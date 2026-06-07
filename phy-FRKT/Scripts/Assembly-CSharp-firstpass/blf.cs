using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class blf : MonoBehaviour
{
	[Serializable]
	public enum UpdateMode
	{
		Update = 0,
		FixedUpdate = 1,
		LateUpdate = 2,
		FixedLateUpdate = 3
	}

	public Transform target;

	public Transform rotationSpace;

	public UpdateMode updateMode;

	public bool lockCursor;

	public bool smoothFollow;

	public Vector3 offset;

	public float followSpeed;

	public float rotationSensitivity;

	public float yMinLimit;

	public float yMaxLimit;

	public bool rotateAlways;

	public bool rotateOnLeftButton;

	public bool rotateOnRightButton;

	public bool rotateOnMiddleButton;

	public float distance;

	public float minDistance;

	public float maxDistance;

	public float zoomSpeed;

	public float zoomSensitivity;

	public LayerMask blockingLayers;

	public float blockingRadius;

	public float blockingSmoothTime;

	public float blockingOriginOffset;

	[Range(0f, 1f)]
	public float blockedOffset;

	private Vector3 tiw;

	private Vector3 tix;

	private Quaternion tiy;

	private Vector3 tiz;

	private Camera tja;

	private bool tjb;

	private float tjc;

	private Quaternion tjd;

	private Vector3 tje;

	private float tjf;

	private float tjg;

	public float tit
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public float tiu
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public float tiv
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	private float xpa => 0f;

	protected virtual void Update()
	{
	}

	public void efc()
	{
	}

	private float jkn(float a, float b, float c)
	{
		return 0f;
	}

	public void jkh(Quaternion a)
	{
	}

	public void lct()
	{
	}

	public void jki(float a, float b)
	{
	}

	public void eun()
	{
	}

	public void jkl(float a)
	{
	}

	public void iaq(Quaternion a)
	{
	}

	public void kxo()
	{
	}

	public void jkj()
	{
	}

	public void jtp(float a)
	{
	}

	public void bts(float a, float b)
	{
	}

	public void jkk()
	{
	}

	public void ein()
	{
	}

	protected virtual void FixedUpdate()
	{
	}

	public void kr(float a, float b)
	{
	}

	protected virtual void LateUpdate()
	{
	}

	public void clf(float a, float b)
	{
	}

	public void fag(float a, float b)
	{
	}

	protected virtual void Awake()
	{
	}
}
