using App.Data;

public class ConverterZIP : BaseBlock
{
	protected override bool TryActive()
	{
		if (socketsIn[2] == null)
		{
			return false;
		}
		return !socketsIn[2].isEmpty();
	}

	protected override void Active()
	{
		if (socketsIn.Count >= BaseBlock.maxSockets && !(socketsIn[2] == null))
		{
			Element element = socketsIn[2].GetElement();
			if (element != null)
			{
				element.SetZIPSprite("");
				socketsOut[element.inputNum].SetElement(element);
			}
		}
	}

	public override void Init()
	{
		base.Init();
		SceneBindContainer.BindObjects(this, base.transform);
		socketsIn.Clear();
		socketsOut.Clear();
		delayTimer = 0.01f;
		for (int i = 0; i < BaseBlock.maxSockets; i++)
		{
			socketsIn.Add(null);
			socketsOut.Add(base.transform.Find("SocketOut" + i).GetComponent<Socket>());
		}
		socketsIn[2] = base.transform.Find("SocketIn").GetComponent<Socket>();
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
	}

	public void SetSocketState(int id, bool state)
	{
		socketsOut[id].gameObject.SetActive(state);
		socketsOut[id].chain.gameObject.SetActive(state);
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();
	}
}
