using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Core.Database.Tables;
using Core.Relationships.Implementation.Commands;
using Core.Relationships.Implementation.Services;
using Core.Relationships.Interfaces.Services;
using Core.Relationships.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Core.Relationships
{
    public class Config
    {
        public static void InitializeServices(ref IServiceCollection services)
        {
            // Services
            services.AddScoped<IRelationshipService, RelationshipService>();

            // Queries
        }
    }

    public class RelationshipProfile : Profile
    {
        public RelationshipProfile()
        {
            CreateMap<CreateRelationshipCommand, Relationship>();

            CreateMap<Relationship, RelationshipModel>()
                .ForMember(x => x.Payload, src => src.MapFrom(y => string.IsNullOrEmpty(y.Payload) ? new RelationshipPayload() : JsonConvert.DeserializeObject<RelationshipPayload>(y.Payload)))
                ;
        }
    }
}
