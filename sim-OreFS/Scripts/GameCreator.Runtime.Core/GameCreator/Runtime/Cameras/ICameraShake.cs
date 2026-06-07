using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	internal interface ICameraShake
	{
		Vector3 AdditivePosition { get; }

		Vector3 AdditiveRotation { get; }

		void Update(TCamera camera);
	}
}
