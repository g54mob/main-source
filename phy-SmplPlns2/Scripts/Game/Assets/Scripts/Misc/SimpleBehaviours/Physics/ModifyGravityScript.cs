using UnityEngine;

namespace Assets.Scripts.Misc.SimpleBehaviours.Physics
{
	public class ModifyGravityScript : MonoBehaviour
	{
		public float GravityModifier;

		private Vector3 _previousGravity;

		protected virtual void OnTriggerEnter(Collider other)
		{
			_previousGravity = UnityEngine.Physics.gravity;
			UnityEngine.Physics.gravity *= GravityModifier;
		}

		protected virtual void OnTriggerExit(Collider other)
		{
			UnityEngine.Physics.gravity = _previousGravity;
		}
	}
}
