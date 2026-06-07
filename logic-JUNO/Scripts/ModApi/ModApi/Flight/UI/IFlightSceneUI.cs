using ModApi.Flight.Sim;
using UnityEngine;
using UnityEngine.UI;

namespace ModApi.Flight.UI
{
	public interface IFlightSceneUI
	{
		Canvas Canvas { get; }

		IContextMenu ContextMenu { get; }

		Image Crosshairs { get; }

		IFlightLog FlightLog { get; }

		IFlightLogUI FlightLogUI { get; }

		IFlightScene FlightScene { get; }

		IFlightTutorialPanel FlightTutorialPanel { get; }

		INavSphere NavSphere { get; }

		bool NavSphereVisible { get; }

		bool NavSphereHeadingVisible { set; }

		RectTransform Transform { get; }

		bool Visible { get; set; }

		void AddInputResponder(IInputResponder inputResponder);

		void OverrideInputResponderCapture(IInputResponder inputResponder);

		void RestoreNavSphereVisibility();

		void SetCurrentTarget(IOrbitNode targetCraftNode);

		void SetNavSphereVisibility(bool visible, bool updateSettings);

		void ShowMessage(string message, bool devlog = false, float duration = 5f);

		void ShowRewardMessage(string text, long money, int techPoints, RewardMessageSoundType sound);
	}
}
