using UnityEngine;

public class AnalyticsInitializer : MonoBehaviour
{
	private void Awake()
	{
		_ = Anal.instance;
	}
}
