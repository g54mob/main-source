using System;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
	public float Speed = 2f;

	public float waitTime = 1f;

	public string OpenSFX = "DoorOpen";

	public string CloseSFX = "DoorClose";

	private float timer;

	private bool Open;

	private bool Close;

	private bool Wait;

	private bool CanWait = true;

	private bool Front;

	private bool Force;

	public float MaxSoundDistance = 8f;

	public bool Scale;

	public bool Reverse;

	public bool DoorCloseSoundOnClose;

	public Quaternion OriginalRot;

	public RoomSegment Owner;

	public Furniture FOwner;

	public bool IsSegment = true;

	[NonSerialized]
	private bool _inDoor;

	[NonSerialized]
	private bool _init;

	public int Floor
	{
		get
		{
			if (!IsSegment)
			{
				return FOwner.GetFloor();
			}
			return Owner.Floor;
		}
	}

	private void Start()
	{
		Init();
	}

	public void Init()
	{
		if (!_init)
		{
			OriginalRot = base.transform.localRotation;
			_init = true;
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull() || (!IsSegment && FOwner.isTemporary))
		{
			return;
		}
		if ((!string.IsNullOrEmpty(CloseSFX) || !string.IsNullOrEmpty(OpenSFX)) && MayPlaySound())
		{
			Room cameraRoom = GameSettings.Instance.sRoomManager.CameraRoom;
			bool flag = cameraRoom == null || cameraRoom.Outside;
			if (IsSegment)
			{
				_inDoor = !(Owner.OnlyInterior && flag) && ((flag && Owner.IsAgainstExterior) || cameraRoom == Owner.ParentRooms[0] || cameraRoom == Owner.ParentRooms[1]);
			}
			else
			{
				_inDoor = FOwner.Parent != null && (object)cameraRoom.GetMainAtriumParentOrSelf() == FOwner.Parent.GetMainAtriumParentOrSelf();
			}
		}
		if (Close || Open || Wait)
		{
			float num = (Force ? Mathf.Max(GameSettings.GameSpeed, 1f) : GameSettings.GameSpeed);
			timer = Mathf.Min(1f, timer + Time.deltaTime * num * (Wait ? (1f / waitTime) : Speed));
		}
		if (Close || Open)
		{
			float num2 = (Close ? (1f - timer) : timer);
			if (!Front)
			{
				num2 = 0f - num2;
			}
			SetState(num2);
		}
		if (!(timer > 0.9999f))
		{
			return;
		}
		Force = false;
		if (Wait)
		{
			if (DoorCloseSoundOnClose && !string.IsNullOrEmpty(CloseSFX) && MayPlaySound())
			{
				UISoundFX.PlaySFX(CloseSFX, base.transform.position, !_inDoor, -1f, MaxSoundDistance);
			}
			Close = true;
			Wait = false;
			timer = 0f;
		}
		else if (Open)
		{
			if (CanWait)
			{
				Wait = true;
				Open = false;
				timer = 0f;
			}
		}
		else if (Close)
		{
			if (!DoorCloseSoundOnClose && !string.IsNullOrEmpty(CloseSFX) && MayPlaySound())
			{
				UISoundFX.PlaySFX(CloseSFX, base.transform.position, !_inDoor, -1f, MaxSoundDistance);
			}
			Close = false;
			timer = 0f;
		}
	}

	public void SetState(float openState)
	{
		if (Scale)
		{
			base.transform.localScale = new Vector3(1f, 1f, 1f - Mathf.Abs(openState));
		}
		else
		{
			base.transform.localRotation = Quaternion.Euler(0f, openState * 90f, 0f) * OriginalRot;
		}
	}

	public bool MayPlaySound()
	{
		if (Floor == CameraScript.Instance.GetCameraFloor())
		{
			return (CameraScript.Instance.LastListenerPos - base.transform.position).sqrMagnitude < MaxSoundDistance * MaxSoundDistance;
		}
		return false;
	}

	public void CloseNow(bool force = false)
	{
		Force = force;
		if (DoorCloseSoundOnClose && !string.IsNullOrEmpty(CloseSFX) && MayPlaySound())
		{
			UISoundFX.PlaySFX(CloseSFX, base.transform.position, !_inDoor, -1f, MaxSoundDistance);
		}
		if (Open || Wait)
		{
			timer = 0f;
		}
		if (!Close)
		{
			Close = true;
			Wait = false;
			Open = false;
		}
		CanWait = true;
	}

	public bool IsInFront(Vector3 p)
	{
		return Utilities.IsLeft(Owner.transform.position.FlattenVector3(), (Owner.transform.position + Owner.transform.right).FlattenVector3(), p.FlattenVector3()) > 0;
	}

	public void DoorCollision(bool front, bool canWait = true, bool force = false)
	{
		CanWait = canWait;
		Force = force;
		if (Close)
		{
			timer = 1f - timer;
			Open = true;
			Close = false;
		}
		else if (Wait)
		{
			timer = 0f;
		}
		else if (!Open)
		{
			if (!string.IsNullOrEmpty(OpenSFX) && MayPlaySound())
			{
				UISoundFX.PlaySFX(OpenSFX, base.transform.position, !_inDoor, -1f, MaxSoundDistance);
			}
			Open = true;
			Front = Reverse ^ front;
		}
	}
}
