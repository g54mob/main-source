using ThreeEyedGames;
using UltimateReplay;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Decal))]
[RequireComponent(typeof(DecalLifeControl))]
public class DecalLifeControlReplay : ReplayBehaviour
{
	private Decal decal;

	private DecalLifeControl decalLifeControl;

	private bool isStickToOtherObject;

	private bool initialIsExisting;

	private float initialFadeValue;

	private Vector3 initialPosition;

	private Quaternion initialRotation;

	private Vector3 initialScale;

	private GameObject initialLimitTo;

	private Vector3 targetPosition;

	private Vector3 lastPosition;

	private Quaternion targetRotation;

	private Quaternion lastRotation;

	private bool shouldSaveBornPosition;

	public override void Awake()
	{
		base.Awake();
		decal = GetComponent<Decal>();
		decalLifeControl = GetComponent<DecalLifeControl>();
		lastPosition = (targetPosition = base.transform.position);
		lastRotation = (targetRotation = base.transform.rotation);
		shouldSaveBornPosition = true;
	}

	public override void OnReplayReset()
	{
		base.OnReplayReset();
		lastPosition = targetPosition;
		lastRotation = targetRotation;
	}

	public override void OnReplayStart()
	{
		base.OnReplayStart();
		decal.enabled = true;
		decalLifeControl.ShouldStopControl = true;
		initialIsExisting = decalLifeControl.IsExisting;
		initialFadeValue = decal.Fade;
		initialPosition = base.transform.position;
		initialRotation = base.transform.rotation;
		initialScale = base.transform.localScale;
		initialLimitTo = decal.LimitTo;
		decal.LimitTo = null;
		shouldSaveBornPosition = true;
	}

	public override void OnReplayEnd()
	{
		base.OnReplayEnd();
		decalLifeControl.ShouldStopControl = false;
		decalLifeControl.SetExistence(initialIsExisting);
		decal.Fade = initialFadeValue;
		base.transform.position = initialPosition;
		base.transform.rotation = initialRotation;
		base.transform.localScale = initialScale;
		decal.LimitTo = initialLimitTo;
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		bool isExisting = decalLifeControl.IsExisting;
		state.Write(isExisting);
		if (isExisting)
		{
			state.Write(decal.Fade);
			state.Write(shouldSaveBornPosition);
			if (shouldSaveBornPosition)
			{
				state.Write(base.transform.position);
				state.Write(base.transform.rotation);
				state.Write(base.transform.localScale);
				shouldSaveBornPosition = false;
			}
			bool flag = decalLifeControl.IsStickToOtherObject;
			state.Write(flag);
			if (flag)
			{
				state.Write(base.transform.position);
				state.Write(base.transform.rotation);
			}
		}
		else
		{
			shouldSaveBornPosition = true;
		}
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		bool flag = state.ReadBool();
		if (decalLifeControl.IsExisting != flag)
		{
			decalLifeControl.SetExistence(flag);
		}
		if (flag)
		{
			decal.Fade = state.ReadFloat();
			if (state.ReadBool())
			{
				base.transform.position = state.ReadVec3();
				base.transform.rotation = state.ReadQuat();
				base.transform.localScale = state.ReadVec3();
			}
			bool flag2 = state.ReadBool();
			if (flag2)
			{
				lastPosition = targetPosition;
				lastRotation = targetRotation;
				targetPosition = state.ReadVec3();
				targetRotation = state.ReadQuat();
			}
			isStickToOtherObject = flag2;
		}
	}

	public override void OnReplayUpdate()
	{
		base.OnReplayUpdate();
		if (isStickToOtherObject)
		{
			Vector3 vector = targetPosition;
			Quaternion quaternion = targetRotation;
			vector = Vector3.Lerp(lastPosition, targetPosition, ReplayTime.Delta);
			quaternion = Quaternion.Lerp(lastRotation, targetRotation, ReplayTime.Delta);
			base.transform.position = vector;
			base.transform.rotation = quaternion;
		}
	}
}
