using Unity.Mathematics;
using UnityEngine;

public class Aquarium : Table
{
	public void UpdateSimulationPosition(int index, float3 position)
	{
		tableItemsLists[0].tableItems[index].transform.localPosition = new Vector3(position.x, position.y - 0.2f, -0.59f + position.y * 0.02f);
	}

	public void PlayAnimationForVisual(int index, int animation, int orientationHash, bool flipX)
	{
		tableItemsLists[0].tableItems[index].transform.localScale = new Vector3((!flipX) ? 1 : (-1), 1f, 1f);
	}
}
