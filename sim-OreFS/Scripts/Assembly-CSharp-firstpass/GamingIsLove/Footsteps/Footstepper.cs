using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

namespace GamingIsLove.Footsteps
{
	[AddComponentMenu("Footstepper/Footstepper")]
	public class Footstepper : MonoBehaviour
	{
		public static string VERSION = "1.6.0";

		[Tooltip("Select in which mode this footstepper operates:\n- Enabled: Uses both audio clips and prefabs from footstep sources.\n- Disabled: Isn't used at all.\n- Only Audio: Only uses audio clips from footstep sources.\n- Only Prefab: Only uses prefabs from footstep sources.\n")]
		public FootstepperMode mode;

		[Tooltip("Sets this footstepper as the footstep manager's player for distance checks.\nOnly set upon first adding the component to the scene ('Start' function)")]
		public bool isPlayer;

		[Tooltip("Define a tag to find a matching footstep effect, leave empty to use the material's default effect.\nYou can use tags to create different effects for e.g. 'heavy' and 'light' footsteppers.")]
		public string effectTag = "";

		[Tooltip("Prevent footstep effects when first initializing this footstepper (e.g. after loading a scene or spawning).\nTime in seconds.")]
		public float initialTimeout;

		[Tooltip("The time in seconds between allowing 2 footsteps.\nE.g. usefull when using animation blending, where mutliple animations might play an animation event.")]
		public float timeBetween = 0.05f;

		[Tooltip("The minimum weight an animation must have to play a footstep effect using animation events.\nThis is only used for footstep effects (walk, run, sprint), not for jump or land effects.")]
		[Range(0f, 1f)]
		public float minAnimationWeight = 0.4f;

		[Tooltip("Only play the footstep effect of the animation with the highest weight.\nThis only applies to animation events that are fired in the same frame and is only used for footstep effects (walk, run, sprint), not for jump or land effects.")]
		public bool onlyHighestAnimationWeight = true;

		[Header("Feet Settings")]
		[Tooltip("Define the feet that will be used - you can set up as many feet as you want.")]
		public List<Transform> feet = new List<Transform>();

		[Header("Speed Settings")]
		[Tooltip("Select when the movement speed is calculated, this should match the method used to move the game object:\n- None: No automatic speed calculation, e.g. use 'Speed' property to set the speed from your control component.\n- Update: In the 'Update' function (i.e. each frame).\n- Late Update: In the 'LateUpdate' function (i.e. each frame after all 'Update' functions have finished).\n- Fixed Update: In the 'FixedUpdate' function (i.e. each physics frame).")]
		public FootstepperSpeedUpdateType speedUpdateType = FootstepperSpeedUpdateType.FixedUpdate;

		[Tooltip("Calculating the movement speed uses X and Y axes instead of X and Z axes.")]
		public bool topDown2DMode;

		[Tooltip("Check the movement speed to use the correct volume.\nWhen using the dedicated functions for walking, running and sprinting footsteps, this will only play the footstep if the speed is correct.")]
		public bool useSpeedCheck = true;

		public float minSpeed;

		[Tooltip("The speed that determines if running is used.\nAnything below this speed is considered walking.")]
		public float runSpeed = 4f;

		[Tooltip("The speed that determines if sprinting is used.\nThe speed below this speed (and above the run speed) is considered running.")]
		public float sprintSpeed = 7f;

		[Header("Autoplay Footsteps")]
		[Tooltip("Automatically play the footstep effects at determined inveralls when the game object is moving.\nThe game object's movement speed determines which effect (and timeout) is used based on the run/sprint speed settings.\nUse this option if you don't want (or can't) use other methods like animation events.")]
		public bool autoPlay;

		[Tooltip("The time in seconds between playing two walk footstep effects.")]
		public float walkTimeout = 0.5f;

		[Tooltip("The time in seconds between playing two run footstep effects.")]
		public float runTimeout = 0.3f;

		[Tooltip("The time in seconds between playing two sprint footstep effects.")]
		public float sprintTimeout = 0.1f;

