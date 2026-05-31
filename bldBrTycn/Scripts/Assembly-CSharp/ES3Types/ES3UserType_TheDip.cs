using CTS;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_timerUI", "_timerNormalizedValue", "_isInUse", "_alreadyPut", "_audioSource", "_currentPitch" })]
	public class ES3UserType_TheDip : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_TheDip()
			: base(typeof(TheDip))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			TheDip theDip = (TheDip)obj;
			writer.WritePrivateField("_timerUI", theDip);
			writer.WritePrivateField("_timerNormalizedValue", theDip);
			writer.WritePrivateField("_isInUse", theDip);
			writer.WritePrivateField("_alreadyPut", theDip);
			writer.WritePrivateFieldByRef("_audioSource", theDip);
			writer.WriteProperty("Synced", theDip.Syncing.IsSynced);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			TheDip theDip = (TheDip)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_timerUI":
					reader.SetPrivateField("_timerUI", reader.Read<float>(), theDip);
					break;
				case "_timerNormalizedValue":
					reader.SetPrivateField("_timerNormalizedValue", reader.Read<float>(), theDip);
					break;
				case "_isInUse":
					reader.SetPrivateField("_isInUse", reader.Read<bool>(), theDip);
					break;
				case "_alreadyPut":
					reader.SetPrivateField("_alreadyPut", reader.Read<bool>(), theDip);
					break;
				case "_audioSource":
					reader.SetPrivateField("_audioSource", reader.Read<AudioSource>(), theDip);
					break;
				case "Synced":
					theDip.Syncing?.SetSyncing(reader.Read<bool>());
					break;
				default:
					reader.Skip();
					break;
				}
			}
			if (theDip.IsSomebodyIn && SaveManager.CurrentSaveState == SaveManager.ESaveState.LoadPost)
			{
				theDip.MachineUI.DisplayOrHide(_value: true);
				theDip.LaunchAfterSave(needWait: true);
			}
		}
	}
}
