using UnityEngine;

public class Garbage : MonoBehaviour
{
	public enum GarbageTemplateTypeEnum
	{
		None = 0,
		GarbageS = 1,
		GarbageM = 2,
		GarbageL = 3,
		GarbageXL = 4,
		EvilGarbageS = 5,
		EvilGarbageM = 6,
		EvilGarbageL = 7,
		EvilGarbageXL = 8,
		BlueShard = 9,
		RedShard = 10,
		YellowShard = 11,
		Book = 12,
		Golem = 13
	}

	public bool IsReserved;

	public GarbageTemplateTypeEnum GarbageTemplateType;

	private CircleCollider2D _circleCollider;

	private Rigidbody2D _rb;

	public TrailRenderer _tr;

	private GarbageInfo _info = new GarbageInfo();

	private bool _enableAudio;

	private bool _isSleeping;

	private float _delay;

	private float _startDelay;

	public static bool HasBulldozer;

	public static float BulldozerPosition;

	private bool _dragging;

	private Vector3 _lastDragDir = Vector3.zero;

	private Vector3 _lastDragPosition = Vector3.zero;

	public GarbageInfo Info => _info;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		_tr = GetComponent<TrailRenderer>();
		_circleCollider = GetComponent<CircleCollider2D>();
		_tr.enabled = false;
	}

	private void Start()
	{
	}

	public void EnableAudio()
	{
		_enableAudio = true;
	}

	public void RestartDelay()
	{
		_rb.bodyType = RigidbodyType2D.Dynamic;
		_rb.constraints = RigidbodyConstraints2D.None;
		_isSleeping = false;
		_delay = 0f;
		_startDelay = 0f;
	}

	private void FixedUpdate()
	{
		if (_dragging)
		{
			ProcessDrag();
			return;
		}
		if (_rb.linearVelocity.magnitude > 0.01f)
		{
			Vector2 vector = -_rb.linearVelocity.normalized * 0.1f * Time.fixedDeltaTime;
			_rb.linearVelocity += vector;
			if (_rb.linearVelocity.magnitude < 0.1f)
			{
				_rb.linearVelocity = Vector2.zero;
			}
		}
		float num = 3f;
		float num2 = 3f;
		if (_startDelay > num2 && !_dragging)
		{
			if (_rb.bodyType != RigidbodyType2D.Kinematic && (!HasBulldozer || base.transform.position.x < BulldozerPosition || base.transform.position.x > BulldozerPosition + num) && _rb.linearVelocity.magnitude < 0.1f && Mathf.Abs(_rb.angularVelocity) < 1f)
			{
				_rb.bodyType = RigidbodyType2D.Kinematic;
				_rb.constraints = RigidbodyConstraints2D.FreezeAll;
				_rb.linearVelocity = Vector2.zero;
				_rb.angularVelocity = 0f;
				_isSleeping = true;
				_delay = 0f;
			}
			bool flag = false;
			if (_delay >= num2)
			{
				flag = true;
			}
			else if (HasBulldozer && base.transform.position.x >= BulldozerPosition && base.transform.position.x < BulldozerPosition + num && (double)base.transform.position.y > -5.19 && (double)base.transform.position.y < -2.49)
			{
				flag = true;
			}
			if (_isSleeping && flag)
			{
				_rb.bodyType = RigidbodyType2D.Dynamic;
				_rb.constraints = RigidbodyConstraints2D.None;
				_isSleeping = false;
			}
		}
		_delay += Time.fixedDeltaTime;
		_startDelay += Time.fixedDeltaTime;
	}

	public bool IsFalling()
	{
		if (!(_rb.linearVelocity.y <= -0.01f))
		{
			return _rb.linearVelocity.y >= 0.01f;
		}
		return true;
	}

	public bool IsStatic()
	{
		return _rb.bodyType == RigidbodyType2D.Static;
	}

	public void SetAsDynamic()
	{
		_rb.bodyType = RigidbodyType2D.Dynamic;
		_rb.simulated = true;
		_rb.constraints = RigidbodyConstraints2D.None;
		_startDelay = 0f;
		_delay = 0f;
		if (_isSleeping)
		{
			_isSleeping = false;
		}
	}

	public void SetAsStatic()
	{
		_rb.bodyType = RigidbodyType2D.Static;
		_rb.simulated = false;
		_rb.constraints = RigidbodyConstraints2D.None;
	}

	public void Throw(float extraX)
	{
		_tr.enabled = true;
		base.transform.SetParent(GameController.Instance.GarbageController.transform);
		SetAsDynamic();
		_rb.linearVelocity = new Vector3(4f + extraX, 4f, 0f);
	}

	public void ThrowToLocation(GameObject location)
	{
		ThrowToLocation(location.transform.position);
	}

	public void ThrowToLocation(Vector3 location)
	{
		_tr.enabled = true;
		_rb.bodyType = RigidbodyType2D.Dynamic;
		_rb.constraints = RigidbodyConstraints2D.None;
		_rb.simulated = true;
		Vector2 throwVelocity = Helper.GetThrowVelocity(base.transform.position, location);
		_rb.linearVelocity = Vector2.zero;
		_rb.angularVelocity = 0f;
		_rb.AddForce(throwVelocity, ForceMode2D.Impulse);
	}

	public float GetHeight()
	{
		return ((Vector2)GetComponent<Collider2D>().bounds.size).y;
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (_enableAudio && _rb.linearVelocity.magnitude >= 3f)
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ga_garbage_hit);
		}
	}

	private void OnMouseDown()
	{
		bool flag = true;
		if (Sign.PreventEvent)
		{
			return;
		}
		if (!_info.IsGarbage)
		{
			flag = false;
		}
		if (GameController.Instance != null && GameController.Instance.AreBuildingOnTop)
		{
			flag = false;
		}
		if (flag)
		{
			SetAsDynamic();
			_dragging = true;
			_lastDragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (GameController.Instance != null)
			{
				GameController.Instance.PeonController.RemoveReserveGarbage(this);
			}
			IsReserved = true;
		}
	}

	private void OnMouseUp()
	{
		if (_dragging && _info.IsGarbage)
		{
			IsReserved = false;
			RemoveDrag();
			_rb.linearVelocity = _lastDragDir * 50f;
			if (_rb.linearVelocity.magnitude >= 3f)
			{
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ga_throw_garbage);
			}
			GameController.TotalTossedGarbage++;
		}
	}

	public void RemoveDrag()
	{
		_dragging = false;
		_tr.enabled = true;
	}

	private void ProcessDrag()
	{
		if (_dragging)
		{
			Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_lastDragDir = vector - _lastDragPosition;
			base.transform.position = Vector2.Lerp(base.transform.position, vector, 1f);
			_lastDragPosition = vector;
			_rb.linearVelocity = Vector2.zero;
			_rb.angularVelocity = 0f;
		}
	}

	public void SetAsZap()
	{
		_info.SetAsZap();
		UpdateFromInfo();
	}

	public void SetInfo(int weight, GarbageInfo.GarbageTypeEnum type, GarbageInfo.CameFromEnum cameFrom, bool isEvil)
	{
		_info = new GarbageInfo(weight, type, cameFrom, isEvil);
		UpdateFromInfo();
	}

	public void SetInfo(GarbageInfo info)
	{
		_info = new GarbageInfo(info);
		UpdateFromInfo();
	}

	private void UpdateFromInfo()
	{
		base.transform.Find("Image").GetComponent<SpriteRenderer>().color = _info.CurColor;
		GetComponent<TrailRenderer>().startColor = _info.CurColor;
	}
}
