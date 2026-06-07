using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Ionic.Zip;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Persistence
{
	public abstract class GlobalSerializableMonobehaviour<T, D> : SerializedMonoBehaviour where T : GlobalSerializableMonobehaviour<T, D> where D : class
	{
		public bool PasswordProtected;

		public string Password;

		public static T Instance { get; set; }

		internal abstract string Filename { get; }

		protected bool HasBeenLoaded { get; private set; }

		protected virtual void Awake()
		{
			if (Instance == null)
			{
				Instance = GetComponent<T>();
				UnityEngine.Object.DontDestroyOnLoad(Instance);
			}
			else
			{
				UnityEngine.Object.Destroy(this);
			}
			HasBeenLoaded = false;
			PreLoad();
			Load();
			PostLoad();
		}

		public void OnApplicationQuit()
		{
			Save();
		}

		private void Save()
		{
			if (Instance == null || string.IsNullOrEmpty(Instance.Filename))
			{
				return;
			}
			try
			{
				string text = Path.Combine(SaveManager.GlobalFilePath, Instance.Filename);
				using (FileStream stream = new FileStream(text, FileMode.Create))
				{
					using (StreamWriter textWriter = new StreamWriter(stream))
					{
						new XmlSerializer(typeof(D)).Serialize(textWriter, Instance.SaveToFile());
					}
				}
				if (!PasswordProtected || !File.Exists(text))
				{
					return;
				}
				if (File.Exists(text + "zip"))
				{
					File.Delete(text + "zip");
				}
				using (ZipFile zipFile = new ZipFile(text + "zip"))
				{
					zipFile.Password = Password;
					if (zipFile.FirstOrDefault((ZipEntry e) => e.FileName == Filename) != null)
					{
						zipFile.UpdateFile(text, "");
					}
					else
					{
						zipFile.AddFile(text, "");
					}
					zipFile.Save();
					File.Delete(text);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void Load()
		{
			if (Instance == null || string.IsNullOrEmpty(Filename))
			{
				return;
			}
			try
			{
				if (PasswordProtected)
				{
					string text = Path.Combine(SaveManager.GlobalFilePath, Instance.Filename + "zip");
					if (!File.Exists(text))
					{
						return;
					}
					using (ZipFile zipFile = ZipFile.Read(text))
					{
						zipFile.Password = Password;
						ZipEntry zipEntry = zipFile.FirstOrDefault((ZipEntry e) => e.FileName == Filename);
						if (zipEntry != null)
						{
							using (MemoryStream memoryStream = new MemoryStream())
							{
								zipEntry.Extract(memoryStream);
								memoryStream.Position = 0L;
								D data = new XmlSerializer(typeof(D)).Deserialize(memoryStream) as D;
								Instance.LoadFromFile(data);
								Instance.HasBeenLoaded = true;
								return;
							}
						}
						return;
					}
				}
				string path = Path.Combine(SaveManager.GlobalFilePath, Instance.Filename);
				if (File.Exists(path))
				{
					using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
					{
						D data2 = new XmlSerializer(typeof(D)).Deserialize(stream) as D;
						Instance.LoadFromFile(data2);
						Instance.HasBeenLoaded = true;
						return;
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected virtual void PreLoad()
		{
		}

		protected virtual void PostLoad()
		{
		}

		protected abstract void LoadFromFile(D data);

		protected abstract D SaveToFile();
	}
}
