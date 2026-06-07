using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ActorPerfTest : MonoBehaviour, IStylable
{
	public Animator Anim;

	public float MoveSpeed = 10f;

	public float RotationSpeed = 10f;

	public Vector2 OrigX;

	public Vector2 OrigY;

	public Vector2 RangeX;

	public Vector2 RangeY;

	private bool _stop;

	private List<ActorBodyItem> _bodyItems = new List<ActorBodyItem>();

	private Vector3 _target;

	private bool _rotate = true;

	[SerializeField]
	private Transform _rootBone;

	public List<ActorBodyItem> BodyItems
	{
		get
		{
			return _bodyItems;
		}
		set
		{
			_bodyItems = value;
		}
	}

	public Transform RootBone
	{
		get
		{
			return _rootBone;
		}
		set
		{
			_rootBone = value;
		}
	}

	public Dictionary<string, Transform> Rig { get; set; }

	public bool UsesLOD1
	{
		get
		{
			return false;
		}
	}

	public bool NeedsDestruction
	{
		get
		{
			return false;
		}
	}

	private void Start()
	{
		Anim.SetActorAnim(Actor.AnimationStates.Idle);
	}

	private Vector3 GetRandomPoint()
	{
		Vector2 a = OrigX + RangeX * Random.value;
		Vector2 b = OrigY + RangeY * Random.value;
		return Vector2.Lerp(a, b, Random.value).ToVector3(0f);
	}

	public void Initialize()
	{
		ActorBodyItem.BodyItemObject[] items = ActorGenerator.Instance.GenerateStyle(Random.value > 0.5f, "Default", 20f);
		ActorGenerator.Instance.ApplySavedStyle(items, this);
		for (int i = 0; i < _bodyItems.Count; i++)
		{
			ActorBodyItem actorBodyItem = _bodyItems[i];
			if (actorBodyItem.rend != null)
			{
				actorBodyItem.rend.shadowCastingMode = ShadowCastingMode.On;
			}
		}
		base.transform.position = GetRandomPoint();
		_target = GetRandomPoint();
	}

	public void Stop()
	{
		Anim.SetActorAnim(Actor.AnimationStates.Walk);
		_stop = true;
	}

	private void Update()
	{
		Vector3 forward = _target - base.transform.position;
		if (forward.sqrMagnitude < 2f)
		{
			_target = GetRandomPoint();
			_rotate = true;
			forward = _target - base.transform.position;
		}
		if (!_stop && _rotate)
		{
			Quaternion quaternion = Quaternion.LookRotation(forward);
			float num = Vector3.SignedAngle(base.transform.forward, forward.normalized, Vector3.up);
			if (Mathf.Approximately(num, 0f))
			{
				base.transform.rotation = quaternion;
				_rotate = false;
			}
			else
			{
				base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, quaternion, Time.deltaTime * RotationSpeed);
				Anim.SetActorAnim((num > 0f) ? Actor.AnimationStates.TurnRight : Actor.AnimationStates.TurnLeft);
			}
		}
		else
		{
			Anim.SetActorAnim(Actor.AnimationStates.Walk);
			base.transform.position = base.transform.position + base.transform.forward * Time.deltaTime * MoveSpeed;
		}
	}

	public Transform GetTransform()
	{
		return base.transform;
	}

	public void UpdateEyes()
	{
	}

	public void UpdateHairColor(Color col)
	{
	}

	public void UpdateSkinColor(Color col)
	{
	}

	public void PostUpdate(bool allowHoliday)
	{
	}

	public void SetLOD2Color(string part, Color col)
	{
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawSphere(_target, 0.05f);
	}
}
