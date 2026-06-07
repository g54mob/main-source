using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Character;
using Assets.Scripts.Character.Camera;
using Assets.Scripts.Character.State;
using Assets.Scripts.Character.Suit;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Character;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Flight.Combat.Teams;
using Assets.Scripts.Flight.Combat.Teams.Events;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Input;
using Assets.Scripts.Multiplayer;
using Assets.Scripts.Multiplayer.ActivityFramework;
using Assets.Scripts.Multiplayer.ActivityFramework.Events;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Events;
using Jundroo.DevConsole;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.CharacterControllerPro.Implementation;
using Lightbug.Utilities;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Flight
{
	public class FlightScenePlayer : IRepositionable
	{
		private Transform _avatarCameraTarget;

		private Transform _avatarFpvCameraTarget;

		private CharacterCameraVantage _avatarFpvCameraVantage;

		private GameObject _emptyAvatar;

		private FlightScenePlayerEventArgs _playerEventArgs;

		private AircraftScript _previousAircraft;

		public AircraftScript Aircraft { get; private set; }

		public GameObject Avatar
		{
			get
			{
				if (NetworkCharacter != null)
				{
					return NetworkCharacter.gameObject;
				}
				return _emptyAvatar;
			}
		}

		public bool AvatarActive
		{
			get
			{
				if (!(CharacterActor == null))
				{
					return CharacterActor.gameObject.activeSelf;
				}
				return false;
			}
			set
			{
				if (CharacterActor != null)
				{
					CharacterActor.gameObject.SetActive(value);
				}
			}
		}

		public Transform AvatarCameraTarget
		{
			get
			{
				if (_avatarCameraTarget != null)
				{
					return _avatarCameraTarget;
				}
				if (_emptyAvatar != null)
				{
					return _emptyAvatar.transform;
				}
				return null;
			}
		}

		public Transform AvatarFpvCameraTarget
		{
			get
			{
				if (_avatarFpvCameraTarget != null)
				{
					return _avatarFpvCameraTarget;
				}
				if (_emptyAvatar != null)
				{
					return _emptyAvatar.transform;
				}
				return null;
			}
		}

		public CharacterActor CharacterActor { get; private set; }

		public Animator CharacterAnimator { get; private set; }

		public NormalMovement CharacterNormalMovement { get; private set; }

		public RuntimeAnimatorController CharacterPreSeatedAnimatorController { get; private set; }

		public CharacterSuitScript CharacterSuit { get; private set; }

		public IKSeatScript CurrentIKSeat { get; private set; }

		public AircraftScript CurrentOrPreviousAircraft => Aircraft ?? PreviousAircraft;

		public SeatScript CurrentSeat { get; private set; }

		public FullBodyBipedIK FBBIK { get; private set; }

		public Vector3 FramePosition
		{
			get
			{
				if ((object)RepositionTarget != null)
				{
					return RepositionTarget.position;
				}
				if ((object)Aircraft == null)
				{
					return Avatar?.transform.position ?? Vector3.zero;
				}
				return Aircraft.Position;
			}
			set
			{
				if ((object)Aircraft != null)
				{
					Aircraft.Position = value;
				}
				if ((object)_emptyAvatar != null)
				{
					_emptyAvatar.transform.position = value;
				}
				if (CharacterActor != null)
				{
					CharacterActor.Position = value;
					CharacterActor.transform.position = value;
				}
				if (IsPrimaryLocal)
				{
					Transform transform = FlightSceneScript.Instance?.CameraScript?.CameraFocalPosition;
					if (transform != null)
					{
						transform.position = value;
					}
				}
			}
		}

		public Vector3 GlobalPosition
		{
			get
			{
				return Utility.ConvertFloatingOriginToAbsolutePosition(FramePosition);
			}
			set
			{
				FramePosition = Utility.ConvertAbsoluteToFloatingOriginPosition(value);
			}
		}

		public Transform Graphics { get; private set; }

		public bool InitialCraftLoadCompleted { get; private set; }

		public bool IsLoadingCraft { get; private set; }

		public bool IsLocal => NetworkPlayer.IsLocal;

		public bool IsPrimaryLocal => NetworkPlayer.IsPrimaryLocal;

		public bool IsRepositioning => (object)RepositionTarget != null;

		public bool IsUnloaded { get; private set; }

		public string Name => NetworkPlayer.Name;

		public NetworkCharacterScript NetworkCharacter { get; private set; }

		public NetworkedActivityScript NetworkedActivity { get; private set; }

		public NetworkPlayerScript NetworkPlayer { get; private set; }

		public FlightScenePlayer Owner
		{
			get
			{
				if (!NetworkPlayer.IsNPC)
				{
					return this;
				}
				int ownerId = NetworkPlayer.OwnerId;
				foreach (FlightScenePlayer allPlayer in FlightSceneScript.Instance.AllPlayers)
				{
					if (!allPlayer.NetworkPlayer.IsNPC && allPlayer.NetworkPlayer.OwnerId == ownerId)
					{
						return allPlayer;
					}
				}
				return null;
			}
		}

		public AircraftScript PreviousAircraft => _previousAircraft;

		public Transform RepositionTarget { get; private set; }

		public Vector3 Rotation
		{
			get
			{
				if ((object)Aircraft == null)
				{
					return Avatar?.transform.rotation.eulerAngles ?? Vector3.zero;
				}
				return Aircraft.Rotation;
			}
			set
			{
				if ((object)Aircraft != null)
				{
					Aircraft.Rotation = value;
				}
				else if (CharacterActor != null)
				{
					CharacterActor.Rotation = Quaternion.Euler(value);
					CharacterActor.Up = Vector3.up;
				}
			}
		}

		public StartLocationData StartLocation { get; set; }

		public ushort TeamId { get; private set; }

		public Vector3 Velocity
		{
			get
			{
				if (Aircraft != null)
				{
					return Aircraft.Velocity;
				}
				if (CharacterActor != null)
				{
					return CharacterActor.Velocity;
				}
				return Vector3.zero;
			}
		}

		public event EventHandler<FlightScenePlayerAircraftEventArgs> AircraftEntered;

		public event EventHandler<FlightScenePlayerAircraftEventArgs> AircraftExited;

		public event EventHandler<AircraftKilledEventArgs> AircraftKilled;

		public event EventHandler<FlightScenePlayerAircraftLoadCompletedEventArgs> AircraftLoadCompleted;

		public event EventHandler<FlightScenePlayerAircraftEventArgs> AircraftLoaded;

		public event EventHandler<FlightScenePlayerEventArgs> AircraftLoadStarted;

		public event EventHandler<FlightScenePlayerAircraftEventArgs> AircraftUnloaded;

		public event EventHandler<FlightScenePlayerEventArgs> EnteredInFlightDesigner;

		public event EventHandler<FlightScenePlayerEventArgs> ExitedInFlightDesigner;

		public event EventHandler<FlightScenePlayerEventArgs> IKPostUpdate;

		public event EventHandler<FlightScenePlayerLocationChangedEventArgs> LocationChanged;

		public event EventHandler<NetworkedActivityEventArgs> NetworkedActivityJoined;

		public event EventHandler<NetworkedActivityEventArgs> NetworkedActivityLeft;

		public event EventHandler<TeamChangedEventArgs> TeamChanged;

		public FlightScenePlayer(NetworkPlayerScript player)
		{
			NetworkPlayer = player;
			_emptyAvatar = new GameObject($"PlayerAvatar_{player.PlayerId}_Placeholder");
			_emptyAvatar.transform.SetParent(FlightSceneScript.Instance.AvatarContainer, worldPositionStays: false);
			NetworkPlayer.FlightScenePlayer = this;
			FloatingOriginScript.Instance.Repositioned += OnFloatingOriginRepositioned;
			TeamId = NetworkPlayer.TeamId;
			player.TeamChanged += OnTeamChanged;
			_playerEventArgs = new FlightScenePlayerEventArgs(this);
		}

		public void CameraDiscovery()
		{
			List<CharacterCameraVantage> list = new List<CharacterCameraVantage>();
			if (CharacterActor != null)
			{
				list.AddRange(CharacterActor.GetComponentsInChildren<CharacterCameraVantage>());
				_avatarCameraTarget = list.FirstOrDefault((CharacterCameraVantage x) => x.Mode == ViewMode.Orbit).transform;
			}
			if (Aircraft != null && Graphics != null)
			{
				list.AddRange(Graphics.GetComponentsInChildren<CharacterCameraVantage>());
			}
			if (_avatarCameraTarget == null)
			{
				Debug.LogWarning("Character does not have orbit camera defined.", CharacterActor);
			}
			if (list != null)
			{
				_avatarFpvCameraVantage = list.LastOrDefault((CharacterCameraVantage x) => x.Mode == ViewMode.FirstPerson);
				_avatarFpvCameraTarget = _avatarFpvCameraVantage?.transform;
			}
			if (_avatarFpvCameraTarget == null)
			{
				Debug.LogWarning("Character does not have fpv camera defined.", CharacterActor);
			}
			CameraViewSwitched(null, CameraManagerScript.Instance.Controller);
		}

		public void DespawnAircraft()
		{
			AircraftScript aircraftScript = Aircraft ?? _previousAircraft;
			if (aircraftScript != null && aircraftScript.gameObject.activeSelf)
			{
				INetworkAircraft networkAircraft = GetNetworkAircraft();
				ExitAircraft();
				aircraftScript.gameObject.SetActive(value: false);
				networkAircraft.RequestDespawn();
			}
			AvatarActive = false;
			_previousAircraft = null;
		}

		public void EnterAircraft(AircraftScript aircraft)
		{
			if (Aircraft == aircraft || aircraft.MainCockpit?.GetComponent<CockpitScript>()?.PilotCanEnter != true)
			{
				return;
			}
			if ((object)Aircraft != null)
			{
				ExitAircraft();
			}
			Aircraft = aircraft;
			if (IsPrimaryLocal)
			{
				InputWrapper.UseCraftControls();
			}
			aircraft.OnPlayerEntered(this);
			if (CharacterActor != null)
			{
				SeatScript seatScript = aircraft.MainSeat?.GetModifier<SeatScript>();
				if (seatScript != null)
				{
					Graphics.SetParent(seatScript.transform);
					CurrentSeat = seatScript;
					Vector3 vector = seatScript.Data.Part.PartScale ?? Vector3.one;
					Graphics.localScale = new Vector3(1f / vector.x, 1f / vector.y, 1f / vector.z);
					Graphics.GetComponent<CharacterStepLerper>().enabled = false;
					Graphics.SetLocalPositionAndRotation(seatScript.Data.SeatedPosition, Quaternion.Euler(seatScript.Data.SeatedRotation));
					CharacterPreSeatedAnimatorController = CharacterAnimator.runtimeAnimatorController;
					CharacterAnimator.updateMode = AnimatorUpdateMode.Normal;
					if (!string.IsNullOrWhiteSpace(seatScript.Data.Animation))
					{
						RuntimeAnimatorController runtimeAnimatorController = Game.Instance.ResourceLoader.Load<RuntimeAnimatorController>(seatScript.Data.Animation);
						if (runtimeAnimatorController != null)
						{
							CharacterAnimator.runtimeAnimatorController = runtimeAnimatorController;
						}
					}
					IKSeatScript modifier = seatScript.PartScript.GetModifier<IKSeatScript>();
					if (modifier != null)
					{
						CurrentIKSeat = modifier;
						modifier.StartPose(Graphics);
					}
				}
				AvatarActive = false;
			}
			this.AircraftEntered?.Invoke(this, new FlightScenePlayerAircraftEventArgs(this, aircraft));
		}

		public void EnterPreviousAircraft()
		{
			if ((object)_previousAircraft != null)
			{
				EnterAircraft(_previousAircraft);
			}
		}

		public void ExitAircraft(Vector3? exitVelocity = null, float? exitVelocityMagnitudeLimit = null)
		{
			if ((object)Aircraft == null)
			{
				return;
			}
			if (IsPrimaryLocal)
			{
				InputWrapper.UseCharacterControls();
			}
			if (CurrentSeat != null && !CurrentSeat.isActiveAndEnabled)
			{
				CurrentSeat = null;
			}
			SeatData seatData = CurrentSeat?.Data;
			Vector3 vector = ((seatData != null) ? CurrentSeat.transform.TransformPoint(seatData.ExitPosition) : (Aircraft.Position + Vector3.up * 2f));
			Quaternion rotation = ((seatData != null) ? (CurrentSeat.transform.rotation * Quaternion.Euler(seatData.ExitRotation)) : Quaternion.Euler(Aircraft.Rotation));
			Vector3 valueOrDefault = exitVelocity.GetValueOrDefault();
			if (!exitVelocity.HasValue)
			{
				valueOrDefault = ((CurrentSeat?.PartScript?.Body?.RigidBody != null) ? CurrentSeat.PartScript.Body.RigidBody.GetPointVelocity(CurrentSeat.transform.position) : Aircraft.MainCockpit.Body.RigidBody.GetPointVelocity(Aircraft.MainCockpit.transform.position));
				exitVelocity = valueOrDefault;
			}
			if (exitVelocityMagnitudeLimit.HasValue && exitVelocity.Value.magnitude > exitVelocityMagnitudeLimit.Value)
			{
				exitVelocity = exitVelocity.Value.normalized * exitVelocityMagnitudeLimit.Value;
			}
			if (CharacterActor != null)
			{
				int layerMask = 9449473;
				Transform transform = ((seatData != null) ? CurrentSeat.transform : Aircraft.MainCockpit?.transform);
				Vector3 vector2 = ((transform != null) ? transform.position : Graphics.position);
				if (seatData != null)
				{
					Vector3 vector3 = CurrentSeat.transform.TransformPoint(new Vector3(seatData.ExitPosition.x, 0f, 0f));
					Vector3 vector4 = CurrentSeat.transform.TransformPoint(new Vector3(0f, seatData.ExitPosition.y, 0f));
					Vector3 vector5 = CurrentSeat.transform.TransformPoint(new Vector3(0f, 0f, seatData.ExitPosition.z));
					Vector3 vector6 = vector3 - vector2;
					Vector3 vector7 = vector4 - vector2;
					Vector3 vector8 = vector5 - vector2;
					if (vector6.magnitude > 0.1f)
					{
						Ray ray = new Ray(vector2, vector6);
						if (Physics.Raycast(ray, out var hitInfo, vector6.magnitude, layerMask))
						{
							vector2 = hitInfo.point - ray.direction * 0.1f;
						}
						else
						{
							vector2 += vector6;
						}
					}
					if (vector8.magnitude > 0.1f)
					{
						Ray ray2 = new Ray(vector2, vector8);
						if (Physics.Raycast(ray2, out var hitInfo2, vector8.magnitude, layerMask))
						{
							vector2 = hitInfo2.point - ray2.direction * 0.1f;
						}
						else
						{
							vector2 += vector8;
						}
					}
					if (vector7.magnitude > 0.1f)
					{
						Ray ray3 = new Ray(vector2, vector7);
						if (Physics.Raycast(ray3, out var hitInfo3, vector7.magnitude, layerMask))
						{
							vector2 = hitInfo3.point - ray3.direction * 0.1f;
						}
						else
						{
							vector2 += vector7;
						}
					}
					vector = vector2;
				}
				else
				{
					Vector3 direction = vector - vector2;
					if (Physics.Raycast(new Ray(vector2, direction), out var hitInfo4, direction.magnitude, layerMask))
					{
						vector = hitInfo4.point;
					}
				}
				if (Graphics.parent != CharacterActor.transform)
				{
					Graphics.SetParent(CharacterActor.transform);
					Graphics.localScale = Vector3.one;
					Graphics.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
					Graphics.GetComponent<CharacterStepLerper>().enabled = true;
					if (CharacterPreSeatedAnimatorController != null && CharacterAnimator.runtimeAnimatorController != CharacterPreSeatedAnimatorController)
					{
						CharacterAnimator.runtimeAnimatorController = CharacterPreSeatedAnimatorController;
					}
					CurrentIKSeat?.ReleasePose();
					CurrentIKSeat = null;
				}
				CharacterActor.InitializeAnimation();
				AvatarActive = true;
				CharacterActor.ForceNotGrounded(0, false);
				CharacterActor.Position = vector;
				CharacterActor.Rotation = rotation;
				CharacterActor.Velocity = exitVelocity.Value;
				CharacterActor.Up = Vector3.up;
			}
			_previousAircraft = Aircraft;
			CurrentSeat = null;
			Aircraft = null;
			_previousAircraft.OnPlayerExited(this);
			this.AircraftExited?.Invoke(this, new FlightScenePlayerAircraftEventArgs(this, _previousAircraft));
		}

		public void GetAllies(List<FlightScenePlayer> allies)
		{
			if (allies == null)
			{
				throw new ArgumentNullException("allies");
			}
			GetAlliesAndEnemies(allies, null);
		}

		public void GetAlliesAndEnemies(List<FlightScenePlayer> allies, List<FlightScenePlayer> enemies)
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			ushort teamId = TeamId;
			NetworkedActivityScript networkedActivityScript = Owner?.NetworkedActivity;
			_ = networkedActivityScript != null;
			foreach (FlightScenePlayer allPlayer in instance.AllPlayers)
			{
				if (allPlayer == null || allPlayer == this)
				{
					continue;
				}
				NetworkedActivityScript networkedActivityScript2 = allPlayer.Owner?.NetworkedActivity;
				if (!(networkedActivityScript != networkedActivityScript2))
				{
					switch (instance.TeamAggressionManager.GetAggressionLevel(teamId, allPlayer.TeamId))
					{
					case AggressionLevel.Friendly:
						allies?.Add(allPlayer);
						break;
					case AggressionLevel.Hostile:
						enemies?.Add(allPlayer);
						break;
					}
				}
			}
		}

		(Bounds Bounds, Vector3 BoundsOffset) IRepositionable.GetBounds()
		{
			if (Aircraft != null)
			{
				return ((IRepositionable)Aircraft).GetBounds();
			}
			if (CharacterActor?.ColliderComponent != null)
			{
				ColliderComponent colliderComponent = CharacterActor.ColliderComponent;
				Bounds item = new Bounds(colliderComponent.Center, colliderComponent.BoundsSize);
				Vector3 offset = colliderComponent.Offset;
				return (Bounds: item, BoundsOffset: offset);
			}
			return default((Bounds, Vector3));
		}

		public void GetEnemies(List<FlightScenePlayer> enemies)
		{
			if (enemies == null)
			{
				throw new ArgumentNullException("enemies");
			}
			GetAlliesAndEnemies(null, enemies);
		}

		public INetworkAircraft GetNetworkAircraft()
		{
			return (Aircraft ?? _previousAircraft)?.NetworkAircraft;
		}

		public void HideMeshesFpv(bool hide = true)
		{
			if (_avatarFpvCameraVantage != null)
			{
				Renderer[] shadowOnlyRenderers = _avatarFpvCameraVantage.ShadowOnlyRenderers;
				for (int i = 0; i < shadowOnlyRenderers.Length; i++)
				{
					shadowOnlyRenderers[i].shadowCastingMode = ((!hide) ? ShadowCastingMode.On : ShadowCastingMode.ShadowsOnly);
				}
			}
		}

		public void OnAircraftDespawning()
		{
			AvatarActive = false;
		}

		public void OnBeginReposition(Vector3 approximateGlobalPosition)
		{
			if (!NetworkPlayer.IsOwner)
			{
				throw new NotSupportedException("Unable to reposition flight scene player because the local client does not own the player.");
			}
			if (IsRepositioning)
			{
				throw new Exception("Unable to reposition flight scene player because they are currently being repositioned already.");
			}
			NetworkPlayer.RpcOnBeginReposition(approximateGlobalPosition);
			if (IsPrimaryLocal)
			{
				CameraManagerScript.Instance.OnPrimaryLocalPlayerRepositionBegin();
			}
			Aircraft?.OnBeginReposition(approximateGlobalPosition);
		}

		public void OnBeginRepositionServerAndClient(Vector3 approximateGlobalPosition)
		{
			RepositionTarget = new GameObject("PlayerRepositionTarget").transform;
			RepositionTarget.SetParent(FlightSceneScript.Instance.transform, worldPositionStays: false);
			RepositionTarget.position = Utility.ConvertAbsoluteToFloatingOriginPosition(approximateGlobalPosition);
		}

		public void OnCharacterLoaded(NetworkCharacterScript networkCharacter)
		{
			Vector3 framePosition = FramePosition;
			NetworkCharacter = networkCharacter;
			CharacterActor = networkCharacter.GetComponent<CharacterActor>();
			CharacterNormalMovement = networkCharacter.GetComponentInChildren<NormalMovement>();
			Graphics = networkCharacter.transform.Find("Graphics");
			networkCharacter.transform.SetParent(FlightSceneScript.Instance.AvatarContainer, worldPositionStays: true);
			networkCharacter.name = $"PlayerAvatar_{NetworkPlayer.PlayerId}";
			if (Graphics != null)
			{
				CharacterSuit = Graphics.GetComponentInChildren<CharacterSuitScript>();
				CharacterAnimator = CharacterSuit.GetComponent<Animator>();
			}
			if (IsPrimaryLocal)
			{
				if (CharacterActor != null)
				{
					Assets.Scripts.Character.State.CharacterStateController componentInChildren = CharacterActor.GetComponentInChildren<Assets.Scripts.Character.State.CharacterStateController>();
					componentInChildren.ExternalReference = FlightSceneScript.Instance.CameraScript.CameraTransform;
					componentInChildren.MovementReferenceMode = MovementReferenceParameters.MovementReferenceMode.External;
					componentInChildren.CharacterBrain.IsPlayer = true;
					CameraManagerScript.Instance.SwitchedToNewViewMode += CameraViewSwitched;
				}
				if (CharacterSuit != null)
				{
					CharacterManager.Character selectedCharacter = CharacterManager.Instance.SelectedCharacter;
					SetCharacterSuit(CharacterManager.Instance.SwapCharacterSuit(CharacterSuit, selectedCharacter.Name, selectedCharacter.SelectedSuit.Name, selectedCharacter.SelectedSuit.SelectedConfig));
					NetworkPlayer.SendSuitData(selectedCharacter.Name, selectedCharacter.SelectedSuit.Name, selectedCharacter.SelectedSuit.SelectedConfig);
				}
			}
			AvatarActive = false;
			FramePosition = framePosition;
		}

		public void OnEndReposition(Vector3 finalGlobalPosition, Vector3 finalRotation)
		{
			if (!NetworkPlayer.IsOwner)
			{
				throw new NotSupportedException("Unable to reposition flight scene player because the local client does not own the player.");
			}
			NetworkPlayer.RpcOnEndReposition(finalGlobalPosition, finalRotation, FlightSceneScript.Instance.FlightSceneNetwork.PhysicsTime);
			if (IsPrimaryLocal)
			{
				CameraManagerScript.Instance.OnPrimaryLocalPlayerRepositionEnd();
			}
			Aircraft?.OnEndReposition(finalGlobalPosition, finalRotation);
			this.LocationChanged?.Invoke(this, new FlightScenePlayerLocationChangedEventArgs());
		}

		public void OnEndRepositionServerAndClient(Vector3 finalGlobalPosition, Vector3 finalRotation, float physicsTime)
		{
			if (RepositionTarget != null)
			{
				UnityEngine.Object.Destroy(RepositionTarget.gameObject);
				RepositionTarget = null;
			}
			if (NetworkPlayer.IsOwner)
			{
				if ((object)Aircraft != null || !(CharacterActor != null))
				{
					return;
				}
				try
				{
					float stepDownDistance = CharacterActor.stepDownDistance;
					try
					{
						CharacterActor.stepDownDistance += 10f;
						CharacterActor.ForceGrounded();
						return;
					}
					finally
					{
						CharacterActor.stepDownDistance = stepDownDistance;
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					return;
				}
			}
			GlobalPosition = finalGlobalPosition;
			Rotation = finalRotation;
			if (NetworkCharacter != null)
			{
				NetworkCharacter.OnRepositionedRemotely(finalGlobalPosition, finalRotation, physicsTime);
			}
		}

		public void OnEnteredInFlightDesigner()
		{
			this.EnteredInFlightDesigner?.Invoke(this, new FlightScenePlayerEventArgs(this));
		}

		public void OnExitedInFlightDesigner()
		{
			this.ExitedInFlightDesigner?.Invoke(this, new FlightScenePlayerEventArgs(this));
		}

		public void OnNetworkedActivityJoined(NetworkedActivityScript activity)
		{
			if (NetworkedActivity != null)
			{
				throw new InvalidOperationException("Player '" + Name + "' is unable to join activity '" + activity.Data.DisplayName + "' because the player is already participating in another activity.");
			}
			NetworkedActivity = activity;
			this.NetworkedActivityJoined?.Invoke(this, new NetworkedActivityEventArgs(activity));
		}

		public void OnNetworkedActivityLeft()
		{
			if (NetworkedActivity == null)
			{
				throw new InvalidOperationException("Player '" + Name + "' is unable to leave their current activity because they are not currently participating in an activity.");
			}
			NetworkedActivityScript networkedActivity = NetworkedActivity;
			NetworkedActivity = null;
			this.NetworkedActivityLeft?.Invoke(this, new NetworkedActivityEventArgs(networkedActivity));
		}

		public void OnPlayerLeaving()
		{
			GetNetworkAircraft()?.OnPlayerLeaving();
			Unload();
		}

		public void RaiseAircraftLoadCompletedEvent(AircraftScript aircraftScript, bool success)
		{
			IsLoadingCraft = false;
			InitialCraftLoadCompleted = true;
			this.AircraftLoadCompleted?.Invoke(this, new FlightScenePlayerAircraftLoadCompletedEventArgs(this, aircraftScript, success));
		}

		public void RaiseAircraftLoadedEvent(AircraftScript aircraftScript)
		{
			aircraftScript.AircraftKilled += OnAircraftKilled;
			this.AircraftLoaded?.Invoke(this, new FlightScenePlayerAircraftEventArgs(this, aircraftScript));
		}

		public void RaiseAircraftLoadStartedEvent()
		{
			IsLoadingCraft = true;
			this.AircraftLoadStarted?.Invoke(this, new FlightScenePlayerEventArgs(this));
		}

		public void RaiseAircraftUnloadedEvent(AircraftScript aircraftScript)
		{
			aircraftScript.AircraftKilled -= OnAircraftKilled;
			this.AircraftUnloaded?.Invoke(this, new FlightScenePlayerAircraftEventArgs(this, aircraftScript));
		}

		public void RepositionOnGround()
		{
			Aircraft?.RepositionOnGround();
		}

		public void SetCharacterSuit(CharacterSuitScript characterSuit)
		{
			if (CharacterSuit != characterSuit)
			{
				if (FBBIK != null)
				{
					IKSolverFullBodyBiped solver = FBBIK.solver;
					solver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPostUpdate, new IKSolver.UpdateDelegate(OnIKPostUpdate));
				}
				CharacterSuit = characterSuit;
				CharacterAnimator = CharacterSuit.GetComponent<Animator>();
				FBBIK = CharacterSuit.GetComponent<FullBodyBipedIK>();
				IKSolverFullBodyBiped solver2 = FBBIK.solver;
				solver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver2.OnPostUpdate, new IKSolver.UpdateDelegate(OnIKPostUpdate));
				if (IsPrimaryLocal)
				{
					CameraDiscovery();
				}
			}
		}

		public void SetVelocity(Vector3 velocity, bool ignoreDisconnectedBodies = false)
		{
			if (Aircraft != null)
			{
				Aircraft?.SetVelocity(velocity, ignoreDisconnectedBodies);
			}
			else if (CharacterActor != null)
			{
				CharacterActor.Velocity = velocity;
			}
		}

		public void SpawnAircraft(bool startPaused = false)
		{
			if (!NetworkPlayer.IsOwner)
			{
				Debug.LogError("FlightScenePlayer.SpawnAircraft() may only be called by the owner.");
				return;
			}
			DespawnAircraft();
			IsLoadingCraft = true;
			NetworkPlayer.SpawnPlayerAircraft(StartLocation, startPaused);
		}

		public void Unload()
		{
			if (!IsUnloaded)
			{
				IsUnloaded = true;
				ExitAircraft();
				NetworkPlayer.FlightScenePlayer = null;
				NetworkPlayer.TeamChanged -= OnTeamChanged;
				if (_emptyAvatar != null)
				{
					UnityEngine.Object.Destroy(_emptyAvatar);
					_emptyAvatar = null;
				}
				if (IsPrimaryLocal)
				{
					DevConsoleApi.UnregisterCommand("Character_ExitAircraft");
					DevConsoleApi.UnregisterCommand("Character_EnterAircraft");
				}
				if ((object)FloatingOriginScript.Instance != null)
				{
					FloatingOriginScript.Instance.Repositioned -= OnFloatingOriginRepositioned;
				}
			}
		}

		public void Update()
		{
			if (IsPrimaryLocal && Game.Instance.UserInterface.AllowKeyboardInputs && !PauseManager.Paused && GameInputs.Instance.EnterExitCraft.GetButtonUpIfEnabled())
			{
				if ((object)Aircraft != null)
				{
					ExitAircraft();
				}
				else
				{
					EnterPreviousAircraft();
				}
			}
			if ((object)Aircraft != null)
			{
				_emptyAvatar.transform.position = Aircraft.Position;
				if (Avatar != null)
				{
					Avatar.transform.position = Aircraft.Position;
				}
			}
			else if (CharacterActor != null)
			{
				_emptyAvatar.transform.position = CharacterActor.Position;
			}
		}

		private void CameraViewSwitched(CameraController oldController, CameraController newController)
		{
			if (CharacterActor != null)
			{
				if (newController is FirstPersonCharacterCameraController)
				{
					CharacterNormalMovement.LookingDirectionParameters.LookDirectionMode = LookingDirectionParameters.LookingDirectionMode.ExternalReference;
					CharacterNormalMovement.LookingDirectionParameters.Speed = 100f;
					HideMeshesFpv();
				}
				else
				{
					CharacterNormalMovement.LookingDirectionParameters.LookDirectionMode = LookingDirectionParameters.LookingDirectionMode.Movement;
					CharacterNormalMovement.LookingDirectionParameters.Speed = 10f;
					HideMeshesFpv(hide: false);
				}
			}
		}

		private async UniTaskVoid DespawnNpcPlayerAfterDelayAsync()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(60.0));
			if (NetworkPlayer != null && NetworkPlayer.IsSpawned)
			{
				NetworkPlayer.RequestDespawn();
			}
		}

		private void OnAircraftKilled(object sender, AircraftKilledEventArgs e)
		{
			this.AircraftKilled?.Invoke(this, e);
			if (NetworkPlayer.IsNPC)
			{
				DespawnNpcPlayerAfterDelayAsync().Forget();
			}
		}

		private void OnFloatingOriginRepositioned(object sender, FloatingOriginUpdatedEventArgs e)
		{
			if (CharacterActor != null)
			{
				CharacterActor.canPushDynamicRigidbodies = false;
				CharacterActor.applyWeightToGround = false;
				Vector3 velocity = CharacterActor.Velocity;
				CharacterActor.Teleport(CharacterActor.Position - e.Delta);
				CharacterActor.Velocity = velocity;
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					if (CharacterActor != null)
					{
						CharacterActor.canPushDynamicRigidbodies = true;
						CharacterActor.applyWeightToGround = true;
					}
				});
			}
			if ((object)_emptyAvatar != null)
			{
				_emptyAvatar.transform.position -= e.Delta;
			}
		}

		private void OnIKPostUpdate()
		{
			this.IKPostUpdate?.Invoke(this, _playerEventArgs);
		}

		private void OnTeamChanged(object sender, TeamChangedEventArgs e)
		{
			TeamId = e.NewTeamId;
			this.TeamChanged?.Invoke(sender, e);
		}
	}
}
