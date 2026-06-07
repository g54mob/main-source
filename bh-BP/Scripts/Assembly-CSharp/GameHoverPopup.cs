using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class GameHoverPopup : HoverPopup
{
	[CompilerGenerated]
	private sealed class _003C_RunEquipment_003Ed__29 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameHoverPopup _003C_003E4__this;

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
		public _003C_RunEquipment_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003C_RunEquipment_003Ed__30 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameHoverPopup _003C_003E4__this;

		public Vector2 pivot;

		public Vector2 pos;

		public Vector2 margin;

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
		public _003C_RunEquipment_003Ed__30(int _003C_003E1__state)
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

	public new static GameHoverPopup I;

	[Header("Equipment")]
	private HUDUpgradeItem _curHUDItem;

	private CoroutineHandle _curHUDAnim;

	private LevelUpCurEquipItem _tgtEquipItem;

	private CoroutineHandle _curEquipnim;

	private GameOverBallStatItem _tgtBallStatItem;

	private CoroutineHandle _curBallStatAnim;

	private FreeUpgradeItem _tgtFreeUpg;

	private CoroutineHandle _curFreeUpgAnim;

	private PetDisplayItemBattle _tgtPetDisp;

	private CoroutineHandle _curPetDispAnim;

	private CharInfoPanel _tgtCharInfo;

	private CoroutineHandle _curCharInfoAnim;

	private EvoSelectBtn _tgtEvoSelectBtn;

	private CoroutineHandle _curEvoAnim;

	private ComboSelectItem _tgtComboItem;

	private CoroutineHandle _curComboAnim;

	public RectTransform XfmEq;

	public SlidingPanel PanelEq;

	public EquipmentInfoPanel EqInfPanel;

	protected override void Awake()
	{
	}

	public void ClearHover()
	{
	}

	public void HoverEquipment(LevelUpCurEquipItem item)
	{
	}

	public void HoverBallStatItem(GameOverBallStatItem item)
	{
	}

	public void HoverFreeUpgrade(FreeUpgradeItem item)
	{
	}

	public void HoverHUDEquipment(HUDUpgradeItem item)
	{
	}

	public void HoverEvoSelect(EvoSelectBtn item)
	{
	}

	public void HoverComboItem(ComboSelectItem item)
	{
	}

	public void HoverCharInfo(CharInfoPanel panel, CharInfo c)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunEquipment_003Ed__29))]
	protected IEnumerator<float> _RunEquipment()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunEquipment_003Ed__30))]
	protected IEnumerator<float> _RunEquipment(Vector2 pivot, Vector2 pos, Vector2 margin)
	{
		return null;
	}
}
