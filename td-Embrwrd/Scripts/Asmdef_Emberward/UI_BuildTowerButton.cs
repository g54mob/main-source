using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_BuildTowerButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
	public enum eDisplayType
	{
		NORMAL = 0,
		BUILD_LIMIT_ONLY = 1
	}

	[CompilerGenerated]
	private sealed class _003CCR_ChangeCostTextEffect_003Ed__61 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int from;

		public int to;

		public UI_BuildTowerButton _003C_003E4__this;

		private float _003Cduration_003E5__2;

		private float _003Ctimer_003E5__3;

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
		public _003CCR_ChangeCostTextEffect_003Ed__61(int _003C_003E1__state)
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
	private KeyCode keycode;

	[SerializeField]
	private eInputAction inputAction;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private int index;

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private TMP_Text text_Cost;

	[SerializeField]
	private Transform node_Content;

	[SerializeField]
	private Transform node_CardFace;

	[SerializeField]
	private GameObject node_KeybindIcon;

	[Header("沒有鎖住, 但沒有卡片的狀態")]
	[SerializeField]
	private Transform node_Empty;

	[SerializeField]
	[Header("鎖住狀態")]
	private Transform node_Locked;

	[SerializeField]
	private Transform node_TowerSize;

	[SerializeField]
	private TMP_Text text_TowerSize;

	[SerializeField]
	private Transform node_TowerBuildLimit;

	[SerializeField]
	private TMP_Text text_TowerBuildLimit;

	[SerializeField]
	private Image image_BuildLimitReachedMask;

	[SerializeField]
	private UI_HoldableButton button;

	[Header("按鈕:目標優先權")]
	[SerializeField]
	private TwoMouseButtonButton button_TargetPriority;

	[SerializeField]
	private TMP_Text text_TargetPriorityType;

	[SerializeField]
	private RectTransform rectTransform_TargetPriority;

	[SerializeField]
	private GameObject node_SpecialTowerSizeIcon;

	[SerializeField]
	private Image image_SpecialTowerSizeIcon;

	[SerializeField]
	private GameObject node_Banned;

	private TowerIngameData currentData;

	private TowerSettingData currentSettingData;

	private Tweener cardMouseOverTweener;

	private bool isClicking;

	private Vector3 startClickMousePos;

	public Action<UI_BuildTowerButton> OnButtonClicked;

	private bool isActive;

	private bool isSelected;

	private bool canBuild;

	private bool isCoinEnough;

	private bool isClickedOnPriorityUI;

	private bool isPriorityUIActivated;

	private int currentCost;

	private bool isBanned;

	private bool isReachedBuildingLimit;

	private eDisplayType displayType;

	private int baseCost;

	private void Awake()
	{
	}

	public void SetIndex(int index)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnCardChanged(List<CardData> list)
	{
	}

	private void OnRequestSwitchBuildTowerButtonUIState(eDisplayType type)
	{
	}

	private void OnTowerRemoved(ABaseTower tower)
	{
	}

	private void OnTowerPlaced(ABaseTower tower)
	{
	}

	private void OnTowerSlotModifierChanged()
	{
	}

	private void OnTowerPriceChanged(eItemType type)
	{
	}

	private void OnGlobalTowerPriceChanged()
	{
	}

	private void UpdateTowerCostDisplay()
	{
	}

	private void Update()
	{
	}

	public void ToggleButton(bool isOn)
	{
	}

	private void OnConfirmPlacement(bool doContinuousBuild)
	{
	}

	private void OnCancelPlacement()
	{
	}

	private void OnTowerChanged(List<TowerIngameData> list, int index)
	{
	}

	private void OnForceUpdateAllTowerCard(List<TowerIngameData> list, int coin)
	{
	}

	private void UpdateCardContent(TowerIngameData data)
	{
	}

	private void OnCoinChanged(int coin, int delta)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ChangeCostTextEffect_003Ed__61))]
	private IEnumerator CR_ChangeCostTextEffect(int from, int to)
	{
		return null;
	}

	private void SetCostText(int value)
	{
	}

	private void UpdateCoinUI(int coin)
	{
	}

	private void OnGameStateChanged(eGameState fromState, eGameState toState)
	{
	}

	private void ToggleTransparent(bool isTransparent, float alpha)
	{
	}

	private void InitiateTowerPlacement()
	{
	}

	private void ToggleSelected(bool isSelected)
	{
	}

	public void TriggerShineAnimation()
	{
	}

	public void OnOtherButtonActivated()
	{
	}

	private void OnPlacementComplete()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void OnClickTargetPriority_LeftClick()
	{
	}

	private void OnClickTargetPriority_RightClick()
	{
	}

	private void UpdatePriorityUIContent()
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	private void TogglePriorityUI(bool isOn)
	{
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
	}

	public void OnEndDrag(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}
}
