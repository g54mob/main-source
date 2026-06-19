using UnityEngine;

public class ClickHitDummyCursorProvider : MonoBehaviour
{
	[SerializeField]
	private ClickHitDummy _clickHitDummy;

	[SerializeField]
	private ClickGeneratorCustomCursor _cursor;

	private CustomCursor _appliedCursor;

	private float _defaultRecoveryTimer;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnHit(bool finished)
	{
	}

	public void OnHoverStart()
	{
	}

	public void OnHoverEnd()
	{
	}
}
