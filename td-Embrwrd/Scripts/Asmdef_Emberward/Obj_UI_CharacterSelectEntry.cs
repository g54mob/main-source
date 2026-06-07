using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Obj_UI_CharacterSelectEntry : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
{
	[SerializeField]
	private eCharacterType characterType;

	[SerializeField]
	private Image image_Character;

	[SerializeField]
	private Image image_Locked;

	[SerializeField]
	private GameObject node_Arrow;

	[SerializeField]
	private Color color_NotSelected;

	[SerializeField]
	private Color color_Selected;

	[SerializeField]
	private Color color_Locked;

	[SerializeField]
	private Button button;

	private bool isLocked;

	private bool isCurrentlySelected;

	private UI_SelectCharacterPopup parentUI;

	public eCharacterType CharacterType => default(eCharacterType);

	public Button Button => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void Setup(UI_SelectCharacterPopup parentUI, bool isLocked)
	{
	}

	public void SetIsCurrentlySelected(bool isSelected)
	{
	}

	private void Update()
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

	private void OnEnable()
	{
	}

	private void OnButtonSubmit()
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}

	private void OnDisable()
	{
	}
}
