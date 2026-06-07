using System.Collections.Generic;
using App.Data;
using UnityEngine;
using UnityEngine.UI;

public class CreditsController : ActiveComponent
{
	private List<GameObject> credits = new List<GameObject>();

	private GameObject pref;

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		pref = Resources.Load("Prefabs/CreditObj") as GameObject;
	}

	public void Redraw()
	{
		foreach (GameObject credit in credits)
		{
			Object.Destroy(credit.gameObject);
		}
		credits.Clear();
		foreach (Credit i in ActiveComponent.Model.P.credits)
		{
			GameObject gameObject = Object.Instantiate(pref, base.transform.position, base.transform.rotation);
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			gameObject.GetComponent<Button>().onClick.AddListener(delegate
			{
				ActiveComponent._controller.earlyPayDay.gameObject.SetActive(value: true);
				ActiveComponent._controller.earlyPayDay.Redraw(i);
			});
			gameObject.GetComponent<CreditObjController>().Init();
			gameObject.GetComponent<CreditObjController>().Redraw(i);
			credits.Add(gameObject);
		}
	}
}
