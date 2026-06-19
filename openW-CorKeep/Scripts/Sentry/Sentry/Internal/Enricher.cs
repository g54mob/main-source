using System;
using System.Runtime.InteropServices;
using Sentry.PlatformAbstractions;
using Sentry.Protocol;

namespace Sentry.Internal
{
	internal class Enricher
	{
		internal const string DefaultIpAddress = "{{auto}}";

		private readonly SentryOptions _options;

		private readonly Lazy<Runtime> _runtimeLazy = new Lazy<Runtime>(delegate
		{
			SentryRuntime current = SentryRuntime.Current;
			return new Runtime
			{
				Name = current.Name,
				Version = current.Version,
				Identifier = current.Identifier,
				RawDescription = current.Raw
			};
		});

		public Enricher(SentryOptions options)
		{
			_options = options;
		}

		public void Apply(IEventLike eventLike)
		{
			if (!eventLike.Contexts.ContainsKey("runtime"))
			{
				eventLike.Contexts["runtime"] = _runtimeLazy.Value;
			}
			if (!eventLike.Contexts.ContainsKey("os") && !SentryRuntime.Current.IsMono())
			{
				eventLike.Contexts.OperatingSystem.RawDescription = RuntimeInformation.OSDescription;
			}
			if (eventLike.Sdk.Version == null && eventLike.Sdk.Name == null)
			{
				eventLike.Sdk.Name = "sentry.dotnet";
				eventLike.Sdk.Version = SdkVersion.Instance.Version;
			}
			if (SdkVersion.Instance.Version != null)
			{
				eventLike.Sdk.AddPackage("nuget:" + SdkVersion.Instance.Name, SdkVersion.Instance.Version);
			}
			IEventLike eventLike2 = eventLike;
			if (eventLike2.Release == null)
			{
				string text = (eventLike2.Release = _options.SettingLocator.GetRelease());
			}
			eventLike2 = eventLike;
			if (eventLike2.Distribution == null)
			{
				string text = (eventLike2.Distribution = _options.Distribution);
			}
			eventLike2 = eventLike;
			if (eventLike2.Environment == null)
			{
				string text = (eventLike2.Environment = _options.SettingLocator.GetEnvironment());
			}
			SentryOptions options = _options;
			if (options != null && options.SendDefaultPii && options.IsEnvironmentUser && !eventLike.HasUser())
			{
				eventLike.User.Username = Environment.UserName;
			}
			SentryUser user = eventLike.User;
			if (user.Id == null)
			{
				string text = (user.Id = _options.InstallationId);
			}
			user = eventLike.User;
			if (user.IpAddress == null)
			{
				string text = (user.IpAddress = "{{auto}}");
			}
			App app = eventLike.Contexts.App;
			if (!app.StartTime.HasValue)
			{
				DateTimeOffset? dateTimeOffset = (app.StartTime = ProcessInfo.Instance?.StartupTime);
			}
			Device device = eventLike.Contexts.Device;
			if (!device.BootTime.HasValue)
			{
				DateTimeOffset? dateTimeOffset = (device.BootTime = ProcessInfo.Instance?.BootTime);
			}
			eventLike.Contexts.App.InForeground = ProcessInfo.Instance?.ApplicationIsActivated(_options);
			_options.ApplyDefaultTags(eventLike);
		}

		public void Apply(SentryCheckIn checkIn)
		{
			SentryCheckIn sentryCheckIn = checkIn;
			if (sentryCheckIn.Release == null)
			{
				string text = (sentryCheckIn.Release = _options.SettingLocator.GetRelease());
			}
			sentryCheckIn = checkIn;
			if (sentryCheckIn.Environment == null)
			{
				string text = (sentryCheckIn.Environment = _options.SettingLocator.GetEnvironment());
			}
		}
	}
}
