using UnityEngine;

public class Feeder : MonoBehaviour
{
	public FeederSlot[] feederSlots;

	private void Start()
	{
		GameManager.ins.feeders.Add(this);
	}

	private void OnDestroy()
	{
		GameManager.ins.feeders.Remove(this);
	}
}
