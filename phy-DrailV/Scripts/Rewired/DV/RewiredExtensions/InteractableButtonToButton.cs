using Rewired.UI.ControlMapper;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RewiredExtensions
{
	public class InteractableButtonToButton : MonoBehaviour
	{
		public CustomButton from;

		public Selectable to;

		private void Awake()
		{
			from.InteractableChanged += delegate(bool interactable)
			{
				to.interactable = interactable;
			};
		}
	}
}
