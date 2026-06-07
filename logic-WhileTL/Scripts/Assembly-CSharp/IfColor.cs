using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class IfColor : BaseBlock
{
	private Socket socketIn;

	private Socket socketTop;

	private Socket socketBot;

	[SceneBind("ParamTop")]
	public Dropdown top;

	[SceneBind("ParamTop/DropdownGlow")]
	public Image glow;

	[SceneBind("ParamTop/Arrow")]
	public Image arrow;

	private List<Dropdown.OptionData> optionsTop = new List<Dropdown.OptionData>();

	private List<Dropdown.OptionData> optionsBot = new List<Dropdown.OptionData>();

	public bool disableGlow = true;

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
		if (top.value == element.ColorId)
		{
			return !socketTop.isFull();
		}
		return !socketBot.isFull();
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
			if (top.value == element.ColorId)
			{
				socketTop.SetElement(element);
			}
			else
			{
				socketBot.SetElement(element);
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
			keyName = "IFCOLOR";
			socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
			socketTop = base.transform.Find("SocketTop").GetComponent<Socket>();
			socketBot = base.transform.Find("SocketBot").GetComponent<Socket>();
		}
		if (top.transform.childCount != normalTop)
		{
			Object.Destroy(top.transform.GetChild(top.transform.childCount - 1).gameObject);
		}
		disableGlow = QuestLine.GetCurrentQuest().GetName() != ActiveComponent._staticData.Settings.DropdownTrigger;
		if (ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial))
		{
			disableGlow = true;
		}
		if (ActiveComponent.Model.construction.schemeStack.Top().keyName != "EXPERT_LEARN" || base.gameObject.GetComponent<BlockData>().dummy)
		{
			OpacitySin componentInChildren = socketIn.GetComponentInChildren<OpacitySin>();
			if (componentInChildren != null)
			{
				Object.Destroy(componentInChildren.gameObject);
			}
			componentInChildren = socketTop.GetComponentInChildren<OpacitySin>();
			if (componentInChildren != null)
			{
				Object.Destroy(componentInChildren.gameObject);
			}
			componentInChildren = socketBot.GetComponentInChildren<OpacitySin>();
			if (componentInChildren != null)
			{
				Object.Destroy(componentInChildren.gameObject);
			}
		}
		Speed.text = Logic.ColorTransform("TIME", Logic.GetWorkTimeByKeyName(keyName) + " " + TextResources.GetString("SEC"));
		optionsTop.Clear();
		for (int i = 0; i < ActiveComponent._staticData.LogicsColor.Count - 1; i++)
		{
			optionsTop.Add(new Dropdown.OptionData(TextResources.GetString(ActiveComponent._staticData.LogicsColor[i].Name)));
		}
		top.ClearOptions();
		top.AddOptions(optionsTop);
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
		top.onValueChanged.RemoveAllListeners();
		top.enabled = true;
		top.value = 0;
		if (base.gameObject.GetComponent<BlockData>().sh != null)
		{
			SchemeBlock sh = base.gameObject.GetComponent<BlockData>().sh;
			top.value = sh.outConditionsColor[1];
		}
		AddRecordToEvent(top.onValueChanged);
		ListenCloseDropdown(top, normalTop);
		top.onValueChanged.AddListener(delegate
		{
			ChangeColors();
		});
		delayTimer = Logic.GetWorkTimeByKeyName(keyName);
		ChangeColors();
		if (QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.ForumQuests[0].KeyName)
		{
			top.enabled = false;
			arrow.gameObject.SetActive(value: false);
		}
	}

	private void ChangeColors()
	{
		Text[] componentsInChildren = top.GetComponentsInChildren<Text>();
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].color = Logic.GetColor(i - 1);
		}
		top.captionText.color = Logic.GetColor(top.value);
		if (top.value == 0)
		{
			glow.gameObject.SetActive(!disableGlow);
		}
		else
		{
			glow.gameObject.SetActive(value: false);
		}
		Transform[] componentsInChildren2 = top.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren2)
		{
			if (transform.gameObject.GetComponent<Image>() != null && transform.gameObject.tag == "Checkmark")
			{
				transform.gameObject.GetComponent<Image>().color = Logic.GetColor(top.value);
			}
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
			if (Logic.UpdateCursorCanvasStatus(ref topOpen, ref topClosing, top, normalTop))
			{
				ChangeColors();
			}
		}
	}
}
