using Motorways.Models;
using Motorways.Views.Boats;

namespace Motorways.Audio
{
	public class Boat : Playback
	{
		public class AudioBoatMotor : FX.Modulator
		{
			private float _pan;

			private float _attenuation;

			private BoatView BoatView { get; set; }

			private AudioSample Sample { get; set; }

			public override float Pan => _pan;

			public override float Gain => 0.25f * _attenuation;

			public AudioBoatMotor(BoatView v)
			{
				BoatView = v;
				Start();
			}

			public override void OnGameTick()
			{
				_pan = BoatView.Pan.x;
				_attenuation = BoatView.Attenuation;
			}

			public void Stop()
			{
				if (Sample != null)
				{
					Sample.FadeOutAndStop((Get.Game.GetTimeScale() == TimeScale.Single) ? 2.25f : 1.5f);
					Sample.DynamicMix = null;
					Sample = null;
				}
			}

			public void Start()
			{
				Sample = AudioPlayer.UI.PlaySample("boat-loop", BoatView.Pan.x, 0.5625f, 1f, (Get.Game.GetTimeScale() == TimeScale.Single) ? 2.25f : 1.5f, -1.0, loop: true, this, stereo: false, randomStart: true);
			}
		}

		private readonly BoatView _boatView;

		private BoatModel.BehaviorState _lastState;

		private AudioSample _engineSample;

		private readonly AudioBoatMotor _boatMotor;

		public Boat(BoatView view)
		{
			_boatView = view;
			_boatMotor = new AudioBoatMotor(_boatView);
		}

		public override void Update()
		{
			if (Get.State.HasAny(StateType.GameOver) || Get.Game.Simulation.IsPaused)
			{
				_boatMotor.Stop();
				return;
			}
			BoatModel model = _boatView.Model;
			_boatMotor?.OnGameTick();
			if (_lastState != model.state)
			{
				switch (model.state)
				{
				case BoatModel.BehaviorState.Stopping:
					_boatMotor?.Stop();
					break;
				case BoatModel.BehaviorState.Undocking:
				{
					string text = Note.SCALE[Get.Loadout.MusicData.CurrentScale.Key];
					double dspTime = Get.Pulse.QuantizedTime(0.25);
					AudioPlayer.Default.PlaySample("boat-horn-dry-" + text, _boatView.Pan.x, 0.4f * _boatView.Attenuation, 1f, 0.0, dspTime);
					AudioPlayer.Default.PlaySample("boat-horn-wet-" + text, 0.5f, 0.16f * _boatView.Attenuation, 1f, 0.0, dspTime, loop: false, null, stereo: true);
					break;
				}
				case BoatModel.BehaviorState.Sailing:
					_boatMotor?.Start();
					break;
				}
			}
			_lastState = model.state;
		}
	}
}
