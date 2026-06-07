using System;
using System.Collections.Generic;
using UnityEngine;

public class CharV2 : MonoBehaviour
{
	public enum ActionEnum
	{
		Idle = 0,
		GoingToGarbage = 1,
		GoingToBuilding = 2,
		InsideBuilding = 3,
		DroppingInBuilding = 4,
		Picked = 5,
		Flying = 6
	}

	private Rigidbody2D _rb;

	private float _currentTimer;

	public float _hapinessLeft;

	private CharDisplay _display;

	public BaseBuilding Job;

	public BaseBuilding TempJob;

	public ActionEnum CurrentAction;

	public GameObject DestinationObject;

	public ColumnController DestinationColumn;

	public GameObject FirstHoldingLoc;

	public List<Garbage> GarbageInHand = new List<Garbage>();

	private BaseBuilding _previousJob;

	private float _breakTimer;

	public int UniqueID;

	private static int _sequence;

	private bool _dragging;

	private Vector3 _lastDragDir = Vector3.zero;

	private Vector3 _lastDragPosition = Vector3.zero;

	public bool IsHappy => _hapinessLeft > 0f;

	public bool IsContent
	{
		get
		{
			if (!IsHappy)
			{
				return !IsSad;
			}
			return false;
		}
	}

	public bool IsSad => _hapinessLeft <= 0f - GetContentLength();

	public bool IsSuperSad => _hapinessLeft <= 0f - GetContentLength() - GetSuperSadLength();

	public CharV2()
	{
		UniqueID = ++_sequence;
	}

	public static float GetHapinessLength()
	{
		return 60f + (float)(House.GlobalInfo.CanHappyLongerAttribute.Level * 30);
	}

	public static float GetContentLength()
	{
		return 150f + (float)(House.GlobalInfo.CanNormalLongerAttribute.Level * 30);
	}

	public static float GetSuperSadLength()
	{
		return 30f;
	}

	private void Awake()
	{
		_display = GetComponent<CharDisplay>();
		_rb = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
	}

	public bool IsFalling()
	{
		if ((double)base.transform.position.y > -4.3)
		{
			return true;
		}
		if (_rb.linearVelocity.y < -0.2f || _rb.linearVelocity.y > 0.2f)
		{
			return true;
		}
		return false;
	}

	private void Update()
	{
		if (DestinationObject == null && CurrentAction == ActionEnum.GoingToGarbage)
		{
			UnreserveGarbage();
			CurrentAction = ActionEnum.Idle;
		}
		if (CurrentAction == ActionEnum.GoingToGarbage && DestinationObject != null && !DestinationObject.activeSelf)
		{
			UnreserveGarbage();
			CurrentAction = ActionEnum.Idle;
			DestinationObject = null;
		}
		if (_previousJob != null)
		{
			_breakTimer += Time.deltaTime;
			if (_breakTimer >= 5f)
			{
				_previousJob = null;
				_breakTimer = 0f;
			}
		}
		if (_dragging)
		{
			_display.ChangeEye(CharDisplay.EyeSpriteEnum.Small);
			_display.ChangeMouth(CharDisplay.MouthSpriteEnum.OpenBig);
			_display.ChangeMovement(CharDisplay.MovementEnum.IdleMovingHand);
			ProcessDrag();
		}
		else
		{
			if (IsFalling())
			{
				return;
			}
			Vector3 vector = Vector3.zero;
			if (DestinationObject != null)
			{
				vector = DestinationObject.transform.position;
			}
			else if (DestinationColumn != null)
			{
				vector = DestinationColumn.GetEnterLocation();
			}
			if (!(Mathf.Abs(vector.x - base.transform.position.x) < 0.3f))
			{
				return;
			}
			if (CurrentAction == ActionEnum.GoingToGarbage)
			{
				PickupGarbage(DestinationObject.GetComponent<Garbage>());
			}
			else if (CurrentAction == ActionEnum.GoingToBuilding)
			{
				DestinationColumn.EnterBuilding(this);
				DestinationColumn = null;
				CurrentAction = ActionEnum.InsideBuilding;
			}
			else
			{
				if (CurrentAction != ActionEnum.DroppingInBuilding)
				{
					return;
				}
				for (int num = GarbageInHand.Count - 1; num >= 0; num--)
				{
					if (DestinationColumn.DumpGarbage(GarbageInHand[num]))
					{
						GarbageInHand.RemoveAt(num);
					}
				}
				UnreserveGarbage();
				DestinationColumn = null;
				DestinationObject = null;
				CurrentAction = ActionEnum.Idle;
				_rb.linearVelocity = new Vector3(0f, 0f, 0f);
			}
		}
	}

