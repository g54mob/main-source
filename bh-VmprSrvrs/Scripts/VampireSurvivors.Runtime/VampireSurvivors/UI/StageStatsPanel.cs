using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI
{
	public class StageStatsPanel : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndCheckPages_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public StageStatsPanel _003C_003E4__this;

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
			public _003CWaitAndCheckPages_003Ed__24(int _003C_003E1__state)
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
		private StageStatUI _TimeLimit;

		[SerializeField]
		private StageStatUI _ClockSpeed;

		[SerializeField]
		private StageStatUI _MoveSpeed;

		[SerializeField]
		private StageStatUI _GoldBonus;

		[SerializeField]
		private StageStatUI _LuckBonus;

		[SerializeField]
		private StageStatUI _EnemyHealth;

		[SerializeField]
		private StageStatUI _Description;

		[SerializeField]
		private StageStatUI _XPBonus;

		[SerializeField]
		private GameObject _DescriptionPage;

		[SerializeField]
		private Button _PreviousPage;

		[SerializeField]
		private Button _NextPage;

		private StageData _currentStage;

		private StageType _currentType;

		private bool _hyperSelected;

		private bool _hurrySelected;

		private bool _inverseSelected;

		private Color _darkRed;

		private PlayerOptions _playerOptions;

		private int _pageCount;

		public void SetHyper(bool b)
		{
		}

		public void SetHurry(bool b)
		{
		}

		public void SetInverse(bool b)
		{
		}

		public void SetPlayerOptions(PlayerOptions playerOptions)
		{
		}

		public void Refresh()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndCheckPages_003Ed__24))]
		private IEnumerator WaitAndCheckPages()
		{
			return null;
		}

		private bool ShowHyperInfo()
		{
			return false;
		}

		public void SetStage(StageData stage, StageType t, PlayerOptions playerOptions)
		{
		}

		private void SetTimeLimit()
		{
		}

		private void SetClockSpeed()
		{
		}

		private void SetMoveSpeed()
		{
		}

		private void SetGoldBonus()
		{
		}

		private void SetLuckBonus()
		{
		}

		private void SetEnemyHealth()
		{
		}

		private void SetDescription()
		{
		}

		private void SetXPBonus()
		{
		}
	}
}
