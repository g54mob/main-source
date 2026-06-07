using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using AOT;
using STB;
using UnityEngine;
using UnityEngine.Rendering;

namespace TriLib
{
	public class AssetLoaderBase : IDisposable
	{
		protected const string AssimpFilenameMagicString = "$$$___magic___$$$";

		public NodeData RootNodeData;

		public MaterialData[] MaterialData;

		public MeshData[] MeshData;

		public AnimationData[] AnimationData;

		public CameraData[] CameraData;

		public AssimpMetadata[] Metadata;

		public Dictionary<string, string> NodesPath;

		public Dictionary<string, Material> LoadedMaterials;

		public Dictionary<string, Texture2D> LoadedTextures;

		public Dictionary<SkinnedMeshRenderer, IList<string>> LoadedBoneNames;

		public Dictionary<string, MeshData> MeshDataConnections;

		public Dictionary<string, EmbeddedTextureData> EmbeddedTextures;

		public static ConcurrentList<FileLoadData> FilesLoadData;

		public static Material StandardBaseMaterial;

		public static Material StandardSpecularMaterial;

		public static Material StandardBaseAlphaMaterial;

		public static Material StandardSpecularAlphaMaterial;

		public static Material StandardBaseCutoutMaterial;

		public static Material StandardBaseFadeMaterial;

		public static Material StandardSpecularCutoutMaterial;

		public static Material StandardSpecularFadeMaterial;

		public static Material StandardRoughnessMaterial;

		public static Material StandardRoughnessCutoutMaterial;

		public static Material StandardRoughnessFadeMaterial;

		public static Material StandardRoughnessAlphaMaterial;

		public static Texture2D NotFoundTexture;

		public uint NodeId;

		public bool HasBoneInfo;

		public bool HasBlendShapes;

		protected IntPtr Scene;

		protected bool HasOnMeshCreated => this.OnMeshCreated != null;

		protected bool HasOnMaterialCreated => this.OnMaterialCreated != null;

		protected bool HasOnTextureLoaded => this.OnTextureLoaded != null;

		public bool HasOnAvatarCreated => this.OnAvatarCreated != null;

		protected bool HasOnAnimationClipCreated => this.OnAnimationClipCreated != null;

		protected bool HasOnObjectLoaded => this.OnObjectLoaded != null;

		protected bool HasOnMetadataProcessed => this.OnMetadataProcessed != null;

		protected bool HasOnBlendShapeKeyCreated => this.OnBlendShapeKeyCreated != null;

		[Obsolete("Please use the loadTextureDataCallback callback from AssetLoader classes loading methods instead.")]
		public event EmbeddedTextureLoadCallback EmbeddedTextureLoad;

		public event MeshCreatedHandle OnMeshCreated;

		public event MaterialCreatedHandle OnMaterialCreated;

		public event TextureLoadHandle OnTextureLoaded;

		public event AvatarCreatedHandle OnAvatarCreated;

		public event AnimationClipCreatedHandle OnAnimationClipCreated;

		public event ObjectLoadedHandle OnObjectLoaded;

		public event MetadataProcessedHandle OnMetadataProcessed;

		public event BlendShapeKeyCreatedHandle OnBlendShapeKeyCreated;

		protected void TriggerOnMeshCreated(uint meshIndex, Mesh mesh)
		{
			if (this.OnMeshCreated != null)
			{
				this.OnMeshCreated(meshIndex, mesh);
			}
		}

		protected void TriggerOnMaterialCreated(uint materialIndex, bool isOverriden, Material material)
		{
			if (this.OnMaterialCreated != null)
			{
				this.OnMaterialCreated(materialIndex, isOverriden, material);
			}
		}

		protected void TriggerOnTextureLoaded(string sourcePath, Material material, string propertyName, Texture2D texture)
		{
			if (this.OnTextureLoaded != null)
			{
				this.OnTextureLoaded(sourcePath, material, propertyName, texture);
			}
		}

		public void TriggerOnAvatarCreated(Avatar avatar, Animator animator)
		{
			if (this.OnAvatarCreated != null)
			{
				this.OnAvatarCreated(avatar, animator);
			}
		}

		protected void TriggerOnAnimationClipCreated(uint animationClipIndex, AnimationClip animationClip)
		{
			if (this.OnAnimationClipCreated != null)
			{
				this.OnAnimationClipCreated(animationClipIndex, animationClip);
			}
		}

		protected void TriggerOnObjectLoaded(GameObject loadedGameObject)
		{
			if (this.OnObjectLoaded != null)
			{
				this.OnObjectLoaded(loadedGameObject);
			}
		}

		protected void TriggerOnMetadataProcessed(AssimpMetadataType metadataType, uint metadataIndex, string metadataKey, object metadataValue)
		{
			if (this.OnMetadataProcessed != null)
			{
				this.OnMetadataProcessed(metadataType, metadataIndex, metadataKey, metadataValue);
			}
		}

		protected void TriggerOnBlendShapeKeyCreated(Mesh mesh, string name, Vector3[] vertices, Vector3[] normals, Vector4[] tangents, Vector4[] biTangents)
		{
			if (this.OnBlendShapeKeyCreated != null)
			{
				this.OnBlendShapeKeyCreated(mesh, name, vertices, normals, tangents, biTangents);
			}
		}

		public static bool IsExtensionSupported(string extension)
		{
			return AssimpInterop.ai_IsExtensionSupported(extension);
		}

		public static string GetSupportedFileExtensions()
		{
			AssimpInterop.ai_GetExtensionList(out var strExtensionList);
			return strExtensionList;
		}

		static AssetLoaderBase()
		{
			FilesLoadData = new ConcurrentList<FileLoadData>();
			LoadAllStandardMaterials();
		}

		private static void LoadAllStandardMaterials()
		{
			if (!LoadNotFoundTexture())
			{
				throw new Exception("Please import 'NotFound' asset from TriLib package 'TriLib\\Resources' to the project.");
			}
			if (!LoadStandardMaterials())
			{
				throw new Exception("Please import all material assets from TriLib package 'TriLib\\Resources' to the project.");
			}
		}

		private static bool LoadStandardMaterials()
		{
			if (StandardBaseMaterial == null)
			{
				StandardBaseMaterial = Resources.Load("StandardMaterial") as Material;
			}
			if (StandardBaseAlphaMaterial == null)
			{
				StandardBaseAlphaMaterial = Resources.Load("StandardBaseAlphaMaterial") as Material;
			}
			if (StandardBaseCutoutMaterial == null)
			{
				StandardBaseCutoutMaterial = Resources.Load("StandardBaseCutoutMaterial") as Material;
			}
			if (StandardBaseFadeMaterial == null)
			{
				StandardBaseFadeMaterial = Resources.Load("StandardBaseFadeMaterial") as Material;
			}
			if (StandardSpecularMaterial == null)
			{
				StandardSpecularMaterial = Resources.Load("StandardSpecularMaterial") as Material;
			}
			if (StandardSpecularAlphaMaterial == null)
			{
				StandardSpecularAlphaMaterial = Resources.Load("StandardSpecularAlphaMaterial") as Material;
			}
			if (StandardSpecularCutoutMaterial == null)
			{
				StandardSpecularCutoutMaterial = Resources.Load("StandardSpecularCutoutMaterial") as Material;
			}
			if (StandardSpecularFadeMaterial == null)
			{
				StandardSpecularFadeMaterial = Resources.Load("StandardSpecularFadeMaterial") as Material;
			}
			if (StandardRoughnessMaterial == null)
			{
				StandardRoughnessMaterial = Resources.Load("StandardRoughnessMaterial") as Material;
			}
			if (StandardRoughnessAlphaMaterial == null)
			{
				StandardRoughnessAlphaMaterial = Resources.Load("StandardRoughnessAlphaMaterial") as Material;
			}
			if (StandardRoughnessCutoutMaterial == null)
			{
				StandardRoughnessCutoutMaterial = Resources.Load("StandardRoughnessCutoutMaterial") as Material;
			}
			if (StandardRoughnessFadeMaterial == null)
			{
				StandardRoughnessFadeMaterial = Resources.Load("StandardRoughnessFadeMaterial") as Material;
			}
			if (StandardBaseMaterial != null && StandardBaseAlphaMaterial != null && StandardBaseCutoutMaterial != null && StandardBaseFadeMaterial != null && StandardSpecularMaterial != null && StandardSpecularAlphaMaterial != null && StandardSpecularCutoutMaterial != null && StandardSpecularFadeMaterial != null && StandardRoughnessMaterial != null && StandardRoughnessCutoutMaterial != null && StandardRoughnessAlphaMaterial != null)
			{
				return StandardRoughnessFadeMaterial != null;
			}
			return false;
		}

		private static bool LoadNotFoundTexture()
		{
			if (NotFoundTexture == null)
			{
				NotFoundTexture = Resources.Load("NotFound") as Texture2D;
			}
			return NotFoundTexture != null;
		}

		protected void InternalLoadFromMemory(byte[] fileBytes, string filename, string basePath, AssetLoaderOptions options = null, bool usesWrapperGameObject = false, AssimpInterop.DataCallback dataCallback = null, AssimpInterop.ExistsCallback existsCallback = null, LoadTextureDataCallback loadTextureDataCallback = null, AssimpInterop.ProgressCallback progressCallback = null, FileLoadData customFileLoadData = null)
		{
			Dispose();
			FileLoadData value = customFileLoadData ?? new GCFileLoadData
			{
				Filename = filename,
				BasePath = basePath
			};
			int count = FilesLoadData.Count;
			FilesLoadData.Add(value);
			try
			{
				Scene = ImportFileFromMemory(fileBytes, FileUtils.GetFileExtension(filename), options, dataCallback ?? new AssimpInterop.DataCallback(DefaultDataCallback), existsCallback ?? new AssimpInterop.ExistsCallback(DefaultExistsCallback), count, progressCallback);
			}
			catch (Exception innerException)
			{
				throw new Exception("Error parsing file.", innerException);
			}
			if (Scene == IntPtr.Zero)
			{
				string arg = AssimpInterop.ai_GetErrorString();
				throw new Exception($"Error loading asset. Assimp returns: [{arg}]");
			}
			LoadInternal(basePath, options, usesWrapperGameObject, loadTextureDataCallback);
			FilesLoadData[count] = null;
		}

		protected void InternalLoadFromMemoryAndZip(byte[] data, string assetExtension, string basePath, AssetLoaderOptions options = null, bool usesWrapperGameObject = false, AssimpInterop.DataCallback dataCallback = null, AssimpInterop.ExistsCallback existsCallback = null, LoadTextureDataCallback loadTextureDataCallback = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			FileLoadData customFileLoadData = null;
			InternalLoadFromMemory(data, assetExtension, basePath, options, usesWrapperGameObject, dataCallback, existsCallback, loadTextureDataCallback, progressCallback, customFileLoadData);
		}

		protected void InternalLoadFromFile(string filename, string basePath, AssetLoaderOptions options = null, bool usesWrapperGameObject = false, AssimpInterop.ProgressCallback progressCallback = null)
		{
			Dispose();
			try
			{
				Scene = ImportFile(filename, options, progressCallback);
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error parsing file: {filename}", innerException);
			}
			if (Scene == IntPtr.Zero)
			{
				string arg = AssimpInterop.ai_GetErrorString();
				throw new Exception($"Error loading asset. Assimp returns: [{arg}]");
			}
			LoadInternal(basePath, options, usesWrapperGameObject);
		}

