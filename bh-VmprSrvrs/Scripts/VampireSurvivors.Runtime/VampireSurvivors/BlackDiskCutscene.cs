using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics.Blitters;
using VampireSurvivors.Objects.Characters.Enemies;

namespace VampireSurvivors
{
	public class BlackDiskCutscene
	{
		[CompilerGenerated]
		private sealed class _003C_BlackDiskCutscene_003Ed__0 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Enemy_TP_Death death;

			private PhaserSprite _003CblackBackground_003E5__2;

			private PhaserSprite _003CnoMask_003E5__3;

			private List<Sprite> _003CspriteList_003E5__4;

			private Blitter _003Cblitter_003E5__5;

			private PhaserSprite _003Cdisk_003E5__6;

			private TweenerCore<Quaternion, Vector3, QuaternionOptions> _003Cspin_003E5__7;

			private float _003CbeatLength_003E5__8;

			private float _003Ctimer_003E5__9;

			private float _003Cduration_003E5__10;

			private int _003ClastBeat_003E5__11;

			private int _003Ci_003E5__12;

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
			public _003C_BlackDiskCutscene_003Ed__0(int _003C_003E1__state)
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

		[IteratorStateMachine(typeof(_003C_BlackDiskCutscene_003Ed__0))]
		public static IEnumerator _BlackDiskCutscene(Enemy_TP_Death death)
		{
			return null;
		}

		private static void AddBobs(Blitter blitter, int amount, List<Sprite> spriteList)
		{
		}

		private static void BlitterBounce(Blitter blitter, float left, float right, float top, float bottom, float alpha)
		{
		}
	}
}
