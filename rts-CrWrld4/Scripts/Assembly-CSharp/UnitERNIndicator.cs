using UnityEngine;

public class UnitERNIndicator : MonoBehaviour
{
	private Transform unitTransform;

	private float SPEED;

	private float extraDist;

	private float height;

	private float minX;

	private float minY;

	private float maxX;

	private float maxY;

	private int currentCorner;

	private float percent;

	private int WIDTH;

	private int HEIGHT;

	private UnitManager.ORIENTATION orientation;

	public void Init(Transform unitTransform, int WIDTH, int HEIGHT, UnitManager.ORIENTATION orientation, float height = 0.2f)
	{
	}

	private void CalculateCorners()
	{
	}

	private void LateUpdate()
	{
	}
}
