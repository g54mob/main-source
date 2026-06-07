using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public TextMeshProUGUI textmeshPro;

	private Image image;

	private Color notSelected;

	[SerializeField]
	private Color selected;

	public ConversationUI.DialogueChoice choice;

	private Button btn;

	private void Awake()
	{
		image = GetComponent<Image>();
		notSelected = image.color;
		btn = GetComponent<Button>();
	}

	private void Start()
	{
		btn.onClick.AddListener(ButtonClicked);
	}

	private void ButtonClicked()
	{
		GameManager.S.DialogueChoiceBtnClicked(choice);
	}

	private void Update()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		textmeshPro.color = Color.black;
		image.color = selected;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		textmeshPro.color = Color.white;
		image.color = notSelected;
	}
}
