using System.Collections;
using UnityEngine;

public class SpotLightDirectionChanger : MonoBehaviour
{
	public Transform[] _trnBoundryPoints;

	public float _fLookChangeSpeed = 1f;

	public Vector3 _vecCurrentLookPoint;

	public Vector3 _vecLookTarget;

	public float _fLookTargetUpdateRate = 2f;

	public float _fLookChangeVarienceMultiplyer = 3f;

	public void CalcLookTarget()
	{
		_vecLookTarget = Vector3.zero;
		float num = 0f;
		Transform[] trnBoundryPoints = _trnBoundryPoints;
		foreach (Transform transform in trnBoundryPoints)
		{
			float f = Random.Range(0.1f, 100f);
			f = Mathf.Pow(f, _fLookChangeVarienceMultiplyer);
			num += f;
			_vecLookTarget += transform.position * f;
		}
		_vecLookTarget *= 1f / num;
	}

	public IEnumerator LookTargetUpdator()
	{
		while (true)
		{
			CalcLookTarget();
			yield return new WaitForSeconds(_fLookTargetUpdateRate);
		}
	}

	public void UpdateCurrentLookPoint()
	{
		_vecCurrentLookPoint = Vector3.Lerp(_vecCurrentLookPoint, _vecLookTarget, _fLookChangeSpeed * Time.deltaTime);
	}

	public void UpdateThisObjectFaceDirection()
	{
		base.transform.LookAt(_vecCurrentLookPoint);
	}

	private void Start()
	{
		CalcLookTarget();
		_vecCurrentLookPoint = _vecLookTarget;
		CalcLookTarget();
		StartCoroutine(LookTargetUpdator());
	}

	public void OnEnable()
	{
		CalcLookTarget();
		_vecCurrentLookPoint = _vecLookTarget;
		CalcLookTarget();
		StartCoroutine(LookTargetUpdator());
	}

	private void Update()
	{
		UpdateCurrentLookPoint();
		UpdateThisObjectFaceDirection();
	}
}
