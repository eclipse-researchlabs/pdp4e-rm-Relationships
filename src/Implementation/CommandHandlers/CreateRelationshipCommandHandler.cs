using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Database;
using Core.Database.Tables;
using Core.Relationships.Implementation.Commands;
using MediatR;

namespace Core.Relationships.Implementation.CommandHandlers
{
    public class CreateRelationshipCommandHandler : IRequestHandler<CreateRelationshipCommand, Relationship>
    {
        private IBeawreContext _beawreContext;
        private IMapper _mapper;

        public CreateRelationshipCommandHandler(IBeawreContext beawreContext, IMapper mapper)
        {
            _beawreContext = beawreContext;
            _mapper = mapper;
        }

        public Task<Relationship> Handle(CreateRelationshipCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Relationship>(request);

            _beawreContext.Relationship.Add(entity);
            _beawreContext.SaveChanges();

            return Task.FromResult(entity);
        }
    }
}
