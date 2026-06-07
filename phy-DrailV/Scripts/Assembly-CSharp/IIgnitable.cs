using DV.Interaction;
using UnityEngine;

public interface IIgnitable : IInteractionPointProvider
{
	bool Ignited { get; }

	bool IgnitionAllowed { get; }

	SphereCollider OverlapInteractionCollider { get; }

	bool Ignite(float ignitionStrength);

	Transform GetTransform();
}
