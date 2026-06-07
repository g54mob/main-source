using Assets.Scripts.Input.Events;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class MfdScreenInputHandlerScript : MonoBehaviour, IInteractablePartModifier
	{
		private MfdScript _mfd;

		public bool InteractionDisabled => false;

		public bool IsOutlined { get; set; }

		public PartTooltipPosition GetTooltipPosition()
		{
			return default(PartTooltipPosition);
		}

		public bool HandleInput(IInputEvent e, bool isPartStillTarget)
		{
			return false;
		}

		public string OnHover()
		{
			return string.Empty;
		}

		protected virtual void Start()
		{
			_mfd = GetComponentInParent<MfdScript>();
			base.gameObject.layer = 16;
		}
	}
}
