using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Characters.Player;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race.Obstacle
{
	public class RaceObstacleCourseManager : BaseRaceManager
	{
		[Header("Obstacle Course Manager")]
		public NimbatusPlayer Player;

		public List<RaceSpline> TrackParts = new List<RaceSpline>();

		public int Seed = 50;

		public int InitialParts;

		[Header("Track")]
		public Mesh TrackMesh;

		public Material TrackMaterial;

		public float TrackScale = 5f;

		public Mesh KerbMesh;

		public Material KerbMaterial;

		public float KerbScale = 1f;

		public PhysicMaterial KerbPhysicMaterial;

		private System.Random _random;

		private RaceSpline _masterSpline;

		private Transform _trackContainer;

		private float _lastPositionAlongSpline;

		private float _nextLength;

		public void Start()
		{
			_random = new System.Random(Seed);
			_masterSpline = GetNextPart();
			_masterSpline.gameObject.name = "TrackMaster";
			_trackContainer = new GameObject("TrackParts").transform;
			_trackContainer.parent = _masterSpline.transform;
			_trackContainer.localPosition = Vector3.zero;
			for (int i = 0; i < InitialParts; i++)
			{
				RaceSpline nextPart = GetNextPart();
				AppendPart(nextPart);
			}
			GenerateTrack(_masterSpline, 0, _masterSpline.curves.Count - 2);
			Player.Drone.TrackerManager.Init(Player.Drone, _masterSpline);
		}

		public override void OnRaceStarted()
		{
			_lastPositionAlongSpline = Player.Drone.TrackerManager.GetDroneBrainPosition();
		}

		public override void Update()
		{
			if (!Application.isEditor)
			{
				foreach (RaceSpline trackPart in TrackParts)
				{
					GenerateTrack(trackPart, 0, trackPart.curves.Count - 1);
				}
				return;
			}
			base.Update();
			if (RaceRunning)
			{
				float droneBrainPosition = Player.Drone.TrackerManager.GetDroneBrainPosition();
				if (droneBrainPosition >= _lastPositionAlongSpline + _nextLength)
				{
					_lastPositionAlongSpline = droneBrainPosition;
					RaceSpline nextPart = GetNextPart();
					AppendPart(nextPart);
					GenerateTrack(_masterSpline, _masterSpline.curves.Count - nextPart.curves.Count - 2, _masterSpline.curves.Count - 2);
				}
			}
		}

		private RaceSpline GetNextPart()
		{
			int index = _random.Next(TrackParts.Count);
			RaceSpline raceSpline = TrackParts[index];
			return UnityEngine.Object.Instantiate(raceSpline, raceSpline.transform.position, raceSpline.transform.rotation);
		}

		private void AppendPart(RaceSpline part)
		{
			Vector3 tangent = _masterSpline.nodes[_masterSpline.nodes.Count - 1].direction - _masterSpline.nodes[_masterSpline.nodes.Count - 1].position;
			float num = tangent.magnitude * 2f;
			Vector3 position = _masterSpline.nodes[_masterSpline.nodes.Count - 1].position + tangent.normalized * num;
			if (_random.Next(2) == 0)
			{
				part.transform.localScale = new Vector3(1f, -1f, 1f);
			}
			part.transform.position = position;
			part.transform.rotation = CubicBezierCurve.GetRotationFromTangent(tangent) * Quaternion.Euler(90f, 0f, 90f);
			part.nodes[0].direction = part.nodes[0].direction.normalized * (num / 3f);
			foreach (SplineNode node2 in part.nodes)
			{
				Vector3 worldPositionOfNode = part.GetWorldPositionOfNode(node2);
				Vector3 worldDirectionOfNode = part.GetWorldDirectionOfNode(node2);
				SplineNode node = new SplineNode(worldPositionOfNode, worldDirectionOfNode);
				_masterSpline.AddNode(node);
				_masterSpline.UpdateNodeSettings();
				_masterSpline.NodeSettings[_masterSpline.NodeSettings.Count - 1] = part.NodeSettings[part.nodes.IndexOf(node2)];
			}
			_nextLength = part.Length + _masterSpline.curves[_masterSpline.curves.Count - 1 - part.curves.Count].Length;
			UnityEngine.Object.Destroy(part.gameObject);
		}

		private void GenerateTrack(RaceSpline spline, int from, int to)
		{
			List<CubicBezierCurve> list = new List<CubicBezierCurve>();
			for (int i = from; i <= to; i++)
			{
				list.Add(spline.curves[i]);
			}
			for (int j = 0; j < list.Count; j++)
			{
				float num = TrackScale * spline.NodeSettings[j].Width;
				Material material = TrackMaterial;
				if (spline.NodeSettings[j].NextSegmentMaterial != null)
				{
					material = spline.NodeSettings[j].NextSegmentMaterial;
				}
				Material material2 = KerbMaterial;
				if (spline.NodeSettings[j].NextSegmentKerbMaterial != null)
				{
					material2 = spline.NodeSettings[j].NextSegmentKerbMaterial;
				}
				float num2 = spline.NodeSettings[j].Offset / (TrackScale / KerbScale);
				float num3 = num / 2f / KerbScale + 0.5f;
				CreateMeshes(list[j], TrackMesh, material, num, j, num2);
				if (spline.NodeSettings[j].KerbRight)
				{
					CreateMeshes(list[j], KerbMesh, material2, KerbScale, j, num3 + num2, true);
				}
				if (spline.NodeSettings[j].KerbLeft)
				{
					CreateMeshes(list[j], KerbMesh, material2, KerbScale, j, 0f - num3 + num2, true);
				}
			}
		}

		private void CreateMeshes(CubicBezierCurve curve, Mesh mesh, Material material, float scale, int index, float offset, bool isKerb = false)
		{
			int num = 0;
			GameObject gameObject;
			if (!isKerb)
			{
				gameObject = new GameObject("Track" + num++, typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshBender));
				gameObject.transform.parent = _trackContainer;
				gameObject.transform.localPosition = new Vector3(0f, 0f, 10f);
			}
			else
			{
				gameObject = new GameObject("Kerb" + num++, typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshBender), typeof(MeshCollider));
				gameObject.transform.parent = _trackContainer;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.layer = 8;
				if (KerbPhysicMaterial != null)
				{
					gameObject.GetComponent<Collider>().material = KerbPhysicMaterial;
				}
			}
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = Vector3.one;
			gameObject.hideFlags = HideFlags.NotEditable;
			gameObject.hideFlags = HideFlags.DontSave;
			gameObject.GetComponent<MeshRenderer>().material = material;
			float scale2 = scale;
			if (!isKerb)
			{
				scale2 = _masterSpline.NodeSettings[index + 1].Width * TrackScale;
			}
			float y;
			float y2;
			if (isKerb)
			{
				int num2 = ((offset > 0f) ? 1 : (-1));
				y = (_masterSpline.NodeSettings[index].Width * TrackScale / 2f / KerbScale + 0.5f) * (float)num2 + _masterSpline.NodeSettings[index].Offset * _masterSpline.NodeSettings[index].Width;
				y2 = (_masterSpline.NodeSettings[index + 1].Width * TrackScale / 2f / KerbScale + 0.5f) * (float)num2 + _masterSpline.NodeSettings[index + 1].Offset * _masterSpline.NodeSettings[index + 1].Width;
			}
			else
			{
				y = offset;
				y2 = _masterSpline.NodeSettings[index + 1].Offset / (TrackScale / KerbScale);
			}
			MeshBender component = gameObject.GetComponent<MeshBender>();
			component.SetSourceMesh(mesh, false);
			if (!isKerb || offset > 0f)
			{
				component.SetRotation(Quaternion.Euler(Vector3.zero), false);
			}
			else
			{
				component.SetRotation(Quaternion.Euler(180f, 0f, 0f), false);
			}
			component.SetTranslation(new Vector3(0f, y, 0f), false);
			component.SetEndTranslation(new Vector3(0f, y2, 0f), false);
			component.SetStartScale(scale, false);
			component.SetEndScale(scale2, false);
			component.SetCurve(curve);
		}
	}
}
