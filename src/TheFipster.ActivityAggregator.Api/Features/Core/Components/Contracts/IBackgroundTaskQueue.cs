namespace TheFipster.ActivityAggregator.Api.Features.Core.Components.Contracts;

public interface IBackgroundTaskQueue
{
    void QueueBackgroundWorkItem(Func<CancellationToken, Task> workItem);

    Task<Func<CancellationToken, Task>> DequeueAsync(CancellationToken cancellationToken);
}
