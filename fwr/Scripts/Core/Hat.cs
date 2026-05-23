using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hat
{
	private static Dictionary<string, Type> hatTypes;

	public HatSO hatSO { get; private set; }

	public Simulation sim { get; private set; }

	public Drone drone { get; private set; }

	public virtual int OnMove(Vector2Int oldPos, Vector2Int newPos, ProgramState programState)
	{
		return -1;
	}

	public virtual void OnUnequip()
	{
	}

	public virtual void OnEquip(Drone drone, ProgramState programState)
	{
	}

	public static Hat CreateHat(HatSO hatType, Simulation sim, Drone drone)
	{
		if (hatTypes == null)
		{
			hatTypes = (from type in typeof(Hat).Assembly.GetTypes()
				where type.IsSubclassOf(typeof(Hat)) || type == typeof(Hat)
				select type).ToDictionary((Type t) => t.Name, (Type t) => t);
		}
		Hat obj = (Hat)Activator.CreateInstance(hatTypes[hatType.className]);
		obj.hatSO = hatType;
		obj.sim = sim;
		obj.drone = drone;
		return obj;
	}
}
