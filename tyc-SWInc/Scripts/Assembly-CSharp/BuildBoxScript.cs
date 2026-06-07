using System;
using UnityEngine;

public class BuildBoxScript : MonoBehaviour
{
	public Material HighMat;

	public Material LowMat;

	[NonSerialized]
	private Material _mat;

	[NonSerialized]
	private bool _high;

	private void Start()
	{
		_high = base.transform.localScale.y > 1.1f;
		InitMat();
	}

	private void InitMat()
	{
		if (_mat != null)
		{
			UnityEngine.Object.Destroy(_mat);
		}
		_mat = new Material(_high ? HighMat : LowMat);
		GetComponent<Renderer>().sharedMaterial = _mat;
	}

	private void Update()
	{
		bool flag = base.transform.localScale.y > 1.1f;
		if (_high != flag)
		{
			_high = flag;
			InitMat();
		}
		_mat.mainTextureScale = new Vector2(base.transform.localScale.z, 1f);
	}

	private void OnDestroy()
	{
		if (_mat != null)
		{
			UnityEngine.Object.Destroy(_mat);
		}
	}
}
