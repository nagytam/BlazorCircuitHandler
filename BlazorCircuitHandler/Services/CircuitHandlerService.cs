using Microsoft.AspNetCore.Components.Server.Circuits;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;


namespace BlazorCircuitHandler.Services
{
    public class CircuitHandlerService : CircuitHandler
    {
        public ConcurrentDictionary<string, Circuit> Circuits { get; set; }

        public CircuitHandlerService()
        {
            Circuits = new ConcurrentDictionary<string, Circuit>();
        }

        public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            Circuits[circuit.Id] = circuit;
            return base.OnCircuitOpenedAsync(circuit, cancellationToken);
        }

        public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            Circuit circuitRemoved;
            Circuits.TryRemove(circuit.Id, out circuitRemoved);
            return base.OnCircuitClosedAsync(circuit, cancellationToken);
        }

        public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            return base.OnConnectionDownAsync(circuit, cancellationToken);
        }

        public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            return base.OnConnectionUpAsync(circuit, cancellationToken);
        }
    }
}
