using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class Details : SelfInstancingMonoSingleton<Details>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRefreshTags_003Ed__54 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Details _003C_003E4__this;

			public ModProfile profile;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003CTransitionGalleryImage_003Ed__68 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Details _003C_003E4__this;

			public int index;

			private Image _003Cnext_003E5__2;

			private Image _003Ccurrent_003E5__3;

			private float _003CtimePassed_003E5__4;

			private Color _003CcolIn_003E5__5;

			private Color _003CcolFailedIcon_003E5__6;

			private Color _003CcolOut_003E5__7;

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
			public _003CTransitionGalleryImage_003Ed__68(int _003C_003E1__state)
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
		private sealed class _003CAutoRotateImages_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Details _003C_003E4__this;

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
			public _003CAutoRotateImages_003Ed__73(int _003C_003E1__state)
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

		[SerializeField]
		[Header("Mod Details Panel")]
		public GameObject ModDetailsPanel;

		[SerializeField]
		public RectTransform ModDetailsContentRect;

		[SerializeField]
		private GameObject ModDetailsGalleryLoadingAnimation;

		[SerializeField]
		private Image ModDetailsGalleryFailedToLoadIcon;

		[SerializeField]
		private Image[] ModDetailsGalleryImage;

		[SerializeField]
		private TMP_Text ModDetailsSubscribeButtonText;

		[SerializeField]
		private TMP_Text ModDetailsName;

		[SerializeField]
		private TMP_Text ModDetailsSummary;

		[SerializeField]
		private TMP_Text ModDetailsDescription;

		[SerializeField]
		private TMP_Text ModDetailsFileSize;

		[SerializeField]
		private TMP_Text ModDetailsLastUpdated;

		[SerializeField]
		private TMP_Text ModDetailsReleaseDate;

		[SerializeField]
		private TMP_Text ModDetailsSubscribers;

		[SerializeField]
		private TMP_Text ModDetailsCreatedBy;

		[SerializeField]
		private TMP_Text ModDetailsUpVotes;

		[SerializeField]
		private TMP_Text ModDetailsDownVotes;

		[SerializeField]
		private GameObject ModDetailsUpVoteActiveOverlay;

		[SerializeField]
		private GameObject ModDetailsDownVoteActiveOverlay;

		[SerializeField]
		private TMP_Text ModDetailsUpVotesActiveOverlayText;

		[SerializeField]
		private TMP_Text ModDetailsDownVotesActiveOverlayText;

		[SerializeField]
		private GameObject ModDetailsGalleryNavBar;

		[SerializeField]
		private Transform ModDetailsGalleryNavButtonParent;

		[SerializeField]
		private GameObject ModDetailsGalleryNavButtonPrefab;

		[SerializeField]
		private GameObject ModDetailsDownloadProgressDisplay;

		[SerializeField]
		private Image ModDetailsDownloadProgressFill;

		[SerializeField]
		private TMP_Text ModDetailsDownloadProgressRemaining;

		[SerializeField]
		private TMP_Text ModDetailsDownloadProgressSpeed;

		[SerializeField]
		private TMP_Text ModDetailsDownloadProgressCompleted;

		[SerializeField]
		private WrappingHorizontalLayoutGroup ModDetailsTagsGroup;

		[SerializeField]
		private GameObject ModDetailsTagsPrefab;

		private List<ListItem> _tagsListItems;

		public SubscribedProgressTab ModDetailsProgressTab;

		public GameObject ModDetailsScrollToggleGameObject;

		private bool galleryImageInUse;

		private Sprite[] ModDetailsGalleryImages;

		private bool[] ModDetailsGalleryImagesFailedToLoad;

		private int galleryPosition;

		private float galleryTransitionTime;

		private IEnumerator galleryTransition;

		private ModProfile currentModProfileBeingViewed;

		private IEnumerator downloadProgressUpdater;

		private ModRating currentAssumedRating;

		internal Translation ModDetailsSubscribeButtonTextTranslation;

		private List<ListItem> _listItems;

		private int activateNavButtonIndex;

		private Coroutine _autoRotateImagesCoroutine;

		private Action modDetailsOnCloseAction;

		private ModId detailsModIdOfLastProgressUpdate;

		private float detailsProgressTimePassed;

		private float detailsProgressTimePassed_onLastTextUpdate;

		public static bool IsOn()
		{
			return false;
		}

		internal void Open(ModProfile profile, Action actionToInvokeWhenClosed)
		{
		}

		public void Close()
		{
		}

		private void Refresh(ModProfile profile)
		{
		}

		[AsyncStateMachine(typeof(_003CRefreshTags_003Ed__54))]
		public void RefreshTags(ModProfile profile)
		{
		}

		public void SubscribeButtonPress()
		{
		}

		public void RatePositiveButtonPress()
		{
		}

		public void RateNegativeButtonPress()
		{
		}

		public void ReportButtonPress()
		{
		}

		public void UpdateRatingButtons()
		{
		}

		public void UpdateRatingButtons(ResultAnd<ModRating> response)
		{
		}

		public void UpdateRatingButtons(ModRating rating)
		{
		}

		public void UpdateSubscribeButtonText()
		{
		}

		public void UpdateDownloadProgress(ProgressHandle handle)
		{
		}

		public void GalleryImageTransition(bool showNext)
		{
		}

		internal void ShowNextGalleryImage()
		{
		}

		internal void ShowPreviousGalleryImage()
		{
		}

		private void TransitionToDifferentGalleryImage(int index)
		{
		}

		[IteratorStateMachine(typeof(_003CTransitionGalleryImage_003Ed__68))]
		private IEnumerator TransitionGalleryImage(int index)
		{
			return null;
		}

		private Image GetCurrentGalleryImageComponent()
		{
			return null;
		}

		private Image GetNextGalleryImageComponent()
		{
			return null;
		}

		private void ActivateButton(int toggledIndex)
		{
		}

		private void ListItemsCleanup()
		{
		}

		[IteratorStateMachine(typeof(_003CAutoRotateImages_003Ed__73))]
		private IEnumerator AutoRotateImages()
		{
			return null;
		}

		private void OnNavButtonClicked(int position)
		{
		}

		public static int GetPreviousIndex(int current, int length)
		{
			return 0;
		}

		public static int GetNextIndex(int current, int length)
		{
			return 0;
		}
	}
}
