using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class Report2Weapon : ReportWeapon
	{
		[CompilerGenerated]
		private sealed class _003CPerformVote_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Report2Weapon _003C_003E4__this;

			public List<EnemyType> enemyTypes;

			private float _003Ct_003E5__2;

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
			public _003CPerformVote_003Ed__18(int _003C_003E1__state)
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
		private GameObject _votingScreenDisplay;

		[SerializeField]
		private Report2VotingScreenOption _votingScreenOptionPrefab;

		[SerializeField]
		private Transform _votingScreenOptionsContainer;

		[SerializeField]
		private SpriteRenderer _votingScreenBackground;

		private List<Report2VotingScreenOption> _votingOptions;

		private int _voteTarget;

		private float _votingTimer;

		private bool _isVotingScreenOpen;

		private float _votingDelay;

		private MultiTargetTween _screenShakeTween;

		private bool _shouldBeVisible;

		public float VotingInterval()
		{
			return 0f;
		}

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void EmergencyMeeting()
		{
		}

		private void ShowVotingScreen()
		{
		}

		public void OnlinePerformVote(List<EnemyType> enemyTypes, int voteTarget)
		{
		}

		[IteratorStateMachine(typeof(_003CPerformVote_003Ed__18))]
		private IEnumerator PerformVote(List<EnemyType> enemyTypes)
		{
			return null;
		}

		private float GetTargetVotingScreenDisplayLocalYPos()
		{
			return 0f;
		}

		private void EraseEnemyType(EnemyType type)
		{
		}

		private void HideVotingScreen()
		{
		}

		private void ScreenShake()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
