using System.Collections.Generic;

namespace GRP
{
	public class BakedMission
	{
		public MissionPart missionPart;

		public ProjectContainer source;

		public List<Part> entries;

		public Dictionary<string, object> values;

		public void Write(string key, object data)
		{
		}

		public T Read<T>(string key)
		{
			return default(T);
		}
	}
}
