using UnityEngine;
using UnityEngine.Events;

namespace TinyGiantStudio.Text
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Tiny Giant Studio/Modular 3D Text/Toggle", 20004)]
	[HelpURL("https://ferdowsur.gitbook.io/modular-3d-text/ui/toggle")]
	public class Toggle : MonoBehaviour
	{
		[SerializeField]
		private bool _isOn;

		[Tooltip("The game object that is active when the toggle is on and inactive when the toggle is off. \n\nVariable name: onGraphic")]
		public GameObject onGraphic;

		[Tooltip("The game object that is active when the toggle is off and inactive when the toggle is on. \n\nVariable name: offGraphic")]
		public GameObject offGraphic;

		public UnityEvent onEvent;

		public UnityEvent offEvent;

		public bool IsOn
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void Set(bool set)
		{
		}

		public void ToggleState()
		{
		}

		public void CallToggleEvent()
		{
		}

		public void VisualUpdate()
		{
		}

		public void ActiveVisualUpdate()
		{
		}

		public void InactiveVisualUpdate()
		{
		}

		private void SetGraphic(GameObject graphic, bool enable)
		{
		}
	}
}
