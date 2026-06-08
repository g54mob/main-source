using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Platforms;
using Unity.Entities;
using Unity.Entities.Serialization;
using UnityEngine;

namespace Kitchen
{
	public class FullWorldSaveSystem
	{
		private World TempWorld = new World("FullWorldSaveSystem temp");

		private SaveStorage<Nothing>[] SaveData;

		private PackProgressionSaveSystem Progress;

		public SaveSystemType SaveSystemType => SaveSystemType.FullWorld;

		public FullWorldSaveSystem(SaveStorage<Nothing>[] save_data, PackProgressionSaveSystem progress)
		{
			SaveData = save_data;
			Progress = progress;
		}

		public async Task Initialise()
		{
			Task[] array = new Task[SaveData.Length];
			for (int i = 0; i < SaveData.Length; i++)
			{
				array[i] = SaveData[i].Initialise();
			}
			await Task.WhenAll(array);
		}

		public IEnumerable<(World, SaveState)> All()
		{
			SaveStorage<Nothing>[] saveData = SaveData;
			foreach (SaveStorage<Nothing> save_storage in saveData)
			{
				World world = new World("FullWorldSaveSystem temp all");
				try
				{
					SaveState item = LoadEntities(world.EntityManager, save_storage);
					yield return (world, item);
				}
				finally
				{
					world.Dispose();
				}
			}
		}

		private bool TryGetSave(int slot, out SaveStorage<Nothing> ret)
		{
			int num = slot - 1;
			if (num < 0 || num >= SaveData.Length)
			{
				ret = null;
				return false;
			}
			ret = SaveData[num];
			return true;
		}

		private SaveState LoadEntities(EntityManager to_manager, SaveStorage<Nothing> save_storage)
		{
			SaveState result = SaveState.Empty;
			List<SaveInfo<Nothing>> list = save_storage.Get();
			for (int i = 0; i < list.Count; i++)
			{
				SaveInfo<Nothing> saveInfo = list[i];
				if (Deserialise(to_manager, saveInfo.Data))
				{
					save_storage.LoadedSuccessfully(i);
					result = SaveState.Loaded;
					break;
				}
				result = SaveState.Failed;
			}
			return result;
		}

		public void Clear(int slot)
		{
			if (TryGetSave(slot, out var ret))
			{
				ret.Clear();
			}
		}

		public bool Save(EntityManager from_manager, int slot)
		{
			AllPersists(from_manager.World, delegate(IPersist p)
			{
				p.BeforeSaving(SaveSystemType);
			});
			DestroyPersistEntities(TempWorld.EntityManager);
			TempWorld.EntityManager.MoveEntitiesFrom(from_manager, GetPersistEntities(from_manager));
			bool result = Serialise(slot);
			from_manager.MoveEntitiesFrom(TempWorld.EntityManager);
			AllPersists(from_manager.World, delegate(IPersist p)
			{
				p.AfterSaving(SaveSystemType);
			});
			return result;
		}

		public bool Load(EntityManager to_manager, int slot)
		{
			if (!TryGetSave(slot, out var ret))
			{
				return false;
			}
			foreach (ComponentSystemBase system in to_manager.World.Systems)
			{
				if (system is EntityCommandBufferSystem)
				{
					system.Update();
				}
			}
			PackSave save = Progress.ExtractPackSave(to_manager);
			bool num = LoadEntities(TempWorld.EntityManager, ret) == SaveState.Loaded;
			if (num)
			{
				AllPersists(to_manager.World, delegate(IPersist p)
				{
					p.BeforeLoading(SaveSystemType);
				});
				DestroyPersistEntities(to_manager);
				to_manager.MoveEntitiesFrom(TempWorld.EntityManager);
				AllPersists(to_manager.World, delegate(IPersist p)
				{
					p.AfterLoading(SaveSystemType);
				});
				Progress.InsertPackSave(to_manager, save);
			}
			return num;
		}

		private bool Serialise(int slot)
		{
			try
			{
				if (!TryGetSave(slot, out var ret))
				{
					return false;
				}
				using MemoryBinaryWriter memoryBinaryWriter = new MemoryBinaryWriter();
				SerializeUtility.SerializeWorld(TempWorld.EntityManager, memoryBinaryWriter, out var referencedObjects);
				byte[] array = new byte[memoryBinaryWriter.content.Length];
				for (int i = 0; i < memoryBinaryWriter.content.Length; i++)
				{
					array[i] = memoryBinaryWriter.content[i];
				}
				if (referencedObjects.Length != 0)
				{
					Debug.LogWarning("Found shared components when saving!");
				}
				ret.Set(array);
			}
			catch (Exception message)
			{
				Debug.LogWarning(message);
				return false;
			}
			return true;
		}

		private bool Deserialise(EntityManager to_manager, byte[] data)
		{
			DestroyPersistEntities(to_manager);
			ExclusiveEntityTransaction manager = to_manager.BeginExclusiveEntityTransaction();
			bool flag = true;
			try
			{
				using ArrayBinaryReader reader = new ArrayBinaryReader(data);
				SerializeUtility.DeserializeWorld(manager, reader);
			}
			catch (Exception arg)
			{
				Debug.LogWarning($"Failed to load the save ({arg})");
				flag = false;
			}
			finally
			{
				to_manager.EndExclusiveEntityTransaction();
			}
			if (!flag)
			{
				DestroyPersistEntities(to_manager);
			}
			return flag;
		}

		private void AllPersists(World world, Action<IPersist> func)
		{
			foreach (ComponentSystemBase system in world.Systems)
			{
				if (system is IPersist obj)
				{
					func(obj);
				}
			}
		}

		private EntityQuery GetPersistEntities(EntityManager em)
		{
			return em.CreateEntityQuery(new EntityQueryDesc
			{
				None = new ComponentType[1] { ComponentType.ReadWrite<CDoNotPersist>() }
			});
		}

		private void DestroyPersistEntities(EntityManager em)
		{
			em.DestroyEntity(GetPersistEntities(em));
		}
	}
}
