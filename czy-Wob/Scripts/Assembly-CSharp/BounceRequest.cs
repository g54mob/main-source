using System;
using UnityEngine;

[Serializable]
public struct BounceRequest
{
	public Vector3 startScale;

	public Vector3 endScale;

	public float time;

	public bool overwriteExistingBounces;

	public Inchworm.EaseStyle easeStyle;

	public ElementBouncer.ElementBouncerCallback callback;

	public BounceRequest(Vector3 startScale, Vector3 endScale, float time, bool overwriteExistingBounces, Inchworm.EaseStyle easeStyle, ElementBouncer.ElementBouncerCallback callback = null)
	{
		this.time = time;
		this.endScale = endScale;
		this.easeStyle = easeStyle;
		this.startScale = startScale;
		this.overwriteExistingBounces = overwriteExistingBounces;
		this.callback = callback;
	}
}
