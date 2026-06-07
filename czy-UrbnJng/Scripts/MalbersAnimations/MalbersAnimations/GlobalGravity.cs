using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Tools/Global Gravity")]
	public class GlobalGravity : MonoBehaviour
	{
		[RequiredField]
		public Vector3Var Gravity;

		[Tooltip("Instead of using the Gravity Value, Use the ")]
		public bool UseUpVector = true;

		private void Update()
		{
			if (Gravity != null)
			{
				Gravity.Value = -base.transform.up;
			}
		}
	}
}
