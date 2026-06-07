using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_PhysicsSettings : FimpossibleComponent
	{
		public float SetFixedTimeStep = 0.01f;

		public float TimeScale = 1f;

		public float GravityY = -9.81f;

		[Tooltip("Ignore TransparentFX vs TransparentFX collision")]
		public bool TransparentFXFullIgnore;

		private void Start()
		{
			Time.timeScale = TimeScale;
			Physics.gravity = new Vector3(Physics.gravity.x, GravityY, Physics.gravity.z);
			Time.fixedDeltaTime = SetFixedTimeStep;
			if (TransparentFXFullIgnore)
			{
				Physics.IgnoreLayerCollision(1, 1, ignore: true);
			}
			else
			{
				Physics.IgnoreLayerCollision(1, 1, ignore: false);
			}
			Physics.IgnoreLayerCollision(1, 4, ignore: true);
		}
	}
}
