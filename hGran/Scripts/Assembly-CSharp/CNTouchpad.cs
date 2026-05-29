using UnityEngine;

public class CNTouchpad : CNAbstractController
{
	[SerializeField]
	[HideInInspector]
	private bool _isAlwaysNormalized;

	public bool IsAlwaysNormalized
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Vector3 PreviousPosition { get; set; }

	protected virtual void Update()
	{
	}

	protected override void TweakControl(Vector2 touchPosition)
	{
	}
}
