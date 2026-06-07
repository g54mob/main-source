using R3;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
	private void Awake()
	{
		ReactiveSettings.FullscreenMode.Subscribe(delegate(FullScreenMode x)
		{
			Screen.fullScreenMode = x;
		}).AddTo(this);
	}
}
