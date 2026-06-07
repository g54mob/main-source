using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Video;

namespace Gh.Tk.UI
{
	public class VideoBlock3DUIView : BaseBlock3DUIView, BaseBlock3DUIView.IEarlyColliderResizable, BaseBlock3DUIView.IColliderResizable, BaseBlock3DUIView.ILateColliderResizable
	{
		[CompilerGenerated]
		private sealed class _003CWaitForVideo_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VideoBlock3DUIView _003C_003E4__this;

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
			public _003CWaitForVideo_003Ed__12(int _003C_003E1__state)
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

		public VideoPlayer videoPlayer;

		public Renderer videoRenderer;

		public SpriteRenderer videoFrame;

		public float frameThickness;

		public Transform videoImage;

		public Transform loadingPlaceholder;

		public float scale;

		public float maxWidth;

		private Coroutine _videoCoroutine;

		public override void SetBlockData(string imageId)
		{
		}

		private void LoadVideo()
		{
		}

		private void OnDisable()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForVideo_003Ed__12))]
		private IEnumerator WaitForVideo()
		{
			return null;
		}

		public void ResizeColliderToContent()
		{
		}

		public float GetColliderWidth()
		{
			return 0f;
		}

		public void ResizeColliderToMaxWidth(float maxWidth)
		{
		}
	}
}