		protected GameObject BuildGameObject(AssetLoaderOptions options, string basePath = null, GameObject wrapperGameObject = null)
		{
			if (HasOnMetadataProcessed && Metadata != null && (options == null || !options.DontLoadMetadata))
			{
				AssimpMetadata[] metadata = Metadata;
				foreach (AssimpMetadata metadata2 in metadata)
				{
					ProcessMetadata(metadata2);
				}
			}
			if (MaterialData != null && (options == null || !options.DontLoadMaterials))
			{
				LoadAllStandardMaterials();
				LoadedMaterials = new Dictionary<string, Material>();
				LoadedTextures = new Dictionary<string, Texture2D>();
				MaterialData[] materialData = MaterialData;
				foreach (MaterialData materialData2 in materialData)
				{
					TransformMaterialData(materialData2, options, basePath);
				}
			}
			if (MeshData != null && (options == null || !options.DontLoadMeshes))
			{
				MeshData[] meshData = MeshData;
				foreach (MeshData meshData2 in meshData)
				{
					TransformMeshData(meshData2, options);
				}
			}
			GameObject gameObject = null;
			GameObject gameObject2 = null;
			if (RootNodeData != null)
			{
				if (options != null && options.UseOriginalPositionRotationAndScale)
				{
					gameObject = new GameObject();
				}
				else
				{
					Debug.LogWarning("Deprecation warning: Please use an AssetLoaderOptions instance when loading your model, and set it's UseOriginalPositionRotationAndScale field to true.\nThis new field ensures your model will use the original model local position, rotation and scale, by adding a wrapper on top of the loaded GameObject.");
				}
				gameObject2 = TransformNodeData(RootNodeData, options, gameObject ?? wrapperGameObject);
				if (gameObject2 != null)
				{
					if (LoadedBoneNames != null && LoadedBoneNames.Count > 0)
					{
						SetupSkinnedMeshRendererTransforms(gameObject2);
					}
					if (gameObject == null)
					{
						LoadContextOptions(gameObject2, options);
					}
					else
					{
						gameObject.name = $"{gameObject2.name}_Wrapper";
						gameObject.transform.SetParent((wrapperGameObject != null) ? wrapperGameObject.transform : gameObject2.transform, worldPositionStays: false);
						LoadContextOptions(gameObject, options);
					}
				}
			}
			if (AnimationData != null && (options == null || !options.DontLoadAnimations))
			{
				AnimationData[] animationData = AnimationData;
				foreach (AnimationData animationData2 in animationData)
				{
					TransformAnimationData(animationData2, options, gameObject2, gameObject != null || wrapperGameObject != null);
				}
			}
			GameObject gameObject3 = gameObject ?? wrapperGameObject ?? gameObject2;
			GameObject gameObject4 = gameObject ?? gameObject2;
			if (gameObject2 != null)
			{
				if (options == null || !options.DontApplyAnimations)
				{
					SetupAnimations(gameObject3, options);
				}
				if (CameraData != null && (options == null || !options.DontLoadCameras))
				{
					CameraData[] cameraData = CameraData;
					foreach (CameraData cameraData2 in cameraData)
					{
						TransformCameraData(gameObject2, cameraData2, options);
					}
				}
				if (options != null && options.AddAssetUnloader)
				{
					gameObject3.AddComponent<AssetUnloader>();
				}
				if (HasOnObjectLoaded)
				{
					TriggerOnObjectLoaded(gameObject4);
				}
			}
			return gameObject4;
		}

