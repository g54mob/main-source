using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class IfShape : BaseBlock
{
	private Socket socketIn;

	private Socket socketTop;

	private Socket socketBot;

	[SceneBind("ParamTop")]
	public Dropdown top;

	[SceneBind("ParamBot")]
	public Dropdown bot;

	private List<Dropdown.OptionData> optionsTop = new List<Dropdown.OptionData>();

	private List<Dropdown.OptionData> optionsBot = new List<Dropdown.OptionData>();

	public Sprite CircleImage;

	public Sprite SquareImage;

	public Sprite TriangleImage;

	private bool topOpen;

	private bool topClosing;

	private int normalTop;

	protected override bool TryActive()
	{
		if (socketIn.queue.Count == 0)
		{
			return false;
		}
		Element element = socketIn.queue[0];
		if (top.value == element.ShapeId)
		{
			return !socketsOut[1].isFull();
		}
		return !socketsOut[3].isFull();
	}

	protected override void Active()
	{
		if (!TryActive())
		{
			return;
		}
		Element element = socketIn.GetElement();
		if (element != null)
		{
			if (top.value == element.ShapeId)
			{
				socketsOut[1].SetElement(element);
			}
			else
			{
				socketsOut[3].SetElement(element);
			}
		}
	}

	public override void Init()
	{
		if (!base.IsInited)
		{
			base.Init();
			SceneBindContainer.BindObjects(this, base.transform);
			normalTop = top.transform.childCount;
			keyName = "IFSHAPE";
			socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
			socketTop = base.transform.Find("SocketTop").GetComponent<Socket>();
			socketBot = base.transform.Find("SocketBot").GetComponent<Socket>();
		}
		if (top.transform.childCount != normalTop)
		{
			Object.Destroy(top.transform.GetChild(top.transform.childCount - 1).gameObject);
		}
		Speed.text = Logic.ColorTransform("TIME", Logic.GetWorkTimeByKeyName(keyName) + " " + TextResources.GetString("SEC"));
		optionsTop.Clear();
		for (int i = 0; i < 3; i++)
		{
			optionsTop.Add(new Dropdown.OptionData(""));
		}
		top.onValueChanged.RemoveAllListeners();
		top.ClearOptions();
		top.AddOptions(optionsTop);
		top.enabled = true;
		hasDropdown = true;
		socketsIn[2] = socketIn;
		socketsOut[1] = socketTop;
		socketsOut[3] = socketBot;
		for (int j = 0; j < BaseBlock.maxSockets; j++)
		{
			if (socketsIn[j] != null)
			{
				socketsIn[j].num = j;
			}
			if (socketsOut[j] != null)
			{
				socketsOut[j].num = j;
			}
		}
		top.value = 0;
		if (base.gameObject.GetComponent<BlockData>().sh != null)
		{
			SchemeBlock sh = base.gameObject.GetComponent<BlockData>().sh;
			top.value = sh.outConditionsShape[1];
		}
		AddRecordToEvent(top.onValueChanged);
		delayTimer = Logic.GetWorkTimeByKeyName(keyName);
		ChangeSprites();
		ListenCloseDropdown(top, normalTop);
		top.onValueChanged.AddListener(delegate
		{
			ChangeSprites();
		});
	}

	private void ChangeSprites()
	{
		Toggle[] componentsInChildren = base.gameObject.GetComponentsInChildren<Toggle>();
		if (componentsInChildren.Length != 0)
		{
			Transform[] componentsInChildren2 = componentsInChildren[0].gameObject.GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren2)
			{
				if (transform.tag == "Second")
				{
					transform.gameObject.GetComponent<Image>().sprite = CircleImage;
				}
				else if (transform.tag == "First" || transform.tag == "Third")
				{
					transform.gameObject.SetActive(value: false);
				}
			}
			componentsInChildren2 = componentsInChildren[1].gameObject.GetComponentsInChildren<Transform>();
			foreach (Transform transform2 in componentsInChildren2)
			{
				if (transform2.tag == "Second")
				{
					transform2.gameObject.GetComponent<Image>().sprite = SquareImage;
				}
				else if (transform2.tag == "First" || transform2.tag == "Third")
				{
					transform2.gameObject.SetActive(value: false);
				}
			}
			componentsInChildren2 = componentsInChildren[2].gameObject.GetComponentsInChildren<Transform>();
			foreach (Transform transform3 in componentsInChildren2)
			{
				if (transform3.tag == "Second")
				{
					transform3.gameObject.GetComponent<Image>().sprite = TriangleImage;
				}
				else if (transform3.tag == "First" || transform3.tag == "Third")
				{
					transform3.gameObject.SetActive(value: false);
				}
			}
		}
		GameObject gameObject = top.gameObject.transform.Find("First").gameObject;
		GameObject gameObject2 = top.gameObject.transform.Find("Second").gameObject;
		GameObject gameObject3 = top.gameObject.transform.Find("Third").gameObject;
		if (top.value != 3)
		{
			gameObject.gameObject.SetActive(value: false);
			gameObject3.gameObject.SetActive(value: false);
			switch (top.value)
			{
			case 0:
				gameObject2.GetComponent<Image>().sprite = CircleImage;
				break;
			case 1:
				gameObject2.GetComponent<Image>().sprite = SquareImage;
				break;
			case 2:
				gameObject2.GetComponent<Image>().sprite = TriangleImage;
				break;
			}
		}
		else
		{
			gameObject.gameObject.SetActive(value: true);
			gameObject3.gameObject.SetActive(value: true);
			gameObject2.GetComponent<Image>().sprite = SquareImage;
		}
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();
		if (!ActiveComponent.Model.construction.testMode)
		{
			if (top.transform.childCount != normalTop)
			{
				ChangeSprites();
			}
			if (Logic.UpdateCursorCanvasStatus(ref topOpen, ref topClosing, top, normalTop))
			{
				ChangeSprites();
			}
		}
	}
}
