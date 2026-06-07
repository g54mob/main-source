using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[SelectionBase]
public class Obj_LavaGround : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_Remove_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_LavaGround _003C_003E4__this;

		object IEnumerator<object>.Current
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
		public _003CCR_Remove_003Ed__34(int _003C_003E1__state)
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

	private static Dictionary<Vector3, Obj_LavaGround> dic_LavaPositions;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Renderer renderer_Lava;

	[SerializeField]
	private Material material_Normal;

	[SerializeField]
	private Material material_Corrupted;

	[SerializeField]
	private int damage;

	[SerializeField]
	private float damageInterval;

	[SerializeField]
	private float effectDuration;

	private bool isActivated;

	private float damageTimer;

	private float durationTimer;

	private float checkCorruptedGridTimer;

	private Vector3Int positionInt;

	private ABaseTower fromTower;

	private bool doUpdateDamageFromTower;

	private ABaseTower.eUpgradeType upgradeType;

	private bool isCorrupteMaterial;

	public ABaseTower FromTower => null;

	[RuntimeInitializeOnLoadMethod]
	public static void InitOnLoad()
	{
	}

	public static void ClearAllLavaGrounds()
	{
	}

	public static bool IsLavaGroundAt(Vector3 position)
	{
		return false;
	}

	public static Obj_LavaGround GetLavaGroundAt(Vector3 position)
	{
		return null;
	}

	public static int GetLavaGroundCount()
	{
		return 0;
	}

	public static Obj_LavaGround CreateLavaGround(Vector3 position, int damagePerTick, float damageInterval, ABaseTower fromTower = null, bool doUpdateDamageFromTower = false, bool overrideDuration = false, float duration = 0f)
	{
		return null;
	}

	public void Initialize(int damagePerTick, float damageInterval, ABaseTower fromTower = null, bool doUpdateDamageFromTower = false, bool overrideDuration = false, float duration = 0f)
	{
	}

	public void OverrideUpgradeType(ABaseTower.eUpgradeType type)
	{
	}

	private void CheckCorruptedGridUnderLava()
	{
	}

	public void SwitchMaterial(bool isCorrupted)
	{
	}

	private void Update()
	{
	}

	private void DealDamage()
	{
	}

	private void Toggle(bool isOn)
	{
	}

	public void ResetDuration()
	{
	}

	public void Despawn(bool isImmediate = false)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Remove_003Ed__34))]
	private IEnumerator CR_Remove()
	{
		return null;
	}
}
