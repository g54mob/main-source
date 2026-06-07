namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class AudioAttributes
	{
		public static AttributeSet Set { get; private set; }

		static AudioAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
			set.AddString("clip", delegate(AudioWidget w, string x)
			{
				w.Clip = x;
			});
			set.AddBool("loop", delegate(AudioWidget w, bool x)
			{
				w.AudioSource.loop = x;
			});
			set.AddBool("mute", delegate(AudioWidget w, bool x)
			{
				w.AudioSource.mute = x;
			});
			set.AddBool("play", delegate(AudioWidget w, bool x)
			{
				w.Play(x);
			});
			set.AddBool("playOnAwake", delegate(AudioWidget w, bool x)
			{
				w.AudioSource.playOnAwake = x;
			});
			set.AddFloat("pitch", delegate(AudioWidget w, float x)
			{
				w.AudioSource.pitch = x;
			}, (AudioWidget w) => w.AudioSource.pitch);
			set.AddFloat("volume", delegate(AudioWidget w, float x)
			{
				w.AudioSource.volume = x;
			}, (AudioWidget w) => w.AudioSource.volume);
		}
	}
}
