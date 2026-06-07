using System.Collections.Generic;
using UnityEngine;

public class StartupTutorialGlowHelper : ActiveComponent
{
	private List<GameObject> startupGlows = new List<GameObject>();

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		for (int i = 0; i < 4; i++)
		{
			Transform transform = base.transform.Find("POI" + i);
			if (transform != null)
			{
				startupGlows.Add(transform.gameObject);
			}
		}
	}

	public void Redraw()
	{
		if (!base.IsInited)
		{
			Init();
		}
		int num = ActiveComponent.Model.P.Startups.FindIndex((StartupScheme st) => st.released == 1);
		if (num >= 0)
		{
			startupGlows.ForEach(delegate(GameObject st)
			{
				st.gameObject.SetActive(value: false);
			});
			startupGlows[num].gameObject.SetActive(value: true);
		}
	}
}
