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

public class HoverPopup : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_RunLBEquipItemm_003Ed__24 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public HoverPopup _003C_003E4__this;

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
		public _003C_RunLBEquipItemm_003Ed__24(int _003C_003E1__state)
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
	private sealed class _003C_RunSettingsItem_003Ed__22 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public HoverPopup _003C_003E4__this;

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
		public _003C_RunSettingsItem_003Ed__22(int _003C_003E1__state)
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
	private sealed class _003C_RunStat_003Ed__20 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public HoverPopup _003C_003E4__this;

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
		public _003C_RunStat_003Ed__20(int _003C_003E1__state)
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

	public static HoverPopup I;

	[Header("Setup")]
	public CanvasScaler CvsScaler;

	public GameObject InstigatorObj;

	public RectTransform InstigatorXfm;

	[Header("Stat Hover")]
	public SlidingPanel PanelStat;

	public RectTransform StatXfm;

	public Localize LocStat;

	public TextSizeRectFitter StatRectFitter;

	public LocalizationParamsManager ParamsStat;

	private TextMeshProUGUI _statTxt;

	private StatType _tgtStat;

	private SettingsItem _tgtSettingsItem;

	private LeaderboardEquipmentItem _lbEquipItem;

	protected CoroutineHandle _curAnim;

	protected virtual void Awake()
	{
	}

	public void SetUpWorldRects(RectTransform hoverPanel, Vector3 extraWorldOffset)
	{
	}

	public void SetUpUIRects(RectTransform hoverPanel, Vector2 pivot, Vector2 pos, Vector2 margin)
	{
	}

	public virtual void SetUpUIRects(RectTransform hoverPanel)
	{
	}

	public void HoverStat(TextMeshProUGUI txt, StatType st)
	{
	}

	public void HoverScaling(TextMeshProUGUI txt, StatType st)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunStat_003Ed__20))]
	protected IEnumerator<float> _RunStat()
	{
		return null;
	}

	public void HoverSettingsItem(SettingsItem item)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunSettingsItem_003Ed__22))]
	private IEnumerator<float> _RunSettingsItem()
	{
		return null;
	}

	public void HoverLBEquipItem(LeaderboardEquipmentItem item)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunLBEquipItemm_003Ed__24))]
	private IEnumerator<float> _RunLBEquipItemm()
	{
		return null;
	}
}
