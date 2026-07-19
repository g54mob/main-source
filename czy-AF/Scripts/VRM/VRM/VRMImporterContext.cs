using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UniGLTF;
using UniHumanoid;
using UnityEngine;

namespace VRM
{
	public class VRMImporterContext : UniGLTF.ImporterContext
	{
		private const string HUMANOID_KEY = "humanoid";

		private const string MATERIAL_KEY = "materialProperties";

		public AvatarDescription AvatarDescription;

		public Avatar HumanoidAvatar;

		public BlendShapeAvatar BlendShapeAvatar;

		public VRMMetaObject Meta;

		public override void Parse(string path, byte[] bytes)
		{
			if (Path.GetExtension(path).ToLower() == ".vrm")
			{
				ParseGlb(bytes);
			}
			else
			{
				base.Parse(path, bytes);
			}
		}

		public override void ParseJson(string json, IStorage storage)
		{
			base.ParseJson(json, storage);
			SetMaterialImporter(new VRMMaterialImporter(this, glTF_VRM_Material.Parse(Json)));
		}

		protected override IEnumerator OnLoadModel()
		{
			Root.name = "VRM";
			using (MeasureTime("VRM LoadMeta"))
			{
				LoadMeta();
			}
			yield return null;
			using (MeasureTime("VRM LoadHumanoid"))
			{
				LoadHumanoid();
			}
			yield return null;
			using (MeasureTime("VRM LoadBlendShapeMaster"))
			{
				LoadBlendShapeMaster();
			}
			yield return null;
			using (MeasureTime("VRM LoadSecondary"))
			{
				VRMSpringUtility.LoadSecondary(Root.transform, Nodes, GLTF.extensions.VRM.secondaryAnimation);
			}
			yield return null;
			using (MeasureTime("VRM LoadFirstPerson"))
			{
				LoadFirstPerson();
			}
		}

		private void LoadMeta()
		{
			VRMMetaObject vRMMetaObject = ReadMeta();
			_ = vRMMetaObject.Thumbnail == null;
			Root.AddComponent<VRMMeta>().Meta = vRMMetaObject;
			Meta = vRMMetaObject;
		}

		private void LoadFirstPerson()
		{
			VRMFirstPerson vRMFirstPerson = Root.AddComponent<VRMFirstPerson>();
			glTF_VRM_Firstperson firstPerson = GLTF.extensions.VRM.firstPerson;
			if (firstPerson.firstPersonBone != -1)
			{
				vRMFirstPerson.FirstPersonBone = Nodes[firstPerson.firstPersonBone];
				vRMFirstPerson.FirstPersonOffset = firstPerson.firstPersonBoneOffset;
			}
			else
			{
				vRMFirstPerson.SetDefault();
				vRMFirstPerson.FirstPersonOffset = firstPerson.firstPersonBoneOffset;
			}
			vRMFirstPerson.TraverseRenderers(this);
			Root.AddComponent<VRMLookAtHead>().OnImported(this);
		}

		private void LoadBlendShapeMaster()
		{
			BlendShapeAvatar = ScriptableObject.CreateInstance<BlendShapeAvatar>();
			BlendShapeAvatar.name = "BlendShape";
			Dictionary<Mesh, Transform> dictionary = new Dictionary<Mesh, Transform>();
			foreach (Transform item in UniGLTF.UnityExtensions.Traverse(Root.transform))
			{
				if (item.GetSharedMesh() != null)
				{
					dictionary.Add(item.GetSharedMesh(), item);
				}
			}
			List<glTF_VRM_BlendShapeGroup> blendShapeGroups = GLTF.extensions.VRM.blendShapeMaster.blendShapeGroups;
			if (blendShapeGroups != null && blendShapeGroups.Count > 0)
			{
				foreach (glTF_VRM_BlendShapeGroup item2 in blendShapeGroups)
				{
					BlendShapeAvatar.Clips.Add(LoadBlendShapeBind(item2, dictionary));
				}
			}
			VRMBlendShapeProxy vRMBlendShapeProxy = Root.AddComponent<VRMBlendShapeProxy>();
			BlendShapeAvatar.CreateDefaultPreset();
			vRMBlendShapeProxy.BlendShapeAvatar = BlendShapeAvatar;
		}

