using UnityEngine;

public class TouchIndicator : MonoBehaviour
{
	public RectTransform WrapperCenter;

	public RectTransform DirIndicator;

	public RectTransform WrapperCur;

	public bool IsAim;

	public bool IsRight;

	private Touch _startTouch;

	private Vector2 _prevDir;

	private Vector2 _curDir;

	private Vector2 _curOffset;

	private bool _justStartedTouch;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetStartScreenPos(Vector2 pos)
	{
	}

	private void OnStickRadiusChanged()
	{
	}

	public bool ShouldAlwaysShow()
	{
		return false;
	}

	public Touch GetStartTouch()
	{
		return default(Touch);
	}

	public void StartTouch(Touch startTouch)
	{
	}

	public void UpdateTouch(Touch curTouch)
	{
	}

	public void EndTouch()
	{
	}

	public Vector2 ScreenPosToCvsPos(Vector2 screenPos)
	{
		return default(Vector2);
	}

	public Vector2 GetDir()
	{
		return default(Vector2);
	}

	public Vector2 GetOffset()
	{
		return default(Vector2);
	}
}
