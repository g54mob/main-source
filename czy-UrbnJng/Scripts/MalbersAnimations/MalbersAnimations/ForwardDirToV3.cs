using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Tools/Forward Direction to Vector3")]
	public class ForwardDirToV3 : MonoBehaviour
	{
		[RequiredField]
		[Header("Tranform.Forward is the Direction")]
		public Vector3Var Direction;

		private void OnEnable()
		{
			if (Direction == null)
			{
				base.enabled = false;
			}
		}

		private void Update()
		{
			if (Direction.Value != base.transform.forward)
			{
				Direction.SetValue(base.transform.forward);
			}
		}

		private void OnDrawGizmos()
		{
		}
	}
}
