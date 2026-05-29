namespace Animancer
{
	public abstract class MixerParameterTween<TParameter> : Key, IUpdatable, Key.IListItem
	{
		public MixerState<TParameter> Mixer { get; set; }

		public TParameter StartValue { get; set; }

		public TParameter EndValue { get; set; }

		public float Duration { get; set; }

		public float Time { get; set; }

		public float Progress
		{
			get
			{
				return Time / Duration;
			}
			set
			{
				Time = value * Duration;
			}
		}

		public bool IsActive => Key.IsInList(this);

		public MixerParameterTween()
		{
		}

		public MixerParameterTween(MixerState<TParameter> mixer)
		{
			Mixer = mixer;
		}

		public void Start(TParameter endValue, float duration)
		{
			StartValue = Mixer.Parameter;
			EndValue = endValue;
			Duration = duration;
			Time = 0f;
			Mixer.Root.RequirePreUpdate(this);
		}

		public void Stop()
		{
			Mixer?.Root?.CancelPreUpdate(this);
		}

		protected abstract TParameter CalculateCurrentValue();

		void IUpdatable.Update()
		{
			Time += AnimancerPlayable.DeltaTime;
			if (Time < Duration)
			{
				Mixer.Parameter = CalculateCurrentValue();
				return;
			}
			Time = Duration;
			Mixer.Parameter = EndValue;
			Stop();
		}
	}
}
