using System;
using System.Collections.Generic;
using System.Text;
using Core.Database.Tables;

namespace Core.Relationships.Models
{
    public class RelationshipModel : Relationship
    {
        public new RelationshipPayload Payload { get; set; }
    }
}
