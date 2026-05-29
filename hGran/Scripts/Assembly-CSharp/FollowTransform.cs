using System;
using UnityEngine;

[Serializable]
public class FollowTransform : MonoBehaviour
{
	public Transform targetTransform;

	public bool faceForward;

	private Transform thisTransform;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}
}
