using System.Collections.Generic;
using App.Data;
using UnityEngine;

public class TechUIShowController : ActiveComponent
{
	private Dictionary<int, GameObject> techs = new Dictionary<int, GameObject>();

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		Transform[] componentsInChildren = GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.tag == "Tech")
			{
				techs.Add(transform.gameObject.name.GetHashCode(), transform.gameObject);
			}
		}
	}

	public void Redraw()
	{
		foreach (Comics comicse in ActiveComponent._staticData.Comicses)
		{
			if (techs.ContainsKey(comicse.KeyName.GetHashCode()))
			{
				techs[comicse.KeyName.GetHashCode()].gameObject.SetActive(value: false);
			}
		}
		GameObject gameObject = null;
		foreach (Comics comicse2 in ActiveComponent._staticData.Comicses)
		{
			if (!techs.ContainsKey(comicse2.KeyName.GetHashCode()))
			{
				continue;
			}
			if (!QuestLine.IsLoadedInMemory(comicse2.KeyName) || !QuestLine.GetQuest(comicse2.KeyName).IsCompleted())
			{
				if (gameObject != null)
				{
					gameObject.gameObject.SetActive(value: true);
				}
				return;
			}
			gameObject = techs[comicse2.KeyName.GetHashCode()].gameObject;
		}
		gameObject.gameObject.SetActive(value: true);
	}
}
