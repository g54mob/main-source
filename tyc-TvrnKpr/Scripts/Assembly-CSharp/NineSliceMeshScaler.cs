using UnityEngine;

public class NineSliceMeshScaler : MonoBehaviour
{
	public Transform topLeftCorner;

	public Transform topRightCorner;

	public Transform bottomLeftCorner;

	public Transform bottomRightCorner;

	public Transform topSide;

	public Transform bottomSide;

	public Transform leftSide;

	public Transform rightSide;

	public Vector2 testSize;

	public void SetSize(float width, float height)
	{
	}

	public void SetToMatchScaleTransform(Transform scaledTransform)
	{
	}

	[ContextMenu("TestSetSize")]
	public void TestSetSize()
	{
	}
}
