using System;
using System.Collections.Generic;
using UnityEngine;

namespace CritiasFoliage
{
	[ExecuteInEditMode]
	public class FoliagePainter : MonoBehaviour
	{
		[Serializable]
		public enum ESpatialGridDrawMode
		{
			NONE = 0,
			DRAW_GRIDS = 1,
			DRAW_GRIDS_EXTENDED = 2,
			DRAW_SUBDIVIDED_GRIDS = 3,
			DRAW_DRAWN_GRIDS = 4,
			DRAW_DRAWN_SUBDIVIDED_GRIDS = 5
		}

		public FoliageRenderer m_FoliageRenderer;

		public FoliageColliders m_FoliageColliders;

		[SerializeField]
		private List<FoliageType> m_FoliageTypes = new List<FoliageType>();

		private Dictionary<int, FoliageType> m_FoliageTypeIndexed;

		public FoliageDataRuntime m_FoliageDataRuntime;

		public string m_FoliageDataSaveName;

		public bool m_BillboardsGenerateLODGroup = true;

		public float m_BillboardLODGroupFade = 0.2f;

		public bool m_BillboardLODGroupWillCrossFade = true;

		public Shader m_ShaderTreeMaster;

		public Shader m_ShaderGrass;

		public Shader m_ShaderNull;

		public FoliagePainterRuntime GetRuntime => new FoliagePainterRuntime(this);

		private void Awake()
		{
		}

		private void Start()
		{
			base.enabled = false;
			LoadFromFile(forceReload: false, runtimeOnly: true);
			if (!m_FoliageRenderer)
			{
				m_FoliageRenderer = UnityEngine.Object.FindObjectOfType<FoliageRenderer>();
			}
			if (!m_FoliageColliders)
			{
				m_FoliageColliders = UnityEngine.Object.FindObjectOfType<FoliageColliders>();
			}
			m_FoliageRenderer.InitRenderer(this, m_FoliageDataRuntime, m_FoliageTypes);
			m_FoliageColliders.InitCollider(m_FoliageDataRuntime, m_FoliageTypes);
			for (int i = 0; i < m_FoliageTypes.Count; i++)
			{
				m_FoliageTypes[i].UpdateValues();
			}
		}

		public Shader GetShaderTreeMaster()
		{
			if (m_ShaderTreeMaster == null)
			{
				m_ShaderTreeMaster = Shader.Find("Critias/WindTree_Master");
			}
			return m_ShaderTreeMaster;
		}

		public Shader GetShaderNull()
		{
			if (m_ShaderNull == null)
			{
				m_ShaderNull = Shader.Find("Critias/NullShader");
			}
			return m_ShaderNull;
		}

		public Shader GetShaderGrass()
		{
			if (m_ShaderGrass == null)
			{
				m_ShaderGrass = Shader.Find("Critias/WindTree_Grass");
			}
			return m_ShaderGrass;
		}

		public string GetFileSaveName()
		{
			if (m_FoliageDataSaveName == null || m_FoliageDataSaveName.Length == 0)
			{
				m_FoliageDataSaveName = "FoliageData_" + base.gameObject.scene.name;
			}
			return m_FoliageDataSaveName;
		}

		public void SaveToFile()
		{
			Debug.LogError("Can't save to file while we are not in the editor!");
		}

		public void LoadFromFile(bool forceReload, bool runtimeOnly)
		{
			if (runtimeOnly)
			{
				m_FoliageDataRuntime = FoliageDataSerializer.LoadFromFileRuntime(GetFileSaveName());
			}
		}

		private void RefreshFoliageTypeData()
		{
			for (int i = 0; i < m_FoliageTypes.Count; i++)
			{
				FoliageTypeUtilities.BuildDataPartialEditTime(this, m_FoliageTypes[i]);
				m_FoliageTypes[i].UpdateValues();
			}
			m_FoliageRenderer.UpdateFoliageTypes(m_FoliageTypes);
		}

		public List<FoliageTypeRuntime> GetFoliageTypesRuntime()
		{
			return m_FoliageTypes.ConvertAll((FoliageType x) => new FoliageTypeRuntime
			{
				m_Hash = x.m_Hash,
				m_Name = x.m_Name,
				m_Type = x.Type,
				m_IsGrassType = x.IsGrassType,
				m_IsSpeedTreeType = x.IsSpeedTreeType
			});
		}

		public void RemoveFoliageInstanceRuntime(Guid guid)
		{
			m_FoliageDataRuntime.RemoveFoliageInstance(guid);
		}

		public void RemoveFoliageInstanceRuntime(int typeHash, Guid guid)
		{
			m_FoliageDataRuntime.RemoveFoliageInstance(typeHash, guid);
		}

		public void RemoveFoliageInstanceRuntime(int typeHash, Guid guid, Vector3 position)
		{
			m_FoliageDataRuntime.RemoveFoliageInstance(typeHash, guid, position);
		}

