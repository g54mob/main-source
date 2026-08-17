using UnityEngine;

namespace VampireSurvivors.Framework.TimerSystem;

public class TimerManagerAutomation : TimerManager
{
	private void Update()
	{
		GameObject target = base.gameObject;
		Object.DontDestroyOnLoad(target);
		UpdateAllTimers();
	}
}
