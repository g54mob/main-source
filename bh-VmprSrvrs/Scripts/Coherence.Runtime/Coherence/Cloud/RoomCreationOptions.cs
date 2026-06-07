using System.Collections.Generic;

namespace Coherence.Cloud
{
	public class RoomCreationOptions
	{
		public int MaxClients;

		public string[] Tags;

		public Dictionary<string, string> KeyValues;

		public bool FindOrCreate;

		public static RoomCreationOptions Default => null;
	}
}
