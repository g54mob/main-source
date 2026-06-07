using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.MultipleUnit;
using DV.PointSet;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public static class TrainCarTeleporter
{
	private static bool isTeleportingTrain;

	public static event Action TeleportSuccessfulEventBeforeCoupling;

	public static List<TrainCar> GetConnectedLocoMultipleUnitCars(TrainCar loco)
	{
		bool num = CarTypes.IsMUSteamLocomotive(loco.carType);
		bool flag = loco.rearCoupler.IsCoupled() && CarTypes.IsTender(loco.rearCoupler.coupledTo.train.carLivery);
		if (num && flag)
		{
			return new List<TrainCar>
			{
				loco.rearCoupler.coupledTo.train,
				loco
			};
		}
		if (loco.IsMultipleUnit)
		{
			List<TrainCar> list = GetCoupledAndMUConnectedCars(loco, frontDireciton: true);
			List<TrainCar> list2 = GetCoupledAndMUConnectedCars(loco, frontDireciton: false);
			if (list != null || list2 != null)
			{
				List<TrainCar> list3 = new List<TrainCar>();
				if (list2 != null)
				{
					list2.Reverse();
					list3.AddRange(list2);
				}
				list3.Add(loco);
				if (list != null)
				{
					list3.AddRange(list);
				}
				return list3;
			}
		}
		return null;
		List<TrainCar> GetCoupledAndMUConnectedCars(TrainCar car, bool frontDireciton)
		{
			List<TrainCar> list4 = null;
			Coupler coupler = (frontDireciton ? car.frontCoupler : car.rearCoupler);
			while (coupler.train.IsMultipleUnit)
			{
				Coupler coupledTo = coupler.coupledTo;
				if (coupledTo == null)
				{
					break;
				}
				TrainCar train = coupledTo.train;
				MultipleUnitModule muModule = coupler.train.muModule;
				MultipleUnitCable multipleUnitCable = (coupler.isFrontCoupler ? muModule.frontCableAdapter.muCable.connectedTo : muModule.rearCableAdapter.muCable.connectedTo);
				if (multipleUnitCable == null)
				{
					break;
				}
				TrainCar train2 = multipleUnitCable.muModule.train;
				if (!(train2 == train))
				{
					break;
				}
				if (list4 == null)
				{
					list4 = new List<TrainCar>();
				}
				list4.Add(train2);
				coupler = coupledTo.GetOppositeCoupler();
			}
			return list4;
		}
	}

	public static IEnumerator TeleportTrainset(List<TrainCar> carsToTeleport, Vector3 target, bool forceRegularDirection = false)
	{
		if (isTeleportingTrain)
		{
			Debug.LogError("Cannot teleport train, because another teleport is already in progress");
			yield break;
		}
		RailTrack[] allTracks = SingletonBehaviour<RailTrackRegistryBase>.Instance.AllTracks;
		if (allTracks.Length == 0)
		{
			Debug.LogError("Cannot teleport train, there are no tracks in the world!");
			yield break;
		}
		if (carsToTeleport == null || carsToTeleport.Count == 0 || carsToTeleport.Any((TrainCar car) => car == null || car.derailed))
		{
			Debug.LogError("carsToTeleport is null/empty or one of the cars is derailed! Aborting fast travel");
			yield break;
		}
		isTeleportingTrain = true;
		bool[] reversedDirection = new bool[carsToTeleport.Count];
		if (!forceRegularDirection && carsToTeleport.Count > 1)
		{
			for (int num = 0; num < reversedDirection.Length; num++)
			{
				if (num < reversedDirection.Length - 1)
				{
					Coupler coupledTo = carsToTeleport[num].frontCoupler.coupledTo;
					reversedDirection[num] = coupledTo == null || coupledTo.train != carsToTeleport[num + 1];
				}
				else
				{
					Coupler coupledTo2 = carsToTeleport[num].rearCoupler.coupledTo;
					reversedDirection[num] = coupledTo2 == null || coupledTo2.train != carsToTeleport[num - 1];
				}
			}
		}
		foreach (TrainCar item in carsToTeleport)
		{
			item.UncoupleSelf(playAudio: false);
			MultipleUnitModule.DisconnectCablesIfMultipleUnitSupported(item);
		}
		yield return WaitFor.FixedUpdate;
		float num2 = 0.1f;
		HashSet<RailTrack> hashSet = new HashSet<RailTrack>(allTracks);
		List<(RailTrack, EquiPointSet.Point)> list = new List<(RailTrack, EquiPointSet.Point)>();
		bool flag = false;
		GameObject gameObject = new GameObject("TrainsTeleportHelper");
		gameObject.SetLayersRecursive("Train_Big_Collider");
		BoxCollider[] array = new BoxCollider[carsToTeleport.Count];
		for (int num3 = 0; num3 < array.Length; num3++)
		{
			GameObject gameObject2 = new GameObject($"c{num3}");
			gameObject2.SetLayersRecursive("Train_Big_Collider");
			BoxCollider boxCollider = gameObject2.AddComponent<BoxCollider>();
			boxCollider.size = carsToTeleport[num3].Bounds.size;
			array[num3] = boxCollider;
			gameObject2.SetActive(value: false);
			gameObject2.transform.SetParent(gameObject.transform);
		}
		List<EquiPointSet.Point> list2 = new List<EquiPointSet.Point>();
		do
		{
			list.Clear();
			foreach (RailTrack item2 in hashSet)
			{
				EquiPointSet.Point? pointWithinRangeWithYOffset = RailTrack.GetPointWithinRangeWithYOffset(item2, target, num2);
				if (pointWithinRangeWithYOffset.HasValue)
				{
					list.Add((item2, pointWithinRangeWithYOffset.Value));
				}
			}
			foreach (var item3 in list)
			{
				EquiPointSet.Point[] points = item3.Item1.GetKinkedPointSet().points;
				int index = item3.Item2.index;
				int num4 = index;
				bool flag2 = true;
				int num5 = 0;
				while (true)
				{
					for (int num6 = 0; num6 < carsToTeleport.Count; num6++)
					{
						Vector3 extents = carsToTeleport[num6].Bounds.extents;
						EquiPointSet.Point? point = CarSpawner.FindValidPointInOneDirectionForCarStartingFromIndex(points, num4, extents, forwardDirection: true);
						if (!point.HasValue)
						{
							break;
						}
						list2.Add(point.Value);
						Vector3 forward = point.Value.forward;
						Vector3 vector = (Vector3)point.Value.position + WorldMover.currentMove;
						array[num6].transform.SetPositionAndRotation(vector, Quaternion.LookRotation(forward));
						array[num6].gameObject.SetActive(value: true);
						num4 = point.Value.index;
						if (num6 > 0)
						{
							Vector3 vector2 = vector - forward * extents.z;
							EquiPointSet.Point point2 = list2[num6 - 1];
							Vector3 forward2 = point2.forward;
							Vector3 vector3 = (Vector3)point2.position + WorldMover.currentMove + forward2 * carsToTeleport[num6 - 1].Bounds.extents.z;
							if (Vector3.SqrMagnitude(vector2 - vector3) > 0.5f)
							{
								break;
							}
						}
						if (num6 == carsToTeleport.Count - 1)
						{
							flag = true;
						}
					}
					if (flag)
					{
						gameObject.SetActive(value: false);
						UnityEngine.Object.Destroy(gameObject);
						for (int num7 = 0; num7 < carsToTeleport.Count; num7++)
						{
							Vector3 vector4 = list2[num7].forward;
							if (reversedDirection[num7])
							{
								vector4 = -vector4;
							}
							Vector3 worldPos = (Vector3)list2[num7].position + WorldMover.currentMove;
							carsToTeleport[num7].MoveToTrack(item3.Item1, worldPos, vector4);
							carsToTeleport[num7].GetComponent<TrainCarInteriorPhysics>()?.SyncPosition();
						}
						Physics.SyncTransforms();
						TrainCarTeleporter.TeleportSuccessfulEventBeforeCoupling?.Invoke();
						for (int num8 = 1; num8 < carsToTeleport.Count; num8++)
						{
							Coupler coupler = (reversedDirection[num8] ? carsToTeleport[num8].frontCoupler : carsToTeleport[num8].rearCoupler);
							coupler.TryCouple(playAudio: false);
							if (coupler.IsCoupled() && coupler.coupledTo.train == carsToTeleport[num8 - 1])
							{
								MultipleUnitModule.ConnectCablesOfConnectedCouplersIfMultipleUnitSupported(coupler, coupler.coupledTo);
							}
							else
							{
								Debug.LogError("Unexpected error, cars weren't properly coupled!", carsToTeleport[num8]);
							}
						}
						isTeleportingTrain = false;
						yield break;
					}
					list2.Clear();
					BoxCollider[] array2 = array;
					for (int num9 = 0; num9 < array2.Length; num9++)
					{
						array2[num9].gameObject.SetActive(value: false);
					}
					if (flag2 && num4 >= points.Length - 1)
					{
						flag2 = false;
					}
					if (!flag2 && index - num5 == 0)
					{
						break;
					}
					if (flag2)
					{
						num4++;
						continue;
					}
					num5++;
					num4 = index - num5;
				}
				hashSet.Remove(item3.Item1);
			}
			num2 += 5f;
		}
		while (!(num2 > 2000f));
		Debug.LogError("Couldn't find place to teleport in radius of 2000m!");
		gameObject.SetActive(value: false);
		UnityEngine.Object.Destroy(gameObject);
		isTeleportingTrain = false;
	}

	public static IEnumerator TeleportTrainNew(TrainCar carToTeleport, Vector3 target)
	{
		if (isTeleportingTrain)
		{
			Debug.LogError("Cannot teleport train, because another teleport is already in progress");
			yield break;
		}
		RailTrack[] allTracks = SingletonBehaviour<RailTrackRegistryBase>.Instance.AllTracks;
		if (allTracks.Length == 0)
		{
			Debug.LogError("Cannot teleport train, there are no tracks in the world!");
			yield break;
		}
		if (carToTeleport == null || carToTeleport.derailed)
		{
			Debug.LogError("carToTeleport is " + ((carToTeleport == null) ? "null" : "derailed") + "! Aborting fast travel");
			yield break;
		}
		isTeleportingTrain = true;
		carToTeleport.UncoupleSelf(playAudio: false);
		MultipleUnitModule.DisconnectCablesIfMultipleUnitSupported(carToTeleport);
		yield return WaitFor.FixedUpdate;
		(RailTrack, EquiPointSet.Point)? pointOnClosestAvailableTrackForCar = CarSpawner.GetPointOnClosestAvailableTrackForCar(target, carToTeleport.Bounds.extents, allTracks, 5f, 10f, 2000f);
		if (!pointOnClosestAvailableTrackForCar.HasValue)
		{
			Debug.LogError("Couldn't find place to teleport in radius of 2000m!");
			isTeleportingTrain = false;
			yield break;
		}
		EquiPointSet.Point item = pointOnClosestAvailableTrackForCar.Value.Item2;
		RailTrack item2 = pointOnClosestAvailableTrackForCar.Value.Item1;
		Vector3 forward = item.forward;
		Vector3 worldPos = (Vector3)item.position + WorldMover.currentMove;
		carToTeleport.MoveToTrack(item2, worldPos, forward);
		carToTeleport.GetComponent<TrainCarInteriorPhysics>()?.SyncPosition();
		isTeleportingTrain = false;
	}
}