		[Header("Audio Settings")]
		[Tooltip("The audio source used to play the audio clips.")]
		public AudioSource source;

		[Range(0f, 1f)]
		[Tooltip("Randomizes the pitch when playing an audio clip.\nUses the audio sources starting pitch + a random value between + and - the pitch variation, e.g. a pitch of 1 and variation of 0.2 will use a pitch between 0.8 and 1.2.")]
		public float pitchVariation = 0.1f;

		[Header("Audio Volumes")]
		[Range(0f, 1f)]
		[Tooltip("The volume used at walking speed.")]
		public float walkVolume = 0.1f;

		[Range(0f, 1f)]
		[Tooltip("The volume used at running speed.")]
		public float runVolume = 0.2f;

		[Range(0f, 1f)]
		[Tooltip("The volume used at sprinting speed.")]
		public float sprintVolume = 0.3f;

		[Range(0f, 1f)]
		[Tooltip("The volume used for jumping.")]
		public float jumpVolume = 0.3f;

		[Range(0f, 1f)]
		[Tooltip("The volume used at landing.")]
		public float landVolume = 0.3f;

		[Range(0f, 1f)]
		[Tooltip("The volume used for custom effects.")]
		public float customEffectVolume = 0.5f;

		[Header("Raycast Settings")]
		[Tooltip("Select if 3D or 2D raycasting is used.")]
		public RaycastMode raycastMode;

		[Tooltip("Finding the footstep material below a foot (or the game object) uses raycasting.\nThe layer mask defines which layers will be checked for footstep sources.")]
		public LayerMask layerMask = -1;

		[Tooltip("The distance used for raycasting.")]
		public float rayDistance = 0.3f;

		[Tooltip("The offset to the foot's (or game object's) position when raycasting.")]
		public Vector3 rayOffset = Vector3.zero;

		[Tooltip("The offset is added in the local space of the foot, otherwise in local space of this game object.")]
		public bool inFootSpace;

		[Header("Auto Find")]
		[Tooltip("Search for tilemaps on the hit game object, using the hit position's tile sprite to find a footstep effect.\nRequires a 'Footstep Manager' in the scene.")]
		public bool searchTilemaps = true;

		[Tooltip("Search for renderers on the hit game object, using the renderer's main texture/sprite to find a footstep effect.\nRequires a 'Footstep Manager' in the scene.")]
		public bool searchRenderers = true;

		[Header("Fallback Effect")]
		[Tooltip("The fallback material is used if no footstep source was found.\nThis still requires the raycast to hit something.")]
		public FootstepMaterial fallbackMaterial;

		[Tooltip("Use the fallback material even if the raycast didn't hit anything.")]
		public bool noRaycastFallback;

		[Space(20f)]
		[Tooltip("Fired whenever this Footstepper plays a footstep.")]
		public UnityEvent onFootstep;

		[Tooltip("Fired whenever this Footstepper plays a footstep with more detailed information: The foot's 'Transform', the 'FootstepEffect', the 'Vector3' position hit by the raycast and the 'Vector3' normal of the hit position.")]
		public FootstepEvent onFootstepDetailed;

		protected bool isGrounded = true;

		protected float timeout;

		protected float startPitch = 1f;

		protected Vector2 speed = Vector2.zero;

		protected Vector3 lastPosition = Vector3.zero;

		protected int autoPlayIndex;

		protected float autoPlayTimeout = 0.1f;

		protected List<FootstepSource> overrideSources = new List<FootstepSource>();

		protected AnimationEvent highestWeightEvent;

		protected Action<int> highestWeightCall;

		protected Action<int, string> highestWeightCustomCall;

		public virtual bool IsEnabled
		{
			get
			{
				if (FootstepperMode.Disabled != mode)
				{
					return FootstepManager.IsAllowed(this);
				}
				return false;
			}
		}

		public virtual bool IsAudioEnabled
		{
			get
			{
				if (mode != FootstepperMode.Enabled)
				{
					return FootstepperMode.OnlyAudio == mode;
				}
				return true;
			}
		}

