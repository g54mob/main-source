using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts
{
	public class ResetUsedTags : MonoBehaviour
	{
		public void OnClick()
		{
			KeyBinding.ResetUsedTags();
		}
	}
}
