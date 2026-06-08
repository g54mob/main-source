using Newtonsoft.Json.Linq;
using UnityEngine;

namespace GRP
{
	public class Module
	{
		public string title;

		public string tooltip;

		public PartConfig part;

		public Vector3 rotation;

		public bool copySelected;

		public JObject data;

		public bool lockRotation;

		public bool lockSize;

		public string checksum;

		public void BuildChecksum()
		{
		}

		public static Module FromConfig(ModuleConfig config)
		{
			return null;
		}

		public ModuleData Serialize()
		{
			return null;
		}

		public static Module FromData(ModuleData data, EntityManagerConfig parts)
		{
			return null;
		}
	}
}
