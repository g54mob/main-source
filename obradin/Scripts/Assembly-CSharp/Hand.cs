using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Hand : MonoBehaviour
{
	private class AnimSet
	{
		public AnimationState idle;

		public AnimationState reach;

		public AnimationState touch;

		public AnimationState curl;

		public AnimationState grip;

		public AnimationState[] all;

		public AnimSet(Animation a, string reachAnimName, string touchAnimName, string curlAnimName, string gripAnimName)
		{
			idle = a["Idle"];
			reach = a[reachAnimName];
			touch = a[touchAnimName];
			curl = a[curlAnimName];
			grip = a[gripAnimName];
			all = new AnimationState[5] { idle, reach, touch, curl, grip };
			int num = 0;
			AnimationState[] array = all;
			foreach (AnimationState animationState in array)
			{
				animationState.blendMode = AnimationBlendMode.Blend;
				animationState.enabled = true;
				animationState.weight = 0f;
				animationState.speed = 0f;
				animationState.layer = num++;
			}
			idle.weight = 1f;
		}

		public void ZeroWeights(float step = 1f)
		{
			AnimationState[] array = all;
			foreach (AnimationState animationState in array)
			{
				float num = Mathf.Max(0f, animationState.weight - step);
				if (animationState.weight != num)
				{
					animationState.weight = num;
				}
			}
		}

		public void EnableAll()
		{
			AnimationState[] array = all;
			foreach (AnimationState animationState in array)
			{
				animationState.enabled = true;
			}
		}
	}

	private struct PrevProp
	{
		public Prop prop;

		private IkSolver.Target _ikTarget;

		private float startTime;

		private const float kLerpDuration = 1f;

		public bool isValid
		{
			get
			{
				return prop != null;
			}
		}

		public bool done
		{
			get
			{
				return prop != null && Clock.play.time - startTime > 1f;
			}
		}

		public float lerpOut
		{
			get
			{
				return (!(prop != null)) ? 1f : Mathf.SmoothStep(0f, 1f, Util.LerpScale(Clock.play.time - startTime, 0f, 1f, 0f, 1f));
			}
		}

		public IkSolver.Target ikTarget
		{
			get
			{
				IkSolver.Target result = _ikTarget;
				result.matrix.SetColumn(3, (result.matrix.GetColumn(3).ToVector3() + 0.1f * Mathf.Sin(lerpOut * (float)Math.PI) * Vector3.up).ToVector4(1f));
				return result;
			}
		}

		public void Clear()
		{
			prop = null;
			_ikTarget = default(IkSolver.Target);
			startTime = Clock.play.time;
		}

		public void Set(Prop prop_, IkSolver.Target ikTarget_)
		{
			prop = prop_;
			_ikTarget = ikTarget_;
			startTime = Clock.play.time;
		}
	}

	private class TouchGripStatus
	{
		public float distToGrip = float.MaxValue;

		public float angleToGrip;
	}

	private enum Mode
	{
		Normal = 0,
		Using = 1,
		Hiding = 2
	}

	public GameObject model;

	private Transform upperArm;

	private Transform lowerArm;

	private Transform palm;

	private Transform rest;

	private Transform restElbow;

	private Transform cuff;

	public float reachRadius = 2f;

	[HideInInspector]
	public List<Prop> allPropsInLevel;

	private Mode mode;

	private Util.Damper reachT = new Util.Damper();

	private Util.Damper relaxT = new Util.Damper();

	private Util.Damper reachTouchBlend = new Util.Damper();

	private Util.Damper touchCurlGripBlend = new Util.Damper();

	private Animation modelAnimation;

	private Dictionary<string, AnimSet> animSets = new Dictionary<string, AnimSet>();

	private Camera mainCamera;

	private Propmaster propmaster;

	private IkSolver ikSolver;

	private int raycastIgnoreLayerMask;

	private Vector3 cuffDefaultLocalPosition;

	private Prop curProp;

	private PrevProp prevProp;

	private TouchGripStatus touchGripStatus;

	private const float kRestRelaxMinDeflectionAngle = 70f;

	private Util.Damper smoothMinDeflectionAngle = new Util.Damper(70f);

	private Util.History minDeflectionAngleVels = new Util.History(3);

	private float breathStartTime;

	private Vector3 upperArmLocalPosition;

	private bool velcroCaptured;

	private Matrix4x4 velcroedMatrixInPalmSpace;

	private Renderer handRenderer;

	private float stopUsingTime = -1000f;

	private static Hand instance;

	private float startTime;

	private PropScore curPropScore = new PropScore();

	private PropScore bestNearbyPropScore = new PropScore();

	private PropScore workPropScore = new PropScore();

	public bool isUsing
	{
		get
		{
			return mode == Mode.Using;
		}
	}

	private bool justStoppedUsing
	{
		get
		{
			return Clock.play.time - stopUsingTime < 2f;
		}
	}

	private void Start()
	{
		modelAnimation = model.GetComponentInChildren<Animation>(true);
		mainCamera = GetComponentInChildren<Camera>(true);
		propmaster = GetComponent<Propmaster>();
		handRenderer = model.GetComponentInChildren<Renderer>(true);
		handRenderer.shadowCastingMode = ShadowCastingMode.Off;
		upperArm = model.transform.FindDescendant("upper_arm");
		lowerArm = model.transform.FindDescendant("lower_arm");
		palm = model.transform.FindDescendant("grip");
		rest = model.transform.FindDescendant("rest");
		restElbow = model.transform.FindDescendant("rest_elbow");
		cuff = model.transform.FindDescendant("cuff");
		cuffDefaultLocalPosition = cuff.localPosition;
		upperArmLocalPosition = upperArm.localPosition;
		raycastIgnoreLayerMask = 1 << LayerMask.NameToLayer("Player");
		ikSolver = new IkSolver(upperArm, lowerArm, palm);
		animSets.Add("Default", new AnimSet(modelAnimation, "Reach", "DoorHandle_Touch", "DoorHandle_Curl", "DoorHandle_Grip"));
		animSets.Add("DoorHandle", new AnimSet(modelAnimation, "Reach", "DoorHandle_Touch", "DoorHandle_Curl", "DoorHandle_Grip"));
		animSets.Add("Book", new AnimSet(modelAnimation, "Reach", "Book_Touch", "Book_Curl", "Book_Grip"));
		animSets.Add("Ball", new AnimSet(modelAnimation, "Reach", "Ball_Touch", "Ball_Curl", "Ball_Grip"));
		animSets.Add("Lantern", new AnimSet(modelAnimation, "Reach_Tip", "Lantern_Touch", "Lantern_Curl", "Lantern_Grip"));
		animSets.Add("Inspect", new AnimSet(modelAnimation, "Inspect", "Inspect", "Inspect", "Inspect"));
		modelAnimation.Play();
		prevProp = default(PrevProp);
		prevProp.Set(null, default(IkSolver.Target));
		touchGripStatus = new TouchGripStatus();
		mode = Mode.Normal;
		startTime = Clock.play.time;
	}

	private void Update()
	{
		if (Clock.play.time < startTime + 1f)
		{
			return;
		}
		if (mode == Mode.Normal)
		{
			GetPropScore(ref curPropScore, curProp, (!(curProp != null)) ? 90f : curProp.holdViewAngle);
			GetBestNearbyPropScore(ref bestNearbyPropScore);
			if (!curPropScore.valid)
			{
				if (bestNearbyPropScore.valid)
				{
					prevProp.Set((!(curProp != null)) ? prevProp.prop : curProp, ikSolver.solvedTarget);
					curProp = bestNearbyPropScore.nearby;
				}
				else if (curProp != null)
				{
					prevProp.Set(curProp, ikSolver.solvedTarget);
					curProp = null;
				}
			}
			else if (bestNearbyPropScore.IsBetterThan(curPropScore))
			{
				prevProp.Set(curProp, ikSolver.solvedTarget);
				curProp = bestNearbyPropScore.nearby;
			}
			if (curProp != null)
			{
				float handAngleToGrip = GetHandAngleToGrip(curProp);
				float distRelaxT = GetDistRelaxT(curProp);
				float num = Util.LerpScale(handAngleToGrip, -45f, -35f, 1f, 0f);
				float target = Mathf.Clamp01(distRelaxT + num);
				relaxT.Update(target, 0.25f);
				reachT.Update(1f, Mathf.Lerp(0.075f, 1f, distRelaxT));
			}
			else
			{
				relaxT.Update(1f, 1f);
				reachT.Update(0f, 1f);
			}
			if (curProp != null && touchGripStatus.distToGrip < ((!curProp.useInfo.moveIntoPosition) ? 0.01f : 0.25f) && RInput.GetButtonDown(4))
			{
				propmaster.StartSequence(curProp);
			}
		}
		else
		{
			if (mode == Mode.Hiding)
			{
				relaxT.Reset(0f);
				reachT.Reset(1f);
				return;
			}
			relaxT.Reset(0f);
			reachT.Reset(1f);
		}
		foreach (KeyValuePair<string, AnimSet> animSet2 in animSets)
		{
			animSet2.Value.ZeroWeights(Clock.play.deltaTime * 2f);
		}
		Prop activeProp = GetActiveProp();
		AnimSet animSet = animSets[(!(activeProp != null)) ? "Default" : activeProp.handAnimsId];
		float num2 = 0f;
		if (activeProp != null)
		{
			float input = 1f - Mathf.Pow(1f - touchGripStatus.angleToGrip / 90f, activeProp.angleToGripPow);
			num2 = Util.LerpScale(input, -1f, 1f, 0f, 1f);
		}
		else
		{
			num2 = Util.LerpScale(touchGripStatus.angleToGrip, -90f, 90f, 0f, 1f);
		}
		animSet.grip.normalizedTime = num2;
		animSet.curl.normalizedTime = num2;
		animSet.touch.normalizedTime = num2;
		float num3 = 0.5f;
		float num4 = 0.3f;
		float num5 = 0.07f;
		float inputMax = 0f;
		float num6 = 0.5f;
		float outputMax = 3f;
		if (curProp != null && curProp.slowPlayerWalk && touchGripStatus.distToGrip < num4)
		{
			outputMax = Util.LerpScale(Vector3.Distance(upperArm.position, curProp.grip.position), ikSolver.armLen * 0.5f, ikSolver.armLen + num3, 0.5f, outputMax);
		}
		if (touchGripStatus.distToGrip < num4)
		{
			float num7 = Util.LerpScale(touchGripStatus.distToGrip, num4, 0f, 0f, 1f);
			if (justStoppedUsing)
			{
				num7 = Mathf.Pow(num7, 3f);
			}
			if (num7 < (float)touchCurlGripBlend)
			{
				touchCurlGripBlend.Reset(num7);
			}
			else
			{
				touchCurlGripBlend.Update(num7, 0.075f);
			}
			float input2 = (1f - Mathf.Pow(touchCurlGripBlend, 3f)) * num4;
			float num8 = Util.LerpScale(input2, num4, num5, 1f, 0f);
			float num9 = Util.LerpScale(input2, num4, num5, 0f, 1f) - Util.LerpScale(input2, num5, inputMax, 0f, 1f);
			float num10 = Util.LerpScale(input2, num5, inputMax, 0f, 1f);
			float num11 = (num8 + num9 + num10) / 3f;
			animSet.touch.weight = num8 * num11;
			animSet.curl.weight = num9 * num11;
			animSet.grip.weight = num10 * num11;
			reachTouchBlend.Reset(1f);
		}
		else
		{
			float num12 = Util.LerpScale(touchGripStatus.distToGrip, num3, num4, 0f, 1f);
			if (num12 > (float)reachTouchBlend)
			{
				reachTouchBlend.Reset(num12);
			}
			else
			{
				reachTouchBlend.Update(num12, 0.25f);
			}
			animSet.grip.weight = 0f;
			animSet.curl.weight = 0f;
			animSet.touch.weight = (float)reachT * (float)reachTouchBlend;
			animSet.reach.weight = (float)reachT * (1f - (float)reachTouchBlend);
			animSet.idle.weight = 1f - (float)reachT;
			touchCurlGripBlend.Reset(0f);
		}
		if (activeProp != null && activeProp.crouchToReach && touchGripStatus.distToGrip < num6)
		{
			HeadMotion.instance.CrouchForOneFrame();
		}
		if (activeProp != null && !activeProp.showHandShadow)
		{
			handRenderer.shadowCastingMode = ShadowCastingMode.Off;
		}
		else
		{
			handRenderer.shadowCastingMode = ((touchGripStatus.distToGrip < num4) ? ShadowCastingMode.On : ShadowCastingMode.Off);
		}
	}

	private void OnEnable()
	{
		foreach (KeyValuePair<string, AnimSet> animSet in animSets)
		{
			animSet.Value.EnableAll();
		}
		instance = this;
	}

	private void OnDisable()
	{
		instance = null;
	}

	public void LateUpdate()
	{
		if (mode == Mode.Hiding)
		{
			return;
		}
		if ((float)reachT < 0.01f)
		{
			breathStartTime = Clock.play.time;
		}
		upperArm.localPosition = upperArmLocalPosition;
		upperArm.SetPositionY(upperArm.position.y + Mathf.Cos(2f * (Clock.play.time - breathStartTime)) * 0.0005f);
		IkSolver.Target target;
		if (mode == Mode.Normal)
		{
			if (!(curProp != null))
			{
				target = (prevProp.done ? MakeRestIkTarget() : IkSolver.Target.Lerp(prevProp.ikTarget, MakeRestIkTarget(), prevProp.lerpOut));
			}
			else
			{
				target = IkSolver.Target.Lerp(MakeRestIkTarget(), MakeGripIkTarget(curProp, relaxT), reachT);
				if (prevProp.isValid && !prevProp.done && prevProp.prop != curProp)
				{
					float lerpOut = prevProp.lerpOut;
					IkSolver.Target target2 = IkSolver.Target.Lerp(IkSolver.Target.Lerp(target, prevProp.ikTarget, 0.5f), MakeRestIkTarget(), 0.1f);
					target = ((!((double)lerpOut < 0.5)) ? IkSolver.Target.Lerp(target2, target, Util.LerpScale(lerpOut, 0.5f, 1f, 0f, 1f)) : IkSolver.Target.Lerp(prevProp.ikTarget, target2, Util.LerpScale(lerpOut, 0f, 0.5f, 0f, 1f)));
				}
			}
		}
		else
		{
			target = MakeUsingIkTarget(curProp);
		}
		if (curProp != null)
		{
			minDeflectionAngleVels.Add((target.minDeflectionAngle - ikSolver.solvedTarget.minDeflectionAngle) / Clock.play.deltaTime);
			smoothMinDeflectionAngle.Reset(target.minDeflectionAngle, minDeflectionAngleVels.average);
		}
		else
		{
			smoothMinDeflectionAngle.Update(target.minDeflectionAngle, 2f);
			target.minDeflectionAngle = smoothMinDeflectionAngle;
		}
		ikSolver.Solve(target, 1f);
		float input = Vector3.Angle(lowerArm.position - upperArm.position, cuff.position - lowerArm.position);
		float num = Mathf.Lerp(-0.05f, 0.015f, Mathf.SmoothStep(1f / 12f, 11f / 12f, Util.LerpScale(input, 0f, 120f, 0f, 1f)));
		cuff.localPosition = cuffDefaultLocalPosition + cuffDefaultLocalPosition.normalized * (cuffDefaultLocalPosition.magnitude + num);
		Prop activeProp = GetActiveProp();
		touchGripStatus.distToGrip = ((!(activeProp != null)) ? float.MaxValue : Vector3.Distance(palm.position, activeProp.grip.position));
		touchGripStatus.angleToGrip = GetHandAngleToGrip(activeProp);
		if (mode == Mode.Using && (bool)curProp.velcroed && velcroCaptured)
		{
			Matrix4x4 m = palm.localToWorldMatrix * velcroedMatrixInPalmSpace;
			curProp.velcroed.position = m.GetT();
			curProp.velcroed.rotation = Util.QuaternionFromMatrix(m);
		}
	}

	public void StartUsing(Prop prop)
	{
		curProp = prop;
		mode = Mode.Using;
		velcroCaptured = false;
	}

	public void CaptureVelcro()
	{
		if ((bool)curProp.velcroed)
		{
			velcroedMatrixInPalmSpace = palm.worldToLocalMatrix * curProp.velcroed.localToWorldMatrix;
			velcroCaptured = true;
		}
	}

	public void StopUsing()
	{
		if (mode == Mode.Using)
		{
			mode = Mode.Normal;
			prevProp.Set(curProp, ikSolver.solvedTarget);
			curProp = null;
			stopUsingTime = Clock.play.time;
		}
	}

	public void StartHiding()
	{
		mode = Mode.Hiding;
		model.SetActive(false);
	}

	public void StopHiding()
	{
		if (mode != Mode.Hiding)
		{
			return;
		}
		model.SetActive(true);
		mode = Mode.Normal;
		prevProp.Clear();
		curProp = null;
		stopUsingTime = Clock.play.time;
		foreach (KeyValuePair<string, AnimSet> animSet in animSets)
		{
			animSet.Value.EnableAll();
		}
	}

	private Prop GetActiveProp()
	{
		if (curProp == null || (prevProp.isValid && Vector3.Distance(curProp.grip.position, palm.position) > Vector3.Distance(prevProp.prop.grip.position, palm.position)))
		{
			return prevProp.prop;
		}
		return curProp;
	}

	private float GetDistRelaxT(Prop prop)
	{
		return Util.LerpScale(Vector3.Distance(prop.grip.position, upperArm.position), ikSolver.armLen + 0.2f, reachRadius, 0f, 1f);
	}

	private float GetHandAngleToGrip(Prop prop)
	{
		if (prop == null)
		{
			return 0f;
		}
		Matrix4x4 localToWorldMatrix = prop.grip.localToWorldMatrix;
		Vector3 x = localToWorldMatrix.GetX();
		Vector3 to = localToWorldMatrix.GetT() - lowerArm.position;
		return 0f - (90f - Vector3.Angle(x, to));
	}

	private void GetPropScore(ref PropScore score, Prop prop, float viewAngleMax)
	{
		if (prop == null || prop.grip == null || justStoppedUsing || !prop.canUse || !prop.enabled)
		{
			score.Reset();
		}
		else
		{
			score.Set(prop, prop.grip.localToWorldMatrix, upperArm.position, reachRadius, mainCamera, (!prop.ignoreViewAngle) ? viewAngleMax : 360f, raycastIgnoreLayerMask);
		}
	}

	private void GetBestNearbyPropScore(ref PropScore score)
	{
		score.Reset();
		workPropScore.Reset();
		foreach (Prop item in allPropsInLevel)
		{
			if (item.isActiveAndEnabled)
			{
				GetPropScore(ref workPropScore, item, item.reachViewAngle);
				if (workPropScore.IsBetterThan(score))
				{
					score.CopyFrom(workPropScore);
				}
			}
		}
	}

	private IkSolver.Target MakeUsingIkTarget(Prop prop)
	{
		if (prop.shouldFacePlayer)
		{
			return MakeGripIkTarget(prop, 0f);
		}
		return new IkSolver.Target
		{
			matrix = prop.releaseGrip.localToWorldMatrix,
			elbow = prop.releaseGripElbow.position,
			minDeflectionAngle = 0f
		};
	}

	private IkSolver.Target MakeGripIkTarget(Prop prop, float relaxT)
	{
		Vector3 vector = ((!prop.spinnableElbow) ? prop.grip.transform.right : Vector3.Cross(Vector3.up, (prop.grip.position - upperArm.position).normalized));
		Vector3 vector2 = Vector3.Cross(vector, Vector3.up);
		Matrix4x4 matrix4x = default(Matrix4x4);
		matrix4x.SetColumn(0, vector);
		matrix4x.SetColumn(1, Vector3.up);
		matrix4x.SetColumn(2, vector2);
		matrix4x.SetColumn(3, prop.grip.position.ToVector4(1f));
		Vector3 a = matrix4x.MultiplyPoint(new Vector3(0.5f, -0.5f, 0f));
		Vector3 b = mainCamera.transform.localToWorldMatrix.MultiplyPoint(new Vector3(1f, -0.5f, -0.5f));
		return new IkSolver.Target
		{
			matrix = prop.grip.localToWorldMatrix,
			elbow = Vector3.Lerp(a, b, relaxT),
			minDeflectionAngle = Mathf.Lerp(10f, 70f, 1f - Mathf.Pow(1f - relaxT, 2f))
		};
	}

	private IkSolver.Target MakeRestIkTarget()
	{
		return new IkSolver.Target
		{
			matrix = rest.localToWorldMatrix,
			elbow = restElbow.position,
			minDeflectionAngle = 70f
		};
	}

	public static void AddLateLevelProp(Prop prop)
	{
		if (instance != null)
		{
			instance.allPropsInLevel.Add(prop);
		}
	}
}
