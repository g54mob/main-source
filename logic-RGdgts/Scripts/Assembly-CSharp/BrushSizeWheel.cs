using UnityEngine;

public class BrushSizeWheel : MonoBehaviour
{
	public Transform wheel;

	public Vector2 numberOffset;

	public int min;

	public int max;

	private int value;

	private Vector2 positionVel;

	private Vector2 position;

	private Vector2 destination => default(Vector2);

	private void Awake()
	{
	}

	public void SetValue(int value)
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}
}
