using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Flight.Combat.Events;
using Assets.Scripts.Flight.Combat.Teams;
using Assets.Scripts.Flight.Combat.Teams.Events;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Input;
using Assets.Scripts.Multiplayer;
using Jundroo.Common.Events;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat
{
	public class TargetingSystem
	{
		public delegate void TargetingSystemEvent();

		public enum TargetingSystemMode
		{
			Off = 0,
			AirToAir = 1,
			AirToGround = 2,
			Chad = 3
		}

		public enum WarningState
		{
			None = 0,
			Acquiring = 1,
			Locked = 2
		}

		public class TargetChangedEventArgs : EventArgs
		{
			public Target Target { get; private set; }

			public TargetChangedEventArgs(Target target)
			{
				Target = target;
			}
		}

		private TeamAggressionManager _aggressionManager;

		private AircraftScript _aircraft;

		private List<CounterMeasureDispenserScript> _countermeasureDispensers = new List<CounterMeasureDispenserScript>();

		private TrackedTarget _currentTarget;

		private List<WeaponPart> _firedWeapons = new List<WeaponPart>();

		private GunWeaponSystem _gunWeaponSystem;

		private bool _inputCycleTargetingMode;

		private bool _inputNextTarget;

		private bool _inputNextWeapon;

		private bool _inputPrevTarget;

		private bool _inputPrevWeapon;

		private TargetingSystemMode? _lastMode;

		private TargetingSystemMode _mode;

		private int _occlusionIndex;

		private WeaponSystem _selectedWeaponSystem;

		private List<TrackedTarget> _targets;

		private List<TrackedTarget> _targetsOutOfRange;

		private float _time;

		private bool _updateWeaponList;

		private float _warningTimer;

		private List<WeaponSystem> _weaponSystems = new List<WeaponSystem>();

		private List<WeaponSystem> _weaponSystemsMode = new List<WeaponSystem>();

		public bool Active { get; private set; }

		public AircraftScript Aircraft => _aircraft;

		public bool AutoSelectOnTargetDeath { get; set; }

		public bool AutoTargetEnemyPlayers { get; set; }

		public bool CanFire
		{
			get
			{
				if (SelectedWeaponSystem != null)
				{
					return SelectedWeaponSystem.CanFire(_currentTarget);
				}
				return false;
			}
		}

		public int CountermeasureAmmo { get; private set; }

		public Target CurrentTarget
		{
			get
			{
				return _currentTarget?.Target;
			}
			set
			{
				if (value != _currentTarget?.Target)
				{
					if (_currentTarget != null)
					{
						_currentTarget.Selected = false;
						_currentTarget.LockPercentage = 0f;
						_currentTarget.IsLocked = false;
						_currentTarget.IsAcquiring = false;
					}
					_currentTarget = FindTrackedTarget(value);
					if (_currentTarget != null)
					{
						_currentTarget.Selected = true;
						_currentTarget.LockPercentage = 0f;
						_currentTarget.IsLocked = false;
						_currentTarget.IsAcquiring = false;
					}
					else if (value != null)
					{
						Debug.LogError("Could not find target '" + value.Name + "' in targeting system.");
					}
					RaiseTargetChangedEvent(_currentTarget?.Target);
				}
			}
		}

		public WarningState CurrentTargetWarningState { get; private set; }

		public TrackedTarget CurrentTrackedTarget => _currentTarget;

		public WarningState CurrentWarningState { get; private set; }

		public IEnumerable<WeaponPart> FiredWeapons => _firedWeapons;

		public bool GunsActive { get; private set; }

		public GunWeaponSystem GunsWeaponSystem => _gunWeaponSystem;

		public bool IsPlayerTargetingSystem => _aircraft.IsPrimaryLocalPlayer;

		public TargetingSystemMode Mode
		{
			get
			{
				return _mode;
			}
			set
			{
				if (_mode != value)
				{
					_mode = value;
					if (_mode == TargetingSystemMode.Off)
					{
						WeaponFunction = WeaponFunction.None;
						TargetFilter = TargetType.None;
					}
					else if (_mode == TargetingSystemMode.AirToGround)
					{
						WeaponFunction = WeaponFunction.AirToSurface;
						TargetFilter = (TargetType)14;
					}
					else if (_mode == TargetingSystemMode.AirToAir)
					{
						WeaponFunction = WeaponFunction.AirToAir;
						TargetFilter = (TargetType)9;
					}
					else if (_mode == TargetingSystemMode.Chad)
					{
						WeaponFunction = WeaponFunction.None;
						TargetFilter = (TargetType)9;
					}
					AutoSelectWeapon();
					UpdateWeaponsList();
				}
			}
		}

		public WeaponSystem SelectedWeaponSystem
		{
			get
			{
				return _selectedWeaponSystem;
			}
			private set
			{
				if (_selectedWeaponSystem != value)
				{
					_selectedWeaponSystem?.OnDeselected();
					_selectedWeaponSystem = value;
					_selectedWeaponSystem?.OnSelected();
				}
			}
		}

		public bool ShowGunReticule { get; private set; }

		public int TargetCount => _targets.Count;

		public TargetType TargetFilter { get; private set; }

		public float TargetingAngle
		{
			get
			{
				if (SelectedWeaponSystem != null)
				{
					return SelectedWeaponSystem.TargetingAngle;
				}
				return 0f;
			}
		}

		public TargetingPodScript TargetingPod => _aircraft.TargetingPod;

		public Transform TargetingTransform { get; private set; }

		public bool TargetMatchesMode { get; private set; }

		public IEnumerable<TrackedTarget> Targets => _targets;

		public ushort TeamId { get; private set; }

		public WeaponFunction WeaponFunction { get; set; }

		public bool WeaponsOnboard { get; private set; }

		public ICollection<WeaponSystem> WeaponSystems => _weaponSystems;

		public IReadOnlyList<WeaponSystem> WeaponSystemsMode => _weaponSystemsMode;

		public IReadOnlyList<WeaponSystem> WeaponSystemsReadOnly => _weaponSystems;

		public event EventHandler<BombFiredEventArgs> BombFired;

		public event EventHandler<MissileFiredEventArgs> MissileFired;

		public event EventHandler<RocketFiredEventArgs> RocketFired;

		public event EventHandler<TrackedTargetEventArgs> TargetAdded;

		public event EventHandler<TargetChangedEventArgs> TargetChanged
		{
			add
			{
				_targetChanged += WeakEventHandler.Create(value, delegate(EventHandler<TargetChangedEventArgs> x)
				{
					_targetChanged -= x;
				});
			}
			remove
			{
				_targetChanged -= WeakEventHandler.FindUnregisterHandler(this._targetChanged, value);
			}
		}

		public event EventHandler<TrackedTargetEventArgs> TargetEnteredRange;

		public event EventHandler<TrackedTargetEventArgs> TargetLeftRange;

		public event EventHandler<TrackedTargetEventArgs> TargetRemoved;

		public event TargetingSystemEvent WeaponsListUpdated;

		private event EventHandler<TargetChangedEventArgs> _targetChanged;

		public TargetingSystem(AircraftScript aircraft, ushort teamId)
		{
			TeamId = teamId;
			_aircraft = aircraft;
			_targets = new List<TrackedTarget>();
			_targetsOutOfRange = new List<TrackedTarget>();
			Active = true;
			Mode = TargetingSystemMode.Off;
			AutoSelectOnTargetDeath = false;
			_aggressionManager = FlightSceneScript.Instance.TeamAggressionManager;
			if (_aircraft.LoadContext == CraftLoadContext.Flight)
			{
				_aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
				_aircraft.PlayerEntered += OnPlayerEnteredAircraft;
				_aircraft.PlayerExited += OnPlayerExitedAircraft;
				_aircraft.TeamChanged += OnTeamChanged;
			}
			RegisterTargets();
		}

		public TrackedTarget AddTarget(Target target)
		{
			TrackedTarget trackedTarget = null;
			if (target != _aircraft.Target)
			{
				AggressionLevel aggressionLevel = _aggressionManager.GetAggressionLevel(TeamId, target.TeamId);
				trackedTarget = new TrackedTarget(target, aggressionLevel);
				target.Unloaded += OnTargetUnloaded;
				_targets.Add(trackedTarget);
				this.TargetAdded?.Invoke(this, new TrackedTargetEventArgs(trackedTarget));
				trackedTarget.Distance = CalculateDistanceToTarget(target);
				if (target.MaxVisibleRange > 0f && trackedTarget.Distance > target.MaxVisibleRange)
				{
					OnTargetLeftRange(trackedTarget);
				}
				else
				{
					OnTargetEnteredRange(trackedTarget);
				}
			}
			return trackedTarget;
		}

		public void Alert(bool locked, ITargetLockSource source, TrackedTarget trackedTarget)
		{
			if (source?.Player != null)
			{
				FlightSceneScript.Instance.TeamAggressionManager.SetAggressionLevel(TeamId, source.Player.TeamId, AggressionLevel.Hostile);
			}
			Alert(locked);
		}

		public void Alert(bool locked)
		{
			if (locked)
			{
				CurrentWarningState = WarningState.Locked;
				_warningTimer = 0.5f;
			}
			else if (CurrentWarningState != WarningState.Locked)
			{
				CurrentWarningState = WarningState.Acquiring;
				_warningTimer = 0.5f;
			}
		}

		public void AutoSelectWeapon()
		{
			if (WeaponFunction == WeaponFunction.None)
			{
				SelectedWeaponSystem = null;
				return;
			}
			WeaponSystem selectedWeaponSystem = null;
			float num = float.MinValue;
			foreach (WeaponSystem weaponSystem in WeaponSystems)
			{
				if (WeaponMatchesFunction(weaponSystem.WeaponFunction) && weaponSystem.Ammo > 0)
				{
					float suitabilityForTarget = weaponSystem.GetSuitabilityForTarget(_currentTarget);
					if (suitabilityForTarget > num)
					{
						selectedWeaponSystem = weaponSystem;
						num = suitabilityForTarget;
					}
				}
			}
			SelectedWeaponSystem = selectedWeaponSystem;
		}

		public bool HasTarget(Predicate<Target> condition)
		{
			foreach (TrackedTarget target in _targets)
			{
				if (condition(target.Target))
				{
					return true;
				}
			}
			foreach (TrackedTarget item in _targetsOutOfRange)
			{
				if (condition(item.Target))
				{
					return true;
				}
			}
			return false;
		}

		public void InventoryWeapons()
		{
			foreach (PartData part in _aircraft.Parts)
			{
				PartScript partScript = part.PartScript;
				if (!partScript.ConnectedToMainCockpit)
				{
					continue;
				}
				foreach (PartModifierScript modifier in partScript.Modifiers)
				{
					if (!(modifier is IWeapon weapon))
					{
						continue;
					}
					WeaponPart weaponPart = new WeaponPart(partScript, weapon, Mathf.Abs((_aircraft.MainCockpit.transform.position - partScript.transform.position).x), weapon.CustomName);
					string weaponPartName = weapon.CustomName ?? part.PartType.Name;
					if (weapon.Type == WeaponType.Gun)
					{
						weaponPartName = "Guns";
					}
					WeaponSystem weaponSystem = GetWeaponSystem(weaponPartName, weapon.Function);
					if (weaponSystem == null)
					{
						weaponSystem = WeaponSystem.CreateWeaponSystem(weaponPart, this);
						_weaponSystems.Add(weaponSystem);
						if (weaponSystem is GunWeaponSystem gunWeaponSystem)
						{
							_gunWeaponSystem = gunWeaponSystem;
						}
						else
						{
							WeaponsOnboard = true;
						}
					}
					weaponSystem.AddWeapon(weaponPart);
				}
			}
			UpdateWeaponsList();
		}

		public void NextTarget()
		{
			AdvanceTarget(1);
		}

		public void NextWeapon()
		{
			AdvanceWeapon(1);
		}

		public void OnActivationGroupStateChanged(int groupIndex)
		{
			_updateWeaponList = true;
		}

		public void OnBombFired(BombScript bomb, ITarget target)
		{
			this.BombFired?.Invoke(this, new BombFiredEventArgs(_aircraft, target, bomb));
		}

		public void OnDestroy()
		{
			if ((object)_aircraft != null && _aircraft.LoadContext == CraftLoadContext.Flight)
			{
				_aircraft.OnAircraftStructureChanged -= OnAircraftStructureChanged;
				_aircraft.PlayerEntered -= OnPlayerEnteredAircraft;
				_aircraft.PlayerExited -= OnPlayerExitedAircraft;
				_aircraft.TeamChanged -= OnTeamChanged;
			}
			DisableTargetingSystem();
		}

		public void OnMissileFired(MissileScript missile, ITarget target)
		{
			this.MissileFired?.Invoke(this, new MissileFiredEventArgs(_aircraft, target, missile));
		}

		public void OnQueueUpdateWeaponsList()
		{
			_updateWeaponList = true;
		}

		public void OnRocketFired(RocketScript rocket, ITarget target)
		{
			this.RocketFired?.Invoke(this, new RocketFiredEventArgs(_aircraft, target, rocket));
		}

		public void PreviousTarget()
		{
			AdvanceTarget(-1);
		}

		public void PreviousWeapon()
		{
			AdvanceWeapon(-1);
		}

		public void RaiseTargetChangedEvent(Target target)
		{
			if (this._targetChanged == null)
			{
				return;
			}
			Delegate[] invocationList = this._targetChanged.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<TargetChangedEventArgs> eventHandler = (EventHandler<TargetChangedEventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new TargetChangedEventArgs(target));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public bool RemoveTarget(TrackedTarget trackedTarget)
		{
			if (trackedTarget == null)
			{
				return false;
			}
			trackedTarget.Target.Unloaded -= OnTargetUnloaded;
			if (_currentTarget == trackedTarget)
			{
				CurrentTarget = null;
			}
			int num;
			if (!_targets.Remove(trackedTarget))
			{
				num = (_targetsOutOfRange.Remove(trackedTarget) ? 1 : 0);
				if (num == 0)
				{
					goto IL_0065;
				}
			}
			else
			{
				num = 1;
			}
			TrackedTargetEventArgs e = new TrackedTargetEventArgs(trackedTarget);
			EventHandler<TrackedTargetEventArgs> eventHandler = this.TargetRemoved;
			if (eventHandler == null)
			{
				return (byte)num != 0;
			}
			eventHandler(this, e);
			goto IL_0065;
			IL_0065:
			return (byte)num != 0;
		}

		public void RemoveTargets(Predicate<Target> condition)
		{
			for (int num = _targets.Count - 1; num >= 0; num--)
			{
				if (condition(_targets[num].Target))
				{
					RemoveTarget(_targets[num]);
				}
			}
			for (int num2 = _targetsOutOfRange.Count - 1; num2 >= 0; num2--)
			{
				if (condition(_targetsOutOfRange[num2].Target))
				{
					RemoveTarget(_targetsOutOfRange[num2]);
				}
			}
		}

		public void SelectWeaponSystem(WeaponSystem weaponSystem)
		{
			WeaponSystem selectedWeaponSystem = null;
			if (weaponSystem != null && WeaponMatchesFunction(weaponSystem.WeaponFunction))
			{
				selectedWeaponSystem = weaponSystem;
			}
			SelectedWeaponSystem = selectedWeaponSystem;
			UpdateWeaponsList();
		}

		public void SetPlayerTarget(int? playerId)
		{
			Target currentTarget = null;
			if (playerId.HasValue)
			{
				foreach (TrackedTarget target in _targets)
				{
					if (target.Target is PlayerTarget playerTarget && playerTarget.Player?.NetworkPlayer?.PlayerId == playerId.Value)
					{
						currentTarget = playerTarget;
						break;
					}
				}
			}
			CurrentTarget = currentTarget;
		}

		public void Update(float deltaTime)
		{
			if (Active && _aircraft.LoadContext == CraftLoadContext.Flight && !PauseManager.Paused)
			{
				_time += Time.deltaTime;
				if (Mode == TargetingSystemMode.Chad)
				{
					if (GameInputs.Instance.NextTarget.GetButtonDownIfEnabled())
					{
						NextTarget();
					}
					else if (GameInputs.Instance.PreviousTarget.GetButtonDownIfEnabled())
					{
						PreviousTarget();
					}
				}
				else
				{
					if (ProcessInput(_aircraft.Controls.NextTarget, ref _inputNextTarget))
					{
						NextTarget();
					}
					if (ProcessInput(_aircraft.Controls.PreviousTarget, ref _inputPrevTarget))
					{
						PreviousTarget();
					}
					if (ProcessInput(_aircraft.Controls.NextWeapon, ref _inputNextWeapon))
					{
						NextWeapon();
					}
					if (ProcessInput(_aircraft.Controls.PreviousWeapon, ref _inputPrevWeapon))
					{
						PreviousWeapon();
					}
					if (ProcessInput(_aircraft.Controls.CycleTargetingMode, ref _inputCycleTargetingMode))
					{
						CycleTargetingMode();
					}
				}
				if (_updateWeaponList)
				{
					_selectedWeaponSystem?.OnBeforeUpdateWeaponList();
					_updateWeaponList = false;
					if (SelectedWeaponSystem == null)
					{
						AutoSelectWeapon();
					}
					UpdateWeaponsList();
					RefreshCountermeasures();
				}
				if (_aircraft.Controls.FireWeapons)
				{
					FireWeapon();
				}
				if (SelectedWeaponSystem != null)
				{
					SelectedWeaponSystem.Update(deltaTime);
				}
				_warningTimer -= Time.deltaTime;
				if (_warningTimer < 0f)
				{
					_warningTimer = 0f;
					CurrentWarningState = WarningState.None;
				}
			}
			List<CounterMeasureDispenserScript> countermeasureDispensers = _countermeasureDispensers;
			if (countermeasureDispensers != null && countermeasureDispensers.Count > 0)
			{
				int num = 0;
				for (int i = 0; i < _countermeasureDispensers.Count; i++)
				{
					if (_countermeasureDispensers[i].gameObject.activeInHierarchy && _countermeasureDispensers[i].IsArmed)
					{
						num += _countermeasureDispensers[i].Ammo;
					}
				}
				CountermeasureAmmo = num;
			}
			UpdateTargets(deltaTime);
		}

		private void AdvanceTarget(int direction)
		{
			if (_targets.Count > 0)
			{
				int num = 0;
				for (int i = 0; i < _targets.Count; i++)
				{
					if (_targets[i].Target == CurrentTarget)
					{
						num = i;
						break;
					}
				}
				for (int j = 0; j < _targets.Count; j++)
				{
					num += direction;
					if (num < 0)
					{
						num = _targets.Count - 1;
					}
					else if (num >= _targets.Count)
					{
						num = 0;
					}
					TrackedTarget trackedTarget = _targets[num];
					if (TargetTypeMatchesMode(trackedTarget.Target.TargetType))
					{
						CurrentTarget = trackedTarget.Target;
						break;
					}
				}
			}
			else
			{
				CurrentTarget = null;
			}
		}

		private void AdvanceWeapon(int direction)
		{
			if (_weaponSystems.Count > 0)
			{
				string arg = "DISABLED";
				if (SelectedWeaponSystem != null)
				{
					switch (Mode)
					{
					case TargetingSystemMode.AirToAir:
						arg = "AIR-TO-AIR";
						break;
					case TargetingSystemMode.AirToGround:
						arg = "AIR-TO-GND";
						break;
					case TargetingSystemMode.Off:
						arg = "DISABLED";
						break;
					}
				}
				WeaponSystem selectedWeaponSystem = SelectedWeaponSystem;
				int num = 0;
				for (int i = 0; i < _weaponSystems.Count; i++)
				{
					if (_weaponSystems[i] == SelectedWeaponSystem)
					{
						num = i;
						break;
					}
				}
				for (int j = 0; j < _weaponSystems.Count - 1; j++)
				{
					num += direction;
					if (num < 0)
					{
						num = _weaponSystems.Count - 1;
					}
					else if (num >= _weaponSystems.Count)
					{
						num = 0;
					}
					WeaponSystem weaponSystem = _weaponSystems[num];
					if (WeaponMatchesFunction(weaponSystem.WeaponFunction) && weaponSystem.Ammo > 0)
					{
						FlightSceneScript.Instance.FlightUI.ShowMessage($"{weaponSystem.WeaponPartName} weapon selected");
						SelectWeaponSystem(weaponSystem);
						break;
					}
				}
				if (SelectedWeaponSystem == selectedWeaponSystem)
				{
					if (_weaponSystems.Count == 1 && _weaponSystems[0] is GunWeaponSystem)
					{
						FlightSceneScript.Instance.FlightUI.ShowMessage("Cannot advance weapon: Only guns available.");
					}
					else if (SelectedWeaponSystem == null)
					{
						FlightSceneScript.Instance.FlightUI.ShowMessage("Cannot advance weapon: Targeting is disabled.");
					}
					else if (SelectedWeaponSystem.WeaponFunction == WeaponFunction.None)
					{
						FlightSceneScript.Instance.FlightUI.ShowMessage("Cannot advance weapon: Targeting is disabled.");
					}
					else
					{
						FlightSceneScript.Instance.FlightUI.ShowMessage($"Cannot advance weapon: No ordinance for {arg} available.");
					}
				}
			}
			else
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage("Cannot advance weapon: No ordinance available.");
			}
		}

		private void AutoSelectEnemyPlayerTarget()
		{
			FlightScenePlayer player = _aircraft.Player;
			if (player == null || !player.NetworkPlayer.IsOwner)
			{
				return;
			}
			List<FlightScenePlayer> value;
			using (CollectionPool<List<FlightScenePlayer>, FlightScenePlayer>.Get(out value))
			{
				List<FlightScenePlayer> value2;
				using (CollectionPool<List<FlightScenePlayer>, FlightScenePlayer>.Get(out value2))
				{
					player.GetAlliesAndEnemies(value, value2);
					if (!value.Contains(player))
					{
						value.Add(player);
					}
					int num = int.MaxValue;
					int a = int.MinValue;
					List<(FlightScenePlayer, FlightScenePlayer, bool)> value3;
					using (CollectionPool<List<(FlightScenePlayer, FlightScenePlayer, bool)>, (FlightScenePlayer, FlightScenePlayer, bool)>.Get(out value3))
					{
						foreach (FlightScenePlayer item2 in value)
						{
							if (item2.Aircraft != null)
							{
								TargetingSystem targetingSystem = item2.Aircraft.TargetingSystem;
								FlightScenePlayer item = (targetingSystem.CurrentTarget as PlayerTarget)?.Player;
								bool autoTargetEnemyPlayers = targetingSystem.AutoTargetEnemyPlayers;
								value3.Add((item2, item, autoTargetEnemyPlayers));
							}
						}
						List<(FlightScenePlayer, int, int)> value4;
						using (CollectionPool<List<(FlightScenePlayer, int, int)>, (FlightScenePlayer, int, int)>.Get(out value4))
						{
							foreach (FlightScenePlayer item3 in value2)
							{
								if (!(item3.Aircraft != null))
								{
									continue;
								}
								int num2 = 0;
								int num3 = 0;
								foreach (var item4 in value3)
								{
									if (item4.Item2 == item3)
									{
										num2++;
										if (item4.Item3)
										{
											num3++;
										}
									}
								}
								num = Mathf.Min(num, num2);
								a = Mathf.Max(a, num2);
								value4.Add((item3, num2, num3));
							}
							int a2 = -1;
							FlightScenePlayer flightScenePlayer = null;
							foreach (var item5 in value3)
							{
								if (!item5.Item3)
								{
									continue;
								}
								bool flag = item5.Item2 == null;
								if (!flag)
								{
									bool flag2 = false;
									foreach (var item6 in value4)
									{
										if (item6.Item1 == item5.Item2)
										{
											flag = item6.Item2 > num + 1;
											flag2 = true;
											break;
										}
									}
									if (!flag2)
									{
										flag = true;
									}
								}
								if (flag)
								{
									a2 = Mathf.Max(a2, item5.Item1.NetworkPlayer.PlayerId);
									if (flightScenePlayer == null || flightScenePlayer.NetworkPlayer.PlayerId < item5.Item1.NetworkPlayer.PlayerId)
									{
										(flightScenePlayer, _, _) = item5;
									}
								}
							}
							if (flightScenePlayer != player)
							{
								return;
							}
							foreach (var item7 in value4)
							{
								if (item7.Item2 == num)
								{
									SetPlayerTarget(item7.Item1.NetworkPlayer.PlayerId);
									break;
								}
							}
						}
					}
				}
			}
		}

		private float CalculateDistanceToTarget(Target target)
		{
			Vector3 vector = _aircraft.Position;
			if (Mode == TargetingSystemMode.Chad)
			{
				vector = _aircraft.NetworkAircraft.Player.FramePosition;
			}
			return (target.Position - vector).magnitude;
		}

		private void ClearTargets()
		{
			for (int num = _targets.Count - 1; num >= 0; num--)
			{
				RemoveTarget(_targets[num]);
			}
		}

		private void CycleTargetingMode()
		{
			if (_aircraft.TargetingSystem.Mode == TargetingSystemMode.Off)
			{
				_aircraft.TargetingSystem.Mode = TargetingSystemMode.AirToAir;
				FlightSceneScript.Instance.FlightUI.ShowMessage("Air to Air Mode", 1f);
			}
			else if (_aircraft.TargetingSystem.Mode == TargetingSystemMode.AirToAir)
			{
				_aircraft.TargetingSystem.Mode = TargetingSystemMode.AirToGround;
				FlightSceneScript.Instance.FlightUI.ShowMessage("Air to Ground Mode", 1f);
			}
			else
			{
				_aircraft.TargetingSystem.Mode = TargetingSystemMode.Off;
				FlightSceneScript.Instance.FlightUI.ShowMessage("Targeting Off", 1f);
			}
		}

		private void DisableTargetingSystem()
		{
			TargetRegistry targetRegistry = FlightSceneScript.Instance.TargetRegistry;
			targetRegistry.TargetRegistered -= OnTargetRegistered;
			targetRegistry.TargetUnregistered -= OnTargetUnregistered;
			ClearTargets();
		}

		private TrackedTarget FindTrackedTarget(Target target)
		{
			return _targets.Where((TrackedTarget x) => x.Target == target).FirstOrDefault() ?? _targetsOutOfRange.Where((TrackedTarget x) => x.Target == target).FirstOrDefault();
		}

		private void FireWeapon()
		{
			if (SelectedWeaponSystem != null && (SelectedWeaponSystem.CanFire(_currentTarget) || DebugInput.GetKey(KeyCode.O)))
			{
				WeaponPart weaponPart = SelectedWeaponSystem.Fire(_currentTarget);
				if (weaponPart != null)
				{
					_updateWeaponList = true;
					_firedWeapons.Add(weaponPart);
				}
			}
		}

		private WeaponSystem GetWeaponSystem(string weaponPartName, WeaponFunction role)
		{
			foreach (WeaponSystem weaponSystem in _weaponSystems)
			{
				if (weaponSystem.WeaponPartName == weaponPartName && (weaponPartName == "Guns" || (weaponSystem.WeaponFunction & role) != WeaponFunction.None))
				{
					return weaponSystem;
				}
			}
			return null;
		}

		private void OnAircraftStructureChanged()
		{
			_updateWeaponList = true;
		}

		private void OnPlayerEnteredAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (_lastMode.HasValue)
			{
				Mode = _lastMode.Value;
				_lastMode = null;
			}
		}

		private void OnPlayerExitedAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			_lastMode = Mode;
			Mode = TargetingSystemMode.Chad;
		}

		private void OnTargetEnteredRange(TrackedTarget trackedTarget)
		{
			_targetsOutOfRange.Remove(trackedTarget);
			if (!_targets.Contains(trackedTarget))
			{
				_targets.Add(trackedTarget);
			}
			this.TargetEnteredRange?.Invoke(this, new TrackedTargetEventArgs(trackedTarget));
		}

		private void OnTargetLeftRange(TrackedTarget trackedTarget)
		{
			if (CurrentTarget == trackedTarget.Target)
			{
				CurrentTarget = null;
			}
			_targets.Remove(trackedTarget);
			if (!_targetsOutOfRange.Contains(trackedTarget))
			{
				_targetsOutOfRange.Add(trackedTarget);
			}
			this.TargetLeftRange?.Invoke(this, new TrackedTargetEventArgs(trackedTarget));
		}

		private void OnTargetRegistered(object sender, TargetEventArgs e)
		{
			AddTarget(e.Target);
		}

		private void OnTargetUnloaded(Target target)
		{
			TrackedTarget trackedTarget = FindTrackedTarget(target);
			RemoveTarget(trackedTarget);
		}

		private void OnTargetUnregistered(object sender, TargetEventArgs e)
		{
			RemoveTarget(FindTrackedTarget(e.Target));
		}

		private void OnTeamChanged(object sender, TeamChangedEventArgs e)
		{
			TeamId = e.NewTeamId;
		}

		private bool ProcessInput(bool input, ref bool inputFlag)
		{
			if (input)
			{
				if (!inputFlag)
				{
					inputFlag = true;
					return true;
				}
			}
			else
			{
				inputFlag = false;
			}
			return false;
		}

		private void RefreshCountermeasures()
		{
			_countermeasureDispensers.Clear();
			if (!(_aircraft != null))
			{
				return;
			}
			for (int i = 0; i < _aircraft.Parts.Count; i++)
			{
				PartScript partScript = _aircraft.Parts[i].PartScript;
				for (int j = 0; j < partScript.Modifiers.Count; j++)
				{
					CounterMeasureDispenserScript modifier = partScript.GetModifier<CounterMeasureDispenserScript>();
					if (modifier != null)
					{
						_countermeasureDispensers.Add(modifier);
					}
				}
			}
		}

		private void RegisterTargets()
		{
			ClearTargets();
			TargetRegistry targetRegistry = FlightSceneScript.Instance.TargetRegistry;
			targetRegistry.TargetRegistered += OnTargetRegistered;
			targetRegistry.TargetUnregistered += OnTargetUnregistered;
			foreach (Target target in targetRegistry.Targets)
			{
				AddTarget(target);
			}
		}

		private void SelectBestTarget()
		{
			float num = 90f;
			Target currentTarget = null;
			for (int i = 0; i < _targets.Count; i++)
			{
				TrackedTarget trackedTarget = _targets[i];
				if (trackedTarget.Angle < num && TargetTypeMatchesMode(trackedTarget.Target.TargetType))
				{
					num = trackedTarget.Angle;
					currentTarget = trackedTarget.Target;
				}
			}
			CurrentTarget = currentTarget;
		}

		private bool TargetTypeMatchesMode(TargetType targetType)
		{
			return (TargetFilter & targetType) != 0;
		}

		private void UpdateTargetOcclusion()
		{
			for (int i = 0; i < _targets.Count; i++)
			{
				_occlusionIndex++;
				if (_occlusionIndex >= _targets.Count)
				{
					_occlusionIndex = 0;
				}
				TrackedTarget trackedTarget = _targets[_occlusionIndex];
				if (TargetTypeMatchesMode(trackedTarget.Target.TargetType) && trackedTarget.Target.SupportsOcclusion)
				{
					Vector3 vector = trackedTarget.Target.Position - _aircraft.Position;
					Ray ray = new Ray(_aircraft.Position, vector.normalized);
					trackedTarget.Occluded = Physics.Raycast(ray, vector.magnitude - 10f, 1048576);
					break;
				}
			}
		}

		private void UpdateTargets(float deltaTime)
		{
			WarningState currentTargetWarningState = WarningState.None;
			TargetMatchesMode = false;
			Transform transform = null;
			if (IsPlayerTargetingSystem)
			{
				CameraVantageScript cameraVantageScript = CameraManagerScript.Instance.Controller?.CameraVantage;
				if (cameraVantageScript != null && cameraVantageScript.Data.EnableMissileLocking && cameraVantageScript.TransformToTrack != null)
				{
					transform = cameraVantageScript.TransformToTrack;
				}
			}
			if (transform == null)
			{
				transform = SelectedWeaponSystem?.TargetingTransform ?? _aircraft.MainCockpit.transform;
			}
			TargetingTransform = transform;
			for (int num = _targets.Count - 1; num >= 0; num--)
			{
				TrackedTarget trackedTarget = _targets[num];
				trackedTarget.AggressionLevel = _aggressionManager.GetAggressionLevel(TeamId, trackedTarget.Target.TeamId);
				trackedTarget.IsTracking = TargetTypeMatchesMode(trackedTarget.Target.TargetType);
				if (trackedTarget.IsTracking)
				{
					if (trackedTarget.Target.IsDead)
					{
						RemoveTarget(trackedTarget);
					}
					else
					{
						Vector3 to = transform.InverseTransformPoint(trackedTarget.Target.Position);
						trackedTarget.Distance = CalculateDistanceToTarget(trackedTarget.Target);
						trackedTarget.Angle = Vector3.Angle(Vector3.forward, to);
						trackedTarget.IsAcquiring = false;
						trackedTarget.IsLocked = false;
						if (trackedTarget.Selected)
						{
							TargetMatchesMode = true;
						}
						if (trackedTarget.Target.MaxVisibleRange > 0f && trackedTarget.Distance > trackedTarget.Target.MaxVisibleRange)
						{
							OnTargetLeftRange(trackedTarget);
						}
						else if (trackedTarget.Selected && SelectedWeaponSystem != null && trackedTarget.Target.TargetType != TargetType.Information)
						{
							SelectedWeaponSystem.ProcessTarget(trackedTarget, deltaTime);
							if (trackedTarget.IsLocked)
							{
								currentTargetWarningState = WarningState.Locked;
							}
							else if (trackedTarget.IsAcquiring)
							{
								currentTargetWarningState = WarningState.Acquiring;
							}
						}
					}
				}
			}
			for (int num2 = _targetsOutOfRange.Count - 1; num2 >= 0; num2--)
			{
				TrackedTarget trackedTarget2 = _targetsOutOfRange[num2];
				trackedTarget2.AggressionLevel = _aggressionManager.GetAggressionLevel(TeamId, trackedTarget2.Target.TeamId);
				if (trackedTarget2.Target.IsDead)
				{
					RemoveTarget(trackedTarget2);
				}
				else
				{
					trackedTarget2.Distance = CalculateDistanceToTarget(trackedTarget2.Target);
					if (trackedTarget2.Distance < trackedTarget2.Target.MaxVisibleRange)
					{
						OnTargetEnteredRange(trackedTarget2);
					}
				}
			}
			CurrentTargetWarningState = currentTargetWarningState;
			FlightScenePlayer player = Aircraft.Player;
			if (player != null && player.NetworkPlayer.IsOwner)
			{
				if (AutoTargetEnemyPlayers)
				{
					AutoSelectEnemyPlayerTarget();
				}
				else if ((CurrentTarget == null || (AutoSelectOnTargetDeath && CurrentTarget.IsDead)) && _time > 1f)
				{
					SelectBestTarget();
				}
			}
			UpdateTargetOcclusion();
		}

		private void UpdateWeaponsList()
		{
			_weaponSystemsMode.Clear();
			foreach (WeaponSystem weaponSystem in _weaponSystems)
			{
				if (WeaponMatchesFunction(weaponSystem.WeaponFunction))
				{
					_weaponSystemsMode.Add(weaponSystem);
				}
			}
			if (_gunWeaponSystem != null)
			{
				_gunWeaponSystem.RecalculateFireDelays();
				GunsActive = _gunWeaponSystem.CanFire(null) && Mode != TargetingSystemMode.Chad;
				ShowGunReticule = GunsActive;
			}
			else
			{
				ShowGunReticule = false;
			}
			if (SelectedWeaponSystem != null && SelectedWeaponSystem.ShowGunReticule)
			{
				ShowGunReticule = Mode != TargetingSystemMode.Chad;
			}
			if (this.WeaponsListUpdated != null)
			{
				this.WeaponsListUpdated();
			}
		}

		private bool WeaponMatchesFunction(WeaponFunction weaponFunction)
		{
			return (weaponFunction & WeaponFunction) != 0;
		}
	}
}
