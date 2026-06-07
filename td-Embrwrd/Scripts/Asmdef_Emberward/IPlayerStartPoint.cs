using UnityEngine;

public interface IPlayerStartPoint
{
	void RegisterToMapManager();

	void UnregisterToMapManager();

	Vector3 GetPosition();

	GameObject GetGameObject();
}
