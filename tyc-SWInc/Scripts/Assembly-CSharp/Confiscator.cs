using System;
using System.Collections.Generic;
using UnityEngine;

public class Confiscator : Writeable
{
	public float[] MetalScales = new float[3] { 0.2f, 0.6f, 1.3f };

	public float[] GoldHeight = new float[3] { 0.4f, 0.5f, 1.25f };

	public Mesh[] MetalMeshes;

	public float Speed = 10f;

	public float FanSpeed = 30f;

	public float GoldDistance = 0.1f;

	public float TiltAmount = 25f;

	public float TiltSpeed = 45f;

	public float Acceleration = 10f;

	public float HeightSpeed = 50f;

	public Renderer[] Rends;

	public Transform[] Fans;

	public Transform[] Grabbers;

	public Transform MainGrabber;

	public Transform MainBody;

	public Renderer Metal;

	public string WallHole;

	public string FloorHole;

	public AudioSource SFX;

	public AudioClip[] WallBreak;

	public AudioClip GrabberClip;

	public float MaxVolume = 1f;

	[NonSerialized]
	public Furniture Target;

	[NonSerialized]
	private Room _above;

	[NonSerialized]
	private int _state;

	[NonSerialized]
	private float _currentSpeed = 10f;

	[NonSerialized]
	private Vector2 _start;

	[NonSerialized]
	private uint _sTarget;

	[NonSerialized]
	private uint _sAbove;

	[NonSerialized]
	private float _targetY;

	[NonSerialized]
	private float _stateProg;

	[NonSerialized]
	private float _targetHeight;

	[NonSerialized]
	private Quaternion _fromTo;

	[NonSerialized]
	private Vector3 _actualPosition;

	[NonSerialized]
	private Vector3 _offset;

	[NonSerialized]
	private int _wallBreakSfx = -1;

	private AudioClip GetWallBreak()
	{
		if (_wallBreakSfx < 0)
		{
			_wallBreakSfx = UnityEngine.Random.Range(0, WallBreak.Length);
		}
		else
		{
			_wallBreakSfx = (_wallBreakSfx + UnityEngine.Random.Range(1, WallBreak.Length)) % WallBreak.Length;
		}
		return WallBreak[_wallBreakSfx];
	}

	private void SetGrabbers(float yoffset, float grabReach)
	{
		MainGrabber.localScale = new Vector3(0.5f, 0.5f, yoffset);
		for (int i = 0; i < Grabbers.Length; i++)
		{
			Transform obj = Grabbers[i];
			obj.localScale = new Vector3(0.5f, 0.5f, grabReach * MetalScales[Target.MetalLevel]);
			obj.localPosition = MainGrabber.localPosition + Vector3.down * MainGrabber.localScale.z;
		}
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		dictionary["Position"] = base.transform.position;
		dictionary["ActualPosition"] = _actualPosition;
		dictionary["Offset"] = _offset;
		dictionary["Start"] = _start;
		dictionary["Rotation"] = base.transform.rotation.eulerAngles;
		dictionary["Target"] = Target.DID;
		dictionary["State"] = _state;
		dictionary["Above"] = ((!(_above == null)) ? _above.DID : 0u);
		dictionary["StateProgress"] = _stateProg;
		dictionary["TargetY"] = _targetY;
		dictionary["CurrentSpeed"] = _currentSpeed;
		dictionary["FromTo"] = (SVector3)_fromTo;
		dictionary["TargetHeight"] = _targetHeight;
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		base.transform.position = dictionary.Get("Position", Vector3.zero);
		_actualPosition = dictionary.Get("ActualPosition", Vector3.zero);
		_offset = dictionary.Get("Offset", Vector3.zero);
		base.transform.rotation = Quaternion.Euler(dictionary.Get("Rotation", Vector3.forward));
		_start = dictionary.Get("Start", Vector2.zero);
		_sTarget = dictionary.Get("Target", 0u);
		_sAbove = dictionary.Get("Above", 0u);
		_state = dictionary.Get("State", 0);
		_stateProg = dictionary.Get("StateProgress", 0f);
		_targetY = dictionary.Get("TargetY", 0f);
		_currentSpeed = dictionary.Get("CurrentSpeed", Speed);
		_targetHeight = dictionary.Get("TargetHeight", base.transform.position.y);
		InitFromTo(dictionary.Get("FromTo", (SVector3)Quaternion.identity));
		SetGrabbers(0f, 0f);
		return this;
	}

	private void InitFromTo(Quaternion fromTo)
	{
		_fromTo = fromTo;
		MainGrabber.transform.rotation = _fromTo * MainGrabber.transform.rotation;
		for (int i = 0; i < Grabbers.Length; i++)
		{
			Transform transform = Grabbers[i];
			transform.transform.rotation = _fromTo * transform.transform.rotation;
		}
		Metal.transform.rotation = _fromTo * Metal.transform.rotation;
	}

