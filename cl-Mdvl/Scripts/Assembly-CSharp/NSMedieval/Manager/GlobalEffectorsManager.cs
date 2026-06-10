using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Dictionary;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Village.Map;

namespace NSMedieval.Manager
{
	[FVSerializableKey("GlobalEffectorsManager", "")]
	public class GlobalEffectorsManager : IFVSerializable
	{
		private StringIntDictionary globalActiveHumanoidEffectors = SerializableDictionary<string, int>.CreateNew<StringIntDictionary>();

		[NonSerialized]
		private VillageMap map;

		public Dictionary<string, int> GlobalActiveHumanoidEffectors
		{
			get
			{
				if (globalActiveHumanoidEffectors == null)
				{
					globalActiveHumanoidEffectors = SerializableDictionary<string, int>.CreateNew<StringIntDictionary>();
				}
				return globalActiveHumanoidEffectors.Dictionary;
			}
		}

		public GlobalEffectorsManager(VillageMap map)
		{
			this.map = map;
			MonoSingleton<HumanoidController>.Instance.OnActivateBehaviourEvent += OnActivateBehaviour;
			MonoSingleton<HumanoidController>.Instance.OnDeactivateBehaviourEvent += OnDeactivateBehaviour;
		}

		public void Dispose()
		{
			if (MonoSingleton<HumanoidController>.IsInstantiated())
			{
				MonoSingleton<HumanoidController>.Instance.OnActivateBehaviourEvent -= OnActivateBehaviour;
				MonoSingleton<HumanoidController>.Instance.OnDeactivateBehaviourEvent -= OnDeactivateBehaviour;
			}
		}

		public void InitAfterLoad()
		{
			if (GlobalSaveController.CurrentVillageData.GlobalActiveWorkerEffectors == null)
			{
				return;
			}
			foreach (string item in GlobalSaveController.CurrentVillageData.GlobalActiveWorkerEffectors.ToHashSet())
			{
				RunEffectorOnDomain(item, runEffector: true, GlobalEffectorDomain.Worker);
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\GlobalEffectorsManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("*** Migrating global effector ");
					messageBuilder.AppendFormatted(item);
				}
				Log.Info(messageBuilder);
			}
			GlobalSaveController.CurrentVillageData.GlobalActiveWorkerEffectors.Clear();
		}

		public void RunActiveGlobalEffectorsOn(HumanoidInstance humanoidInstance)
		{
			if (humanoidInstance == null || humanoidInstance.HasDisposed)
			{
				return;
			}
			GlobalEffectorDomain globalEffectorDomain = humanoidInstance.GetGlobalEffectorDomain();
			Dictionary<string, int> dictionary = GlobalActiveHumanoidEffectors;
			foreach (string key in dictionary.Keys)
			{
				StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(key);
				if (!(byID == null) && byID.DontSave)
				{
					GlobalEffectorDomain globalEffectorDomain2 = (GlobalEffectorDomain)dictionary[key];
					if ((globalEffectorDomain & globalEffectorDomain2) != GlobalEffectorDomain.None)
					{
						humanoidInstance.Stats.StartEffector(key);
					}
				}
			}
		}

		public void RunEffectorOnDomain(string effectorName, bool runEffector, GlobalEffectorDomain domain)
		{
			bool isEnabled;
			if (runEffector)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(29, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\GlobalEffectorsManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Starting effector ");
					messageBuilder.AppendFormatted(effectorName);
					messageBuilder.AppendLiteral(" on domain ");
					messageBuilder.AppendFormatted(domain);
				}
				Log.Info(messageBuilder);
				if (GlobalActiveHumanoidEffectors.ContainsKey(effectorName))
				{
					GlobalActiveHumanoidEffectors[effectorName] |= (int)domain;
				}
				else
				{
					GlobalActiveHumanoidEffectors.Add(effectorName, (int)domain);
				}
			}
			else
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(29, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\GlobalEffectorsManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Stopping effector ");
					messageBuilder.AppendFormatted(effectorName);
					messageBuilder.AppendLiteral(" on domain ");
					messageBuilder.AppendFormatted(domain);
				}
				Log.Info(messageBuilder);
				if (GlobalActiveHumanoidEffectors.ContainsKey(effectorName))
				{
					GlobalActiveHumanoidEffectors[effectorName] &= (int)(~domain);
					if (GlobalActiveHumanoidEffectors[effectorName] == 0)
					{
						GlobalActiveHumanoidEffectors.Remove(effectorName);
					}
				}
			}
			List<HumanoidInstance> workers = GlobalSaveController.CurrentVillageData.Workers;
			List<HumanoidInstance> nPCs = GlobalSaveController.CurrentVillageData.NPCs;
			_ = workers.Count;
			int num = (GlobalActiveHumanoidEffectors.ContainsKey(effectorName) ? GlobalActiveHumanoidEffectors[effectorName] : 0);
			foreach (HumanoidInstance item in workers.IterateInReverseDynamic())
			{
				if (!item.HasDisposed)
				{
					if (((uint)num & (uint)item.GetGlobalEffectorDomain()) != 0)
					{
						item.Stats.StartEffector(effectorName);
					}
					else
					{
						item.Stats.EndEffector(effectorName);
					}
				}
			}
			_ = nPCs.Count;
			foreach (HumanoidInstance item2 in nPCs.IterateInReverseDynamic())
			{
				if (!item2.HasDisposed)
				{
					if (((uint)num & (uint)item2.GetGlobalEffectorDomain()) != 0)
					{
						item2.Stats.StartEffector(effectorName);
					}
					else
					{
						item2.Stats.EndEffector(effectorName);
					}
				}
			}
		}

		public bool IsGlobalEffectorRunning(string effectorName, GlobalEffectorDomain effectorDomain)
		{
			if (GlobalSaveController.CurrentVillageData == null)
			{
				return false;
			}
			if (GlobalActiveHumanoidEffectors.TryGetValue(effectorName, out var value))
			{
				return ((uint)value & (uint)effectorDomain) != 0;
			}
			return false;
		}

		private void OnDeactivateBehaviour(HumanoidBehaviour humanoidBehaviour)
		{
			RemoveActiveGlobalEffectorsFrom(humanoidBehaviour.Humanoid);
		}

		private void OnActivateBehaviour(HumanoidBehaviour humanoidBehaviour)
		{
			RunActiveGlobalEffectorsOn(humanoidBehaviour.Humanoid);
		}

		private void RemoveActiveGlobalEffectorsFrom(HumanoidInstance humanoidInstance)
		{
			if (humanoidInstance == null || humanoidInstance.HasDisposed)
			{
				return;
			}
			GlobalEffectorDomain globalEffectorDomain = humanoidInstance.GetGlobalEffectorDomain();
			Dictionary<string, int> dictionary = GlobalActiveHumanoidEffectors;
			foreach (string key in dictionary.Keys)
			{
				StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(key);
				if (!(byID == null) && byID.DontSave)
				{
					GlobalEffectorDomain globalEffectorDomain2 = (GlobalEffectorDomain)dictionary[key];
					if ((globalEffectorDomain & globalEffectorDomain2) != GlobalEffectorDomain.None)
					{
						humanoidInstance.Stats.EndEffector(key);
					}
				}
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("globalActiveHumanoidEffectors", globalActiveHumanoidEffectors);
		}

		public GlobalEffectorsManager(FVDeserializer deserializer)
		{
			globalActiveHumanoidEffectors = deserializer.ReadObject<StringIntDictionary>("globalActiveHumanoidEffectors");
		}
	}
}
