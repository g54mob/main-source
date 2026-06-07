using System.Collections.Generic;
using UnityEngine;

public class CreateFakeTreeNodesWithConnection : ActiveComponent
{
	[SceneBind("LinesContentTutorial")]
	public RectTransform LinesContent;

	private string[] showTasks = new string[2] { "G/B DIVIDE", "FIRST PERCEPTRON" };

	protected override void OnInit()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		List<GameObject> list = new List<GameObject>();
		List<LevelTreeController> list2 = new List<LevelTreeController>();
		GameObject original = Resources.Load("Prefabs/LevelTreeObject") as GameObject;
		for (int i = 0; i < 2; i++)
		{
			list.Add(base.transform.Find("NodeCon" + i).gameObject);
			GameObject obj = Object.Instantiate(original);
			obj.transform.SetParent(list[i].transform);
			obj.transform.localPosition = new Vector3(0f, 0f, 0f);
			obj.transform.localScale = new Vector3(1f, 1f, 1f);
			LevelTreeController component = obj.GetComponent<LevelTreeController>();
			list2.Add(component);
			component.Init();
			component.InitFake(Logic.GetTaskByKeyName(showTasks[i]));
		}
		GameObject obj2 = Object.Instantiate(Resources.Load("Prefabs/TreeChain") as GameObject);
		obj2.transform.SetParent(LinesContent.transform);
		TreeChain component2 = obj2.GetComponent<TreeChain>();
		component2.Init();
		component2.SetEnds(list2[0].gameObject, list2[1].gameObject, fake: true);
	}
}