		public void AddFoliageInstanceRuntime(int typeHash, FoliageInstance instance)
		{
			FoliageType foliageTypeByHash = GetFoliageTypeByHash(typeHash);
			if (foliageTypeByHash != null && !foliageTypeByHash.IsGrassType)
			{
				PrepareFoliageInstanceRuntime(foliageTypeByHash, ref instance);
				m_FoliageDataRuntime.AddFoliageInstance(typeHash, instance);
			}
		}

		public void SetFoliageTypeCastShadowRuntime(int typeHash, bool castShadow)
		{
			FoliageType foliageTypeByHash = GetFoliageTypeByHash(typeHash);
			if (foliageTypeByHash != null && foliageTypeByHash.m_RenderInfo.m_CastShadow != castShadow)
			{
				foliageTypeByHash.m_RenderInfo.m_CastShadow = castShadow;
				RefreshFoliageTypeDataRuntime(foliageTypeByHash);
			}
			m_FoliageRenderer.UpdateFoliageTypes(m_FoliageTypes);
		}

		public bool GetFoliageTypeCastShadowRuntime(int typeHash)
		{
			return GetFoliageTypeByHash(typeHash)?.m_RenderInfo.m_CastShadow ?? false;
		}

		public void SetFoliageTypeMaxDistanceRuntime(int typeHash, float maxDistance)
		{
			FoliageType foliageTypeByHash = GetFoliageTypeByHash(typeHash);
			if (foliageTypeByHash != null && Mathf.Abs(foliageTypeByHash.m_RenderInfo.m_MaxDistance - maxDistance) > Mathf.Epsilon)
			{
				foliageTypeByHash.m_RenderInfo.m_MaxDistance = FoliageGlobals.ClampDistance(foliageTypeByHash.Type, maxDistance);
				RefreshFoliageTypeDataRuntime(foliageTypeByHash);
			}
		}

		public float GetFoliageTypeMaxDistanceRuntime(int typeHash)
		{
			return GetFoliageTypeByHash(typeHash)?.m_RenderInfo.m_MaxDistance ?? (-1f);
		}

		public void SetFoliageTypeHueRuntime(int typeHash, Color hue)
		{
			FoliageType foliageTypeByHash = GetFoliageTypeByHash(typeHash);
			if (foliageTypeByHash != null && foliageTypeByHash.m_RenderInfo.m_Hue != hue)
			{
				foliageTypeByHash.m_RenderInfo.m_Hue = hue;
				RefreshFoliageTypeDataRuntime(foliageTypeByHash);
			}
		}

		public Color GetFoliageTypeHueRuntime(int typeHash)
		{
			return GetFoliageTypeByHash(typeHash)?.m_RenderInfo.m_Hue ?? Color.black;
		}

		public void SetFoliageTypeColorRuntime(int typeHash, Color color)
		{
			FoliageType foliageTypeByHash = GetFoliageTypeByHash(typeHash);
			if (foliageTypeByHash != null && foliageTypeByHash.m_RenderInfo.m_Color != color)
			{
				foliageTypeByHash.m_RenderInfo.m_Color = color;
				RefreshFoliageTypeDataRuntime(foliageTypeByHash);
			}
		}

		public Color GetFoliageTypeColorRuntime(int typeHash)
		{
			return GetFoliageTypeByHash(typeHash)?.m_RenderInfo.m_Color ?? Color.black;
		}

		private void RefreshFoliageTypeDataRuntime(FoliageType modifiedType = null)
		{
			if (modifiedType != null)
			{
				modifiedType.UpdateValues();
			}
			else
			{
				for (int i = 0; i < m_FoliageTypes.Count; i++)
				{
					m_FoliageTypes[i].UpdateValues();
				}
			}
			m_FoliageRenderer.UpdateFoliageTypes(m_FoliageTypes);
		}

		private Dictionary<int, FoliageType> GetFoliageTypeSet()
		{
			if (m_FoliageTypeIndexed == null)
			{
				m_FoliageTypeIndexed = new Dictionary<int, FoliageType>();
				m_FoliageTypes.ForEach(delegate(FoliageType x)
				{
					m_FoliageTypeIndexed.Add(x.m_Hash, x);
				});
			}
			return m_FoliageTypeIndexed;
		}

		public FoliageType GetFoliageTypeByHash(int typeHash)
		{
			Dictionary<int, FoliageType> foliageTypeSet = GetFoliageTypeSet();
			if (!foliageTypeSet.ContainsKey(typeHash))
			{
				return null;
			}
			return foliageTypeSet[typeHash];
		}

		private void PrepareFoliageInstanceRuntime(FoliageType type, ref FoliageInstance instance)
		{
			instance.m_UniqueId = Guid.NewGuid();
			instance.m_Bounds = type.m_Bounds;
			instance.m_Bounds = FoliageUtilities.LocalToWorld(ref instance.m_Bounds, instance.GetWorldTransform());
			instance.BuildWorldMatrix();
		}
	}
}
