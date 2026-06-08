using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Kitchen.Serialisation;
using MessagePack;
using Newtonsoft.Json;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class ProfileSaveSystem
	{
		private readonly SaveStorage<Nothing> SaveStorage;

		private JsonSerializerSettings JSONSettings = new JsonSerializerSettings
		{
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore
		};

		public SaveSystemType SaveSystemType => SaveSystemType.Partial;

		public ProfileSaveSystem(SaveStorage<Nothing> save_storage)
		{
			SaveStorage = save_storage;
		}

		public async Task Initialise()
		{
			await SaveStorage.Initialise();
		}

		public bool Save<T>(T value)
		{
			try
			{
				byte[] data = MessagePackUtility.Serialize(value);
				SaveStorage.Set(data);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public bool Load<T>(out T ret)
		{
			ret = default(T);
			List<SaveInfo<Nothing>> list = SaveStorage.Get();
			for (int i = 0; i < list.Count; i++)
			{
				SaveInfo<Nothing> saveInfo = list[i];
				if (saveInfo.Data == null)
				{
					continue;
				}
				try
				{
					ret = MessagePackUtility.Deserialize<T>(saveInfo.Data);
					SaveStorage.LoadedSuccessfully(i);
					return true;
				}
				catch (EndOfStreamException)
				{
					Debug.LogWarning("Tried to read an empty file as a profile save");
				}
				catch (ArgumentException arg)
				{
					Debug.LogError($"Failed to load the save ({saveInfo.Name}): {arg}");
				}
				catch (Exception ex2) when (ex2 is MessagePackSerializationException || ex2 is InvalidCastException)
				{
					Debug.LogWarning("Failed to load the save (" + saveInfo.Name + ") in MessagePack format - trying again in JSON format...");
					try
					{
						ret = JsonConvert.DeserializeObject<T>(saveInfo.Text(), JSONSettings);
						Debug.LogWarning("Loaded the save from JSON format. It will be converted on save...");
						return true;
					}
					catch (Exception arg2)
					{
						Debug.LogError($"Failed to load the save ({saveInfo.Name}): {arg2}");
					}
				}
			}
			return false;
		}
	}
}
