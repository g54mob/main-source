using System;
using UnityEngine;

[Serializable]
public class pushRigidbody : MonoBehaviour
{
	public float pushPower;

	public virtual void OnControllerColliderHit(ControllerColliderHit hit)
	{
	}
}
