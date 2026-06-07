using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_MonsterHPBar : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_DamageLerpEffect_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MonsterHPBar _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003CstartPercentage_003E5__3;

		private float _003Cduration_003E5__4;

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
		public _003CCR_DamageLerpEffect_003Ed__34(int _003C_003E1__state)
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
	private CanvasGroup canvasGroup;

	[SerializeField]
	private Image image_Bar;

	[SerializeField]
	private Image image_PoisonBar;

	[SerializeField]
	private Image image_BurnBar;

	[SerializeField]
	private Image image_ElectricBar;

	[SerializeField]
	[FormerlySerializedAs("image_ElectricBar_BG")]
	private Image image_ExtraBarBG;

	[SerializeField]
	private Image image_FragileBar;

	[SerializeField]
	private Image image_Bar_Damage;

	[SerializeField]
	private List<Image> list_ChillEffectIcons;

	[SerializeField]
	private Vector3 localOffset;

	[SerializeField]
	private Color color_Normal;

	[SerializeField]
	private Color color_Poison;

	[SerializeField]
	private Color color_Burning;

	[SerializeField]
	private Color color_Freeze;

	private Vector3 extraBar1Position;

	private Vector3 extraBar2Position;

	[SerializeField]
	private float width;

	[SerializeField]
	private float extraBarBGHeight;

	private AMonsterBase targetMonster;

	private float monsterHPPercentage;

	private float damageLerpPercentage;

	private float monsterPoisonDamagePercentage;

	private int updateFrameCount;

	private bool isElectricBarEnabled;

	private bool isFragileBarEnabled;

	private float barwidth;

	private Coroutine coroutine_DamageLerpEffect;

	public float Width => 0f;

	private void Awake()
	{
	}

	public void AttachUI(AMonsterBase target)
	{
	}

	public void DetachUI()
	{
	}

	private void OnMonsterDisable(AMonsterBase monster)
	{
	}

	private void OnMonsterDamaged(AMonsterBase monster, int damage, eDamageType damageType, bool isCrit, ABaseTower tower)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DamageLerpEffect_003Ed__34))]
	private IEnumerator CR_DamageLerpEffect()
	{
		return null;
	}

	private void OnMonsterDamageDebuffChange()
	{
	}

	private void UpdateChillEffectIcons()
	{
	}

	private void UpdateElectricBar()
	{
	}

	private void UpdateFragileBar()
	{
	}

	private void UpdateExtraBarBG()
	{
	}

	private void UpdateBarColor()
	{
	}

	private void Update()
	{
	}
}
