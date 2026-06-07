using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TaskController : ActiveComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public bool hover;

	[SceneBind("Name")]
	public Text Name;

	[SceneBind("Task")]
	public Text Task;

	[SceneBind("ReadBtn")]
	public Button Read;

	[SceneBind("Hover")]
	public Image Hover;

	[SceneBind("Money")]
	public Text Money;

	[SceneBind("Acc")]
	public Text Acc;

	[SceneBind("Speed")]
	public Text Speed;

	[SceneBind("Time")]
	public Text Time;

	[SceneBind("EditBtn")]
	public Button Edit;

	[SceneBind("ContinueBtn")]
	public Button Continue;

	[SceneBind("Medal")]
	public Image Medal;

	private List<Sprite> medalSprites = new List<Sprite>();

	public void OnPointerEnter(PointerEventData eventData)
	{
		Hover.gameObject.SetActive(value: true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Hover.gameObject.SetActive(value: false);
	}

	public void Init(QuestLine.Quest cq, int id)
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		medalSprites.Add(Logic.LoadSprite("EMPTY_MEDAL"));
		medalSprites.Add(Logic.LoadSprite("BRONZE"));
		medalSprites.Add(Logic.LoadSprite("SILVER"));
		medalSprites.Add(Logic.LoadSprite("GOLD"));
		Task.text = "#" + id;
		BaseGameQuest obj = (BaseGameQuest)cq.quest;
		Name.text = TextResources.GetString(cq.GetTexts() + "T");
		Edit.gameObject.SetActive(value: false);
		Continue.gameObject.SetActive(value: false);
		if (cq.IsTaskOpened())
		{
			Edit.gameObject.SetActive(value: false);
			Continue.gameObject.SetActive(value: true);
		}
		if (cq.IsCompleted())
		{
			Edit.gameObject.SetActive(value: true);
			Continue.gameObject.SetActive(value: false);
		}
		Hover.gameObject.SetActive(value: false);
		obj.InitTaskController(this);
		Medal.sprite = medalSprites[cq.GetScore()];
	}
}
