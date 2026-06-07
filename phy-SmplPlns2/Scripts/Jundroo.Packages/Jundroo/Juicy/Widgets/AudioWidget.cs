using System.Xml.Linq;
using Jundroo.Juicy.Widgets.Serialization;
using UnityEngine;

namespace Jundroo.Juicy.Widgets
{
	public class AudioWidget : Widget
	{
		private string _clip;

		public AudioSource AudioSource { get; private set; }

		public string Clip
		{
			get
			{
				return _clip;
			}
			set
			{
				if (_clip != value)
				{
					_clip = value;
					AudioClip clip = null;
					if (!string.IsNullOrEmpty(_clip))
					{
						clip = base.Context.ResourceLoader.LoadAudioClip(value);
					}
					AudioSource.clip = clip;
				}
			}
		}

		protected override AttributeSet AttributeSet => AudioAttributes.Set;

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
			AudioSource = GetComponent<AudioSource>();
		}

		public void Play(bool play)
		{
			if (play)
			{
				AudioSource?.Play();
			}
			else
			{
				AudioSource?.Stop();
			}
		}
	}
}
