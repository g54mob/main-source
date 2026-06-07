using UnityEngine;

namespace DV.Interaction
{
	public interface IGrabberCursor
	{
		IPlayerRig Rig { get; }

		Ray GetRay();
	}
}
