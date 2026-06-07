using System.Collections.Generic;
using UnityEngine;

public class ScissorLift : MonoBehaviour
{
	public Transform Top;

	public List<Transform> LeftLegs = new List<Transform>();

	public List<Transform> RightLegs = new List<Transform>();

	public float LegLength = 1.41f;

	public float TestHeight = 2f;

	private int _lastLegs = 1;

	private float _lastTop = -1f;

	private Actor _target;

	public static ScissorLift Get(Vector3 pos, float height, Quaternion rot, Actor target)
	{
		ScissorLift scissorLift = GameSettings.Instance.ScissorPool.Get();
		scissorLift._target = target;
		scissorLift.transform.position = pos;
		scissorLift.transform.rotation = rot;
		scissorLift.Init(height);
		return scissorLift;
	}

	[ContextMenu("Test")]
	public void InitEdit()
	{
		Init(TestHeight);
	}

	public void Release()
	{
		_target = null;
		GameSettings.Instance.ScissorPool.Release(this);
	}

	public void Init(float height)
	{
		int num = Mathf.Max(1, Mathf.CeilToInt(height / 1.25f));
		if (num != _lastLegs)
		{
			_lastLegs = num;
			for (int i = 0; i < LeftLegs.Count; i++)
			{
				LeftLegs[i].gameObject.SetActive(i < _lastLegs);
				RightLegs[i].gameObject.SetActive(i < _lastLegs);
			}
			for (int j = LeftLegs.Count; j < _lastLegs; j++)
			{
				GameObject gameObject = Object.Instantiate(LeftLegs[0].gameObject);
				gameObject.transform.SetParent(base.transform, true);
				LeftLegs.Add(gameObject.transform);
				gameObject = Object.Instantiate(RightLegs[0].gameObject);
				gameObject.transform.SetParent(base.transform, true);
				RightLegs.Add(gameObject.transform);
			}
		}
	}

	private void Update()
	{
		if (_target != null)
		{
			Vector3 position = Top.position;
			Top.position = new Vector3(position.x, _target.ActualPosition.y, position.z);
		}
		float y = Top.localPosition.y;
		if (y != _lastTop)
		{
			_lastTop = y;
			y -= 0.1f;
			float num = y / (float)_lastLegs;
			float num2 = Mathf.Asin(num / LegLength);
			float num3 = LegLength / 2f - Mathf.Cos(num2) * LegLength;
			num2 *= 57.29578f;
			for (int i = 0; i < _lastLegs; i++)
			{
				bool flag = (i & 1) == 1;
				Transform obj = LeftLegs[i];
				obj.transform.localRotation = Quaternion.Euler(0f - num2, 0f, 0f);
				obj.transform.localPosition = new Vector3(0f, num * (float)i, flag ? num3 : ((0f - LegLength) / 2f));
				Transform obj2 = RightLegs[i];
				obj2.transform.localRotation = Quaternion.Euler(180f + num2, 0f, 0f);
				obj2.transform.localPosition = new Vector3(0f, num * (float)i, flag ? (0f - num3) : (LegLength / 2f));
			}
		}
	}
}
