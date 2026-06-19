using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sentry
{
	public static class BuiltInSystemDiagnosticsMeters
	{
		private const string MicrosoftAspNetCoreHostingPattern = "^Microsoft\\.AspNetCore\\.Hosting$";

		private const string MicrosoftAspNetCoreRoutingPattern = "^Microsoft\\.AspNetCore\\.Routing$";

		private const string MicrosoftAspNetCoreDiagnosticsPattern = "^Microsoft\\.AspNetCore\\.Diagnostics$";

		private const string MicrosoftAspNetCoreRateLimitingPattern = "^Microsoft\\.AspNetCore\\.RateLimiting$";

		private const string MicrosoftAspNetCoreHeaderParsingPattern = "^Microsoft\\.AspNetCore\\.HeaderParsing$";

		private const string MicrosoftAspNetCoreServerKestrelPattern = "^Microsoft\\.AspNetCore\\.Server\\.Kestrel$";

		private const string MicrosoftAspNetCoreHttpConnectionsPattern = "^Microsoft\\.AspNetCore\\.Http\\.Connections$";

		private const string MicrosoftExtensionsDiagnosticsHealthChecksPattern = "^Microsoft\\.Extensions\\.Diagnostics\\.HealthChecks$";

		private const string MicrosoftExtensionsDiagnosticsResourceMonitoringPattern = "^Microsoft\\.Extensions\\.Diagnostics\\.ResourceMonitoring$";

		private const string OpenTelemetryInstrumentationRuntimePattern = "^OpenTelemetry\\.Instrumentation\\.Runtime$";

		private const string SystemNetNameResolutionPattern = "^System\\.Net\\.NameResolution$";

		private const string SystemNetHttpPattern = "^System\\.Net\\.Http$";

		public static readonly SubstringOrRegexPattern MicrosoftAspNetCoreHosting = new Regex("^Microsoft\\.AspNetCore\\.Hosting$", RegexOptions.Compiled);

		public static readonly SubstringOrRegexPattern MicrosoftAspNetCoreRouting = new Regex("^Microsoft\\.AspNetCore\\.Routing$", RegexOptions.Compiled);

		public static readonly SubstringOrRegexPattern MicrosoftAspNetCoreDiagnostics = new Regex("^Microsoft\\.AspNetCore\\.Diagnostics$", RegexOptions.Compiled);

		public static readonly SubstringOrRegexPattern MicrosoftAspNetCoreRateLimiting = new Regex("^Microsoft\\.AspNetCore\\.RateLimiting$", RegexOptions.Compiled);

		public static readonly SubstringOrRegexPattern MicrosoftAspNetCoreHeaderParsing = new Regex("^Microsoft\\.AspNetCore\\.HeaderParsing$", RegexOptions.Compiled);

		public static readonly SubstringOrRegexPattern MicrosoftAspNetCoreServerKestrel = new Regex("^Microsoft\\.AspNetCore\\.Server\\.Kestrel$", RegexOptions.Compiled);

		public static readonly SubstringOrRegexPattern MicrosoftAspNetCoreHttpConnections = new Regex("^Microsoft\\.AspNetCore\\.Http\\.Connections$", RegexOptions.Compiled);

		public static readonly SubstringOrRegexPattern MicrosoftExtensionsDiagnosticsHealthChecks = new Regex("^Microsoft\\.Extensions\\.Diagnostics\\.HealthChecks$", RegexOptions.Compiled);

		public static readonly SubstringOrRegexPattern MicrosoftExtensionsDiagnosticsResourceMonitoring = new Regex("^Microsoft\\.Extensions\\.Diagnostics\\.ResourceMonitoring$", RegexOptions.Compiled);

		public static readonly SubstringOrRegexPattern OpenTelemetryInstrumentationRuntime = new Regex("^OpenTelemetry\\.Instrumentation\\.Runtime$", RegexOptions.Compiled);

		public static readonly SubstringOrRegexPattern SystemNetNameResolution = new Regex("^System\\.Net\\.NameResolution$", RegexOptions.Compiled);

		public static readonly SubstringOrRegexPattern SystemNetHttp = new Regex("^System\\.Net\\.Http$", RegexOptions.Compiled);

		private static readonly Lazy<IList<SubstringOrRegexPattern>> LazyAll = new Lazy<IList<SubstringOrRegexPattern>>(() => new List<SubstringOrRegexPattern>
		{
			MicrosoftAspNetCoreHosting, MicrosoftAspNetCoreRouting, MicrosoftAspNetCoreDiagnostics, MicrosoftAspNetCoreRateLimiting, MicrosoftAspNetCoreHeaderParsing, MicrosoftAspNetCoreServerKestrel, MicrosoftAspNetCoreHttpConnections, MicrosoftExtensionsDiagnosticsHealthChecks, MicrosoftExtensionsDiagnosticsResourceMonitoring, OpenTelemetryInstrumentationRuntime,
			SystemNetNameResolution, SystemNetHttp
		});

		public static IList<SubstringOrRegexPattern> All => LazyAll.Value;
	}
}
