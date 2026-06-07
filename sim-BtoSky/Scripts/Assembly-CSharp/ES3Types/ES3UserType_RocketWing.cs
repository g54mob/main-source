using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "gizmos" })]
	public class ES3UserType_RocketWing : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_RocketWing()
			: base(typeof(RocketWing))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			RocketWing rocketWing = (RocketWing)obj;
			writer.WriteProperty("gizmos", rocketWing.gizmos, ES3Type_GameObjectArray.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			RocketWing rocketWing = (RocketWing)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "gizmos")
				{
					rocketWing.gizmos = reader.Read<GameObject[]>(ES3Type_GameObjectArray.Instance);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