	private void FixedUpdate()
	{
		if (_dragging)
		{
			return;
		}
		if (CurrentAction == ActionEnum.Flying)
		{
			base.transform.Rotate(new Vector3(0f, 0f, 180f * Time.fixedDeltaTime));
			if (!IsFalling())
			{
				base.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				UnreserveGarbage();
				CurrentAction = ActionEnum.Idle;
			}
		}
		if (IsFalling())
		{
			return;
		}
		if (CurrentAction == ActionEnum.Idle && _rb.bodyType != RigidbodyType2D.Static)
		{
			_rb.linearVelocity = new Vector3(0f, 0f, 0f);
		}
		float hapinessLeft = _hapinessLeft;
		_hapinessLeft -= Time.fixedDeltaTime;
		if (hapinessLeft > 0f && _hapinessLeft <= 0f)
		{
			_display.ChangeEye(CharDisplay.EyeSpriteEnum.Normal);
			_display.ChangeMouth(CharDisplay.MouthSpriteEnum.Normal);
		}
		else if (hapinessLeft > 0f - GetContentLength() && _hapinessLeft <= 0f - GetContentLength())
		{
			_display.ChangeEye(CharDisplay.EyeSpriteEnum.Closed);
			_display.ChangeMouth(CharDisplay.MouthSpriteEnum.Sad);
		}
		Vector3 vector = Vector3.zero;
		if (DestinationObject != null)
		{
			vector = DestinationObject.transform.position;
		}
		else if (DestinationColumn != null)
		{
			vector = DestinationColumn.GetEnterLocation();
		}
		if (vector != Vector3.zero)
		{
			if (IsHappy)
			{
				if (GarbageInHand.Count > 0)
				{
					_display.ChangeDisplay(CharDisplay.MovementEnum.MovingHandUp, CharDisplay.EyeSpriteEnum.Small, CharDisplay.MouthSpriteEnum.Happy);
				}
				else
				{
					_display.ChangeDisplay(CharDisplay.MovementEnum.MovingHandDown, CharDisplay.EyeSpriteEnum.Small, CharDisplay.MouthSpriteEnum.Happy);
				}
			}
			else if (IsSad)
			{
				if (GarbageInHand.Count > 0)
				{
					_display.ChangeDisplay(CharDisplay.MovementEnum.MovingHandUp, CharDisplay.EyeSpriteEnum.Closed, CharDisplay.MouthSpriteEnum.Sad);
				}
				else
				{
					_display.ChangeDisplay(CharDisplay.MovementEnum.MovingHandDown, CharDisplay.EyeSpriteEnum.Closed, CharDisplay.MouthSpriteEnum.Sad);
				}
			}
			else if (GarbageInHand.Count > 0)
			{
				_display.ChangeDisplay(CharDisplay.MovementEnum.MovingHandUp, CharDisplay.EyeSpriteEnum.Normal, CharDisplay.MouthSpriteEnum.Normal);
			}
			else
			{
				_display.ChangeDisplay(CharDisplay.MovementEnum.MovingHandDown, CharDisplay.EyeSpriteEnum.Normal, CharDisplay.MouthSpriteEnum.Normal);
			}
			if (vector.x < base.transform.position.x)
			{
				float num = GetMovementSpeed();
				if (MathF.Abs(base.transform.position.x - vector.x) < 1.2f && num > 6f)
				{
					num = 6f;
				}
				_rb.linearVelocity = new Vector3(0f - num, 0f, 0f);
				_display.ChangeSide(CharDisplay.SideEnum.Left);
			}
			else if (vector.x > base.transform.position.x)
			{
				float num2 = GetMovementSpeed();
				if (MathF.Abs(base.transform.position.x - vector.x) < 1.2f && num2 > 6f)
				{
					num2 = 6f;
				}
				_rb.linearVelocity = new Vector3(num2, 0f, 0f);
				_display.ChangeSide(CharDisplay.SideEnum.Right);
			}
		}
		else if (IsHappy)
		{
			_display.ChangeDisplay(CharDisplay.MovementEnum.IdleHandDown, CharDisplay.EyeSpriteEnum.Small, CharDisplay.MouthSpriteEnum.Happy);
		}
		else if (IsSad)
		{
			_display.ChangeDisplay(CharDisplay.MovementEnum.IdleHandDown, CharDisplay.EyeSpriteEnum.Closed, CharDisplay.MouthSpriteEnum.Sad);
		}
		else
		{
			_display.ChangeDisplay(CharDisplay.MovementEnum.IdleHandDown, CharDisplay.EyeSpriteEnum.Normal, CharDisplay.MouthSpriteEnum.Normal);
		}
	}

