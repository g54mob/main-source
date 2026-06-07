using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PickupMgr : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_PickUpAllPickupsAboveY_003Ed__38 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float y;

		private int _003CnumPerFrame_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_PickUpAllPickupsAboveY_003Ed__38(int _003C_003E1__state)
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
	}

	[CompilerGenerated]
	private sealed class _003C_SpawnGem_003Ed__36 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Vector3 pos;

		public float width;

		public float height;

		public PickupMgr _003C_003E4__this;

		public int xpVal;

		private Vector3 _003CdropOffset_003E5__2;

		private PickupObj _003Cgem_003E5__3;

		private float _003CstartTime_003E5__4;

		private float _003CgemHeight_003E5__5;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_SpawnGem_003Ed__36(int _003C_003E1__state)
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
	}

	public static PickupMgr I;

	public Dictionary<Collider2D, PickupObj> PickupColDict;

	private WeightedEnumList<PickupType> _droppablePickups;

	public const float kBasePickupProb = 1f / 160f;

	public int CurPickupStreak;

	public float LastPickupTime;

	private const float kSpawnLen = 0.35f;

	public const float kPickupZ = -0.25f;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnSceneAboutToChange()
	{
	}

	public float GetMinPickupY()
	{
		return 0f;
	}

	public float GetMaxPickupY()
	{
		return 0f;
	}

	public float GetMinPickupX()
	{
		return 0f;
	}

	public float GetMaxPickupX()
	{
		return 0f;
	}

	public int GetClearBonus()
	{
		return 0;
	}

	public PickupType GetPickupToDrop(System.Random rnd)
	{
		return default(PickupType);
	}

	public PickupObj DropPickup(Vector3 dropPos, PickupType pType)
	{
		return null;
	}

	public PickupObj TryDropBossBlueprint(Vector3 dropPos)
	{
		return null;
	}

	public PickupObj TryDropEgg(Vector3 dropPos)
	{
		return null;
	}

	public PickupObj TryDropFuserBlueprint(Vector3 dropPos)
	{
		return null;
	}

	public PickupObj DropBlueprintIfNecessary(Vector3 dropPos, BuildingType bt)
	{
		return null;
	}

	public PickupObj DropBlueprint(Vector3 dropPos, BuildingType bt)
	{
		return null;
	}

	public PickupObj DropXP(Vector3 dropPos, int xpAmt)
	{
		return null;
	}

	public int DropGold(int nGold, GridPieceObj p, int dropIdx)
	{
		return 0;
	}

	public void DropGoldAnywhere(int nGold)
	{
	}

	public int DropRandomResources(int goldValue, GridPieceObj p, int dropIdx, System.Random rnd)
	{
		return 0;
	}

	public int GetExtraGoldAmount(int curTurn, System.Random rnd)
	{
		return 0;
	}

	public PickupObj CreatePickup(PickupInst p, bool isLoading)
	{
		return null;
	}

	public void BallHitPickup(Collider2D col, BallObj b)
	{
	}

	public void PickUpPlayerPickup(Collider2D col, int controllerIdx)
	{
	}

	public void PickUpResourcesInRange(Vector3 pos, float range, int controllerIdx)
	{
	}

	public void RemovePickup(PickupObj p)
	{
	}

	public void AddXP(int amt)
	{
	}

	public void AddGold(int amt)
	{
	}

	public void AddResource(ResourceType rt, int amt)
	{
	}

	[IteratorStateMachine(typeof(_003C_SpawnGem_003Ed__36))]
	public IEnumerator<float> _SpawnGem(Vector3 pos, float width, float height, int xpVal)
	{
		return null;
	}

	public void PickUpAllPickupsAboveY(float y)
	{
	}

	[IteratorStateMachine(typeof(_003C_PickUpAllPickupsAboveY_003Ed__38))]
	private IEnumerator<float> _PickUpAllPickupsAboveY(float y)
	{
		return null;
	}
}
