using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using LCU.State.API.State.InfrastructureManager.Harness;
using LCU.State.API.State.InfrastructureManager.Models;
using System.Runtime.Serialization;

namespace LCU.State.API.State.InfrastructureManager
{    
    [Serializable]
    [DataContract]
    public class EnableInfrastructureRequest
    {
        [DataMember]
        public virtual string DeploymentTemplate { get; set; }
    }

    public static class EnableInfrastructure
    {
        [FunctionName("EnableInfrastructure")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Admin, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            return await req.Manage<dynamic, InfrastructureManagerState, InfrastructureManagerStateHarness>(log, async (mgr, reqData) =>
            {
                await mgr.EnableInfrastructure();

                return await mgr.WhenAll();
            });
        }
    }
}
