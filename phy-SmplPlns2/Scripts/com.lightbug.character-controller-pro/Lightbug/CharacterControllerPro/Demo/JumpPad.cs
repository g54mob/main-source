using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class JumpPad : CharacterDetector
	{
		public bool useLocalSpace = true;

		public Vector3 direction = Vector3.up;

		public float jumpPadVelocity = 10f;

		protected override void ProcessEnterAction(CharacterActor characterActor)
		{
			if (!(characterActor.GroundObject != base.gameObject))
			{
				characterActor.ForceNotGrounded();
				Vector3 vector = (useLocalSpace ? base.transform.TransformDirection(direction) : direction);
				characterActor.Velocity += vector * jumpPadVelocity;
			}
		}

		protected override void ProcessStayAction(CharacterActor characterActor)
		{
			ProcessEnterAction(characterActor);
		}

		private void OnDrawGizmos()
		{
			Vector3 vector = (useLocalSpace ? base.transform.TransformDirection(direction) : direction);
			CustomUtilities.DrawArrowGizmo(base.transform.position, base.transform.position + vector * 2f, Color.red);
		}
	}
}
