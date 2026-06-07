using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Fuselage
{
	public class FuselageEnabledScript : MonoBehaviour
	{
		[SerializeField]
		private bool _enabledWhenMirrored;

		public bool EnabledWhenMirrored => _enabledWhenMirrored;
	}
}
