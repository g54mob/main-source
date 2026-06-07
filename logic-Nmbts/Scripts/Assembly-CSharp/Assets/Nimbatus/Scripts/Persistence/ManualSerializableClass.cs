using System;
using System.IO;
using System.Xml.Serialization;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Persistence
{
	public abstract class ManualSerializableClass<TD> where TD : class
	{
		protected bool HasBeenLoaded { get; private set; }

		protected abstract string GetFilename();

		public void Save()
		{
			using (FileStream stream = new FileStream(Path.Combine(SaveManager.ActiveDataFolderPath, GetFilename()), FileMode.Create))
			{
				using (StreamWriter textWriter = new StreamWriter(stream))
				{
					new XmlSerializer(typeof(TD)).Serialize(textWriter, SaveToFile());
				}
			}
		}

		public void Load()
		{
			string path = Path.Combine(SaveManager.ActiveDataFolderPath, GetFilename());
			try
			{
				if (File.Exists(path))
				{
					using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
					{
						TD data = new XmlSerializer(typeof(TD)).Deserialize(stream) as TD;
						LoadFromFile(data);
						HasBeenLoaded = true;
						return;
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected abstract void LoadFromFile(TD data);

		protected abstract TD SaveToFile();
	}
}
