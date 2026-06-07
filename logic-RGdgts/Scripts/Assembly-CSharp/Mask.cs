using Fix;
using UnityEngine;

public class Mask : MonoBehaviour
{
	private SpriteMask spriteMask;

	public int frontSortingLayerID => 0;

	public int frontSortingOrder => 0;

	public int backSortingLayerID => 0;

	public int backSortingOrder => 0;

	private void Awake()
	{
	}

	private bool IsInside(Transform transform, Vector2 position)
	{
		return false;
	}

	public bool IsInside(Vector2 position)
	{
		return false;
	}
}
