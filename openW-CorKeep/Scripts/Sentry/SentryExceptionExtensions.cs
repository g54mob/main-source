using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sentry.Protocol;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class SentryExceptionExtensions
{
	public static void AddSentryTag(this Exception ex, string name, string value)
	{
		ex.Data.Add("sentry:tag:" + name, value);
	}

	public static void AddSentryContext(this Exception ex, string name, IReadOnlyDictionary<string, object> data)
	{
		ex.Data.Add("sentry:context:" + name, data);
	}

	public static void SetSentryMechanism(this Exception ex, string type, string? description = null, bool? handled = null)
	{
		ex.Data[Mechanism.MechanismKey] = type;
		if (string.IsNullOrWhiteSpace(description))
		{
			ex.Data.Remove(Mechanism.DescriptionKey);
		}
		else
		{
			ex.Data[Mechanism.DescriptionKey] = description;
		}
		if (!handled.HasValue)
		{
			ex.Data.Remove(Mechanism.HandledKey);
		}
		else
		{
			ex.Data[Mechanism.HandledKey] = handled;
		}
	}
}
