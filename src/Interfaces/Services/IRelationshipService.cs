using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Database.Tables;
using Core.Relationships.Implementation.Commands;

namespace Core.Relationships.Interfaces.Services
{
    public interface IRelationshipService
    {
        Task<Relationship> Create(CreateRelationshipCommand command);
        void Delete(Guid id);
        List<Relationship> GetList(Expression<Func<Relationship, bool>> func);
        void Delete(Expression<Func<Relationship, bool>> func);
    }
}
