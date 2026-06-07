using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class AccessoryLEM_ACC_SABOTEUR : AccessoryTP_FREESLOT_FOLLOWER
	{
		[CompilerGenerated]
		private sealed class _003C_UpdateFace_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AccessoryLEM_ACC_SABOTEUR _003C_003E4__this;

			public PhaserSprite saboteurFace;

			public CharacterController owner;

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
			public _003C_UpdateFace_003Ed__7(int _003C_003E1__state)
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

		public List<CharacterType> excludedCharacters;

		private PhaserSprite saboteurFace;

		public override bool LevelUp(bool skipFire = false)
		{
			return false;
		}

		protected override void MakeLevelOne()
		{
		}

		protected void GiveCoins(float value)
		{
		}

		public void AddAnimation_Saboteur()
		{
		}

		private void UpdateFace(PhaserSprite saboteurFace, CharacterController owner)
		{
		}

		[IteratorStateMachine(typeof(_003C_UpdateFace_003Ed__7))]
		private IEnumerator _UpdateFace(PhaserSprite saboteurFace, CharacterController owner)
		{
			return null;
		}
	}
}
