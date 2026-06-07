using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialList : ActiveComponent
{
	private List<GameObject> tutorialsWindow = new List<GameObject>();

	private List<GameObject> POIs = new List<GameObject>();

	private int id;

	private int activePOI;

	private List<GameObject> btns = new List<GameObject>();

	public Button GetActiveBtn()
	{
		foreach (GameObject btn in btns)
		{
			if (btn.gameObject.activeSelf)
			{
				return btn.gameObject.GetComponent<Button>();
			}
		}
		return null;
	}

	private void InitActiveComponent()
	{
		Transform[] componentsInChildren = base.transform.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.tag == "ActiveComponent" && transform != base.transform)
			{
				transform.GetComponent<ActiveComponent>().Init();
			}
		}
		ReactivePOI();
	}

	public Vector3 GetClickPosition()
	{
		foreach (GameObject btn in btns)
		{
			if (btn.gameObject.activeInHierarchy)
			{
				return btn.transform.position;
			}
		}
		return Vector3.zero;
	}

	private void ReactivePOI()
	{
		POIs = new List<GameObject>();
		for (int i = 0; i < 4; i++)
		{
			Transform transform = tutorialsWindow[id].gameObject.transform.Find("POI" + i);
			if (transform != null)
			{
				POIs.Add(transform.gameObject);
			}
		}
		for (int j = 0; j < POIs.Count; j++)
		{
			if (POIs[j] != null)
			{
				POIs[j].gameObject.SetActive(activePOI == j);
			}
		}
	}

	public void SetActivePOI(int id)
	{
		activePOI = id;
		POIs = new List<GameObject>();
	}

	public void NextClick()
	{
		tutorialsWindow[id].gameObject.SetActive(value: false);
		id++;
		if (id >= tutorialsWindow.Count)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		tutorialsWindow[id].gameObject.SetActive(value: true);
		InitActiveComponent();
	}

	public void ForceQuit()
	{
		id = tutorialsWindow.Count;
	}

	public IEnumerator WaitForUserAction()
	{
		while (id < tutorialsWindow.Count)
		{
			yield return new WaitForEndOfFrame();
		}
		base.gameObject.SetActive(value: false);
	}

	public void Redraw()
	{
		id = 0;
		foreach (GameObject item in tutorialsWindow)
		{
			item.gameObject.SetActive(value: false);
		}
		tutorialsWindow[0].gameObject.SetActive(value: true);
		InitActiveComponent();
	}

	protected override void OnInit()
	{
		Transform[] componentsInChildren = base.transform.GetComponentsInChildren<Transform>();
		btns.Clear();
		bool[] array = new bool[componentsInChildren.Length];
		int num = -1;
		Transform[] array2 = componentsInChildren;
		foreach (Transform transform in array2)
		{
			if (transform != null && transform.gameObject != null)
			{
				array[++num] = transform.gameObject.activeSelf;
				transform.gameObject.SetActive(value: true);
				if (transform.tag == "TutorialWindow")
				{
					GameObject gameObject = transform.gameObject;
					tutorialsWindow.Add(gameObject);
					Button componentInChildren = gameObject.GetComponentInChildren<Button>();
					componentInChildren.onClick.AddListener(NextClick);
					btns.Add(componentInChildren.gameObject);
				}
			}
		}
		for (num = 0; num < componentsInChildren.Length; num++)
		{
			componentsInChildren[num].gameObject.SetActive(array[num]);
		}
		id = 0;
		foreach (GameObject item in tutorialsWindow)
		{
			item.gameObject.SetActive(value: false);
		}
		if (tutorialsWindow.Count > 0)
		{
			tutorialsWindow[0].gameObject.SetActive(value: true);
		}
		else
		{
			Debug.LogError("Tutorial pages for " + base.gameObject.name + " aren't exist");
		}
		base.gameObject.SetActive(value: false);
	}
}
