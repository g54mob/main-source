using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public interface IExhaustSystem
	{
		GameObject GameObject { get; }

		float NozzleRadius { get; set; }

		void SetActive(bool active);

		void UpdateExhaust(float throttle, float afterburnerThrottle);
	}
}
