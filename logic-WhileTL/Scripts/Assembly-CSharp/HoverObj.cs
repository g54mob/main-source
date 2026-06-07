using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverObj : ActiveComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SceneBind("Hover")]
	public Image Hover;

	public bool hover;

	public void OnPointerEnter(PointerEventData eventData)
	{
		Hover.gameObject.SetActive(value: true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Hover.gameObject.SetActive(value: false);
	}

	private void Start()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		Hover.gameObject.SetActive(value: false);
	}
}
