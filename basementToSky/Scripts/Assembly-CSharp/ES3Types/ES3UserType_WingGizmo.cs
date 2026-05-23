using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "wingGO", "lineGizmo", "originRot", "selected" })]
	public class ES3UserType_WingGizmo : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_WingGizmo()
			: base(typeof(WingGizmo))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			WingGizmo wingGizmo = (WingGizmo)obj;
			writer.WritePropertyByRef("wingGO", wingGizmo.wingGO);
			writer.WritePropertyByRef("lineGizmo", wingGizmo.lineGizmo);
			writer.WritePrivateField("originRot", wingGizmo);
			writer.WriteProperty("selected", wingGizmo.selected, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			WingGizmo wingGizmo = (WingGizmo)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "wingGO":
					wingGizmo.wingGO = reader.Read<GameObject>(ES3Type_GameObject.Instance);
					break;
				case "lineGizmo":
					wingGizmo.lineGizmo = reader.Read<WingLineGizmo>();
					break;
				case "originRot":
					wingGizmo = (WingGizmo)reader.SetPrivateField("originRot", reader.Read<Vector3>(), wingGizmo);
					break;
				case "selected":
					wingGizmo.selected = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
