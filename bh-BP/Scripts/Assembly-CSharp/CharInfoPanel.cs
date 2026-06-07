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

public class CharInfoPanel : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateXPAura_003Ed__27 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public CharInfoPanel _003C_003E4__this;

		public float len;

		public Color tgtColor;

		private float _003CstartTime_003E5__2;

		private Color _003CstartColor_003E5__3;

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
		public _003C_AnimateXPAura_003Ed__27(int _003C_003E1__state)
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

	public Image ImgIcon;

	public Image ImgIcon2;

	public CoolButton BtnCharHoverLeft;

	public CoolButton BtnCharHoverRight;

	public Localize LocName;

	public LocalizationParamsManager ParamsName;

	public Localize LocDesc;

	public LocalizationParamsManager ParamsDesc;

	public GameObject WrapperStarter;

	public Image ImgStarter;

	public Localize LocStarterName;

	public DetailedStatsPanel StatsPanel;

	public StatDisplayGroup StatGrp;

	public StatPropDisplayGroup StatPropGrp;

	public LocalizationParamsManager ParamsLvl;

	public Image ImgXP;

	public TextMeshProUGUI TxtXP;

	private CoroutineHandle _xpAnim;

	public HarvestDisplayItem[] HarvestUpgradeItems;

	public Localize LocWorkerStatus;

	private CharMetaInst _tgtChar;

	private void Awake()
	{
	}

	public void SetChar(CharBattleInst c)
	{
	}

	public void SetChar(CharMetaInst c)
	{
	}

	public void SetXPVal(int xp)
	{
	}

	public void EnterXPActive()
	{
	}

	public void ExitXPActive()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateXPAura_003Ed__27))]
	private IEnumerator<float> _AnimateXPAura(Color tgtColor, float len)
	{
		return null;
	}

	public Color GetDefaultXPAura()
	{
		return default(Color);
	}

	public Color GetActiveXPAura()
	{
		return default(Color);
	}

	private void OnCharLeftHover()
	{
	}

	private void OnCharRightHover()
	{
	}

	private void OnCharHoverExit()
	{
	}
}
