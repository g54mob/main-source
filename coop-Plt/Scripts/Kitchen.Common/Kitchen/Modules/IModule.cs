using Controllers;
using UnityEngine;

namespace Kitchen.Modules
{
	public interface IModule
	{
		Vector2 Position { get; set; }

		Bounds BoundingBox { get; }

		bool IsSelectable { get; }

		void GainFocus();

		void LoseFocus();

		bool HandleInteraction(InputState state);

		void Destroy();
	}
}
