using ES3Internal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"quality", "updateWhenOffscreen", "rootBone", "bones", "sharedMesh", "skinnedMotionVectors", "localBounds", "enabled", "shadowCastingMode", "receiveShadows",
		"motionVectorGenerationMode", "lightProbeUsage", "reflectionProbeUsage", "sortingLayerName", "sortingLayerID", "sortingOrder", "lightProbeProxyVolumeOverride", "probeAnchor", "lightmapIndex", "realtimeLightmapIndex",
		"lightmapScaleOffset", "realtimeLightmapScaleOffset", "materials", "material", "sharedMaterial", "sharedMaterials"
	})]
	public class ES3UserType_SkinnedMeshRenderer : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_SkinnedMeshRenderer()
			: base(typeof(SkinnedMeshRenderer))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj;
			writer.WriteProperty("quality", skinnedMeshRenderer.quality, ES3TypeMgr.GetOrCreateES3Type(typeof(SkinQuality)));
			writer.WriteProperty("updateWhenOffscreen", skinnedMeshRenderer.updateWhenOffscreen, ES3Type_bool.Instance);
			writer.WritePropertyByRef("rootBone", skinnedMeshRenderer.rootBone);
			writer.WriteProperty("bones", skinnedMeshRenderer.bones, ES3TypeMgr.GetOrCreateES3Type(typeof(Transform[])));
			writer.WritePropertyByRef("sharedMesh", skinnedMeshRenderer.sharedMesh);
			writer.WriteProperty("skinnedMotionVectors", skinnedMeshRenderer.skinnedMotionVectors, ES3Type_bool.Instance);
			writer.WriteProperty("localBounds", skinnedMeshRenderer.localBounds, ES3Type_Bounds.Instance);
			writer.WriteProperty("enabled", skinnedMeshRenderer.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("shadowCastingMode", skinnedMeshRenderer.shadowCastingMode, ES3TypeMgr.GetOrCreateES3Type(typeof(ShadowCastingMode)));
			writer.WriteProperty("receiveShadows", skinnedMeshRenderer.receiveShadows, ES3Type_bool.Instance);
			writer.WriteProperty("motionVectorGenerationMode", skinnedMeshRenderer.motionVectorGenerationMode, ES3TypeMgr.GetOrCreateES3Type(typeof(MotionVectorGenerationMode)));
			writer.WriteProperty("lightProbeUsage", skinnedMeshRenderer.lightProbeUsage, ES3TypeMgr.GetOrCreateES3Type(typeof(LightProbeUsage)));
			writer.WriteProperty("reflectionProbeUsage", skinnedMeshRenderer.reflectionProbeUsage, ES3TypeMgr.GetOrCreateES3Type(typeof(ReflectionProbeUsage)));
			writer.WriteProperty("sortingLayerName", skinnedMeshRenderer.sortingLayerName, ES3Type_string.Instance);
			writer.WriteProperty("sortingLayerID", skinnedMeshRenderer.sortingLayerID, ES3Type_int.Instance);
			writer.WriteProperty("sortingOrder", skinnedMeshRenderer.sortingOrder, ES3Type_int.Instance);
			writer.WritePropertyByRef("lightProbeProxyVolumeOverride", skinnedMeshRenderer.lightProbeProxyVolumeOverride);
			writer.WritePropertyByRef("probeAnchor", skinnedMeshRenderer.probeAnchor);
			writer.WriteProperty("lightmapIndex", skinnedMeshRenderer.lightmapIndex, ES3Type_int.Instance);
			writer.WriteProperty("realtimeLightmapIndex", skinnedMeshRenderer.realtimeLightmapIndex, ES3Type_int.Instance);
			writer.WriteProperty("lightmapScaleOffset", skinnedMeshRenderer.lightmapScaleOffset, ES3Type_Vector4.Instance);
			writer.WriteProperty("realtimeLightmapScaleOffset", skinnedMeshRenderer.realtimeLightmapScaleOffset, ES3Type_Vector4.Instance);
			writer.WriteProperty("materials", skinnedMeshRenderer.materials, ES3Type_MaterialArray.Instance);
			writer.WritePropertyByRef("material", skinnedMeshRenderer.material);
			writer.WritePropertyByRef("sharedMaterial", skinnedMeshRenderer.sharedMaterial);
			writer.WriteProperty("sharedMaterials", skinnedMeshRenderer.sharedMaterials, ES3Type_MaterialArray.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "quality":
					skinnedMeshRenderer.quality = reader.Read<SkinQuality>();
					break;
				case "updateWhenOffscreen":
					skinnedMeshRenderer.updateWhenOffscreen = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "rootBone":
					skinnedMeshRenderer.rootBone = reader.Read<Transform>(ES3Type_Transform.Instance);
					break;
				case "bones":
					skinnedMeshRenderer.bones = reader.Read<Transform[]>();
					break;
				case "sharedMesh":
					skinnedMeshRenderer.sharedMesh = reader.Read<Mesh>(ES3Type_Mesh.Instance);
					break;
				case "skinnedMotionVectors":
					skinnedMeshRenderer.skinnedMotionVectors = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "localBounds":
					skinnedMeshRenderer.localBounds = reader.Read<Bounds>(ES3Type_Bounds.Instance);
					break;
				case "enabled":
					skinnedMeshRenderer.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "shadowCastingMode":
					skinnedMeshRenderer.shadowCastingMode = reader.Read<ShadowCastingMode>();
					break;
				case "receiveShadows":
					skinnedMeshRenderer.receiveShadows = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "motionVectorGenerationMode":
					skinnedMeshRenderer.motionVectorGenerationMode = reader.Read<MotionVectorGenerationMode>();
					break;
				case "lightProbeUsage":
					skinnedMeshRenderer.lightProbeUsage = reader.Read<LightProbeUsage>();
					break;
				case "reflectionProbeUsage":
					skinnedMeshRenderer.reflectionProbeUsage = reader.Read<ReflectionProbeUsage>();
					break;
				case "sortingLayerName":
					skinnedMeshRenderer.sortingLayerName = reader.Read<string>(ES3Type_string.Instance);
					break;
				case "sortingLayerID":
					skinnedMeshRenderer.sortingLayerID = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "sortingOrder":
					skinnedMeshRenderer.sortingOrder = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "lightProbeProxyVolumeOverride":
					skinnedMeshRenderer.lightProbeProxyVolumeOverride = reader.Read<GameObject>(ES3Type_GameObject.Instance);
					break;
				case "probeAnchor":
					skinnedMeshRenderer.probeAnchor = reader.Read<Transform>(ES3Type_Transform.Instance);
					break;
				case "lightmapIndex":
					skinnedMeshRenderer.lightmapIndex = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "realtimeLightmapIndex":
					skinnedMeshRenderer.realtimeLightmapIndex = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "lightmapScaleOffset":
					skinnedMeshRenderer.lightmapScaleOffset = reader.Read<Vector4>(ES3Type_Vector4.Instance);
					break;
				case "realtimeLightmapScaleOffset":
					skinnedMeshRenderer.realtimeLightmapScaleOffset = reader.Read<Vector4>(ES3Type_Vector4.Instance);
					break;
				case "materials":
					skinnedMeshRenderer.materials = reader.Read<Material[]>(ES3Type_MaterialArray.Instance);
					break;
				case "material":
					skinnedMeshRenderer.material = reader.Read<Material>(ES3Type_Material.Instance);
					break;
				case "sharedMaterial":
					skinnedMeshRenderer.sharedMaterial = reader.Read<Material>(ES3Type_Material.Instance);
					break;
				case "sharedMaterials":
					skinnedMeshRenderer.sharedMaterials = reader.Read<Material[]>(ES3Type_MaterialArray.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
