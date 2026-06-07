using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

[SelectionBase]
public class Obj_FireSource : MonoBehaviour, IPlayerStartPoint, IVisionObject
{
	[CompilerGenerated]
	private sealed class _003CCR_CreateTiles_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_FireSource _003C_003E4__this;

		public int range;

		public int createCount;

		private List<Vector3Int> _003Clist_CreatedPos_003E5__2;

		private int _003Ci_003E5__3;

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
		public _003CCR_CreateTiles_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003CCR_DemonFireDestroyEffect_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_FireSource _003C_003E4__this;

		private List<ABaseTower>.Enumerator _003C_003E7__wrap1;

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
		public _003CCR_DemonFireDestroyEffect_003Ed__30(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private ParticleSystem particle_Fire;

	[Header("受傷Particle - 小")]
	[SerializeField]
	private ParticleSystem particle_TakeDamage_Small;

	[Header("受傷Particle - 中")]
	[SerializeField]
	private ParticleSystem particle_TakeDamage_Medium;

	[Header("受傷Particle - 大")]
	[SerializeField]
	private ParticleSystem particle_TakeDamage_Large;

	[Header("生命值Debug文字")]
	[SerializeField]
	private TMP_Text text_Debug_EnergyLevel;

	[SerializeField]
	[Header("能量的最大最小值 (用來轉換到其他數值)")]
	private Vector2 energyLevelRange;

	[SerializeField]
	private Renderer renderer_FogOfWar;

	[Header("迷霧可視範圍最大最小值")]
	[SerializeField]
	private Vector2 fogOfWarVisionRadiusRange;

	[SerializeField]
	private Obj_EmberFireController obj_EmberFireController;

	[SerializeField]
	private List<Renderer> list_AnomalyStartPositions;

	[SerializeField]
	private GameObject node_HardModeCrystals;

	[SerializeField]
	private List<GameObject> list_HardModeCrystals;

	private float lerpingLightIntensity;

	private float lerpingLightRange;

	private float lerpingFireParticleScale;

	private float lerpingFogOfWarRadius;

	private float energyLevel;

	private int placedTowerCountInThisRound;

	private int ancientFlameDormantLevel;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTowerPlaced(ABaseTower tower)
	{
	}

	private void OnRequestFireSourceInit(bool isAnomalyLevel)
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnRoundStart(int round, int totalRound)
	{
	}

	private void OnRoundEnd()
	{
	}

	private void UpdateHardModeCrystals()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CreateTiles_003Ed__28))]
	private IEnumerator CR_CreateTiles(int createCount, int range)
	{
		return null;
	}

	private void OnMonsterDealDamageToPlayer(AMonsterBase monster, int damage, int hpDamage, int armorDamage)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DemonFireDestroyEffect_003Ed__30))]
	private IEnumerator CR_DemonFireDestroyEffect()
	{
		return null;
	}

	private void OnHPChanged(int value)
	{
	}

	private void Reset()
	{
	}

	private void Update()
	{
	}

	public void SetEnergyLevel(int level)
	{
	}

	public void RegisterToMapManager()
	{
	}

	public void UnregisterToMapManager()
	{
	}

	public Vector3 GetPosition()
	{
		return default(Vector3);
	}

	public GameObject GetGameObject()
	{
		return null;
	}

	public float GetVisionRange()
	{
		return 0f;
	}

	public Vector3 GetVisionPosition()
	{
		return default(Vector3);
	}
}
