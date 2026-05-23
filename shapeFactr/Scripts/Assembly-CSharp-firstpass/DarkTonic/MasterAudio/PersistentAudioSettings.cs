namespace DarkTonic.MasterAudio
{
	public static class PersistentAudioSettings
	{
		public const string SfxVolKey = "MA_sfxVolume";

		public const string MusicVolKey = "MA_musicVolume";

		public const string SfxMuteKey = "MA_sfxMute";

		public const string MusicMuteKey = "MA_musicMute";

		public const string BusVolKey = "MA_BusVolume_";

		public const string GroupVolKey = "MA_GroupVolume_";

		public const string BusKeysKey = "MA_BusKeys";

		public const string GroupKeysKey = "MA_GroupsKeys";

		public const string Separator = ";";

		public static string BusesUpdatedKeys
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static string GroupsUpdatedKeys
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static bool? MixerMuted
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static float? MixerVolume
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static bool? MusicMuted
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static float? MusicVolume
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static void SetBusVolume(string busName, float vol)
		{
		}

		public static string MakeBusKey(string busName)
		{
			return null;
		}

		public static float? GetBusVolume(string busName)
		{
			return null;
		}

		public static string GetGroupKey(string groupName)
		{
			return null;
		}

		public static void SetGroupVolume(string grpName, float vol)
		{
		}

		public static float? GetGroupVolume(string grpName)
		{
			return null;
		}

		public static void RestoreMasterSettings()
		{
		}
	}
}
