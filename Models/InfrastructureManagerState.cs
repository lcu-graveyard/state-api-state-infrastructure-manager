
using System.Collections.Generic;
using System.Runtime.Serialization;
using LCU.Graphs.Registry.Enterprises;

namespace LCU.State.API.State.InfrastructureManager.Models
{
    [DataContract]
    public class InfrastructureManagerState
    {
        [DataMember]
        public virtual bool InfrastructureEnabled { get; set; }
        
        [DataMember]
        public virtual bool Loading { get; set; }
    }
}