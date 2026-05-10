using CTS.Core.Pooling;

namespace CTS
{
	public class SaveJunks : SaveStaticGameObjectSaverSet<JunkObject>
	{
		public override bool CanObjectBeSaved(JunkObject obj)
		{
			if (obj.IsDiscarded)
			{
				return false;
			}
			return base.CanObjectBeSaved(obj);
		}

		protected override void SaveSingle(string saveKey, JunkObject obj, ES3Settings settings)
		{
			SaveContainer.SaveReference(saveKey + "prefab", obj.Parameters, settings);
			base.SaveSingle(saveKey, obj, settings);
		}

		protected override JunkObject InstantiateSingle(string saveKey, ES3Settings settings)
		{
			JunkObjectParameters junkObjectParameters = SaveContainer.LoadReference<JunkObjectParameters>(saveKey + "prefab", settings);
			if (junkObjectParameters == null)
			{
				return null;
			}
			return Pooler.Pull(junkObjectParameters.Prefab);
		}

		protected override void LoadIntoSingle(string saveKey, JunkObject obj, ES3Settings settings)
		{
			base.LoadIntoSingle(saveKey, obj, settings);
			obj.gameObject.SetActive(value: true);
		}
	}
}
