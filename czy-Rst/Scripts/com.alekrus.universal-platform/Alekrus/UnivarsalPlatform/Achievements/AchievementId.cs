namespace Alekrus.UnivarsalPlatform.Achievements
{
	public struct AchievementId
	{
		public string Id;

		public AchievementId(string parId)
		{
			Id = parId;
		}

		public static implicit operator AchievementId(string value)
		{
			return new AchievementId(value);
		}

		public static implicit operator string(AchievementId value)
		{
			return value.Id;
		}

		public override string ToString()
		{
			return Id.ToString();
		}
	}
}
