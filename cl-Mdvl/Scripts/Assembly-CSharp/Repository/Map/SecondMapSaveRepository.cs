using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using JetBrains.Annotations;
using NSEipix;
using NSEipix.ObjectMapper;
using NSEipix.Repository;
using NSMedieval.Model.SecondMap;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;

namespace Repository.Map
{
	public class SecondMapSaveRepository : DynamicJsonRepository<SecondMapSaveRepository, SecondMapSaveInfo>
	{
		public override void Reload()
		{
			Deserialize();
		}

		protected override string JsonFile()
		{
			return "SecondMap/SavesRepository.json";
		}

		public new void Add(SecondMapSaveInfo info)
		{
			base.Add(info);
		}

		public new void Remove(SecondMapSaveInfo info)
		{
			base.Remove(info);
		}

		public void Replace(SecondMapSaveInfo info)
		{
			Remove(info);
			Add(info);
		}

		public SecondMapSaveInfo GetRandomSave(SecondMapType type, string biomeType)
		{
			using PooledList<SecondMapSaveInfo> pooledList = ListPool<SecondMapSaveInfo>.GetJanitor();
			foreach (SecondMapSaveInfo allItem in GetAllItems())
			{
				if (allItem.Type == type && !(allItem.BiomeType != biomeType))
				{
					pooledList.Add(allItem);
				}
			}
			if (pooledList.Count == 0 && biomeType != "map_type_valley")
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(96, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Map\\SecondMapSaveRepository.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Found no save matches for type '");
					messageBuilder.AppendFormatted(type);
					messageBuilder.AppendLiteral("' and biome '");
					messageBuilder.AppendFormatted(biomeType);
					messageBuilder.AppendLiteral("', trying now with fallback biome 'map_type_valley'");
				}
				Log.Info(messageBuilder);
				SecondMapSaveInfo randomSave = GetRandomSave(type, "map_type_valley");
				if (randomSave == null)
				{
					throw new Exception($"Failed to find save of type '{type}' for biome '{biomeType}' (also found no matches for Valley biome, which is the fallback)");
				}
				return randomSave;
			}
			return (pooledList.Count == 0) ? null : pooledList.PickRandom();
		}

		public IEnumerable<SecondMapSaveInfo> GetSaves(SecondMapType type)
		{
			foreach (SecondMapSaveInfo allItem in GetAllItems())
			{
				if (allItem.Type == type)
				{
					yield return allItem;
				}
			}
		}

		[MustDisposeResource]
		public PooledList<string> GetSaveIdsPooled(SecondMapType type)
		{
			PooledList<string> janitor = ListPool<string>.GetJanitor();
			foreach (SecondMapSaveInfo allItem in GetAllItems())
			{
				if (allItem.Type == type)
				{
					janitor.Add(allItem.Id);
				}
			}
			return janitor;
		}

		public new void Serialize()
		{
			base.Serialize();
		}

		protected override ISerializer<RepositoryDto<SecondMapSaveInfo>> Serializer()
		{
			return new JsonSerializer<RepositoryDto<SecondMapSaveInfo>>.Builder(JsonFilePathRegistry).BuildMultiple();
		}
	}
}
