using App.Data;
using Localization;
using UnityEngine;

public class SGradient : BaseBlock
{
	private Socket socketIn;

	private Socket socketOut;

	protected override bool TryActive()
	{
		if (socketIn.queue.Count == 0)
		{
			return false;
		}
		bool result = true;
		for (int i = 0; i < BaseBlock.maxSockets; i++)
		{
			if (socketsOut[i] != null && socketsOut[i].isFull())
			{
				result = false;
			}
		}
		return result;
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
			if (Random.Range(0f, 1f) < 0.5f)
			{
				element.error *= value;
			}
			else
			{
				element.error -= value * 0.05f;
			}
			if (element.Test)
			{
				element.error = 0f;
			}
			socketsOut[2].SetElement(element);
		}
	}

	public override void Init()
	{
		base.Init();
		socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
		socketOut = base.transform.Find("SocketOut").GetComponent<Socket>();
		keyName = "SGRADIENT";
		Speed.text = Logic.ColorTransform("TIME", Logic.GetWorkTimeByKeyName(keyName) + " " + TextResources.GetString("SEC"));
		value = Logic.GetValueByKeyName(keyName);
		for (int i = 0; i < BaseBlock.maxSockets; i++)
		{
			socketsIn.Add(null);
			socketsOut.Add(null);
		}
		socketsIn[2] = socketIn;
		socketsOut[2] = socketOut;
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
		delayTimer = Logic.GetWorkTimeByKeyName(keyName);
	}
}
