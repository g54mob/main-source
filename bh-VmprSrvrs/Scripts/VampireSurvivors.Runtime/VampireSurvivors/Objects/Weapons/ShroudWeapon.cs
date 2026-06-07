using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons
{
	public class ShroudWeapon : Weapon
	{
		[CompilerGenerated]
		private sealed class _003CDelayAFrame_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ShroudWeapon _003C_003E4__this;

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
			public _003CDelayAFrame_003Ed__9(int _003C_003E1__state)
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
		private SpriteRenderer _Renderer;

		private Sequence _fadeTween;

		private Tween _angleTween;

		private int _maxCharges;

		private bool _hasThorns;

		private float _lastReceivedDamage;

		private bool _wasActiveOnMadeInvisible;

		public override float PPower()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		[IteratorStateMachine(typeof(_003CDelayAFrame_003Ed__9))]
		private IEnumerator DelayAFrame()
		{
			return null;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void Cleanup()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override void SetVisible(bool visible)
		{
		}

		protected override void OnStart()
		{
		}

		private void OnLostShield(GameplaySignals.CharacterLostShieldSignal sig)
		{
		}

		private void CheckColor(GameplaySignals.CharacterLostShieldSignal sig)
		{
		}
	}
}