		public virtual bool IsPrefabEnabled
		{
			get
			{
				if (mode != FootstepperMode.Enabled)
				{
					return FootstepperMode.OnlyPrefab == mode;
				}
				return true;
			}
		}

		public virtual Vector2 Speed
		{
			get
			{
				return speed;
			}
			set
			{
				speed = value;
			}
		}

		protected virtual void Start()
		{
			lastPosition = base.transform.position;
			if (source != null)
			{
				startPitch = source.pitch;
			}
			timeout = initialTimeout;
			if (isPlayer && FootstepManager.Instance != null)
			{
				FootstepManager.Instance.player = this;
			}
		}

		protected virtual void OnDisable()
		{
			ClearOverrideSources();
		}

		protected virtual void Update()
		{
			if (timeout > 0f)
			{
				timeout -= Time.deltaTime;
			}
			if (FootstepperSpeedUpdateType.Update == speedUpdateType)
			{
				CalculateSpeed();
			}
			if (!autoPlay || !(speed.x > 0f))
			{
				return;
			}
			autoPlayTimeout -= Time.deltaTime;
			if (autoPlayTimeout <= 0f)
			{
				FootstepIndex(autoPlayIndex++);
				if (autoPlayIndex >= feet.Count)
				{
					autoPlayIndex = 0;
				}
			}
		}

		protected virtual void LateUpdate()
		{
			if (FootstepperSpeedUpdateType.LateUpdate == speedUpdateType)
			{
				CalculateSpeed();
			}
			if (onlyHighestAnimationWeight && highestWeightEvent != null)
			{
				if (highestWeightCustomCall != null)
				{
					highestWeightCustomCall(highestWeightEvent.intParameter, highestWeightEvent.stringParameter);
				}
				else if (highestWeightCall != null)
				{
					highestWeightCall(highestWeightEvent.intParameter);
				}
				highestWeightEvent = null;
				highestWeightCall = null;
				highestWeightCustomCall = null;
			}
		}

		protected virtual void FixedUpdate()
		{
			if (FootstepperSpeedUpdateType.FixedUpdate == speedUpdateType)
			{
				CalculateSpeed();
			}
		}

		public virtual void CalculateSpeed()
		{
			Vector3 vector = (base.transform.position - lastPosition) / Time.fixedDeltaTime;
			if (topDown2DMode)
			{
				speed.x = vector.magnitude;
			}
			else
			{
				speed.y = vector.y;
				vector.y = 0f;
				speed.x = vector.magnitude;
			}
			lastPosition = base.transform.position;
		}

		public virtual void AddOverrideSource(FootstepSource footstepSource)
		{
			overrideSources.Add(footstepSource);
		}

		public virtual void RemoveOverrideSource(FootstepSource footstepSource)
		{
			overrideSources.Remove(footstepSource);
		}

		public virtual void ClearOverrideSources()
		{
			overrideSources.Clear();
		}

		public virtual FootstepEffect GetOverrideEffect(Vector3 position)
		{
			FootstepEffect footstepEffect = null;
			for (int num = overrideSources.Count - 1; num >= 0; num--)
			{
				if (overrideSources[num].enabled)
				{
					footstepEffect = overrideSources[num].GetFootstepAt(position, effectTag);
					if (footstepEffect != null)
					{
						return footstepEffect;
					}
				}
			}
			return null;
		}

		public virtual void SetGrounded(bool grounded)
		{
			isGrounded = grounded;
		}

		public virtual Transform GetFoot(int index)
		{
			if (index >= 0 && index < feet.Count && feet[index] != null)
			{
				return feet[index];
			}
			return base.transform;
		}

		public virtual void GetSpeedType(ref float volume, ref FootstepType type)
		{
			volume = runVolume;
			type = FootstepType.Run;
			autoPlayTimeout = runTimeout;
			if (useSpeedCheck)
			{
				if (speed.x < runSpeed)
				{
					volume = walkVolume;
					type = FootstepType.Walk;
					autoPlayTimeout = walkTimeout;
				}
				else if (speed.x >= sprintSpeed)
				{
					volume = sprintVolume;
					type = FootstepType.Sprint;
					autoPlayTimeout = sprintTimeout;
				}
			}
		}

