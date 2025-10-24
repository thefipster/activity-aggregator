using Fip.Strive.Core.Domain.Schemas.Queue.Enums;
using Fip.Strive.Core.Domain.Schemas.Queue.Models;
using Fip.Strive.Harvester.Application.Core.Queue.Models;
using Fip.Strive.Harvester.Application.Core.Queue.Repositories.Contracts;
using Fip.Strive.Harvester.Application.Infrastructure.Contexts;
using Fip.Strive.Harvester.Application.Infrastructure.Models;

namespace Fip.Strive.Harvester.Application.Core.Queue.Repositories;

public class LiteDbJobReader(SignalQueueContext context)
    : LiteDbBaseJobRepository(context),
        IJobReader
{
    public PagedResponse<JobDetails> GetUpcommingJobs(int page, int size)
    {
        var query = Collection
            .Query()
            .Where(x => x.Status == JobStatus.Stored || x.Status == JobStatus.Pending)
            .OrderByDescending(x => x.CreatedAt);

        var count = query.Count();
        var items = query.Skip(page * size).Limit(size).ToArray();

        return new PagedResponse<JobDetails>(items, count);
    }

    public PagedResponse<JobDetails> GetSucceededJobs(int page, int size) =>
        GetJobs(JobStatus.Succeeded, page, size);

    public PagedResponse<JobDetails> GetFailedJobs(int page, int size) =>
        GetJobs(JobStatus.Failed, page, size);

    public PagedResponse<JobDetails> GetJobs(JobStatus status, int page, int size)
    {
        var query = Collection
            .Query()
            .Where(x => x.Status == status)
            .OrderByDescending(x => x.CreatedAt);

        var count = query.Count();
        var items = query.Skip(page * size).Limit(size).ToArray();

        return new PagedResponse<JobDetails>(items, count);
    }
}
