using System.Collections;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Controls
{
	public class BlockMovementOnStart : MonoBehaviour
	{
		public float Delay = 0.1f;

		public void Awake()
		{
			RuntimeGlobals.IsMovementBlocked = true;
			StartCoroutine(WakeUp());
		}

		private IEnumerator WakeUp()
		{
			yield return new WaitForSeconds(Delay);
			RuntimeGlobals.IsMovementBlocked = false;
		}
	}
}
