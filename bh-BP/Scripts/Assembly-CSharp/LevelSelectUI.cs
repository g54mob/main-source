using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using MEC;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUI : OverlayUI
{
	[CompilerGenerated]
	private sealed class _003C_RunUpgradeLift_003Ed__43 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

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
		public _003C_RunUpgradeLift_003Ed__43(int _003C_003E1__state)
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
	private sealed class _003C_WaitAndFocus_003Ed__28 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelSelectUI _003C_003E4__this;

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
		public _003C_WaitAndFocus_003Ed__28(int _003C_003E1__state)
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

	public static LevelSelectUI I;

	public CoolButtonGroup BtnGrp;

	public ScrollRect Scrl;

	public GameObject WrapperSelectNGPlus;

	public Localize LocSelectNGPlus;

	public LocalizationParamsManager ParamsSelectNGPlus;

	public CoolButton BtnNGPlusLeft;

	public CoolButton BtnNGPlusRight;

	public CoolButton BtnClose;

	public CoolButton BtnPlay;

	public CoolButton BtnUpgradeLift;

	public LocalizationParamsManager ParamsUpgradeLift;

	public Image ImgSurface;

	public LevelSelectItem[] Items;

	public float MapHeight;

	public float[] DefaultY;

	public LevelEnemyItem PrefabEnItem;

	[NonSerialized]
	public ObjectPool<LevelEnemyItem> EnItemPool;

	public LevelCharItem PrefabCharItem;

	[NonSerialized]
	public ObjectPool<LevelCharItem> CharItemPool;

	private LevelSelectItem _selectedItem;

	private LevelInfo _selectedLevel;

	private int _selectedNGPlus;

	private int _selectedDiff;

	private bool _canUpgradeElevator;

	private CoroutineHandle _curScrlAnim;

	private void Awake()
	{
	}

	public override void Activate()
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndFocus_003Ed__28))]
	private IEnumerator<float> _WaitAndFocus()
	{
		return null;
	}

	protected override void OnEntryComplete()
	{
	}

	private void FocusOnLatestLvl()
	{
	}

	protected override void MyUpdate()
	{
	}

	private void OnCloseClicked()
	{
	}

	public override void OnUnderlayClicked()
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}

	public void SelectItem(LevelSelectItem item)
	{
	}

	public void ClickItem(LevelSelectItem item)
	{
	}

	private void OnGrpEntered(CoolButton btn)
	{
	}

	private void OnGrpNav(CoolButton btnPrev, CoolButton btnNext)
	{
	}

	private void OnGrpExited(CoolButton btn)
	{
	}

	private void OnPlayClicked()
	{
	}

	public void SetSelectedNGPlus(int ng)
	{
	}

	private void OnUpgradeLiftClicked()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunUpgradeLift_003Ed__43))]
	private IEnumerator<float> _RunUpgradeLift()
	{
		return null;
	}

	public LevelInfo GetSelectedLevel()
	{
		return null;
	}

	public int GetSelectedDifficulty()
	{
		return 0;
	}

	public int GetSelectedNGPlus()
	{
		return 0;
	}

	private void OnPrevNGPlusClicked()
	{
	}

	private void OnNextNGPlusClicked()
	{
	}
}
