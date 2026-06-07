using UnityEngine;

namespace Assets.Nimbatus.GUI.SandboxSettings.Scripts
{
	public abstract class SandboxSettingsUi : MonoBehaviour
	{
		public Color ActiveColor = Color.white;

		public Color InactiveColor = Color.grey;

		public UILabel NameLabel;

		public abstract void Activate(bool active);
	}
}
