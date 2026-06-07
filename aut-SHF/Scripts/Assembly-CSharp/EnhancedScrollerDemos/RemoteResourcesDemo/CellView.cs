using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.RemoteResourcesDemo
{
	public class CellView : EnhancedScrollerCellView
	{
		[CompilerGenerated]
		private sealed class _003CLoadRemoteImage_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Data data;

			public CellView _003C_003E4__this;

			private string _003Cpath_003E5__2;

			private Texture2D _003Ctexture_003E5__3;

			private UnityWebRequest _003CwebRequest_003E5__4;

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
			public _003CLoadRemoteImage_003Ed__4(int _003C_003E1__state)
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

		public Image cellImage;

		public Sprite defaultSprite;

		private Coroutine _loadImageCoroutine;

		public void SetData(Data data)
		{
		}

		[IteratorStateMachine(typeof(_003CLoadRemoteImage_003Ed__4))]
		public IEnumerator LoadRemoteImage(Data data)
		{
			return null;
		}

		public void ClearImage()
		{
		}

		public void WillRecycle()
		{
		}
	}
}
