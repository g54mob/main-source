using System.Collections.Generic;
using UnityEngine;

public class WalkwayScalable : MonoBehaviour
{
	private Vector3 _scale;

	private void Awake()
	{
		_scale = base.transform.localScale;
	}

	public void SetScale(Vector3 scale)
	{
		base.transform.localScale = new Vector3(scale.x * _scale.x, scale.y * _scale.y, scale.z * scale.z);
	}

	public void SetXScale(float scale)
	{
		base.transform.localScale = new Vector3(scale * _scale.x, _scale.y, _scale.z);
	}

	public void SetYScale(float scale)
	{
		base.transform.localScale = new Vector3(_scale.x, scale * _scale.y, _scale.z);
	}

	public void SetZScale(float scale)
	{
		base.transform.localScale = new Vector3(_scale.x, _scale.y, scale * _scale.z);
	}

	public static void SetZScale(IReadOnlyList<WalkwayScalable> scalables, float scale)
	{
		foreach (WalkwayScalable scalable in scalables)
		{
			scalable.SetZScale(scale);
		}
	}
}
