using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DarkTonic.MasterAudio
{
	public static class AudioAddressableOptimizer
	{
		[CompilerGenerated]
		private sealed class _003CPopulateAddressableSongToPlaylistControllerAsync_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AssetReference addressable;

			public PlaylistController playlistController;

			public MusicSetting setting;

			public PlaylistController.AudioPlayType playType;

			private string _003CaddressableId_003E5__2;

			private AsyncOperationHandle<AudioClip> _003CloadHandle_003E5__3;

			private bool _003CshouldReleaseLoadedAssetNow_003E5__4;

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
			public _003CPopulateAddressableSongToPlaylistControllerAsync_003Ed__7(int _003C_003E1__state)
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
		private sealed class _003CPopulateSourceWithAddressableClipAsync_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AssetReference addressable;

			public Action failureAction;

			public SoundGroupVariation variation;

			public int unusedSecondsLifespan;

			public Action successAction;

			private bool _003CisWarmingCall_003E5__2;

			private string _003CaddressableId_003E5__3;

			private AsyncOperationHandle<AudioClip> _003CloadHandle_003E5__4;

			private bool _003CshouldReleaseLoadedAssetNow_003E5__5;

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
			public _003CPopulateSourceWithAddressableClipAsync_003Ed__2(int _003C_003E1__state)
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

		private static readonly Dictionary<string, AddressableTracker<AudioClip>> AddressableTasksByAddressableId;

		private static readonly object SyncRoot;

		[IteratorStateMachine(typeof(_003CPopulateSourceWithAddressableClipAsync_003Ed__2))]
		public static IEnumerator PopulateSourceWithAddressableClipAsync(AssetReference addressable, SoundGroupVariation variation, int unusedSecondsLifespan, Action successAction, Action failureAction)
		{
			return null;
		}

		public static void AddAddressablePlayingClip(AssetReference addressable, AudioSource holderSource)
		{
		}

		public static void RemoveAddressablePlayingClip(AssetReference addressable, AudioSource holderSource, bool forceRemove = false)
		{
		}

		public static void MaybeReleaseAddressable(string addressableId, bool forceRelease = false)
		{
		}

		public static bool IsAddressableValid(AssetReference addressable)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CPopulateAddressableSongToPlaylistControllerAsync_003Ed__7))]
		public static IEnumerator PopulateAddressableSongToPlaylistControllerAsync(MusicSetting setting, AssetReference addressable, PlaylistController playlistController, PlaylistController.AudioPlayType playType)
		{
			return null;
		}

		private static bool IsAnyOfAddressableClipPlaying(AssetReference addressable)
		{
			return false;
		}

		private static void ReleaseAddressableIfNoUses(AssetReference addressable, bool forceRemove = false)
		{
		}

		private static string GetAddressableId(AssetReference addressable)
		{
			return null;
		}
	}
}
