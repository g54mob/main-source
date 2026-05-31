using System.Collections.Generic;
using UnityEngine;

public class HotAirStation_Entity : MonoBehaviour
{
	public enum StateEnum
	{
		Idle = 0,
		Coming = 1,
		Dumping = 2,
		Parting = 3
	}

	public HotAirStation Parent;

	public BoxCollider2D Range;

	private Vector3 _originalLocation;

	private bool _isActive;

	private AnimationSprite _animationSprite;

	public List<GarbageInfo> _storedGarbage = new List<GarbageInfo>();

	public GameObject Wind;

	private StateEnum _state;

	private float _dumpingTimer;

	private Vector2 _center;

	private Vector2 _size;

	private bool _movingUp;

	private float _direction = 1f;

	private void Awake()
	{
		_animationSprite = GetComponent<AnimationSprite>();
	}

	private void Start()
	{
		_center = Range.GetComponent<BoxCollider2D>().offset;
		_size = Range.GetComponent<BoxCollider2D>().bounds.size;
		Range.GetComponent<BoxCollider2D>().enabled = false;
		_originalLocation = base.transform.position;
		_animationSprite.Play("Pumping");
		Wind.SetActive(value: false);
	}

	private void FixedUpdate()
	{
		if (!_isActive || GameController.Instance.IsHoleFilled())
		{
			return;
		}
		if (_state == StateEnum.Parting)
		{
			if (base.transform.position.y < 6f)
			{
				base.transform.position += new Vector3(0f, GetSpeed() * Time.fixedDeltaTime, 0f);
				_movingUp = true;
			}
			else if (_movingUp)
			{
				_movingUp = false;
				if (Parent.HasMoveLeftAttribute.IsEnabled)
				{
					_state = StateEnum.Coming;
				}
			}
			else
			{
				base.transform.position += new Vector3(GetSpeed() * Time.fixedDeltaTime, 0f, 0f);
				if (base.transform.position.x >= GameController.Instance.HoleLocation.transform.position.x)
				{
					_state = StateEnum.Dumping;
					if (HotAirStation.GlobalInfo.CanCompressAttribute.IsEnabled)
					{
						CompressStorage();
					}
					_direction = 1f;
					Wind.SetActive(value: false);
				}
			}
			MoveGarbage();
		}
		else if (_state == StateEnum.Dumping)
		{
			_dumpingTimer += Time.fixedDeltaTime;
			base.transform.position += new Vector3(GetSpeed() * Time.fixedDeltaTime * _direction, 0f, 0f);
			if (base.transform.position.x > GameController.Instance.HoleFarLocation.transform.position.x && _direction > 0f)
			{
				_direction = -1f;
			}
			if (base.transform.position.x > GameController.Instance.Hole.LeftSection.transform.position.x && _direction < 0f)
			{
				_direction = 1f;
			}
			if (!(_dumpingTimer >= 0.1f))
			{
				return;
			}
			_dumpingTimer = 0f;
			if (_storedGarbage.Count > 0)
			{
				Parent.ParentColumn.LocalSfx2Controller.PlayOneFromDistance(SoundManager.SoundTypeEnum.bs_balloon_drop, base.transform.position.x);
				GameController.Instance.GarbageController.Generate(base.transform.position, _storedGarbage[0]);
				_storedGarbage.RemoveAt(0);
				return;
			}
			_state = StateEnum.Coming;
			if (HotAirStation.GlobalInfo.CanStrongerFanAttribute.Level > 0 && HotAirStation.GlobalInfo.CanBothSideAttribute.IsEnabled)
			{
				Wind.SetActive(value: true);
			}
		}
		else
		{
			if (_state != StateEnum.Coming)
			{
				return;
			}
			base.transform.position += new Vector3((0f - GetSpeed()) * Time.fixedDeltaTime, 0f, 0f);
			if (base.transform.position.x <= _originalLocation.x - 7f * (float)Parent.HasMoveLeftAttribute.Level)
			{
				_state = StateEnum.Parting;
				if (HotAirStation.GlobalInfo.CanStrongerFanAttribute.Level > 0)
				{
					Wind.SetActive(value: true);
				}
			}
			if (HotAirStation.GlobalInfo.CanBothSideAttribute.IsEnabled)
			{
				MoveGarbage();
			}
		}
	}

	private void MoveGarbage()
	{
		Collider2D[] array = Physics2D.OverlapBoxAll((Vector2)base.transform.position + _center, _size, 0f);
		for (int i = 0; i < array.Length; i++)
		{
			Garbage component = array[i].gameObject.GetComponent<Garbage>();
			if (component != null && (component.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageS || (component.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageM && HotAirStation.GlobalInfo.CanStrongerFanAttribute.IsEnabled) || (component.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageL && HotAirStation.GlobalInfo.CanStrongerFan2Attribute.IsEnabled) || (component.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageXL && HotAirStation.GlobalInfo.CanStrongerFan2Attribute.IsEnabled)))
			{
				component.SetAsDynamic();
				if (_state == StateEnum.Coming)
				{
					component.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f * GetSpeed(), 20f));
				}
				else
				{
					component.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f * GetSpeed(), 20f));
				}
				if (component.transform.position.y >= base.transform.position.y - 1f)
				{
					_storedGarbage.Add(component.Info);
					GameController.Instance.GarbageController.DestroyGarbage(component);
				}
			}
		}
	}

	private float GetSpeed()
	{
		if (Parent.Workers.Count <= 1)
		{
			return 1f;
		}
		return 1f + 0.1f * (float)(Parent.Workers.Count - 1);
	}

	public void SetActive()
	{
		if (!_isActive)
		{
			_isActive = true;
			_state = StateEnum.Parting;
		}
	}

	public void SetInactive()
	{
		if (_isActive)
		{
			_isActive = false;
			base.transform.position = _originalLocation;
			_state = StateEnum.Idle;
		}
	}

	public void EmptyStorage()
	{
		foreach (GarbageInfo item in _storedGarbage)
		{
			GameController.Instance.GarbageController.Generate(base.transform.position, item).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3, 3), 3f), ForceMode2D.Impulse);
		}
		_storedGarbage.Clear();
	}

	private void CompressStorage()
	{
		List<GarbageInfo.GarbageTypeEnum> list = new List<GarbageInfo.GarbageTypeEnum>
		{
			GarbageInfo.GarbageTypeEnum.GarbageS,
			GarbageInfo.GarbageTypeEnum.GarbageM,
			GarbageInfo.GarbageTypeEnum.GarbageL,
			GarbageInfo.GarbageTypeEnum.GarbageXL
		};
		for (int i = 0; i < HotAirStation.GlobalInfo.CanCompressAttribute.Level; i++)
		{
			List<int> list2 = new List<int>();
			for (int num = _storedGarbage.Count - 1; num >= 0; num--)
			{
				if (_storedGarbage[num].GarbageType == list[i])
				{
					list2.Add(num);
				}
				if (list2.Count == 4)
				{
					GarbageInfo garbageInfo = new GarbageInfo(_storedGarbage[list2[0]].Weight + _storedGarbage[list2[1]].Weight + _storedGarbage[list2[2]].Weight + _storedGarbage[list2[3]].Weight, list[i + 1], GarbageInfo.CameFromEnum.Compressed, isEvil: false);
					garbageInfo.ForceZap();
					_storedGarbage.RemoveAt(list2[0]);
					_storedGarbage.RemoveAt(list2[1]);
					_storedGarbage.RemoveAt(list2[2]);
					_storedGarbage.RemoveAt(list2[3]);
					_storedGarbage.Add(garbageInfo);
					list2.Clear();
				}
			}
		}
	}
}
