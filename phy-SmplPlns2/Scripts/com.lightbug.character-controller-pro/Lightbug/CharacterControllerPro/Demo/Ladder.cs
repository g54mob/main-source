using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class Ladder : MonoBehaviour
	{
		[Header("Debug")]
		[SerializeField]
		private bool showGizmos = true;

		[Header("Exit points")]
		[SerializeField]
		private Transform topReference;

		[SerializeField]
		private Transform bottomReference;

		[Header("Properties")]
		[Min(0f)]
		[SerializeField]
		private int climbingAnimations = 1;

		[SerializeField]
		private Vector3 bottomLocalPosition = Vector3.zero;

		[SerializeField]
		private Direction facingDirection = Direction.Forward;

		public int ClimbingAnimations => climbingAnimations;

		public Transform TopReference => topReference;

		public Transform BottomReference => bottomReference;

		public Vector3 FacingDirectionVector
		{
			get
			{
				Vector3 result = base.transform.forward;
				switch (facingDirection)
				{
				case Direction.Left:
					result = -base.transform.right;
					break;
				case Direction.Right:
					result = base.transform.right;
					break;
				case Direction.Up:
					result = base.transform.up;
					break;
				case Direction.Down:
					result = -base.transform.up;
					break;
				case Direction.Forward:
					result = base.transform.forward;
					break;
				case Direction.Back:
					result = -base.transform.forward;
					break;
				}
				return result;
			}
		}

		private void Awake()
		{
		}

		private void OnDrawGizmos()
		{
			if (showGizmos)
			{
				if (bottomReference != null)
				{
					Gizmos.color = new Color(0f, 0f, 1f, 0.2f);
					Gizmos.DrawCube(bottomReference.position, Vector3.one * 0.5f);
				}
				if (topReference != null)
				{
					Gizmos.color = new Color(1f, 0f, 0f, 0.2f);
					Gizmos.DrawCube(topReference.position, Vector3.one * 0.5f);
				}
				CustomUtilities.DrawArrowGizmo(base.transform.position, base.transform.position + FacingDirectionVector, Color.blue);
				Gizmos.color = Color.white;
			}
		}
	}
}
