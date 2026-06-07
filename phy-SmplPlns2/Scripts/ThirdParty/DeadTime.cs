using System;
using UnityEngine;

[Serializable]
public class DeadTime : MonoBehaviour
{
	public float deadTime;

	public virtual void Awake()
	{
		UnityEngine.Object.Destroy(base.gameObject, deadTime);
	}
}
