using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HospitalTests.Integration
{
    public class RoomTests : BaseIntegrationTest
    {
        public RoomTests(TestDatabaseFactory<Startup> factory) : base(factory) {}
        private static RoomsController SetupController(IServiceScope scope)
        {
            return new RoomsController(scope.ServiceProvider.GetRequiredService<IRoomService>());
        }


        [Fact]
        public void Retrieves_single_room()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.GetById(1))?.Value as Room;

            Assert.NotNull(result);
        }
    }
}
