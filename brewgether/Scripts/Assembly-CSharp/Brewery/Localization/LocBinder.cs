using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.Localization
{
	[RequireComponent(typeof(UIDocument))]
	public class LocBinder : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelayedBind_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LocBinder _003C_003E4__this;

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
			public _003CDelayedBind_003Ed__6(int _003C_003E1__state)
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

		private const float FadeInDuration = 0.25f;

		private UIDocument _uiDocument;

		private VisualElement _root;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedBind_003Ed__6))]
		private IEnumerator DelayedBind()
		{
			return null;
		}

		public void RebindAll()
		{
		}

		public static void BindAll(VisualElement root)
		{
		}

		public static void Bind(TextElement element, string table, string key)
		{
		}

		private static void SetupFadeIn(VisualElement element)
		{
		}
	}
}