	public bool HasShardOrBookInHand()
	{
		foreach (Garbage item in GarbageInHand)
		{
			if (item.Info.IsShard || item.Info.IsBook)
			{
				return true;
			}
		}
		return false;
	}

	private float GetMovementSpeed()
	{
		float num = GameController.GlobalInfo.GetCharacterSpeed(IsHappy, IsContent, IsSad || IsSuperSad);
		if (HasShardOrBookInHand())
		{
			num /= 16f;
		}
		if (num < 0.1f)
		{
			num = 0.1f;
		}
		return num;
	}

	public void MoveToGarbage(Garbage g)
	{
		g.IsReserved = true;
		DestinationObject = g.gameObject;
		CurrentAction = ActionEnum.GoingToGarbage;
	}

	public void DropGarbage()
	{
		foreach (Garbage item in GarbageInHand)
		{
			item.SetAsDynamic();
			item.IsReserved = false;
			GameController.Instance.GarbageController.BringBack(item);
		}
		GarbageInHand.Clear();
	}

	public void UnreserveGarbage()
	{
		if (DestinationObject != null && DestinationObject.activeSelf && DestinationObject.GetComponent<Garbage>() != null)
		{
			GameController.Instance.PeonController.RemoveReserveGarbage(DestinationObject.GetComponent<Garbage>());
		}
	}

	public void PickupGarbage(Garbage g)
	{
		if (g == null)
		{
			return;
		}
		g.RemoveDrag();
		g.IsReserved = false;
		GarbageInHand.Add(g);
		CurrentAction = ActionEnum.Idle;
		UnreserveGarbage();
		DestinationObject = null;
		GameController.Instance.GarbageController.Remove(g);
		g.SetAsStatic();
		g.transform.SetParent(base.transform);
		float num = FirstHoldingLoc.transform.localPosition.y;
		foreach (Garbage item in GarbageInHand)
		{
			num += item.GetHeight();
		}
		g.transform.localPosition = new Vector3(0f, num, 0f);
	}

	public void MoveToBuilding(ColumnController column)
	{
		DropGarbage();
		UnreserveGarbage();
		column.ReserveBuilding(this);
		DestinationColumn = column;
		CurrentAction = ActionEnum.GoingToBuilding;
	}

	public void MoveToBuildingToDump(ColumnController column)
	{
		DestinationColumn = column;
		CurrentAction = ActionEnum.DroppingInBuilding;
	}

	public bool AreHandsFull()
	{
		if (HasShardOrBookInHand())
		{
			return true;
		}
		if (GarbageInHand.Count >= GameController.GlobalInfo.GetCharacterCarryLimit())
		{
			return true;
		}
		return false;
	}

	public void SetAsOutside(Vector3 location)
	{
		_rb.bodyType = RigidbodyType2D.Dynamic;
		_rb.simulated = true;
		base.transform.SetParent(GameController.Instance.PeonController.transform);
		base.transform.position = location;
		_display.ChangeLocation(CharDisplay.LocationEnum.Outside);
	}

