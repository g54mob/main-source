using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class CreateDynamicScrollSnap : MonoBehaviour
{
	[SerializeField]
	private GameObject ScrollSnapPrefab;

	private HorizontalScrollSnap hss;

	[SerializeField]
	private GameObject ScrollSnapContent;

	[SerializeField]
	private int startingPage;

	private bool isInitialized;

	private void Start()
	{
		hss = Object.Instantiate(ScrollSnapPrefab, base.transform).GetComponent<HorizontalScrollSnap>();
		hss.ChangePage(0);
	}

	private void Update()
	{
		if (!isInitialized && hss != null && Input.GetKeyDown(KeyCode.K))
		{
			AddHSSChildren();
			isInitialized = true;
		}
	}

	private void AddHSSChildren()
	{
		if (hss.transform.Find("Content") != null)
		{
			for (int i = 0; i < 10; i++)
			{
				GameObject gameObject = Object.Instantiate(ScrollSnapContent);
				SetHSSItemTest(gameObject, $"Page {i}");
				hss.AddChild(gameObject);
			}
			hss.StartingScreen = startingPage;
			hss.UpdateLayout(resetPositionToStart: true);
		}
		else
		{
			Debug.LogError("Content not found");
		}
	}

	private void SetHSSItemTest(GameObject prefab, string value)
	{
		prefab.gameObject.name = value;
		prefab.GetComponentInChildren<Text>().text = value;
	}
}
