using App.Data;
using Localization;
using UnityEngine;

public class IsObject : BaseBlock
{
	private Socket socketIn;

	private Socket socketBot;

	private Socket socketTop;

	public const string nodeName = "unknown";

	protected override bool TryActive()
	{
		if (socketIn.queue.Count == 0)
		{
			return false;
		}
		Element element = socketIn.queue[0];
		if (element.predictedObject != "unknown")
		{
			if (!socketBot.isFull())
			{
				return !socketTop.isFull();
			}
			return false;
		}
		string text = CarObjectTree.Step(element.predictedObject, element.trueCellObject);
		if (text == "object")
		{
			return !socketTop.isFull();
		}
		if (text == "empty")
		{
			return !socketBot.isFull();
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
		if (element.predictedObject != "unknown")
		{
			element.predictedObject = "unknown";
		}
		else
		{
			element.predictedObject = CarObjectTree.Step(element.predictedObject, element.trueCellObject);
		}
		if (element.predictedObject == "unknown")
		{
			int[] array = new int[2] { 2, 3 };
			socketsOut[array[Random.Range(0, 2)]].SetElement(element);
			return;
		}
		if (element.predictedObject == "object")
		{
			socketTop.SetElement(element);
		}
		if (element.predictedObject == "empty")
		{
			socketBot.SetElement(element);
		}
	}

	public override void Init()
	{
		base.Init();
		socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
		socketBot = base.transform.Find("SocketBot").GetComponent<Socket>();
		socketTop = base.transform.Find("SocketTop").GetComponent<Socket>();
		keyName = "ISCAR";
		socketsIn[2] = socketIn;
		socketsOut[3] = socketBot;
		socketsOut[2] = socketTop;
		Speed.text = Logic.ColorTransform("TIME", Logic.GetWorkTimeByKeyName(keyName) + " " + TextResources.GetString("MSEC"));
		delayTimer = Logic.GetWorkTimeByKeyName(keyName);
	}
}
