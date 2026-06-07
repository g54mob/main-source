using System;
using System.Collections.Generic;
using System.Linq;
using ModApi.Ui;
using UnityEngine;

namespace UI.Xml
{
	public class XmlLayoutResourceDatabase : ScriptableObject, IUIResourceDatabase
	{
		public class LoadedXmlEventArgs
		{
			public Action<IXmlLayoutController> OnLayoutRebuilt { get; set; }

			public string Path { get; }

			public string Xml { get; set; }

			public LoadedXmlEventArgs(string path, string xml)
			{
				Path = path;
				Xml = xml;
			}
		}

		private static XmlLayoutResourceDatabase _instance;

		public List<XmlLayoutResourceEntry> entries = new List<XmlLayoutResourceEntry>();

		[SerializeField]
		public List<XmlLayoutCustomResourceDatabase> customResourceDatabases = new List<XmlLayoutCustomResourceDatabase>();

		public static XmlLayoutResourceDatabase instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = Resources.Load<XmlLayoutResourceDatabase>("resourceData/resourceDatabase");
				}
				return _instance;
			}
		}

		public event EventHandler<LoadedXmlEventArgs> LoadedXml;

		public static void UpdateCustomResourceDatabasesDirectly()
		{
		}

		public void ApplyOverrideDatabase(string modName, XmlLayoutCustomResourceDatabase database)
		{
			foreach (XmlLayoutCustomResourceDatabase customResourceDatabase in customResourceDatabases)
			{
				ApplyOverrides(modName, customResourceDatabase.name, customResourceDatabase.entries, database.entries);
			}
			ApplyOverrides(modName, base.name, entries, database.entries);
			if (database.entries.Count > 1)
			{
				Debug.Log("UI Resource Override: Mod '" + modName + "' was not able to apply all overrides because some could not be found. The remaining entries will be added as a custom resource database.");
				RegisterCustomResourceDatabase(database);
			}
		}

		public TextAsset LoadXml(string path)
		{
			return LoadXmlWithLayoutRebuiltCallback(path).TextAsset;
		}

		public (TextAsset TextAsset, Action<IXmlLayoutController> OnLayoutRebuilt) LoadXmlWithLayoutRebuiltCallback(string path)
		{
			TextAsset resource = GetResource<TextAsset>(path);
			EventHandler<LoadedXmlEventArgs> eventHandler = this.LoadedXml;
			if (eventHandler == null)
			{
				return (TextAsset: resource, OnLayoutRebuilt: null);
			}
			LoadedXmlEventArgs e = new LoadedXmlEventArgs(path, resource.text);
			eventHandler(this, e);
			return (TextAsset: (e.Xml == resource.text) ? resource : new TextAsset(e.Xml), OnLayoutRebuilt: e.OnLayoutRebuilt);
		}

		private void ApplyOverrides(string modName, string databaseName, List<XmlLayoutResourceEntry> entries, List<XmlLayoutResourceEntry> overrides)
		{
			for (int num = overrides.Count - 1; num >= 0; num--)
			{
				XmlLayoutResourceEntry overrideEntry = overrides[num];
				XmlLayoutResourceEntry xmlLayoutResourceEntry = entries.FirstOrDefault((XmlLayoutResourceEntry x) => x.path.Equals(overrideEntry.path, StringComparison.Ordinal));
				if (xmlLayoutResourceEntry != null)
				{
					xmlLayoutResourceEntry.resource = overrideEntry.resource;
					overrides.RemoveAt(num);
					Debug.Log("UI Resource Override: Mod '" + modName + "' replaced asset '" + xmlLayoutResourceEntry.path + "' in resource database '" + databaseName + "'.");
				}
			}
		}

		public bool IsResource(UnityEngine.Object o)
		{
			if (!entries.Any((XmlLayoutResourceEntry e) => e.resource == o))
			{
				return customResourceDatabases.Any((XmlLayoutCustomResourceDatabase db) => db.entries.Any((XmlLayoutResourceEntry e) => e.resource == o));
			}
			return true;
		}

		public string GetResourcePath(UnityEngine.Object o)
		{
			XmlLayoutResourceEntry xmlLayoutResourceEntry = entries.FirstOrDefault((XmlLayoutResourceEntry e) => e.resource == o);
			if (xmlLayoutResourceEntry != null)
			{
				return xmlLayoutResourceEntry.path;
			}
			foreach (XmlLayoutCustomResourceDatabase customResourceDatabase in customResourceDatabases)
			{
				xmlLayoutResourceEntry = customResourceDatabase.entries.FirstOrDefault((XmlLayoutResourceEntry e) => e.resource == o);
				if (xmlLayoutResourceEntry != null)
				{
					return xmlLayoutResourceEntry.path;
				}
			}
			return null;
		}

		public T GetResource<T>(string path) where T : UnityEngine.Object
		{
			XmlLayoutResourceEntry xmlLayoutResourceEntry = null;
			Type typeFromHandle = typeof(T);
			if (customResourceDatabases.Count > 0)
			{
				foreach (XmlLayoutCustomResourceDatabase customResourceDatabase in customResourceDatabases)
				{
					xmlLayoutResourceEntry = customResourceDatabase.entries.FirstOrDefault((XmlLayoutResourceEntry e) => e.path.Equals(path, StringComparison.OrdinalIgnoreCase));
					if (xmlLayoutResourceEntry != null)
					{
						break;
					}
				}
			}
			if (xmlLayoutResourceEntry == null)
			{
				xmlLayoutResourceEntry = entries.FirstOrDefault((XmlLayoutResourceEntry e) => e.path == path);
			}
			if (xmlLayoutResourceEntry != null && xmlLayoutResourceEntry.resource != null)
			{
				if (typeFromHandle.IsAssignableFrom(xmlLayoutResourceEntry.resource.GetType()))
				{
					try
					{
						return (T)xmlLayoutResourceEntry.resource;
					}
					catch (Exception ex)
					{
						Debug.LogFormat("[XmlLayout][XmlLayoutResourceDatabase][GetResource()] An exception ocurred while trying to load resource '{0}'. Message follows: {1}", path, ex.Message);
					}
				}
				else
				{
					if (typeFromHandle == typeof(Texture) && xmlLayoutResourceEntry.resource.GetType() == typeof(Sprite))
					{
						Sprite sprite = xmlLayoutResourceEntry.resource as Sprite;
						if (sprite != null)
						{
							return sprite.texture as T;
						}
					}
					if (typeFromHandle == typeof(Transform) && xmlLayoutResourceEntry.resource.GetType() == typeof(GameObject))
					{
						return ((GameObject)xmlLayoutResourceEntry.resource).transform as T;
					}
				}
			}
			return null;
		}

		public void AddResource(string path, UnityEngine.Object resource)
		{
			XmlLayoutResourceEntry xmlLayoutResourceEntry = entries.FirstOrDefault((XmlLayoutResourceEntry e) => e.path == path);
			if (xmlLayoutResourceEntry != null)
			{
				entries.Remove(xmlLayoutResourceEntry);
			}
			entries.Add(new XmlLayoutResourceEntry
			{
				path = path,
				resource = resource
			});
		}

		public void RegisterCustomResourceDatabase(XmlLayoutCustomResourceDatabase customDatabase)
		{
			if (!customResourceDatabases.Contains(customDatabase))
			{
				customResourceDatabases.Add(customDatabase);
			}
		}
	}
}
