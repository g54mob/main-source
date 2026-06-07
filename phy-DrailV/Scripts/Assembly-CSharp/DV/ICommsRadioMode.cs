using UnityEngine;

namespace DV
{
	public interface ICommsRadioMode
	{
		ButtonBehaviourType ButtonBehaviour { get; }

		void Enable();

		void Disable();

		void OverrideSignalOrigin(Transform signalOrigin);

		void OnUse();

		void OnUpdate();

		bool ButtonACustomAction();

		bool ButtonBCustomAction();

		void SetStartingDisplay();

		Color GetLaserBeamColor();
	}
}
