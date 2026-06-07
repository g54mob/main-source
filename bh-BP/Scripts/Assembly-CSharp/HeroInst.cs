using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class HeroInst : UpgradeInst<HeroInfo>
{
	[CompilerGenerated]
	private sealed class _003CGetHitEffects_003Ed__28 : IEnumerable<StatusEffectType>, IEnumerable, IEnumerator<StatusEffectType>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private StatusEffectType _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public HeroInst _003C_003E4__this;

		private HeroInfo _003Cinf_003E5__2;

		private int _003Ci_003E5__3;

		private HeroInfo _003CcInf_003E5__4;

		private int _003Cj_003E5__5;

		StatusEffectType IEnumerator<StatusEffectType>.Current
		{
			[DebuggerHidden]
			get
			{
				return default(StatusEffectType);
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
		public _003CGetHitEffects_003Ed__28(int _003C_003E1__state)
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
		IEnumerator<StatusEffectType> IEnumerable<StatusEffectType>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetHitSFX_003Ed__63 : IEnumerable<EventReference>, IEnumerable, IEnumerator<EventReference>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EventReference _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private bool isBaby;

		public bool _003C_003E3__isBaby;

		public HeroInst _003C_003E4__this;

		private bool _003CshouldPlayMainSFX_003E5__2;

		private HeroInfo _003Cinf_003E5__3;

		private int _003Ci_003E5__4;

		private int _003Cj_003E5__5;

		EventReference IEnumerator<EventReference>.Current
		{
			[DebuggerHidden]
			get
			{
				return default(EventReference);
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
		public _003CGetHitSFX_003Ed__63(int _003C_003E1__state)
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
		IEnumerator<EventReference> IEnumerable<EventReference>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetSpecials_003Ed__31 : IEnumerable<BallSpecialType>, IEnumerable, IEnumerator<BallSpecialType>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private BallSpecialType _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public HeroInst _003C_003E4__this;

		private HeroInfo _003Cinf_003E5__2;

		private int _003Ci_003E5__3;

		private HeroInfo _003CcInf_003E5__4;

		private int _003Cj_003E5__5;

		BallSpecialType IEnumerator<BallSpecialType>.Current
		{
			[DebuggerHidden]
			get
			{
				return default(BallSpecialType);
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
		public _003CGetSpecials_003Ed__31(int _003C_003E1__state)
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
		IEnumerator<BallSpecialType> IEnumerable<BallSpecialType>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	public HeroType Type;

	public int FollowerOrder;

	public float LastLaunchTime;

	public float LastReturnTime;

	public float PreserveTime;

	public BallReturnType LastReturnType;

	public float LastHitSFXTime;

	public int Id;

	public int ParentId;

	public bool[] _hasAOE;

	public bool[] _hasStatusEff;

	public bool[] _hasSpecial;

	public List<HeroStatData> StatData;

	[NonSerialized]
	private Sprite _customIcon;

	[NonSerialized]
	private Dictionary<string, Texture2D>[] _customBallTextures;

	[NonSerialized]
	private Dictionary<string, Texture2D>[] _customTrailTextures;

	[NonSerialized]
	public BallObj Obj;

	public HeroInst(HeroType type)
	{
	}

	private void PopulateArrays(HeroInfo inf)
	{
	}

	public HeroInst(HeroInst toCopy)
	{
	}

	public int ModifyDamage(int dmg, PropertyType bonusProp, int lvl = -1)
	{
		return 0;
	}

	public int GetMinDamage(int lvl = -1)
	{
		return 0;
	}

	public int GetMaxDamage(int lvl = -1)
	{
		return 0;
	}

	public int PickDamage(ThreadSafeRandom rnd)
	{
		return 0;
	}

	public int GetNumHitEffects()
	{
		return 0;
	}

	public int GetNumAOE()
	{
		return 0;
	}

	public int GetNumSpecial()
	{
		return 0;
	}

	public bool HasHitEffect(StatusEffectType t)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CGetHitEffects_003Ed__28))]
	public IEnumerable<StatusEffectType> GetHitEffects()
	{
		return null;
	}

	public bool HasAOE(BallAOEType t)
	{
		return false;
	}

	public bool HasSpecial(BallSpecialType t)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CGetSpecials_003Ed__31))]
	public IEnumerable<BallSpecialType> GetSpecials()
	{
		return null;
	}

	public bool DoesDestroyOnHitEnemy(bool isBaby)
	{
		return false;
	}

	public bool DoesDestroyAfterHitEnemy(bool isBaby)
	{
		return false;
	}

	public bool DoesDestroyOnHitWall(bool isBaby)
	{
		return false;
	}

	public DamageType GetDamageType()
	{
		return default(DamageType);
	}

	public bool CanCombine(HeroInst h2)
	{
		return false;
	}

	public void CombineWith(HeroInst h2)
	{
	}

	private bool IsBadComboInternal(HeroInst h2)
	{
		return false;
	}

	public bool IsBadCombo(HeroInst h2)
	{
		return false;
	}

	public override bool ContainsComponent(UpgradeInfo upgInf)
	{
		return false;
	}

	public bool HasMergeComponent(UpgradeInfo upgInf)
	{
		return false;
	}

	public bool HasComboComponent(UpgradeInfo upgInf)
	{
		return false;
	}

	public Sprite GetIcon()
	{
		return null;
	}

	public void CleanUp()
	{
	}

	public Texture2D GetBallMeshTex(int idx, string propName)
	{
		return null;
	}

	public Texture2D GetBallTrailTex(int idx, string propName)
	{
		return null;
	}

	public Sprite GetPendingComboIcon(HeroInst h)
	{
		return null;
	}

	public override void ApplyIcon(Image img)
	{
	}

	public override HeroInfo GetInfo()
	{
		return null;
	}

	public HeroInfo GetInfo(int idx)
	{
		return null;
	}

	public int GetNumInfo()
	{
		return 0;
	}

	public HeroInfo GetBaseInfo()
	{
		return null;
	}

	public HeroInfo GetColorInfo()
	{
		return null;
	}

	public HeroType GetNonBirtherType()
	{
		return default(HeroType);
	}

	public string DumpStats()
	{
		return null;
	}

	public HeroStatData GetStatData()
	{
		return null;
	}

	public bool IsReadyToShoot()
	{
		return false;
	}

	public int GetBabyModifiedProperty(PropertyType pt, bool isBaby)
	{
		return 0;
	}

	public int GetBabyModifiedProperty(HeroType ht, PropertyType pt, bool isBaby)
	{
		return 0;
	}

	public int GetBabyModifiedRangeProperty(PropertyType ptMin, bool isBaby, ThreadSafeRandom rnd)
	{
		return 0;
	}

	public int GetBabyModifiedRangeProperty(HeroType ht, PropertyType ptMin, bool isBaby, ThreadSafeRandom rnd)
	{
		return 0;
	}

	public float GetReloadPct()
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(_003CGetHitSFX_003Ed__63))]
	public IEnumerable<EventReference> GetHitSFX(bool isBaby)
	{
		return null;
	}

	public bool HasType(HeroType ht)
	{
		return false;
	}
}
