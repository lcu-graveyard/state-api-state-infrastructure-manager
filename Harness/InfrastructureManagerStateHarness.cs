using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fathym;
using Fathym.Design.Singleton;
using LCU.Graphs.Registry.Enterprises;
using LCU.Runtime;
using LCU.State.API.State.InfrastructureManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace LCU.State.API.State.InfrastructureManager.Harness
{
    public class InfrastructureManagerStateHarness : LCUStateHarness<InfrastructureManagerState>
    {
        #region Fields
        protected readonly string container;

        const string lcuPathRoot = "_lcu";
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public InfrastructureManagerStateHarness(HttpRequest req, ILogger log, InfrastructureManagerState state)
            : base(req, log, state)
        {
            this.container = "Default";
        }
        #endregion

        #region API Methods
        public virtual async Task<InfrastructureManagerState> EnableInfrastructure()
        {
            state.InfrastructureEnabled = !state.InfrastructureEnabled;
            
            return state;
        }
        
        public virtual async Task<InfrastructureManagerState> Ensure()
        {
            return state;
        }
        #endregion

        #region Helpers
        #endregion
    }

    public enum AddNewTypes
    {
        None,
        App,
    }
}