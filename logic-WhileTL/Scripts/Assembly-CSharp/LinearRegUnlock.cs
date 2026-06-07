using System.Collections.Generic;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class LinearRegUnlock : ActiveComponent
{
	private class Point
	{
		public float x;

		public float y;

		public bool flag;

		public GameObject obj;

		public float targetAngle;

		public Point(float vx, float vy, bool group, GameObject parent)
		{
			flag = group;
			x = vx;
			y = vy;
			obj = Object.Instantiate(pointObj, parent.transform.position, parent.transform.rotation);
			obj.transform.parent = parent.transform;
			Rect rect = parent.GetComponent<RectTransform>().rect;
			if (group)
			{
				obj.GetComponentInChildren<Text>().text = "1";
				obj.transform.localPosition = new Vector3(rect.width * vx - rect.width / 2f, rect.height * Random.Range(0f, vx) - rect.height / 2f, 0f);
				obj.GetComponentsInChildren<Image>()[1].gameObject.SetActive(value: false);
			}
			else
			{
				obj.GetComponentInChildren<Text>().text = "2";
				obj.transform.localPosition = new Vector3(rect.width * vx - rect.width / 2f, rect.height * Random.Range(vx, 1f) - rect.height / 2f, 0f);
				obj.GetComponentsInChildren<Image>()[2].gameObject.SetActive(value: false);
			}
			if (Random.Range(0f, 1f) < 0.1f)
			{
				obj.transform.localPosition = new Vector3(rect.width * vx - rect.width / 2f, rect.height * vy - rect.height / 2f, 0f);
			}
		}
	}

	[SceneBind("ExitButton")]
	private Button exitButton;

	private int score;

	[SceneBind("Up")]
	private Button upButton;

	[SceneBind("Down")]
	private Button downButton;

	[SceneBind("Done")]
	private Button doneButton;

	[SceneBind("Image")]
	private Image image;

	[SceneBind("HelpText")]
	private Text helpText;

	private GameObject line;

	private float angle;

	private GameObject playPrefab;

	private List<GameObject> blocks = new List<GameObject>();

	private static GameObject pointObj;

	private List<Point> points = new List<Point>();

	private int findValue;

	private void OnExitClick()
	{
		ActiveComponent._controller.RedrawUnlockTable();
		IniGame();
		base.gameObject.SetActive(value: false);
	}

	private void Redraw()
	{
	}

	private void DownClick()
	{
		angle -= 5f;
		angle = Mathf.Max(-90f, angle);
		RotateLine();
	}

	private void UpClick()
	{
		angle += 5f;
		angle = Mathf.Min(0f, angle);
		RotateLine();
	}

	private void DoneButton()
	{
		if (Mathf.Abs(line.transform.eulerAngles.z - 45f - 270f) < 10f)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			helpText.text = TextResources.GetString("lowacc");
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		exitButton.onClick.AddListener(OnExitClick);
		upButton.onClick.AddListener(UpClick);
		downButton.onClick.AddListener(DownClick);
		doneButton.onClick.AddListener(DoneButton);
		line = GameObject.Find("LinearRotate");
		pointObj = Resources.Load("Prefabs/Point") as GameObject;
		IniGame();
		helpText.text = TextResources.GetString("findline");
	}

	private void RotateLine()
	{
		Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
		line.transform.rotation = rotation;
		Debug.Log(line.transform.eulerAngles.z + " " + Mathf.Abs(line.transform.eulerAngles.z - 45f - 270f) / 45f);
		line.GetComponentInChildren<Image>().color = Color.red * Mathf.Abs(line.transform.eulerAngles.z - 45f - 270f) / 45f + Color.green * (1f - Mathf.Abs(line.transform.eulerAngles.z - 45f - 270f) / 45f);
	}

	public void IniGame()
	{
		foreach (Point point in points)
		{
			Object.Destroy(point.obj);
		}
		points = new List<Point>();
		for (int i = 0; i < 10; i++)
		{
			points.Add(new Point(Random.Range(0f, 1f), Random.Range(0f, 1f), group: true, image.gameObject));
		}
		for (int j = 0; j < 10; j++)
		{
			points.Add(new Point(Random.Range(0f, 1f), Random.Range(0f, 1f), group: false, image.gameObject));
		}
		angle = 0f;
		RotateLine();
		Redraw();
	}

	private void CheckEnd()
	{
	}

	private void Update()
	{
	}
}
