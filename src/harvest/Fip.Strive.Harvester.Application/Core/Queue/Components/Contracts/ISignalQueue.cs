using Fip.Strive.Harvester.Application.Core.Queue.Models;

namespace Fip.Strive.Harvester.Application.Core.Queue.Components.Contracts;

public interface ISignalQueue
{
    int Count { get; }
    Task EnqueueAsync(Signal signal, CancellationToken ct = default);
    Task<JobDetails?> DequeueAsync(CancellationToken ct = default);
    Task MarkAsStartedAsync(Guid jobId, CancellationToken ct = default);
    Task MarkAsSuccessAsync(Guid jobId, CancellationToken ct = default);
    Task MarkAsFailedAsync(Guid jobId, string reason, CancellationToken ct = default);
    Task MarkAsFailedAsync(Guid jobId, string reason, Exception ex, CancellationToken ct = default);
}
