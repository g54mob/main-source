using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using TwitchLib.PubSub.Enums;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
	public class Whisper : MessageData
	{
		public class DataObjThread
		{
			public class SpamInfoObj
			{
				public string Likelihood { get; }

				public long LastMarkedNotSpam { get; }

				public SpamInfoObj(JToken json)
				{
					Likelihood = json.SelectToken("likelihood").ToString();
					LastMarkedNotSpam = long.Parse(json.SelectToken("last_marked_not_spam").ToString());
				}
			}

			public string Id { get; }

			public long LastRead { get; }

			public bool Archived { get; }

			public bool Muted { get; }

			public SpamInfoObj SpamInfo { get; }

			public DataObjThread(JToken json)
			{
				Id = json.SelectToken("id").ToString();
				LastRead = long.Parse(json.SelectToken("last_read").ToString());
				Archived = bool.Parse(json.SelectToken("archived").ToString());
				Muted = bool.Parse(json.SelectToken("muted").ToString());
				SpamInfo = new SpamInfoObj(json.SelectToken("spam_info"));
			}
		}

		public class DataObjWhisperReceived
		{
			public class TagsObj
			{
				public class EmoteObj
				{
					public int Id { get; protected set; }

					public int Start { get; protected set; }

					public int End { get; protected set; }

					public EmoteObj(JToken json)
					{
						Id = int.Parse(json.SelectToken("id").ToString());
						Start = int.Parse(json.SelectToken("start").ToString());
						End = int.Parse(json.SelectToken("end").ToString());
					}
				}

				public readonly List<EmoteObj> Emotes = new List<EmoteObj>();

				public readonly List<Badge> Badges = new List<Badge>();

				public string Login { get; protected set; }

				public string DisplayName { get; protected set; }

				public string Color { get; protected set; }

				public string UserType { get; protected set; }

				public TagsObj(JToken json)
				{
					Login = json.SelectToken("login")?.ToString();
					DisplayName = json.SelectToken("login")?.ToString();
					Color = json.SelectToken("color")?.ToString();
					UserType = json.SelectToken("user_type")?.ToString();
					foreach (JToken item in (IEnumerable<JToken>)json.SelectToken("emotes"))
					{
						Emotes.Add(new EmoteObj(item));
					}
					foreach (JToken item2 in (IEnumerable<JToken>)json.SelectToken("badges"))
					{
						Badges.Add(new Badge(item2));
					}
				}
			}

			public class RecipientObj
			{
				public string Id { get; protected set; }

				public string Username { get; protected set; }

				public string DisplayName { get; protected set; }

				public string Color { get; protected set; }

				public string UserType { get; protected set; }

				public List<Badge> Badges { get; protected set; } = new List<Badge>();

				public RecipientObj(JToken json)
				{
					Id = json.SelectToken("id").ToString();
					Username = json.SelectToken("username")?.ToString();
					DisplayName = json.SelectToken("display_name")?.ToString();
					Color = json.SelectToken("color")?.ToString();
					UserType = json.SelectToken("user_type")?.ToString();
					foreach (JToken item in (IEnumerable<JToken>)json.SelectToken("badges"))
					{
						Badges.Add(new Badge(item));
					}
				}
			}

			public class Badge
			{
				public string Id { get; protected set; }

				public string Version { get; protected set; }

				public Badge(JToken json)
				{
					Id = json.SelectToken("id")?.ToString();
					Version = json.SelectToken("version")?.ToString();
				}
			}

			public string Id { get; protected set; }

			public string ThreadId { get; protected set; }

			public string Body { get; protected set; }

			public long SentTs { get; protected set; }

			public string FromId { get; protected set; }

			public TagsObj Tags { get; protected set; }

			public RecipientObj Recipient { get; protected set; }

			public string Nonce { get; protected set; }

			public DataObjWhisperReceived(JToken json)
			{
				Id = json.SelectToken("id").ToString();
				ThreadId = json.SelectToken("thread_id")?.ToString();
				Body = json.SelectToken("body")?.ToString();
				SentTs = long.Parse(json.SelectToken("sent_ts").ToString());
				FromId = json.SelectToken("from_id").ToString();
				Tags = new TagsObj(json.SelectToken("tags"));
				Recipient = new RecipientObj(json.SelectToken("recipient"));
				Nonce = json.SelectToken("nonce")?.ToString();
			}
		}

		public string Type { get; }

		public WhisperType TypeEnum { get; }

		public string Data { get; }

		public DataObjWhisperReceived DataObjectWhisperReceived { get; }

		public DataObjThread DataObjectThread { get; }

		public Whisper(string jsonStr)
		{
			JObject jObject = JObject.Parse(jsonStr);
			Type = jObject.SelectToken("type").ToString();
			Data = jObject.SelectToken("data").ToString();
			string type = Type;
			string text = type;
			if (!(text == "whisper_received"))
			{
				if (text == "thread")
				{
					TypeEnum = WhisperType.Thread;
					DataObjectThread = new DataObjThread(jObject.SelectToken("data_object"));
				}
				else
				{
					TypeEnum = WhisperType.Unknown;
				}
			}
			else
			{
				TypeEnum = WhisperType.WhisperReceived;
				DataObjectWhisperReceived = new DataObjWhisperReceived(jObject.SelectToken("data_object"));
			}
		}
	}
}
