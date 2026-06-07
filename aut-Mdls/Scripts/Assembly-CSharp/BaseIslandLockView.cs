using Data.FactoryFloor.Maps;
using Presentation.FactoryFloor.Islands;
using UnityEngine;

public abstract class BaseIslandLockView : MonoBehaviour
{
	public abstract void Setup(IslandViewBottom bottomPrefab, IslandObject islandObject);

	public abstract void Hover();

	public abstract void HoverStopped();

	public abstract void Cull(bool cull);
}
