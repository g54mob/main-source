using CTS;
using CTS.AI;
using CTS.BBT;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"<ContextActorData>k__BackingField", "ToiletSettingsSO", "_openRotation", "_openEasing", "_closedRotation", "_closeEasing", "_doorRotationDuration", "<LoadTarget>k__BackingField", "<LoadedTarget>k__BackingField", "<UnloadTarget>k__BackingField",
		"sfxToiletList", "_vfxAnchor", "_vfxPee", "_doorTransform", "NavMeshObstacle", "_debugMode", "_doorStatus", "_dirtiness", "<IsDirty>k__BackingField"
	})]
	public class ES3UserType_Toilet : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Toilet()
			: base(typeof(Toilet))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Toilet toilet = (Toilet)obj;
			writer.WritePrivateField("<ContextActorData>k__BackingField", toilet);
			writer.WritePropertyByRef("ToiletSettingsSO", toilet.ToiletSettingsSO);
			writer.WritePrivateField("_openRotation", toilet);
			writer.WritePrivateField("_openEasing", toilet);
			writer.WritePrivateField("_closedRotation", toilet);
			writer.WritePrivateField("_closeEasing", toilet);
			writer.WritePrivateField("_doorRotationDuration", toilet);
			writer.WritePrivateFieldByRef("<LoadTarget>k__BackingField", toilet);
			writer.WritePrivateFieldByRef("<LoadedTarget>k__BackingField", toilet);
			writer.WritePrivateFieldByRef("<UnloadTarget>k__BackingField", toilet);
			writer.WritePropertyByRef("sfxToiletList", toilet.sfxToiletList);
			writer.WritePrivateFieldByRef("_vfxAnchor", toilet);
			writer.WritePrivateField("_vfxPee", toilet);
			writer.WritePrivateField("_doorTransform", toilet);
			writer.WritePropertyByRef("NavMeshObstacle", toilet.NavMeshObstacle);
			writer.WritePrivateField("_debugMode", toilet);
			writer.WritePrivateField("_doorStatus", toilet);
			writer.WritePrivateField("_dirtiness", toilet);
			writer.WritePrivateField("<IsDirty>k__BackingField", toilet);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Toilet toilet = (Toilet)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "<ContextActorData>k__BackingField":
					toilet = (Toilet)reader.SetPrivateField("<ContextActorData>k__BackingField", reader.Read<ContextActorData>(), toilet);
					break;
				case "ToiletSettingsSO":
					toilet.ToiletSettingsSO = reader.Read<ToiletSettingsSO>();
					break;
				case "_openRotation":
					toilet = (Toilet)reader.SetPrivateField("_openRotation", reader.Read<float>(), toilet);
					break;
				case "_openEasing":
					toilet = (Toilet)reader.SetPrivateField("_openEasing", reader.Read<AnimationCurve>(), toilet);
					break;
				case "_closedRotation":
					toilet = (Toilet)reader.SetPrivateField("_closedRotation", reader.Read<float>(), toilet);
					break;
				case "_closeEasing":
					toilet = (Toilet)reader.SetPrivateField("_closeEasing", reader.Read<AnimationCurve>(), toilet);
					break;
				case "_doorRotationDuration":
					toilet = (Toilet)reader.SetPrivateField("_doorRotationDuration", reader.Read<float>(), toilet);
					break;
				case "<LoadTarget>k__BackingField":
					toilet = (Toilet)reader.SetPrivateField("<LoadTarget>k__BackingField", reader.Read<MoveTarget>(), toilet);
					break;
				case "<LoadedTarget>k__BackingField":
					toilet = (Toilet)reader.SetPrivateField("<LoadedTarget>k__BackingField", reader.Read<MoveTarget>(), toilet);
					break;
				case "<UnloadTarget>k__BackingField":
					toilet = (Toilet)reader.SetPrivateField("<UnloadTarget>k__BackingField", reader.Read<MoveTarget>(), toilet);
					break;
				case "sfxToiletList":
					toilet.sfxToiletList = reader.Read<MachineSoundsScriptableObject>();
					break;
				case "_vfxAnchor":
					toilet = (Toilet)reader.SetPrivateField("_vfxAnchor", reader.Read<Transform>(), toilet);
					break;
				case "_vfxPee":
					toilet = (Toilet)reader.SetPrivateField("_vfxPee", reader.Read<JunkObjectParameters[]>(), toilet);
					break;
				case "_doorTransform":
					toilet = (Toilet)reader.SetPrivateField("_doorTransform", reader.Read<Transform[]>(), toilet);
					break;
				case "NavMeshObstacle":
					toilet.NavMeshObstacle = reader.Read<NavMeshObstacle>();
					break;
				case "_debugMode":
					toilet = (Toilet)reader.SetPrivateField("_debugMode", reader.Read<bool>(), toilet);
					break;
				case "_doorStatus":
					toilet = (Toilet)reader.SetPrivateField("_doorStatus", reader.Read<bool>(), toilet);
					break;
				case "_dirtiness":
					toilet = (Toilet)reader.SetPrivateField("_dirtiness", reader.Read<float>(), toilet);
					break;
				case "<IsDirty>k__BackingField":
					toilet = (Toilet)reader.SetPrivateField("<IsDirty>k__BackingField", reader.Read<bool>(), toilet);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
