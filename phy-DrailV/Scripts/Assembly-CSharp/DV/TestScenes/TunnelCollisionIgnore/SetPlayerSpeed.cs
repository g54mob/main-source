using System.Collections;
using UnityEngine;

namespace DV.TestScenes.TunnelCollisionIgnore
{
	public class SetPlayerSpeed : MonoBehaviour
	{
		public float walkSpeed = 5f;

		public float runSpeed = 50f;

		private IEnumerator Start()
		{
			yield return null;
			yield return null;
			CustomFirstPersonController customFirstPersonController = Object.FindObjectOfType<CustomFirstPersonController>();
			if ((bool)customFirstPersonController)
			{
				customFirstPersonController.baseWalkSpeed = walkSpeed;
				customFirstPersonController.baseRunSpeed = runSpeed;
			}
			else
			{
				Debug.LogWarning("Couldn't find CustomFirstPersonController", this);
			}
		}
	}
}
