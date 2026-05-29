using System;

namespace FuryStudios.FurySDK
{
	[Serializable]
	public struct AchievementID
	{
		public string id;

		public AchievementID(string id)
		{
			this.id = null;
		}

		public static explicit operator string(AchievementID achievement)
		{
			return null;
		}

		public static implicit operator AchievementID(string id)
		{
			return default(AchievementID);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