	protected override bool WriteDID()
	{
		return false;
	}

	public override void PostDeserialize()
	{
		Target = GetDeserializedObject(_sTarget) as Furniture;
		_above = GetDeserializedObject(_sAbove) as Room;
	}

	public override string WriteName()
	{
		return "Confiscator";
	}

	public void Init()
	{
		if (!GameSettings.Instance.IsReferenceNull() && !GameSettings.Instance.Confiscators.Contains(this))
		{
			GameSettings.Instance.Confiscators.Add(this);
		}
		if (UnityEngine.Random.value > 0.5f)
		{
			_start = new Vector2(UnityEngine.Random.value * 256f, (!(UnityEngine.Random.value > 0.5f)) ? 256 : 0);
		}
		else
		{
			_start = new Vector2((!(UnityEngine.Random.value > 0.5f)) ? 256 : 0, UnityEngine.Random.value * 256f);
		}
		int num = Target.Floor;
		if (Target.Floor < 0)
		{
			num = 0;
		}
		Metal.GetComponent<MeshFilter>().sharedMesh = MetalMeshes[Target.MetalLevel];
		SetGrabbers(0f, 0f);
		base.transform.position = (_actualPosition = _start.ToVector3((float)(num * 2) + 1.8f));
		_targetHeight = base.transform.position.y;
		base.transform.rotation = Quaternion.LookRotation((Target.transform.position.FlattenVector3() - _start).ToVector3(0f));
		InitFromTo(Quaternion.FromToRotation(base.transform.rotation * Vector3.forward, Target.transform.rotation * Vector3.forward));
		_targetY = MainGrabber.transform.position.y - (Target.transform.position.y + GoldHeight[Target.MetalLevel]) - GoldDistance;
		_currentSpeed = Speed;
	}

	private bool UpdateVisibility(int floor)
	{
		bool flag = Utilities.InBasement(floor) == Utilities.InBasement(GameSettings.Instance.ActiveFloor) && floor <= GameSettings.Instance.ActiveFloor;
		if (flag ^ Rends[0].enabled)
		{
			for (int i = 0; i < Rends.Length; i++)
			{
				Rends[i].enabled = flag;
			}
		}
		bool flag2 = flag && GameSettings.GameSpeed > 0f && (base.transform.position - CameraScript.Instance.LastListenerPos).sqrMagnitude < SFX.maxDistance * SFX.maxDistance;
		if (!flag2 && SFX.isPlaying)
		{
			SFX.volume = Mathf.Lerp(SFX.volume, 0f, Time.deltaTime * 8f);
			if (Mathf.Approximately(SFX.volume, 0f))
			{
				SFX.Stop();
			}
		}
		else if (flag2)
		{
			if (!SFX.isPlaying)
			{
				SFX.volume = 0f;
				SFX.Play();
			}
			else
			{
				SFX.volume = Mathf.Lerp(SFX.volume, MaxVolume, Time.deltaTime * 8f);
			}
			Room roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(floor, _actualPosition.FlattenVector3());
			SFX.outputAudioMixerGroup = ((GameSettings.Instance.sRoomManager.CameraRoom == roomFromPoint) ? AudioManager.InGameNormal : AudioManager.InGameHighPass);
		}
		return flag;
	}

	private float GetTargetHeight()
	{
		Vector2 vector = _actualPosition.FlattenVector3() + base.transform.forward.FlattenVector3();
		_offset = Vector3.zero;
		for (int i = 0; i < RoadManager.Instance.Landmarks.Count; i++)
		{
			Landmark landmark = RoadManager.Instance.Landmarks[i];
			float num = landmark.GetHeight() + 1.8f;
			if (!(num > _targetHeight))
			{
				continue;
			}
			Rect area = landmark.GetArea();
			if (area.Contains(vector))
			{
				Vector2 vector2 = _actualPosition.FlattenVector3();
				Vector2 vector3 = Utilities.ProjectToLineEndless(area.center, vector2, vector);
				if (vector3.x > area.xMax - 1f || vector3.x < area.xMin + 1f || vector3.y > area.yMax - 1f || vector3.y < area.yMin + 1f)
				{
					Vector2 vector4 = area.center + (vector2 - area.center).normalized * (area.size.magnitude * 0.5f + 0.5f);
					vector4 = new Vector2(Mathf.Clamp(vector4.x, area.xMin - 0.5f, area.xMax + 0.5f), Mathf.Clamp(vector4.y, area.yMin - 0.5f, area.yMax + 0.5f));
					_offset = (vector4 - vector2).ToVector3(0f);
					return _targetHeight;
				}
				return num;
			}
		}
		return _targetHeight;
	}

