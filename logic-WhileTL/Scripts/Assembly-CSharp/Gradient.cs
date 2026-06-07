using App.Data;
using Localization;

public class Gradient : BaseBlock
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
			element.error += value;
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
		keyName = "GRADIENT";
		Speed.text = Logic.ColorTransform("TIME", Logic.GetWorkTimeByKeyName(keyName) + " " + TextResources.GetString("SEC"));
		value = Logic.GetValueByKeyName(keyName);
		socketsIn[2] = socketIn;
		socketsOut[2] = socketOut;
		for (int i = 0; i < BaseBlock.maxSockets; i++)
		{
			if (socketsIn[i] != null)
			{
				socketsIn[i].num = i;
			}
			if (socketsOut[i] != null)
			{
				socketsOut[i].num = i;
			}
		}
		delayTimer = Logic.GetWorkTimeByKeyName(keyName);
	}
}
