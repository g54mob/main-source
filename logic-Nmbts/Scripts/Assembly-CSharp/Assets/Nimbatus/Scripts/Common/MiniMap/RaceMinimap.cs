using System.Linq;
using Assets.Nimbatus.Scripts.GalaxyMap.Race;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.MiniMap
{
	public class RaceMinimap : BaseSingleton<RaceMinimap>
	{
		public GameObject PlayerMapObject;

		public GameObject Track;

		public Mesh TrackMesh;

		public float SplineScale = 0.1f;

		public Transform Background;

		public GameObject FinishPrefab;

		public GameObject AcceleratorPrefab;

		public GameObject DeceleratorPrefab;

		public Material DamagefieldMaterial;

		private GameObject _player;

		private Vector3 _lastPos;

		private GameObject _splineObj;

		private Spline _spline;

		public void Init(NimbatusDrone drone)
		{
			_player = drone.RootDronePart.gameObject;
			RaceTrack selectedTrack = BaseSingleton<RaceTrackManager>.Instance.SelectedTrack;
			RaceSpline mainSpline = selectedTrack.MainSpline;
			_splineObj = new GameObject("MinimapTrack", typeof(Spline));
			_splineObj.transform.parent = Background;
			_splineObj.transform.localPosition = Vector3.zero;
			_spline = _splineObj.GetComponent<Spline>();
			_spline.ResetFully();
			Vector3 vector = Vector3.zero - mainSpline.nodes[0].position + mainSpline.nodes[0].position * SplineScale;
			vector += selectedTrack.transform.position * SplineScale;
			for (int i = 0; i < mainSpline.nodes.Count; i++)
			{
				Vector3 vector2 = mainSpline.nodes[i].position - mainSpline.nodes[0].position;
				Vector3 vector3 = mainSpline.nodes[0].position + vector2 * SplineScale + vector;
				Vector3 vector4 = mainSpline.nodes[i].direction - mainSpline.nodes[i].position;
				Vector3 direction = vector3 + vector4 * SplineScale;
				_spline.AddNode(new SplineNode(vector3, direction));
			}
			Mesh mesh = ((TrackMesh != null) ? TrackMesh : Track.GetComponent<MeshFilter>().sharedMesh);
			CreateMesh(_spline, mesh, Track.GetComponent<MeshRenderer>().sharedMaterial, _splineObj.transform, selectedTrack);
			Track.SetActive(false);
			RaceCheckpoint raceCheckpoint = selectedTrack.Checkpoints[selectedTrack.Checkpoints.Count - 1];
			PlacePrefab(raceCheckpoint.gameObject, FinishPrefab);
			if (!selectedTrack.MainSpline.Loop)
			{
				RaceCheckpoint raceCheckpoint2 = selectedTrack.Checkpoints[0];
				PlacePrefab(raceCheckpoint2.gameObject, FinishPrefab);
			}
			RaceBooster[] componentsInChildren = selectedTrack.GetComponentsInChildren<RaceBooster>();
			foreach (RaceBooster item in componentsInChildren.Where((RaceBooster l) => l.BoostMode == EBoostModes.Forward || l.BoostMode == EBoostModes.BoostThrusters))
			{
				PlacePrefab(item.gameObject, AcceleratorPrefab);
			}
			foreach (RaceBooster item2 in componentsInChildren.Where((RaceBooster l) => l.BoostMode == EBoostModes.Backward || l.BoostMode == EBoostModes.SlowDown))
			{
				PlacePrefab(item2.gameObject, DeceleratorPrefab);
			}
			DamagingFieldBendy[] componentsInChildren2 = selectedTrack.GetComponentsInChildren<DamagingFieldBendy>();
			foreach (DamagingFieldBendy damagingFieldBendy in componentsInChildren2)
			{
				Spline spline = new GameObject("DamageFieldMinimap").AddComponent<Spline>();
				spline.transform.parent = _spline.transform;
				spline.transform.localPosition = (damagingFieldBendy.transform.position - Vector3.zero) * SplineScale;
				spline.transform.localScale = Vector3.one;
				spline.ResetFully();
				for (int num2 = 0; num2 < damagingFieldBendy.OwnSpline.nodes.Count; num2++)
				{
					Vector3 vector5 = damagingFieldBendy.OwnSpline.nodes[num2].position - Vector3.zero;
					Vector3 vector6 = Vector3.zero + vector5 * SplineScale;
					Vector3 vector7 = damagingFieldBendy.OwnSpline.nodes[num2].direction - damagingFieldBendy.OwnSpline.nodes[num2].position;
					Vector3 direction2 = vector6 + vector7 * SplineScale;
					spline.AddNode(new SplineNode(vector6, direction2));
				}
				spline.transform.localPosition = new Vector3(spline.transform.localPosition.x, spline.transform.localPosition.y, -1f);
				CreateMesh(spline, damagingFieldBendy.TextureMesh, DamagefieldMaterial, spline.transform, null, damagingFieldBendy.ScaleX * SplineScale);
			}
			_lastPos = _player.transform.position;
		}

		public void Update()
		{
			PlayerMapObject.transform.rotation = _player.transform.rotation;
			Vector3 vector = _lastPos - _player.transform.position;
			_splineObj.transform.position += vector.normalized * (vector.magnitude * SplineScale);
			_lastPos = _player.transform.position;
		}

		private void CreateMesh(Spline spl, Mesh mesh, Material mat, Transform parent, RaceTrack track, float customScale = 0f)
		{
			for (int i = 0; i < spl.GetCurves().Count; i++)
			{
				GameObject obj = new GameObject("MapTrackPart", typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshBender));
				obj.layer = 10;
				obj.transform.parent = parent;
				obj.transform.localRotation = Quaternion.identity;
				obj.transform.localPosition = Vector3.zero;
				obj.transform.localScale = Vector3.one;
				obj.hideFlags = HideFlags.NotEditable;
				obj.hideFlags = HideFlags.DontSave;
				obj.GetComponent<MeshRenderer>().material = mat;
				float scale = ((track != null) ? (track.Scale * SplineScale * track.MainSpline.NodeSettings[i].Width) : customScale);
				float scale2 = ((track != null) ? (track.Scale * SplineScale * track.MainSpline.NodeSettings[i + 1].Width) : customScale);
				MeshBender component = obj.GetComponent<MeshBender>();
				component.SetSourceMesh(mesh, false);
				component.SetRotation(Quaternion.identity, false);
				component.SetCurve(spl.curves[i], false);
				component.SetStartScale(scale, false);
				component.SetEndScale(scale2);
			}
		}

		private void PlacePrefab(GameObject sourceObj, GameObject prefab)
		{
			Vector3 vector = sourceObj.transform.position - Vector3.zero;
			Vector3 localPosition = new Vector3(0f, 0f, -1f) + vector * SplineScale;
			GameObject obj = Object.Instantiate(prefab);
			obj.layer = 10;
			obj.transform.parent = _splineObj.transform;
			obj.transform.localPosition = localPosition;
			obj.transform.localRotation = sourceObj.transform.rotation;
			obj.transform.localScale = prefab.transform.localScale / 500f;
		}
	}
}
