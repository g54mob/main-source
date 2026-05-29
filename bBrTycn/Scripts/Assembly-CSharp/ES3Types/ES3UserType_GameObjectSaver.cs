using System;
using CTS;
using ES3Internal;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_saveTransform", "_transformInLocalSpace", "_componentsToSave", "_componentsToInit", "_componentsToPostLoad" })]
	public class ES3UserType_GameObjectSaver : ES3ComponentType
	{
		[Serializable]
		private struct WorldTransformSave
		{
			public Vector3 Position;

			public Vector3 Rotation;

			public WorldTransformSave(Transform transform)
			{
				Position = transform.position;
				Rotation = transform.eulerAngles;
			}

			public void ApplyTo(Transform transform)
			{
				transform.SetPositionAndRotation(Position, Quaternion.Euler(Rotation));
				transform.SetParent(null);
			}
		}

		public static ES3Type Instance;

		public ES3UserType_GameObjectSaver()
			: base(typeof(GameObjectSaver))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			GameObjectSaver gameObjectSaver = (GameObjectSaver)obj;
			if (gameObjectSaver.ShouldSaveTransform)
			{
				if (gameObjectSaver.SaveTransformInLocalSpace)
				{
					writer.WriteProperty("transform", gameObjectSaver.transform, ES3.ReferenceMode.ByRefAndValue);
				}
				else
				{
					writer.WriteProperty("transform", new WorldTransformSave(gameObjectSaver.transform));
				}
			}
			foreach (GameObjectSaver.SaveDictionary.ComponentSave item in gameObjectSaver.ComponentsToSave)
			{
				writer.WriteProperty(item.Data.Key, item.Component, ES3.ReferenceMode.ByRefAndValue);
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			GameObjectSaver obj2 = (GameObjectSaver)obj;
			switch (SaveManager.CurrentSaveState)
			{
			case SaveManager.ESaveState.LoadInit:
				LoadInit(obj2, reader);
				break;
			case SaveManager.ESaveState.LoadPost:
				LoadPost(obj2, reader);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private void LoadInit(GameObjectSaver obj, ES3Reader reader)
		{
			foreach (string property in reader.Properties)
			{
				if (property == "transform")
				{
					if (obj.ShouldSaveTransform)
					{
						if (obj.SaveTransformInLocalSpace)
						{
							reader.ReadInto<Transform>(obj.transform);
						}
						else
						{
							reader.Read<WorldTransformSave>().ApplyTo(obj.transform);
						}
					}
					else
					{
						reader.Skip();
					}
				}
				else if (!TryInit(property))
				{
					reader.Skip();
				}
			}
			bool TryInit(string propertyName)
			{
				foreach (GameObjectSaver.SaveDictionary.ComponentSave item in obj.ComponentsToSave)
				{
					if (item.Data.InitLoad && !(item.Data.Key != propertyName))
					{
						reader.ReadInto<Component>(item.Component, ES3TypeMgr.GetOrCreateES3Type(item.Component.GetType(), throwException: false));
						return true;
					}
				}
				return false;
			}
		}

		private void LoadPost(GameObjectSaver obj, ES3Reader reader)
		{
			foreach (string property in reader.Properties)
			{
				if (property == "transform")
				{
					if (obj.ShouldSaveTransform && obj.SaveTransformInLocalSpace)
					{
						reader.ReadInto<Transform>(obj.transform);
					}
					else
					{
						reader.Skip();
					}
				}
				else if (!TryInit(property))
				{
					reader.Skip();
				}
			}
			bool TryInit(string propertyName)
			{
				foreach (GameObjectSaver.SaveDictionary.ComponentSave item in obj.ComponentsToSave)
				{
					if (!(item.Component == null) && item.Data.PostLoad && !(item.Data.Key != propertyName))
					{
						reader.ReadInto<Component>(item.Component, ES3TypeMgr.GetOrCreateES3Type(item.Component.GetType(), throwException: false));
						return true;
					}
				}
				return false;
			}
		}
	}
}
