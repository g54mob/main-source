using UnityEngine;

public class CreateFakeCustomBlockForTutorial : ActiveComponent
{
	private GameObject go;

	public string customId;

	protected override void OnInit()
	{
		Redraw(customId);
	}

	public void Redraw(string s)
	{
		if (!(go != null) && QuestLine.IsLoadedInMemory(s))
		{
			SchemeBlock schemeCustomBlockByKeyName = Logic.GetSchemeCustomBlockByKeyName(s);
			if (schemeCustomBlockByKeyName != null)
			{
				GameObject original = Resources.Load("Prefabs/CUSTOM") as GameObject;
				go = Object.Instantiate(original, base.transform.position, base.transform.rotation);
				go.transform.SetParent(base.gameObject.transform);
				go.transform.localPosition = new Vector3(0f, 0f, 0f);
				go.transform.localScale = new Vector3(1f, 1f, 1f);
				go.GetComponent<CustomBlock>().Init(schemeCustomBlockByKeyName, flag: false);
				go.GetComponent<BlockData>().DeActive(disableSockets: true);
				Object.Destroy(go.GetComponent<CustomBlock>());
				Object.Destroy(go.GetComponent<BlockData>());
				base.enabled = false;
			}
		}
	}

	private void Update()
	{
		if (ActiveComponent._staticData != null && ActiveComponent.Model.P != null)
		{
			Redraw(customId);
		}
	}
}
