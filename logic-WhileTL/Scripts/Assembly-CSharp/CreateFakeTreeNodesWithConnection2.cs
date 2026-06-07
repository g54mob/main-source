using System.Collections.Generic;
using UnityEngine;

public class CreateFakeTreeNodesWithConnection2 : ActiveComponent
{
	[SceneBind("LinesContentTutorialEd")]
	public RectTransform LinesContent;

	private string[] showTasks = new string[6] { "R/G/B SORT", "ONLY RED FAST1", "R/G/B SORT", "FIRST PERCEPTRON", "ONLY RED FAST1", "ONLY RED FAST1" };

	protected override void OnInit()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		List<GameObject> list = new List<GameObject>();
		List<LevelTreeController> list2 = new List<LevelTreeController>();
		List<TreeChain> list3 = new List<TreeChain>();
		GameObject original = Resources.Load("Prefabs/LevelTreeObject") as GameObject;
		for (int i = 0; i < 6; i++)
		{
			list.Add(base.transform.Find("NodeConEd" + i).gameObject);
			GameObject obj = Object.Instantiate(original);
			obj.transform.SetParent(list[i].transform);
			obj.transform.localPosition = new Vector3(0f, 0f, 0f);
			obj.transform.localScale = new Vector3(1f, 1f, 1f);
			LevelTreeController component = obj.GetComponent<LevelTreeController>();
			list2.Add(component);
			component.Init();
			component.InitFake(Logic.GetTaskByKeyName(showTasks[i]));
		}
		GameObject original2 = Resources.Load("Prefabs/TreeChain") as GameObject;
		for (int j = 0; j < 5; j++)
		{
			GameObject obj2 = Object.Instantiate(original2);
			obj2.transform.SetParent(LinesContent.transform);
			TreeChain component2 = obj2.GetComponent<TreeChain>();
			component2.Init();
			list3.Add(component2);
		}
		list3[0].SetEnds(list2[0].gameObject, list2[1].gameObject, fake: true);
		list3[1].SetEnds(list2[0].gameObject, list2[2].gameObject, fake: true);
		list3[2].SetEnds(list2[2].gameObject, list2[3].gameObject, fake: true);
		list3[3].SetEnds(list2[1].gameObject, list2[4].gameObject, fake: true);
		list3[4].SetEnds(list2[1].gameObject, list2[5].gameObject, fake: true);
	}
}
