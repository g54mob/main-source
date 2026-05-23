using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DarkTonic.MasterAudio
{
	public static class AudioResourceOptimizer
	{
		[CompilerGenerated]
		private sealed class _003CPopulateResourceSongToPlaylistControllerAsync_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string songResourceName;

			public string playlistName;

			public PlaylistController controller;

			public MusicSetting songSetting;

			public PlaylistController.AudioPlayType playType;

			private ResourceRequest _003CasyncRes_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CPopulateResourceSongToPlaylistControllerAsync_003Ed__11(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CPopulateSourcesWithResourceClipAsync_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string clipName;

			public Action successAction;

			public SoundGroupVariation variation;

			public Action failureAction;

			private bool _003CisWarmingCall_003E5__2;

			private ResourceRequest _003CasyncRes_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CPopulateSourcesWithResourceClipAsync_003Ed__12(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private static readonly Dictionary<string, List<AudioSource>> AudioResourceTargetsByName;

		private static readonly Dictionary<string, AudioClip> AudioClipsByName;

		private static readonly Dictionary<string, List<AudioClip>> PlaylistClipsByPlaylistName;

		private static string _supportedLanguageFolder;

		public static void ClearAudioClips()
		{
		}

		public static string GetLocalizedDynamicSoundGroupFileName(SystemLanguage localLanguage, bool useLocalization, string resourceFileName)
		{
			return null;
		}

		public static string GetLocalizedFileName(bool useLocalization, string resourceFileName)
		{
			return null;
		}

		public static void AddTargetForClip(string clipName, AudioSource source)
		{
		}

		private static string SupportedLanguageFolder()
		{
			return null;
		}

		public static void ClearSupportLanguageFolder()
		{
		}

		private static void FinishRecordingPlaylistClip(string controllerName, AudioClip resAudioClip)
		{
		}

		[IteratorStateMachine(typeof(_003CPopulateResourceSongToPlaylistControllerAsync_003Ed__11))]
		public static IEnumerator PopulateResourceSongToPlaylistControllerAsync(MusicSetting songSetting, string songResourceName, string playlistName, PlaylistController controller, PlaylistController.AudioPlayType playType)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPopulateSourcesWithResourceClipAsync_003Ed__12))]
		public static IEnumerator PopulateSourcesWithResourceClipAsync(string clipName, SoundGroupVariation variation, Action successAction, Action failureAction)
		{
			return null;
		}

		public static void UnloadPlaylistSongIfUnused(string controllerName, AudioClip clipToRemove)
		{
		}

		public static void DeleteAudioSourceFromList(string clipName, AudioSource source)
		{
		}

		public static void UnloadClipIfUnused(string clipName)
		{
		}
	}
}
