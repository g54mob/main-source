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

public class BaseUI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateSidebar_003Ed__97 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseUI _003C_003E4__this;

		public CoolButton selectOnComplete;

		private Vector2 _003CtgtPos_003E5__2;

		private float _003CstartTime_003E5__3;

		private Vector2 _003CstartPos_003E5__4;

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
		public _003C_AnimateSidebar_003Ed__97(int _003C_003E1__state)
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
	private sealed class _003C_FadeUI_003Ed__73 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseUI _003C_003E4__this;

		public float len;

		public float alpha;

		private float _003CstartTime_003E5__2;

		private float _003CstartAlpha_003E5__3;

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
		public _003C_FadeUI_003Ed__73(int _003C_003E1__state)
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
	private sealed class _003C_RunShowUpgradeable_003Ed__116 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseUI _003C_003E4__this;

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
		public _003C_RunShowUpgradeable_003Ed__116(int _003C_003E1__state)
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

	public static BaseUI I;

	public Canvas CvsNoScale;

	public CanvasScaler CvsScaler;

	public CanvasGroup CvsGrpMain;

	public CanvasGroup CvsGrpResources;

	[Header("Top Bar")]
	public GameObject WrapperResources;

	[NonSerialized]
	public RectTransform XfmResources;

	public RectTransform XfmResourceBacking;

	[NamedArray(typeof(ResourceType))]
	public ResourceText[] TxtResources;

	public Rect[] ResourceTextRect;

	public LocalizationParamsManager ParamsDay;

	public RectTransform XfmWhole;

	[Header("Sidebar")]
	public RectTransform XfmBotBar;

	public CoolSelectableWrapper WrapperBotBar;

	public GameObject WrapperBuildHUD;

	public BaseSidebarBtn BtnOptions;

	public BaseSidebarBtn BtnPlay;

	public BaseSidebarBtn BtnBuild;

	public BaseSidebarBtn BtnWorkers;

	public BaseSidebarBtn BtnExpand;

	public BaseSidebarBtn BtnRearrange;

	public GameObject WrapperHarvestNotif;

	public TextMeshProUGUI TxtHarvestMasseuseCost;

	public GameObject WrapperBuildNotif;

	public GameObject WrapperHatcheryNotif;

	public RectTransform WrapperControllerPrompt;

	private bool _isSidebarSelected;

	private bool _isAnimatingSidebar;

	private CoroutineHandle _sidebarAnim;

	[Header("Prompts")]
	public CanvasGroup GrpMainPrompt;

	public TextSizeRectFitter FitterMainPrompt;

	public Localize LocMainPrompt;

	public LocalizationParamsManager ParamsMainPrompt;

	public BtnPrompt PromptViewUpgrades;

	public BtnPrompt PromptPickUp;

	public BtnPrompt PromptRotate;

	public BtnPrompt PromptLaunchHarvest;

	public BtnPrompt PromptViewWorkers;

	public BtnPrompt PromptSpeedUpHarvest;

	public BtnPrompt PromptCancelHarvest;

	public BtnPrompt PromptDismantleMultiple;

	public BtnPrompt PromptUpgradeMultiple;

	public BtnPrompt BtnPromptPanController;

	public CanvasGroup GrpHarvestClock;

	public TextMeshProUGUI TxtHarvestClock;

	private bool _isUIHidden;

	private CoroutineHandle _fadeAnim;

	[Header("Mobile")]
	public CoolButton BtnShowUpgradeable;

	public LocalizationParamsManager ParamsBtnShowUpgradeable;

	public GameObject WrapperExitMode;

	public CoolButton BtnExitMode;

	public CoolButton BtnSpeedUpHarvest;

	public CoolToggleButton BtnPanHarvest;

	public Image ImgPanHarvest;

	public GameObject WrapperRightBtns;

	public CoolButton BtnPlaceBuilding;

	public CoolButton BtnRotateBuilding;

	public CoolButton BtnCancelBuilding;

	public CoolButton BtnMultiUpgrade;

	public CoolButton BtnMultiDelete;

	public CoolToggleButton BtnToggleMultiselect;

	public CoolButton BtnTouchActionRight;

	public Localize LocTouchActionRight;

	public CoolButton BtnTouchCheats;

	private int _numTimesPressedCheats;

	private float _lastTouchCheatTime;

	private bool _isSidebarBlocked;

	private CoroutineHandle _showUpgradeableAnim;

	private int _numCheatPressed;

	private float _lastCheatPressTime;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void RefreshNotifIcons()
	{
	}

	public void RefreshMasseuseCost()
	{
	}

	public void RefreshWorkerBtn()
	{
	}

	public void SetHidden(bool hidden, bool animate)
	{
	}

	[IteratorStateMachine(typeof(_003C_FadeUI_003Ed__73))]
	private IEnumerator<float> _FadeUI(float alpha, float len)
	{
		return null;
	}

	private void OnBaseStateChanged()
	{
	}

	public void ActivateMainPrompt(string loc)
	{
	}

	public void RefreshBuildBtn()
	{
	}

	private void OnPlayClicked()
	{
	}

	private void OnOptionsClicked()
	{
	}

	private void OnBuildClicked()
	{
	}

	private void OnWorkersClicked()
	{
	}

	private void OnMasseuseBought()
	{
	}

	private void OnExpandClicked()
	{
	}

	private void OnRearrangeClicked()
	{
	}

	public float GetSideBarScreenWidth()
	{
		return 0f;
	}

	private void OnResourcesChanged(ResourceType rt)
	{
	}

	private void RefreshBuildingUpgrades()
	{
	}

	public void ActivateHarvestClock()
	{
	}

	public void RefreshHarvestClock()
	{
	}

	public void DeactivateHarvestClock()
	{
	}

	public bool IsSidebarSelected()
	{
		return false;
	}

	public bool IsAnimatingSidebar()
	{
		return false;
	}

	public void BlockSidebarInput(bool isBlocked)
	{
	}

	public bool IsSidebarBlocked()
	{
		return false;
	}

	public void SetSidebarSelected(bool isOut, bool immediate = false, CoolButton selectOnComplete = null)
	{
	}

	public void ClearSidebarSelection()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateSidebar_003Ed__97))]
	private IEnumerator<float> _AnimateSidebar(CoolButton selectOnComplete)
	{
		return null;
	}

	public bool IsBaseSidebarBtn(Transform xfm)
	{
		return false;
	}

	public bool IsFTUEPointingAtBaseSidebarBtn()
	{
		return false;
	}

	private void OnInputTypeChanged()
	{
	}

	private void OnExitModeClicked()
	{
	}

	private void OnSpeedUpPressed()
	{
	}

	private void OnPanHarvestClicked()
	{
	}

	public void OnPlaceBuildingClicked()
	{
	}

	private void OnRotateBuildingClicked()
	{
	}

	private void OnCancelBuildingClicked()
	{
	}

	private void OnMultiUpgradeClicked()
	{
	}

	private void OnMultiDeleteClicked()
	{
	}

	private void OnTouchActionRightClicked()
	{
	}

	private void OnMultiselectedToggled()
	{
	}

	public void RefreshResourceRect()
	{
	}

	private void OnShowUpgradeablePressed()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunShowUpgradeable_003Ed__116))]
	private IEnumerator<float> _RunShowUpgradeable()
	{
		return null;
	}

	private void OnTouchCheatsClicked()
	{
	}
}
