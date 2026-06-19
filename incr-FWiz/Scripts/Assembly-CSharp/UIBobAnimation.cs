using UnityEngine;

public class UIBobAnimation : MonoBehaviour
{
	[SerializeField]
	private RectTransform _bounceTarget;

	[SerializeField]
	private float _bounceHeight;

	[SerializeField]
	private float _bounceRate;

	private float _lastLevel;

	private Vector2 _lastOffset;

	private Vector2 _offset;

	private float _timeAnimated;

	private void Update()
	{
	}

	public void Clear()
	{
	}
}
