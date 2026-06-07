using System;
using System.Collections.Generic;
using UnityEngine;

public class ParkingDetector : MonoBehaviour
{
	public bool partialMatch;

	private HashSet<TrainCar> desiredCars = new HashSet<TrainCar>();

	private HashSet<TrainCar> carsInside = new HashSet<TrainCar>();

	private HashSet<TrainCar> carsParked = new HashSet<TrainCar>();

	private HashSet<TrainCar> carsDerailed = new HashSet<TrainCar>();

	private BoxCollider myBoxCollider;

	private Vector3 boxAA;

	private Vector3 boxBB;

	private readonly Vector3[] carPoints = new Vector3[3];

	public bool IsCarParked => carsParked.Count > 0;

	public bool IsCarInside => carsInside.Count > 0;

	public event Action<TrainCar> CarParked;

	public event Action<TrainCar> CarUnparked;

	public event Action<TrainCar, bool> CarEnteredParkingZone;

	public event Action<TrainCar, bool> CarExitedParkingZone;

	private void Awake()
	{
		myBoxCollider = GetComponent<BoxCollider>();
		boxAA = myBoxCollider.center - myBoxCollider.size * 0.5f;
		boxBB = myBoxCollider.center + myBoxCollider.size * 0.5f;
	}

	public void Clear()
	{
		desiredCars.Clear();
		carsInside.Clear();
		carsParked.Clear();
		carsDerailed.Clear();
	}

	public void AddDesiredCar(TrainCar car)
	{
		if (desiredCars.Add(car))
		{
			CheckCar(car);
		}
	}

	private void CheckCars()
	{
		if (desiredCars.RemoveWhere((TrainCar c) => c == null) > 0)
		{
			carsInside.RemoveWhere((TrainCar c) => c == null);
			carsParked.RemoveWhere((TrainCar c) => c == null);
		}
		foreach (TrainCar desiredCar in desiredCars)
		{
			CheckCar(desiredCar);
		}
	}

	private void CheckCar(TrainCar car)
	{
		if (!car.derailed)
		{
			carsDerailed.Remove(car);
		}
		if (car.derailed && carsDerailed.Add(car))
		{
			if (carsParked.Remove(car))
			{
				this.CarUnparked?.Invoke(car);
			}
			if (carsInside.Remove(car))
			{
				this.CarExitedParkingZone?.Invoke(car, arg2: false);
			}
		}
		if (car.derailed)
		{
			return;
		}
		Bounds bounds = car.Bounds;
		carPoints[0] = car.transform.TransformPoint(bounds.center + new Vector3(0f, 0f, 0f - bounds.extents.z));
		carPoints[1] = car.transform.TransformPoint(bounds.center);
		carPoints[2] = car.transform.TransformPoint(bounds.center + new Vector3(0f, 0f, bounds.extents.z));
		int num = 0;
		for (int i = 0; i < 3; i++)
		{
			carPoints[i] = base.transform.InverseTransformPoint(carPoints[i]);
			if (boxAA.x <= carPoints[i].x && carPoints[i].x <= boxBB.x && boxAA.y <= carPoints[i].y && carPoints[i].y <= boxBB.y && boxAA.z <= carPoints[i].z && carPoints[i].z <= boxBB.z)
			{
				num++;
			}
		}
		bool flag = (partialMatch ? (num > 0) : (num == 3));
		if (flag && carsInside.Add(car))
		{
			this.CarEnteredParkingZone?.Invoke(car, carPoints[1].z > 0f);
		}
		else if (!flag && carsInside.Remove(car))
		{
			this.CarExitedParkingZone?.Invoke(car, carPoints[1].z > 0f);
		}
		if (flag)
		{
			if (Mathf.Abs(car.GetForwardSpeed()) < 0.1f && carsParked.Add(car))
			{
				this.CarParked?.Invoke(car);
			}
			else if (Mathf.Abs(car.GetForwardSpeed()) >= 0.1f && carsParked.Remove(car))
			{
				this.CarUnparked?.Invoke(car);
			}
		}
	}

	private void OnEnable()
	{
		CheckCars();
	}

	private void Update()
	{
		CheckCars();
	}

	public void CheckNow()
	{
		CheckCars();
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.magenta;
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.DrawWireCube((boxAA + boxBB) * 0.5f, boxBB - boxAA);
		foreach (TrainCar desiredCar in desiredCars)
		{
			bool flag = carsInside.Contains(desiredCar);
			bool flag2 = carsParked.Contains(desiredCar);
			if (flag && flag2)
			{
				Gizmos.color = Color.green;
			}
			else if (flag)
			{
				Gizmos.color = Color.blue;
			}
			else
			{
				Gizmos.color = Color.red;
			}
			Bounds bounds = desiredCar.Bounds;
			Gizmos.matrix = desiredCar.transform.localToWorldMatrix;
			Gizmos.DrawWireCube(bounds.center, bounds.size);
			Gizmos.matrix = base.transform.localToWorldMatrix;
			carPoints[0] = desiredCar.transform.TransformPoint(bounds.center + new Vector3(0f, 0f, 0f - bounds.extents.z));
			carPoints[1] = desiredCar.transform.TransformPoint(bounds.center);
			carPoints[2] = desiredCar.transform.TransformPoint(bounds.center + new Vector3(0f, 0f, bounds.extents.z));
			for (int i = 0; i < 3; i++)
			{
				carPoints[i] = base.transform.InverseTransformPoint(carPoints[i]);
				if (boxAA.x <= carPoints[i].x && carPoints[i].x <= boxBB.x && boxAA.y <= carPoints[i].y && carPoints[i].y <= boxBB.y && boxAA.z <= carPoints[i].z && carPoints[i].z <= boxBB.z)
				{
					Gizmos.color = Color.green;
				}
				else
				{
					Gizmos.color = Color.red;
				}
				Gizmos.DrawSphere(carPoints[i], 0.1f);
			}
		}
	}
}
