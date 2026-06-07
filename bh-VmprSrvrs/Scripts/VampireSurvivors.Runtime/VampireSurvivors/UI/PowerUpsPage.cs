using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class PowerUpsPage : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndGenerateNavigation_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PowerUpsPage _003C_003E4__this;

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
			public _003CWaitAndGenerateNavigation_003Ed__31(int _003C_003E1__state)
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
		private Localize Name;

		[SerializeField]
		private Localize Description;

		[SerializeField]
		private Image Icon;

		[SerializeField]
		private PriceUI Price;

		[SerializeField]
		private GameObject PowerUpPrefab;

		[SerializeField]
		private GameObject BuyButton;

		[SerializeField]
		private GameObject CompleteText;

		[SerializeField]
		private Image Background;

		[SerializeField]
		private Color MaxColor;

		[SerializeField]
		private Image _Frame;

		[SerializeField]
		private Button _RefundButton;

		[SerializeField]
		private TickBoxUI _ActiveTickBox;

		private PlayerOptions _playerOptions;

		private DataManager _dataManager;

		private PlayerStats _playerStats;

		private SignalBus _signalBus;

		private PowerUpItemUI _selected;

		private List<PowerUpItemUI> _spawned;

		private Dictionary<PowerUpType, List<PowerUpData>> rawPowerUpData;

		private List<PowerUpType> _shownPowerUps;

		[Inject]
		private void Construct(PlayerOptions playerOptions, DataManager dataManager, PlayerStats playerStats, SignalBus signal)
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private void Populate()
		{
		}

		private void CreatePowerUp(PowerUpData dat, PowerUpType type, int level, int maxRank)
		{
		}

		public bool CheckIfDisabled(PowerUpType type)
		{
			return false;
		}

		public void Purchase(PowerUpData data, PowerUpType type, PowerUpItemUI item)
		{
		}

		private bool IsTogglablePowerup(PowerUpType type)
		{
			return false;
		}

		public void ToggleActive()
		{
		}

		public void OnActiveToggled(bool b)
		{
		}

		public void PurchaseSelected()
		{
		}

		public PowerUpItemUI GetCurrentSelected()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitAndGenerateNavigation_003Ed__31))]
		private IEnumerator WaitAndGenerateNavigation()
		{
			return null;
		}

		public void ResetAll()
		{
		}

		public void SetInfo(PowerUpData data, PowerUpType type, PowerUpItemUI itemUI)
		{
		}

		public void RefundPowerUps()
		{
		}

		public void Reset()
		{
		}

		protected override void OnEnterPressed()
		{
		}
	}
}
