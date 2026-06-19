using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Sentry;
using Sentry.Unity;
using UnityEngine;

[CreateAssetMenu(fileName = "Assets/Resources/Sentry/SentryOptionsConfiguration.cs", menuName = "Sentry/SentryOptionsConfiguration", order = 999)]
public class SentryOptionsConfiguration : SentryRuntimeOptionsConfiguration
{
	public static readonly List<string> piiList = new List<string>();

	private static readonly Regex userIdRegex = new Regex("userid:\\d*");

	private int _numberOfSentEvents;

	public override void Configure(SentryUnityOptions options)
	{
		options.Environment = "prod";
		options.SampleRate = 0.005f;
		options.TracesSampleRate = 0.005;
		options.AttachScreenshot = false;
		options.DefaultTags.Add("dedicated_server", "false");
		options.DefaultTags.Add("pc_storefront", "Steam");
		options.Release = Application.version;
		options.SetBeforeSend(BeforeSend);
		options.SetBeforeBreadcrumb(BeforeBreadcrumb);
	}

	private bool MatchesFilter(string message)
	{
		if (userIdRegex.IsMatch(message))
		{
			return true;
		}
		foreach (string pii in piiList)
		{
			if (message.Contains(pii))
			{
				return true;
			}
		}
		return false;
	}

	private string FilterString(string message)
	{
		message = userIdRegex.Replace(message, "userid:<redacted>");
		foreach (string pii in piiList)
		{
			if (message.Contains(pii))
			{
				message = message.Replace(pii, "<redacted>");
			}
		}
		return message;
	}

	[CanBeNull]
	private Breadcrumb BeforeBreadcrumb(Breadcrumb breadcrumb)
	{
		string text = FilterString(breadcrumb.Message);
		if (text != breadcrumb.Message)
		{
			return new Breadcrumb(text, breadcrumb.Type, breadcrumb.Data, breadcrumb.Category, breadcrumb.Level);
		}
		return breadcrumb;
	}

	[CanBeNull]
	private SentryEvent BeforeSend(SentryEvent sentryEvent)
	{
		if (_numberOfSentEvents > 100)
		{
			return null;
		}
		_numberOfSentEvents++;
		if (sentryEvent != null && sentryEvent.Message?.Message != null)
		{
			sentryEvent.Message.Message = FilterString(sentryEvent.Message.Message);
		}
		return sentryEvent;
	}
}
