using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CCTVRenderer : MonoBehaviour
{
	public static CCTVRenderer Instance;

	public Camera CCTVCamera;

	public int CCSize = 64;

	private int _lastCCTV;

	public float UpdateTime = 0.5f;

	private float _nextUpdate;

	public RenderTexture CCTVTexture;

	public RenderTexture CCTVTextureTemp;

	public Material CCTVMaterial;

	private Vector2Int _targetPos;

	public Renderer Ground;

	public Mesh lightSphereMesh;

	private Dictionary<SurveillanceDesk, List<int>> _slots = new Dictionary<SurveillanceDesk, List<int>>();

	private HashSet<int> _usedKeys = new HashSet<int>();

	private Dictionary<Furniture, int> _fSlots = new Dictionary<Furniture, int>();

	private CommandBuffer _lightBuffer;

	private List<Mesh> _meshPool = new List<Mesh>();

	private List<Mesh> _usedMeshes = new List<Mesh>();

	private List<KeyValuePair<SurveillanceDesk, List<int>>> _removeCache = new List<KeyValuePair<SurveillanceDesk, List<int>>>();

	private List<Furniture> _freeCams = new List<Furniture>();

	private List<SurveillanceDesk> _freeDesks = new List<SurveillanceDesk>();

	private void Awake()
	{
		Instance = this;
	}

	private void FixedUpdate()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			_nextUpdate += Time.deltaTime;
			if (_nextUpdate > UpdateTime && !CCTVCamera.enabled)
			{
				UpdateCCTV();
				_nextUpdate = 0f;
			}
		}
	}

	private int GetFreeKey()
	{
		int num = CCTVTexture.width / CCSize;
		num *= num;
		if (_usedKeys.Count < num)
		{
			for (int i = 0; i < num; i++)
			{
				if (!_usedKeys.Contains(i))
				{
					return i;
				}
			}
		}
		return -1;
	}

	public void RemoveCCTV(SurveillanceDesk desk, Furniture furn)
	{
		int value;
		if (!_fSlots.TryGetValue(furn, out value))
		{
			return;
		}
		bool flag = false;
		List<int> value2;
		if (_slots.TryGetValue(desk, out value2))
		{
			flag = value2.Remove(value);
			if (value2.Count == 0)
			{
				_slots.Remove(desk);
			}
		}
		if (!flag)
		{
			_removeCache.AddRange(_slots);
			foreach (KeyValuePair<SurveillanceDesk, List<int>> item in _removeCache)
			{
				if (item.Value.Remove(value) && item.Value.Count == 0)
				{
					_slots.Remove(desk);
				}
			}
			_removeCache.Clear();
		}
		_usedKeys.Remove(value);
		_fSlots.Remove(furn);
	}

	private Mesh GetMeshFromPool()
	{
		Mesh mesh = _meshPool.Pop();
		if (mesh == null)
		{
			mesh = new Mesh();
		}
		_usedMeshes.AddRange(mesh);
		return mesh;
	}

	private void UpdateCCTV()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			CCTVCamera.enabled = false;
			return;
		}
		Furniture furniture = null;
		Furniture furniture2 = null;
		int num = 0;
		RoomManager sRoomManager = GameSettings.Instance.sRoomManager;
		bool flag = false;
		_freeCams.Clear();
		_freeDesks.Clear();
		foreach (Furniture key2 in _fSlots.Keys)
		{
			if (!key2.IsAliveNotNull())
			{
				_freeCams.Add(key2);
			}
		}
		for (int i = 0; i < _freeCams.Count; i++)
		{
			Furniture key = _freeCams[i];
			int item = _fSlots[key];
			_fSlots.Remove(key);
			_usedKeys.Remove(item);
			foreach (KeyValuePair<SurveillanceDesk, List<int>> slot in _slots)
			{
				if (slot.Value.Remove(item))
				{
					if (slot.Value.Count == 0)
					{
						_freeDesks.Add(slot.Key);
					}
					break;
				}
			}
		}
		for (int j = 0; j < _freeDesks.Count; j++)
		{
			_slots.Remove(_freeDesks[j]);
		}
		foreach (CCTVGroup cCGroup in sRoomManager.CCGroups)
		{
			foreach (SurveillanceDesk desk in cCGroup.Desks)
			{
				List<int> value;
				if (desk.Furn.IsAliveNotNull() && desk.Furn.IsChildVisible())
				{
					Furniture[] cCTVs = desk.GetCCTVs();
					for (int k = 0; k < cCTVs.Length; k++)
					{
						if (!cCTVs[k].IsAliveNotNull())
						{
							continue;
						}
						if (!_fSlots.ContainsKey(cCTVs[k]))
						{
							int freeKey = GetFreeKey();
							if (freeKey < 0)
							{
								flag = true;
								break;
							}
							_usedKeys.Add(freeKey);
							_fSlots[cCTVs[k]] = freeKey;
							_slots.Append(desk, freeKey);
							desk.AssignTex(k, freeKey);
						}
						if (furniture == null)
						{
							furniture = cCTVs[k];
						}
						if (num == _lastCCTV)
						{
							furniture2 = cCTVs[k];
							break;
						}
						num++;
					}
				}
				else if (_slots.TryGetValue(desk, out value))
				{
					for (int l = 0; l < value.Count; l++)
					{
						if (_usedKeys.Remove(value[l]))
						{
							_fSlots.Remove(_fSlots.LookupKey(value[l]));
						}
					}
					_slots.Remove(desk);
				}
				if (furniture2 != null || flag)
				{
					break;
				}
			}
		}
		_lastCCTV++;
		if (furniture2 == null)
		{
			furniture2 = furniture;
			_lastCCTV = 1;
			num = 0;
		}
		if (furniture2 != null)
		{
			_meshPool.AddRange(_usedMeshes);
			_usedMeshes.Clear();
			base.transform.position = furniture2.transform.position + Vector3.up * 1.8f;
			base.transform.rotation = furniture2.transform.rotation * Quaternion.Euler(30f, 0f, 0f);
			int num2 = CCTVTexture.width / CCSize;
			num %= num2 * num2;
			int num3 = num % num2;
			int num4 = num2 - num / num2 - 1;
			_targetPos = new Vector2Int(num3 * CCSize, num4 * CCSize);
			MaterialPropertyBlock properties = new MaterialPropertyBlock();
			Plane[] planes = GeometryUtility.CalculateFrustumPlanes(CCTVCamera);
			List<Furniture> furnitures = furniture2.Parent.GetFurnitures();
			_lightBuffer.Clear();
			for (int m = 0; m < furnitures.Count; m++)
			{
				Furniture furniture3 = furnitures[m];
				Renderer[] children = furniture3.GetChildren();
				if (children == null)
				{
					continue;
				}
				foreach (Renderer renderer in children)
				{
					if (renderer != null && renderer.gameObject.activeSelf)
					{
						MeshFilter component = renderer.GetComponent<MeshFilter>();
						if (component != null && GeometryUtility.TestPlanesAABB(planes, renderer.bounds))
						{
							renderer.GetPropertyBlock(properties);
							Graphics.DrawMesh(component.sharedMesh, renderer.localToWorldMatrix, renderer.sharedMaterial, 10, CCTVCamera, 0, properties, ShadowCastingMode.Off, false);
						}
					}
				}
				for (int num5 = 0; num5 < furniture3.ColorableLights.Count; num5++)
				{
					PipLight pipLight = furniture3.ColorableLights[num5];
					if (pipLight.enabled)
					{
						Bounds bounds = new Bounds(pipLight.transform.position, Vector3.one * pipLight.range);
						if (GeometryUtility.TestPlanesAABB(planes, bounds))
						{
							pipLight.WriteToCommandBuffer(_lightBuffer, lightSphereMesh, PipLightRenderer.Materials.GetMaterial(pipLight.type, null, false, LightShadows.None), 1f);
						}
					}
				}
			}
			foreach (RoomSegment item2 in furniture2.Parent.GetSegmentsMainThreadNotOutside())
			{
				for (int num6 = 0; num6 < item2.Children.Length; num6++)
				{
					Renderer renderer2 = item2.Children[num6];
					MeshFilter component2 = renderer2.GetComponent<MeshFilter>();
					if (component2 != null && GeometryUtility.TestPlanesAABB(planes, renderer2.bounds))
					{
						renderer2.GetPropertyBlock(properties);
						Graphics.DrawMesh(component2.sharedMesh, renderer2.localToWorldMatrix, renderer2.sharedMaterial, 10, CCTVCamera, 0, properties, ShadowCastingMode.Off, false);
					}
				}
			}
			for (int num7 = 0; num7 < furniture2.Parent.Occupants.Count; num7++)
			{
				Actor actor = furniture2.Parent.Occupants[num7];
				for (int num8 = 0; num8 < actor.BodyItems.Count; num8++)
				{
					Renderer rend = actor.BodyItems[num8].rend;
					if (!(rend != null))
					{
						continue;
					}
					MeshFilter component3 = rend.GetComponent<MeshFilter>();
					if (component3 != null && GeometryUtility.TestPlanesAABB(planes, rend.bounds))
					{
						rend.GetPropertyBlock(properties);
						Graphics.DrawMesh(component3.sharedMesh, rend.localToWorldMatrix, rend.sharedMaterial, 10, CCTVCamera, 0, properties, ShadowCastingMode.Off, false);
						continue;
					}
					SkinnedMeshRenderer component4 = rend.GetComponent<SkinnedMeshRenderer>();
					if (component4 != null && GeometryUtility.TestPlanesAABB(planes, rend.bounds))
					{
						Mesh meshFromPool = GetMeshFromPool();
						component4.BakeMesh(meshFromPool);
						rend.GetPropertyBlock(properties);
						Graphics.DrawMesh(meshFromPool, Matrix4x4.TRS(rend.transform.position, rend.transform.rotation, Vector3.one), rend.sharedMaterial, 10, CCTVCamera, 0, properties, ShadowCastingMode.Off, false);
					}
				}
			}
			CCTVMaterial.SetFloat("_Darkness", 1f - furniture2.Parent.DarknessLevel);
			RenderIfNotNull(furniture2.Parent.FloorMesh);
			RenderIfNotNull(furniture2.Parent.InnerWalls);
			RenderIfNotNull(furniture2.Parent.MainFence);
			Graphics.DrawMesh(Ground.GetComponent<MeshFilter>().sharedMesh, Ground.localToWorldMatrix, Ground.sharedMaterial, 10, CCTVCamera, 0, null, ShadowCastingMode.Off, false);
			CCTVCamera.backgroundColor = TimeOfDay.Instance.GetSkyColor();
			CCTVCamera.enabled = true;
		}
		else
		{
			CCTVCamera.enabled = false;
		}
	}

	private void RenderIfNotNull(GameObject obj)
	{
		if (obj != null)
		{
			MeshFilter component = obj.GetComponent<MeshFilter>();
			Graphics.DrawMesh(material: obj.GetComponent<Renderer>().sharedMaterial, mesh: component.sharedMesh, matrix: obj.transform.localToWorldMatrix, layer: 10, camera: CCTVCamera, submeshIndex: 0, properties: null, castShadows: ShadowCastingMode.Off, receiveShadows: false);
		}
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		Graphics.Blit(src, dst, CCTVMaterial);
		Graphics.CopyTexture(dst, 0, 0, 0, 0, CCSize, CCSize, CCTVTexture, 0, 0, _targetPos.x, _targetPos.y);
		CCTVCamera.enabled = false;
	}

	private void OnPostRender()
	{
	}

	private void Start()
	{
		CCTVTextureTemp = new RenderTexture(CCSize, CCSize, 16);
		CCTVMaterial = new Material(CCTVMaterial);
		CCTVCamera.targetTexture = CCTVTextureTemp;
		_lightBuffer = new CommandBuffer();
		_lightBuffer.name = "Deferred pipLights";
		CCTVCamera.AddCommandBuffer(CameraEvent.AfterFinalPass, _lightBuffer);
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = CCTVTexture;
		GL.Clear(true, true, Color.black);
		RenderTexture.active = active;
	}

	private void OnDestroy()
	{
		Object.Destroy(CCTVTextureTemp);
		Instance = null;
	}
}
