using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaUI : OverlayUI
{
	[CompilerGenerated]
	private sealed class _003C_RefreshItemDetailsLayout_003Ed__45 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public EncyclopediaUI _003C_003E4__this;

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
		public _003C_RefreshItemDetailsLayout_003Ed__45(int _003C_003E1__state)
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

	public static EncyclopediaUI I;

	public static readonly string[] StatLabels;

	public static readonly string[] SetLabels;

	[NamedArray(typeof(EncycloPage))]
	public CoolButton[] NavBtns;

	public CoolButton BtnClose;

	public Localize LocHeader;

	public GameObject WrapperStatistics;

	public VerticalLayoutGroup StatLayoutGrp;

	public CoolSelectableWrapper StatSelectable;

	public VerticalLayoutGroup StatColumnLeft;

	public VerticalLayoutGroup StatColumnRight;

	public GameObject WrapperItems;

	public ScrollRect ScrlItems;

	public GridLayoutGroup ItemLayoutGrp;

	public SerializedObjectPool<EncyclopediaItem> EncycloItemPool;

	public SerializedObjectPool<EncyclopediaStatItem> EncycloStatItemPool;

	public ScrollRect ScrlDetails;

	public EquipmentInfoPanel ItemInfPanel;

	public CoolSelectableWrapper ItemSelectable;

	public GameObject WrapperItemDetailsLocked;

	public GameObject WrapperItemDetailsUnlocked;

	public VerticalLayoutGroup ItemDetailsLayoutGroup;

	public GameObject WrapperEnemyDetailsUnlocked;

	public PixelFontAutosizer EnemyNameAutosizer;

	public RectTransform EnemyDetailsContent;

	public Localize LocEnemyGameplayDesc;

	private EncyclopediaItem _selectedItem;

	public CoolButtonViz VizItemNormal;

	public CoolButtonViz VizItemSelected;

	public RectTransform WrapperSetDisplay;

	public EncycloSet CurSet;

	public Localize LocCurSet;

	public CoolButton BtnPrevSet;

	public CoolButton BtnNextSet;

	public EncycloPage CurPage;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnResolutionChanged()
	{
	}

	public override void Activate()
	{
	}

	public void SetPage(EncycloPage pg)
	{
	}

	public void SetCurSet(EncycloSet set)
	{
	}

	private void OnNextSetClicked()
	{
	}

	private void OnPrevSetClicked()
	{
	}

	protected override void MyUpdate()
	{
	}

	public void HoverItem(EncyclopediaItem item)
	{
	}

	[IteratorStateMachine(typeof(_003C_RefreshItemDetailsLayout_003Ed__45))]
	private IEnumerator<float> _RefreshItemDetailsLayout()
	{
		return null;
	}

	public override void OnUnderlayClicked()
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}

	private void OnCloseClicked()
	{
	}

	private void OnStatsClicked()
	{
	}

	private void OnBallsClicked()
	{
	}

	private void OnPassivesClicked()
	{
	}

	private void OnEnemiesClicked()
	{
	}
}
