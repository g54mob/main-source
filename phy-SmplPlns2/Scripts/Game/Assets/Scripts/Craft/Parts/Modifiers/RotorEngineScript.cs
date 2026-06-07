using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class RotorEngineScript : PartModifierScript
	{
		public AudioSource EngineAudioSource;

		public float EngineHp;

		public float EngineTorque;

		public float GovernedEngineSpeed;

		private int _currentRpm;

		public int CurrentRpm => _currentRpm;

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			_currentRpm = (int)(base.gameObject.GetComponent<PartScript>().Aircraft.Controls.Throttle * GovernedEngineSpeed);
		}
	}
}
