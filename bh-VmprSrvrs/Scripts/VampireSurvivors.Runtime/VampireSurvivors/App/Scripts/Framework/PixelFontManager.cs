using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Profiling;
using UnityEngine;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.App.Scripts.Framework
{
	public class PixelFontManager : GameTickable, IInitializable, IDisposable
	{
		[CompilerGenerated]
		private sealed class _003CDelayedForce_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

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
			public _003CDelayedForce_003Ed__20(int _003C_003E1__state)
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

		private static Material _defaultMaterial;

		private static int _fontSizePropId;

		private static int _alphaCutoffBoostPropId;

		private static readonly ProfilerMarker MarkerOnTextChanged;

		private static List<int> _ignoreOnce;

		private static Dictionary<TextMeshProUGUI, TextCache> _textCache;

		private static bool _dirty;

		private static List<TextMeshProUGUI> _cacheToRemove;

		private static int _tickCount;

		private static PlayerOptions _playerOptions;

		[Inject]
		private void Construct(PlayerOptions playerOptions)
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		protected override void OnTick()
		{
		}

		private static void TriggerListener()
		{
		}

		public static void SetDirty(bool value)
		{
		}

		public static void TurnOn()
		{
		}

		public static void TurnOff()
		{
		}

		private static void ForceApply()
		{
		}

		public static void ClearCache()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedForce_003Ed__20))]
		private static IEnumerator DelayedForce()
		{
			return null;
		}

		private static void ON_TEXT_CHANGED(UnityEngine.Object obj)
		{
		}
	}
}
