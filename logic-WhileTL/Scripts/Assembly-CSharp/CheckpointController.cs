using App.Data;
using Localization;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckpointController : ActiveComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public bool hover;

	[SceneBind("Name")]
	public Text Name;

	[SceneBind("Task")]
	public Text Task;

	[SceneBind("Hover")]
	public Image Hover;

	public void OnPointerEnter(PointerEventData eventData)
	{
		Hover.gameObject.SetActive(value: true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Hover.gameObject.SetActive(value: false);
	}

	public void Init(Checkpoint ch)
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		if (ch == null)
		{
			Name.gameObject.SetActive(value: false);
			Task.gameObject.SetActive(value: false);
		}
		else
		{
			Name.text = Logic.ColorTransform("GOOD", TextResources.GetString(ch.KeyName));
			Task.text = TextResources.GetString("TASK #");
			Hover.gameObject.SetActive(value: false);
		}
	}
}
