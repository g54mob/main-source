using System.Collections.Generic;
using App.Data;
using UnityEngine;
using UnityEngine.UI;

public class Genetic : ActiveComponent
{
	private Socket socketIn;

	private Socket socketAdd;

	private Socket socketOut;

	[SceneBind("IncrText")]
	private Text incrText;

	private float timer;

	private float delayTimer;

	private float lastActiveTime;

	public List<Socket> socketsIn = new List<Socket>();

	public List<Socket> socketsOut = new List<Socket>();

	private List<int> extraChance = new List<int>();

	private List<float> percents = new List<float>();

	private void Active()
	{
		if (socketOut.isFull())
		{
			return;
		}
		Element element = socketIn.GetElement();
		if (element != null)
		{
			if (Random.Range(0f, 100f) < percents[element.RealColorId])
			{
				element.ColorId = element.RealColorId;
			}
			socketOut.SetElement(element);
		}
	}

	private void CheckAdd()
	{
		Element element = socketAdd.GetElement();
		if (element != null && element.ColorId == element.RealColorId)
		{
			extraChance[element.ColorId]++;
			RecalcChance();
		}
	}

	private void RecalcChance()
	{
		float num = extraChance[0] + extraChance[1] + extraChance[2];
		if (num < 100f)
		{
			for (int i = 0; i < 3; i++)
			{
				percents[i] = extraChance[i];
			}
		}
		else
		{
			for (int j = 0; j < 3; j++)
			{
				percents[j] = 100f * (float)extraChance[j] / num;
			}
		}
		Redraw();
	}

	private void Awake()
	{
		timer = 0f;
		lastActiveTime = 0f;
		SceneBindContainer.BindObjects(this, base.transform);
		socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
		socketOut = base.transform.Find("SocketOut").GetComponent<Socket>();
		socketAdd = base.transform.Find("SocketAdd").GetComponent<Socket>();
		for (int i = 0; i < 3; i++)
		{
			extraChance.Add(0);
			percents.Add(0f);
		}
		for (int j = 0; j < 5; j++)
		{
			socketsIn.Add(null);
			socketsOut.Add(null);
		}
		socketsIn[1] = socketIn;
		socketsIn[3] = socketAdd;
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
		socketsIn[1].catcherSocket = true;
		delayTimer = Logic.GetWorkTimeByKeyName("GENETIC");
	}

	private void Clear()
	{
		extraChance = new List<int>();
		percents = new List<float>();
		for (int i = 0; i < 3; i++)
		{
			extraChance.Add(0);
			percents.Add(0f);
		}
	}

	private void Redraw()
	{
		incrText.text = (int)percents[0] + "% " + (int)percents[1] + "% " + (int)percents[2] + "%";
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer - lastActiveTime >= delayTimer)
		{
			Active();
			CheckAdd();
			lastActiveTime = timer;
		}
	}
}
