using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using UnityEngine;

public class EquipmentInfoPanel : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_Test_003Ed__23 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public EquipmentInfoPanel _003C_003E4__this;

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
		public _003C_Test_003Ed__23(int _003C_003E1__state)
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

	public RectTransform Wrapper;

	public Localize LocEquipName;

	public LocalizationParamsManager ParamsEquipName;

	public PixelFontAutosizer NameAutosizer;

	public LocalizationParamsManager ParamsEquipLvl;

	public Localize LocEquipDmg;

	public LocalizationParamsManager ParamsEquipDmg;

	public EquipmentDescPanel DescPanel;

	public bool ShowExtraDesc;

	public EquipmentDescPanel[] ExtraDescPanels;

	[Header("Evo")]
	public EquipmentEvoPanel[] EvoPanels;

	public GameObject[] WrapperEvoOr;

	public Localize LocEvoLabel;

	public GameObject WrapperEvoDivider;

	public EquipmentEvoPanel[] TgtEvoPanels;

	public LocalizationParamsManager ParamsUnknownEvos;

	public void SetUpgrade(UpgradeInfo inf, int lvl)
	{
	}

	public void SetHero(HeroInst h)
	{
	}

	public void SetBaby()
	{
	}

	public void SetPassive(PassiveInst p)
	{
	}

	public void SetChar(CharInfo inf)
	{
	}

	public void InitEncyclopedia(UpgradeInfo inf)
	{
	}

	public void InitTgtEvoPanels(UpgradeInfo inf)
	{
	}

	[IteratorStateMachine(typeof(_003C_Test_003Ed__23))]
	private IEnumerator<float> _Test()
	{
		return null;
	}
}
