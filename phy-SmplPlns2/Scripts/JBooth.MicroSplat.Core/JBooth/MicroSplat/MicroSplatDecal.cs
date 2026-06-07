using UnityEngine;

namespace JBooth.MicroSplat
{
	[ExecuteAlways]
	public class MicroSplatDecal : MonoBehaviour
	{
		public enum SplatMode
		{
			SplatMap = 0,
			StreamMap = 1
		}

		public enum NormalBlend
		{
			Replace = 0,
			Blend = 1
		}

		public enum AlbedoBlend
		{
			Blend = 0,
			Multiply2X = 1
		}

		public MicroSplatDecalReceiver targetObject;

		public int textureIndex;

		public int splatTextureIndex;

		public float albedoOpacity = 1f;

		public float smoothnessOpacity = 1f;

		public float heightBlend;

		public float normalOpacity = 1f;

		public float splatOpacity;

		public Color tint = Color.white;

		public AlbedoBlend albedoBlend;

		public SplatMode splatMode;

		public NormalBlend normalBlend;

		public float tessOpacity = 1f;

		public float tessOffset;

		public int sortOrder;

		public Vector4 splatIndexes = new Vector4(0f, 1f, 2f, 3f);

		[SerializeField]
		private bool _dynamic;

		private Matrix4x4 oldMtx;

		public bool dynamic
		{
			get
			{
				return _dynamic;
			}
			set
			{
				if (value != _dynamic)
				{
					if (base.enabled)
					{
						OnDisable();
					}
					_dynamic = value;
					if (base.enabled)
					{
						OnEnable();
					}
				}
			}
		}

		public void GetShaderData(out Vector4 data1, out Vector4 data2)
		{
			float num = 0f;
			num = Mathf.Floor(tessOffset * 256f) + tessOpacity * 0.95f;
			float z = (splatOpacity + 1f) * (float)((splatMode == SplatMode.SplatMap) ? 1 : (-1));
			float y = (normalOpacity + 1f) * (float)((normalBlend == NormalBlend.Replace) ? 1 : (-1));
			float x = (albedoOpacity + 1f) * (float)((albedoBlend == AlbedoBlend.Blend) ? 1 : (-1));
			float x2 = splatTextureIndex * 100 + textureIndex;
			data1 = new Vector4(x2, base.transform.lossyScale.y, z, num);
			data2 = new Vector4(x, y, smoothnessOpacity, heightBlend);
		}

		private void InitDecal()
		{
			oldMtx = base.transform.localToWorldMatrix;
			if (targetObject != null)
			{
				targetObject.RegisterDecal(this);
			}
		}

		private void OnEnable()
		{
			InitDecal();
		}

		private void Start()
		{
			InitDecal();
		}

		private void OnDisable()
		{
			if (targetObject != null)
			{
				targetObject.UnregisterDecal(this);
			}
		}

		private void OnDestroy()
		{
			OnDisable();
		}

		public void Reset()
		{
			OnDisable();
			OnEnable();
		}

		private void UpdateRendering()
		{
			if (targetObject != null && targetObject.msObj != null)
			{
				MicroSplatTerrain microSplatTerrain = targetObject.msObj as MicroSplatTerrain;
				if (microSplatTerrain != null)
				{
					targetObject.UpdateDecalInCache(microSplatTerrain.terrain.transform.position, microSplatTerrain.terrain.terrainData.size, this, oldMtx);
					oldMtx = base.transform.localToWorldMatrix;
				}
				MicroSplatMeshTerrain microSplatMeshTerrain = targetObject.msObj as MicroSplatMeshTerrain;
				if (microSplatMeshTerrain != null)
				{
					targetObject.UpdateDecalInCache(microSplatMeshTerrain.transform.position, microSplatMeshTerrain.GetBounds().size, this, oldMtx);
					oldMtx = base.transform.localToWorldMatrix;
				}
			}
		}

		private void Update()
		{
			if (base.transform.hasChanged)
			{
				base.transform.hasChanged = false;
				UpdateRendering();
			}
		}
	}
}
