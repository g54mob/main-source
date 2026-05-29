using System;
using UnityEngine;

namespace CTS
{
	public abstract class SaveStaticGameObjectSaverSet<T> : SaveStaticSet<T> where T : Component
	{
		public override bool CanObjectBeSaved(T obj)
		{
			if (obj == null)
			{
				return false;
			}
			GameObjectSaver component;
			return obj.gameObject.TryGetComponent<GameObjectSaver>(out component);
		}

		protected override void SaveSingle(string saveKey, T obj, ES3Settings settings)
		{
			if (!obj.TryGetComponent<GameObjectSaver>(out var component))
			{
				throw new NullReferenceException(typeof(T).Name + " should have a game object saver");
			}
			ES3.Save(saveKey, component, settings);
		}

		protected override void LoadIntoSingle(string saveKey, T obj, ES3Settings settings)
		{
			LoadInto(saveKey, obj.GetComponent<GameObjectSaver>(), settings);
		}
	}
}
