using R3;
using UnityEngine;

public class FrameRateController : MonoBehaviour
{
	private void Awake()
	{
		QualitySettings.vSyncCount = 0;
		ReactiveSettings.FpsLimit.Subscribe(delegate(int x)
		{
			Application.targetFrameRate = x;
		}).AddTo(this);
	}
}
