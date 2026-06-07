using System;
using System.Collections.Generic;
using UnityEngine;

public class GrassSystem : MonoBehaviour
{
	public int Divisions = 8;

	[NonSerialized]
	private int? _currentlyUpdating;

	private int _updateProg;

	private int _updateEnd;

	private ParticleSystem[,] _grassTiles;

	private ParticleSystem.Particle[,][] _grassBlades;

	private List<Vector4>[,] _waveOffset;

	public float MinGrassSize = 0.75f;

	public float MaxGrassSize = 0.75f;

	public float YOffset = 0.2f;

	public float PerlinFactor = 256f;

	public float MaxUpdateSlize = 0.01f;

	public bool Working;

	public int GrassTexRes = 512;

	public Vector2 RNDOffset;

	public Camera cam;

	public RenderTexture Test;

	public Texture2D Test2;

	public Material Black;

	public Mesh Quad;

	private int _texDirty = 5;

	public MeshFilter GrassMesh;

	public Mesh[] GrassLOD;

	public float[] LODDistance;

	public Renderer GrassMask;

	public static GrassSystem Instance;

	[NonSerialized]
	private float _lastDist = -1f;

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		Test = new RenderTexture(GrassTexRes, GrassTexRes, 0, RenderTextureFormat.R8);
		GrassMask.material.mainTexture = Test;
		cam.targetTexture = Test;
	}

	private void OnDestroy()
	{
		if (Test != null)
		{
			UnityEngine.Object.Destroy(Test);
		}
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void RefreshTex()
	{
		Camera.SetupCurrent(cam);
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = Test;
		GL.Clear(false, true, Color.white);
		GL.PushMatrix();
		GL.LoadProjectionMatrix(GL.GetGPUProjectionMatrix(cam.projectionMatrix, false));
		GL.LoadIdentity();
		GL.modelview = cam.worldToCameraMatrix;
		if (Black.SetPass(0))
		{
			for (int i = 0; i < GameSettings.Instance.sRoomManager.Rooms.Count; i++)
			{
				Room room = GameSettings.Instance.sRoomManager.Rooms[i];
				if (room == null)
				{
					continue;
				}
				if (room.Floor == 0 && room.FloorMeshFilter != null)
				{
					Graphics.DrawMeshNow(room.FloorMeshFilter.sharedMesh, Matrix4x4.identity);
					if (!room.Outdoors)
					{
						Graphics.DrawMeshNow(room.TopWallMesh.sharedMesh, Matrix4x4.identity);
					}
				}
				else
				{
					if (room.Floor != -1)
					{
						continue;
					}
					List<Furniture> furnitures = room.GetFurnitures();
					for (int j = 0; j < furnitures.Count; j++)
					{
						Furniture furniture = furnitures[j];
						if (furniture == null)
						{
							continue;
						}
						if (furniture.TwoFloors && furniture.MakeHole && furniture.Colorable.Count > 0)
						{
							if (furniture.CustomHoleTransform != null)
							{
								Graphics.DrawMeshNow((furniture.CustomHoleMesh != null) ? furniture.CustomHoleMesh : Quad, furniture.CustomHoleTransform.localToWorldMatrix);
							}
							else if (furniture.Colorable.Count > 0)
							{
								Graphics.DrawMeshNow(furniture.Colorable[0].GetComponent<MeshFilter>().sharedMesh, furniture.Colorable[0].transform.localToWorldMatrix);
							}
						}
						else if (furniture.PokesThroughRoof)
						{
							MeshFilter[] componentsInChildren = furniture.OnRoofObject.GetComponentsInChildren<MeshFilter>();
							for (int k = 0; k < componentsInChildren.Length; k++)
							{
								Graphics.DrawMeshNow(componentsInChildren[0].sharedMesh, componentsInChildren[0].transform.localToWorldMatrix);
							}
						}
					}
				}
			}
			foreach (PlayerMap value in GameSettings.Instance.sRoomManager.PlayerMaps.Values)
			{
				foreach (NetworkRoom value2 in value.Rooms.Values)
				{
					if (value2.Floor == 0 && value2.RoofFloorObject != null)
					{
						Graphics.DrawMeshNow(value2.RoofFloorObject.GetComponent<MeshFilter>().sharedMesh, Matrix4x4.identity);
					}
				}
			}
			float num = RoadManager.Instance.RoadSize * 0.5f;
			for (int l = 1; l < RoadManager.Instance.GridSize - 1; l++)
			{
				for (int m = 1; m < RoadManager.Instance.GridSize - 1; m++)
				{
					if (RoadManager.Instance.GetRoad(l, m, 0) > 0)
					{
						Graphics.DrawMeshNow(Quad, Matrix4x4.TRS(new Vector3((float)l * RoadManager.Instance.RoadSize + num, 0f, (float)m * RoadManager.Instance.RoadSize + num), Quaternion.identity, new Vector3(RoadManager.Instance.RoadSize, 1f, RoadManager.Instance.RoadSize)));
					}
				}
			}
			for (int n = 0; n < RoadManager.Instance.Landmarks.Count; n++)
			{
				MeshFilter grassMesh = RoadManager.Instance.Landmarks[n].GetGrassMesh();
				if (grassMesh != null)
				{
					Graphics.DrawMeshNow(grassMesh.sharedMesh, grassMesh.transform.localToWorldMatrix);
				}
			}
			for (int num2 = 0; num2 < GameSettings.Instance.sRoomManager.PathController.AllPathObjects.Count; num2++)
			{
				Graphics.DrawMeshNow(GameSettings.Instance.sRoomManager.PathController.AllPathObjects[num2].MeshComp.sharedMesh, Matrix4x4.identity);
			}
		}
		else
		{
			Debug.LogError("Failed setting Black Grass material");
			Options.GrassQuality = 0;
		}
		GL.PopMatrix();
		RenderTexture.active = active;
	}

	public void InvalidateArea()
	{
		if (base.enabled)
		{
			_texDirty = 3;
		}
	}

	public static void RefreshGrassQuality()
	{
		if (Instance != null)
		{
			Instance.LocalRefresh();
			GameSettings.Instance.sRoomManager.Rooms.ForEach(delegate(Room x)
			{
				x.UpdateGrass();
			});
		}
	}

	private void LocalRefresh()
	{
		base.enabled = Options.GrassQuality > 0;
		BuildController.Instance.MainGridMaterial.SetShaderPassEnabled("Vertex", base.enabled);
		_lastDist = -1f;
	}

	public void Init(Vector2? offset = null)
	{
		if (offset.HasValue)
		{
			RNDOffset = offset.Value;
		}
		TimeOfDay.Instance.NoiseGrassMaterial.SetVector("_Offset", RNDOffset);
		base.enabled = Options.GrassQuality > 0;
	}

	private void InitializeBlades()
	{
	}

	private void Update()
	{
		if (_texDirty > 0)
		{
			_texDirty--;
			if (_texDirty == 0)
			{
				RefreshTex();
			}
		}
		float y = CameraScript.Instance.LastCamPos.y;
		if (y == _lastDist)
		{
			return;
		}
		_lastDist = y;
		for (int i = 3 - Mathf.Clamp(Options.GrassQuality, 0, 3); i < LODDistance.Length; i++)
		{
			if (y < LODDistance[i])
			{
				GrassMesh.sharedMesh = GrassLOD[i];
				break;
			}
		}
	}

	private void FixGrass()
	{
		if (!_currentlyUpdating.HasValue)
		{
			return;
		}
		int value = _currentlyUpdating.Value;
		int num = value % Divisions;
		int num2 = value / Divisions;
		ParticleSystem.Particle[] array = _grassBlades[num, num2];
		List<Vector4> list = _waveOffset[num, num2];
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		while (_updateProg <= _updateEnd && Time.realtimeSinceStartup - realtimeSinceStartup < MaxUpdateSlize)
		{
			Vector2 vector = array[_updateProg].position.FlattenVector3();
			if (!(vector.x > 8f) || !(vector.x < 248f) || !(vector.y > 8f) || !(vector.y < 248f) || !(Test2.GetPixelBilinear((vector.x - 8f) / 240f, (vector.y - 8f) / 240f).r > 0.95f))
			{
				ParticleSystem.Particle particle = array[_updateEnd];
				array[_updateEnd] = array[_updateProg];
				array[_updateProg] = particle;
				Vector4 value2 = list[_updateEnd];
				list[_updateEnd] = list[_updateProg];
				list[_updateProg] = value2;
				_updateEnd--;
			}
			else
			{
				_updateProg++;
			}
		}
		if (_updateProg > _updateEnd)
		{
			_updateProg = 0;
			_currentlyUpdating = null;
		}
		_grassTiles[num, num2].SetCustomParticleData(list, ParticleSystemCustomData.Custom1);
		_grassTiles[num, num2].SetParticles(array, _updateEnd + 1);
	}

	private int FillGrass(ParticleSystem.Particle[] blades, List<Vector4> wave, Rect area)
	{
		int num = 0;
		for (int i = 0; i < blades.Length; i++)
		{
			Vector2 randomPoint = area.GetRandomPoint();
			float num2 = TimeOfDay.Instance.CurrentWeather.GrassPerlinCutoff.Evaluate(Mathf.PerlinNoise(randomPoint.x / PerlinFactor + RNDOffset.x, randomPoint.y / PerlinFactor + RNDOffset.y));
			if (num2 > 0.1f)
			{
				blades[num] = new ParticleSystem.Particle
				{
					position = randomPoint.ToVector3(YOffset),
					startLifetime = 100000f,
					remainingLifetime = 100000f,
					startColor = TimeOfDay.Instance.CurrentWeather.GrassVariance.Evaluate(UnityEngine.Random.value),
					startSize = num2 * UnityEngine.Random.Range(MinGrassSize, MaxGrassSize),
					randomSeed = (uint)UnityEngine.Random.Range(0, int.MaxValue)
				};
				wave[num] = new Vector4(Mathf.PerlinNoise(randomPoint.x / PerlinFactor * 2f, randomPoint.y / PerlinFactor * 2f) * 2f * (float)Math.PI, UnityEngine.Random.Range(0, 2));
				num++;
			}
		}
		return num;
	}
}
