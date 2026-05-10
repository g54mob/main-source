using CTS.BBT;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_CleanableObject : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_CleanableObject()
			: base(typeof(CleanableObject))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			CleanableObject cleanableObject = (CleanableObject)obj;
			writer.WriteProperty("_filthLevel", cleanableObject.FilthLevel);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			CleanableObject cleanableObject = (CleanableObject)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "_filthLevel")
				{
					cleanableObject.SetFilth(reader.Read<int>());
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
