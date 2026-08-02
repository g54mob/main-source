using UnityEngine;

namespace FishingGameTool.Example
{
	public class ItemInfo : MonoBehaviour
	{
		public CharacterMovement _characterMovement;

		private void Update()
		{
			base.transform.rotation = Quaternion.LookRotation(base.transform.position - _characterMovement.GetCurrentCam().position);
		}
	}
}
