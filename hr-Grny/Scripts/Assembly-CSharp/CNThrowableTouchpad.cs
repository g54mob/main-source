using UnityEngine;

public class CNThrowableTouchpad : CNTouchpad
{
	[SerializeField]
	[HideInInspector]
	private float _speedDecay;

	public float SpeedDecay
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	protected override void ResetControlState()
	{
	}

	protected override void Update()
	{
	}
}
