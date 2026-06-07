using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Obj_SkillButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public enum eSkillIndex
	{
		NONE = 0,
		SKILL_1 = 1,
		SKILL_2 = 2,
		SKILL_3 = 3
	}

	[SerializeField]
	private KeyCode keybind;

	[SerializeField]
	private eSkillIndex skillIndex;

	[SerializeField]
	protected int cost;

	[SerializeField]
	protected TMP_Text text_Cost;

	[SerializeField]
	protected Color color_Cost_Normal;

	[SerializeField]
	protected Color color_Cost_Insufficient;

	[SerializeField]
	protected GameObject node_Cost;

	[SerializeField]
	protected GameObject node_Content;

	[SerializeField]
	protected GameObject node_Banned;

	[SerializeField]
	protected GameObject node_InputGlyph;

	[SerializeField]
	protected Button button;

	[SerializeField]
	protected Transform node_Locked;

	[SerializeField]
	protected eItemType buffItemType;

	[SerializeField]
	protected Image image_CooldownBlackMask;

	[SerializeField]
	protected Spin cogSpin;

	[SerializeField]
	protected Spin cogShadowSpin;

	[SerializeField]
	protected bool isLockedInDemo;

	[SerializeField]
	protected bool doShowUseCount;

	[SerializeField]
	protected bool doPlayErrorSound;

	[SerializeField]
	protected TMP_Text text_UseCount;

	protected int useCountLimit;

	protected ABaseBuffSettingData settingData;

	protected int usedCountInThisRound;

	private float targetSpinSpeed;

	private const float cogSpinSpeed_Fast = -1.33f;

	private const float cogSpinSpeed_Slow = -0.05f;

	private bool isSkillUnlocked;

	protected bool isActivated;

	private bool isHaveCost;

	private bool isBanned;

	private bool isTooltipOn;

	private void OnValidate()
	{
	}

	private void OnEnable()
	{
	}

	protected virtual void OnEnableProc()
	{
	}

	private void OnDisable()
	{
	}

	protected virtual void OnDisableProc()
	{
	}

	private void OnGameInitReady()
	{
	}

	private void OnCoinChanged(int coin, int delta)
	{
	}

	private void UpdateCostTextColor()
	{
	}

	protected void ToggleButton(bool isOn)
	{
	}

	private void OnCancelBuffSelection()
	{
	}

	private void OnApplyBuff(ABaseBuffSettingData data, bool isFromPlayer, bool isPlayerAction)
	{
	}

	private void OnRoundStart(int round, int totalRound)
	{
	}

	private void SetUsedCount(int count)
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnCharacterChanged(eCharacterType characterType)
	{
	}

	protected abstract void OnCharacterChangedProc(eCharacterType characterType);

	protected abstract bool IsUnlocked();

	protected virtual void InitProc()
	{
	}

	private bool IsUsedCountLimitReached()
	{
		return false;
	}

	private void OnClickButton()
	{
	}

	protected void OnSkillUsed()
	{
	}

	protected abstract void OnSkillUsedProc();

	protected void SetCooldownMaskStatus(float rate)
	{
	}

	private void OnRequestBanCharacterSkills()
	{
	}

	public void SetBanned(bool isBanned)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
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

	private void StartTargetSelection()
	{
	}

	protected virtual void StartTargetSelectionProc()
	{
	}
}
