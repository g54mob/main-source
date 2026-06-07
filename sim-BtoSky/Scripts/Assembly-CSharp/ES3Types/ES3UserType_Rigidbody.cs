using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "isKinematic" })]
	public class ES3UserType_Rigidbody : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Rigidbody()
			: base(typeof(Rigidbody))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Rigidbody rigidbody = (Rigidbody)obj;
			writer.WriteProperty("isKinematic", rigidbody.isKinematic, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Rigidbody rigidbody = (Rigidbody)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "isKinematic")
				{
					rigidbody.isKinematic = reader.Read<bool>(ES3Type_bool.Instance);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
