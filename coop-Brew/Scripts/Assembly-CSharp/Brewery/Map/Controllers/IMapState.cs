using UnityEngine;

namespace Brewery.Map.Controllers
{
	public interface IMapState
	{
		bool IsMapOpen { get; }

		bool IsTransitioning { get; }

		Camera MapCamera { get; }

		Transform CameraRig { get; }

		Vector3 MapPosition { get; set; }

		float MapZoom { get; set; }

		float TargetMapZoom { get; set; }

		MapCameraSettings Settings { get; }

		void SetTransitioning(bool transitioning);

		void SetMapOpen(bool open);
	}
}
