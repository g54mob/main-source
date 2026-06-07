using System.Collections;
using UI.Elements;
using UnityEngine;

public class UIClock : MonoBehaviour
{
	private UIText textTime;

	private Coroutine updateTimeCO;

	private string format;

	public void Init()
	{
	}

	public void StartClock(string format = "HH:mm")
	{
	}

	public void StopClock()
	{
	}

	private IEnumerator UpdateTimeCO()
	{
		return null;
	}
}
