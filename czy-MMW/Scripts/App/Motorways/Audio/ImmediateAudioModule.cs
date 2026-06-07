namespace Motorways.Audio
{
	public class ImmediateAudioModule : IAudioModule
	{
		protected AudioEnvironment Environment;

		protected AudioEventFilter Filter;

		protected string SampleName;

		protected string ModuleName;

		protected float Pan;

		protected float Gain;

		protected float Pitch;

		public AudioEventListener EventListener = new AudioEventListener();

		public ImmediateAudioModule(AudioEventFilter filter, string sampleName, float gain = 1f, float pan = -1f, string moduleName = "", float pitch = 1f)
		{
			Filter = filter;
			SampleName = sampleName;
			Pan = pan;
			Gain = gain;
			ModuleName = moduleName;
			Pitch = pitch;
		}

		public ImmediateAudioModule(AudioEventFilter filter)
		{
			Filter = filter;
		}

		public ImmediateAudioModule()
		{
		}

		public void Activate(AudioEnvironment environment)
		{
			Environment = environment;
			EventListener.Start(AddEventListeners);
			OnActivate();
		}

		public void Deactivate()
		{
			OnDeactivate();
			EventListener.Stop();
		}

		public void Release()
		{
		}

		public virtual void UpdateModule()
		{
		}

		protected virtual void OnActivate()
		{
		}

		protected virtual void OnDeactivate()
		{
		}

		protected virtual void AddEventListeners()
		{
			EventListener.Add(OnAudioEventBase, Filter);
		}

		protected virtual void OnAudioEvent(AudioEvent e)
		{
		}

		private void OnAudioEventBase(AudioEvent e)
		{
			OnAudioEvent(e);
		}
	}
}
