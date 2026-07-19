using System;
using System.Collections.Generic;
using System.Linq;
using UniGLTF;
using UniHumanoid;
using UnityEngine;

namespace VRM
{
	public class VRMExporter : gltfExporter
	{
		protected override IMaterialExporter CreateMaterialExporter()
		{
			return new VRMMaterialExporter();
		}

		public VRMExporter(glTF gltf)
			: base(gltf)
		{
			gltf.extensionsUsed.Add(glTF_VRM_extensions.ExtensionName);
			gltf.extensions.VRM = new glTF_VRM_extensions();
		}

		public static glTF Export(GameObject go, bool exportOnlyBlendShapePosition = false)
		{
			VRMExporterConfiguration configuration = VRMExporterConfiguration.Default;
			configuration.ExportOnlyBlendShapePosition = exportOnlyBlendShapePosition;
			return Export(go, configuration);
		}

		public static glTF Export(GameObject go, VRMExporterConfiguration configuration)
		{
			glTF glTF2 = new glTF();
			using VRMExporter exporter = new VRMExporter(glTF2)
			{
				UseSparseAccessorForBlendShape = configuration.UseSparseAccessorForBlendShape,
				ExportOnlyBlendShapePosition = configuration.ExportOnlyBlendShapePosition,
				RemoveVertexColor = configuration.RemoveVertexColor
			};
			_Export(glTF2, exporter, go);
			return glTF2;
		}

