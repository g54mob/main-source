using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Graphics.RenderPass;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages
{
	[UsedImplicitly]
	public class BackgroundWater : BackgroundManager
	{
		[CompilerGenerated]
		private sealed class _003CInitFishEye_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BackgroundWater _003C_003E4__this;

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
			public _003CInitFishEye_003Ed__18(int _003C_003E1__state)
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

		private bool _canTriggerEclipse;

		private SpriteRenderer _water;

		private TileSprite _bgTile;

		private SpriteRenderer _moonPresence;

		private SpriteRenderer _fader;

		private SpriteRenderer _sDarkness;

		private FishEyeRenderFeature _fishEyeRenderFeature;

		private Timer _destructibleTimer;

		private Sequence _waterBgmTween;

		private static readonly int Intensity;

		private static readonly int Radius;

		private static readonly int Mode;

		private static readonly int TexSize;

		private static readonly int Center;

		protected override void OnUpdate()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void Create()
		{
		}

		private void OnRemoteEnemySpawned(EnemyController enemy)
		{
		}

		[IteratorStateMachine(typeof(_003CInitFishEye_003Ed__18))]
		private IEnumerator InitFishEye()
		{
			return null;
		}

		private void CharacterDied()
		{
		}

		private void RestoreEclipse()
		{
		}

		private void RemoveEclipse()
		{
		}

		private void SpawnHealer()
		{
		}

		private void SpawnEggman()
		{
		}

		private void StartEclipse()
		{
		}

		private void Cry()
		{
		}

		private void SendToHiddenGround()
		{
		}

		public void TransitionToHolyForbidden()
		{
		}

		private void SpawnAnforaCluster()
		{
		}

		private Vector2 GetPositionOutOfSight(float inPlayerDirectionAngle)
		{
			return default(Vector2);
		}

		public override void DisableMovingBackground()
		{
		}

		public override void EnableMovingBackground()
		{
		}
	}
}
