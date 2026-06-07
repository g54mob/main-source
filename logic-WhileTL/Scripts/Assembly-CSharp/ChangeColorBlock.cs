using System.Collections.Generic;
using App.Data;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorBlock : ActiveComponent
{
	private Socket socketIn;

	private Socket socketOut;

	[SceneBind("ColorIn")]
	public Dropdown colorIn;

	[SceneBind("ColorOut")]
	public Dropdown colorOut;

	private string inColor;

	private string outColor;

	private float timer;

	private float delayTimer;

	private float lastActiveTime;

	public List<Socket> socketsIn = new List<Socket>();

	public List<Socket> socketsOut = new List<Socket>();

	private List<Dropdown.OptionData> optionsIn = new List<Dropdown.OptionData>();

	private List<Dropdown.OptionData> optionsOut = new List<Dropdown.OptionData>();

	private void Active()
	{
		Element element = socketIn.GetElement();
		if (element != null)
		{
			if (colorIn.value == element.ColorId)
			{
				element.ColorId = colorOut.value;
			}
			socketOut.SetElement(element);
		}
	}

	private void Start()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		inColor = "";
		outColor = "";
		socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
		socketOut = base.transform.Find("SocketOut").GetComponent<Socket>();
		for (int i = 0; i < ActiveComponent._staticData.Colors.Count; i++)
		{
			optionsIn.Add(new Dropdown.OptionData(ActiveComponent._staticData.Colors[i].Name));
			optionsOut.Add(new Dropdown.OptionData(ActiveComponent._staticData.Colors[i].Name));
		}
		colorIn.ClearOptions();
		colorOut.ClearOptions();
		colorIn.AddOptions(optionsIn);
		colorOut.AddOptions(optionsOut);
		colorIn.value = 0;
		colorOut.value = 0;
		for (int j = 0; j < 5; j++)
		{
			socketsIn.Add(null);
			socketsOut.Add(null);
		}
		socketsIn[2] = socketIn;
		socketsOut[2] = socketOut;
		for (int k = 0; k < 5; k++)
		{
			if (socketsIn[k] != null)
			{
				socketsIn[k].num = k;
			}
			if (socketsOut[k] != null)
			{
				socketsOut[k].num = k;
			}
		}
		if (base.gameObject.GetComponent<BlockData>().sh != null)
		{
			SchemeBlock sh = base.gameObject.GetComponent<BlockData>().sh;
			colorIn.value = sh.outConditionsColor[2];
			colorOut.value = sh.changeColorSocket[2];
		}
		delayTimer = Logic.GetWorkTimeByKeyName("CHCOLORBLOCK");
	}

	public int GetInColorValue()
	{
		return colorIn.value;
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer - lastActiveTime >= delayTimer)
		{
			Active();
			lastActiveTime = timer;
		}
	}
}
