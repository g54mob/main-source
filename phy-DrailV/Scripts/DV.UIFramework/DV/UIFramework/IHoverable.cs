using UnityEngine;

namespace DV.UIFramework
{
	public interface IHoverable
	{
		bool IsInteractable { get; }

		bool IsHovered { get; }

		bool IsMouseOvered { get; }

		event InteractabilityChangedDelegate InteractabilityChanged;

		event HoverChangedDelegate HoverChanged;

		event HoverChangedDelegate MouseOverChanged;

		void ToggleInteractable(bool newInteractable);

		void Hover();

		void Unhover();

		GameObject GetGameObject();
	}
}
