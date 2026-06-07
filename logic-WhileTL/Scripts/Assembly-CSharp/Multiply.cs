using App.Data;
using Localization;

public class Multiply : BaseBlock
{
	private Socket socketIn;

	private Socket socketBot;

	private Socket socketTop;

	private Socket socketMid;

	protected override bool TryActive()
	{
		if (socketIn.queue.Count == 0)
		{
			return false;
		}
		_ = socketIn.queue[socketIn.queue.Count - 1];
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
		if (element == null)
		{
			return;
		}
		foreach (Socket item in socketsOut)
		{
			if (item != null)
			{
				item.SetElement(new Element(element));
			}
		}
	}

	public override void Init()
	{
		base.Init();
		socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
		socketTop = base.transform.Find("SocketTop").GetComponent<Socket>();
		socketBot = base.transform.Find("SocketBot").GetComponent<Socket>();
		socketMid = base.transform.Find("SocketMid").GetComponent<Socket>();
		keyName = "MULTIPLY";
		Speed.text = Logic.ColorTransform("TIME", Logic.GetWorkTimeByKeyName(keyName) + " " + TextResources.GetString("SEC"));
		socketsIn[2] = socketIn;
		socketsOut[1] = socketTop;
		socketsOut[2] = socketMid;
		socketsOut[3] = socketBot;
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
