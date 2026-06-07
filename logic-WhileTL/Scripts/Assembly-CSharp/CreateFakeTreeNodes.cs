using System.Collections.Generic;
using UnityEngine;

public class CreateFakeTreeNodes : ActiveComponent
{
	private string[] showTasks = new string[4] { "R/B DIVIDE", "R/G/B SORT", "FIRST PERCEPTRON", "R/R PARALLEL" };

	protected override void OnInit()
	{
		List<GameObject> list = new List<GameObject>();
		GameObject original = Resources.Load("Prefabs/LevelTreeObject") as GameObject;
		for (int i = 0; i < 4; i++)
		{
			list.Add(GameObject.Find("Node" + i));
			GameObject obj = Object.Instantiate(original);
			obj.transform.SetParent(list[i].transform);
			obj.transform.localPosition = new Vector3(0f, 0f, 0f);
			obj.transform.localScale = new Vector3(1f, 1f, 1f);
			LevelTreeController component = obj.GetComponent<LevelTreeController>();
			component.Init();
			component.InitFake(Logic.GetTaskByKeyName(showTasks[i]));
		}
	}
}
