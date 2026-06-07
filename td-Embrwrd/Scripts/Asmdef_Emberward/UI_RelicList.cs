using System.Collections.Generic;
using Rewired;
using Rewired.Glyphs.UnityUI;
using UnityEngine;
using UnityEngine.UI;

public class UI_RelicList : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Transform node_Layout;

	[SerializeField]
	[Header("是否可以用搖桿檢視內容")]
	private bool canSeeDetail;

	[SerializeField]
	private List<UI_Obj_RelicItem> list_RelicItems;

	[SerializeField]
	[Header("要接收到這個input才會觸發")]
	private eInputAction showDetailInputAction;

	[SerializeField]
	private eControlScheme triggerControlScheme;

	[SerializeField]
	[Header("搖桿檢視內容的選擇框node")]
	private GameObject node_SelectFrame;

	[Header("搖桿檢視內容的選擇框")]
	[SerializeField]
	private Image image_SelectingEffect;

	[SerializeField]
	[Header("當放在其他視窗下時，要這個視窗是top stack才接收訊號")]
	private APopupWindow parentPopupWindow;

	[SerializeField]
	private UnityUITextMeshProGlyphHelper text_JoystickGlyphInfo;

	private Vector2 defaultGridItemSize;

	[SerializeField]
	private GridLayoutGroup gridLayout;

	[SerializeField]
	[Header("超過X個神器之後縮小尺寸")]
	private int shrinkItemThreshold;

	[SerializeField]
	private float shrinkItemMultiplier;

	private int defaultGridConstraintCount;

	private bool isShowingDetail;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnRelicItemSelectedCallback(UI_Obj_RelicItem item)
	{
	}

	private void Update()
	{
	}

	private void UpdateGlyphText()
	{
	}

	private void SelectItem(UI_Obj_RelicItem item)
	{
	}

	private void RebuildNavigation()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnControlSchemeChanged(eControlScheme scheme)
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}

	public void SetupParentPopupWindow(APopupWindow popup)
	{
	}

	public void ForceUpdateAllRelics()
	{
	}

	private void OnRelicChanged(List<eItemType> list)
	{
	}

	public void Toggle(bool isOn, bool isImmediate)
	{
	}

	private void OnRelicLoadedInGame(eItemType itemType)
	{
	}

	private void UpdateRelicSize()
	{
	}

	private void OnShowCommonIngameUI()
	{
	}

	private void OnHideCommonIngameUI()
	{
	}
}
