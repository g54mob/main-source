using System;
using System.Runtime.CompilerServices;
using Noesis;

namespace NoesisApp
{
	public abstract class MediaPlayer
	{
		public virtual uint Width => 0u;

		public virtual uint Height => 0u;

		public virtual bool CanPause => false;

		public virtual bool HasAudio => false;

		public virtual bool HasVideo => false;

		public virtual float BufferingProgress => 0f;

		public virtual float DownloadProgress => 0f;

		public virtual double Duration => 0.0;

		public virtual double Position
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public virtual float SpeedRatio
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual float Volume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual float Balance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual bool IsMuted
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool ScrubbingEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public abstract ImageSource TextureSource { get; }

		public event BufferingStartedHandler BufferingStarted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event BufferingEndedHandler BufferingEnded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event MediaOpenedHandler MediaOpened
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event MediaEndedHandler MediaEnded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event MediaFailedHandler MediaFailed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public virtual void Play()
		{
		}

		public virtual void Pause()
		{
		}

		public virtual void Stop()
		{
		}

		public virtual void Close()
		{
		}

		protected void RaiseBufferingStarted()
		{
		}

		protected void RaiseBufferingEnded()
		{
		}

		protected void RaiseMediaOpened()
		{
		}

		protected void RaiseMediaEnded()
		{
		}

		protected void RaiseMediaFailed(Exception error)
		{
		}
	}
}
