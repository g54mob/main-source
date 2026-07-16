using UnityEngine;

public class TableComponent : MonoBehaviour
{
	[SerializeField]
	private ItemSocket[] cupSockets;

	public ItemSocket GetNearestFreeSocket(Vector3 pos)
	{
		float num = float.PositiveInfinity;
		ItemSocket result = null;
		for (int i = 0; i < cupSockets.Length; i++)
		{
			if (!cupSockets[i].IsHoldingItem())
			{
				float num2 = Vector3.Distance(cupSockets[i].transform.position, pos);
				if (num2 < num)
				{
					num = num2;
					result = cupSockets[i];
				}
			}
		}
		return result;
	}

	public float GetSocketPlacementHeight()
	{
		return cupSockets[0].transform.position.y;
	}
}
