using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BusScript : MonoBehaviour
{
	public float Wait = -1f;

	public CarScript Car;

	public static bool Present;

	private bool WaitingToFill;

	public CarSpawn Input;

	public AudioClip BusStopSound;

	private float _waitTimer;

	public void Reset()
	{
		Wait = -1f;
		WaitingToFill = false;
	}

	public void Init()
	{
		Car.CurrentSpeed = Car.Speed;
		List<Actor> list = GameSettings.Instance.sActorManager.ReadyForBus.Take(Car.Capacity).ToList();
		if (list.Count > 0)
		{
			list.ForEach(delegate(Actor x)
			{
				GameSettings.Instance.sActorManager.ReadyForBus.Remove(x);
			});
		}
		Car.CanDestroy = list.Count == 0;
		for (int num = 0; num < list.Count; num++)
		{
			Actor actor = list[num];
			Car.AddOccupant(actor, true);
		}
		base.transform.position = GameSettings.Instance.BusStart;
		base.transform.rotation = Quaternion.LookRotation(GameSettings.Instance.BusDir);
	}

	public bool UseXAxis()
	{
		return Mathf.Abs(GameSettings.Instance.BusDir.x) > Mathf.Abs(GameSettings.Instance.BusDir.z);
	}

	private float GetAxisValue(Vector3 v, bool flip = false)
	{
		if (UseXAxis())
		{
			if (flip && GameSettings.Instance.BusDir.x < 0f)
			{
				return 256f - v.x;
			}
			return v.x;
		}
		if (flip && GameSettings.Instance.BusDir.z < 0f)
		{
			return 256f - v.z;
		}
		return v.z;
	}

	private Vector3 ReplaceAxisValue(Vector3 input, float v)
	{
		if (!UseXAxis())
		{
			return new Vector3(input.x, input.y, v);
		}
		return new Vector3(v, input.y, input.z);
	}

	private float GetAB(float a, float b)
	{
		if (!UseXAxis())
		{
			if (!(GameSettings.Instance.BusDir.z > 0f))
			{
				return b;
			}
			return a;
		}
		if (!(GameSettings.Instance.BusDir.x > 0f))
		{
			return b;
		}
		return a;
	}

	private void Update()
	{
		if (Car.WaitingFor.Count > 0)
		{
			_waitTimer += Time.deltaTime * GameSettings.GameSpeed;
			if (_waitTimer > 30f)
			{
				_waitTimer = 0f;
				Car.WaitingFor.Clear();
			}
			return;
		}
		_waitTimer = 0f;
		if (!SelectorController.Instance.DoneLoading || GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (Wait == -1f)
		{
			if (WaitingToFill)
			{
				if (!Input.AnyActive())
				{
					Input.Occupants.Clear();
					WaitingToFill = false;
					Wait = 1f;
				}
				else
				{
					Car.CurrentSpeed = 0f;
				}
			}
			else
			{
				float num = GetAxisValue(GameSettings.Instance.BusStopSign.transform.position) + GetAB(-2f, 2f);
				float num2 = Mathf.Clamp(GetAB(num - GetAxisValue(base.transform.position), GetAxisValue(base.transform.position) - num), 0f, 3f) / 3f;
				Car.CurrentSpeed = Car.Speed * Mathf.Max(0.01f, num2);
				if (num2 == 0f)
				{
					Car.PlaySFX(BusStopSound);
					Car.CurrentSpeed = 0f;
					Car.AudioE = false;
					base.transform.position = ReplaceAxisValue(base.transform.position, num);
					Car.BeginSpawn();
					if (GameSettings.Instance.sActorManager.ReadyForHome.Count > 0)
					{
						int num3 = 0;
						foreach (Actor item in GameSettings.Instance.sActorManager.ReadyForHome)
						{
							if (item != null)
							{
								item.CurrentPathNode = 0;
								item.PathProg = 0f;
								List<PathVector> list = Actor.PathPool.Get();
								list.Add(item.ActualPosition);
								list.Add(Input.transform.position);
								item.SetPath(list);
								Input.Occupants.Add(item);
								item.MyCar = Car;
								item.CarSpawnID = Input.ID;
								num3++;
								if (num3 == Car.Capacity)
								{
									break;
								}
							}
						}
						Input.OpenDoor();
						WaitingToFill = true;
					}
					else
					{
						Wait = 2f;
					}
				}
			}
		}
		else
		{
			if (AllOut() && Wait > 0f)
			{
				Car.CurrentSpeed = 0f;
				Wait -= Time.deltaTime * GameSettings.GameSpeed;
			}
			else if (!IsSpawning())
			{
				Car.BeginSpawn();
			}
			if (Wait <= 0f)
			{
				Input.CloseDoor();
				Car.CurrentSpeed = Mathf.Lerp(Car.CurrentSpeed, Car.Speed, Time.deltaTime * GameSettings.GameSpeed * Car.Speed);
				Car.AudioE = true;
			}
		}
		if (GetAxisValue(base.transform.position, true) > 260f)
		{
			Present = false;
			RoadManager.Instance.DestroyCar(Car);
		}
		base.transform.position = base.transform.position + base.transform.rotation * Vector3.forward * Car.CurrentSpeed * Time.deltaTime * GameSettings.GameSpeed;
	}

	public bool IsSpawning()
	{
		for (int i = 0; i < Car.SpawnPoints.Length; i++)
		{
			CarSpawn carSpawn = Car.SpawnPoints[i];
			if (!(carSpawn == Input) && carSpawn.isSpawning)
			{
				return true;
			}
		}
		return false;
	}

	public bool AllOut()
	{
		for (int i = 0; i < Car.SpawnPoints.Length; i++)
		{
			CarSpawn carSpawn = Car.SpawnPoints[i];
			if (carSpawn == Input)
			{
				continue;
			}
			foreach (Actor occupant in carSpawn.Occupants)
			{
				if (occupant != null && !occupant.isActiveAndEnabled)
				{
					return false;
				}
			}
		}
		return true;
	}

	public void Serialize(WriteDictionary dict)
	{
		dict["Wait"] = Wait;
		dict["WaitingToFill"] = WaitingToFill;
	}

	public void Deserialize(WriteDictionary dict)
	{
		Wait = dict.Get("Wait", -1f);
		WaitingToFill = dict.Get("WaitingToFill", false);
		foreach (Actor occupant in Input.Occupants)
		{
			occupant.MyCar = Car;
			occupant.CarSpawnID = Input.ID;
		}
		Present = true;
	}
}
