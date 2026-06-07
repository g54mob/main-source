using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Newspaper : ActiveComponent
{
	[SceneBind("Ok")]
	private Button Ok;

	private List<GameObject> news = new List<GameObject>();

	public UnityEvent closeNews = new UnityEvent();

	private void OkClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		CloseNewspaper();
	}

	public void CloseNewspaper()
	{
		Logic.UpdateGameSaves();
		ActiveComponent._controller.construction.WaitTutorial = false;
		closeNews.Invoke();
		base.gameObject.SetActive(value: false);
		ActiveComponent._controller.construction.RunAllTutorials();
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		Ok.onClick.AddListener(OkClick);
		news.Clear();
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.tag == "Newspaper")
			{
				news.Add(transform.gameObject);
			}
		}
	}

	public bool hasNewspaper(string KeyName)
	{
		foreach (GameObject item in news)
		{
			if (item.name == KeyName)
			{
				return true;
			}
		}
		return false;
	}

	public void Redraw(string KeyName)
	{
		ActiveComponent._controller.construction.WaitTutorial = true;
		foreach (GameObject item in news)
		{
			item.SetActive(value: false);
		}
		foreach (GameObject item2 in news)
		{
			if (item2.name == KeyName)
			{
				item2.SetActive(value: true);
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Newspaper");
				ActiveComponent.Program.cursor.SetPosition(Ok.transform.position);
				return;
			}
		}
		base.gameObject.SetActive(value: false);
		ActiveComponent._controller.construction.WaitTutorial = false;
	}

	private void Update()
	{
		if (ActiveComponent.Model != null && base.gameObject.activeSelf && base.IsInited)
		{
			QuestLine.GetCurrentQuest().newspaperTime += Time.unscaledDeltaTime;
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			OkClick();
		}
	}
}
