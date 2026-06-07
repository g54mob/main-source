using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Leaderboards;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race
{
	[SelectionBase]
	[ExecuteInEditMode]
	[RequireComponent(typeof(RaceSpline))]
	public class RaceTrack : MonoBehaviour
	{
		public class RoadsideObject
		{
			public GameObject Object;

			public float StartOffset;

			public float Spacing = 20f;

			public float MinDistance;

			public float Width = 100f;
		}

		public TranslationTerm Name;

		public TranslationTerm Description;

		public Texture2D PreviewImage;

		public Texture2D Logo;

		public Color Color;

		public ELeaderboard Leaderboard;

		public ELeaderboard AutonomousLeaderboard;

		public EAirResistance AirResistance;

		public EGravity Gravity;

		public int Layer = 11;

		[Header("Track")]
		public Mesh Mesh;

		public Material Material;

		public float Scale = 5f;

		public EUvStretchMode TrackUvMode = EUvStretchMode.SeamlessStretch;

		[Header("Kerbs")]
		public Mesh KerbMesh;

		public Material KerbMaterial;

		public float KerbScale = 1f;

		public PhysicMaterial KerbPhysicMaterial;

		public float KerbTiling = 1f;

		public EUvStretchMode KerbUvMode = EUvStretchMode.SeamlessStretch;

		[Header("Other")]
		public bool OverrideMusic;

		[ShowIf("OverrideMusic", true)]
		public string MusicLoop;

		public List<RoadsideObject> RoadsideObjects = new List<RoadsideObject>();

		public List<RaceCheckpoint> Checkpoints = new List<RaceCheckpoint>();

		[HideInInspector]
		public RaceSpline MainSpline;

		private GameObject _trackContainer;

		private GameObject _decoContainer;

		private int _zOffset;

		private bool _toUpdate;

		private List<GameObject> _meshes = new List<GameObject>();

		private List<GameObject> _roadsideObjects = new List<GameObject>();

		private void OnEnable()
		{
			MainSpline = GetComponent<RaceSpline>();
			MainSpline.NodeCountChanged.AddListener(delegate
			{
				_toUpdate = true;
			});
			MainSpline.OnSplineValidate.AddListener(delegate
			{
				_toUpdate = true;
			});
			if (_trackContainer == null)
			{
				_trackContainer = new GameObject("Track");
				_trackContainer.transform.parent = base.transform;
				_trackContainer.transform.localPosition = Vector3.zero;
				_trackContainer.hideFlags = HideFlags.DontSave;
			}
			if (_decoContainer == null)
			{
				_decoContainer = new GameObject("Deco");
				_decoContainer.transform.parent = base.transform;
				_decoContainer.transform.localPosition = Vector3.zero;
				_decoContainer.hideFlags = HideFlags.DontSave;
			}
			_toUpdate = true;
		}

		protected void OnValidate()
		{
			_toUpdate = true;
		}

		private void Update()
		{
			if (!_toUpdate)
			{
				return;
			}
			_toUpdate = false;
			_zOffset = 0;
			foreach (RaceSpline.NodeSetting nodeSetting in MainSpline.NodeSettings)
			{
				if (nodeSetting.ForkOut && nodeSetting.ForkOutSpline == null)
				{
					GameObject obj = new GameObject("Fork" + MainSpline.NodeSettings.IndexOf(nodeSetting), typeof(RaceSpline));
					obj.transform.parent = base.transform;
					RaceSpline component = obj.GetComponent<RaceSpline>();
					component.Reset();
					component.nodes[0].SetPosition(MainSpline.nodes[MainSpline.NodeSettings.IndexOf(nodeSetting)].position + base.transform.position);
					nodeSetting.ForkOutSpline = component;
				}
				else if (nodeSetting.ForkIn)
				{
					if (nodeSetting.ForkInSplines == null || nodeSetting.ForkInSplines.Count <= 0)
					{
						continue;
					}
					foreach (RaceSpline forkInSpline in nodeSetting.ForkInSplines)
					{
						if (!(forkInSpline == null))
						{
							RaceSpline raceSpline = forkInSpline;
							raceSpline.nodes[raceSpline.nodes.Count - 1].SetPosition(MainSpline.nodes[MainSpline.NodeSettings.IndexOf(nodeSetting)].position);
							raceSpline.ForkTargetSpline = MainSpline;
						}
					}
				}
				else if (!nodeSetting.ForkOut && nodeSetting.ForkOutSpline != null)
				{
					SafeDelete(nodeSetting.ForkOutSpline.gameObject);
				}
			}
			ClearMeshes();
			StartCoroutine(CreateMeshes());
			ClearRoadsideObjects();
			PlaceRoadsideObjects();
		}

		private void OnDisable()
		{
			ClearMeshes();
			ClearRoadsideObjects();
			SafeDelete(_trackContainer);
			SafeDelete(_decoContainer);
		}

		private IEnumerator CreateMeshes()
		{
			RaceSpline[] componentsInChildren = GetComponentsInChildren<RaceSpline>();
			foreach (RaceSpline spl in componentsInChildren)
			{
				float distance = float.MaxValue;
				NimbatusDrone nimbatusDrone = Object.FindObjectOfType<NimbatusDrone>();
				float num = float.MaxValue;
				for (float num2 = 0f; num2 <= spl.Length; num2 += 10f)
				{
					Vector3 vector = spl.GetLocationAlongSplineAtDistance(num2) + spl.transform.position;
					float magnitude = (((nimbatusDrone != null && nimbatusDrone.RootDronePart != null) ? nimbatusDrone.RootDronePart.transform.position : Vector3.zero) - vector).magnitude;
					if (magnitude < num)
					{
						num = magnitude;
						distance = num2;
					}
				}
				int nodePos = spl.GetLastNodeIndexAtDistance(distance);
				nodePos--;
				if (nodePos < 0)
				{
					nodePos = (spl.Loop ? (nodePos + (spl.nodes.Count - 1)) : 0);
				}
				ReadOnlyCollection<CubicBezierCurve> c = spl.GetCurves();
				int buffer = 0;
				for (int h = nodePos; h < nodePos + c.Count; h++)
				{
					int i2 = ((h < c.Count) ? h : (h - c.Count));
					float num3 = Scale * spl.NodeSettings[i2].Width;
					Material material = Material;
					if (spl.NodeSettings[i2].NextSegmentMaterial != null)
					{
						material = spl.NodeSettings[i2].NextSegmentMaterial;
					}
					Material kerbMat = KerbMaterial;
					if (spl.NodeSettings[i2].NextSegmentKerbMaterial != null)
					{
						kerbMat = spl.NodeSettings[i2].NextSegmentKerbMaterial;
					}
					float offset = spl.NodeSettings[i2].Offset / (Scale / KerbScale);
					float kerboffset = num3 / 2f / KerbScale + 0.5f;
					CreateMesh(c[i2], spl, Mesh, material, num3, i2, offset);
					if (Application.isPlaying && buffer >= 2)
					{
						yield return new WaitForEndOfFrame();
					}
					if (spl.NodeSettings[i2].KerbRight)
					{
						CreateMesh(c[i2], spl, KerbMesh, kerbMat, KerbScale, i2, kerboffset + offset, true);
					}
					if (Application.isPlaying && buffer >= 2)
					{
						yield return new WaitForEndOfFrame();
					}
					if (spl.NodeSettings[i2].KerbLeft)
					{
						CreateMesh(c[i2], spl, KerbMesh, kerbMat, KerbScale, i2, 0f - kerboffset + offset, true);
					}
					if (Application.isPlaying && buffer >= 2)
					{
						yield return new WaitForEndOfFrame();
					}
					buffer++;
				}
				_zOffset++;
				if (Application.isPlaying)
				{
					yield return new WaitForEndOfFrame();
				}
				else
				{
					yield return null;
				}
			}
		}

		private void CreateMesh(CubicBezierCurve curve, RaceSpline spl, Mesh mesh, Material material, float scale, int index, float offset, bool isKerb = false)
		{
			int num = 0;
			GameObject gameObject;
			if (!isKerb)
			{
				gameObject = new GameObject("Track" + num++, typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshBender));
				gameObject.transform.parent = _trackContainer.transform;
				gameObject.transform.localPosition = new Vector3(0f, 0f, 10f + 0.1f * (float)_zOffset);
				gameObject.layer = Layer;
			}
			else
			{
				gameObject = new GameObject("Kerb" + num++, typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshBender), typeof(MeshCollider));
				gameObject.transform.parent = _trackContainer.transform;
				gameObject.transform.localPosition = Vector3.zero + new Vector3(0f, 0f, 0.1f * (float)_zOffset);
				gameObject.layer = Layer;
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
			float num2 = scale;
			if (!isKerb)
			{
				num2 = spl.NodeSettings[index + 1].Width * Scale;
			}
			float y;
			float y2;
			if (isKerb)
			{
				int num3 = ((offset > 0f) ? 1 : (-1));
				y = spl.NodeSettings[index].Width * Scale / 2f / KerbScale + 0.5f + spl.NodeSettings[index].Offset * (float)num3 * spl.NodeSettings[index].Width;
				y2 = spl.NodeSettings[index + 1].Width * Scale / 2f / KerbScale + 0.5f + spl.NodeSettings[index + 1].Offset * (float)num3 * spl.NodeSettings[index + 1].Width;
			}
			else
			{
				y = offset;
				y2 = spl.NodeSettings[index + 1].Offset / (Scale / KerbScale);
			}
			EUvStretchMode mode = ((!isKerb) ? (spl.NodeSettings[index].OverrideTrackUvMode ? spl.NodeSettings[index].TrackUvMode : TrackUvMode) : (spl.NodeSettings[index].OverrideKerbUvMode ? spl.NodeSettings[index].KerbUvMode : KerbUvMode));
			MeshBender component = gameObject.GetComponent<MeshBender>();
			component.SetUvMode(mode, false);
			component.SetUvYTiling(isKerb ? KerbTiling : 1f, false);
			component.SetSourceMesh(mesh, false);
			component.SetRotation(Quaternion.Euler(Vector3.zero), false);
			component.SetTranslation(new Vector3(0f, y, 0f), false);
			component.SetEndTranslation(new Vector3(0f, y2, 0f), false);
			component.SetCurve(curve, false);
			int num4 = ((!isKerb || offset > 0f) ? 1 : (-1));
			component.SetStartScale(scale * (float)num4, false);
			component.SetEndScale(num2 * (float)num4);
			_meshes.Add(gameObject);
		}

		private void ClearMeshes()
		{
			foreach (GameObject item in _meshes.ToList())
			{
				SafeDelete(item);
			}
			_meshes.Clear();
			if (!(_trackContainer != null))
			{
				return;
			}
			foreach (GameObject item2 in (from Transform child in _trackContainer.transform
				select child.gameObject).ToList())
			{
				SafeDelete(item2);
			}
		}

		private void PlaceRoadsideObjects()
		{
			for (int i = 0; i < 2; i++)
			{
				GameObject gameObject = null;
				foreach (RoadsideObject roadsideObject in RoadsideObjects)
				{
					float num = roadsideObject.StartOffset;
					Mathf.Clamp(roadsideObject.Spacing, 0.1f, 2.1474836E+09f);
					while (num <= MainSpline.Length)
					{
						GameObject gameObject2 = Object.Instantiate(roadsideObject.Object, _decoContainer.transform);
						gameObject2.transform.localRotation = Quaternion.identity;
						gameObject2.transform.localScale = Vector3.one;
						gameObject2.transform.localPosition = MainSpline.GetLocationAlongSplineAtDistance(num);
						Quaternion rotation = Quaternion.LookRotation(MainSpline.GetTangentAlongSplineAtDistance(num)) * Quaternion.LookRotation(Vector3.left, Vector3.up);
						gameObject2.transform.rotation = rotation;
						Vector3 tangentAlongSplineAtDistance = MainSpline.GetTangentAlongSplineAtDistance(num);
						tangentAlongSplineAtDistance = Vector3.Cross(tangentAlongSplineAtDistance, Vector3.back).normalized * roadsideObject.Width * MainSpline.GetWidthModifierAtDistance(num);
						int num2 = ((i == 0) ? 1 : (-1));
						gameObject2.transform.localPosition += tangentAlongSplineAtDistance * num2;
						gameObject2.transform.localPosition += new Vector3(0f, 0f, 0f - KerbScale);
						num += roadsideObject.Spacing;
						if (gameObject != null && (gameObject2.transform.position - gameObject.transform.position).magnitude < roadsideObject.MinDistance)
						{
							SafeDelete(gameObject2);
							continue;
						}
						gameObject = gameObject2;
						gameObject2.hideFlags = HideFlags.NotEditable;
						gameObject2.hideFlags = HideFlags.DontSave;
						_roadsideObjects.Add(gameObject2);
					}
				}
			}
		}

		private void ClearRoadsideObjects()
		{
			foreach (GameObject item in _roadsideObjects.ToList())
			{
				SafeDelete(item);
			}
			_roadsideObjects.Clear();
			if (!(_decoContainer != null))
			{
				return;
			}
			foreach (GameObject item2 in (from Transform child in _decoContainer.transform
				select child.gameObject).ToList())
			{
				SafeDelete(item2);
			}
		}

		private void SafeDelete(GameObject go)
		{
			if (go != null)
			{
				if (Application.isEditor)
				{
					Object.DestroyImmediate(go);
				}
				else
				{
					Object.Destroy(go);
				}
			}
		}
	}
}
