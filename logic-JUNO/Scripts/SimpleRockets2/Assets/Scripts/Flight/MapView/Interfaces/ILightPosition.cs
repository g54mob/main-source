using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Interfaces
{
	public interface ILightPosition
	{
		Vector3 LightPosition { get; }

		Transform Transform { get; }
	}
}
