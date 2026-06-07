using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public interface IExhaustSystem
	{
		GameObject GameObject { get; }

		void SetActive(bool active);

		void UpdateExhaust(float throttle);
	}
}
