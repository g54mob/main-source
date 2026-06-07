using UnityEngine;

namespace Assets.Nimbatus.GUI.Credits
{
	public class ToggleCredits : MonoBehaviour
	{
		public DisplayCredits Credits;

		public ECreditsType Type;

		public void OnClick()
		{
			Credits.Toggle(Type);
		}
	}
}
