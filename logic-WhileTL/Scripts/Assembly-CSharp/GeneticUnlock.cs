using System.Collections.Generic;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class GeneticUnlock : ActiveComponent
{
	private class Object
	{
		public int winrate = Random.Range(0, 8);

		public int stage;

		public Object(Object a)
		{
			winrate = a.winrate;
			stage = a.stage;
		}

		public Object()
		{
			winrate = Random.Range(0, 8);
			stage = 0;
		}
	}

	private Button _createProjectButton;

	[SceneBind("ExitButton")]
	private Button exitButton;

	[SceneBind("EvolveBtn")]
	private Button evolveBtn;

	[SceneBind("MultiplyBtn")]
	private Button multiplyBtn;

	[SceneBind("MutateBtn")]
	private Button mutateBtn;

	[SceneBind("EvolveBlock")]
	private Text evolveBlock;

	[SceneBind("MultiplyBlock")]
	private Text multiplyBlock;

	[SceneBind("MutateBlock")]
	private Text mutateBlock;

	[SceneBind("Score")]
	private Text scoreText;

	[SceneBind("HelpText")]
	private Text HelpText;

	private int stage;

	private int score;

	private List<Object> objectList = new List<Object>();

	private List<GameObject> evolveList = new List<GameObject>();

	private List<GameObject> multiplyList = new List<GameObject>();

	private List<GameObject> mutateList = new List<GameObject>();

	private GameObject btnPrefab;

	public Color basic;

	public Color notActive;

	private void OnExitClick()
	{
		ActiveComponent._controller.RedrawUnlockTable();
		base.gameObject.SetActive(value: false);
	}

	private void BlockStage(int i)
	{
		int num = 0;
		foreach (Object @object in objectList)
		{
			num += @object.stage;
		}
		if (num == 4)
		{
			return;
		}
		num = 0;
		if (objectList[i].stage == 0)
		{
			foreach (Object object2 in objectList)
			{
				num += object2.stage;
			}
			if (num >= 2)
			{
				return;
			}
			objectList[i].stage = 1;
		}
		else if (objectList[i].stage == 1)
		{
			objectList[i].stage = 0;
		}
		Redraw();
	}

	public void Redraw()
	{
		foreach (GameObject evolve in evolveList)
		{
			UnityEngine.Object.Destroy(evolve);
		}
		evolveList = new List<GameObject>();
		foreach (GameObject multiply in multiplyList)
		{
			UnityEngine.Object.Destroy(multiply);
		}
		multiplyList = new List<GameObject>();
		foreach (GameObject mutate in mutateList)
		{
			UnityEngine.Object.Destroy(mutate);
		}
		mutateList = new List<GameObject>();
		for (int i = 0; i < objectList.Count; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(btnPrefab, base.transform.position, base.transform.rotation);
			float num = evolveBlock.GetComponent<RectTransform>().rect.width / 4f;
			switch (objectList[i].stage)
			{
			case 0:
			{
				gameObject.transform.parent = evolveBlock.transform;
				Vector3 localPosition = new Vector3(num * (-1.5f + (float)i), 0f, 0f);
				gameObject.transform.localPosition = localPosition;
				evolveList.Add(gameObject);
				break;
			}
			case 1:
			{
				gameObject.transform.parent = multiplyBlock.transform;
				Vector3 localPosition = new Vector3(num * (-1.5f + (float)i), 0f, 0f);
				gameObject.transform.localPosition = localPosition;
				multiplyList.Add(gameObject);
				break;
			}
			case 2:
			{
				gameObject.transform.parent = mutateBlock.transform;
				Vector3 localPosition = new Vector3(num * (-1.5f + (float)i), 0f, 0f);
				gameObject.transform.localPosition = localPosition;
				mutateList.Add(gameObject);
				break;
			}
			}
			gameObject.transform.localScale = new Vector3(0.5f, 1f, 1f);
			int newInstance = i;
			gameObject.GetComponent<Button>().onClick.AddListener(delegate
			{
				BlockStage(newInstance);
			});
			gameObject.GetComponentInChildren<Text>().text = TextResources.GetString("acc") + "\n" + objectList[i].winrate + "%";
		}
		CheckActions();
		scoreText.text = TextResources.GetString("maxacc") + ": " + score + "%";
	}

	public void CheckActions()
	{
		mutateBtn.gameObject.SetActive(value: false);
		multiplyBtn.gameObject.SetActive(value: false);
		evolveBtn.gameObject.SetActive(value: false);
		int num = 0;
		foreach (Object @object in objectList)
		{
			num += @object.stage;
		}
		HelpText.text = TextResources.GetString("seleffmodels");
		if (num < 2)
		{
			foreach (GameObject evolve in evolveList)
			{
				evolve.GetComponentsInChildren<Image>()[1].enabled = false;
			}
			foreach (GameObject multiply in multiplyList)
			{
				multiply.GetComponentsInChildren<Image>()[1].enabled = false;
			}
		}
		if (num == 2)
		{
			multiplyBtn.gameObject.SetActive(value: true);
			HelpText.text = TextResources.GetString("multmodels");
			foreach (GameObject evolve2 in evolveList)
			{
				evolve2.GetComponent<Button>().enabled = false;
				evolve2.GetComponent<ZoomOnMouse>().enabled = false;
				evolve2.GetComponentsInChildren<Image>()[1].enabled = false;
			}
			foreach (GameObject multiply2 in multiplyList)
			{
				multiply2.GetComponent<Button>().enabled = false;
				multiply2.GetComponent<ZoomOnMouse>().enabled = false;
				multiply2.GetComponentsInChildren<Image>()[1].enabled = false;
			}
		}
		if (num == 8)
		{
			evolveBtn.gameObject.SetActive(value: true);
			HelpText.text = TextResources.GetString("evolvemodels");
			foreach (GameObject evolve3 in evolveList)
			{
				evolve3.GetComponent<Button>().enabled = false;
				evolve3.GetComponent<ZoomOnMouse>().enabled = false;
				evolve3.GetComponentsInChildren<Image>()[1].enabled = false;
			}
			foreach (GameObject multiply3 in multiplyList)
			{
				multiply3.GetComponent<Button>().enabled = false;
				multiply3.GetComponent<ZoomOnMouse>().enabled = false;
			}
			foreach (GameObject mutate in mutateList)
			{
				mutate.GetComponent<Button>().enabled = false;
				mutate.GetComponent<ZoomOnMouse>().enabled = false;
			}
		}
		if (num != 4)
		{
			return;
		}
		mutateBtn.gameObject.SetActive(value: true);
		HelpText.text = TextResources.GetString("mutatemodels");
		foreach (GameObject evolve4 in evolveList)
		{
			evolve4.GetComponent<Button>().enabled = false;
			evolve4.GetComponent<ZoomOnMouse>().enabled = false;
		}
		foreach (GameObject multiply4 in multiplyList)
		{
			multiply4.GetComponent<Button>().enabled = false;
			multiply4.GetComponent<ZoomOnMouse>().enabled = false;
		}
		foreach (GameObject mutate2 in mutateList)
		{
			mutate2.GetComponent<Button>().enabled = false;
			mutate2.GetComponent<ZoomOnMouse>().enabled = false;
		}
	}

	private void ClickMutate()
	{
		foreach (Object @object in objectList)
		{
			@object.stage = 2;
			@object.winrate += Random.Range(-5, 10);
		}
		CheckEndGame();
		Redraw();
	}

	private void ClickEvolve()
	{
		foreach (Object @object in objectList)
		{
			@object.stage = 0;
			@object.winrate += Random.Range(-5, 20);
		}
		CheckEndGame();
		Redraw();
	}

	private void CheckEndGame()
	{
		score = -1000;
		foreach (Object @object in objectList)
		{
			if (@object.winrate > score)
			{
				score = @object.winrate;
			}
			if (@object.winrate >= 80)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}

	private void ClickMultiply()
	{
		List<Object> list = new List<Object>();
		foreach (Object @object in objectList)
		{
			if (@object.stage == 1)
			{
				list.Add(@object);
				list.Add(new Object(@object));
			}
		}
		objectList = new List<Object>();
		foreach (Object item in list)
		{
			objectList.Add(item);
		}
		Redraw();
	}

	public void IniGame()
	{
		objectList = new List<Object>();
		for (int i = 0; i < 4; i++)
		{
			objectList.Add(new Object());
		}
		foreach (GameObject evolve in evolveList)
		{
			UnityEngine.Object.Destroy(evolve);
		}
		evolveList = new List<GameObject>();
		foreach (GameObject multiply in multiplyList)
		{
			UnityEngine.Object.Destroy(multiply);
		}
		multiplyList = new List<GameObject>();
		foreach (GameObject mutate in mutateList)
		{
			UnityEngine.Object.Destroy(mutate);
		}
		mutateList = new List<GameObject>();
		CheckEndGame();
		Redraw();
	}

	protected override void OnInit()
	{
		base.OnInit();
		btnPrefab = Resources.Load("Prefabs/GeneticBlock") as GameObject;
		SceneBindContainer.BindObjects(this, base.transform);
		exitButton.onClick.AddListener(OnExitClick);
		stage = 0;
		mutateBtn.onClick.AddListener(ClickMutate);
		multiplyBtn.onClick.AddListener(ClickMultiply);
		evolveBtn.onClick.AddListener(ClickEvolve);
	}
}
