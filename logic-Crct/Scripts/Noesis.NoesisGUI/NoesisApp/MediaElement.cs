using System;
using Noesis;

namespace NoesisApp
{
	public class MediaElement : Decorator
	{
		public static readonly DependencyProperty SourceProperty;

		public static readonly DependencyProperty LoadedBehaviorProperty;

		public static readonly DependencyProperty UnloadedBehaviorProperty;

		public static readonly DependencyProperty StretchProperty;

		public static readonly DependencyProperty StretchDirectionProperty;

		public static readonly DependencyProperty BalanceProperty;

		public static readonly DependencyProperty VolumeProperty;

		public static readonly DependencyProperty IsMutedProperty;

		public static readonly DependencyProperty ScrubbingEnabledProperty;

		private TimeSpan _position;

		private float _speedRatio;

		private static CreateMediaPlayerCallback _createMediaPlayerCallback;

		private static object _createMediaPlayerUser;

		private MediaPlayer _player;

		private MediaState _state;

		public Uri Source
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public MediaState LoadedBehavior
		{
			get
			{
				return default(MediaState);
			}
			set
			{
			}
		}

		public MediaState UnloadedBehavior
		{
			get
			{
				return default(MediaState);
			}
			set
			{
			}
		}

		public Stretch Stretch
		{
			get
			{
				return default(Stretch);
			}
			set
			{
			}
		}

		public StretchDirection StretchDirection
		{
			get
			{
				return default(StretchDirection);
			}
			set
			{
			}
		}

		public float Balance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Volume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool IsMuted
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsBuffering { get; private set; }

		public float BufferingProgress => 0f;

		public float DownloadProgress => 0f;

		public bool ScrubbingEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public uint NaturalVideoWidth => 0u;

		public uint NaturalVideoHeight => 0u;

		public Duration NaturalDuration => default(Duration);

		public TimeSpan Position
		{
			get
			{
				return default(TimeSpan);
			}
			set
			{
			}
		}

		public float SpeedRatio
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool CanPause => false;

		public bool HasAudio => false;

		public bool HasVideo => false;

		public event RoutedEventHandler BufferingStarted
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler BufferingEnded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler MediaOpened
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler MediaEnded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ExceptionRoutedEventHandler MediaFailed
		{
			add
			{
			}
			remove
			{
			}
		}

		public MediaElement()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public static void SetCreateMediaPlayerCallback(CreateMediaPlayerCallback callback, object user)
		{
		}

		private static void OnStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private static void OnBalanceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private static void OnVolumeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private static void OnIsMutedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private static void OnScrubbingEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		public void Play()
		{
		}

		public void Pause()
		{
		}

		public void Stop()
		{
		}

		public void Close()
		{
		}

		private void SetState(MediaState state)
		{
		}

		private void UpdateState(MediaState action, bool sourceChanged)
		{
		}

		private void CreateMediaPlayer(Uri source)
		{
		}

		private void DestroyMediaPlayer()
		{
		}

		private void OnLoadStateChanged(object sender, RoutedEventArgs e)
		{
		}

		private void OnBufferingStarted()
		{
		}

		private void OnBufferingEnded()
		{
		}

		private void OnMediaOpened()
		{
		}

		private void OnMediaEnded()
		{
		}

		private void OnMediaFailed(Exception error)
		{
		}
	}
}
