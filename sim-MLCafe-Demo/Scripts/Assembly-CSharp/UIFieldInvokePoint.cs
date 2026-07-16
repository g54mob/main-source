using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class UIFieldInvokePoint
{
	[Range(0f, 1f)]
	public float time;

	public UnityEvent OnKeyframeEvent = new UnityEvent();

	[HideInInspector]
	public bool fired;
}
