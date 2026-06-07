using System;
using System.Collections;
using UnityEngine;

public class Prop : MonoBehaviour
{
	[Serializable]
	public class UseInfo
	{
		public string activeInStateName;

		public string boolParameterName;

		public string stateName;

		public float resetDelay = -1f;

		public bool moveIntoPosition = true;

		public bool once;
	}

	public string handAnimsId;

	public string velcroedName;

	public float reachViewAngle = 30f;

	public float holdViewAngle = 90f;

	public float angleToGripPow = 1f;

	public bool slowPlayerWalk = true;

	public bool ignoreViewAngle;

	public bool showHandShadow = true;

	public bool crouchToReach;

	public string rootInScene;

	public string prefixInScene;

	public bool spinnableElbow;

	public UseInfo useInfo = new UseInfo();

	[NonSerialized]
	public Transform grip;

	[NonSerialized]
	public Transform gripElbow;

	[NonSerialized]
	public Transform standHere;

	[NonSerialized]
	public Transform lookHere;

	[NonSerialized]
	public Transform releaseGrip;

	[NonSerialized]
	public Transform releaseGripElbow;

	[NonSerialized]
	public Transform velcroed;

	[NonSerialized]
	public Transform facer;

	[NonSerialized]
	public Animator animator;

	[NonSerialized]
	public Vector3 startGripPos;

	[NonSerialized]
	public HangingBag hangingBag;

	[NonSerialized]
	public bool preventReset;

	[NonSerialized]
	public Bounds preventResetWorldBounds;

	[NonSerialized]
	public CannedAnim cannedAnim;

	private bool used;

	public bool shouldFacePlayer
	{
		get
		{
			return facer != null;
		}
	}

	public bool canUse
	{
		get
		{
			return (string.IsNullOrEmpty(useInfo.activeInStateName) || animator == null || animator.GetCurrentAnimatorStateInfo(0).IsName(useInfo.activeInStateName)) && (!useInfo.once || !used);
		}
	}

	private void Start()
	{
		Transform target = base.transform;
		if (!string.IsNullOrEmpty(rootInScene))
		{
			target = base.transform.FindDescendant(rootInScene);
		}
		grip = target.FindDescendant(prefixInScene + "grip");
		gripElbow = target.FindDescendant(prefixInScene + "grip_elbow");
		standHere = target.FindDescendant(prefixInScene + "stand_here");
		lookHere = target.FindDescendant(prefixInScene + "look_here");
		releaseGrip = target.FindDescendant(prefixInScene + "release_grip");
		releaseGripElbow = target.FindDescendant(prefixInScene + "release_grip_elbow");
		facer = target.FindDescendant(prefixInScene + "facer", false);
		if (!string.IsNullOrEmpty(velcroedName))
		{
			velcroed = target.FindDescendant(velcroedName);
		}
		Transform transform = target.FindDescendant("noreset", false);
		if (transform != null)
		{
			Renderer component = transform.GetComponent<Renderer>();
			preventReset = useInfo.resetDelay > 0f;
			preventResetWorldBounds = component.bounds;
			transform.gameObject.SetActive(false);
		}
		animator = GetComponentInChildren<Animator>(true);
		startGripPos = grip.position;
		hangingBag = GetComponent<HangingBag>();
	}

	private void Update()
	{
		if (shouldFacePlayer && Player.instance != null)
		{
			Vector3 vector = facer.parent.worldToLocalMatrix.MultiplyPoint(Player.instance.transform.position);
			vector.y = facer.localPosition.y;
			Quaternion localRotation = Quaternion.LookRotation(facer.localPosition - vector);
			facer.localRotation = localRotation;
		}
	}

	public void SetTouchingForOneFrame(Vector3 pullTowardsPos)
	{
	}

	public void SetUsed()
	{
		used = true;
	}

	public void StartReset()
	{
		StartCoroutine(Reset());
	}

	private IEnumerator Reset()
	{
		if (!(useInfo.resetDelay >= 0f))
		{
			yield break;
		}
		if (useInfo.resetDelay != 0f)
		{
			yield return new WaitForSeconds(useInfo.resetDelay);
		}
		if (preventReset)
		{
			while (preventResetWorldBounds.Contains(Player.instance.transform.position))
			{
				yield return new WaitForSeconds(0.25f);
			}
		}
		animator.SetBool(useInfo.boolParameterName, false);
		SetUsed();
	}
}
