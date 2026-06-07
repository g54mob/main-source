using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HyperlinkTxt : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	private TextMeshProUGUI _txt;

	private void Awake()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}
}