		private BlendShapeClip LoadBlendShapeBind(glTF_VRM_BlendShapeGroup group, Dictionary<Mesh, Transform> transformMeshTable)
		{
			BlendShapeClip blendShapeClip = ScriptableObject.CreateInstance<BlendShapeClip>();
			string text = group.name;
			string text2 = "BlendShape.";
			while (text.StartsWith(text2))
			{
				text = text.Substring(text2.Length);
			}
			blendShapeClip.name = "BlendShape." + text;
			if (group != null)
			{
				blendShapeClip.BlendShapeName = text;
				blendShapeClip.Preset = CacheEnum.TryParseOrDefault(group.presetName, ignoreCase: true, BlendShapePreset.Unknown);
				blendShapeClip.IsBinary = group.isBinary;
				if (blendShapeClip.Preset == BlendShapePreset.Unknown)
				{
					blendShapeClip.Preset = CacheEnum.TryParseOrDefault(group.name, ignoreCase: true, BlendShapePreset.Unknown);
				}
				blendShapeClip.Values = group.binds.Select(delegate(glTF_VRM_BlendShapeBind x)
				{
					Mesh mesh = Meshes[x.mesh].Mesh;
					string relativePath = transformMeshTable[mesh].RelativePathFrom(Root.transform);
					return new BlendShapeBinding
					{
						RelativePath = relativePath,
						Index = x.index,
						Weight = x.weight
					};
				}).ToArray();
				blendShapeClip.MaterialValues = (from x in @group.materialValues.Select(delegate(glTF_VRM_MaterialValueBind x)
					{
						Vector4 targetValue = default(Vector4);
						for (int i = 0; i < x.targetValue.Length; i++)
						{
							switch (i)
							{
							case 0:
								targetValue.x = x.targetValue[0];
								break;
							case 1:
								targetValue.y = x.targetValue[1];
								break;
							case 2:
								targetValue.z = x.targetValue[2];
								break;
							case 3:
								targetValue.w = x.targetValue[3];
								break;
							}
						}
						Material material = GetMaterials().FirstOrDefault((Material y) => y.name == x.materialName);
						string name = x.propertyName;
						if (x.propertyName.EndsWith("_ST_S") || x.propertyName.EndsWith("_ST_T"))
						{
							name = x.propertyName.Substring(0, x.propertyName.Length - 2);
						}
						MaterialValueBinding? result = null;
						if (material != null)
						{
							try
							{
								result = new MaterialValueBinding
								{
									MaterialName = x.materialName,
									ValueName = x.propertyName,
									TargetValue = targetValue,
									BaseValue = material.GetColor(name)
								};
								return result;
							}
							catch (Exception)
							{
							}
						}
						return result;
					})
					where x.HasValue
					select x.Value).ToArray();
			}
			return blendShapeClip;
		}

		private static string ToHumanBoneName(HumanBodyBones b)
		{
			string[] boneName = HumanTrait.BoneName;
			foreach (string text in boneName)
			{
				if (text.Replace(" ", "") == b.ToString())
				{
					return text;
				}
			}
			throw new KeyNotFoundException();
		}

		private static SkeletonBone ToSkeletonBone(Transform t)
		{
			return new SkeletonBone
			{
				name = t.name,
				position = t.localPosition,
				rotation = t.localRotation,
				scale = t.localScale
			};
		}

		private void LoadHumanoid()
		{
			AvatarDescription = GLTF.extensions.VRM.humanoid.ToDescription(Nodes);
			AvatarDescription.name = "AvatarDescription";
			HumanoidAvatar = AvatarDescription.CreateAvatar(Root.transform);
			if (!HumanoidAvatar.isValid || !HumanoidAvatar.isHuman)
			{
				throw new Exception("fail to create avatar");
			}
			HumanoidAvatar.name = "VrmAvatar";
			VRMHumanoidDescription vRMHumanoidDescription = Root.AddComponent<VRMHumanoidDescription>();
			vRMHumanoidDescription.Avatar = HumanoidAvatar;
			vRMHumanoidDescription.Description = AvatarDescription;
			Animator animator = Root.GetComponent<Animator>();
			if (animator == null)
			{
				animator = Root.AddComponent<Animator>();
			}
			animator.avatar = HumanoidAvatar;
		}

		public VRMMetaObject ReadMeta(bool createThumbnail = false)
		{
			VRMMetaObject vRMMetaObject = ScriptableObject.CreateInstance<VRMMetaObject>();
			vRMMetaObject.name = "Meta";
			vRMMetaObject.ExporterVersion = GLTF.extensions.VRM.exporterVersion;
			glTF_VRM_Meta meta = GLTF.extensions.VRM.meta;
			vRMMetaObject.Version = meta.version;
			vRMMetaObject.Author = meta.author;
			vRMMetaObject.ContactInformation = meta.contactInformation;
			vRMMetaObject.Reference = meta.reference;
			vRMMetaObject.Title = meta.title;
			TextureItem texture = GetTexture(meta.texture);
			if (texture != null)
			{
				vRMMetaObject.Thumbnail = texture.Texture;
			}
			else if (createThumbnail && meta.texture >= 0 && meta.texture < GLTF.textures.Count)
			{
				TextureItem textureItem = new TextureItem(meta.texture, CreateTextureLoader(meta.texture));
				textureItem.Process(GLTF, Storage);
				vRMMetaObject.Thumbnail = textureItem.Texture;
			}
			vRMMetaObject.AllowedUser = meta.allowedUser;
			vRMMetaObject.ViolentUssage = meta.violentUssage;
			vRMMetaObject.SexualUssage = meta.sexualUssage;
			vRMMetaObject.CommercialUssage = meta.commercialUssage;
			vRMMetaObject.OtherPermissionUrl = meta.otherPermissionUrl;
			vRMMetaObject.LicenseType = meta.licenseType;
			vRMMetaObject.OtherLicenseUrl = meta.otherLicenseUrl;
			return vRMMetaObject;
		}

		protected override IEnumerable<UnityEngine.Object> ObjectsForSubAsset()
		{
			foreach (UnityEngine.Object item in base.ObjectsForSubAsset())
			{
				yield return item;
			}
			yield return AvatarDescription;
			yield return HumanoidAvatar;
			if (BlendShapeAvatar != null && BlendShapeAvatar.Clips != null)
			{
				foreach (BlendShapeClip clip in BlendShapeAvatar.Clips)
				{
					yield return clip;
				}
			}
			yield return BlendShapeAvatar;
			yield return Meta;
		}
	}
}
