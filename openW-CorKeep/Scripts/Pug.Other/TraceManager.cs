using System;
using Sentry;
using Unity.Profiling;
using UnityEngine.Scripting;

public class TraceManager : ManagerBase
{
	[Preserve]
	private class World
	{
		public int WorldSlot => Manager.saves.GetWorldId();

		public uint Seed => Manager.saves.GetWorldInfo()?.seed ?? 0;

		public string CreationDate => Manager.saves.GetWorldInfo()?.creationDate.ToString();

		public WorldMode Mode => Manager.saves.GetWorldInfo()?.mode ?? WorldMode.Undefined;
	}

	[Preserve]
	private class Character
	{
		public bool Hardcore
		{
			get
			{
				if (Manager.saves.GetCharacterId() >= 0)
				{
					return Manager.saves.GetCharacterType() == CharacterType.Hardcore;
				}
				return false;
			}
		}

		public int ServerCount
		{
			get
			{
				if (Manager.saves.GetCharacterId() < 0)
				{
					return -1;
				}
				return Manager.saves.GetServerConnectCount();
			}
		}
	}

	[Preserve]
	private class Powers
	{
		public bool HasUnlockedSouls
		{
			get
			{
				if (Manager.saves.GetCharacterId() >= 0)
				{
					return Manager.saves.HasUnlockedSouls();
				}
				return false;
			}
		}

		public bool SoulOfAzeos
		{
			get
			{
				if (Manager.saves.GetCharacterId() >= 0 && Manager.saves.HasCollectedSoul(SoulID.SoulOfAzeos))
				{
					return Manager.saves.SoulPowerIsEnabled(SoulID.SoulOfAzeos);
				}
				return false;
			}
		}

		public bool SoulOfOmoroth
		{
			get
			{
				if (Manager.saves.GetCharacterId() >= 0 && Manager.saves.HasCollectedSoul(SoulID.SoulOfOmoroth))
				{
					return Manager.saves.SoulPowerIsEnabled(SoulID.SoulOfOmoroth);
				}
				return false;
			}
		}

		public bool SoulOfScarab
		{
			get
			{
				if (Manager.saves.GetCharacterId() >= 0 && Manager.saves.HasCollectedSoul(SoulID.SoulOfScarab))
				{
					return Manager.saves.SoulPowerIsEnabled(SoulID.SoulOfScarab);
				}
				return false;
			}
		}

		public bool SoulOfNatureHydra
		{
			get
			{
				if (Manager.saves.GetCharacterId() >= 0 && Manager.saves.HasCollectedSoul(SoulID.SoulOfNatureHydra))
				{
					return Manager.saves.SoulPowerIsEnabled(SoulID.SoulOfNatureHydra);
				}
				return false;
			}
		}

		public bool SoulOfSeaHydra
		{
			get
			{
				if (Manager.saves.GetCharacterId() >= 0 && Manager.saves.HasCollectedSoul(SoulID.SoulOfSeaHydra))
				{
					return Manager.saves.SoulPowerIsEnabled(SoulID.SoulOfSeaHydra);
				}
				return false;
			}
		}

		public bool SoulOfDesertHydra
		{
			get
			{
				if (Manager.saves.GetCharacterId() >= 0 && Manager.saves.HasCollectedSoul(SoulID.SoulOfDesertHydra))
				{
					return Manager.saves.SoulPowerIsEnabled(SoulID.SoulOfDesertHydra);
				}
				return false;
			}
		}
	}

	[Preserve]
	private class Skills
	{
		public int Mining
		{
			get
			{
				if (Manager.saves.GetCharacterId() < 0)
				{
					return -1;
				}
				return Manager.saves.GetSkillValue(SkillID.Mining);
			}
		}

		public int Running
		{
			get
			{
				if (Manager.saves.GetCharacterId() < 0)
				{
					return -1;
				}
				return Manager.saves.GetSkillValue(SkillID.Running);
			}
		}

		public int Melee
		{
			get
			{
				if (Manager.saves.GetCharacterId() < 0)
				{
					return -1;
				}
				return Manager.saves.GetSkillValue(SkillID.Melee);
			}
		}

		public int Vitality
		{
			get
			{
				if (Manager.saves.GetCharacterId() < 0)
				{
					return -1;
				}
				return Manager.saves.GetSkillValue(SkillID.Vitality);
			}
		}

		public int Crafting
		{
			get
			{
				if (Manager.saves.GetCharacterId() < 0)
				{
					return -1;
				}
				return Manager.saves.GetSkillValue(SkillID.Crafting);
			}
		}

		public int Range
		{
			get
			{
				if (Manager.saves.GetCharacterId() < 0)
				{
					return -1;
				}
				return Manager.saves.GetSkillValue(SkillID.Range);
			}
		}

		public int Gardening
		{
			get
			{
				if (Manager.saves.GetCharacterId() < 0)
				{
					return -1;
				}
				return Manager.saves.GetSkillValue(SkillID.Gardening);
			}
		}

		public int Fishing
		{
			get
			{
				if (Manager.saves.GetCharacterId() < 0)
				{
					return -1;
				}
				return Manager.saves.GetSkillValue(SkillID.Fishing);
			}
		}

		public int Cooking
		{
			get
			{
				if (Manager.saves.GetCharacterId() < 0)
				{
					return -1;
				}
				return Manager.saves.GetSkillValue(SkillID.Cooking);
			}
		}

		public int Magic
		{
			get
			{
				if (Manager.saves.GetCharacterId() < 0)
				{
					return -1;
				}
				return Manager.saves.GetSkillValue(SkillID.Magic);
			}
		}

		public int Minion
		{
			get
			{
				if (Manager.saves.GetCharacterId() < 0)
				{
					return -1;
				}
				return Manager.saves.GetSkillValue(SkillID.Summoning);
			}
		}
	}

	[Preserve]
	private class Network
	{
		public bool HasNetwork => Manager.networking?.hasNetwork ?? false;

		public bool Hosting => Manager.ecs?.ServerWorld != null;

		public int Ping => (int)(Manager.networking?.rttToServer ?? 0f);

		public bool IsDedicatedServer => false;

		public bool ConnectedToDedicatedServer => Manager.networking?.currentSessionIsDedicatedServer ?? false;
	}

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("TraceManager.Init");

	private bool _isRunningFrameTransaction;

	private bool _hasStartedFixedUpdateOperation;

	private IDisposable _currentScope;

	public bool IsRunningFrameTransaction
	{
		get
		{
			return _isRunningFrameTransaction;
		}
		set
		{
			_isRunningFrameTransaction = value;
			_hasStartedFixedUpdateOperation = false;
		}
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			return true;
		}
	}

	public override void Deinit()
	{
		SentrySdk.FlushAsync(TimeSpan.FromSeconds(5.0)).Wait();
		base.Deinit();
	}

	public void GameStart()
	{
		_currentScope = SentrySdk.PushScope();
		SentrySdk.ConfigureScope(delegate(Scope scope)
		{
			scope.Contexts["world"] = new World();
			scope.Contexts["networkinfo"] = new Network();
			scope.Contexts["character"] = new Character();
			scope.Contexts["powers"] = new Powers();
			scope.Contexts["skills"] = new Skills();
		});
		SentrySdk.StartSession();
	}

	public void GameEnd()
	{
		SentrySdk.EndSession();
		if (_currentScope != null)
		{
			_currentScope.Dispose();
			_currentScope = null;
		}
	}

	public void GamePause()
	{
		SentrySdk.PauseSession();
	}

	public void GameResume()
	{
		SentrySdk.ResumeSession();
	}
}
