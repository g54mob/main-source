using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : OverlayUI
{
	[CompilerGenerated]
	private sealed class _003C_Test_003Ed__52 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PauseUI _003C_003E4__this;

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
		public _003C_Test_003Ed__52(int _003C_003E1__state)
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

	public static PauseUI I;

	public GamePausePage CurPage;

	[NamedArray(typeof(GamePausePage))]
	public CoolButton[] NavBtns;

	[NamedArray(typeof(GamePausePage))]
	public GameObject[] Wrappers;

	[Header("Char")]
	public ScrollRect ScrlChar;

	public CharInfoPanel InfPanel;

	public DetailedStatsPanel StatPanel;

	public StatDisplayGroup BasicStats;

	public GameObject WrapperBasicInfo;

	public GameObject WrapperDetailedStats;

	public bool IsShowingDetailedStats;

	public CoolButton BtnStatDisplayToggle;

	public Localize LocStatDisplayToggle;

	[Header("Equipment")]
	public Transform WrapperEquipBtns;

	public CoolSelectableWrapper SelectableEquipBtns;

	public CoolButtonGroup BtnGrpEquipBtns;

	public PauseEquipInfoBtn PrefabEquipBtn;

	private ObjectPool<PauseEquipInfoBtn> _equipBtnPool;

	public EquipmentInfoPanel EquipInfoPanel;

	public ScrollRect ScrlEquipDetails;

	public RectTransform WrapperEquipDetails;

	public VerticalLayoutGroup GrpEquipDetails;

	private PauseEquipInfoBtn _selectedEquipBtn;

	[Header("System")]
	public CoolSelectableWrapper SelectableSystem;

	public CoolButton BtnRestart;

	public CoolButton BtnEncyclopedia;

	public CoolButton BtnSettings;

	public CoolButton BtnBase;

	public CoolButton BtnClose;

	public CoolButton BtnAch;

	private void Awake()
	{
	}

	public override void Activate()
	{
	}

	public void SetPage(GamePausePage pg, bool force = false)
	{
	}

	protected override void MyUpdate()
	{
	}

	private void OnCharNavClicked()
	{
	}

	private void OnEquipNavClicked()
	{
	}

	private void OnSystemNavClicked()
	{
	}

	public void ToggleDetailedStats(bool isOn)
	{
	}

	private void OnStatsToggled()
	{
	}

	private void OnBaseClicked()
	{
	}

	private void OnEncyclopediaClicked()
	{
	}

	private void OnSettingsClicked()
	{
	}

	private void OnBaseConfirmed()
	{
	}

	private void OnRestartClicked()
	{
	}

	private void OnRestartConfirmed()
	{
	}

	public void OnCloseClicked()
	{
	}

	public override void OnUnderlayClicked()
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}

	private void OnEquipEntered(CoolButton btn)
	{
	}

	private void OnEquipNav(CoolButton prevBtn, CoolButton newBtn)
	{
	}

	private void SetSelectedEquipBtn(PauseEquipInfoBtn btn)
	{
	}

	public void PreviewHero(PauseEquipInfoBtn btn, HeroInst h)
	{
	}

	[IteratorStateMachine(typeof(_003C_Test_003Ed__52))]
	private IEnumerator<float> _Test()
	{
		return null;
	}

	public void PreviewPassive(PauseEquipInfoBtn btn, PassiveInst p)
	{
	}

	public void PreviewPet(PauseEquipInfoBtn btn, PetBattleInst p)
	{
	}
}