		protected virtual void SetupSkinnedMeshRendererTransforms(GameObject gameObject)
		{
			foreach (KeyValuePair<SkinnedMeshRenderer, IList<string>> loadedBoneName in LoadedBoneNames)
			{
				SkinnedMeshRenderer key = loadedBoneName.Key;
				IList<string> value = loadedBoneName.Value;
				int count = value.Count;
				List<Transform> list = new List<Transform>(count);
				Transform rootBone = key.transform;
				int num = 0;
				for (int i = 0; i < count; i++)
				{
					string text = value[i];
					if (text == null)
					{
						continue;
					}
					Transform transform = gameObject.transform.FindDeepChild(text);
					if (transform == null)
					{
						continue;
					}
					list.Add(transform);
					do
					{
						bool flag = false;
						Component[] components = transform.GetComponents(typeof(Component));
						for (int j = 0; j < components.Length; j++)
						{
							if (components[j].GetType() != typeof(Transform))
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
						int num2 = CountChild(transform);
						if (num2 > num)
						{
							rootBone = transform;
							num = num2;
						}
						transform = transform.parent;
					}
					while (!(transform == gameObject.transform) && !(transform == null));
				}
				key.rootBone = rootBone;
				key.bones = list.ToArray();
			}
		}

		private static void LoadContextOptions(GameObject gameObject, AssetLoaderOptions options)
		{
			gameObject.transform.rotation = Quaternion.Euler((options == null) ? new Vector3(0f, 180f, 0f) : options.RotationAngles);
			gameObject.transform.localScale = Vector3.one * ((options == null) ? 1f : options.Scale);
		}

		protected virtual void ProcessMetadata(AssimpMetadata metadata)
		{
			TriggerOnMetadataProcessed(metadata.MetadataType, metadata.MetadataIndex, metadata.MetadataKey, metadata.MetadataValue);
		}

		protected virtual void SetupAnimations(GameObject gameObject, AssetLoaderOptions options)
		{
			if (options == null || (options.UseLegacyAnimations && !options.DontLoadAnimations && ((AnimationData != null && AnimationData.Length != 0) || options.ForceAnimationComponents)))
			{
				Animation animation = gameObject.GetComponent<Animation>();
				if (animation == null)
				{
					animation = gameObject.AddComponent<Animation>();
				}
				AnimationClip clip = null;
				if (AnimationData != null)
				{
					for (int i = 0; i < AnimationData.Length; i++)
					{
						AnimationClip animationClip = AnimationData[i].AnimationClip;
						if (!(animationClip == null))
						{
							animation.AddClip(animationClip, animationClip.name);
							if (i == 0)
							{
								clip = animationClip;
							}
						}
					}
				}
				animation.clip = clip;
				if (options == null || options.AutoPlayAnimations)
				{
					animation.Play();
				}
			}
			else
			{
				if (options.DontLoadAnimations || ((AnimationData == null || AnimationData.Length == 0) && !options.ForceAnimationComponents))
				{
					return;
				}
				Animator animator = gameObject.GetComponent<Animator>();
				if (animator == null)
				{
					animator = gameObject.AddComponent<Animator>();
				}
				if (options.AnimatorController != null)
				{
					animator.runtimeAnimatorController = options.AnimatorController;
				}
				if (options.DontGenerateAvatar)
				{
					return;
				}
				if (options.Avatar != null)
				{
					animator.avatar = options.Avatar;
					return;
				}
				Avatar avatar = AvatarBuilder.BuildGenericAvatar(gameObject, "");
				avatar.name = FixName(gameObject.name);
				animator.avatar = avatar;
				if (HasOnAvatarCreated)
				{
					TriggerOnAvatarCreated(avatar, animator);
				}
			}
		}

		protected virtual GameObject TransformNodeData(NodeData nodeData, AssetLoaderOptions options, GameObject existingGameObject = null)
		{
			GameObject gameObject = new GameObject
			{
				name = nodeData.Name
			};
			if (nodeData.Metadata != null && (options == null || (!options.DontAddMetadataCollection && !options.DontLoadMetadata)))
			{
				AssimpMetadataCollection assimpMetadataCollection = gameObject.AddComponent<AssimpMetadataCollection>();
				AssimpMetadata[] metadata;
				if (nodeData == RootNodeData)
				{
					metadata = Metadata;
					foreach (AssimpMetadata assimpMetadata in metadata)
					{
						if (!assimpMetadataCollection.ContainsKey(assimpMetadata.MetadataKey))
						{
							assimpMetadataCollection.Add(assimpMetadata.MetadataKey, assimpMetadata);
						}
					}
				}
				metadata = nodeData.Metadata;
				foreach (AssimpMetadata assimpMetadata2 in metadata)
				{
					if (!assimpMetadataCollection.ContainsKey(assimpMetadata2.MetadataKey))
					{
						assimpMetadataCollection.Add(assimpMetadata2.MetadataKey, assimpMetadata2);
					}
				}
			}
			GameObject gameObject2 = ((existingGameObject != null) ? existingGameObject : ((nodeData.Parent == null) ? null : nodeData.Parent.GameObject));
			if (gameObject2 != null)
			{
				gameObject.transform.SetParent(gameObject2.transform, worldPositionStays: false);
			}
			gameObject.transform.LoadMatrix(nodeData.Matrix);
			if (nodeData.Meshes != null && nodeData.Meshes.Length != 0 && MeshData != null && MeshData.Length != 0)
			{
				int num = 0;
				uint[] meshes = nodeData.Meshes;
				foreach (uint num2 in meshes)
				{
					MeshData meshData = MeshData[num2];
					num += meshData.Vertices.Length;
				}
				bool flag = options == null || options.CombineMeshes;
				bool flag2 = num < 65536 && flag;
				bool flag3 = options == null || options.Use32BitsIndexFormat;
				bool flag4 = flag3 && flag;
				if (!HasBlendShapes && (flag4 || flag2))
				{
					Material material = null;
					List<string> list = null;
					bool flag5 = true;
					CombineInstance[] array = new CombineInstance[nodeData.Meshes.Length];
					Material[] array2 = new Material[nodeData.Meshes.Length];
					for (int j = 0; j < nodeData.Meshes.Length; j++)
					{
						uint num3 = nodeData.Meshes[j];
						if (num3 >= MeshData.Length)
						{
							continue;
						}
						MeshData meshData2 = MeshData[num3];
						if (meshData2.HasBoneInfo && meshData2.BoneNames.Length != 0)
						{
							if (list == null)
							{
								list = new List<string>();
							}
							list.AddRange(meshData2.BoneNames);
						}
						CombineInstance combineInstance = new CombineInstance
						{
							mesh = meshData2.Mesh,
							transform = Matrix4x4.identity
						};
						array[j] = combineInstance;
						if (MaterialData != null && MaterialData.Length != 0 && meshData2.MaterialIndex < MaterialData.Length)
						{
							Material material2 = MaterialData[meshData2.MaterialIndex].Material;
							if (material != null && material2 != material)
							{
								flag5 = false;
							}
							array2[j] = material2;
							material = material2;
						}
					}
					Mesh mesh = new Mesh();
					if (flag3)
					{
						mesh.indexFormat = IndexFormat.UInt32;
					}
					mesh.CombineMeshes(array, flag5);
					mesh.name = FixName(nodeData.Name);
					CreateMeshComponents(gameObject, options, mesh, HasBoneInfo || HasBlendShapes, array2, list, flag5 ? array2[0] : null);
				}
				else
				{
					for (int k = 0; k < nodeData.Meshes.Length; k++)
					{
						uint num4 = nodeData.Meshes[k];
						MeshData meshData3 = MeshData[num4];
						Material singleMaterial = ((MaterialData == null) ? null : MaterialData[meshData3.MaterialIndex].Material);
						string text = "SubMesh_" + k;
						GameObject gameObject3 = new GameObject
						{
							name = text
						};
						meshData3.SubMeshName = text;
						gameObject3.transform.SetParent(gameObject.transform, worldPositionStays: false);
						string connectionKey = gameObject.name + "*" + k;
						CreateMeshComponents(gameObject3, options, meshData3.Mesh, HasBoneInfo || HasBlendShapes, null, meshData3.BoneNames, singleMaterial, meshData3, connectionKey);
					}
				}
			}
			nodeData.GameObject = gameObject;
			if (nodeData.Children != null)
			{
				NodeData[] children = nodeData.Children;
				foreach (NodeData nodeData2 in children)
				{
					TransformNodeData(nodeData2, options);
				}
			}
			return gameObject;
		}

		private int CountChild(Transform transform)
		{
			int num = transform.childCount;
			foreach (Transform item in transform)
			{
				num += CountChild(item);
			}
			return num;
		}

		protected virtual void CreateMeshComponents(GameObject gameObject, AssetLoaderOptions options, Mesh mesh, bool hasBoneInfo, Material[] combinedMaterials, IList<string> boneNames = null, Material singleMaterial = null, MeshData meshData = null, string connectionKey = null)
		{
			if (hasBoneInfo && (options == null || !options.DontLoadSkinning))
			{
				SkinnedMeshRenderer skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();
				skinnedMeshRenderer.sharedMesh = mesh;
				skinnedMeshRenderer.quality = SkinQuality.Bone4;
				if (boneNames != null)
				{
					if (LoadedBoneNames == null)
					{
						LoadedBoneNames = new Dictionary<SkinnedMeshRenderer, IList<string>>();
					}
					LoadedBoneNames.Add(skinnedMeshRenderer, boneNames);
				}
				if (meshData != null && connectionKey != null)
				{
					if (MeshDataConnections == null)
					{
						MeshDataConnections = new Dictionary<string, MeshData>();
					}
					MeshDataConnections.Add(connectionKey, meshData);
				}
				if (singleMaterial != null)
				{
					skinnedMeshRenderer.sharedMaterial = singleMaterial;
				}
				else
				{
					skinnedMeshRenderer.sharedMaterials = combinedMaterials;
				}
			}
			else
			{
				gameObject.AddComponent<MeshFilter>().mesh = mesh;
				MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
				if (singleMaterial != null)
				{
					meshRenderer.sharedMaterial = singleMaterial;
				}
				else
				{
					meshRenderer.sharedMaterials = combinedMaterials;
				}
				if (options != null && options.GenerateMeshColliders)
				{
					MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
					meshCollider.sharedMesh = mesh;
					meshCollider.convex = options.ConvexMeshColliders;
				}
			}
			if (HasOnMeshCreated)
			{
				TriggerOnMeshCreated(0u, mesh);
			}
		}

		protected virtual void TransformCameraData(GameObject gameObject, CameraData cameraData, AssetLoaderOptions options)
		{
			Transform transform = gameObject.transform.FindDeepChild(cameraData.Name);
			if (!(transform == null))
			{
				Camera camera = transform.gameObject.AddComponent<Camera>();
				camera.aspect = cameraData.Aspect;
				camera.nearClipPlane = cameraData.NearClipPlane;
				camera.farClipPlane = cameraData.FarClipPlane;
				camera.fieldOfView = 57.29578f * cameraData.FieldOfView;
				camera.transform.localPosition = cameraData.LocalPosition;
				camera.transform.LookAt(cameraData.Forward, cameraData.Up);
				cameraData.Camera = camera;
			}
		}

		private static AnimationCurve FixCurve(float animationLength, AnimationCurve curve)
		{
			if (Mathf.Approximately(animationLength, 0f))
			{
				animationLength = 1f;
			}
			if (curve.keys.Length == 1)
			{
				curve.AddKey(new Keyframe(animationLength, curve.keys[0].value));
			}
			return curve;
		}

		protected virtual void TransformAnimationData(AnimationData animationData, AssetLoaderOptions options, GameObject gameObject, bool useWrapperGameObject = false)
		{
			AnimationClip animationClip = new AnimationClip
			{
				name = animationData.Name,
				frameRate = animationData.FrameRate,
				wrapMode = animationData.WrapMode,
				legacy = animationData.Legacy
			};
			AnimationChannelData[] channelData = animationData.ChannelData;
			foreach (AnimationChannelData animationChannelData in channelData)
			{
				if (!NodesPath.ContainsKey(animationChannelData.NodeName))
				{
					continue;
				}
				string text = NodesPath[animationChannelData.NodeName];
				if (useWrapperGameObject)
				{
					text = gameObject.name + "/" + text;
				}
				foreach (KeyValuePair<string, AnimationCurveData> curveDatum in animationChannelData.CurveData)
				{
					string key = curveDatum.Key;
					AnimationCurveData value = curveDatum.Value;
					animationClip.SetCurve(curve: value.AnimationCurve = FixCurve(animationData.Length, new AnimationCurve
					{
						keys = value.Keyframes
					}), relativePath: text, type: typeof(Transform), propertyName: key);
				}
			}
			if (animationData.MorphData.Length != 0)
			{
				MorphChannelData[] morphData = animationData.MorphData;
				foreach (MorphChannelData morphChannelData in morphData)
				{
					string text2 = (morphChannelData.NodeName.Contains("*") ? morphChannelData.NodeName : (morphChannelData.NodeName + "*0"));
					string key2 = text2.Substring(0, text2.LastIndexOf("*", StringComparison.Ordinal));
					if (MeshDataConnections == null || !MeshDataConnections.ContainsKey(text2) || !NodesPath.ContainsKey(key2))
					{
						continue;
					}
					MeshData meshData = MeshDataConnections[text2];
					string arg = NodesPath[key2];
					Dictionary<MorphData, List<Keyframe>> dictionary = new Dictionary<MorphData, List<Keyframe>>();
					foreach (KeyValuePair<float, MorphChannelKey> morphChannelKey in morphChannelData.MorphChannelKeys)
					{
						float key3 = morphChannelKey.Key;
						MorphChannelKey value2 = morphChannelKey.Value;
						for (int j = 0; j < value2.Indices.Length; j++)
						{
							uint num = value2.Indices[j];
							float value3 = value2.Weights[j];
							if (num <= meshData.MorphsData.Length)
							{
								MorphData key4 = meshData.MorphsData[num];
								List<Keyframe> list;
								if (dictionary.ContainsKey(key4))
								{
									list = dictionary[key4];
								}
								else
								{
									list = new List<Keyframe>();
									dictionary.Add(key4, list);
								}
								list.Add(new Keyframe(key3, value3));
							}
						}
					}
					foreach (KeyValuePair<MorphData, List<Keyframe>> item in dictionary)
					{
						AnimationCurve curve = FixCurve(animationData.Length, new AnimationCurve
						{
							keys = item.Value.ToArray()
						});
						animationClip.SetCurve($"{arg}/{meshData.SubMeshName}", typeof(SkinnedMeshRenderer), $"blendShape.{item.Key.Name}", curve);
					}
				}
			}
			if (options != null && options.EnsureQuaternionContinuity)
			{
				animationClip.EnsureQuaternionContinuity();
			}
			if (HasOnAnimationClipCreated)
			{
				TriggerOnAnimationClipCreated(0u, animationClip);
			}
			animationData.AnimationClip = animationClip;
		}

		protected virtual void TransformMeshData(MeshData meshData, AssetLoaderOptions options)
		{
			Mesh mesh = new Mesh();
			if (options == null || options.Use32BitsIndexFormat)
			{
				mesh.indexFormat = IndexFormat.UInt32;
			}
			mesh.name = meshData.Name;
			mesh.vertices = meshData.Vertices;
			mesh.normals = meshData.Normals;
			mesh.uv4 = meshData.Uv3;
			mesh.uv3 = meshData.Uv2;
			mesh.uv2 = meshData.Uv1;
			mesh.uv = meshData.Uv;
			mesh.tangents = meshData.Tangents;
			mesh.colors = meshData.Colors;
			mesh.boneWeights = meshData.BoneWeights;
			mesh.bindposes = meshData.BindPoses;
			mesh.triangles = meshData.Triangles;
			if ((options == null || !options.DontLoadBlendShapes) && meshData.MorphsData != null)
			{
				MorphData[] morphsData = meshData.MorphsData;
				foreach (MorphData morphData in morphsData)
				{
					mesh.AddBlendShapeFrame(morphData.Name, morphData.Weight, morphData.Vertices, morphData.Normals, morphData.Tangents);
					if (HasOnBlendShapeKeyCreated)
					{
						TriggerOnBlendShapeKeyCreated(mesh, meshData.Name, meshData.Vertices, meshData.Normals, meshData.Tangents, meshData.BiTangents);
					}
				}
			}
			meshData.Mesh = mesh;
		}

		protected virtual void TransformMaterialData(MaterialData materialData, AssetLoaderOptions options, string basePath = null)
		{
			bool hasAlphaChannel = false;
			bool hasAlphaChannel2 = false;
			Texture2D value = (materialData.DiffuseInfoLoaded ? LoadTextureFromFile(materialData.DiffusePath, materialData.Name, options, materialData.DiffuseEmbeddedTextureData, materialData.DiffuseWrapMode, ref hasAlphaChannel2, isNormalMap: false, options != null && (options.ScanForAlphaMaterials || options.ApplyAlphaMaterials)) : null);
			Texture2D value2 = (materialData.EmissionInfoLoaded ? LoadTextureFromFile(materialData.EmissionPath, materialData.Name, options, materialData.EmissionEmbeddedTextureData, materialData.EmissionWrapMode, ref hasAlphaChannel, isNormalMap: false) : null);
			Texture2D value3 = (materialData.SpecularInfoLoaded ? LoadTextureFromFile(materialData.SpecularPath, materialData.Name, options, materialData.SpecularEmbeddedTextureData, materialData.SpecularWrapMode, ref hasAlphaChannel, isNormalMap: false) : null);
			Texture2D value4 = (materialData.NormalInfoLoaded ? LoadTextureFromFile(materialData.NormalPath, materialData.Name, options, materialData.NormalEmbeddedTextureData, materialData.NormalWrapMode, ref hasAlphaChannel, isNormalMap: true) : null);
			Texture2D value5 = (materialData.HeightInfoLoaded ? LoadTextureFromFile(materialData.HeightPath, materialData.Name, options, materialData.HeightEmbeddedTextureData, materialData.HeightWrapMode, ref hasAlphaChannel, isNormalMap: false) : null);
			Texture2D value6 = (materialData.OcclusionInfoLoaded ? LoadTextureFromFile(materialData.OcclusionPath, materialData.Name, options, materialData.OcclusionEmbeddedTextureData, materialData.OcclusionWrapMode, ref hasAlphaChannel, isNormalMap: false) : null);
			Texture2D value7 = (materialData.MetallicInfoLoaded ? LoadTextureFromFile(materialData.MetallicPath, materialData.Name, options, materialData.MetallicEmbeddedTextureData, materialData.MetallicWrapMode, ref hasAlphaChannel, isNormalMap: false) : null);
			bool hasAlpha = hasAlphaChannel2 || (materialData.AlphaLoaded && materialData.Alpha < 1f);
			bool hasSpecular = materialData.SpecularColorLoaded || !string.IsNullOrEmpty(materialData.SpecularPath);
			Material material = LoadMaterial(materialData.Name, options, hasAlpha, hasSpecular);
			if (options == null || options.ApplyDiffuseTexture)
			{
				material.SetTexture("_MainTex", value);
			}
			else
			{
				material.SetTexture("_MainTex", null);
			}
			if (options == null || options.ApplyEmissionTexture)
			{
				material.SetTexture("_EmissionMap", value2);
			}
			else
			{
				material.SetTexture("_EmissionMap", null);
			}
			if (options == null || options.ApplySpecularTexture)
			{
				material.SetTexture("_SpecGlossMap", value3);
			}
			else
			{
				material.SetTexture("_SpecGlossMap", null);
			}
			if (options == null || options.ApplyNormalTexture)
			{
				material.SetTexture("_BumpMap", value4);
			}
			else
			{
				material.SetTexture("_BumpMap", null);
			}
			if (options == null || options.ApplyDisplacementTexture)
			{
				material.SetTexture("_Displacement", value5);
			}
			else
			{
				material.SetTexture("_Displacement", null);
			}
			if (options == null || options.ApplyOcclusionTexture)
			{
				material.SetTexture("_OcclusionMap", value6);
			}
			else
			{
				material.SetTexture("_OcclusionMap", null);
			}
			if (options == null || options.ApplyMetallicTexture)
			{
				material.SetTexture("_MetallicGlossMap", value7);
			}
			else
			{
				material.SetTexture("_MetallicGlossMap", null);
			}
			if ((options == null || options.ApplyDiffuseColor) && materialData.DiffuseColorLoaded)
			{
				Color diffuseColor = materialData.DiffuseColor;
				if ((options == null || (options.ApplyColorAlpha && !options.DisableAlphaMaterials)) && materialData.AlphaLoaded)
				{
					diffuseColor.a = materialData.Alpha;
				}
				material.SetColor("_Color", diffuseColor);
			}
			if ((options == null || options.ApplyEmissionColor) && materialData.EmissionColorLoaded)
			{
				material.SetColor("_EmissionColor", materialData.EmissionColor);
			}
			if ((options == null || options.ApplySpecularColor) && materialData.SpecularColorLoaded)
			{
				material.SetColor("_SpecColor", materialData.SpecularColor);
			}
			if ((options == null || options.ApplyNormalScale) && materialData.BumpScaleLoaded)
			{
				material.SetFloat("_BumpScale", materialData.BumpScale);
			}
			if ((options == null || options.ApplyGlossiness) && materialData.GlossinessLoaded)
			{
				material.SetFloat("_Glossiness", materialData.Glossiness);
			}
			if ((options == null || options.ApplyGlossinessScale) && materialData.GlossMapScaleLoaded)
			{
				material.SetFloat("_GlossMapScale", materialData.GlossMapScale);
			}
			materialData.Material = material;
		}

		protected virtual Material LoadMaterial(string name, AssetLoaderOptions options, bool hasAlpha, bool hasSpecular)
		{
			Material material;
			if (LoadedMaterials.ContainsKey(name))
			{
				material = LoadedMaterials[name];
			}
			else
			{
				MaterialShadingMode materialShadingMode = ((!(options == null)) ? (options.UseStandardSpecularMaterial ? MaterialShadingMode.Specular : options.MaterialShadingMode) : MaterialShadingMode.Standard);
				MaterialTransparencyMode materialTransparencyMode = ((options == null) ? MaterialTransparencyMode.Cutout : (options.UseCutoutMaterials ? MaterialTransparencyMode.Cutout : options.MaterialTransparencyMode));
				if (options != null && !options.DisableAlphaMaterials && hasAlpha)
				{
					switch (materialShadingMode)
					{
					case MaterialShadingMode.Roughness:
						switch (materialTransparencyMode)
						{
						case MaterialTransparencyMode.Alpha:
							material = new Material(StandardRoughnessAlphaMaterial);
							break;
						case MaterialTransparencyMode.Cutout:
							material = new Material(StandardRoughnessCutoutMaterial);
							break;
						default:
							material = new Material(StandardRoughnessFadeMaterial);
							break;
						}
						break;
					case MaterialShadingMode.Specular:
						switch (materialTransparencyMode)
						{
						case MaterialTransparencyMode.Alpha:
							material = new Material(StandardSpecularAlphaMaterial);
							break;
						case MaterialTransparencyMode.Cutout:
							material = new Material(StandardSpecularCutoutMaterial);
							break;
						default:
							material = new Material(StandardSpecularFadeMaterial);
							break;
						}
						break;
					default:
						switch (materialTransparencyMode)
						{
						case MaterialTransparencyMode.Alpha:
							material = new Material(StandardBaseAlphaMaterial);
							break;
						case MaterialTransparencyMode.Cutout:
							material = new Material(StandardBaseCutoutMaterial);
							break;
						default:
							material = new Material(StandardBaseFadeMaterial);
							break;
						}
						break;
					}
				}
				else
				{
					switch (materialShadingMode)
					{
					case MaterialShadingMode.Roughness:
						material = new Material(StandardRoughnessMaterial);
						break;
					case MaterialShadingMode.Specular:
						material = new Material(StandardSpecularMaterial);
						break;
					default:
						material = new Material(StandardBaseMaterial);
						break;
					}
				}
				material.name = name;
				LoadedMaterials.Add(name, material);
			}
			if (HasOnMaterialCreated)
			{
				TriggerOnMaterialCreated(0u, isOverriden: false, material);
			}
			return material;
		}

		protected virtual Texture2D LoadTextureFromFile(string path, string name, AssetLoaderOptions options, EmbeddedTextureData embeddedTextureData, TextureWrapMode textureWrapMode, ref bool hasAlphaChannel, bool isNormalMap, bool checkAlphaChannel = false)
		{
			Texture2D texture2D = null;
			if (LoadedTextures.ContainsKey(path))
			{
				texture2D = LoadedTextures[path];
			}
			else if (embeddedTextureData != null)
			{
				if (!checkAlphaChannel)
				{
					hasAlphaChannel = embeddedTextureData.NumChannels == 4;
				}
				texture2D = Texture2DUtils.ProcessTexture(embeddedTextureData, name, ref hasAlphaChannel, isNormalMap, textureWrapMode, (!(options != null)) ? FilterMode.Bilinear : options.TextureFilterMode, (!(options != null)) ? TextureCompression.NormalQuality : options.TextureCompression, checkAlphaChannel, options == null || options.GenerateMipMaps);
				if (texture2D != null)
				{
					LoadedTextures.Add(path, texture2D);
				}
			}
			if (texture2D != null && HasOnTextureLoaded)
			{
				TriggerOnTextureLoaded(path, null, null, texture2D);
			}
			return texture2D;
		}

		private static uint GetDefaultPostProcessSteps()
		{
			return 20351567u;
		}

		private static IntPtr BuildPropertyStore(AssetLoaderOptions options)
		{
			IntPtr intPtr = AssimpInterop.ai_CreatePropertyStore();
			foreach (AssetAdvancedConfig advancedConfig in options.AdvancedConfigs)
			{
				AssetAdvancedPropertyMetadata.GetOptionMetadata(advancedConfig.Key, out var assetAdvancedConfigType, out var _, out var _, out var _, out var _, out var _, out var _, out var _, out var _, out var _);
				switch (assetAdvancedConfigType)
				{
				case AssetAdvancedConfigType.AiComponent:
					AssimpInterop.ai_SetImportPropertyInteger(intPtr, advancedConfig.Key, advancedConfig.IntValue << 1);
					break;
				case AssetAdvancedConfigType.AiPrimitiveType:
					AssimpInterop.ai_SetImportPropertyInteger(intPtr, advancedConfig.Key, advancedConfig.IntValue << 1);
					break;
				case AssetAdvancedConfigType.AiUVTransform:
					AssimpInterop.ai_SetImportPropertyInteger(intPtr, advancedConfig.Key, advancedConfig.IntValue << 1);
					break;
				case AssetAdvancedConfigType.Bool:
					AssimpInterop.ai_SetImportPropertyInteger(intPtr, advancedConfig.Key, advancedConfig.BoolValue ? 1 : 0);
					break;
				case AssetAdvancedConfigType.Integer:
					AssimpInterop.ai_SetImportPropertyInteger(intPtr, advancedConfig.Key, advancedConfig.IntValue);
					break;
				case AssetAdvancedConfigType.Float:
					AssimpInterop.ai_SetImportPropertyFloat(intPtr, advancedConfig.Key, advancedConfig.FloatValue);
					break;
				case AssetAdvancedConfigType.String:
					AssimpInterop.ai_SetImportPropertyString(intPtr, advancedConfig.Key, advancedConfig.StringValue);
					break;
				case AssetAdvancedConfigType.AiMatrix:
					AssimpInterop.ai_SetImportPropertyMatrix(intPtr, advancedConfig.Key, advancedConfig.TranslationValue, advancedConfig.RotationValue, advancedConfig.ScaleValue);
					break;
				}
			}
			return intPtr;
		}

		private static IntPtr ImportFileFromMemory(byte[] fileBytes, string fileHint, AssetLoaderOptions options, AssimpInterop.DataCallback dataCallback, AssimpInterop.ExistsCallback existsCallback, int fileId, AssimpInterop.ProgressCallback progressCallback)
		{
			IntPtr result;
			if (options != null && options.AdvancedConfigs != null)
			{
				IntPtr intPtr = BuildPropertyStore(options);
				result = AssimpInterop.ai_ImportFileFromMemoryWithProperties(fileBytes, (uint)options.PostProcessSteps, fileHint, intPtr, dataCallback, existsCallback, fileId, progressCallback);
				AssimpInterop.ai_CreateReleasePropertyStore(intPtr);
			}
			else
			{
				result = AssimpInterop.ai_ImportFileFromMemory(fileBytes, (options == null) ? GetDefaultPostProcessSteps() : ((uint)options.PostProcessSteps), fileHint, dataCallback, existsCallback, fileId, progressCallback);
			}
			return result;
		}

		private static IntPtr ImportFile(string filename, AssetLoaderOptions options, AssimpInterop.ProgressCallback progressCallback)
		{
			IntPtr result;
			if (options != null && options.AdvancedConfigs != null)
			{
				IntPtr intPtr = BuildPropertyStore(options);
				result = AssimpInterop.ai_ImportFileEx(filename, (uint)options.PostProcessSteps, IntPtr.Zero, intPtr, progressCallback);
				AssimpInterop.ai_CreateReleasePropertyStore(intPtr);
			}
			else
			{
				result = AssimpInterop.ai_ImportFile(filename, (options == null) ? GetDefaultPostProcessSteps() : ((uint)options.PostProcessSteps), progressCallback);
			}
			return result;
		}

		private void LoadInternal(string basePath, AssetLoaderOptions options, bool usesWrapperGameObject = false, LoadTextureDataCallback loadTextureDataCallback = null)
		{
			Metadata = BuildMetadata(IntPtr.Zero);
			if (AssimpInterop.aiScene_HasMaterials(Scene) && (options == null || !options.DontLoadMaterials))
			{
				MaterialData = new MaterialData[AssimpInterop.aiScene_GetNumMaterials(Scene)];
				EmbeddedTextures = new Dictionary<string, EmbeddedTextureData>();
				BuildMaterials(basePath, options, loadTextureDataCallback);
			}
			if (AssimpInterop.aiScene_HasMeshes(Scene) && (options == null || !options.DontLoadMeshes))
			{
				MeshData = new MeshData[AssimpInterop.aiScene_GetNumMeshes(Scene)];
				BuildMeshes();
				BuildBones();
			}
			if (AssimpInterop.aiScene_HasAnimation(Scene) && (options == null || !options.DontLoadAnimations))
			{
				AnimationData = new AnimationData[AssimpInterop.aiScene_GetNumAnimations(Scene)];
				BuildAnimations(options);
			}
			if (AssimpInterop.aiScene_HasCameras(Scene) && (options == null || !options.DontLoadCameras))
			{
				CameraData = new CameraData[AssimpInterop.aiScene_GetNumCameras(Scene)];
				BuildCameras();
			}
			BuildObjects(options, usesWrapperGameObject);
		}

		private void BuildObjects(AssetLoaderOptions options, bool usesWrapperGameObject = false)
		{
			NodesPath = new Dictionary<string, string>();
			IntPtr node = AssimpInterop.aiScene_GetRootNode(Scene);
			RootNodeData = BuildObject(RootNodeData, node, options, usesWrapperGameObject);
		}

		private NodeData BuildObject(NodeData parentNodeData, IntPtr node, AssetLoaderOptions options, bool usesWrapperGameObject = false)
		{
			uint nodeId = NodeId++;
			string text = AssimpInterop.aiNode_GetName(node);
			string text2 = FixNodeName(text, nodeId);
			Matrix4x4 matrix = AssimpInterop.aiNode_GetTransformation(node);
			string text3 = ((parentNodeData != null) ? string.Format((parentNodeData.Path != null) ? "{0}/{1}" : "{1}", parentNodeData.Path, text) : (usesWrapperGameObject ? $"{text}" : null));
			NodesPath.Add(text2, text3);
			uint num = AssimpInterop.aiNode_GetNumMeshes(node);
			NodeData nodeData = new NodeData
			{
				Name = text2,
				Path = text3,
				Matrix = matrix,
				Meshes = new uint[num]
			};
			nodeData.Metadata = BuildMetadata(node);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				uint num3 = AssimpInterop.aiNode_GetMeshIndex(node, num2);
				nodeData.Meshes[num2] = num3;
			}
			uint num4 = AssimpInterop.aiNode_GetNumChildren(node);
			if (num4 != 0)
			{
				nodeData.Children = new NodeData[num4];
				for (uint num5 = 0u; num5 < num4; num5++)
				{
					IntPtr node2 = AssimpInterop.aiNode_GetChildren(node, num5);
					NodeData nodeData2 = BuildObject(nodeData, node2, options, usesWrapperGameObject);
					nodeData2.Parent = nodeData;
					nodeData.Children[num5] = nodeData2;
				}
			}
			return nodeData;
		}

