using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ModIO;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class FeaturedModListItem : ListItem
	{
		[CompilerGenerated]
		private sealed class _003CTransition_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FeaturedModListItem _003C_003E4__this;

			public RectTransform end;

			public Vector2 start;

			private RectTransform _003CrectTransform_003E5__2;

			private Vector2 _003CstartingSize_003E5__3;

			private Vector2 _003Cdistance_003E5__4;

			private Vector2 _003Cgrowth_003E5__5;

			private float _003CtimePassed_003E5__6;

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
			public _003CTransition_003Ed__14(int _003C_003E1__state)
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
		private Image image;

		[SerializeField]
		private GameObject background;

		[SerializeField]
		private GameObject failedToLoad;

		public SubscribedProgressTab progressTab;

		public int rowIndex;

		public int profileIndex;

		private static float transitionTime;

		public AnimationCurve animationCurve;

		private IEnumerator transition;

		internal static int transitionCount;

		public override void PlaceholderSetup()
		{
		}

		public override void Setup(ModProfile profile)
		{
		}

		private void SetIcon(ResultAnd<Texture2D> resultAndTexture)
		{
		}

		public void Transition(RectTransform start, RectTransform end)
		{
		}

		[IteratorStateMachine(typeof(_003CTransition_003Ed__14))]
		private IEnumerator Transition(Vector2 start, RectTransform end)
		{
			return null;
		}
	}
}
