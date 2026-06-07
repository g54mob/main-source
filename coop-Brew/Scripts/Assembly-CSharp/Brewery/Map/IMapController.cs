using UnityEngine;

namespace Brewery.Map
{
	public interface IMapController
	{
		bool IsMapOpen();

		bool IsTransitioning();

		Vector3 GetCameraPosition();
	}
}