		private AssimpMetadata[] BuildMetadata(IntPtr node)
		{
			if (!HasOnMetadataProcessed)
			{
				return null;
			}
			uint num = ((node == IntPtr.Zero) ? AssimpInterop.aiScene_GetMetadataCount(Scene) : AssimpInterop.aiNode_GetMetadataCount(node));
			AssimpMetadata[] array = new AssimpMetadata[num];
			for (uint num2 = 0u; num2 < num; num2++)
			{
				string metadataKey = ((node == IntPtr.Zero) ? AssimpInterop.aiScene_GetMetadataKey(Scene, num2) : AssimpInterop.aiNode_GetMetadataKey(node, num2));
				AssimpMetadataType assimpMetadataType = ((node == IntPtr.Zero) ? AssimpInterop.aiScene_GetMetadataType(Scene, num2) : AssimpInterop.aiNode_GetMetadataType(node, num2));
				object metadataValue;
				switch (assimpMetadataType)
				{
				case AssimpMetadataType.AI_BOOL:
					metadataValue = ((node == IntPtr.Zero) ? AssimpInterop.aiScene_GetMetadataBoolValue(Scene, num2) : AssimpInterop.aiNode_GetMetadataBoolValue(node, num2));
					break;
				case AssimpMetadataType.AI_INT32:
					metadataValue = ((node == IntPtr.Zero) ? AssimpInterop.aiScene_GetMetadataInt32Value(Scene, num2) : AssimpInterop.aiNode_GetMetadataInt32Value(node, num2));
					break;
				case AssimpMetadataType.AI_UINT64:
					metadataValue = ((node == IntPtr.Zero) ? AssimpInterop.aiScene_GetMetadataInt64Value(Scene, num2) : AssimpInterop.aiNode_GetMetadataInt64Value(node, num2));
					break;
				case AssimpMetadataType.AI_FLOAT:
					metadataValue = ((node == IntPtr.Zero) ? AssimpInterop.aiScene_GetMetadataFloatValue(Scene, num2) : AssimpInterop.aiNode_GetMetadataFloatValue(node, num2));
					break;
				case AssimpMetadataType.AI_DOUBLE:
					metadataValue = ((node == IntPtr.Zero) ? AssimpInterop.aiScene_GetMetadataDoubleValue(Scene, num2) : AssimpInterop.aiNode_GetMetadataDoubleValue(node, num2));
					break;
				case AssimpMetadataType.AI_AIVECTOR3D:
					metadataValue = ((node == IntPtr.Zero) ? AssimpInterop.aiScene_GetMetadataVectorValue(Scene, num2) : AssimpInterop.aiNode_GetMetadataVectorValue(node, num2));
					break;
				default:
					metadataValue = ((node == IntPtr.Zero) ? AssimpInterop.aiScene_GetMetadataStringValue(Scene, num2) : AssimpInterop.aiNode_GetMetadataStringValue(node, num2));
					break;
				}
				array[num2] = new AssimpMetadata(assimpMetadataType, num2, metadataKey, metadataValue);
			}
			return array;
		}

