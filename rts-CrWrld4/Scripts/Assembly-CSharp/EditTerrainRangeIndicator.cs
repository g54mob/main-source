using UnityEngine;

public class EditTerrainRangeIndicator : MonoBehaviour
{
	public AreaBorder areaBorder;

	private bool[] data;

	private int lastRadius;

	private bool lastSquare;

	private bool lastSquareWhenZero;

	public void Refresh(int radius, bool square, bool squareWhenZero, Vector3 position)
	{
	}
}
