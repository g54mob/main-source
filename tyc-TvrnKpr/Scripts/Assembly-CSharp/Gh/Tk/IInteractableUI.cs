namespace Gh.Tk
{
	public interface IInteractableUI
	{
		bool IsInteractionSuspended { get; set; }

		bool IsHovered { get; set; }

		bool IsPressed { get; set; }

		void OnHovering();

		void OnClicked();
	}
}
