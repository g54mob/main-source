using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using UnityEngine;

[Serializable]
public class BuildingInst
{
	[CompilerGenerated]
	private sealed class _003CGetBuildingsInRange_003Ed__43 : IEnumerable<BuildingInst>, IEnumerable, IEnumerator<BuildingInst>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private BuildingInst _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private BuildingType tgt;

		public BuildingType _003C_003E3__tgt;

		public BuildingInst _003C_003E4__this;

		private List<BuildingInst> _003CtgtList_003E5__2;

		private int _003Ci_003E5__3;

		BuildingInst IEnumerator<BuildingInst>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CGetBuildingsInRange_003Ed__43(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}

		[DebuggerHidden]
		IEnumerator<BuildingInst> IEnumerable<BuildingInst>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	public int Id;

	public BuildingType Type;

	public float X;

	public float Y;

	public int Rotation;

	public int UpgradePts;

	public int UpgradeLvl;

	private int _upgradeTgt;

	public Cost ResourcesSpent;

	[NonSerialized]
	public int NumBouncesThisHarvest;

	public BuildingState CurState;

	public Cost HeldResources;

	public int WorkerChar;

	public Vector2 LauncherAimDir;

	public List<int> LauncherHitBuildings;

	public int CurTaskSecs;

	[NonSerialized]
	public BuildingObj Obj;

	public BuildingInst(BuildingType t, float x, float y)
	{
	}

	public BuildingInst(string str)
	{
	}

	public BuildingInst(BuildingInst toCopy)
	{
	}

	public BuildingInfo GetInfo()
	{
		return null;
	}

	public float GetUpgradePct()
	{
		return 0f;
	}

	public int GetUpgradeTgt()
	{
		return 0;
	}

	public bool CanBeUpgraded()
	{
		return false;
	}

	public Cost GetUpgradeCost()
	{
		return null;
	}

	public void AddUpgradePts(int pts)
	{
	}

	public int GetNumResources()
	{
		return 0;
	}

	public int GetResourceCapacity()
	{
		return 0;
	}

	public int GetRemainingCapacityForResource(ResourceType rt)
	{
		return 0;
	}

	public void ResetResourcePts()
	{
	}

	public bool CanHarvest()
	{
		return false;
	}

	public int Harvest(int dmg)
	{
		return 0;
	}

	public int Harvest(CharMetaInst worker, bool isDirect)
	{
		return 0;
	}

	public int Harvest(BuildingInst harvester)
	{
		return 0;
	}

	public Cost GetRefundAmt()
	{
		return null;
	}

	public bool HasWorker()
	{
		return false;
	}

	public CharMetaInst GetWorker()
	{
		return null;
	}

	public void RemoveWorker()
	{
	}

	public bool HasActiveTask()
	{
		return false;
	}

	public float GetTaskProgress()
	{
		return 0f;
	}

	public int GetTaskTgtSecs()
	{
		return 0;
	}

	public int GetHarvestStrength()
	{
		return 0;
	}

	private float GetSpeedImprovementAmtInRange()
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(_003CGetBuildingsInRange_003Ed__43))]
	public IEnumerable<BuildingInst> GetBuildingsInRange(BuildingType tgt)
	{
		return null;
	}

	public int GetNumBuildingsInRange(BuildingType tgt, float range)
	{
		return 0;
	}

	public float GetRange()
	{
		return 0f;
	}

	public bool IsInRange(BuildingInst b)
	{
		return false;
	}

	public bool IsInRange(BuildingInst b, float range)
	{
		return false;
	}

	public bool IsValidIdleHarvesterTgt(BuildingInst b)
	{
		return false;
	}

	public bool AddTaskSecs(int secs)
	{
		return false;
	}

	public void TryAddResourcesToStorage(ResourceType rt, int amt)
	{
	}

	public void AddResources(Cost c)
	{
	}

	public void AddResources(ResourceType rt, int amt)
	{
	}

	public void ApplyDesc(Localize loc, LocalizationParamsManager prams, bool isBuild)
	{
	}

	public void ApplyHousingUpgradeDesc(Localize loc, LocalizationParamsManager prams)
	{
	}

	public int GetBabyWorkerBounceLimit()
	{
		return 0;
	}

	public override string ToString()
	{
		return null;
	}

	public void AddHitBuilding(BuildingObj b)
	{
	}

	public int GetNumBuildingHits(BuildingObj b)
	{
		return 0;
	}

	public void GetHitByWorker(BallObj b)
	{
	}

	public Vector3Int GetBotLeftGridPos()
	{
		return default(Vector3Int);
	}

	public void SetState(BuildingState bs, bool force)
	{
	}

	public int GetStatBonusAmt()
	{
		return 0;
	}

	public bool IsUpgradedHousingInRange(BuildingType bt)
	{
		return false;
	}

	public Vector2Int GetTileSize()
	{
		return default(Vector2Int);
	}

	public void PlayPickupSFX()
	{
	}

	public void PlayPickupVFX()
	{
	}

	public void PlayPlacementSFX()
	{
	}

	public void PlayPlacementVFX()
	{
	}

	public void PlayDismantleSFX()
	{
	}

	public void PlayHoverSFX()
	{
	}

	public void PlayHitSFX()
	{
	}

	public string GetExportStr()
	{
		return null;
	}
}
