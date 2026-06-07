using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Obj_IngameCharacterSelectEntry : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private eCharacterType characterType;

	[SerializeField]
	private Image image_Character;

	[SerializeField]
	private GameObject node_Locked;

	[SerializeField]
	private GameObject node_Unavailable;

	[SerializeField]
	private Image image_Selected;

	[SerializeField]
	private Image image_CharacterBG;

	[SerializeField]
	private TMP_Text text_BestRecord;

	[SerializeField]
	private Button button;

	private bool isLocked;

	private bool isUnavailable;

	private bool isCurrentlySelected;

	private UI_InGameSelectCharacterPopup parentUI;

	public eCharacterType CharacterType => default(eCharacterType);

	public Button Button => null;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Setup(UI_InGameSelectCharacterPopup parentUI, bool isLocked, bool isUnavailable)
	{
	}

	public void SetIsCurrentlySelected(bool isSelected)
	{
	}

	public void OnClickButton()
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void OnButtonClickByJoystick()
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}
}
