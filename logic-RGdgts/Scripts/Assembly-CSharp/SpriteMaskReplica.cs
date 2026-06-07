using Fix;
using UnityEngine;

public class SpriteMaskReplica : MonoBehaviour
{
	public Vector3 localPositionOffset;

	private SpriteMask copyFrom;

	private SpriteMask spriteMask;

	private int sortingOrderOffset;

	private int maxSortingOrder;

	private bool init;

	public static SpriteMaskReplica Create(SpriteMask spriteMask, Transform parent, int sortingOrderOffset, int maxSortingOrder = 32767)
	{
		return null;
	}

	public void Init(SpriteMask copyFrom, int sortingOrderOffset, int maxSortingOrder = 32767)
	{
	}

	private void LateUpdate()
	{
	}

	public void OnDestroy()
	{
	}
}
