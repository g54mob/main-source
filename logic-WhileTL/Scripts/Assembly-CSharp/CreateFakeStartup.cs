using UnityEngine;

public class CreateFakeStartup : ActiveComponent
{
	private GameObject go;

	protected override void OnInit()
	{
		if (go != null)
		{
			Object.Destroy(go);
		}
		GameObject original = Resources.Load("Prefabs/StartupBlock") as GameObject;
		go = Object.Instantiate(original);
		go.transform.SetParent(base.transform);
		go.transform.localPosition = new Vector3(0f, 0f, 0f);
		go.transform.localScale = new Vector3(1f, 1f, 1f);
		go.GetComponent<StartupControl>().InitFake();
	}
}
