using UnityEngine;

public class SteeringBehaviors
{
	private const float MAX_FORCE = float.MaxValue;

	private SteeringBehaviorTypes _enabledTypes;

	private Vector3 _steeringForce = Vector3.zero;

	private GameObject _target;

	private Drone _thisDrone;

	private Deceleration _deceleration;

	public SteeringBehaviorTypes EnabledTypes
	{
		get
		{
			return _enabledTypes;
		}
	}

	public GameObject Target
	{
		get
		{
			return _target;
		}
	}

	public SteeringBehaviors(Drone drone)
	{
		_thisDrone = drone;
	}

	public Vector3 Calculate(Vector3 initialForce)
	{
		_steeringForce = initialForce;
		_steeringForce = CalculatePrioritized();
		return _steeringForce;
	}

	public void SetTarget(GameObject target)
	{
		_target = target;
	}

	public void SetTarget(MonoBehaviour target)
	{
		_target = target.gameObject;
	}

	public void ClearTarget()
	{
		_target = null;
	}

	public void AllOff()
	{
		_enabledTypes = SteeringBehaviorTypes.None;
	}

	public void SeekOn()
	{
		if (_target == null)
		{
			Debug.LogWarning("SeekOn: _target is null!!");
		}
		_enabledTypes |= SteeringBehaviorTypes.Seek;
	}

	public void ArriveOn(Deceleration deceleration)
	{
		if (_target == null)
		{
			Debug.LogWarning("ArriveOn: _target is null!!");
		}
		_deceleration = deceleration;
		_enabledTypes |= SteeringBehaviorTypes.Arrive;
	}

	public void LazyAvoidanceOn()
	{
		_enabledTypes |= SteeringBehaviorTypes.LazyAvoidance;
	}

	public void WallAvoidanceOn()
	{
		_enabledTypes |= SteeringBehaviorTypes.WallAvoidance;
	}

	public void ObstacleAvoidanceOn()
	{
		_enabledTypes |= SteeringBehaviorTypes.ObstacleAvoidance;
	}

	public void SeekOff()
	{
		_enabledTypes &= ~SteeringBehaviorTypes.Seek;
	}

	public void ArriveOff()
	{
		_enabledTypes &= ~SteeringBehaviorTypes.Arrive;
	}

	public void LazyAvoidanceOff()
	{
		_enabledTypes &= ~SteeringBehaviorTypes.LazyAvoidance;
	}

	public void WallAvoidanceOff()
	{
		_enabledTypes &= ~SteeringBehaviorTypes.WallAvoidance;
	}

	public void ObstacleAvoidanceOff()
	{
		_enabledTypes &= ~SteeringBehaviorTypes.ObstacleAvoidance;
	}

	private bool IsOn(SteeringBehaviorTypes typeToCheck)
	{
		return (_enabledTypes & typeToCheck) == typeToCheck;
	}

	private bool AccumulateForce(Vector3 forceToAdd)
	{
		float magnitude = _steeringForce.magnitude;
		float num = float.MaxValue - magnitude;
		if (num <= 0f)
		{
			return false;
		}
		float magnitude2 = forceToAdd.magnitude;
		if (magnitude2 < num)
		{
			_steeringForce += forceToAdd;
		}
		else
		{
			magnitude2 = num;
			Vector3 vector = forceToAdd.normalized * magnitude2;
			_steeringForce += vector;
		}
		return true;
	}

	private Vector3 CalculatePrioritized()
	{
		if (IsOn(SteeringBehaviorTypes.WallAvoidance))
		{
			Vector3 vector = WallAvoidance();
			if (!AccumulateForce(vector))
			{
				return _steeringForce;
			}
			if (vector != Vector3.zero)
			{
				return _steeringForce;
			}
		}
		if (IsOn(SteeringBehaviorTypes.LazyAvoidance))
		{
			Vector3 forceToAdd = LazyAvoidance();
			if (!AccumulateForce(forceToAdd))
			{
				return _steeringForce;
			}
		}
		if (IsOn(SteeringBehaviorTypes.ObstacleAvoidance))
		{
			Vector3 forceToAdd2 = ObstacleAvoidance();
			if (!AccumulateForce(forceToAdd2))
			{
				return _steeringForce;
			}
		}
		if (IsOn(SteeringBehaviorTypes.Seek))
		{
			Vector3 forceToAdd3 = Seek();
			if (!AccumulateForce(forceToAdd3))
			{
				return _steeringForce;
			}
		}
		if (IsOn(SteeringBehaviorTypes.Arrive))
		{
			Vector3 forceToAdd4 = Arrive();
			if (!AccumulateForce(forceToAdd4))
			{
				return _steeringForce;
			}
		}
		return _steeringForce;
	}

