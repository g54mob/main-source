using UnityEngine;

namespace Coherence.Toolkit
{
	public delegate CoherenceBridge CoherenceBridgeResolver<in T>(T resolvingComponent) where T : MonoBehaviour;
}