		public virtual void PlayFootstep(Transform foot, float volume, FootstepType type, string customName)
		{
			if (!(timeout <= 0f))
			{
				return;
			}
			Vector3 hitPosition;
			Vector3 hitNormal;
			FootstepEffect footstepEffect = FindFootstep(foot, out hitPosition, out hitNormal);
			if (footstepEffect == null)
			{
				return;
			}
			if (IsAudioEnabled)
			{
				AudioClip clip = footstepEffect.GetClip(type, customName);
				if (clip != null && source != null && volume > 0f)
				{
					source.pitch = startPitch + UnityEngine.Random.Range(0f - pitchVariation, pitchVariation);
					source.PlayOneShot(clip, volume);
				}
			}
			if (IsPrefabEnabled)
			{
				FootstepPrefab prefab = footstepEffect.GetPrefab(type, customName);
				if (prefab != null && prefab.prefab != null)
				{
					StartCoroutine(prefab.CreatePrefab(base.transform, foot, hitPosition, hitNormal));
				}
			}
			timeout = timeBetween;
			onFootstep.Invoke();
			onFootstepDetailed.Invoke(foot, footstepEffect, hitPosition, hitNormal);
		}

		public virtual void PlayFootstep(Transform foot, FootstepSource footstepSource, bool raycastPosition)
		{
			if (!IsEnabled || !(timeout <= 0f))
			{
				return;
			}
			Vector3 vector = foot.position;
			Vector3 vector2 = Vector3.up;
			if (raycastPosition)
			{
				RaycastResult raycastResult = Raycast(foot);
				if (raycastResult != null)
				{
					vector = raycastResult.point;
					vector2 = raycastResult.normal;
				}
			}
			FootstepEffect footstepEffect = null;
			if (overrideSources.Count > 0)
			{
				footstepEffect = GetOverrideEffect(vector);
			}
			if (footstepEffect == null)
			{
				footstepEffect = footstepSource.GetFootstepAt(vector, effectTag);
			}
			if (footstepEffect == null)
			{
				return;
			}
			FootstepType type = FootstepType.Run;
			float volume = runVolume;
			GetSpeedType(ref volume, ref type);
			if (IsAudioEnabled)
			{
				AudioClip clip = footstepEffect.GetClip(type, "");
				if (clip != null && source != null && volume > 0f)
				{
					source.pitch = startPitch + UnityEngine.Random.Range(0f - pitchVariation, pitchVariation);
					source.PlayOneShot(clip, volume);
				}
			}
			if (IsPrefabEnabled)
			{
				FootstepPrefab prefab = footstepEffect.GetPrefab(type, "");
				if (prefab != null && prefab.prefab != null)
				{
					StartCoroutine(prefab.CreatePrefab(base.transform, foot, vector, vector2));
				}
			}
			timeout = timeBetween;
			onFootstep.Invoke();
			onFootstepDetailed.Invoke(foot, footstepEffect, vector, vector2);
		}

