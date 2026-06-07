using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Subway : Landmark
{
	public static float MaxDistanceSq = 2500f;

	public static float MaxDistanceUsedSq = 22500f;

	public float SpawnWidth = 3.5f;

	public float Height = 1f;

	public Transform[] Waypoints;

	public MeshFilter GrassMesh;

	public GameObject Rend;

	private Vector3 _pos;

	public AudioSource SFX;

	protected override void Start()
	{
		base.Start();
		GameSettings.Instance.ActiveSubway = this;
		GameSettings.Instance.HasSubway = true;
		_pos = base.transform.position;
	}

	private void FixedUpdate()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			Rend.SetActive(GameSettings.Instance.ActiveFloor >= 0);
		}
	}

	public void ClearTrees()
	{
		_pos = base.transform.position;
		Rect area = GetArea().Expand(4f, 4f);
		List<TreeInstance> list = GameSettings.Instance.TreeTree.Query(area).ToList();
		for (int i = 0; i < list.Count; i++)
		{
			TreeInstance treeInstance = list[i];
			if (area.Contains(treeInstance.GetPos()))
			{
				GameSettings.Instance.RemoveTree(treeInstance);
			}
		}
	}

	public override float GetHeight()
	{
		return Height;
	}

	public override bool MakeHole()
	{
		return true;
	}

	public override string WriteName()
	{
		return "Subway";
	}

	public override Rect GetArea()
	{
		return new Rect(_pos.x - 4f, _pos.z - 4f, 8f, 8f);
	}

	public override Vector2[] GetNavMesh()
	{
		return GetArea().ToPolygon();
	}

	public override Vector2 Center()
	{
		return base.transform.position.FlattenVector3();
	}

	public override MeshFilter GetGrassMesh()
	{
		return GrassMesh;
	}

	public void SpawnActor(Actor ac)
	{
		ac.enabled = true;
		ac.SetVisible(true);
		ac.anim.enabled = true;
		ac.MeetNow();
		ac.DriveTime = SDateTime.Now();
		ac.PathProg = 0f;
		ac.CurrentPathNode = 0;
		List<PathVector> list = Actor.PathPool.Get();
		GetWaypoints(list, Random.Range(0f - SpawnWidth, SpawnWidth), false);
		ac.ActualPosition = list[0];
		ac.transform.SetPositionAndRotation(ac.ActualPosition, base.transform.rotation);
		ac.SetPath(list);
		ac.UsedSubway = true;
	}

	public void GetWaypoints(List<PathVector> input, float w, bool rev)
	{
		if (rev)
		{
			for (int num = Waypoints.Length - 1; num >= 0; num--)
			{
				input.Add(GetWaypoint(num, w));
			}
		}
		else
		{
			for (int i = 0; i < Waypoints.Length; i++)
			{
				input.Add(GetWaypoint(i, w));
			}
		}
	}

	public Vector3 GetLastWaypoint(float w)
	{
		return GetWaypoint(Waypoints.Length - 1, w);
	}

	public Vector3 GetWaypoint(int i, float w)
	{
		Transform transform = Waypoints[i];
		return transform.position + transform.right * w;
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		base.DeserializeMe(dictionary, loading, networkMode);
		Vector3 pos = (base.transform.position = dictionary.Get("Pos", SVector3.Zero));
		_pos = pos;
		base.transform.rotation = Quaternion.Euler(dictionary.Get("Rot", SVector3.Zero));
		return this;
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		base.SerializeMe(dictionary, mode, networkMode, checkDIDs);
		dictionary["Pos"] = (SVector3)base.transform.position;
		dictionary["Rot"] = (SVector3)base.transform.rotation.eulerAngles;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		for (int i = 0; i < Waypoints.Length - 1; i++)
		{
			Gizmos.DrawLine(Waypoints[i].position, Waypoints[i + 1].position);
		}
	}
}
