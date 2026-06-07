using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public class SuperchargerComponentScript : MonoBehaviour
	{
		[SerializeField]
		private bool _enabledWithSupercharger;

		public void InitializeComponent(bool superchargerEnabled)
		{
			base.gameObject.SetActive(_enabledWithSupercharger == superchargerEnabled);
		}
	}
}