		public virtual FootstepEffect FindFootstep(Transform foot, out Vector3 hitPosition, out Vector3 hitNormal)
		{
			hitPosition = foot.position;
			hitNormal = Vector3.up;
			if (overrideSources.Count > 0)
			{
				FootstepEffect overrideEffect = GetOverrideEffect(foot.position);
				if (overrideEffect != null)
				{
					RaycastResult raycastResult = Raycast(foot);
					if (raycastResult != null)
					{
						hitPosition = raycastResult.point;
						hitNormal = raycastResult.normal;
					}
					return overrideEffect;
				}
			}
			RaycastResult raycastResult2 = Raycast(foot);
			if (raycastResult2 != null)
			{
				hitPosition = raycastResult2.point;
				hitNormal = raycastResult2.normal;
				FootstepSource componentInParent = raycastResult2.transform.GetComponentInParent<FootstepSource>();
				if (componentInParent != null)
				{
					FootstepEffect footstepAt = componentInParent.GetFootstepAt(foot.position, effectTag);
					if (footstepAt != null)
					{
						return footstepAt;
					}
				}
				if (FootstepManager.Instance != null)
				{
					if (searchTilemaps)
					{
						Tilemap[] componentsInChildren = raycastResult2.transform.GetComponentsInChildren<Tilemap>();
						if (componentsInChildren != null && componentsInChildren.Length != 0)
						{
							for (int i = 0; i < componentsInChildren.Length; i++)
							{
								Sprite sprite = componentsInChildren[i].GetSprite(componentsInChildren[i].WorldToCell(raycastResult2.point));
								if (sprite != null)
								{
									FootstepEffect footstepFor = FootstepManager.Instance.GetFootstepFor(sprite, effectTag);
									if (footstepFor != null)
									{
										return footstepFor;
									}
								}
							}
						}
					}
					if (searchRenderers)
					{
						Renderer componentInParent2 = raycastResult2.transform.GetComponentInParent<Renderer>();
						if (componentInParent2 != null)
						{
							if (componentInParent2 is SpriteRenderer)
							{
								FootstepEffect footstepFor2 = FootstepManager.Instance.GetFootstepFor(((SpriteRenderer)componentInParent2).sprite, effectTag);
								if (footstepFor2 != null)
								{
									return footstepFor2;
								}
							}
							else
							{
								FootstepEffect footstepFor3 = FootstepManager.Instance.GetFootstepFor(componentInParent2.material.mainTexture, effectTag);
								if (footstepFor3 != null)
								{
									return footstepFor3;
								}
							}
						}
					}
				}
				if (fallbackMaterial != null)
				{
					return fallbackMaterial.GetEffect(effectTag);
				}
			}
			else if (noRaycastFallback && fallbackMaterial != null)
			{
				return fallbackMaterial.GetEffect(effectTag);
			}
			return null;
		}

		public virtual void Footstep(AnimationEvent evt)
		{
			if (!IsEnabled)
			{
				return;
			}
			if (evt.isFiredByAnimator)
			{
				if (!(evt.animatorClipInfo.weight >= minAnimationWeight))
				{
					return;
				}
				if (onlyHighestAnimationWeight)
				{
					if (highestWeightEvent == null || highestWeightEvent.animatorClipInfo.weight < evt.animatorClipInfo.weight)
					{
						highestWeightEvent = evt;
						highestWeightCall = FootstepIndex;
						highestWeightCustomCall = null;
					}
				}
				else
				{
					FootstepIndex(evt.intParameter);
				}
			}
			else
			{
				if (!evt.isFiredByLegacy || !(evt.animationState.weight >= minAnimationWeight))
				{
					return;
				}
				if (onlyHighestAnimationWeight)
				{
					if (highestWeightEvent == null || highestWeightEvent.animationState.weight < evt.animationState.weight)
					{
						highestWeightEvent = evt;
						highestWeightCall = FootstepIndex;
						highestWeightCustomCall = null;
					}
				}
				else
				{
					FootstepIndex(evt.intParameter);
				}
			}
		}

		public virtual void FootstepIndex(int index)
		{
			if (isGrounded && IsEnabled && (!useSpeedCheck || speed.x >= minSpeed))
			{
				float volume = runVolume;
				FootstepType type = FootstepType.Run;
				GetSpeedType(ref volume, ref type);
				PlayFootstep(GetFoot(index), volume, type, "");
			}
		}

