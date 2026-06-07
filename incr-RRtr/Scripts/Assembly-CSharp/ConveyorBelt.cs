using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
	public enum BeltDirection
	{
		Right = 0,
		Down = 1,
		Left = 2,
		Up = 3
	}

	public BeltDirection beltDirection;

	public float speed = 0.5f;

	private Vector3 centerOffset = new Vector3(0.5625f, 0.5625f, 0f);

	[SerializeField]
	private int numberOfItemsOnBelt;

	public Vector3 getItemCenterPosition()
	{
		return base.transform.position + centerOffset;
	}

	public void AddItemToBelt()
	{
		numberOfItemsOnBelt++;
	}

	public void RemoveItemFromBelt()
	{
		numberOfItemsOnBelt--;
		if (numberOfItemsOnBelt < 0)
		{
			numberOfItemsOnBelt = 0;
		}
	}
}
