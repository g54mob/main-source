using System;
using System.Collections.Generic;
using UnityEngine;

public static class DroneCharacteristics
{
	public static void Assign(IDrone drone, bool fleetDrone, List<IDrone> otherDroneList, System.Random rnd)
	{
		string empty = string.Empty;
		if (!fleetDrone)
		{
			DroneManager instance = DroneManager.Instance;
			do
			{
				empty = DroneNameGenerator.Next();
			}
			while (FastFleetNameCheck(empty));
		}
		else
		{
			empty = DroneNameGenerator.Next();
		}
		drone.DroneName = empty;
		drone.OriginalSpeed = GetRandomOriginalSpeedForDrone(rnd);
		drone.OverrideTotalHitpoints(GetRandomHitpointsForDrone(rnd));
		if (UnityEngine.Random.Range(0, 100) < 20)
		{
			drone.DroneVisualIndex = rnd.Next(4, 6);
		}
		else
		{
			drone.DroneVisualIndex = rnd.Next(0, 4);
		}
		if (otherDroneList != null)
		{
			while (FastVisualIndexCheck(otherDroneList, drone.DroneVisualIndex))
			{
				if (UnityEngine.Random.Range(0, 100) < 20)
				{
					drone.DroneVisualIndex = rnd.Next(4, 6);
				}
				else
				{
					drone.DroneVisualIndex = rnd.Next(0, 4);
				}
			}
		}
		if (GlobalSettings.IsTutorial)
		{
			switch (drone.DroneNumber)
			{
			case 1:
				drone.DroneVisualIndex = 0;
				break;
			case 2:
				drone.DroneVisualIndex = 3;
				break;
			}
		}
	}

	private static bool FastFleetNameCheck(string name)
	{
		int count = DroneManager.Instance.dronesList.Count;
		int length = name.Length;
		for (int i = 0; i < count; i++)
		{
			Drone drone = DroneManager.Instance.dronesList[i];
			if (drone != null && drone.DroneName.Length == length && drone.DroneName[0] == name[0] && drone.DroneName == name)
			{
				return true;
			}
		}
		return false;
	}

	private static bool FastVisualIndexCheck(List<IDrone> otherDroneList, int visualIndex)
	{
		int count = otherDroneList.Count;
		for (int i = 0; i < count; i++)
		{
			if (otherDroneList[i].DroneVisualIndex == visualIndex)
			{
				return true;
			}
		}
		return false;
	}

	private static float GetRandomOriginalSpeedForDrone(System.Random rnd)
	{
		int num = 0;
		float num2 = 1f;
		float num3 = 0.1f;
		int num4 = 0;
		num4 = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? UnityEngine.Random.Range(-num, num + 1) : rnd.Next(-num, num + 1));
		return num2 + (float)num4 * num3;
	}

	private static float GetRandomHitpointsForDrone(System.Random rnd)
	{
		int num = 30;
		int num2 = 10;
		float num3 = 100f;
		int num4 = num / num2;
		int num5 = 0;
		num5 = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? UnityEngine.Random.Range(-num4, num4 + 1) : rnd.Next(-num4, num4 + 1));
		return num3 + (float)(num5 * num2);
	}
}
