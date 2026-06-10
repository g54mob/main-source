using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.Village.Map;

namespace NSMedieval.CommanderAI
{
	[FVSerializableKey("CommanderAgentBase", "")]
	public abstract class CommanderAgentBase : IFVSerializable, IDisposable
	{
		protected ActiveRaidInfo linkedRaid;

		public uint Id { get; private set; }

		public CommanderAIGroup UnitGroup { get; private set; }

		public VillageMap Map { get; private set; }

		public CommanderAIUnit FirstUnit => UnitGroup?.Units?.First();

		public ICollection<CommanderAIUnit> Units => UnitGroup?.Units;

		public List<BaseBuildingInstance> DeployedSiegeWeapons => UnitGroup?.DeployedSiegeWeapons;

		public bool HasArtilleryAmmo
		{
			get
			{
				if (UnitGroup == null)
				{
					return false;
				}
				if (UnitGroup.SiegeWeaponInventory.Count > 0)
				{
					return true;
				}
				foreach (BaseBuildingInstance deployedSiegeWeapon in UnitGroup.DeployedSiegeWeapons)
				{
					if (deployedSiegeWeapon.IsUnderConstruction)
					{
						return true;
					}
					SiegeWeaponComponentInstance componentInstance = deployedSiegeWeapon.GetComponentInstance<SiegeWeaponComponentInstance>();
					if (componentInstance != null && (componentInstance.HasAmmunition() || componentInstance.HasAmmoAvailableNearByFloodFill()))
					{
						return true;
					}
				}
				return false;
			}
		}

		protected static WorldDate DateTime
		{
			get
			{
				if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
				{
					return null;
				}
				return GlobalSaveController.CurrentVillageData.DateAndTime;
			}
		}

		public Dictionary<string, int> SiegeWeaponInventory => UnitGroup?.SiegeWeaponInventory;

		protected CommanderAgentBase(uint id, VillageMap map)
		{
			Id = id;
			Map = map;
			UnitGroup = new CommanderAIGroup();
			MonoSingleton<SceneController>.Instance.Tick += Tick;
		}

		public virtual void InitAfterLoad()
		{
			UnitGroup.InitAfterLoad();
			MonoSingleton<SceneController>.Instance.Tick += Tick;
		}

		public void LinkWithRaid(ActiveRaidInfo activeRaidInfo)
		{
			linkedRaid = activeRaidInfo;
		}

		public void TransferTo(CommanderAgentBase newCommander)
		{
			newCommander.Id = Id;
			newCommander.UnitGroup = UnitGroup;
			newCommander.Map = Map;
			UnitGroup = null;
			Map = null;
		}

		public virtual void Dispose()
		{
			Map = null;
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= Tick;
			}
		}

		public int GetSiegeWeaponInventoryCount(string blueprintId)
		{
			if (UnitGroup == null)
			{
				return -1;
			}
			return UnitGroup.GetSiegeWeaponInventoryCount(blueprintId);
		}

		protected virtual void OnTick()
		{
		}

		private void Tick(float deltaTime)
		{
			if (deltaTime <= 0f || Units.Count == 0 || LoadingController.IsSceneTransition)
			{
				return;
			}
			using (ProfilerSampleJanitor.Begin("CommanderAgentBase.Tick"))
			{
				bool flag = false;
				foreach (CommanderAIUnit unit in Units)
				{
					if (!unit.Humanoid.IsLeaving)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return;
				}
				if (linkedRaid != null)
				{
					if (!linkedRaid.RaidEngageDelay.HasEnded)
					{
						return;
					}
					if (!linkedRaid.HasEngaged)
					{
						MonoSingleton<RaidController>.Instance.OnRaidAttackEngage(linkedRaid);
					}
				}
				OnTick();
			}
		}

		public virtual void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", Id);
			serializer.Write("unitGroup", UnitGroup);
			serializer.Write("map", Map);
			serializer.Write("linkedRaid", linkedRaid);
		}

		public CommanderAgentBase(FVDeserializer deserializer)
		{
			Id = deserializer.ReadUInt("id");
			UnitGroup = deserializer.ReadObject<CommanderAIGroup>("unitGroup");
			Map = deserializer.ReadObject<VillageMap>("map");
			linkedRaid = deserializer.ReadObject<ActiveRaidInfo>("linkedRaid");
		}
	}
}
