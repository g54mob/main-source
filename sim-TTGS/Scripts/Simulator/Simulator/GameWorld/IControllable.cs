using Unity.Cinemachine;
using UnityEngine;

namespace Simulator.GameWorld
{
	public interface IControllable
	{
		CinemachineCamera Camera { get; }

		EControllerContext Context { get; }

		Controller Controller { get; }

		Vector3 Position { get; }

		Quaternion Rotation { get; }

		void OnControlledBy(Controller controller);

		void OnUncontrolledBy(Controller controller);
	}
}
