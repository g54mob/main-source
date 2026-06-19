using OUSystems.Basics.Effects;
using OUSystems.Basics.UI;
using UnityEngine.UI;

public class DestroyButton : HoldListener
{
	public ShakeReceiver ShakeReciever;

	private float _lastPorgress;

	public float ShakeFactor;

	public float ProgressShakeAmplifier;

	public Image _fillImage;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnUpdateProgress(float progress)
	{
	}
}
