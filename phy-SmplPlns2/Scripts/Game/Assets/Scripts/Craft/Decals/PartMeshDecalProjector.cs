using Jundroo.Common.Utils;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Craft.Decals
{
	public class PartMeshDecalProjector : PartMeshDecalObject
	{
		public DecalProjector DecalProjector { get; private set; }

		public ICraftTextureDecal TextureDecal { get; private set; }

		public static PartMeshDecalProjector Create()
		{
			return PartMeshDecalObject.Create<PartMeshDecalProjector>();
		}

		protected override void OnCreated()
		{
			base.OnCreated();
			DecalProjector = base.gameObject.AddComponent<DecalProjector>();
		}

		protected override void OnInitializePooledObject(ICraftDecal decal, DecalTargetScript target)
		{
			base.OnInitializePooledObject(decal, target);
			TextureDecal = (ICraftTextureDecal)decal;
			DecalProjector.material = TextureDecal.RequestDecalMaterial();
			DecalProjector.enabled = true;
		}

		protected override void OnRefreshRenderer()
		{
			base.OnRefreshRenderer();
			ICraftTextureDecal textureDecal = TextureDecal;
			DecalProjector.renderingLayerMask = DecalLayers.DecalTargetIdToLayerMask(base.DecalTarget.DecalTargetId);
			if (!base.DecalTarget.DecalToTargetMatrix.HasValue)
			{
				base.Transform.SetPositionAndRotation(textureDecal.CraftPosition, textureDecal.CraftRotation);
			}
			else
			{
				Matrix4x4 value = base.DecalTarget.DecalToTargetMatrix.Value;
				base.Transform.SetLocalPositionAndRotation(value.MultiplyPoint3x4(textureDecal.CraftPosition), value.rotation * textureDecal.CraftRotation);
			}
			bool flag = false;
			if (!Utilities.CompareVector3s(DecalProjector.size, textureDecal.Size, 0.001f))
			{
				DecalProjector.size = textureDecal.Size;
				flag = true;
			}
			Vector3 vector = new Vector3(0f, 0f, textureDecal.Size.z / 2f);
			if (!Utilities.CompareVector3s(DecalProjector.pivot, vector, 0.001f))
			{
				DecalProjector.pivot = vector;
				flag = true;
			}
			if (!Utilities.CompareVector2s(DecalProjector.uvScale, textureDecal.TextureTiling, 0.001f))
			{
				DecalProjector.uvScale = textureDecal.TextureTiling;
				flag = true;
			}
			if (!Utilities.CompareVector2s(DecalProjector.uvBias, textureDecal.TextureOffset, 0.001f))
			{
				DecalProjector.uvBias = textureDecal.TextureOffset;
				flag = true;
			}
			float num = 300f * ((textureDecal.Size.x + textureDecal.Size.y) * 0.5f);
			if (!Utilities.CompareFloats(DecalProjector.drawDistance, num, 0.001f))
			{
				DecalProjector.drawDistance = num;
				flag = true;
			}
			if (!flag)
			{
				DecalProjector.material = DecalProjector.material;
			}
		}

		protected override void OnResetPooledObject()
		{
			base.OnResetPooledObject();
			if (TextureDecal != null)
			{
				TextureDecal.ReleaseDecalMaterial(DecalProjector.material);
			}
			TextureDecal = null;
			DecalProjector.material = null;
		}
	}
}
