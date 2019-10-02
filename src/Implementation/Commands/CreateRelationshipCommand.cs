using System;
using System.Collections.Generic;
using System.Text;
using Core.Database.Enums;
using Core.Database.Tables;
using MediatR;

namespace Core.Relationships.Implementation.Commands
{
    public class CreateRelationshipCommand : Relationship, IRequest<Relationship>
    {

    }
}