	private void FixedUpdate()
	{
		if (GameSettings.Instance.IsReferenceNull() || !SelectorController.Instance.DoneLoading)
		{
			return;
		}
		if (_state == 0 && Target == null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			GameSettings.Instance.Confiscators.Remove(this);
			return;
		}
		if (GameSettings.GameSpeed <= 0f)
		{
			UpdateVisibility(Mathf.FloorToInt(base.transform.position.y / 2f));
			return;
		}
		int num = Mathf.FloorToInt((base.transform.position.y - 1f) / 2f);
		Vector2 vector = _actualPosition.FlattenVector3();
		SFX.pitch = _currentSpeed.MapRange(0f, Speed, 0.7f, 1f, true);
		if (ShouldMove())
		{
			MainBody.localRotation = Quaternion.Lerp(MainBody.localRotation, Quaternion.Euler(TiltAmount * (_currentSpeed / Speed), 0f, 0f), Time.deltaTime * GameSettings.GameSpeed * TiltSpeed);
			float num2 = Mathf.Min(2f, _currentSpeed * Time.deltaTime * GameSettings.GameSpeed);
			Vector2 vector2 = base.transform.position.FlattenVector3();
			_actualPosition = (_actualPosition + base.transform.forward * num2).ReplaceY(Mathf.Lerp(_actualPosition.y, GetTargetHeight(), Time.deltaTime * GameSettings.GameSpeed * HeightSpeed));
			base.transform.position = Vector3.Lerp(base.transform.position, _actualPosition + _offset, Time.deltaTime * GameSettings.GameSpeed * 5f);
			vector = _actualPosition.FlattenVector3();
			Room room = GameSettings.Instance.sRoomManager.GetRoomFromPoint(num, vector, true, false);
			if (room != null && (room.Outside || room.Outdoors || room.Pillar))
			{
				room = null;
			}
			if (room != _above && !GameSettings.Instance.RentMode)
			{
				Room room2 = room ?? _above;
				Vector2 vector3 = (vector - vector2).normalized * 0.1f;
				for (int i = 0; i < room2.Edges.Count; i++)
				{
					WallEdge wallEdge = room2.Edges[i];
					WallEdge wallEdge2 = room2.Edges[(i + 1) % room2.Edges.Count];
					Vector2? lineIntersection = Utilities.GetLineIntersection(vector2 - vector3, vector + vector3, wallEdge.Pos, wallEdge2.Pos);
					if (!lineIntersection.HasValue)
					{
						continue;
					}
					float magnitude = (wallEdge2.Pos - wallEdge.Pos).magnitude;
					float num3 = Mathf.Clamp((lineIntersection.Value - wallEdge.Pos).magnitude, 0.5f, magnitude - 0.5f);
					bool flag = true;
					HashSet<WallSnap> value;
					if (wallEdge.Children.TryGetValue(wallEdge2, out value))
					{
						foreach (WallSnap item in value)
						{
							float num4 = item.WallPosition[wallEdge];
							if (Utilities.Overlap(num3 - 0.5f, num3 + 0.5f, num4 - item.WallWidth / 2f, num4 + item.WallWidth / 2f))
							{
								RoomSegment roomSegment;
								if ((object)(roomSegment = item as RoomSegment) != null && WallHole.Equals(roomSegment.name))
								{
									flag = false;
									break;
								}
								item.DestroyGO();
							}
						}
					}
					if (flag)
					{
						UISoundFX.PlaySFX(GetWallBreak(), base.transform.position, AudioManager.InGameNormal, 1f, UnityEngine.Random.Range(0.9f, 1.1f), 16f);
						RoomSegment component = UnityEngine.Object.Instantiate(ObjectDatabase.Instance.GetSegmentComponent(WallHole)).GetComponent<RoomSegment>();
						component.Floor = num;
						component.transform.position = lineIntersection.Value.ToVector3(num * 2);
						component.Init(wallEdge, wallEdge2, num3 / magnitude);
						component.name = component.name.Replace("(Clone)", "").Trim();
						Vector3 vector4 = (wallEdge2.Pos - wallEdge.Pos).normalized.Turn90().ToVector3(0f);
						EmitDirt(lineIntersection.Value.ToVector3(num * 2 + 1), new Vector4(-0.5f, -1f, 0.5f, 1f), Quaternion.LookRotation(vector4));
						EmitDirt(lineIntersection.Value.ToVector3(num * 2 + 1), new Vector4(-0.5f, -1f, 0.5f, 1f), Quaternion.LookRotation(-vector4));
					}
					break;
				}
			}
			_above = room;
		}
		else
		{
			_offset = Vector3.zero;
			_actualPosition = _actualPosition.ReplaceY(Mathf.Lerp(_actualPosition.y, _targetHeight, Time.deltaTime * GameSettings.GameSpeed * HeightSpeed));
			base.transform.position = Vector3.Lerp(base.transform.position, _actualPosition + _offset, Time.deltaTime * GameSettings.GameSpeed * 5f);
			MainBody.localRotation = Quaternion.Lerp(MainBody.localRotation, Quaternion.identity, Time.deltaTime * GameSettings.GameSpeed * TiltSpeed);
		}
		if (UpdateVisibility(num))
		{
			Quaternion quaternion = Quaternion.Euler(0f, Time.deltaTime * FanSpeed, 0f);
			for (int j = 0; j < Fans.Length; j++)
			{
				Fans[j].transform.localRotation = Fans[j].transform.localRotation * quaternion;
			}
		}
		switch (_state)
		{
		case 0:
			_currentSpeed = (vector - Target.transform.position.FlattenVector3()).magnitude.MapRange(0f, 1f, 1f, Speed, true);
			if ((_start - vector).sqrMagnitude > (_start - Target.transform.position.FlattenVector3()).sqrMagnitude)
			{
				_actualPosition = Target.transform.position.ReplaceY(_targetHeight);
				_offset = Vector3.zero;
				_currentSpeed = 0f;
				if (Target.Floor < 0 && !GameSettings.Instance.RentMode)
				{
					UISoundFX.PlaySFX(GetWallBreak(), base.transform.position, SFX.outputAudioMixerGroup, 1f, UnityEngine.Random.Range(0.9f, 1.1f), 16f);
					bool inventory;
					FurnitureBuilder.MakeFurn(Target.transform.position, Quaternion.Euler(0f, Utilities.RandomValue * 360f, 0f), Target.Parent, null, null, 0f, false, null, ObjectDatabase.Instance.GetFurniture(FloorHole), 0f, false, out inventory, true);
					GrassSystem.Instance.InvalidateArea();
					TimeOfDay.Instance.GroundTopDirty = true;
					EmitDirt(Target.transform.position + Vector3.up * 2f, new Vector4(-0.5f, -0.5f, 0.5f, 0.5f), Quaternion.LookRotation(Vector3.up, Vector3.left));
				}
				if (SFX.isPlaying)
				{
					UISoundFX.PlaySFX(GrabberClip, base.transform.position, SFX.outputAudioMixerGroup);
				}
				_state = 1;
			}
			break;
		case 1:
			_stateProg += Time.deltaTime * GameSettings.GameSpeed;
			SetGrabbers(_stateProg * _targetY, 0f);
			if (_stateProg >= 1f)
			{
				_state = 2;
				_stateProg = 0f;
			}
			break;
		case 2:
			_stateProg += Time.deltaTime * GameSettings.GameSpeed;
			SetGrabbers(_targetY, Mathf.Min(1f, _stateProg));
			if (_stateProg >= 1f)
			{
				Metal.gameObject.SetActive(true);
				SetMetalPos();
				Metal.SetPropertyBlock(Target.GetBlock());
				Target.Undo = true;
				Target.DestroyGO();
				_state = 3;
				_stateProg = 0f;
			}
			break;
		case 3:
			_stateProg += Time.deltaTime * GameSettings.GameSpeed;
			SetGrabbers(Mathf.Lerp(_targetY, GoldDistance, Mathf.Min(1f, _stateProg)), 1f);
			SetMetalPos();
			if (_stateProg >= 1f)
			{
				_state = 4;
			}
			break;
		case 4:
			SetGrabbers(GoldDistance, 1f);
			_currentSpeed = Mathf.Min(Speed, _currentSpeed + Time.deltaTime * GameSettings.GameSpeed * Acceleration);
			if (vector.x < 0f || vector.x > 256f || vector.y < 0f || vector.y > 256f)
			{
				GameSettings.Instance.Confiscators.Remove(this);
				UnityEngine.Object.Destroy(base.gameObject);
			}
			break;
		}
	}

	private void SetMetalPos()
	{
		Metal.transform.position = Metal.transform.position.ReplaceY(MainGrabber.transform.position.y - MainGrabber.transform.localScale.z - GoldDistance - GoldHeight[Target.MetalLevel]);
	}

	private bool ShouldMove()
	{
		if (_state != 0)
		{
			return _state == 4;
		}
		return true;
	}

	private void EmitDirt(Vector3 center, Vector4 extents, Quaternion dir)
	{
		Vector3 vector = dir * Vector3.forward;
		for (int i = 0; i < 10; i++)
		{
			Room.EmitDirt(center + dir * new Vector3(UnityEngine.Random.Range(extents.x, extents.z), 0f, UnityEngine.Random.Range(extents.y, extents.w)), vector * UnityEngine.Random.Range(1f, 3f));
		}
	}
}
