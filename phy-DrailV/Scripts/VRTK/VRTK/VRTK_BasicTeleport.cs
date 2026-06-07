using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Locomotion/VRTK_BasicTeleport")]
	public class VRTK_BasicTeleport : MonoBehaviour
	{
		[Header("Base Settings")]
		[Tooltip("The colour to fade to when fading on teleport.")]
		public Color blinkToColor = Color.black;

		[Tooltip("The time taken to fade to the `Blink To Color`. Setting the speed to `0` will mean no fade effect is present.")]
		public float blinkTransitionSpeed = 0.6f;

		[Tooltip("Determines how long the fade will stay present out depending on the distance being teleported. A value of `0` will not delay the teleport fade effect over any distance, a max value will delay the teleport fade in even when the distance teleported is very close to the original position.")]
		[Range(0f, 32f)]
		public float distanceBlinkDelay;

		[Tooltip("If this is checked then the teleported location will be the position of the headset within the play area. If it is unchecked then the teleported location will always be the centre of the play area even if the headset position is not in the centre of the play area.")]
		public bool headsetPositionCompensation = true;

		[Tooltip("A specified VRTK_PolicyList to use to determine whether destination targets will be acted upon by the teleporter.")]
		public VRTK_PolicyList targetListPolicy;

		[Tooltip("An optional NavMeshData object that will be utilised for limiting the teleport to within any scene NavMesh.")]
		public VRTK_NavMeshData navMeshData;

		[Header("Obsolete Settings")]
		[Obsolete("`VRTK_BasicTeleport.navMeshLimitDistance` is no longer used, use `VRTK_BasicTeleport.processNavMesh` instead. This parameter will be removed in a future version of VRTK.")]
		[ObsoleteInspector]
		public float navMeshLimitDistance;

		protected Transform headset;

		protected Transform playArea;

		protected bool adjustYForTerrain;

		protected bool enableTeleport = true;

		protected float blinkPause;

		protected float fadeInTime;

		protected float maxBlinkTransitionSpeed = 1.5f;

		protected float maxBlinkDistance = 33f;

		protected Coroutine initaliseListeners;

		protected bool useGivenForcedPosition;

		protected Vector3 givenForcedPosition = Vector3.zero;

		protected Quaternion? givenForcedRotation;

		public event TeleportEventHandler Teleporting;

		public event TeleportEventHandler Teleported;

		public virtual void InitDestinationSetListener(GameObject markerMaker, bool register)
		{
			if (!(markerMaker != null))
			{
				return;
			}
			VRTK_DestinationMarker[] componentsInChildren = markerMaker.GetComponentsInChildren<VRTK_DestinationMarker>();
			foreach (VRTK_DestinationMarker vRTK_DestinationMarker in componentsInChildren)
			{
				if (register)
				{
					vRTK_DestinationMarker.DestinationMarkerSet += DoTeleport;
					if (vRTK_DestinationMarker.targetListPolicy == null)
					{
						vRTK_DestinationMarker.targetListPolicy = targetListPolicy;
					}
					vRTK_DestinationMarker.SetNavMeshData(navMeshData);
					vRTK_DestinationMarker.SetHeadsetPositionCompensation(headsetPositionCompensation);
				}
				else
				{
					vRTK_DestinationMarker.DestinationMarkerSet -= DoTeleport;
				}
			}
		}

		public virtual void ToggleTeleportEnabled(bool state)
		{
			enableTeleport = state;
		}

		public virtual bool ValidLocation(Transform target, Vector3 destinationPosition)
		{
			if (target == null || VRTK_PlayerObject.IsPlayerObject(target.gameObject) || (bool)target.GetComponent<VRTK_UIGraphicRaycaster>())
			{
				return false;
			}
			bool flag = false;
			if (!(navMeshData != null) || NavMesh.SamplePosition(destinationPosition, out var _, navMeshData.distanceLimit, navMeshData.validAreas))
			{
				return !VRTK_PolicyList.Check(target.gameObject, targetListPolicy);
			}
			return false;
		}

		public virtual void Teleport(DestinationMarkerEventArgs teleportArgs)
		{
			DoTeleport(this, teleportArgs);
		}

		public virtual void Teleport(Transform target, Vector3 destinationPosition, Quaternion? destinationRotation = null, bool forceDestinationPosition = false)
		{
			DestinationMarkerEventArgs teleportArgs = BuildTeleportArgs(target, destinationPosition, destinationRotation, forceDestinationPosition);
			Teleport(teleportArgs);
		}

		public virtual void ForceTeleport(Vector3 destinationPosition, Quaternion? destinationRotation = null)
		{
			DestinationMarkerEventArgs e = BuildTeleportArgs(null, destinationPosition, destinationRotation);
			StartTeleport(this, e);
			Quaternion targetRotation = SetNewRotation(destinationRotation);
			Vector3 compensatedPosition = GetCompensatedPosition(destinationPosition, destinationPosition);
			CalculateBlinkDelay(blinkTransitionSpeed, compensatedPosition);
			Blink(blinkTransitionSpeed);
			if (ValidRigObjects())
			{
				playArea.position = compensatedPosition;
			}
			ProcessOrientation(this, e, compensatedPosition, targetRotation);
			EndTeleport(this, e);
		}

		public virtual void SetActualTeleportDestination(Vector3 actualPosition, Quaternion? actualRotation)
		{
			useGivenForcedPosition = true;
			givenForcedPosition = actualPosition;
			givenForcedRotation = actualRotation;
		}

		public virtual void ResetActualTeleportDestination()
		{
			useGivenForcedPosition = false;
		}

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			VRTK_PlayerObject.SetPlayerObject(base.gameObject, VRTK_PlayerObject.ObjectTypes.CameraRig);
			headset = VRTK_SharedMethods.AddCameraFade();
			playArea = VRTK_DeviceFinder.PlayAreaTransform();
			adjustYForTerrain = false;
			enableTeleport = true;
			initaliseListeners = StartCoroutine(InitListenersAtEndOfFrame());
			VRTK_ObjectCache.registeredTeleporters.Add(this);
		}

		protected virtual void OnDisable()
		{
			if (initaliseListeners != null)
			{
				StopCoroutine(initaliseListeners);
			}
			InitDestinationMarkerListeners(state: false);
			VRTK_ObjectCache.registeredTeleporters.Remove(this);
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void Blink(float transitionSpeed)
		{
			fadeInTime = transitionSpeed;
			if (transitionSpeed > 0f)
			{
				VRTK_SDK_Bridge.HeadsetFade(blinkToColor, 0f);
			}
			Invoke("ReleaseBlink", blinkPause);
		}

		protected virtual DestinationMarkerEventArgs BuildTeleportArgs(Transform target, Vector3 destinationPosition, Quaternion? destinationRotation = null, bool forceDestinationPosition = false)
		{
			return new DestinationMarkerEventArgs
			{
				distance = (ValidRigObjects() ? Vector3.Distance(new Vector3(headset.position.x, playArea.position.y, headset.position.z), destinationPosition) : 0f),
				target = target,
				raycastHit = default(RaycastHit),
				destinationPosition = destinationPosition,
				destinationRotation = destinationRotation,
				forceDestinationPosition = forceDestinationPosition,
				enableTeleport = true
			};
		}

		protected virtual bool ValidRigObjects()
		{
			if (headset == null)
			{
				VRTK_Logger.Warn(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_SCENE, "VRTK_BasicTeleport", "rig headset", ". Are you trying to access the headset before the SDK Manager has initialised it?"));
				return false;
			}
			if (playArea == null)
			{
				VRTK_Logger.Warn(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_SCENE, "VRTK_BasicTeleport", "rig boundaries", ". Are you trying to access the boundaries before the SDK Manager has initialised it?"));
				return false;
			}
			return true;
		}

		protected virtual void DoTeleport(object sender, DestinationMarkerEventArgs e)
		{
			if (enableTeleport && ValidLocation(e.target, e.destinationPosition) && e.enableTeleport)
			{
				if (useGivenForcedPosition)
				{
					e.destinationPosition = givenForcedPosition;
					e.destinationRotation = (givenForcedRotation.HasValue ? givenForcedRotation : e.destinationRotation);
					ResetActualTeleportDestination();
				}
				StartTeleport(sender, e);
				Quaternion targetRotation = SetNewRotation(e.destinationRotation);
				Vector3 newPosition = GetNewPosition(e.destinationPosition, e.target, e.forceDestinationPosition);
				CalculateBlinkDelay(blinkTransitionSpeed, newPosition);
				Blink(blinkTransitionSpeed);
				Vector3 targetPosition = SetNewPosition(newPosition, e.target, e.forceDestinationPosition);
				ProcessOrientation(sender, e, targetPosition, targetRotation);
				EndTeleport(sender, e);
			}
		}

		protected virtual void StartTeleport(object sender, DestinationMarkerEventArgs e)
		{
			OnTeleporting(sender, e);
		}

		protected virtual void ProcessOrientation(object sender, DestinationMarkerEventArgs e, Vector3 targetPosition, Quaternion targetRotation)
		{
		}

		protected virtual void EndTeleport(object sender, DestinationMarkerEventArgs e)
		{
			OnTeleported(sender, e);
		}

		protected virtual Vector3 SetNewPosition(Vector3 position, Transform target, bool forceDestinationPosition)
		{
			if (ValidRigObjects())
			{
				playArea.position = CheckTerrainCollision(position, target, forceDestinationPosition);
				return playArea.position;
			}
			return Vector3.zero;
		}

		protected virtual Quaternion SetNewRotation(Quaternion? rotation)
		{
			if (ValidRigObjects())
			{
				if (rotation.HasValue)
				{
					playArea.rotation = rotation.Value;
				}
				return playArea.rotation;
			}
			return Quaternion.identity;
		}

		protected virtual Vector3 GetNewPosition(Vector3 tipPosition, Transform target, bool returnOriginalPosition)
		{
			if (returnOriginalPosition)
			{
				return tipPosition;
			}
			return GetCompensatedPosition(tipPosition, playArea.position);
		}

		protected virtual Vector3 GetCompensatedPosition(Vector3 givenPosition, Vector3 defaultPosition)
		{
			float x = 0f;
			float y = 0f;
			float z = 0f;
			if (ValidRigObjects())
			{
				x = (headsetPositionCompensation ? (givenPosition.x - (headset.position.x - playArea.position.x)) : givenPosition.x);
				y = defaultPosition.y;
				z = (headsetPositionCompensation ? (givenPosition.z - (headset.position.z - playArea.position.z)) : givenPosition.z);
			}
			return new Vector3(x, y, z);
		}

		protected virtual Vector3 CheckTerrainCollision(Vector3 position, Transform target, bool useHeadsetForPosition)
		{
			Terrain component = target.GetComponent<Terrain>();
			if (adjustYForTerrain && component != null)
			{
				Vector3 worldPosition = ((useHeadsetForPosition && ValidRigObjects()) ? new Vector3(headset.position.x, position.y, headset.position.z) : position);
				float num = component.SampleHeight(worldPosition);
				position.y = ((num > position.y) ? position.y : (component.GetPosition().y + num));
			}
			return position;
		}

		protected virtual void OnTeleporting(object sender, DestinationMarkerEventArgs e)
		{
			if (this.Teleporting != null)
			{
				this.Teleporting(this, e);
			}
		}

		protected virtual void OnTeleported(object sender, DestinationMarkerEventArgs e)
		{
			if (this.Teleported != null)
			{
				this.Teleported(this, e);
			}
		}

		protected virtual void CalculateBlinkDelay(float blinkSpeed, Vector3 newPosition)
		{
			blinkPause = 0f;
			if (distanceBlinkDelay > 0f)
			{
				float num = 0.5f;
				float num2 = (ValidRigObjects() ? Vector3.Distance(playArea.position, newPosition) : 0f);
				blinkPause = Mathf.Clamp(num2 * blinkTransitionSpeed / (maxBlinkDistance - distanceBlinkDelay), num, maxBlinkTransitionSpeed);
				blinkPause = (((double)blinkSpeed <= 0.25) ? num : blinkPause);
			}
		}

		protected virtual void ReleaseBlink()
		{
			VRTK_SDK_Bridge.HeadsetFade(Color.clear, fadeInTime);
			fadeInTime = 0f;
		}

		protected virtual IEnumerator InitListenersAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			if (base.enabled)
			{
				InitDestinationMarkerListeners(state: true);
			}
		}

		protected virtual void InitDestinationMarkerListeners(bool state)
		{
			GameObject controllerLeftHand = VRTK_DeviceFinder.GetControllerLeftHand();
			GameObject controllerRightHand = VRTK_DeviceFinder.GetControllerRightHand();
			InitDestinationSetListener(controllerLeftHand, state);
			InitDestinationSetListener(controllerRightHand, state);
			for (int i = 0; i < VRTK_ObjectCache.registeredDestinationMarkers.Count; i++)
			{
				VRTK_DestinationMarker vRTK_DestinationMarker = VRTK_ObjectCache.registeredDestinationMarkers[i];
				if (vRTK_DestinationMarker.gameObject != controllerLeftHand && vRTK_DestinationMarker.gameObject != controllerRightHand)
				{
					InitDestinationSetListener(vRTK_DestinationMarker.gameObject, state);
				}
			}
		}
	}
}
