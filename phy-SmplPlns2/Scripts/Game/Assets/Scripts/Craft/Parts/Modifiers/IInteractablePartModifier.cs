using Assets.Scripts.Input.Events;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public interface IInteractablePartModifier
	{
		bool InteractionDisabled { get; }

		bool IsOutlined { get; set; }

		PartTooltipPosition GetTooltipPosition();

		bool HandleInput(IInputEvent e, bool isPartStillTarget);

		string OnHover();
	}
}
