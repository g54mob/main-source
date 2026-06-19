using Aggro.Core;
using UnityEngine;

public class BoxDebug : EntityBehaviourBase
{
	public GameObject sleepContainer;

	public GameObject awakeContainer;

	public static bool debugEnabled;

	[RuntimeInitializeOnLoadMethod]
	private static void RuntimeInit()
	{
		debugEnabled = false;
	}

	protected override void OnEntityCreated()
	{
		sleepContainer.SetActive(value: false);
		awakeContainer.SetActive(value: false);
	}
}
