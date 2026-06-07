using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public interface IWheelPart
	{
		bool IsGrounded { get; }

		Vector3 WheelPosition { get; }

		float WheelRadius { get; }

		float WheelSpeed { get; }
	}
}
