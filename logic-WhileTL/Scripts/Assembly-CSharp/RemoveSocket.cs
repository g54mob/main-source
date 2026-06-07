public class RemoveSocket : BaseBlock
{
	private Socket socketIn;

	protected override bool TryActive()
	{
		if (socketIn == null)
		{
			return false;
		}
		if (socketIn.queue.Count == 0)
		{
			return false;
		}
		return true;
	}

	protected override void Active()
	{
		socketIn.GetElement();
	}

	public override void Init()
	{
		base.Init();
		socketIn = base.gameObject.GetComponent<Socket>();
	}

	protected override void FixedUpdate()
	{
		if (TryActive())
		{
			Active();
		}
	}
}
