using UnityEngine;

public class Bench : MonoBehaviour
{
	public bool occupied;

	public SpriteRenderer visual;

	private void OnEnable()
	{
		GameManager.ins.benches.Add(this);
		SetOccupied(state: false);
	}

	private void OnDisable()
	{
		GameManager.ins.benches.Remove(this);
	}

	public void SetOccupied(bool state)
	{
		occupied = state;
		if ((bool)visual)
		{
			if (!occupied)
			{
				visual.sortingOrder = 0;
			}
			else
			{
				visual.sortingOrder = -25;
			}
		}
	}
}