		private void BuildMeshes()
		{
			uint num = AssimpInterop.aiScene_GetNumMeshes(Scene);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				MeshData meshData = new MeshData();
				IntPtr ptrMesh = AssimpInterop.aiScene_GetMesh(Scene, num2);
				string name = AssimpInterop.aiMesh_GetName(ptrMesh);
				meshData.Name = FixName(name, num2);
				uint materialIndex = AssimpInterop.aiMesh_GetMatrialIndex(ptrMesh);
				meshData.MaterialIndex = materialIndex;
				uint num3 = AssimpInterop.aiMesh_VertexCount(ptrMesh);
				bool flag = AssimpInterop.aiMesh_HasNormals(ptrMesh);
				if (flag)
				{
					meshData.Normals = new Vector3[num3];
				}
				bool flag2 = AssimpInterop.aiMesh_HasTangentsAndBitangents(ptrMesh);
				if (flag2)
				{
					meshData.Tangents = new Vector4[num3];
					meshData.BiTangents = new Vector4[num3];
				}
				bool flag3 = AssimpInterop.aiMesh_HasTextureCoords(ptrMesh, 0u);
				if (flag3)
				{
					meshData.Uv = new Vector2[num3];
				}
				bool flag4 = AssimpInterop.aiMesh_HasTextureCoords(ptrMesh, 1u);
				if (flag4)
				{
					meshData.Uv1 = new Vector2[num3];
				}
				bool flag5 = AssimpInterop.aiMesh_HasTextureCoords(ptrMesh, 2u);
				if (flag5)
				{
					meshData.Uv2 = new Vector2[num3];
				}
				bool flag6 = AssimpInterop.aiMesh_HasTextureCoords(ptrMesh, 3u);
				if (flag6)
				{
					meshData.Uv3 = new Vector2[num3];
				}
				bool flag7 = AssimpInterop.aiMesh_HasVertexColors(ptrMesh, 0u);
				if (flag7)
				{
					meshData.Colors = new Color[num3];
				}
				meshData.Vertices = new Vector3[num3];
				for (uint num4 = 0u; num4 < num3; num4++)
				{
					meshData.Vertices[num4] = AssimpInterop.aiMesh_GetVertex(ptrMesh, num4);
					if (flag)
					{
						meshData.Normals[num4] = AssimpInterop.aiMesh_GetNormal(ptrMesh, num4);
					}
					if (flag2)
					{
						meshData.Tangents[num4] = AssimpInterop.aiMesh_GetTangent(ptrMesh, num4);
						meshData.BiTangents[num4] = AssimpInterop.aiMesh_GetBitangent(ptrMesh, num4);
					}
					if (flag3)
					{
						meshData.Uv[num4] = AssimpInterop.aiMesh_GetTextureCoord(ptrMesh, 0u, num4);
					}
					if (flag4)
					{
						meshData.Uv1[num4] = AssimpInterop.aiMesh_GetTextureCoord(ptrMesh, 1u, num4);
					}
					if (flag5)
					{
						meshData.Uv2[num4] = AssimpInterop.aiMesh_GetTextureCoord(ptrMesh, 2u, num4);
					}
					if (flag6)
					{
						meshData.Uv3[num4] = AssimpInterop.aiMesh_GetTextureCoord(ptrMesh, 3u, num4);
					}
					if (flag7)
					{
						meshData.Colors[num4] = AssimpInterop.aiMesh_GetVertexColor(ptrMesh, 0u, num4);
					}
				}
				if (AssimpInterop.aiMesh_HasFaces(ptrMesh))
				{
					uint num5 = AssimpInterop.aiMesh_GetNumFaces(ptrMesh);
					meshData.Triangles = new int[num5 * 3];
					for (uint num6 = 0u; num6 < num5; num6++)
					{
						IntPtr ptrFace = AssimpInterop.aiMesh_GetFace(ptrMesh, num6);
						uint num7 = AssimpInterop.aiFace_GetNumIndices(ptrFace);
						if (num7 > 3)
						{
							throw new UnityException("More than three face indices is not supported. Please enable \"Triangulate\" in your \"AssetLoaderOptions\" \"PostProcessSteps\" field");
						}
						for (uint num8 = 0u; num8 < num7; num8++)
						{
							meshData.Triangles[num6 * 3 + num8] = (int)AssimpInterop.aiFace_GetIndex(ptrFace, num8);
						}
					}
				}
				uint num9 = AssimpInterop.aiMesh_GetAnimMeshCount(ptrMesh);
				MorphData[] array;
				if (num9 != 0)
				{
					HasBlendShapes = true;
					array = new MorphData[num9];
					for (uint num10 = 0u; num10 < num9; num10++)
					{
						IntPtr ptrMesh2 = AssimpInterop.aiMesh_GetAnimMesh(ptrMesh, num10);
						uint num11 = AssimpInterop.aiAnimMesh_GetVerticesCount(ptrMesh2);
						Vector3[] array2;
						if (AssimpInterop.aiAnimMesh_HasPositions(ptrMesh2) && meshData.Vertices != null)
						{
							array2 = new Vector3[num11];
							for (uint num12 = 0u; num12 < num11; num12++)
							{
								Vector3 vector = AssimpInterop.aiAnimMesh_GetVertex(ptrMesh2, num12);
								Vector3 vector2 = ((num12 < meshData.Vertices.Length) ? meshData.Vertices[num12] : Vector3.zero);
								Vector3 vector3 = vector - vector2;
								array2[num12] = vector3;
							}
						}
						else
						{
							array2 = null;
						}
						Vector3[] array3;
						if (AssimpInterop.aiAnimMesh_HasNormals(ptrMesh2) && meshData.Normals != null)
						{
							array3 = new Vector3[num11];
							for (uint num13 = 0u; num13 < num11; num13++)
							{
								Vector3 vector4 = AssimpInterop.aiAnimMesh_GetNormal(ptrMesh2, num13);
								Vector3 vector5 = ((num13 < meshData.Normals.Length) ? meshData.Normals[num13] : Vector3.zero);
								Vector3 vector6 = vector4 - vector5;
								array3[num13] = vector6;
							}
						}
						else
						{
							array3 = null;
						}
						Vector3[] array4;
						if (AssimpInterop.aiAnimMesh_HasTangentsAndBitangents(ptrMesh2) && meshData.Tangents != null)
						{
							array4 = new Vector3[num11];
							for (uint num14 = 0u; num14 < num11; num14++)
							{
								Vector3 vector7 = AssimpInterop.aiAnimMesh_GetTangent(ptrMesh2, num14);
								Vector4 vector8 = ((num14 < meshData.Tangents.Length) ? meshData.Tangents[num14] : Vector4.zero);
								Vector4 vector9 = new Vector4(vector7.x, vector7.y, vector7.z) - vector8;
								array4[num14] = vector9;
							}
						}
						else
						{
							array4 = null;
						}
						MorphData morphData = new MorphData();
						morphData.Name = AssimpInterop.aiAnimMesh_GetName(ptrMesh2);
						morphData.Vertices = array2;
						morphData.Normals = array3;
						morphData.Tangents = array4;
						morphData.Weight = AssimpInterop.aiAnimMesh_GetWeight(ptrMesh2);
						array[num10] = morphData;
					}
				}
				else
				{
					array = null;
				}
				meshData.MorphsData = array;
				MeshData[num2] = meshData;
			}
		}

