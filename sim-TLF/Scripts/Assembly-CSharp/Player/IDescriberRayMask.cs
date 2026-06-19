using UnityEngine;

namespace Player
{
	public interface IDescriberRayMask
	{
		void RestrictToLayers(LayerMask mask);

		void ClearRestriction();
	}
}
