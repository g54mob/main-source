using System;
using DV.Utils;

namespace DV.Interaction
{
	public interface IGrabberRaycaster
	{
		AGrabHandler CurrentlyRaycasted { get; }

		RaycastHitDV CurrentlyHit { get; }

		bool AnythingHit { get; }

		event Action<AGrabHandler> Hovered;

		event Action<AGrabHandler> UnHovered;

		void ReleaseHover();

		void UpdateRaycast();
	}
}
