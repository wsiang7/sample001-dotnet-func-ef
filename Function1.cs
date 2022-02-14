using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Sample.Models.SampleDb;
using Newtonsoft.Json;

namespace Sample.Function
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly SampleDbContext _sampleDbContext;

        public Function1(ILogger<Function1> logger, SampleDbContext sampleDbContext)
        {
            this._logger = logger;
            this._sampleDbContext = sampleDbContext;
        }

        [FunctionName("Function1")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "InsertAddressBook" })]
        [OpenApiRequestBody("application/json", typeof(AddressBook))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,            
            ILogger log)
        {
            try
            {   
                var strReqBody = await req.ReadAsStringAsync();
                AddressBook reqBody = JsonConvert.DeserializeObject<AddressBook>(strReqBody);
                _sampleDbContext.Add(reqBody);
                await _sampleDbContext.SaveChangesAsync();
                return new OkObjectResult(reqBody.Name + " has been saved");
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }
    }
}

