using System.Collections.Generic;
using Platforms;

namespace Kitchen.NetworkSupport
{
	public struct JoinCode
	{
		public string RoomName;

		public PlatformType SourcePlatform;

		private static Dictionary<PlatformType, string> PlatformMap = new Dictionary<PlatformType, string>
		{
			{
				PlatformType.Null,
				"A"
			},
			{
				PlatformType.Steam,
				"B"
			},
			{
				PlatformType.WindowsStore,
				"C"
			},
			{
				PlatformType.Xbox,
				"D"
			},
			{
				PlatformType.PS4,
				"E"
			},
			{
				PlatformType.PS5,
				"F"
			},
			{
				PlatformType.Switch,
				"G"
			}
		};

		public string Actual => RoomName + PlatformCharacter(SourcePlatform);

		public override string ToString()
		{
			return Actual;
		}

		public static JoinCode Create(string room_name)
		{
			return new JoinCode
			{
				RoomName = room_name,
				SourcePlatform = PlatformSettings.CurrentPlatformType
			};
		}

		public static JoinCode CreateFromRemote(string actual_code)
		{
			if (actual_code.Length < JoinCodeHelpers.FullLength)
			{
				return default(JoinCode);
			}
			string text = actual_code.Substring(0, JoinCodeHelpers.FullLength);
			return new JoinCode
			{
				RoomName = text.Substring(0, JoinCodeHelpers.FullLength - 1),
				SourcePlatform = GetPlatform(text[JoinCodeHelpers.FullLength - 1].ToString())
			};
		}

		public static string PlatformCharacter(PlatformType platform)
		{
			if (PlatformMap.TryGetValue(platform, out var value))
			{
				return value;
			}
			return "A";
		}

		public static PlatformType GetPlatform(string character)
		{
			foreach (KeyValuePair<PlatformType, string> item in PlatformMap)
			{
				if (item.Value == character)
				{
					return item.Key;
				}
			}
			return PlatformType.Null;
		}
	}
}
