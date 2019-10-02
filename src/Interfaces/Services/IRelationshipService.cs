﻿using System;
using System.Collections.Generic;
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
    }
}