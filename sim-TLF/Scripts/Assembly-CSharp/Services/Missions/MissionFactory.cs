using System;

namespace Services.Missions
{
	public class MissionFactory
	{
		public MissionBuilder Create(string missionId = null)
		{
			return new MissionBuilder(missionId ?? GenerateId("mission"));
		}

		public static string GenerateId(string prefix)
		{
			return $"{prefix}_{Guid.NewGuid():N}";
		}
	}
}
