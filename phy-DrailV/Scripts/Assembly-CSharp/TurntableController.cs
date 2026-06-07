using System;
using System.Collections.Generic;
using DV;
using DV.CabControls;
using DV.JObjectExtstensions;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class TurntableController : MonoBehaviour
{
	private const float MAX_ROTATION_SPEED_DEGREES_PER_SEC = 12f;

	private const float LEVER_POSITIVE_DIRECTION_THRESHOLD = 0.55f;

	private const float LEVER_NEGATIVE_DIRECTION_THRESHOLD = 0.45f;

	private const float MAX_SNAPPING_ROTATION_SPEED_DEGREES_PER_SEC = 10f;

	private const float PUSHING_INTENSITY = 0.2f;

	private const float PUSHING_DOT_PRODUCT_THRESHOLD = 0.5f;

	private const float REQUIRED_PUSHING_SQR_MAGNITUDE = 0.4f;

	private const string CURRENT_Y_ROTATION_SAVE_GAME_KEY = "rot";

	private static readonly Vector3 PUSH_HANDLE_HALF_EXTENTS = new Vector3(0.3f, 0f, 0.2f);

	private static List<TurntableController> allControllers = new List<TurntableController>();

	public GameObject leverGO;

	public TurntableRailTrack turntable;

	public float speedMultiplier = 1f;

	[Header("Sounds")]
	public AudioClip snapRangeEnterSound;

	public AudioClip trackConnectedSound;

	public LayeredAudio turntableRotateLayered;

	private float rotationSoundIntensity;

	private LeverBase leverControl;

	private bool snappingAngleSet;

	private float snappingAngle = -1f;

	private float snappingDirection;

	private bool playTrackConnectedSound;

	private bool playSnapRangeEnterSound;

	private float lastSnappingAnglePlayed = -1f;

	private LayerMask playerLayerMask;

	private Collider[] playerOverlapResults = new Collider[3];

	private float pushingPositiveDirectionValue;

	private float pushingNegativeDirectionValue;

	public bool PlayerControlAllowed { get; set; } = true;

	public event Action Snapped;

	private void Awake()
	{
		allControllers.Add(this);
		turntableRotateLayered = AudioManager.InstantiateLayeredAudio(turntableRotateLayered, turntable.transform);
		playerLayerMask = LayerMask.GetMask("Player");
	}

	private void Start()
	{
		leverControl = leverGO.GetComponent<LeverBase>();
	}

	private void OnDestroy()
	{
		allControllers.Remove(this);
	}

	private void FixedUpdate()
	{
		if (!WorldStreamingInit.IsLoaded || SingletonBehaviour<PausePhysicsHandler>.Instance.PhysicsHandlingInProcess)
		{
			return;
		}
		float value = (PlayerControlAllowed ? leverControl.Value : 0.5f);
		float num = ((pushingPositiveDirectionValue != 0f) ? pushingPositiveDirectionValue : Mathf.InverseLerp(0.55f, 1f, value));
		if (num > 0f)
		{
			rotationSoundIntensity = num;
			snappingAngleSet = false;
			UpdateSnappingRangeSound(turntable.ClosestSnappingAngle());
			float num2 = num * 12f * speedMultiplier;
			turntable.targetYRotation = TurntableRailTrack.AngleRange0To360(turntable.targetYRotation + num2 * Time.fixedDeltaTime);
			turntable.RotateToTargetRotation();
			return;
		}
		float num3 = ((pushingNegativeDirectionValue != 0f) ? pushingNegativeDirectionValue : Mathf.InverseLerp(0.45f, 0f, value));
		if (num3 > 0f)
		{
			rotationSoundIntensity = num3;
			snappingAngleSet = false;
			UpdateSnappingRangeSound(turntable.ClosestSnappingAngle());
			float num4 = (0f - num3) * 12f * speedMultiplier;
			turntable.targetYRotation = TurntableRailTrack.AngleRange0To360(turntable.targetYRotation + num4 * Time.fixedDeltaTime);
			turntable.RotateToTargetRotation();
			return;
		}
		if (!snappingAngleSet)
		{
			snappingAngle = turntable.ClosestSnappingAngle();
			snappingAngleSet = true;
			if (snappingAngle >= 0f)
			{
				float currentYRotation = turntable.currentYRotation;
				float num5 = TurntableRailTrack.AngleRange0To360(currentYRotation + 180f);
				float f = TurntableRailTrack.AngleRangeNeg180To180(snappingAngle - currentYRotation);
				float f2 = TurntableRailTrack.AngleRangeNeg180To180(snappingAngle - num5);
				snappingDirection = ((Mathf.Abs(f2) <= Mathf.Abs(f)) ? Mathf.Sign(f2) : Mathf.Sign(f));
			}
		}
		if (snappingAngle >= 0f)
		{
			float currentYRotation2 = turntable.currentYRotation;
			float angleA = TurntableRailTrack.AngleRange0To360(currentYRotation2 + 180f);
			if (!TurntableRailTrack.AnglesEqual(currentYRotation2, snappingAngle) && !TurntableRailTrack.AnglesEqual(angleA, snappingAngle))
			{
				float num6 = TurntableRailTrack.AngleRangeNeg180To180(snappingAngle - turntable.targetYRotation);
				float num7 = TurntableRailTrack.AngleRangeNeg180To180(num6 + 180f);
				float f3 = ((Mathf.Abs(num6) < Mathf.Abs(num7)) ? num6 : num7);
				float num8 = snappingDirection * Mathf.Min(Mathf.Abs(f3), 10f * Time.fixedDeltaTime);
				turntable.targetYRotation = TurntableRailTrack.AngleRange0To360(turntable.targetYRotation + num8);
				turntable.RotateToTargetRotation();
			}
			else
			{
				this.Snapped?.Invoke();
				playTrackConnectedSound = true;
				snappingAngle = -1f;
			}
		}
		rotationSoundIntensity = 0f;
	}

	private void Update()
	{
		if (!WorldStreamingInit.IsLoaded)
		{
			return;
		}
		if (playTrackConnectedSound)
		{
			if (trackConnectedSound != null)
			{
				trackConnectedSound.Play(turntable.transform.position, 1f, 1f, 0f, 10f, 500f, default(AudioSourceCurves), null, base.transform);
			}
			playTrackConnectedSound = false;
		}
		if (playSnapRangeEnterSound)
		{
			if (snapRangeEnterSound != null)
			{
				snapRangeEnterSound.Play(turntable.transform.position, 1f, 1f, 0f, 10f, 500f, default(AudioSourceCurves), null, base.transform);
			}
			playSnapRangeEnterSound = false;
		}
		if (rotationSoundIntensity > 0f || turntableRotateLayered.layers[0].source.isPlaying)
		{
			turntableRotateLayered.Set(rotationSoundIntensity);
		}
		float pushingInput = GetPushingInput(turntable.frontHandle);
		if (pushingInput != 0f)
		{
			if (pushingInput > 0f)
			{
				pushingPositiveDirectionValue = pushingInput * 0.2f;
				pushingNegativeDirectionValue = 0f;
			}
			else
			{
				pushingPositiveDirectionValue = 0f;
				pushingNegativeDirectionValue = Mathf.Abs(pushingInput) * 0.2f;
			}
			return;
		}
		float pushingInput2 = GetPushingInput(turntable.rearHandle);
		if (pushingInput2 != 0f)
		{
			if (pushingInput2 > 0f)
			{
				pushingPositiveDirectionValue = pushingInput2 * 0.2f;
				pushingNegativeDirectionValue = 0f;
			}
			else
			{
				pushingPositiveDirectionValue = 0f;
				pushingNegativeDirectionValue = Mathf.Abs(pushingInput2) * 0.2f;
			}
		}
		else
		{
			pushingPositiveDirectionValue = 0f;
			pushingNegativeDirectionValue = 0f;
		}
	}

	private float GetPushingInput(Transform handle)
	{
		if (!PlayerControlAllowed)
		{
			return 0f;
		}
		int num = Physics.OverlapBoxNonAlloc(handle.position, PUSH_HANDLE_HALF_EXTENTS, playerOverlapResults, handle.rotation, playerLayerMask, QueryTriggerInteraction.Collide);
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				CustomFirstPersonController component = playerOverlapResults[i].GetComponent<CustomFirstPersonController>();
				if (!(component != null))
				{
					continue;
				}
				bool flag = Vector3.Dot(Vector3.ProjectOnPlane(handle.position - component.transform.position, Vector3.up).normalized, handle.forward) >= 0f;
				Vector3 vector = Vector3.ProjectOnPlane(component.DesiredMove, Vector3.up);
				float sqrMagnitude = vector.sqrMagnitude;
				if (Vector3.Dot(vector.normalized, flag ? handle.forward : (-handle.forward)) > 0.5f && sqrMagnitude > 0.4f)
				{
					float num2 = Mathf.InverseLerp(0.4f, 1f, sqrMagnitude);
					if (!flag)
					{
						return 0f - num2;
					}
					return num2;
				}
				return 0f;
			}
		}
		return 0f;
	}

	private void UpdateSnappingRangeSound(float currentSnappingAngle)
	{
		if (currentSnappingAngle >= 0f)
		{
			bool num = TurntableRailTrack.AnglesEqual(currentSnappingAngle, lastSnappingAnglePlayed, 0.5f);
			bool flag = TurntableRailTrack.AnglesEqual(TurntableRailTrack.AngleRange0To360(currentSnappingAngle + 180f), lastSnappingAnglePlayed, 0.5f);
			if (!num && !flag)
			{
				playSnapRangeEnterSound = true;
				lastSnappingAnglePlayed = currentSnappingAngle;
			}
		}
		else
		{
			lastSnappingAnglePlayed = -1f;
		}
	}

	private JObject GetStateSaveData()
	{
		JObject jObject = new JObject();
		jObject.SetFloat("rot", turntable.currentYRotation);
		return jObject;
	}

	public void SetAngle(float angle, bool forceNoSnapping = false)
	{
		turntable.targetYRotation = angle;
		turntable.RotateToTargetRotation(forceConnectionRefresh: true);
		if (forceNoSnapping)
		{
			snappingAngleSet = true;
			snappingAngle = -1f;
			return;
		}
		snappingAngleSet = true;
		snappingAngle = turntable.ClosestSnappingAngle();
		if (snappingAngle >= 0f)
		{
			float currentYRotation = turntable.currentYRotation;
			float angleA = TurntableRailTrack.AngleRange0To360(currentYRotation + 180f);
			if (TurntableRailTrack.AnglesEqual(currentYRotation, snappingAngle) || TurntableRailTrack.AnglesEqual(angleA, snappingAngle))
			{
				snappingAngle = -1f;
			}
		}
	}

	private void LoadState(JObject saveData)
	{
		float? num = saveData.GetFloat("rot");
		if (num.HasValue)
		{
			SetAngle(num.Value);
		}
		else
		{
			Debug.LogError("Couldn't find rot to load!", this);
		}
	}

	public static JObject GetSaveData()
	{
		JObject jObject = new JObject();
		for (int i = 0; i < allControllers.Count; i++)
		{
			TurntableController turntableController = allControllers[i];
			TurntableRailTrack turntableRailTrack = turntableController.turntable;
			jObject.SetJObject(turntableRailTrack.uniqueID, turntableController.GetStateSaveData());
		}
		return jObject;
	}

	public static void LoadData(JObject turntableData)
	{
		int num = 0;
		for (int i = 0; i < allControllers.Count; i++)
		{
			TurntableController turntableController = allControllers[i];
			TurntableRailTrack turntableRailTrack = turntableController.turntable;
			JObject jObject = turntableData.GetJObject(turntableRailTrack.uniqueID);
			if (jObject != null)
			{
				num++;
				turntableController.LoadState(jObject);
			}
		}
		if (num < allControllers.Count)
		{
			Debug.LogWarning($"State for {allControllers.Count - num} turntables is not restored!");
		}
	}

	public static TurntableController FindClosestTo(Vector3 worldPosition)
	{
		if (allControllers == null || allControllers.Count == 0)
		{
			return null;
		}
		if (allControllers.Count == 1)
		{
			return allControllers[0];
		}
		TurntableController turntableController = allControllers[0];
		float num = Vector3.SqrMagnitude(turntableController.transform.position - worldPosition);
		for (int i = 1; i < allControllers.Count; i++)
		{
			float num2 = Vector3.SqrMagnitude(allControllers[i].transform.position - worldPosition);
			if (num2 < num)
			{
				turntableController = allControllers[i];
				num = num2;
			}
		}
		return turntableController;
	}
}
