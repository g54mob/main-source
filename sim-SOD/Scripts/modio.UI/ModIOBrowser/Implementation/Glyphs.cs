using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ModIO.Util;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	internal class Glyphs : SelfInstancingMonoSingleton<Glyphs>
	{
		[CompilerGenerated]
		private sealed class _003CInternalSetColor_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Glyphs _003C_003E4__this;

			public Action<Color> setter;

			public ColorSetterType colorSetter;

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
			public _003CInternalSetColor_003Ed__11(int _003C_003E1__state)
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

		private ColorScheme colorScheme;

		public Color glyphColorFallback;

		public Sprite fallbackSprite;

		public Color fallbackColor;

		private bool hasStarted;

		public GlyphPlatforms PlatformType { get; internal set; }

		private void Start()
		{
		}

		public void SetColor(ColorSetterType colorSetter, Action<Color> setter)
		{
		}

		[IteratorStateMachine(typeof(_003CInternalSetColor_003Ed__11))]
		private IEnumerator InternalSetColor(ColorSetterType colorSetter, Action<Color> setter)
		{
			return null;
		}

		public Color GetColor(ColorSetterType colorSetter)
		{
			return default(Color);
		}

		public void ChangeGlyphs(GlyphPlatforms platform)
		{
		}

		[ExposeMethodInEditor]
		public void ChangeToPc()
		{
		}

		[ExposeMethodInEditor]
		public void ChangeToXbox()
		{
		}

		[ExposeMethodInEditor]
		public void ChangeToNintendoSwitch()
		{
		}

		[ExposeMethodInEditor]
		public void ChangeToPs4()
		{
		}

		[ExposeMethodInEditor]
		public void ChangeToPs5()
		{
		}
	}
}
