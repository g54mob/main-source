using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	public sealed class SentryUser : ISentryJsonSerializable
	{
		private string? _id;

		private string? _username;

		private string? _email;

		private string? _ipAddress;

		private string? _segment;

		private IDictionary<string, string>? _other;

		internal Action<SentryUser>? PropertyChanged { get; set; }

		public string? Id
		{
			get
			{
				return _id;
			}
			set
			{
				if (_id != value)
				{
					_id = value;
					PropertyChanged?.Invoke(this);
				}
			}
		}

		public string? Username
		{
			get
			{
				return _username;
			}
			set
			{
				if (_username != value)
				{
					_username = value;
					PropertyChanged?.Invoke(this);
				}
			}
		}

		public string? Email
		{
			get
			{
				return _email;
			}
			set
			{
				if (_email != value)
				{
					_email = value;
					PropertyChanged?.Invoke(this);
				}
			}
		}

		public string? IpAddress
		{
			get
			{
				return _ipAddress;
			}
			set
			{
				if (_ipAddress != value)
				{
					_ipAddress = value;
					PropertyChanged?.Invoke(this);
				}
			}
		}

		[Obsolete("This property is deprecated and will be removed in a future version.")]
		public string? Segment
		{
			get
			{
				return _segment;
			}
			set
			{
				if (_segment != value)
				{
					_segment = value;
					PropertyChanged?.Invoke(this);
				}
			}
		}

		public IDictionary<string, string> Other
		{
			get
			{
				return _other ?? (_other = new Dictionary<string, string>());
			}
			set
			{
				if (_other != value)
				{
					_other = value;
					PropertyChanged?.Invoke(this);
				}
			}
		}

		public SentryUser Clone()
		{
			SentryUser sentryUser = new SentryUser();
			CopyTo(sentryUser);
			return sentryUser;
		}

		internal void CopyTo(SentryUser? user)
		{
			if (user == null)
			{
				return;
			}
			SentryUser sentryUser = user;
			if (sentryUser.Id == null)
			{
				string text = (sentryUser.Id = Id);
			}
			sentryUser = user;
			if (sentryUser.Username == null)
			{
				string text = (sentryUser.Username = Username);
			}
			sentryUser = user;
			if (sentryUser.Email == null)
			{
				string text = (sentryUser.Email = Email);
			}
			sentryUser = user;
			if (sentryUser.IpAddress == null)
			{
				string text = (sentryUser.IpAddress = IpAddress);
			}
			sentryUser = user;
			if (sentryUser.Segment == null)
			{
				string text = (sentryUser.Segment = Segment);
			}
			sentryUser = user;
			if (sentryUser._other == null)
			{
				sentryUser._other = _other?.ToDictionary((KeyValuePair<string, string> entry) => entry.Key, (KeyValuePair<string, string> entry) => entry.Value);
			}
		}

		internal bool HasAnyData()
		{
			if (Id == null && Username == null && Email == null && IpAddress == null && Segment == null)
			{
				IDictionary<string, string>? other = _other;
				if (other == null)
				{
					return false;
				}
				return other.Count > 0;
			}
			return true;
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? _)
		{
			writer.WriteStartObject();
			writer.WriteStringIfNotWhiteSpace("id", Id);
			writer.WriteStringIfNotWhiteSpace("username", Username);
			writer.WriteStringIfNotWhiteSpace("email", Email);
			writer.WriteStringIfNotWhiteSpace("ip_address", IpAddress);
			writer.WriteStringIfNotWhiteSpace("segment", Segment);
			writer.WriteStringDictionaryIfNotEmpty("other", _other);
			writer.WriteEndObject();
		}

		public static SentryUser FromJson(JsonElement json)
		{
			string id = json.GetPropertyOrNull("id")?.GetString();
			string username = json.GetPropertyOrNull("username")?.GetString();
			string email = json.GetPropertyOrNull("email")?.GetString();
			string ipAddress = json.GetPropertyOrNull("ip_address")?.GetString();
			string segment = json.GetPropertyOrNull("segment")?.GetString();
			Dictionary<string, string> dictionary = json.GetPropertyOrNull("other")?.GetStringDictionaryOrNull();
			return new SentryUser
			{
				Id = id,
				Username = username,
				Email = email,
				IpAddress = ipAddress,
				Segment = segment,
				_other = dictionary?.WhereNotNullValue().ToDict()
			};
		}
	}
}
