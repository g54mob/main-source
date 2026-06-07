using UnityEngine;

public class Example : MonoBehaviour
{
	public bool active = true;

	private GraphDebugChannel ch;

	private void Start()
	{
		ch = GraphDebug.GetChannel();
	}

	private void Update()
	{
		ch.isActive = active;
		if (active)
		{
			float num = 0f;
			if (num > GraphDebug.YMax)
			{
				GraphDebug.YMax = num;
			}
			if (num < GraphDebug.YMin)
			{
				GraphDebug.YMin = num;
			}
			ch.Feed(num);
		}
	}
}
