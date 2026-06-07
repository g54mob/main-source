using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

public class FireSourceShootModule : MonoBehaviour, IInteractable
{
	[CompilerGenerated]
	private sealed class _003CCR_BlazeFire_Attack_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FireSourceShootModule _003C_003E4__this;

		public AMonsterBase target;

		public LineRenderer lineRenderer;

		private float _003ClineWidth_003E5__2;

		private Vector3 _003CtargetPoint_003E5__3;

		private float _003Ctime_003E5__4;

		private float _003Cduration_003E5__5;

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
		public _003CCR_BlazeFire_Attack_003Ed__73(int _003C_003E1__state)
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
	private sealed class _003CCR_BlazeFire_AttackMonsters_003Ed__72 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FireSourceShootModule _003C_003E4__this;

		private List<AMonsterBase> _003CselectedMonsters_003E5__2;

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
		public _003CCR_BlazeFire_AttackMonsters_003Ed__72(int _003C_003E1__state)
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
	private sealed class _003CCR_BlazeFire_ShootLightning_003Ed__71 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FireSourceShootModule _003C_003E4__this;

		public AMonsterBase target;

		public LineRenderer lineRenderer;

		private float _003ClineWidth_003E5__2;

		private Vector3 _003CtargetPoint_003E5__3;

		private float _003Ctime_003E5__4;

		private float _003Cduration_003E5__5;

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
		public _003CCR_BlazeFire_ShootLightning_003Ed__71(int _003C_003E1__state)
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
	private sealed class _003CCR_BlazeFire_StunMonsters_003Ed__70 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FireSourceShootModule _003C_003E4__this;

		private List<AMonsterBase> _003CselectedMonsters_003E5__2;

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
		public _003CCR_BlazeFire_StunMonsters_003Ed__70(int _003C_003E1__state)
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
	private sealed class _003CCR_CleanseCorruptedGridEffect_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ACorruptedPowerGrid grid;

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
		public _003CCR_CleanseCorruptedGridEffect_003Ed__46(int _003C_003E1__state)
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
	private sealed class _003CCR_OverchargeTower_003Ed__68 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FireSourceShootModule _003C_003E4__this;

		public ABaseTower targetTower;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

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
		public _003CCR_OverchargeTower_003Ed__68(int _003C_003E1__state)
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

	[SerializeField]
	private Obj_FireSource fireSource;

	[SerializeField]
	private GameObject bulletPrefab;

	[SerializeField]
	private GameObject bulletPrefab_HolyFire;

	[SerializeField]
	private GameObject bulletPrefab_DemonFire;

	[SerializeField]
	private GameObject bulletPrefab_FrostFire;

	[SerializeField]
	private Transform shootPosition;

	[SerializeField]
	private int damage_normal;

	[SerializeField]
	private float holyFireRangeIncreaseEachRound;

	[SerializeField]
	private float holyFireRangeIncreaseCap;

	[SerializeField]
	private float demonFireDamageMultiplier;

	[SerializeField]
	private float demonFireShootSpeedMultiplier;

	[SerializeField]
	private float frostFireShootSpeedMultiplier;

	[SerializeField]
	private float frostFireRangeIncreaseEachRound;

	[SerializeField]
	private LineRenderer lineRenderer_ElectricEffect;

	[SerializeField]
	private LineRenderer lineRenderer_ElectricEffect2;

	[SerializeField]
	private LineRenderer lineRenderer_ElectricDamageEffect1;

	[SerializeField]
	private LineRenderer lineRenderer_ElectricDamageEffect2;

	[SerializeField]
	private LineRenderer lineRenderer_ElectricDamageEffect3;

	[SerializeField]
	private ParticleSystem particle_ElectricHitEffect;

	[SerializeField]
	private float attackRange;

	[SerializeField]
	private float shootInterval;

	[SerializeField]
	private Transform node_RangeIndicator;

	private List<int> list_DemonFireExpRequirement;

	[SerializeField]
	[Header("火焰攻擊的數值")]
	private TMP_Text text_FireDamageDetails;

	private float shootTimer;

	private AMonsterBase currentTarget;

	private bool IsEmberSparkTalentLearned;

	private bool IsHolyFire;

	private bool IsDemonFire;

	private bool IsFrostFire;

	private bool IsBlazeFire;

	private float blazeFireStunIntervalMin;

	private float blazeFireStunIntervalMax;

	private float blazeFireStunTimer;

	private int killedCount;

	private int exp;

	private int demonFlameLevel;

	private int extraDamage;

	private int maxDamage;

	private float baseAttackRange;

	private List<(AGridObject grid, float time)> list_AttackedCorruptedGrid;

	private TweenerCore<Vector3, Vector3, VectorOptions> tween;

	private int blazeFireStunEffectTriggerCount;

	private int blazeFireAttackTriggerCount;

	private List<Vector3> list_LinePoints;

	private int UpgradeExpNeed => 0;

	private void OnValidate()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRoundStart(int currentRound, int totalRound)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CleanseCorruptedGridEffect_003Ed__46))]
	private IEnumerator CR_CleanseCorruptedGridEffect(ACorruptedPowerGrid grid)
	{
		return null;
	}

	private void Start()
	{
	}

	private void OnPlayerVictory()
	{
	}

	public float GetShootRange()
	{
		return 0f;
	}

	private void Update()
	{
	}

	private void OnHitGroundTarget(AGridObject target)
	{
	}

	protected void Shoot(AMonsterBase target)
	{
	}

	private int GetDemonFireDamage()
	{
		return 0;
	}

	private void OnMonsterDealDamageToPlayer(AMonsterBase monster, int damage, int hpDamage, int armorDamage)
	{
	}

	private void OnKillMonster(AProjectile bullet, AMonsterBase monster)
	{
	}

	private void IncreaseDemonFlameExp(int addExp)
	{
	}

	private void UpdateDetailsText()
	{
	}

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}

	public void OnRayEnter()
	{
	}

	public void OnRayExit()
	{
	}

	private void BlazeFire_OverchargeTower(ABaseTower target)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_OverchargeTower_003Ed__68))]
	private IEnumerator CR_OverchargeTower(ABaseTower targetTower)
	{
		return null;
	}

	private void SetLinePoints(List<Vector3> list_LinePoints, int v1, int v2)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_BlazeFire_StunMonsters_003Ed__70))]
	private IEnumerator CR_BlazeFire_StunMonsters()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_BlazeFire_ShootLightning_003Ed__71))]
	private IEnumerator CR_BlazeFire_ShootLightning(AMonsterBase target, LineRenderer lineRenderer)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_BlazeFire_AttackMonsters_003Ed__72))]
	private IEnumerator CR_BlazeFire_AttackMonsters()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_BlazeFire_Attack_003Ed__73))]
	private IEnumerator CR_BlazeFire_Attack(AMonsterBase target, LineRenderer lineRenderer)
	{
		return null;
	}
}
