using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using MEC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpBtn : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateBanishing_003Ed__27 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpBtn _003C_003E4__this;

		private Color _003Cc_003E5__2;

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
		public _003C_AnimateBanishing_003Ed__27(int _003C_003E1__state)
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

	public int ChoiceIdx;

	public RectTransform Xfm;

	public SlidingPanel Panel;

	public RectTransform InnerXfm;

	public LvlUpChoiceType ChoiceType;

	public Image ImgIcon;

	public Image ImgPetIcon;

	public ResourceType ResType;

	public int NumResources;

	public TextMeshProUGUI TxtLvl;

	public Localize LocLvl;

	public LocalizationParamsManager ParamsLvl;

	public CoolButton Btn;

	public Image WrapperBanish;

	private CoroutineHandle _banishAnim;

	private Texture2D _customSprTex;

	public UpgradeInfo TgtInfo;

	public int TgtLvl;

	public int EquipmentIdx;

	public bool IsNew;

	private void Awake()
	{
	}

	private void InitInternal()
	{
	}

	public void SetUpgrade(int idx, UpgradeChoice choice)
	{
	}

	public void SetResource(int idx, ResourceType res)
	{
	}

	public void SetHero(int idx, HeroInfo inf, UpgradeChoice choice)
	{
	}

	public void SetPassive(int idx, PassiveInfo inf, UpgradeChoice choice)
	{
	}

	public void SetBanishing(bool isBanishing)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateBanishing_003Ed__27))]
	private IEnumerator<float> _AnimateBanishing()
	{
		return null;
	}

	private void OnClicked()
	{
	}
}
