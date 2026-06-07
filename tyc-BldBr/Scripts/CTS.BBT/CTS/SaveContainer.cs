using CTS.Core;
using UnityEngine;

namespace CTS
{
	public abstract class SaveContainer : CTSBehaviour
	{
		[field: SerializeField]
		public int SaveOrder { get; private set; }

		[field: SerializeField]
		public int LoadInitOrder { get; private set; }

		[field: SerializeField]
		public int LoadPostOrder { get; private set; }

		public abstract void Save(ES3Settings settings);

		public virtual void Clear()
		{
		}

		public abstract void LoadInit(ES3Settings settings);

		public abstract void LoadPost(ES3Settings settings);

		public static void SaveReference(string saveKey, Object reference, ES3Settings settings)
		{
			ES3.Save(saveKey, AssetReferences.GetOrCreateReferenceId(reference), settings);
		}

		public static T LoadReference<T>(string saveKey, ES3Settings settings) where T : Object
		{
			return AssetReferences.GetReference<T>(ES3.Load(saveKey, 0L, settings));
		}

		protected void LoadInto<T>(string key, T obj, ES3Settings settings) where T : class
		{
			if (ES3.KeyExists(key, settings))
			{
				ES3.LoadInto(key, obj, settings);
			}
		}
	}
}
