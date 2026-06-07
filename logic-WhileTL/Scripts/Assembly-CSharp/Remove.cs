public class Remove : BaseBlock
{
	private Socket socketIn;

	protected override bool TryActive()
	{
		return false;
	}

	protected override void Active()
	{
		socketIn.GetElement();
	}

	public override void Init()
	{
		base.Init();
		keyName = "REMOVE";
		socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
		socketsIn[2] = socketIn;
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
		socketsIn[2].catcherSocket = true;
		delayTimer = Logic.GetWorkTimeByKeyName(keyName);
	}

	protected override void FixedUpdate()
	{
		while (socketIn.queue.Count > 0)
		{
			Active();
		}
	}
}
