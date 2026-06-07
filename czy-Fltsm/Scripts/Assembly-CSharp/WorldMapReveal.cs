using System.Collections;
using UnityEngine;

public abstract class WorldMapReveal : MonoBehaviour
{
	public abstract void Initialize(WorldMapPointOfInterest poi);

	public abstract bool InitializeReveal(WorldMapPointOfInterest poi);

	public abstract IEnumerator Reveal(WorldMapPointOfInterest poi);
}