		private void BuildCameras()
		{
			for (uint num = 0u; num < AssimpInterop.aiScene_GetNumCameras(Scene); num++)
			{
				IntPtr ptrCamera = AssimpInterop.aiScene_GetCamera(Scene, num);
				string name = AssimpInterop.aiCamera_GetName(ptrCamera);
				CameraData cameraData = new CameraData
				{
					Name = name,
					Aspect = AssimpInterop.aiCamera_GetAspect(ptrCamera),
					NearClipPlane = AssimpInterop.aiCamera_GetClipPlaneNear(ptrCamera),
					FarClipPlane = AssimpInterop.aiCamera_GetClipPlaneFar(ptrCamera),
					FieldOfView = AssimpInterop.aiCamera_GetHorizontalFOV(ptrCamera),
					LocalPosition = AssimpInterop.aiCamera_GetPosition(ptrCamera),
					Forward = AssimpInterop.aiCamera_GetLookAt(ptrCamera),
					Up = AssimpInterop.aiCamera_GetUp(ptrCamera)
				};
				CameraData[num] = cameraData;
			}
		}

		private void BuildMaterials(string basePath, AssetLoaderOptions options, LoadTextureDataCallback loadTextureDataCallback = null)
		{
			for (uint num = 0u; num < AssimpInterop.aiScene_GetNumMaterials(Scene); num++)
			{
				MaterialData materialData = new MaterialData();
				IntPtr intPtr = AssimpInterop.aiScene_GetMaterial(Scene, num);
				if (options != null && options.LoadRawMaterialProperties)
				{
					uint num2 = AssimpInterop.aiMaterial_GetNumProperties(intPtr);
					if (num2 != 0)
					{
						materialData.Properties = new IMaterialProperty[num2];
						for (uint num3 = 0u; num3 < num2; num3++)
						{
							IntPtr intPtr2 = AssimpInterop.aiMaterial_GetProperty(intPtr, num3);
							string text = AssimpInterop.aiMaterialProperty_GetKey(intPtr2);
							aiPropertyTypeInfo aiPropertyTypeInfo2 = AssimpInterop.aiMaterialProperty_GetType(intPtr2);
							uint num4 = AssimpInterop.aiMaterialProperty_GetIndex(intPtr2);
							uint num5 = AssimpInterop.aiMaterialProperty_GetSemantic(intPtr2);
							uint num6 = AssimpInterop.aiMaterialProperty_GetDataSize(intPtr2);
							IntPtr pointer = AssimpInterop.aiMaterialProperty_GetDataPointer(intPtr2);
							IMaterialProperty materialProperty;
							switch (aiPropertyTypeInfo2)
							{
							case aiPropertyTypeInfo.aiPTI_Float:
							{
								int num8 = (int)(num6 / 4);
								if (num8 == 1)
								{
									float newFloat = AssimpInterop.GetNewFloat(pointer);
									materialProperty = new MaterialProperty<float>(text, newFloat, num4, num5);
								}
								else
								{
									float[] data2 = AssimpInterop.ReadFloatArray(pointer, num8);
									materialProperty = new MaterialProperty<float[]>(text, data2, num4, num5);
								}
								break;
							}
							case aiPropertyTypeInfo.aiPTI_Double:
							{
								int num10 = (int)(num6 / 8);
								if (num10 == 1)
								{
									double newDouble = AssimpInterop.GetNewDouble(pointer);
									materialProperty = new MaterialProperty<double>(text, newDouble, num4, num5);
								}
								else
								{
									double[] data4 = AssimpInterop.ReadDoubleArray(pointer, num10);
									materialProperty = new MaterialProperty<double[]>(text, data4, num4, num5);
								}
								break;
							}
							case aiPropertyTypeInfo.aiPTI_String:
							{
								AssimpInterop.aiMaterial_GetString(intPtr, text, num5, num4, out var strValue);
								materialProperty = new MaterialProperty<string>(text, strValue, num4, num5);
								break;
							}
							case aiPropertyTypeInfo.aiPTI_Integer:
							{
								int num9 = (int)(num6 / 4);
								if (num9 == 1)
								{
									int newInt = AssimpInterop.GetNewInt32(pointer);
									materialProperty = new MaterialProperty<int>(text, newInt, num4, num5);
								}
								else
								{
									int[] data3 = AssimpInterop.ReadIntArray(pointer, num9);
									materialProperty = new MaterialProperty<int[]>(text, data3, num4, num5);
								}
								break;
							}
							default:
							{
								int num7 = (int)num6;
								if (num7 == 1)
								{
									byte newByte = AssimpInterop.GetNewByte(pointer);
									materialProperty = new MaterialProperty<byte>(text, newByte, num4, num5);
								}
								else
								{
									byte[] data = AssimpInterop.ReadByteArray(pointer, num7);
									materialProperty = new MaterialProperty<byte[]>(text, data, num4, num5);
								}
								break;
							}
							}
							materialData.Properties[num3] = materialProperty;
						}
					}
				}
				string strName = null;
				if (AssimpInterop.aiMaterial_HasName(intPtr))
				{
					AssimpInterop.aiMaterial_GetName(intPtr, out strName);
				}
				strName = FixName(strName, num);
				materialData.Name = strName;
				bool alphaLoaded = false;
				if (AssimpInterop.aiMaterial_HasOpacity(intPtr) && AssimpInterop.aiMaterial_GetOpacity(intPtr, out var floatOut))
				{
					materialData.Alpha = floatOut;
					alphaLoaded = true;
				}
				materialData.AlphaLoaded = alphaLoaded;
				bool diffuseInfoLoaded = false;
				if (AssimpInterop.aiMaterial_GetNumTextureDiffuse(intPtr) != 0 && AssimpInterop.aiMaterial_GetTextureDiffuse(intPtr, 0u, out var strPath, out var _, out var _, out var floatBlend, out var uintOp, out var uintMapMode))
				{
					TextureWrapMode diffuseWrapMode = ((uintMapMode == 1) ? TextureWrapMode.Clamp : TextureWrapMode.Repeat);
					string diffuseName = StringUtils.GenerateUniqueName(strPath);
					materialData.DiffusePath = strPath;
					materialData.DiffuseWrapMode = diffuseWrapMode;
					materialData.DiffuseName = diffuseName;
					materialData.DiffuseBlendMode = floatBlend;
					materialData.DiffuseOp = uintOp;
					diffuseInfoLoaded = true;
					EmbeddedTextureData diffuseEmbeddedTextureData;
					if (this.EmbeddedTextureLoad != null)
					{
						diffuseEmbeddedTextureData = this.EmbeddedTextureLoad(strPath);
					}
					else
					{
						IntPtr intPtr3 = AssimpInterop.aiScene_GetEmbeddedTexture(Scene, strPath);
						diffuseEmbeddedTextureData = ((!(intPtr3 != IntPtr.Zero)) ? ((loadTextureDataCallback == null) ? LoadTextureData(strPath, basePath) : loadTextureDataCallback(strPath, basePath)) : LoadEmbeddedTextureData(intPtr3, strPath));
					}
					materialData.DiffuseEmbeddedTextureData = diffuseEmbeddedTextureData;
				}
				materialData.DiffuseInfoLoaded = diffuseInfoLoaded;
				bool diffuseColorLoaded = false;
				if (AssimpInterop.aiMaterial_HasDiffuse(intPtr) && AssimpInterop.aiMaterial_GetDiffuse(intPtr, out var colorOut))
				{
					materialData.DiffuseColor = colorOut;
					diffuseColorLoaded = true;
				}
				materialData.DiffuseColorLoaded = diffuseColorLoaded;
				bool emissionColorLoaded = false;
				if (AssimpInterop.aiMaterial_HasEmissive(intPtr) && AssimpInterop.aiMaterial_GetEmissive(intPtr, out var colorOut2))
				{
					materialData.EmissionColor = colorOut2;
					emissionColorLoaded = true;
				}
				materialData.EmissionColorLoaded = emissionColorLoaded;
				bool emissionInfoLoaded = false;
				if (AssimpInterop.aiMaterial_GetNumTextureEmissive(intPtr) != 0 && AssimpInterop.aiMaterial_GetTextureEmissive(intPtr, 0u, out var strPath2, out var _, out var _, out var floatBlend2, out var uintOp2, out var uintMapMode2))
				{
					TextureWrapMode emissionWrapMode = ((uintMapMode2 == 1) ? TextureWrapMode.Clamp : TextureWrapMode.Repeat);
					string emissionName = StringUtils.GenerateUniqueName(strPath2);
					materialData.EmissionPath = strPath2;
					materialData.EmissionWrapMode = emissionWrapMode;
					materialData.EmissionName = emissionName;
					materialData.EmissionBlendMode = floatBlend2;
					materialData.EmissionOp = uintOp2;
					emissionInfoLoaded = true;
					EmbeddedTextureData emissionEmbeddedTextureData;
					if (this.EmbeddedTextureLoad != null)
					{
						emissionEmbeddedTextureData = this.EmbeddedTextureLoad(strPath2);
					}
					else
					{
						IntPtr intPtr4 = AssimpInterop.aiScene_GetEmbeddedTexture(Scene, strPath2);
						emissionEmbeddedTextureData = ((!(intPtr4 != IntPtr.Zero)) ? ((loadTextureDataCallback == null) ? LoadTextureData(strPath2, basePath) : loadTextureDataCallback(strPath2, basePath)) : LoadEmbeddedTextureData(intPtr4, strPath2));
					}
					materialData.EmissionEmbeddedTextureData = emissionEmbeddedTextureData;
				}
				materialData.EmissionInfoLoaded = emissionInfoLoaded;
				bool specularColorLoaded = false;
				if (AssimpInterop.aiMaterial_HasSpecular(intPtr) && AssimpInterop.aiMaterial_GetSpecular(intPtr, out var colorOut3))
				{
					materialData.SpecularColor = colorOut3;
					specularColorLoaded = true;
				}
				materialData.SpecularColorLoaded = specularColorLoaded;
				bool specularInfoLoaded = false;
				if (AssimpInterop.aiMaterial_GetNumTextureSpecular(intPtr) != 0 && AssimpInterop.aiMaterial_GetTextureSpecular(intPtr, 0u, out var strPath3, out var _, out var _, out var floatBlend3, out var uintOp3, out var uintMapMode3))
				{
					TextureWrapMode specularWrapMode = ((uintMapMode3 == 1) ? TextureWrapMode.Clamp : TextureWrapMode.Repeat);
					string specularName = StringUtils.GenerateUniqueName(strPath3);
					materialData.SpecularPath = strPath3;
					materialData.SpecularWrapMode = specularWrapMode;
					materialData.SpecularName = specularName;
					materialData.SpecularBlendMode = floatBlend3;
					materialData.SpecularOp = uintOp3;
					specularInfoLoaded = true;
					EmbeddedTextureData specularEmbeddedTextureData;
					if (this.EmbeddedTextureLoad != null)
					{
						specularEmbeddedTextureData = this.EmbeddedTextureLoad(strPath3);
					}
					else
					{
						IntPtr intPtr5 = AssimpInterop.aiScene_GetEmbeddedTexture(Scene, strPath3);
						specularEmbeddedTextureData = ((!(intPtr5 != IntPtr.Zero)) ? ((loadTextureDataCallback == null) ? LoadTextureData(strPath3, basePath) : loadTextureDataCallback(strPath3, basePath)) : LoadEmbeddedTextureData(intPtr5, strPath3));
					}
					materialData.SpecularEmbeddedTextureData = specularEmbeddedTextureData;
				}
				materialData.SpecularInfoLoaded = specularInfoLoaded;
				bool normalInfoLoaded = false;
				if (AssimpInterop.aiMaterial_GetNumTextureNormals(intPtr) != 0 && AssimpInterop.aiMaterial_GetTextureNormals(intPtr, 0u, out var strPath4, out var _, out var _, out var floatBlend4, out var uintOp4, out var uintMapMode4))
				{
					TextureWrapMode normalWrapMode = ((uintMapMode4 == 1) ? TextureWrapMode.Clamp : TextureWrapMode.Repeat);
					string normalName = StringUtils.GenerateUniqueName(strPath4);
					materialData.NormalPath = strPath4;
					materialData.NormalWrapMode = normalWrapMode;
					materialData.NormalName = normalName;
					materialData.NormalBlendMode = floatBlend4;
					materialData.NormalOp = uintOp4;
					normalInfoLoaded = true;
					EmbeddedTextureData normalEmbeddedTextureData;
					if (this.EmbeddedTextureLoad != null)
					{
						normalEmbeddedTextureData = this.EmbeddedTextureLoad(strPath4);
					}
					else
					{
						IntPtr intPtr6 = AssimpInterop.aiScene_GetEmbeddedTexture(Scene, strPath4);
						normalEmbeddedTextureData = ((!(intPtr6 != IntPtr.Zero)) ? ((loadTextureDataCallback == null) ? LoadTextureData(strPath4, basePath) : loadTextureDataCallback(strPath4, basePath)) : LoadEmbeddedTextureData(intPtr6, strPath4));
					}
					materialData.NormalEmbeddedTextureData = normalEmbeddedTextureData;
				}
				materialData.NormalInfoLoaded = normalInfoLoaded;
				bool heightInfoLoaded = false;
				if (AssimpInterop.aiMaterial_GetNumTextureHeight(intPtr) != 0 && AssimpInterop.aiMaterial_GetTextureHeight(intPtr, 0u, out var strPath5, out var _, out var _, out var floatBlend5, out var uintOp5, out var uintMapMode5))
				{
					TextureWrapMode heightWrapMode = ((uintMapMode5 == 1) ? TextureWrapMode.Clamp : TextureWrapMode.Repeat);
					string heightName = StringUtils.GenerateUniqueName(strPath5);
					materialData.HeightPath = strPath5;
					materialData.HeightWrapMode = heightWrapMode;
					materialData.HeightName = heightName;
					materialData.HeightBlendMode = floatBlend5;
					materialData.HeightOp = uintOp5;
					heightInfoLoaded = true;
					EmbeddedTextureData heightEmbeddedTextureData;
					if (this.EmbeddedTextureLoad != null)
					{
						heightEmbeddedTextureData = this.EmbeddedTextureLoad(strPath5);
					}
					else
					{
						IntPtr intPtr7 = AssimpInterop.aiScene_GetEmbeddedTexture(Scene, strPath5);
						heightEmbeddedTextureData = ((!(intPtr7 != IntPtr.Zero)) ? ((loadTextureDataCallback == null) ? LoadTextureData(strPath5, basePath) : loadTextureDataCallback(strPath5, basePath)) : LoadEmbeddedTextureData(intPtr7, strPath5));
					}
					materialData.HeightEmbeddedTextureData = heightEmbeddedTextureData;
				}
				materialData.HeightInfoLoaded = heightInfoLoaded;
				bool occlusionInfoLoaded = false;
				if (AssimpInterop.aiMaterial_GetNumTextureOcclusion(intPtr) != 0 && AssimpInterop.aiMaterial_GetTextureOcclusion(intPtr, 0u, out var strPath6, out var _, out var _, out var floatBlend6, out var uintOp6, out var uintMapMode6))
				{
					TextureWrapMode occlusionWrapMode = ((uintMapMode6 == 1) ? TextureWrapMode.Clamp : TextureWrapMode.Repeat);
					string occlusionName = StringUtils.GenerateUniqueName(strPath6);
					materialData.OcclusionPath = strPath6;
					materialData.OcclusionWrapMode = occlusionWrapMode;
					materialData.OcclusionName = occlusionName;
					materialData.OcclusionBlendMode = floatBlend6;
					materialData.OcclusionOp = uintOp6;
					occlusionInfoLoaded = true;
					EmbeddedTextureData occlusionEmbeddedTextureData;
					if (this.EmbeddedTextureLoad != null)
					{
						occlusionEmbeddedTextureData = this.EmbeddedTextureLoad(strPath6);
					}
					else
					{
						IntPtr intPtr8 = AssimpInterop.aiScene_GetEmbeddedTexture(Scene, strPath6);
						occlusionEmbeddedTextureData = ((!(intPtr8 != IntPtr.Zero)) ? ((loadTextureDataCallback == null) ? LoadTextureData(strPath6, basePath) : loadTextureDataCallback(strPath6, basePath)) : LoadEmbeddedTextureData(intPtr8, strPath6));
					}
					materialData.OcclusionEmbeddedTextureData = occlusionEmbeddedTextureData;
				}
				materialData.OcclusionInfoLoaded = occlusionInfoLoaded;
				bool metallicInfoLoaded = false;
				if (AssimpInterop.aiMaterial_GetNumTextureMetallic(intPtr) != 0 && AssimpInterop.aiMaterial_GetTextureMetallic(intPtr, 0u, out var strPath7, out var _, out var _, out var floatBlend7, out var uintOp7, out var uintMapMode7))
				{
					TextureWrapMode metallicWrapMode = ((uintMapMode7 == 1) ? TextureWrapMode.Clamp : TextureWrapMode.Repeat);
					string metallicName = StringUtils.GenerateUniqueName(strPath7);
					materialData.MetallicPath = strPath7;
					materialData.MetallicWrapMode = metallicWrapMode;
					materialData.MetallicName = metallicName;
					materialData.MetallicBlendMode = floatBlend7;
					materialData.MetallicOp = uintOp7;
					metallicInfoLoaded = true;
					EmbeddedTextureData metallicEmbeddedTextureData;
					if (this.EmbeddedTextureLoad != null)
					{
						metallicEmbeddedTextureData = this.EmbeddedTextureLoad(strPath7);
					}
					else
					{
						IntPtr intPtr9 = AssimpInterop.aiScene_GetEmbeddedTexture(Scene, strPath7);
						metallicEmbeddedTextureData = ((!(intPtr9 != IntPtr.Zero)) ? ((loadTextureDataCallback == null) ? LoadTextureData(strPath7, basePath) : loadTextureDataCallback(strPath7, basePath)) : LoadEmbeddedTextureData(intPtr9, strPath7));
					}
					materialData.MetallicEmbeddedTextureData = metallicEmbeddedTextureData;
				}
				materialData.MetallicInfoLoaded = metallicInfoLoaded;
				bool bumpScaleLoaded = false;
				if (AssimpInterop.aiMaterial_HasBumpScaling(intPtr) && AssimpInterop.aiMaterial_GetBumpScaling(intPtr, out var floatOut2))
				{
					if (Mathf.Approximately(floatOut2, 0f))
					{
						floatOut2 = 1f;
					}
					materialData.BumpScale = floatOut2;
					bumpScaleLoaded = true;
				}
				materialData.BumpScaleLoaded = bumpScaleLoaded;
				bool glossinessLoaded = false;
				if (AssimpInterop.aiMaterial_HasShininess(intPtr) && AssimpInterop.aiMaterial_GetShininess(intPtr, out var floatOut3))
				{
					materialData.Glossiness = floatOut3;
					glossinessLoaded = true;
				}
				materialData.GlossinessLoaded = glossinessLoaded;
				bool glossMapScaleLoaded = false;
				if (AssimpInterop.aiMaterial_HasShininessStrength(intPtr) && AssimpInterop.aiMaterial_GetShininessStrength(intPtr, out var floatOut4))
				{
					materialData.GlossMapScale = floatOut4;
					glossMapScaleLoaded = true;
				}
				materialData.GlossMapScaleLoaded = glossMapScaleLoaded;
				MaterialData[num] = materialData;
			}
		}

