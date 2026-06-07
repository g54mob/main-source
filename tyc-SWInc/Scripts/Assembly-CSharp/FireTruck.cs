using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireTruck : MonoBehaviour
{
	public NormalCar Car;

	public Transform[] SprayPoints;

	public float RotSpeed;

	[NonSerialized]
	public List<Room> Rooms;

	[NonSerialized]
	private Room _currentRoom;

	public Transform MainCanon;

	public Transform SecondaryCanon;

	public bool Turning;

	public ParticleSystem Particles;

	public AudioSource SFX;

	private void Update()
	{
		if (Car.GoHome || Car.Car.CurrentSpeed > 0f)
		{
			return;
		}
		if (_currentRoom == null)
		{
			int num;
			for (num = 0; num < Rooms.Count; num++)
			{
				Room room = Rooms[num];
				if (room.IsOnFire && room.BurnStop > 0f)
				{
					_currentRoom = room;
					break;
				}
				Rooms.RemoveAt(num);
				num--;
			}
			Turning = true;
		}
		if (_currentRoom == null)
		{
			SFX.Stop();
			Particles.Stop();
			Car.GoHome = true;
			return;
		}
		if (Turning)
		{
			Quaternion quaternion = Quaternion.LookRotation(_currentRoom.Center.ToVector3((float)(_currentRoom.Floor * 2) + 1f) - MainCanon.transform.position);
			Quaternion quaternion2 = Quaternion.Euler(0f, quaternion.eulerAngles.y, 0f);
			int num2 = 0;
			MainCanon.transform.rotation = Quaternion.RotateTowards(MainCanon.transform.rotation, quaternion2, RotSpeed * Time.deltaTime * GameSettings.GameSpeed);
			if (Mathf.Abs(Quaternion.Angle(quaternion2, MainCanon.transform.rotation)) < 0.1f)
			{
				MainCanon.transform.rotation = quaternion2;
				num2++;
			}
			SecondaryCanon.transform.rotation = Quaternion.Euler(SecondaryCanon.transform.rotation.eulerAngles.x, MainCanon.transform.rotation.eulerAngles.y, 0f);
			quaternion2 = Quaternion.Euler(quaternion.eulerAngles.x, MainCanon.transform.rotation.eulerAngles.y, 0f);
			SecondaryCanon.transform.rotation = Quaternion.RotateTowards(SecondaryCanon.transform.rotation, quaternion2, RotSpeed * Time.deltaTime * GameSettings.GameSpeed);
			if (Mathf.Abs(Quaternion.Angle(quaternion2, SecondaryCanon.transform.rotation)) < 0.1f)
			{
				SecondaryCanon.transform.rotation = quaternion2;
				num2++;
			}
			if (num2 == 2)
			{
				Turning = false;
			}
		}
		bool flag = false;
		if (!Turning)
		{
			flag = true;
			Vector3 v = _currentRoom.Center.ToVector3((float)(_currentRoom.Floor * 2) + 1f) - Particles.transform.position;
			Particles.transform.rotation = v.LookDir();
			ParticleSystem.MainModule main = Particles.main;
			main.startLifetimeMultiplier = v.magnitude / 10f;
			_currentRoom.BurnStop -= Utilities.PerHour(100f / _currentRoom.Area);
			if (!_currentRoom.IsOnFire || _currentRoom.BurnStop <= 0f)
			{
				_currentRoom = null;
			}
		}
		bool flag2 = GameSettings.GameSpeed > 0f && flag;
		if (flag2)
		{
			if (!SFX.isPlaying)
			{
				SFX.Play();
			}
			SFX.outputAudioMixerGroup = ((GameSettings.Instance.sRoomManager.CameraRoom == GameSettings.Instance.sRoomManager.Outside) ? AudioManager.InGameNormal : AudioManager.InGameHighPass);
		}
		else if (!flag2 && SFX.isPlaying)
		{
			SFX.Stop();
		}
		if (flag)
		{
			if (!Particles.isPlaying)
			{
				Particles.Play();
			}
			ParticleSystem.MainModule main2 = Particles.main;
			main2.simulationSpeed = Mathf.Max(0.01f, HUD.Instance.GameSpeed);
		}
		else if (Particles.isPlaying)
		{
			Particles.Stop();
		}
	}

	public void Serialize(WriteDictionary d)
	{
		d["FRooms"] = Rooms.SelectInPlace((Room x) => x.DID);
		d["FRoom"] = ((_currentRoom != null) ? _currentRoom.DID : 0u);
		d["FTurning"] = Turning;
		d["FRot1"] = (SVector3)MainCanon.rotation;
		d["FRot2"] = (SVector3)SecondaryCanon.rotation;
	}

	public void Deserialize(WriteDictionary d)
	{
		Rooms = d.Get("FRooms", new uint[0]).SelectNotNull((uint x) => Writeable.STGetDeserializedObject(x) as Room).ToList();
		_currentRoom = Writeable.STGetDeserializedObject(d.Get("FRoom", 0u)) as Room;
		Turning = d.Get("FTurning", false);
		MainCanon.rotation = d.Get("FRot1", SVector3.Zero);
		SecondaryCanon.rotation = d.Get("FRot2", SVector3.Zero);
	}
}
