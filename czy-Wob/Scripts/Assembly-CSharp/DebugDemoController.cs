using UnityEngine;

public class DebugDemoController : MonoBehaviour
{
	private void Awake()
	{
		CheatEngine.cheatRef.demoMode = true;
	}
}
