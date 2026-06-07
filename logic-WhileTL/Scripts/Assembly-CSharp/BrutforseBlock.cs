using System.Collections.Generic;
using App.Data;
using UnityEngine;

public class BrutforseBlock : ActiveComponent
{
	private Socket socketIn;

	private Socket socketOut;

	public List<Socket> socketsIn = new List<Socket>();

	public List<Socket> socketsOut = new List<Socket>();

	private float timer;

	private float delayTimer;

	private float lastActiveTime;

	private void Active()
	{
		if (!socketOut.isFull())
		{
			Element element = socketIn.GetElement();
			if (element != null)
			{
				socketOut.SetElement(element);
			}
		}
	}

	private void Awake()
	{
		timer = 0f;
		lastActiveTime = 0f;
		SceneBindContainer.BindObjects(this, base.transform);
		socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
		socketOut = base.transform.Find("SocketOut").GetComponent<Socket>();
		for (int i = 0; i < 5; i++)
		{
			socketsIn.Add(null);
			socketsOut.Add(null);
		}
		socketsIn[2] = socketIn;
		socketsOut[2] = socketOut;
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
		socketsIn[2].catcherSocket = true;
		delayTimer = Logic.GetWorkTimeByKeyName("BRBLOCK");
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