		public static void _Export(glTF gltf, VRMExporter exporter, GameObject go)
		{
			exporter.Prepare(go);
			exporter.Export();
			Animator component = go.GetComponent<Animator>();
			if (component != null)
			{
				VRMHumanoidDescription component2 = go.GetComponent<VRMHumanoidDescription>();
				AvatarDescription avatarDescription = null;
				List<Transform> list = UniGLTF.UnityExtensions.Traverse(go.transform).Skip(1).ToList();
				bool isCreated = false;
				if (component2 != null)
				{
					avatarDescription = component2.GetDescription(out isCreated);
				}
				if (avatarDescription != null)
				{
					gltf.extensions.VRM.humanoid.Apply(avatarDescription, list);
				}
				if (isCreated)
				{
					UnityEngine.Object.DestroyImmediate(avatarDescription);
				}
				_ = component.avatar;
				foreach (HumanBodyBones value in Enum.GetValues(typeof(HumanBodyBones)))
				{
					if (value == HumanBodyBones.LastBone)
					{
						break;
					}
					Transform boneTransform = component.GetBoneTransform(value);
					if (boneTransform != null)
					{
						gltf.extensions.VRM.humanoid.SetNodeIndex(value, list.IndexOf(boneTransform));
					}
				}
			}
			VRMBlendShapeProxy component3 = go.GetComponent<VRMBlendShapeProxy>();
			if (component3 != null)
			{
				BlendShapeAvatar blendShapeAvatar = component3.BlendShapeAvatar;
				if (blendShapeAvatar != null)
				{
					foreach (BlendShapeClip clip in blendShapeAvatar.Clips)
					{
						gltf.extensions.VRM.blendShapeMaster.Add(clip, exporter);
					}
				}
			}
			VRMSpringUtility.ExportSecondary(exporter.Copy.transform, exporter.Nodes, delegate(glTF_VRM_SecondaryAnimationColliderGroup x)
			{
				gltf.extensions.VRM.secondaryAnimation.colliderGroups.Add(x);
			}, delegate(glTF_VRM_SecondaryAnimationGroup x)
			{
				gltf.extensions.VRM.secondaryAnimation.boneGroups.Add(x);
			});
			VRMMetaInformation component4 = exporter.Copy.GetComponent<VRMMetaInformation>();
			if (component4 != null)
			{
				gltf.extensions.VRM.meta.author = component4.Author;
				gltf.extensions.VRM.meta.contactInformation = component4.ContactInformation;
				gltf.extensions.VRM.meta.title = component4.Title;
				if (component4.Thumbnail != null)
				{
					gltf.extensions.VRM.meta.texture = TextureIO.ExportTexture(gltf, gltf.buffers.Count - 1, component4.Thumbnail, glTFTextureTypes.Unknown);
				}
				gltf.extensions.VRM.meta.licenseType = component4.LicenseType;
				gltf.extensions.VRM.meta.otherLicenseUrl = component4.OtherLicenseUrl;
				gltf.extensions.VRM.meta.reference = component4.Reference;
			}
			VRMMeta component5 = exporter.Copy.GetComponent<VRMMeta>();
			if (component5 != null && component5.Meta != null)
			{
				VRMMetaObject meta = component5.Meta;
				gltf.extensions.VRM.meta.version = meta.Version;
				gltf.extensions.VRM.meta.author = meta.Author;
				gltf.extensions.VRM.meta.contactInformation = meta.ContactInformation;
				gltf.extensions.VRM.meta.reference = meta.Reference;
				gltf.extensions.VRM.meta.title = meta.Title;
				if (meta.Thumbnail != null)
				{
					gltf.extensions.VRM.meta.texture = TextureIO.ExportTexture(gltf, gltf.buffers.Count - 1, meta.Thumbnail, glTFTextureTypes.Unknown);
				}
				gltf.extensions.VRM.meta.allowedUser = meta.AllowedUser;
				gltf.extensions.VRM.meta.violentUssage = meta.ViolentUssage;
				gltf.extensions.VRM.meta.sexualUssage = meta.SexualUssage;
				gltf.extensions.VRM.meta.commercialUssage = meta.CommercialUssage;
				gltf.extensions.VRM.meta.otherPermissionUrl = meta.OtherPermissionUrl;
				gltf.extensions.VRM.meta.licenseType = meta.LicenseType;
				if (meta.LicenseType == LicenseType.Other)
				{
					gltf.extensions.VRM.meta.otherLicenseUrl = meta.OtherLicenseUrl;
				}
			}
			VRMFirstPerson component6 = exporter.Copy.GetComponent<VRMFirstPerson>();
			if (component6 != null)
			{
				if (component6.FirstPersonBone != null)
				{
					gltf.extensions.VRM.firstPerson.firstPersonBone = exporter.Nodes.IndexOf(component6.FirstPersonBone);
					gltf.extensions.VRM.firstPerson.firstPersonBoneOffset = component6.FirstPersonOffset;
					gltf.extensions.VRM.firstPerson.meshAnnotations = component6.Renderers.Select((VRMFirstPerson.RendererFirstPersonFlags x) => new glTF_VRM_MeshAnnotation
					{
						mesh = exporter.Meshes.IndexOf(x.SharedMesh),
						firstPersonFlag = x.FirstPersonFlag.ToString()
					}).ToList();
				}
				if (exporter.Copy.GetComponent<VRMLookAtHead>() != null)
				{
					VRMLookAtBoneApplyer component7 = exporter.Copy.GetComponent<VRMLookAtBoneApplyer>();
					VRMLookAtBlendShapeApplyer component8 = exporter.Copy.GetComponent<VRMLookAtBlendShapeApplyer>();
					if (component7 != null)
					{
						gltf.extensions.VRM.firstPerson.lookAtType = LookAtType.Bone;
						gltf.extensions.VRM.firstPerson.lookAtHorizontalInner.Apply(component7.HorizontalInner);
						gltf.extensions.VRM.firstPerson.lookAtHorizontalOuter.Apply(component7.HorizontalOuter);
						gltf.extensions.VRM.firstPerson.lookAtVerticalDown.Apply(component7.VerticalDown);
						gltf.extensions.VRM.firstPerson.lookAtVerticalUp.Apply(component7.VerticalUp);
					}
					else if (component8 != null)
					{
						gltf.extensions.VRM.firstPerson.lookAtType = LookAtType.BlendShape;
						gltf.extensions.VRM.firstPerson.lookAtHorizontalOuter.Apply(component8.Horizontal);
						gltf.extensions.VRM.firstPerson.lookAtVerticalDown.Apply(component8.VerticalDown);
						gltf.extensions.VRM.firstPerson.lookAtVerticalUp.Apply(component8.VerticalUp);
					}
				}
			}
			foreach (Material material in exporter.Materials)
			{
				gltf.extensions.VRM.materialProperties.Add(VRMMaterialExporter.CreateFromMaterial(material, exporter.TextureManager.Textures));
			}
		}
	}
}
