using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private Color _original = Color.white;

	private Sprite _originalSprite;

	private Sprite _hoverSprite;

	private void Awake()
	{
		_original = base.transform.Find("Text (TMP)").GetComponent<TMP_Text>().color;
		_originalSprite = GetComponent<Image>().sprite;
		_hoverSprite = GetComponent<Button>().spriteState.highlightedSprite;
		GetComponent<Button>().onClick.AddListener(RemoveSelection);
	}

	private void Start()
	{
		GetComponent<Image>().sprite = _originalSprite;
		base.transform.Find("Text (TMP)").GetComponent<TMP_Text>().color = _original;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		GetComponent<Image>().sprite = _hoverSprite;
		base.transform.Find("Text (TMP)").GetComponent<TMP_Text>().color = Color.black;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		GetComponent<Image>().sprite = _originalSprite;
		base.transform.Find("Text (TMP)").GetComponent<TMP_Text>().color = _original;
	}

	public void OnDeselect(PointerEventData eventData)
	{
		GetComponent<Image>().sprite = _originalSprite;
		base.transform.Find("Text (TMP)").GetComponent<TMP_Text>().color = _original;
	}

	private void RemoveSelection()
	{
		EventSystem.current.SetSelectedGameObject(null);
	}
}
