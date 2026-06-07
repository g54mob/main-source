using System.Collections.Generic;
using UnityEngine;

public class RagdollAnimatorSync : MonoBehaviour
{
	private enum RagdollState
	{
		Animation = 0,
		Ragdoll = 1
	}

	public Transform animationRig;

	public Transform ragdollRoot;

	public float forceMultiplier = 500f;

	[SerializeField]
	private List<Rigidbody> hardSyncRBs;

	[SerializeField]
	private List<Rigidbody> ragdollRBsToSync;

	private List<Transform> animationBones;

	private List<Transform> hardSyncAnimationBones;

	public Rigidbody ragdollHead;

	public GameObject animationHead;

	private RagdollState ragdollState;

	private void Start()
	{
		InitializeBoneAndAnimRigs();
	}

	private void Update()
	{
		if (InputManager.Singleton.inputActions.PlayerActionMap.Throw.WasPressedThisFrame())
		{
			if (ragdollState == RagdollState.Animation)
			{
				ragdollState = RagdollState.Ragdoll;
			}
			else if (ragdollState == RagdollState.Ragdoll)
			{
				ragdollState = RagdollState.Animation;
			}
		}
	}

	private void FixedUpdate()
	{
		TryToMatchRigidBodyBonesToAnimation();
	}

	private Transform FindBone(Transform root, string boneName)
	{
		Transform[] componentsInChildren = root.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.name == boneName)
			{
				return transform;
			}
		}
		return null;
	}

	private void TryToMatchRigidBodyBonesToAnimation()
	{
		if (ragdollState == RagdollState.Animation)
		{
			for (int i = 0; i < hardSyncAnimationBones.Count; i++)
			{
				if (hardSyncAnimationBones[i] != null)
				{
					Rigidbody rigidbody = hardSyncRBs[i];
					Transform obj = hardSyncAnimationBones[i];
					Vector3 position = obj.position;
					Quaternion rotation = obj.rotation;
					rigidbody.transform.position = position;
					rigidbody.transform.rotation = rotation;
					rigidbody.useGravity = false;
				}
			}
			for (int j = 0; j < ragdollRBsToSync.Count; j++)
			{
				if (animationBones[j] != null)
				{
					Rigidbody rigidbody2 = ragdollRBsToSync[j];
					Transform obj2 = animationBones[j];
					Vector3 position2 = obj2.position;
					Quaternion rotation2 = obj2.rotation;
					Vector3 force = (position2 - rigidbody2.position) * forceMultiplier;
					rigidbody2.AddForce(force, ForceMode.Force);
					Quaternion quaternion = rotation2 * Quaternion.Inverse(rigidbody2.rotation);
					Vector3 torque = new Vector3(quaternion.x, quaternion.y, quaternion.z) * forceMultiplier;
					rigidbody2.AddTorque(torque, ForceMode.Force);
				}
			}
		}
		else
		{
			if (ragdollState != RagdollState.Ragdoll)
			{
				return;
			}
			for (int k = 0; k < hardSyncAnimationBones.Count; k++)
			{
				if (hardSyncAnimationBones[k] != null)
				{
					hardSyncRBs[k].useGravity = true;
				}
			}
		}
	}

	private void InitializeBoneAndAnimRigs()
	{
		hardSyncAnimationBones = new List<Transform>();
		for (int i = 0; i < hardSyncRBs.Count; i++)
		{
			string boneName = hardSyncRBs[i].name;
			hardSyncAnimationBones.Add(FindBone(animationRig, boneName));
		}
		animationBones = new List<Transform>();
		for (int j = 0; j < ragdollRBsToSync.Count; j++)
		{
			string boneName2 = ragdollRBsToSync[j].name;
			animationBones.Add(FindBone(animationRig, boneName2));
		}
	}
}