		public virtual void FootstepWalk(AnimationEvent evt)
		{
			if (!IsEnabled)
			{
				return;
			}
			if (evt.isFiredByAnimator)
			{
				if (!(evt.animatorClipInfo.weight >= minAnimationWeight))
				{
					return;
				}
				if (onlyHighestAnimationWeight)
				{
					if (highestWeightEvent == null || highestWeightEvent.animatorClipInfo.weight < evt.animatorClipInfo.weight)
					{
						highestWeightEvent = evt;
						highestWeightCall = FootstepWalkIndex;
						highestWeightCustomCall = null;
					}
				}
				else
				{
					FootstepWalkIndex(evt.intParameter);
				}
			}
			else
			{
				if (!evt.isFiredByLegacy || !(evt.animationState.weight >= minAnimationWeight))
				{
					return;
				}
				if (onlyHighestAnimationWeight)
				{
					if (highestWeightEvent == null || highestWeightEvent.animationState.weight < evt.animationState.weight)
					{
						highestWeightEvent = evt;
						highestWeightCall = FootstepWalkIndex;
						highestWeightCustomCall = null;
					}
				}
				else
				{
					FootstepWalkIndex(evt.intParameter);
				}
			}
		}

		public virtual void FootstepWalkIndex(int index)
		{
			if (isGrounded && IsEnabled && (!useSpeedCheck || (speed.x >= minSpeed && speed.x < runSpeed)))
			{
				PlayFootstep(GetFoot(index), walkVolume, FootstepType.Walk, "");
			}
		}

		public virtual void FootstepRun(AnimationEvent evt)
		{
			if (!IsEnabled)
			{
				return;
			}
			if (evt.isFiredByAnimator)
			{
				if (!(evt.animatorClipInfo.weight >= minAnimationWeight))
				{
					return;
				}
				if (onlyHighestAnimationWeight)
				{
					if (highestWeightEvent == null || highestWeightEvent.animatorClipInfo.weight < evt.animatorClipInfo.weight)
					{
						highestWeightEvent = evt;
						highestWeightCall = FootstepRunIndex;
						highestWeightCustomCall = null;
					}
				}
				else
				{
					FootstepRunIndex(evt.intParameter);
				}
			}
			else
			{
				if (!evt.isFiredByLegacy || !(evt.animationState.weight >= minAnimationWeight))
				{
					return;
				}
				if (onlyHighestAnimationWeight)
				{
					if (highestWeightEvent == null || highestWeightEvent.animationState.weight < evt.animationState.weight)
					{
						highestWeightEvent = evt;
						highestWeightCall = FootstepRunIndex;
						highestWeightCustomCall = null;
					}
				}
				else
				{
					FootstepRunIndex(evt.intParameter);
				}
			}
		}

		public virtual void FootstepRunIndex(int index)
		{
			if (isGrounded && IsEnabled && (!useSpeedCheck || (speed.x >= runSpeed && speed.x < sprintSpeed)))
			{
				PlayFootstep(GetFoot(index), runVolume, FootstepType.Run, "");
			}
		}

		public virtual void FootstepSprint(AnimationEvent evt)
		{
			if (!IsEnabled)
			{
				return;
			}
			if (evt.isFiredByAnimator)
			{
				if (!(evt.animatorClipInfo.weight >= minAnimationWeight))
				{
					return;
				}
				if (onlyHighestAnimationWeight)
				{
					if (highestWeightEvent == null || highestWeightEvent.animatorClipInfo.weight < evt.animatorClipInfo.weight)
					{
						highestWeightEvent = evt;
						highestWeightCall = FootstepSprintIndex;
						highestWeightCustomCall = null;
					}
				}
				else
				{
					FootstepSprintIndex(evt.intParameter);
				}
			}
			else
			{
				if (!evt.isFiredByLegacy || !(evt.animationState.weight >= minAnimationWeight))
				{
					return;
				}
				if (onlyHighestAnimationWeight)
				{
					if (highestWeightEvent == null || highestWeightEvent.animationState.weight < evt.animationState.weight)
					{
						highestWeightEvent = evt;
						highestWeightCall = FootstepSprintIndex;
						highestWeightCustomCall = null;
					}
				}
				else
				{
					FootstepSprintIndex(evt.intParameter);
				}
			}
		}

		public virtual void FootstepSprintIndex(int index)
		{
			if (isGrounded && IsEnabled && (!useSpeedCheck || speed.x >= sprintSpeed))
			{
				PlayFootstep(GetFoot(index), runVolume, FootstepType.Sprint, "");
			}
		}

