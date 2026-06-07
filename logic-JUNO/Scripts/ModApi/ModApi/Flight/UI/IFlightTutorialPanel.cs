using System;
using UnityEngine;

namespace ModApi.Flight.UI
{
	public interface IFlightTutorialPanel
	{
		string InstructionText { get; set; }

		string StepText { get; set; }

		bool Visible { get; set; }

		void DisableButton();

		void DisableHighlight();

		void EnableButton(Action action, bool highlight = true);

		bool HighlightUiElement(string name, Vector2 padding, bool highlightEvenIfInactive = false);
	}
}
