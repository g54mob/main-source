using App.Data;
using Localization;
using UnityEngine.UI;

public class Parallel : BaseBlock
{
	private Socket socketIn;

	private Socket socketTop;

	private Socket socketBot;

	[SceneBind("ServersCost")]
	private Text Servers;

	private int curExit;

	protected override bool TryActive()
	{
		if (socketIn.queue.Count == 0)
		{
			return false;
		}
		if (socketBot.isFull() && socketTop.isFull())
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
		if (element == null)
		{
			return;
		}
		if (curExit == 0)
		{
			if (socketTop.isFull())
			{
				socketBot.SetElement(element);
				curExit = 1 - curExit;
			}
			else
			{
				socketTop.SetElement(element);
				curExit = 1 - curExit;
			}
		}
		else if (socketBot.isFull())
		{
			socketTop.SetElement(element);
			curExit = 1 - curExit;
		}
		else
		{
			socketBot.SetElement(element);
			curExit = 1 - curExit;
		}
	}

	public override void Init()
	{
		base.Init();
		socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
		socketTop = base.transform.Find("SocketTop").GetComponent<Socket>();
		socketBot = base.transform.Find("SocketBot").GetComponent<Socket>();
		keyName = "PARALLEL";
		Speed.text = Logic.ColorTransform("TIME", Logic.GetWorkTimeByKeyName(keyName) + " " + TextResources.GetString("SEC"));
		Servers.text = Logic.ColorTransform("SERVERS", Logic.GetServersCouInBlock(keyName).ToString());
		socketsIn[2] = socketIn;
		socketsOut[1] = socketTop;
		socketsOut[3] = socketBot;
		for (int i = 0; i < 5; i++)
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
		curExit = 0;
		delayTimer = Logic.GetWorkTimeByKeyName(keyName);
	}
}