		public virtual void Jump(int index)
		{
			if (IsEnabled)
			{
				PlayFootstep(GetFoot(index), jumpVolume, FootstepType.Jump, "");
			}
		}

		public virtual void Land(int index)
		{
			if (IsEnabled)
			{
				PlayFootstep(GetFoot(index), landVolume, FootstepType.Land, "");
			}
		}

		public virtual void FootstepCustom(AnimationEvent evt)
		{
			if (!IsEnabled)
			{
				return;
			}
			if (evt.isFiredByAnimator)
			{
				if (!(evt.animatorClipInfo.weight >= minAnimationWeight))
				{
					return;
				}
				if (onlyHighestAnimationWeight)
				{
					if (highestWeightEvent == null || highestWeightEvent.animatorClipInfo.weight < evt.animatorClipInfo.weight)
					{
						highestWeightEvent = evt;
						highestWeightCustomCall = FootstepCustomIndex;
						highestWeightCall = null;
					}
				}
				else
				{
					FootstepCustomIndex(evt.intParameter, evt.stringParameter);
				}
			}
			else
			{
				if (!evt.isFiredByLegacy || !(evt.animationState.weight >= minAnimationWeight))
				{
					return;
				}
				if (onlyHighestAnimationWeight)
				{
					if (highestWeightEvent == null || highestWeightEvent.animationState.weight < evt.animationState.weight)
					{
						highestWeightEvent = evt;
						highestWeightCustomCall = FootstepCustomIndex;
						highestWeightCall = null;
					}
				}
				else
				{
					FootstepCustomIndex(evt.intParameter, evt.stringParameter);
				}
			}
		}

		public virtual void FootstepCustomIndex(int index, string customName)
		{
			if (IsEnabled)
			{
				PlayFootstep(GetFoot(index), customEffectVolume, FootstepType.Custom, customName);
			}
		}

		public virtual RaycastResult Raycast(Transform foot)
		{
			if (raycastMode == RaycastMode.Raycast3D)
			{
				return RaycastResult.Raycast3D(inFootSpace ? foot.TransformPoint(rayOffset) : (foot.position + base.transform.rotation * rayOffset), rayDistance, layerMask);
			}
			return RaycastResult.Raycast2D(inFootSpace ? foot.TransformPoint(rayOffset) : (foot.position + base.transform.rotation * rayOffset), rayDistance, layerMask);
		}

		protected virtual void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			if (feet.Count == 0)
			{
				Vector3 vector = base.transform.TransformPoint(rayOffset);
				RaycastResult raycastResult = Raycast(base.transform);
				if (raycastResult != null)
				{
					Gizmos.DrawLine(vector, raycastResult.point);
				}
				else
				{
					Gizmos.DrawLine(vector, vector + Vector3.down * rayDistance);
				}
				return;
			}
			for (int i = 0; i < feet.Count; i++)
			{
				if (feet[i] != null)
				{
					Vector3 vector2 = (inFootSpace ? feet[i].TransformPoint(rayOffset) : (feet[i].position + base.transform.rotation * rayOffset));
					RaycastResult raycastResult2 = Raycast(feet[i]);
					if (raycastResult2 != null)
					{
						Gizmos.DrawLine(vector2, raycastResult2.point);
					}
					else
					{
						Gizmos.DrawLine(vector2, vector2 + Vector3.down * rayDistance);
					}
				}
			}
		}

		protected virtual void OnDrawGizmos()
		{
			Gizmos.DrawIcon(base.transform.position, "/GamingIsLove/Footsteps/Footstepper Icon.png");
		}

		public void SetTimeBetween(float timeBetween)
		{
			this.timeBetween = timeBetween;
		}

		public void SetPlayer()
		{
			mode = FootstepperMode.Enabled;
			isPlayer = true;
			if (FootstepManager.Instance != null)
			{
				FootstepManager.Instance.player = this;
			}
		}
	}
}
