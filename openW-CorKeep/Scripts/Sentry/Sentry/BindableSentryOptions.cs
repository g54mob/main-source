using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;

namespace Sentry
{
	internal class BindableSentryOptions
	{
		public bool? IsGlobalModeEnabled { get; set; }

		public bool? EnableScopeSync { get; set; }

		public List<string>? TagFilters { get; set; }

		public bool? SendDefaultPii { get; set; }

		public bool? IsEnvironmentUser { get; set; }

		public string? ServerName { get; set; }

		public bool? AttachStacktrace { get; set; }

		public int? MaxBreadcrumbs { get; set; }

		public float? SampleRate { get; set; }

		public string? Release { get; set; }

		public string? Distribution { get; set; }

		public string? Environment { get; set; }

		public string? Dsn { get; set; }

		public int? MaxQueueItems { get; set; }

		public int? MaxCacheItems { get; set; }

		public TimeSpan? ShutdownTimeout { get; set; }

		public TimeSpan? FlushTimeout { get; set; }

		public DecompressionMethods? DecompressionMethods { get; set; }

		public CompressionLevel? RequestBodyCompressionLevel { get; set; }

		public bool? RequestBodyCompressionBuffered { get; set; }

		public bool? SendClientReports { get; set; }

		public bool? Debug { get; set; }

		public SentryLevel? DiagnosticLevel { get; set; }

		public ReportAssembliesMode? ReportAssembliesMode { get; set; }

		public DeduplicateMode? DeduplicateMode { get; set; }

		public string? CacheDirectoryPath { get; set; }

		public bool? CaptureFailedRequests { get; set; }

		public List<string>? FailedRequestTargets { get; set; }

		public bool? DisableFileWrite { get; set; }

		public TimeSpan? InitCacheFlushTimeout { get; set; }

		public Dictionary<string, string>? DefaultTags { get; set; }

		public bool? EnableTracing { get; set; }

		public double? TracesSampleRate { get; set; }

		public List<string>? TracePropagationTargets { get; set; }

		public double? ProfilesSampleRate { get; set; }

		public StackTraceMode? StackTraceMode { get; set; }

		public long? MaxAttachmentSize { get; set; }

		public StartupTimeDetectionMode? DetectStartupTime { get; set; }

		public TimeSpan? AutoSessionTrackingInterval { get; set; }

		public bool? AutoSessionTracking { get; set; }

		public bool? UseAsyncFileIO { get; set; }

		public bool? JsonPreserveReferences { get; set; }

		public bool? EnableSpotlight { get; set; }

		public string? SpotlightUrl { get; set; }

		public void ApplyTo(SentryOptions options)
		{
			options.IsGlobalModeEnabled = IsGlobalModeEnabled ?? options.IsGlobalModeEnabled;
			options.EnableScopeSync = EnableScopeSync ?? options.EnableScopeSync;
			ICollection<SubstringOrRegexPattern> collection = TagFilters?.Select((string s) => new SubstringOrRegexPattern(s)).ToList();
			options.TagFilters = collection ?? options.TagFilters;
			options.SendDefaultPii = SendDefaultPii ?? options.SendDefaultPii;
			options.IsEnvironmentUser = IsEnvironmentUser ?? options.IsEnvironmentUser;
			options.ServerName = ServerName ?? options.ServerName;
			options.AttachStacktrace = AttachStacktrace ?? options.AttachStacktrace;
			options.MaxBreadcrumbs = MaxBreadcrumbs ?? options.MaxBreadcrumbs;
			options.SampleRate = SampleRate ?? options.SampleRate;
			options.Release = Release ?? options.Release;
			options.Distribution = Distribution ?? options.Distribution;
			options.Environment = Environment ?? options.Environment;
			options.Dsn = Dsn ?? options.Dsn;
			options.MaxQueueItems = MaxQueueItems ?? options.MaxQueueItems;
			options.MaxCacheItems = MaxCacheItems ?? options.MaxCacheItems;
			options.ShutdownTimeout = ShutdownTimeout ?? options.ShutdownTimeout;
			options.FlushTimeout = FlushTimeout ?? options.FlushTimeout;
			options.DecompressionMethods = DecompressionMethods ?? options.DecompressionMethods;
			options.RequestBodyCompressionLevel = RequestBodyCompressionLevel ?? options.RequestBodyCompressionLevel;
			options.RequestBodyCompressionBuffered = RequestBodyCompressionBuffered ?? options.RequestBodyCompressionBuffered;
			options.SendClientReports = SendClientReports ?? options.SendClientReports;
			options.Debug = Debug ?? options.Debug;
			options.DiagnosticLevel = DiagnosticLevel ?? options.DiagnosticLevel;
			options.ReportAssembliesMode = ReportAssembliesMode ?? options.ReportAssembliesMode;
			options.DeduplicateMode = DeduplicateMode ?? options.DeduplicateMode;
			options.CacheDirectoryPath = CacheDirectoryPath ?? options.CacheDirectoryPath;
			options.CaptureFailedRequests = CaptureFailedRequests ?? options.CaptureFailedRequests;
			IList<SubstringOrRegexPattern> list = FailedRequestTargets?.Select((string s) => new SubstringOrRegexPattern(s)).ToList();
			options.FailedRequestTargets = list ?? options.FailedRequestTargets;
			options.DisableFileWrite = DisableFileWrite ?? options.DisableFileWrite;
			options.InitCacheFlushTimeout = InitCacheFlushTimeout ?? options.InitCacheFlushTimeout;
			options.DefaultTags = DefaultTags ?? options.DefaultTags;
			options.EnableTracing = EnableTracing ?? options.EnableTracing;
			options.TracesSampleRate = TracesSampleRate ?? options.TracesSampleRate;
			options.ProfilesSampleRate = ProfilesSampleRate ?? options.ProfilesSampleRate;
			list = TracePropagationTargets?.Select((string s) => new SubstringOrRegexPattern(s)).ToList();
			options.TracePropagationTargets = list ?? options.TracePropagationTargets;
			options.StackTraceMode = StackTraceMode ?? options.StackTraceMode;
			options.MaxAttachmentSize = MaxAttachmentSize ?? options.MaxAttachmentSize;
			options.DetectStartupTime = DetectStartupTime ?? options.DetectStartupTime;
			options.AutoSessionTrackingInterval = AutoSessionTrackingInterval ?? options.AutoSessionTrackingInterval;
			options.AutoSessionTracking = AutoSessionTracking ?? options.AutoSessionTracking;
			options.UseAsyncFileIO = UseAsyncFileIO ?? options.UseAsyncFileIO;
			options.JsonPreserveReferences = JsonPreserveReferences ?? options.JsonPreserveReferences;
			options.EnableSpotlight = EnableSpotlight ?? options.EnableSpotlight;
			options.SpotlightUrl = SpotlightUrl ?? options.SpotlightUrl;
		}
	}
}
