using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Timers;
using Gh.Tk;

namespace Gh
{
	public static class DevCommentaryManager
	{
		private static readonly Timer _minuteTimer;

		private static Dictionary<string, DevCommentaryMetadata> _devCommentaries;

		private static Dictionary<string, DevCommentaryMetadata[]> _devCommentariesByVisibilityGroup;

		public static bool IsInstalled => false;

		public static bool IsEnabled => false;

		public static DevCommentaryMetadata CurrentlyPlaying => null;

		public static Dictionary<string, DevCommentaryMetadata> DevCommentaries => null;

		public static Dictionary<string, DevCommentaryMetadata[]> DevCommentariesByVisibilityGroup => null;

		public static event EventHandler IsEnabledChanged
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

		public static event EventHandler<EventArgs<string>> DevCommentaryCompleted
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

		public static event EventHandler DevCommentaryPlayingStateChanged
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

		public static event EventHandler DevCommentaryNodeVisibilityModeChanged
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

		static DevCommentaryManager()
		{
		}

		private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
		{
		}

		public static void Init()
		{
		}

		private static void ProfileChanged(object sender, EventArgs<PlayerProfile> e)
		{
		}

		public static bool IsCompleted(string commentaryId)
		{
			return false;
		}

		public static void RaiseDevCommentaryCompleted(string id)
		{
		}

		public static void InvalidateEnabledState()
		{
		}

		public static void PlayDevCommentary(string commentaryId)
		{
		}

		public static bool IsPlayingAny()
		{
			return false;
		}

		public static void RaiseDevCommentaryPlayingStateChanged()
		{
		}

		public static void RaiseDevCommentaryNodeVisibilityModeChanged()
		{
		}
	}
}
