using UnityEngine;

public class GoldcrestPos : MonoBehaviour
{
	public bool occupied;

	public bool setLayerToZero;

	private void OnEnable()
	{
		GameManager.ins.goldcrestPositions.Add(this);
	}

	private void OnDisable()
	{
		GameManager.ins.goldcrestPositions.Remove(this);
	}
}
