﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Database;
using Core.Database.Enums;
using Core.Database.Tables;
using Core.Relationships.Implementation.Commands;
using Core.Relationships.Interfaces.Services;
using MediatR;

namespace Core.Relationships.Implementation.Services
{
    public class RelationshipService : IRelationshipService
    {
        private IMediator _mediator;
        private IMapper _mapper;
        private IBeawreContext _beawreContext;

        public RelationshipService(IMediator mediator, IBeawreContext beawreContext, IMapper mapper)
        {
            _mediator = mediator;
            _beawreContext = beawreContext;
            _mapper = mapper;
        }

        public async Task<Relationship> Create(CreateRelationshipCommand command) => await _mediator.Send(command);

        public void Delete(Guid id)
        {
            _beawreContext.Assets.FirstOrDefault(x => x.Id == id).IsDeleted = true;
            foreach (var item in _beawreContext.Relationship.Where(x => x.FromId == id && x.FromType == ObjectType.AssetGroup))
                item.IsDeleted = true;
            _beawreContext.SaveChanges();
        }
    }
}