	public void SetMaxHapiness(bool showHearth = false)
	{
		if (_hapinessLeft < GetHapinessLength())
		{
			_hapinessLeft = GetHapinessLength();
		}
		_display.ChangeEye(CharDisplay.EyeSpriteEnum.Small);
		_display.ChangeMouth(CharDisplay.MouthSpriteEnum.Happy);
		if (showHearth)
		{
			_display.ShowHearth();
		}
	}

	private void OnMouseDown()
	{
		if (!Sign.PreventEvent && (!(GameController.Instance != null) || !GameController.Instance.AreBuildingOnTop))
		{
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ga_grab_peon);
			_dragging = true;
			_lastDragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			CurrentAction = ActionEnum.Picked;
			DropGarbage();
			UnreserveGarbage();
		}
	}

	private void OnMouseUp()
	{
		if (_dragging)
		{
			UnreserveGarbage();
			_dragging = false;
			CurrentAction = ActionEnum.Idle;
			DestinationObject = null;
			DestinationColumn = null;
			_rb.linearVelocity = _lastDragDir * 50f;
			if (_lastDragDir.magnitude >= 0.2f)
			{
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ga_throw_peon);
				GameController.TotalPeonThrow++;
			}
		}
	}

	private void ProcessDrag()
	{
		if (_dragging)
		{
			Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_lastDragDir = vector - _lastDragPosition;
			base.transform.position = Vector2.Lerp(base.transform.position, vector, 1f);
			_lastDragPosition = vector;
		}
	}

	public void SetPreviousJob(BaseBuilding building)
	{
		_previousJob = building;
		_breakTimer = 0f;
	}

	public bool IsInBreak(ColumnController col)
	{
		if (col == null)
		{
			return false;
		}
		if (col.Buildings == null)
		{
			return false;
		}
		return IsInBreak(col.Buildings);
	}

	public bool IsInBreak(BaseBuilding building)
	{
		if (_previousJob == building)
		{
			return true;
		}
		return false;
	}

	public void Fly(bool rightOnly = false)
	{
		if (!rightOnly)
		{
			base.transform.position += new Vector3(0f, 3f, 0f);
		}
		float num = 0f;
		num = ((!rightOnly) ? UnityEngine.Random.Range(base.transform.position.x - 7f, base.transform.position.x + 7f) : UnityEngine.Random.Range(base.transform.position.x + 2f, base.transform.position.x + 7f));
		float num2 = 0f;
		num2 = ((!rightOnly) ? (-5f) : 0f);
		Vector2 throwVelocity = Helper.GetThrowVelocity(base.transform.position, new Vector3(num, num2, 0f));
		_rb.AddForce(throwVelocity, ForceMode2D.Impulse);
		CurrentAction = ActionEnum.Flying;
	}

	public void VerifyDestination()
	{
		if (DestinationColumn != null && DestinationColumn.Buildings == null)
		{
			DestinationColumn = null;
			CurrentAction = ActionEnum.Idle;
		}
	}

	public void SetTempJob(BaseBuilding b)
	{
		TempJob = b;
	}

	public void RemoveOutOfBuilding(BaseBuilding b, Vector3 doorLocation)
	{
		SetTempJob(null);
		SetPreviousJob(b);
		TempJob = null;
		Job = null;
		CurrentAction = ActionEnum.Idle;
		SetAsOutside(doorLocation);
		base.gameObject.SetActive(value: true);
	}

	public void EnterBuilding(BaseBuilding building)
	{
		base.gameObject.SetActive(value: false);
	}

	public void ResetForSpawn()
	{
		_hapinessLeft = 0f;
		GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
		DropGarbage();
		UnreserveGarbage();
		if (Job != null)
		{
			Job.RemoveWorker(this);
		}
		if (TempJob != null)
		{
			TempJob.RemoveWorker(this);
		}
		DestinationObject = null;
		DestinationColumn = null;
		CurrentAction = ActionEnum.Idle;
	}
}
