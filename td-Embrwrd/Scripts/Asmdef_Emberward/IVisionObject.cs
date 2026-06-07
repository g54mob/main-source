using UnityEngine;

public interface IVisionObject
{
	void RegisterVisionObject(AGridObject gridObject)
	{
	}

	void UnregisterVisionObject(AGridObject gridObject)
	{
	}

	float GetVisionRange();

	Vector3 GetVisionPosition();
}
