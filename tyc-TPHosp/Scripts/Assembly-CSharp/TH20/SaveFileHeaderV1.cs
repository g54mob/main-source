using System;
using FullSerializerSave;

namespace TH20
{
	public class SaveFileHeaderV1
	{
		public class SaveInfo
		{
			public DateTime Date;

			public string Name;

			public VersionNumber Version;
		}

		[fsObject("1", new Type[] { })]
		public class GameInfoV1
		{
			public string LevelID;

			public byte[] ThumbnailPNG;

			public int Balance;

			public float Reputation;

			public int HospitalLevel;

			public int HospitalValue;
		}

		[fsObject("2", new Type[] { typeof(GameInfoV1) })]
		public class GameInfoV2
		{
			public string LevelID;

			public ByteArray ThumbnailPNG;

			public int Balance;

			public float Reputation;

			public int HospitalLevel;

			public int HospitalValue;

			public GameInfoV2(GameInfoV1 old)
			{
				LevelID = old.LevelID;
				ThumbnailPNG = new ByteArray
				{
					Bytes = old.ThumbnailPNG
				};
				Balance = old.Balance;
				Reputation = old.Reputation;
				HospitalLevel = old.HospitalLevel;
				HospitalValue = old.HospitalValue;
			}
		}

		[fsObject("3", new Type[] { typeof(GameInfoV2) })]
		public class GameInfo
		{
			public string LevelID;

			public ByteArray ThumbnailPNG;

			public int Balance;

			public float Reputation;

			public int HospitalLevel;

			public float HospitalLevelProgress;

			public int HospitalValue;

			public GameInfo()
			{
			}

			public GameInfo(GameInfoV2 old)
			{
				LevelID = old.LevelID;
				ThumbnailPNG = old.ThumbnailPNG;
				Balance = old.Balance;
				Reputation = old.Reputation;
				HospitalLevel = old.HospitalLevel;
				HospitalLevelProgress = 0f;
				HospitalValue = old.HospitalValue;
			}
		}

		public readonly SaveInfo saveInfo;

		public readonly GameInfo gameInfo;

		public bool IsBroken { get; private set; }
	}
}
