using System.Collections.Generic;
using App.Data;
using UnityEngine;

public class Duplicator : ActiveComponent
{
	private Socket socketIn;

	private Socket socketTop;

	private Socket socketBot;

	public List<Socket> socketsIn = new List<Socket>();

	public List<Socket> socketsOut = new List<Socket>();

	private float timer;

	private float delayTimer;

	private float lastActiveTime;

	private void Active()
	{
		if (!socketBot.isFull() && !socketTop.isFull())
		{
			Element element = socketIn.GetElement();
			if (element != null)
			{
				Element elem = new Element(element);
				socketBot.SetElement(element);
				socketTop.SetElement(elem);
			}
		}
	}

	private void Start()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
		socketTop = base.transform.Find("SocketTop").GetComponent<Socket>();
		socketBot = base.transform.Find("SocketBot").GetComponent<Socket>();
		for (int i = 0; i < 5; i++)
		{
			socketsIn.Add(null);
			socketsOut.Add(null);
		}
		socketsIn[2] = socketIn;
		socketsOut[1] = socketTop;
		socketsOut[3] = socketBot;
		for (int j = 0; j < 5; j++)
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
		delayTimer = Logic.GetWorkTimeByKeyName("DOUBLE");
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
