using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerStatus : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_CoinLerpValue_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_PlayerStatus _003C_003E4__this;

		public int value;

		private float _003Cduration_003E5__2;

		private float _003Ctimer_003E5__3;

		private int _003CstartValue_003E5__4;

		private int _003CendValue_003E5__5;

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
		public _003CCR_CoinLerpValue_003Ed__31(int _003C_003E1__state)
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
	private sealed class _003CCR_LerpValueForText_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int start;

		public int end;

		public float duration;

		public TMP_Text text;

		private float _003Ctimer_003E5__2;

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
		public _003CCR_LerpValueForText_003Ed__27(int _003C_003E1__state)
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
	private Animator animator;

	[SerializeField]
	private TMP_Text text_Coin;

	[SerializeField]
	private TMP_Text text_Energy;

	[SerializeField]
	private GameObject node_MerchantSavedCoin;

	[SerializeField]
	private TMP_Text text_MerchantSavedCoin;

	[SerializeField]
	private Transform node_CoinAddEffectAnchor;

	[SerializeField]
	private Transform node_playerCharacter;

	[SerializeField]
	private Transform node_GamblerTokenIncrease;

	[SerializeField]
	private TMP_Text text_GamblerTokenIncrease;

	[SerializeField]
	private Transform node_PlayerCoin;

	[Header("ScrapMaster經驗條")]
	[SerializeField]
	private UI_ScrapMasterExpBar ui_ScrapMasterExpBar;

	[Header("賭徒紋章數量顯示")]
	[SerializeField]
	private GameObject node_RerollToken;

	[SerializeField]
	private TMP_Text text_RerollTokenCount;

	[SerializeField]
	[Header("顯示難度顏色用的角色邊框")]
	private Image image_PlayerCharacterBorder;

	[Header("計分UI")]
	[SerializeField]
	private UI_EndlessTimeScore ui_EndlessTimeScore;

	[SerializeField]
	private Color color_CasualDifficulty;

	[SerializeField]
	private Color color_NormalDifficulty;

	[SerializeField]
	private Color color_HeroicDifficulty;

	[SerializeField]
	private Color color_NightmareDifficulty;

	private int curCoinVaue;

	private bool doShowSavedCoin;

	private int curSavedCoinValue;

	private Coroutine coroutine_CoinChange;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnSavedCoinChanged(int value)
	{
	}

	private void OnRerollCountChanged(int value, int delta)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_LerpValueForText_003Ed__27))]
	private IEnumerator CR_LerpValueForText(int start, int end, TMP_Text text, float duration)
	{
		return null;
	}

	private void Update()
	{
	}

	private void OnCoinChanged(int value, int delta)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CoinLerpValue_003Ed__31))]
	private IEnumerator CR_CoinLerpValue(int value)
	{
		return null;
	}

	private void OnEnergyChanged(int value)
	{
	}

	private void OnMonsterDealDamageToPlayer(AMonsterBase monster, int damage, int hpDamage, int armorDamage)
	{
	}

	private void OnShowCommonIngameUI()
	{
	}

	private void OnHideCommonIngameUI()
	{
	}

	private void OnRequestHidePlayerResourceUI()
	{
	}
}
