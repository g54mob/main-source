using UnityEngine;

public class AnimalPosSaveData
{
	public int ID;

	public float X;

	public float Y;

	public float Z;

	public int SortingOrder;

	public AnimalPosSaveData(int id, Vector3 pos, int sortingOrder)
	{
		ID = id;
		X = pos.x;
		Y = pos.y;
		Z = pos.z;
		SortingOrder = sortingOrder;
	}

	public Vector3 GetVector3()
	{
		return new Vector3(X, Y, Z);
	}
}
