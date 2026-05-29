using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AeLa.EasyFeedback.Utility
{
	public static class ScreenshotUtil
	{
		[CompilerGenerated]
		private sealed class _003CCaptureScreenshotAsTexture_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public bool resizeLargeScreenshots;

			public Action<byte[]> onCapturedCallback;

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
			public _003CCaptureScreenshotAsTexture_003Ed__3(int _003C_003E1__state)
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
		private sealed class _003CCaptureScreenshotLegacy_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Action<byte[]> onCapturedCallback;

			public Action<string> onErrorCallback;

			private string _003CscreenshotPath_003E5__2;

			private Exception _003Cexception_003E5__3;

			private byte[] _003Cfile_003E5__4;

			private int _003Ci_003E5__5;

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
			public _003CCaptureScreenshotLegacy_003Ed__4(int _003C_003E1__state)
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

		private const int BixTex = 4082;

		private const float TexDimensionMax = 1920f;

		public static IEnumerator CaptureScreenshot(ScreenshotMode mode, bool resizeLargeScreenshots, Action<byte[]> onCapturedCallback, Action<string> onErrorCallback)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CCaptureScreenshotAsTexture_003Ed__3))]
		private static IEnumerator CaptureScreenshotAsTexture(bool resizeLargeScreenshots, Action<byte[]> onCapturedCallback)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CCaptureScreenshotLegacy_003Ed__4))]
		private static IEnumerator CaptureScreenshotLegacy(Action<byte[]> onCapturedCallback, Action<string> onErrorCallback)
		{
			return null;
		}
	}
}
