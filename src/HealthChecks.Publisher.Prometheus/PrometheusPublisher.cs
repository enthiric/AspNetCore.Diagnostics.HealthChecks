using Microsoft.Extensions.Diagnostics.HealthChecks;
using Prometheus.Advanced;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HealthChecks.Publisher.Prometheus
{
    internal sealed class PrometheusPublisher : LivenessPrometheusMetrics, IHealthCheckPublisher
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly Uri _targetUrl;

        public PrometheusPublisher()
        {
        }
        public async Task PublishAsync(HealthReport report, CancellationToken cancellationToken)
        {
            WriteMetricsFromHealthReport(report);
        }
    }
}