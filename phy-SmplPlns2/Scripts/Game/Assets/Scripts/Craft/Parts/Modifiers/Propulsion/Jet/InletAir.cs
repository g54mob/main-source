using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class InletAir
	{
		private float _availableAir;

		private float _usedAir;

		public float AirEfficiency { get; private set; }

		public float AvailableAir => _availableAir;

		public void AddAir(float air)
		{
			_availableAir += air;
		}

		public void Update()
		{
			if (_usedAir > 0f)
			{
				AirEfficiency = Mathf.Clamp01(_availableAir / _usedAir);
			}
			else
			{
				AirEfficiency = 1f;
			}
			_usedAir = 0f;
			_availableAir = 0f;
		}

		public void UseAir(float air)
		{
			_usedAir += air;
		}
	}
}
