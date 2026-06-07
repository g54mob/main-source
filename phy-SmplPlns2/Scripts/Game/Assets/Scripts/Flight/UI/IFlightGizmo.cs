using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public interface IFlightGizmo
	{
		void DrawFlightGizmo(Camera camera);

		void OnFlightGizmosEnabled(bool enabled);
	}
}