		private EmbeddedTextureData LoadTextureData(string path, string basePath)
		{
			string filename = FileUtils.GetFilename(path);
			if (EmbeddedTextures.ContainsKey(filename))
			{
				return EmbeddedTextures[filename];
			}
			byte[] array = FileUtils.LoadFileData(path);
			if (array.Length == 0 && basePath != null)
			{
				array = FileUtils.LoadFileData(Path.Combine(basePath, path));
			}
			if (array.Length == 0)
			{
				array = FileUtils.LoadFileData(filename);
			}
			if (array.Length == 0 && basePath != null)
			{
				array = FileUtils.LoadFileData(Path.Combine(basePath, filename));
			}
			if (array.Length == 0)
			{
				return null;
			}
			EmbeddedTextureData embeddedTextureData = new EmbeddedTextureData();
			embeddedTextureData.DataPointer = STBImageLoader.LoadTextureDataFromByteArray(array, out embeddedTextureData.Width, out embeddedTextureData.Height, out embeddedTextureData.NumChannels, out embeddedTextureData.DataLength);
			embeddedTextureData.OnDataDisposal = STBImageLoader.UnloadTextureData;
			EmbeddedTextures.Add(filename, embeddedTextureData);
			return embeddedTextureData;
		}

		private EmbeddedTextureData LoadEmbeddedTextureData(IntPtr texture, string textureName)
		{
			string filename = FileUtils.GetFilename(AssimpInterop.aiMaterial_GetEmbeddedTextureName(texture));
			if (string.IsNullOrEmpty(filename))
			{
				filename = FileUtils.GetFilename(textureName);
			}
			if (EmbeddedTextures.ContainsKey(filename))
			{
				return EmbeddedTextures[filename];
			}
			EmbeddedTextureData embeddedTextureData = new EmbeddedTextureData();
			bool num = !AssimpInterop.aiMaterial_IsEmbeddedTextureCompressed(texture);
			uint inDataLength = AssimpInterop.aiMaterial_GetEmbeddedTextureDataSize(texture);
			IntPtr intPtr = AssimpInterop.aiMaterial_GetEmbeddedTextureDataPointer(texture);
			if (!num)
			{
				embeddedTextureData.DataPointer = STBImageLoader.LoadTextureFromDataPointer(intPtr, (int)inDataLength, out embeddedTextureData.Width, out embeddedTextureData.Height, out embeddedTextureData.NumChannels, out embeddedTextureData.DataLength);
				embeddedTextureData.OnDataDisposal = STBImageLoader.UnloadTextureData;
			}
			else
			{
				embeddedTextureData.DataPointer = intPtr;
				embeddedTextureData.Width = AssimpInterop.aiMaterial_GetEmbeddedTextureWidth(texture);
				embeddedTextureData.Height = AssimpInterop.aiMaterial_GetEmbeddedTextureHeight(texture);
			}
			AssimpInterop.aiMaterial_ReleaseEmbeddedTexture(texture);
			EmbeddedTextures.Add(filename, embeddedTextureData);
			return embeddedTextureData;
		}

