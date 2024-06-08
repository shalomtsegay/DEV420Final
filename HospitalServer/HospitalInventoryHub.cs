using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading;


namespace HospitalServer
{
    public class HospitalInventoryHub : Hub
    {
        private Timer _timer;

        public void StartStockPriceUpdates()
        {
            var context = Context.ConnectionAborted;
            var clients = Clients;

            _timer = new Timer(async _ =>
            {
                if (context.IsCancellationRequested)
                {
                    _timer.Dispose();
                    return;
                }

                var inventoryStock = new Random().Next(100, 1000);
                await clients.All.SendAsync("ReceiveInventoryStock", inventoryStock);
            }, null, 0, 1000);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _timer?.Dispose();
            await base.OnDisconnectedAsync(exception);
        }
    }
}
