using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kitchen.Serialisation;
using Newtonsoft.Json;
using Platforms;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class PackProgressionSaveSystem
	{
		private SaveStorage<ProgressInfo> SaveStorage;

		protected string Name => "ProgressionSave";

		public SaveSystemType SaveSystemType => SaveSystemType.Partial;

		public PackProgressionSaveSystem(SaveStorage<ProgressInfo> save_storage)
		{
			SaveStorage = save_storage;
		}

		public async Task Initialise()
		{
			await SaveStorage.Initialise((byte[] data, bool ok) => (!ok || !Deserialise(data, out var save)) ? default(ProgressInfo) : GetProgress(save));
		}

		private bool Serialise(PackSave save)
		{
			try
			{
				byte[] data = MessagePackUtility.Serialize(save);
				SaveStorage.Set(data, GetProgress(save));
			}
			catch (Exception message)
			{
				Debug.LogError("Failed to create save");
				Debug.LogError(message);
				return false;
			}
			return true;
		}

		private bool Deserialise(byte[] data, out PackSave save)
		{
			try
			{
				save = MessagePackUtility.Deserialize<PackSave>(data);
			}
			catch (Exception arg)
			{
				try
				{
					JsonSerializerSettings settings = new JsonSerializerSettings
					{
						TypeNameHandling = TypeNameHandling.Auto
					};
					save = JsonConvert.DeserializeObject<PackSave>(Encoding.UTF8.GetString(data), settings);
					Debug.LogWarning("Successfully loaded in JSON format");
				}
				catch (Exception)
				{
					Debug.LogWarning($"Failed to load the progress save ({arg}) in MessagePack format");
					save = default(PackSave);
					return false;
				}
			}
			return true;
		}

		public PackSave ExtractPackSave(EntityManager from_manager)
		{
			PackSave save = new PackSave
			{
				SaveVersion = 1,
				SaveObjects = new List<ISaveObject>()
			};
			AllPersists(from_manager.World, delegate(IPersist p)
			{
				p.BeforeSaving(SaveSystemType);
			});
			using NativeArray<Entity> nativeArray = from_manager.GetAllEntities();
			foreach (Entity ent in nativeArray)
			{
				AllTypeSystems(from_manager.World, delegate(IPackSaver s)
				{
					if (s.SaveEntity(from_manager, ent, out var save_object))
					{
						save.SaveObjects.Add(save_object);
					}
				});
			}
			AllPersists(from_manager.World, delegate(IPersist p)
			{
				p.AfterSaving(SaveSystemType);
			});
			return save;
		}

		public void InsertPackSave(EntityManager to_manager, PackSave save)
		{
			AllPersists(to_manager.World, delegate(IPersist p)
			{
				p.BeforeLoading(SaveSystemType);
			});
			using NativeArray<Entity> nativeArray = to_manager.GetAllEntities();
			foreach (Entity ent in nativeArray)
			{
				AllTypeSystems(to_manager.World, delegate(IPackSaver s)
				{
					s.PrepareEntity(to_manager, ent);
				});
			}
			foreach (ISaveObject obj in save.SaveObjects)
			{
				AllTypeSystems(to_manager.World, delegate(IPackLoader s)
				{
					s.LoadEntity(to_manager, obj);
				});
			}
			AllPersists(to_manager.World, delegate(IPersist p)
			{
				p.AfterLoading(SaveSystemType);
			});
		}

		public bool Save(EntityManager from_manager)
		{
			PackSave save = ExtractPackSave(from_manager);
			return Serialise(save);
		}

		public bool Load(EntityManager to_manager)
		{
			List<SaveInfo<ProgressInfo>> list = SaveStorage.Get();
			for (int i = 0; i < list.Count; i++)
			{
				SaveInfo<ProgressInfo> saveInfo = list[i];
				if (saveInfo.Data != null && Deserialise(saveInfo.Data, out var save))
				{
					InsertPackSave(to_manager, save);
					SaveStorage.LoadedSuccessfully(i);
					return true;
				}
			}
			return false;
		}

		private ProgressInfo GetProgress(PackSave save)
		{
			foreach (ISaveObject saveObject in save.SaveObjects)
			{
				if (saveObject != null && saveObject is IProgress progress)
				{
					return progress.Progress();
				}
			}
			return default(ProgressInfo);
		}

		protected void AllPersists(World world, Action<IPersist> func)
		{
			foreach (ComponentSystemBase system in world.Systems)
			{
				if (system.ShouldRunSystem() && system is IPersist obj)
				{
					func(obj);
				}
			}
		}

		protected void AllTypeSystems<T>(World world, Action<T> func)
		{
			foreach (ComponentSystemBase system in world.Systems)
			{
				if (system.ShouldRunSystem() && system is T obj)
				{
					func(obj);
				}
			}
		}
	}
}
