using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class ButtonToggleActive : MonoBehaviour
	{
		public GameObject Target;

		public void OnClick()
		{
			if (Target != null)
			{
				bool activeInHierarchy = Target.activeInHierarchy;
				NGUITools.SetActive(Target, !activeInHierarchy);
			}
		}
	}
}
