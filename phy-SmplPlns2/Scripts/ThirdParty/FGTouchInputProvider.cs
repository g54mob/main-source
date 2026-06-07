using UnityEngine;

public class FGTouchInputProvider : FGInputProvider
{
	public int maxTouches = 5;

	public bool fixAndroidTouchIdBug = true;

	private int touchIdOffset;

	private Touch nullTouch;

	private int[] finger2touchMap;

	public override int MaxSimultaneousFingers => maxTouches;

	private void Start()
	{
		finger2touchMap = new int[maxTouches];
	}

	private void Update()
	{
		UpdateFingerTouchMap();
	}

	private void UpdateFingerTouchMap()
	{
		for (int i = 0; i < finger2touchMap.Length; i++)
		{
			finger2touchMap[i] = -1;
		}
		for (int j = 0; j < Input.touchCount; j++)
		{
			int num = Input.touches[j].fingerId - touchIdOffset;
			if (num < finger2touchMap.Length)
			{
				finger2touchMap[num] = j;
			}
		}
	}

	private bool HasValidTouch(int fingerIndex)
	{
		return finger2touchMap[fingerIndex] != -1;
	}

	private Touch GetTouch(int fingerIndex)
	{
		int num = finger2touchMap[fingerIndex];
		if (num == -1)
		{
			return nullTouch;
		}
		return Input.touches[num];
	}

	public override void GetInputState(int fingerIndex, out bool down, out Vector2 position)
	{
		down = false;
		position = Vector2.zero;
		if (HasValidTouch(fingerIndex))
		{
			Touch touch = GetTouch(fingerIndex);
			if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
			{
				down = false;
				return;
			}
			down = true;
			position = touch.position;
		}
	}
}
