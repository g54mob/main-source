using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Data.Enemies;

namespace VampireSurvivors.Objects.Characters
{
	public class FollowerEnemy_CharacterController : CharacterController
	{
		[CompilerGenerated]
		private sealed class _003CWaitForEnemyDataForAddAttackAnimations_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FollowerEnemy_CharacterController _003C_003E4__this;

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
			public _003CWaitForEnemyDataForAddAttackAnimations_003Ed__15(int _003C_003E1__state)
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
		private sealed class _003CWaitForEnemyDataForMakeLevelOne_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FollowerEnemy_CharacterController _003C_003E4__this;

			public bool dontGetCharacterDataForCurrentLevel;

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
			public _003CWaitForEnemyDataForMakeLevelOne_003Ed__9(int _003C_003E1__state)
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
		private sealed class _003CWaitForEnemyDataForSetCharacterSprite_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FollowerEnemy_CharacterController _003C_003E4__this;

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
			public _003CWaitForEnemyDataForSetCharacterSprite_003Ed__11(int _003C_003E1__state)
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
		private sealed class _003CWaitForEnemyDataForSetupAnimation_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FollowerEnemy_CharacterController _003C_003E4__this;

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
			public _003CWaitForEnemyDataForSetupAnimation_003Ed__13(int _003C_003E1__state)
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

		private EnemyData _enemyData;

		private Vector3 _OriginalScale;

		public bool HasSetName;

		private bool _needsCart;

		[SerializeField]
		private float _PowerMultiplier;

		[SerializeField]
		private float _HpMultiplier;

		public override bool NeedsCart => false;

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForEnemyDataForMakeLevelOne_003Ed__9))]
		private IEnumerator WaitForEnemyDataForMakeLevelOne(bool dontGetCharacterDataForCurrentLevel)
		{
			return null;
		}

		protected override void SetCharacterSprite()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForEnemyDataForSetCharacterSprite_003Ed__11))]
		private IEnumerator WaitForEnemyDataForSetCharacterSprite()
		{
			return null;
		}

		protected override void SetupAnimation()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForEnemyDataForSetupAnimation_003Ed__13))]
		private IEnumerator WaitForEnemyDataForSetupAnimation()
		{
			return null;
		}

		protected override void AddAttackAnimations()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForEnemyDataForAddAttackAnimations_003Ed__15))]
		private IEnumerator WaitForEnemyDataForAddAttackAnimations()
		{
			return null;
		}

		protected override void InternalUpdate()
		{
		}

		protected override void ScheduleDeathConsequences()
		{
		}

		private void Deactivate()
		{
		}

		public void Activate()
		{
		}
	}
}
