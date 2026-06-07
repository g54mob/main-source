using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class IsolationForest : BaseBlock
{
	private Socket socketIn;

	private Socket socketTop;

	private Socket socketMid;

	[SceneBind("ParamTop")]
	public Dropdown top;

	[SceneBind("ParamMid")]
	public Dropdown mid;

	private List<Dropdown.OptionData> optionsTop = new List<Dropdown.OptionData>();

	private List<Dropdown.OptionData> optionsMid = new List<Dropdown.OptionData>();

	public Sprite CircleImage;

	public Sprite SquareImage;

	public Sprite TriangleImage;

	private bool topOpen;

	private bool midOpen;

	private bool topClosing;

	private bool midClosing;

	private int normalMid;

	private int normalTop;

	protected override bool TryActive()
	{
		if (socketIn.queue.Count == 0)
		{
			return false;
		}
		Element element = socketIn.queue[0];
		bool flag = false;
		bool flag2 = false;
		if (top.value == element.ColorId && mid.value == element.ShapeId && element.revealed)
		{
			flag = true;
		}
		else
		{
			flag2 = true;
		}
		if (flag && socketTop.isFull())
		{
			return false;
		}
		if (flag2 && socketMid.isFull())
		{
			return false;
		}
		return true;
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
			bool flag = false;
			bool flag2 = false;
			if (top.value == element.ColorId && mid.value == element.ShapeId && element.revealed)
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
			if (flag)
			{
				socketTop.SetElement(element);
			}
			if (flag2)
			{
				socketMid.SetElement(element);
			}
		}
	}

	public override void Init()
	{
		if (!base.IsInited)
		{
			base.Init();
			socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
			socketTop = base.transform.Find("SocketTop").GetComponent<Socket>();
			socketMid = base.transform.Find("SocketMid").GetComponent<Socket>();
			keyName = "ISOFOREST";
			normalTop = top.transform.childCount;
			normalMid = mid.transform.childCount;
		}
		if (top.transform.childCount != normalTop)
		{
			Object.Destroy(top.transform.GetChild(top.transform.childCount - 1).gameObject);
		}
		if (mid.transform.childCount != normalMid)
		{
			Object.Destroy(mid.transform.GetChild(mid.transform.childCount - 1).gameObject);
		}
		Speed.text = Logic.ColorTransform("TIME", Logic.GetWorkTimeByKeyName(keyName) + " " + TextResources.GetString("SEC"));
		optionsMid.Clear();
		optionsTop.Clear();
		for (int i = 0; i < ActiveComponent._staticData.LogicsColor.Count - 1; i++)
		{
			optionsTop.Add(new Dropdown.OptionData(TextResources.GetString(ActiveComponent._staticData.LogicsColor[i].Name)));
		}
		optionsMid.Add(new Dropdown.OptionData(CircleImage));
		optionsMid.Add(new Dropdown.OptionData(SquareImage));
		optionsMid.Add(new Dropdown.OptionData(TriangleImage));
		top.onValueChanged.RemoveAllListeners();
		mid.onValueChanged.RemoveAllListeners();
		top.ClearOptions();
		mid.ClearOptions();
		top.AddOptions(optionsTop);
		mid.AddOptions(optionsMid);
		hasDropdown = true;
		socketsIn[2] = socketIn;
		socketsOut[1] = socketTop;
		socketsOut[3] = socketMid;
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
		top.enabled = true;
		mid.enabled = true;
		top.value = 0;
		mid.value = 0;
		if (base.gameObject.GetComponent<BlockData>().sh != null)
		{
			SchemeBlock sh = base.gameObject.GetComponent<BlockData>().sh;
			top.value = sh.outConditionsColor[0];
			mid.value = sh.outConditionsColor[1];
		}
		AddRecordToEvent(top.onValueChanged);
		AddRecordToEvent(mid.onValueChanged);
		delayTimer = Logic.GetWorkTimeByKeyName(keyName);
		ChangeColors();
		ChangeSprites();
		ListenCloseDropdown(top, normalTop);
		ListenCloseDropdown(mid, normalMid);
		top.onValueChanged.AddListener(delegate
		{
			ChangeColors();
		});
		mid.onValueChanged.AddListener(delegate
		{
			ChangeSprites();
		});
	}

	public void ChangeColors()
	{
		Text[] componentsInChildren = top.GetComponentsInChildren<Text>();
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].color = Logic.GetColor(i - 1);
		}
		top.captionText.color = Logic.GetColor(top.value);
		Transform[] componentsInChildren2 = top.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren2)
		{
			if (transform.gameObject.GetComponent<Image>() != null && transform.gameObject.tag == "Checkmark")
			{
				transform.gameObject.GetComponent<Image>().color = Logic.GetColor(Mathf.Min(top.value, 3));
			}
		}
	}

	public void ChangeSprites()
	{
		GameObject gameObject = mid.gameObject.transform.Find("Second").gameObject;
		gameObject.gameObject.SetActive(value: true);
		switch (mid.value % 3)
		{
		case 0:
			gameObject.GetComponent<Image>().sprite = CircleImage;
			break;
		case 1:
			gameObject.GetComponent<Image>().sprite = SquareImage;
			break;
		case 2:
			gameObject.GetComponent<Image>().sprite = TriangleImage;
			break;
		}
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();
		if (!ActiveComponent.Model.construction.testMode)
		{
			if (top.transform.childCount != normalTop)
			{
				ChangeColors();
			}
			if (mid.transform.childCount != normalMid)
			{
				ChangeSprites();
			}
			if (Logic.UpdateCursorCanvasStatus(ref topOpen, ref topClosing, top, normalTop))
			{
				ChangeColors();
			}
			if (Logic.UpdateCursorCanvasStatus(ref midOpen, ref midClosing, mid, normalMid))
			{
				ChangeSprites();
			}
		}
	}
}