	private Vector3 Seek()
	{
		Vector3 vector = (_target.transform.position - _thisDrone.Position).normalized * _thisDrone.CurrentMaxRawSpeed;
		return vector - _thisDrone.GetVelocityVectorRawNoDelta(_thisDrone.CurrentRawSpeed);
	}

	private Vector3 Arrive()
	{
		Vector3 vector = _target.transform.position - _thisDrone.Position;
		float num = Vector3.Distance(_target.transform.position, _thisDrone.Position);
		if (num > 0f)
		{
			float a = num / ((float)_deceleration * 0.5f);
			a = Mathf.Min(a, _thisDrone.CurrentMaxRawSpeed);
			Vector3 vector2 = vector * a / num;
			return vector2 - _thisDrone.GetVelocityVectorRawNoDelta(_thisDrone.CurrentRawSpeed);
		}
		return Vector3.zero;
	}

	private Vector3 LazyAvoidance()
	{
		GameObject gameObject = null;
		float num = float.MaxValue;
		int count = _thisDrone.CollidingObjects.Count;
		for (int i = 0; i < count; i++)
		{
			GameObject gameObject2 = _thisDrone.CollidingObjects[i];
			if (!(gameObject2 == _target))
			{
				float num2 = Vector3.Distance(gameObject2.transform.position, _thisDrone.transform.position);
				if (num2 < num)
				{
					gameObject = gameObject2;
					num = num2;
				}
			}
		}
		Vector3 result = Vector3.zero;
		if (gameObject != null)
		{
			float x = ((!(_thisDrone.transform.InverseTransformPoint(gameObject.transform.position).x > 0f)) ? 0.7f : (-0.7f));
			float y = 0f;
			result = _thisDrone.transform.TransformVector(x, y, 0f);
		}
		return result;
	}

	private Vector3 WallAvoidance()
	{
		float num = 0f;
		float y = 0f;
		if (_thisDrone.CollidingWallMiddle && _thisDrone.CurrentRawSpeed > 0f)
		{
			if (_thisDrone.CollidingWallLeft && !_thisDrone.CollidingWallRight)
			{
				num += 0.4f;
			}
			else if (!_thisDrone.CollidingWallLeft && _thisDrone.CollidingWallRight)
			{
				num += -0.4f;
			}
			if (_thisDrone.CurrentRawSpeed > 0.1f)
			{
				y = 0f - _thisDrone.CurrentMaxRawSpeed;
			}
		}
		if (_thisDrone.CollidingWallLeft)
		{
			num += 0.4f;
		}
		if (_thisDrone.CollidingWallRight)
		{
			num += -0.4f;
		}
		return _thisDrone.transform.TransformVector(num, y, 0f);
	}

	private Vector3 ObstacleAvoidance()
	{
		GameObject gameObject = null;
		float num = float.MaxValue;
		int count = _thisDrone.CollidingObjects.Count;
		for (int i = 0; i < count; i++)
		{
			GameObject gameObject2 = _thisDrone.CollidingObjects[i];
			if (!(gameObject2 == _target))
			{
				float num2 = Vector3.Distance(gameObject2.transform.position, _thisDrone.transform.position);
				if (num2 < num)
				{
					gameObject = gameObject2;
					num = num2;
				}
			}
		}
		Vector3 result = Vector3.zero;
		if (gameObject != null)
		{
			Vector3 vector = _thisDrone.transform.InverseTransformPoint(gameObject.transform.position);
			SphereCollider component = gameObject.transform.GetComponent<SphereCollider>();
			if (component != null)
			{
				float num3 = 2.5f + (1f - vector.y) / 1f;
				float x = (component.radius - vector.x) * num3;
				float y = -0.15f * num3;
				result = _thisDrone.transform.TransformVector(x, y, 0f);
			}
			else
			{
				float x2 = ((!(vector.x > 0f)) ? 0.7f : (-0.7f));
				float y2 = 0f;
				result = _thisDrone.transform.TransformVector(x2, y2, 0f);
			}
		}
		return result;
	}
}
