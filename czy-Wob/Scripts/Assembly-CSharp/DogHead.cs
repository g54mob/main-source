using System;
using UnityEngine;

[Serializable]
public class DogHead
{
	public GameObject snoutBone;

	public GameObject faceObject;

	public GameObject headHolder;

	public GameObject earsHolder;

	public GameObject armatureStart;

	public ConfigurableJoint emoteJoint;

	public DogVocalizer vocalizationEffect;

	public Rigidbody mouthJointBody;

	public Transform mouthJointRef;

	public Transform mouthTransform;
}