		private void BuildBones()
		{
			uint num = AssimpInterop.aiScene_GetNumMeshes(Scene);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				MeshData meshData = MeshData[num2];
				IntPtr ptrMesh = AssimpInterop.aiScene_GetMesh(Scene, num2);
				if (!(meshData.HasBoneInfo = AssimpInterop.aiMesh_HasBones(ptrMesh)))
				{
					continue;
				}
				HasBoneInfo = true;
				uint num3 = AssimpInterop.aiMesh_VertexCount(ptrMesh);
				uint num4 = AssimpInterop.aiMesh_GetNumBones(ptrMesh);
				meshData.BindPoses = new Matrix4x4[num4];
				meshData.BoneNames = new string[num4];
				meshData.BoneWeights = new BoneWeight[num3];
				int[] array = new int[num3];
				for (uint num5 = 0u; num5 < num4; num5++)
				{
					IntPtr ptrBone = AssimpInterop.aiMesh_GetBone(ptrMesh, num5);
					string text = AssimpInterop.aiBone_GetName(ptrBone);
					meshData.BoneNames[num5] = text;
					Matrix4x4 matrix4x = AssimpInterop.aiBone_GetOffsetMatrix(ptrBone);
					meshData.BindPoses[num5] = matrix4x;
					uint num6 = AssimpInterop.aiBone_GetNumWeights(ptrBone);
					for (uint num7 = 0u; num7 < num6; num7++)
					{
						int num8 = (int)num5;
						IntPtr ptrVweight = AssimpInterop.aiBone_GetWeights(ptrBone, num7);
						float num9 = AssimpInterop.aiVertexWeight_GetWeight(ptrVweight);
						uint num10 = AssimpInterop.aiVertexWeight_GetVertexId(ptrVweight);
						switch (array[num10])
						{
						case 0:
						{
							BoneWeight boneWeight = new BoneWeight
							{
								boneIndex0 = num8,
								weight0 = num9
							};
							meshData.BoneWeights[num10] = boneWeight;
							break;
						}
						case 1:
						{
							BoneWeight boneWeight = meshData.BoneWeights[num10];
							boneWeight.boneIndex1 = num8;
							boneWeight.weight1 = num9;
							meshData.BoneWeights[num10] = boneWeight;
							break;
						}
						case 2:
						{
							BoneWeight boneWeight = meshData.BoneWeights[num10];
							boneWeight.boneIndex2 = num8;
							boneWeight.weight2 = num9;
							meshData.BoneWeights[num10] = boneWeight;
							break;
						}
						case 3:
						{
							BoneWeight boneWeight = meshData.BoneWeights[num10];
							boneWeight.boneIndex3 = num8;
							boneWeight.weight3 = num9;
							meshData.BoneWeights[num10] = boneWeight;
							break;
						}
						default:
						{
							BoneWeight boneWeight = meshData.BoneWeights[num10];
							boneWeight.boneIndex3 = num8;
							boneWeight.weight3 = num9;
							meshData.BoneWeights[num10] = boneWeight;
							break;
						}
						}
						array[num10]++;
					}
				}
			}
		}

		private void BuildAnimations(AssetLoaderOptions options)
		{
			uint num = AssimpInterop.aiScene_GetNumAnimations(Scene);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				IntPtr ptrAnimation = AssimpInterop.aiScene_GetAnimation(Scene, num2);
				float num3 = AssimpInterop.aiAnimation_GetTicksPerSecond(ptrAnimation);
				if (num3 <= 0f)
				{
					num3 = 60f;
				}
				float length = AssimpInterop.aiAnimation_GetDuraction(ptrAnimation) / num3;
				uint num4 = AssimpInterop.aiAnimation_GetNumChannels(ptrAnimation);
				uint num5 = AssimpInterop.aiAnimation_GetNumMorphChannels(ptrAnimation);
				string name = AssimpInterop.aiAnimation_GetName(ptrAnimation);
				name = FixName(name, num2);
				AnimationData animationData = new AnimationData
				{
					Name = name,
					Legacy = (options == null || options.UseLegacyAnimations),
					FrameRate = num3,
					Length = length,
					ChannelData = new AnimationChannelData[num4],
					MorphData = new MorphChannelData[num5]
				};
				for (uint num6 = 0u; num6 < num4; num6++)
				{
					IntPtr ptrNodeAnim = AssimpInterop.aiAnimation_GetAnimationChannel(ptrAnimation, num6);
					string nodeName = AssimpInterop.aiNodeAnim_GetNodeName(ptrNodeAnim);
					AnimationChannelData animationChannelData = new AnimationChannelData
					{
						CurveData = new Dictionary<string, AnimationCurveData>(),
						NodeName = nodeName
					};
					uint num7 = AssimpInterop.aiNodeAnim_GetNumPositionKeys(ptrNodeAnim);
					if (num7 != 0)
					{
						AnimationCurveData animationCurveData = new AnimationCurveData(num7);
						AnimationCurveData animationCurveData2 = new AnimationCurveData(num7);
						AnimationCurveData animationCurveData3 = new AnimationCurveData(num7);
						for (uint num8 = 0u; num8 < num7; num8++)
						{
							IntPtr ptrVectorKey = AssimpInterop.aiNodeAnim_GetPositionKey(ptrNodeAnim, num8);
							float time = AssimpInterop.aiVectorKey_GetTime(ptrVectorKey) / num3;
							float[] array = AssimpInterop.aiVectorKey_GetValue(ptrVectorKey);
							animationCurveData.AddKey(time, array[0]);
							animationCurveData2.AddKey(time, array[1]);
							animationCurveData3.AddKey(time, array[2]);
						}
						animationChannelData.SetCurve("localPosition.x", animationCurveData);
						animationChannelData.SetCurve("localPosition.y", animationCurveData2);
						animationChannelData.SetCurve("localPosition.z", animationCurveData3);
					}
					uint num9 = AssimpInterop.aiNodeAnim_GetNumRotationKeys(ptrNodeAnim);
					if (num9 != 0)
					{
						AnimationCurveData animationCurveData4 = new AnimationCurveData(num9);
						AnimationCurveData animationCurveData5 = new AnimationCurveData(num9);
						AnimationCurveData animationCurveData6 = new AnimationCurveData(num9);
						AnimationCurveData animationCurveData7 = new AnimationCurveData(num9);
						for (uint num10 = 0u; num10 < num9; num10++)
						{
							IntPtr ptrQuatKey = AssimpInterop.aiNodeAnim_GetRotationKey(ptrNodeAnim, num10);
							float time2 = AssimpInterop.aiQuatKey_GetTime(ptrQuatKey) / num3;
							float[] array2 = AssimpInterop.aiQuatKey_GetValue(ptrQuatKey);
							animationCurveData4.AddKey(time2, array2[1]);
							animationCurveData5.AddKey(time2, array2[2]);
							animationCurveData6.AddKey(time2, array2[3]);
							animationCurveData7.AddKey(time2, array2[0]);
						}
						animationChannelData.SetCurve("localRotation.x", animationCurveData4);
						animationChannelData.SetCurve("localRotation.y", animationCurveData5);
						animationChannelData.SetCurve("localRotation.z", animationCurveData6);
						animationChannelData.SetCurve("localRotation.w", animationCurveData7);
					}
					uint num11 = AssimpInterop.aiNodeAnim_GetNumScalingKeys(ptrNodeAnim);
					if (num11 != 0)
					{
						AnimationCurveData animationCurveData8 = new AnimationCurveData(num11);
						AnimationCurveData animationCurveData9 = new AnimationCurveData(num11);
						AnimationCurveData animationCurveData10 = new AnimationCurveData(num11);
						for (uint num12 = 0u; num12 < num11; num12++)
						{
							IntPtr ptrVectorKey2 = AssimpInterop.aiNodeAnim_GetScalingKey(ptrNodeAnim, num12);
							float time3 = AssimpInterop.aiVectorKey_GetTime(ptrVectorKey2) / num3;
							float[] array3 = AssimpInterop.aiVectorKey_GetValue(ptrVectorKey2);
							animationCurveData8.AddKey(time3, array3[0]);
							animationCurveData9.AddKey(time3, array3[1]);
							animationCurveData10.AddKey(time3, array3[2]);
						}
						animationChannelData.SetCurve("localScale.x", animationCurveData8);
						animationChannelData.SetCurve("localScale.y", animationCurveData9);
						animationChannelData.SetCurve("localScale.z", animationCurveData10);
					}
					animationData.ChannelData[num6] = animationChannelData;
				}
				for (uint num13 = 0u; num13 < num5; num13++)
				{
					IntPtr ptrNodeAnim2 = AssimpInterop.aiAnimation_GetMeshMorphAnim(ptrAnimation, num13);
					string nodeName2 = AssimpInterop.aiMeshMorphAnim_GetName(ptrNodeAnim2);
					MorphChannelData morphChannelData = new MorphChannelData
					{
						MorphChannelKeys = new Dictionary<float, MorphChannelKey>(),
						NodeName = nodeName2
					};
					uint num14 = AssimpInterop.aiMeshMorphAnim_GetNumKeys(ptrNodeAnim2);
					for (uint num15 = 0u; num15 < num14; num15++)
					{
						IntPtr ptrMeshMorphKey = AssimpInterop.aiMeshMorphAnim_GetMeshMorphKey(ptrNodeAnim2, num15);
						float key = AssimpInterop.aiMeshMorphKey_GetTime(ptrMeshMorphKey) / num3;
						uint num16 = AssimpInterop.aiMeshMorphKey_GetNumValues(ptrMeshMorphKey);
						MorphChannelKey morphChannelKey = new MorphChannelKey
						{
							Indices = new uint[num16],
							Weights = new float[num16]
						};
						for (uint num17 = 0u; num17 < num16; num17++)
						{
							morphChannelKey.Indices[num17] = AssimpInterop.aiMeshMorphKey_GetValue(ptrMeshMorphKey, num17);
							morphChannelKey.Weights[num17] = AssimpInterop.aiMeshMorphKey_GetWeight(ptrMeshMorphKey, num17);
						}
						morphChannelData.MorphChannelKeys.Add(key, morphChannelKey);
					}
					animationData.MorphData[num13] = morphChannelData;
				}
				animationData.WrapMode = ((options != null) ? options.AnimationWrapMode : WrapMode.Loop);
				AnimationData[num2] = animationData;
			}
		}

		protected virtual string FixNodeName(string name, uint nodeId)
		{
			if (string.IsNullOrEmpty(name))
			{
				return nodeId.ToString();
			}
			if (NodesPath != null && NodesPath.ContainsKey(name))
			{
				return name + nodeId;
			}
			return name;
		}

		protected virtual string FixName(string name, uint id)
		{
			if (!string.IsNullOrEmpty(name))
			{
				return name;
			}
			return StringUtils.GenerateUniqueName(id);
		}

		protected virtual string FixName(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				return name;
			}
			return default(Guid).ToString();
		}

		[MonoPInvokeCallback(typeof(AssimpInterop.DataCallback))]
		private static IntPtr DefaultDataCallback(string resourceFilename, int resourceId, ref int fileSize)
		{
			FileLoadData fileLoadData = FilesLoadData[resourceId];
			if (resourceFilename == fileLoadData.Filename || resourceFilename.StartsWith("$$$___magic___$$$"))
			{
				return IntPtr.Zero;
			}
			string path = FileUtils.GetFilename(resourceFilename).ToLowerInvariant();
			byte[] array = FileUtils.LoadFileData(Path.Combine(fileLoadData.BasePath ?? "", path));
			_ = array.LongLength;
			if (array.Length == 0)
			{
				return IntPtr.Zero;
			}
			fileSize = array.Length;
			GCHandle bufferHandle = AssimpInterop.LockGc(array);
			fileLoadData.AddBuffer(bufferHandle);
			return bufferHandle.AddrOfPinnedObject();
		}

		[MonoPInvokeCallback(typeof(AssimpInterop.ExistsCallback))]
		private static bool DefaultExistsCallback(string resourceFilename, int resourceId)
		{
			FileLoadData fileLoadData = FilesLoadData[resourceId];
			if (resourceFilename == fileLoadData.Filename || resourceFilename.StartsWith("$$$___magic___$$$"))
			{
				return false;
			}
			string filename = FileUtils.GetFilename(resourceFilename);
			return File.Exists(Path.Combine(fileLoadData.BasePath ?? "", filename));
		}

		protected void ReleaseImport()
		{
			if (Scene != IntPtr.Zero)
			{
				AssimpInterop.ai_ReleaseImport(Scene);
			}
		}

		public void Dispose()
		{
			RootNodeData = null;
			MaterialData = null;
			MeshData = null;
			AnimationData = null;
			CameraData = null;
			Metadata = null;
			NodesPath = null;
			LoadedMaterials = null;
			LoadedTextures = null;
			LoadedBoneNames = null;
			MeshDataConnections = null;
			EmbeddedTextures = null;
			NodeId = 0u;
			HasBoneInfo = false;
			HasBlendShapes = false;
			Scene = IntPtr.Zero;
		}
	}
}
