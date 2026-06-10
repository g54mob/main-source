using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class PipeConstructor : MonoBehaviour
{
	[Serializable]
	public class PipeSetup
	{
		public PipeType type;

		public Material material;

		public List<GameObject> models;
	}

	public enum PipeType
	{
		wire = 0,
		wire2 = 1
	}

	[Serializable]
	public class PipeGroup
	{
		public int type;

		public List<PipeRoute> routes;

		public List<int> rooms;

		[NonSerialized]
		public GameObject spawned;

		[NonSerialized]
		public bool isVisible;

		public PipeGroup(PipeType newType)
		{
		}

		public void AddPipeRoute(NewWall from, NewWall to, int sourceIndex, int endIndex)
		{
		}

		public void AddPipeRoute(NewWall from, NewWall to, int[] sourceIndex, int[] endIndex)
		{
		}

		public void AddToRoomsAsReferences()
		{
		}

		public void SetVisible(bool val)
		{
		}

		public void Spawn()
		{
		}

		public bool TryGetWall(int input, out NewWall output)
		{
			output = null;
			return false;
		}
	}

	[Serializable]
	public class PipeRoute
	{
		public int w;

		public List<int> s;
	}

	[Header("Components")]
	public List<PipeSetup> pipeConfig;

	[Header("Generated")]
	public List<PipeGroup> generated;

	public int debugGetWall1;

	public int debugGetWall2;

	private static PipeConstructor _instance;

	public static PipeConstructor Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public List<NewWall> WallPathfind(NewWall from, NewWall to, PipeGroup existingGroup)
	{
		return null;
	}

	public bool IsLeftOf(NewWall one, NewWall two)
	{
		return false;
	}

	public bool IsRightOf(NewWall one, NewWall two)
	{
		return false;
	}

	public bool IsFrontOf(NewWall one, NewWall two)
	{
		return false;
	}

	public void GeneratePipes()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GetWall()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void LeftRightCheck()
	{
	}
}
