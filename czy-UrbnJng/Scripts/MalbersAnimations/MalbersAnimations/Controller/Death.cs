using UnityEngine;

namespace MalbersAnimations.Controller
{
	[HelpURL("https://docs.google.com/document/d/1QBLQVWcDSyyWBDrrcS2PthhsToWkOayU0HUtiiSWTF8/edit#heading=h.kraxblx9518t")]
	public class Death : State
	{
		[Header("Death Parameters")]
		[Tooltip("Disable all components when the animal dies. Use this when your animal will not respawn")]
		public bool DisableAllComponents = true;

		[Tooltip("Disable the main collider when the animal dies. Use this when your animal will not respawn")]
		public bool DisableMainCollider = true;

		[Tooltip("Disable the internal collider when the animal dies. Use this when your animal will not respawn")]
		public bool DisableInternalColliders;

		public bool IsKinematic = true;

		public int DelayFrames = 2;

		public float RigidbodyDrag = 5f;

		public float RigidbodyAngularDrag = 15f;

		[Space]
		public bool disableAnimal = true;

		[Hide("disableAnimal")]
		public float disableAnimalTime = 5f;

		public override string StateName => "Death/Death (Animation)";

		public override string StateIDName => "Death";

		public override void EnterCoreAnimation()
		{
			animal.Mode_Interrupt();
			if ((bool)animal.RB && IsKinematic)
			{
				animal.RB.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
				animal.RB.isKinematic = true;
			}
			animal.StopMoving();
			animal.InputSource?.Enable(val: false);
			animal.Mode_Stop();
			animal.Delay_Action(DelayFrames, delegate
			{
				DisableAll();
			});
		}

		public override void OnStateMove(float deltatime)
		{
			if (!animal.Grounded)
			{
				animal.CheckIfGrounded();
				animal.UseGravity = false;
			}
		}

		private void DisableAll()
		{
			SetEnterStatus(0);
			if (DisableMainCollider && animal.MainCollider != null)
			{
				animal.MainCollider.enabled = false;
			}
			if (DisableAllComponents)
			{
				MonoBehaviour[] componentsInChildren = animal.GetComponentsInChildren<MonoBehaviour>();
				foreach (MonoBehaviour monoBehaviour in componentsInChildren)
				{
					if (!(monoBehaviour == animal) && monoBehaviour != null)
					{
						monoBehaviour.enabled = false;
					}
				}
			}
			if (DisableInternalColliders)
			{
				foreach (Collider collider in animal.colliders)
				{
					collider.SetEnable(enable: false);
				}
			}
			animal.SetCustomSpeed(new MSpeed("Death"));
			if ((bool)animal.RB)
			{
				animal.RB.drag = RigidbodyDrag;
				animal.RB.angularDrag = RigidbodyAngularDrag;
			}
			if (disableAnimal)
			{
				animal.DisableSelf(disableAnimalTime);
			}
		}
	}
}
