using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Bozo.ModularCharacters
{
	public class BoZo_CharacterOptimizer
	{
		private class boneData
		{
			public Transform bone;

			public int index;
		}

		private struct BlendshapeData
		{
			public string name;

			public float weight;

			public float currentWeight;

			public Vector3[] deltaVertices;

			public Vector3[] deltaNormals;

			public Vector3[] deltaTangents;

			public int vertexOffset;
		}

		private static string path = "/BoZo_StylizedModularCharacters/CustomCharacters/Prefabs";

		private MergedMaterialData[] mergedMaterialDatas;

		public async void OptimizeCharacter(OutfitSystem source, CharacterData data)
		{
			if (source.mergeMaterial == null)
			{
				Debug.Log("Merge Material required, please assign one in the inspector");
				return;
			}
			OutfitSystem body = await PrepareMergeBase(source, data);
			_ = body.height;
			mergedMaterialDatas = source.materialData;
			GameObject characterBody = await Merge(body);
			source.customMaps = body.customMaps;
			UnityEngine.Object.Destroy(body.gameObject);
			BMAC_SaveSystem.LoadBodyMods(body, data);
			source.SetCharacterBody(characterBody);
		}

		public async void SaveOptimizedCharacter(OutfitSystem source, CharacterData data)
		{
			OutfitSystem body = await PrepareMergeBase(source, data);
			_ = body.height;
			body.data = data;
			mergedMaterialDatas = source.materialData;
			GameObject characterBody = await Merge(body, saveAsPrefab: true, source.prefabName);
			UnityEngine.Object.Destroy(body.gameObject);
			BMAC_SaveSystem.LoadBodyMods(body, data);
			source.SetCharacterBody(characterBody);
			source.MuteHeightChange(value: false);
		}

		private async Task<OutfitSystem> PrepareMergeBase(OutfitSystem source, CharacterData data)
		{
			OutfitSystem original = Resources.Load<OutfitSystem>("BSMC_CharacterMergedBase");
			OutfitSystem body = UnityEngine.Object.Instantiate(original);
			body.mergeBase = true;
			body.MuteHeightChange(value: true);
			body.animator.enabled = false;
			await BMAC_SaveSystem.LoadCharacter(body, data, manualShapeApply: true, async: true);
			body.mergeMaterial = source.mergeMaterial;
			return body;
		}

		public async Task<GameObject> Merge(OutfitSystem outfitSystem, bool saveAsPrefab = false, string saveName = "")
		{
			if (!Application.isPlaying)
			{
				return null;
			}
			List<Outfit> outfitsToMerge = outfitSystem.GetOutfits();
			SkinnedMeshRenderer rig = outfitSystem.GetCharacterBody();
			Material mergeMaterial = outfitSystem.mergeMaterial;
			if (outfitsToMerge == null || outfitsToMerge.Count == 0)
			{
				Debug.LogError("No Skinned Mesh Renderers assigned.");
				return null;
			}
			List<Transform> masterBones = outfitSystem.GetBones().Values.ToList();
			Transform rootBone = rig.rootBone;
			Transform parent = rig.transform.parent;
			Dictionary<string, boneData> boneMap = new Dictionary<string, boneData>();
			for (int i = 0; i < masterBones.Count; i++)
			{
				boneData boneData2 = new boneData();
				boneData2.bone = masterBones[i];
				boneData2.index = i;
				boneMap.Add(masterBones[i].name, boneData2);
			}
			bool MergeMaterials = true;
			List<Vector3> vertices = new List<Vector3>();
			List<Vector3> normals = new List<Vector3>();
			List<Vector4> tangents = new List<Vector4>();
			List<Vector2> uv = new List<Vector2>();
			List<Vector2> uv2 = new List<Vector2>();
			List<Color> colors = new List<Color>();
			List<BoneWeight> boneWeights = new List<BoneWeight>();
			List<Material> materials = new List<Material>();
			List<Matrix4x4> bindposes = new List<Matrix4x4>();
			Dictionary<string, List<BlendshapeData>> blendshapeGroups = new Dictionary<string, List<BlendshapeData>>();
			int vertexOffset = 0;
			List<List<int>> submeshTriangles = new List<List<int>>();
			Texture2D mergedTexture = new Texture2D(2, 2);
			new Dictionary<string, Rect>();
			Material newMaterial = new Material(mergeMaterial)
			{
				mainTexture = null
			};
			List<Renderer> rendererList = new List<Renderer>();
			foreach (Outfit item5 in outfitsToMerge)
			{
				if (item5.gameObject.activeSelf)
				{
					rendererList.AddRange(item5.GetComponentsInChildren<Renderer>());
					Animator componentInChildren = item5.GetComponentInChildren<Animator>();
					if (componentInChildren != null)
					{
						componentInChildren.enabled = false;
					}
				}
			}
			foreach (Renderer item6 in rendererList)
			{
				item6.enabled = false;
			}
			(Texture2D, Dictionary<string, Texture2D>, Dictionary<string, Rect>, Dictionary<string, Texture2D>) tuple = await CreateMergedTextures(outfitsToMerge);
			newMaterial.mainTexture = tuple.Item1;
			MergedMaterialData[] array = mergedMaterialDatas;
			foreach (MergedMaterialData mergedMaterialData in array)
			{
				newMaterial.SetTexture(mergedMaterialData.toMateiralProperty, tuple.Item2[mergedMaterialData.toMateiralProperty]);
			}
			Dictionary<string, Rect> item = tuple.Item3;
			outfitSystem.customMaps = tuple.Item4;
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			for (int k = 0; k < rendererList.Count; k++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = rendererList[k].GetComponentInChildren<SkinnedMeshRenderer>(includeInactive: true);
				Outfit componentInParent = rendererList[k].GetComponentInParent<Outfit>(includeInactive: true);
				if (skinnedMeshRenderer == null)
				{
					Mesh sharedMesh = rendererList[k].GetComponentInChildren<MeshFilter>(includeInactive: true).sharedMesh;
					MeshRenderer componentInChildren2 = rendererList[k].GetComponentInChildren<MeshRenderer>(includeInactive: true);
					Material sharedMaterial = componentInChildren2.sharedMaterial;
					GameObject gameObject = componentInChildren2.gameObject;
					UnityEngine.Object.DestroyImmediate(componentInChildren2);
					UnityEngine.Object.DestroyImmediate(gameObject.GetComponent<MeshFilter>());
					skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();
					skinnedMeshRenderer.sharedMaterial = sharedMaterial;
					skinnedMeshRenderer.sharedMesh = sharedMesh;
				}
				Mesh sharedMesh2 = skinnedMeshRenderer.sharedMesh;
				bool flag = true;
				if (skinnedMeshRenderer.rootBone != null && !boneMap.ContainsKey(skinnedMeshRenderer.rootBone.name))
				{
					int count = masterBones.Count;
					if (componentInParent.AttachPoint == "")
					{
						Debug.Log("What are you doing here? Stop the show...");
						return null;
					}
					skinnedMeshRenderer.rootBone = boneMap[componentInParent.AttachPoint].bone;
					masterBones.AddRange(skinnedMeshRenderer.bones);
					skinnedMeshRenderer.bones[0].SetParent(boneMap[componentInParent.AttachPoint].bone);
					for (int l = 0; l < skinnedMeshRenderer.bones.Length; l++)
					{
						int num = 1;
						boneData boneData3 = new boneData();
						boneData3.bone = skinnedMeshRenderer.bones[l];
						boneData3.index = l + count;
						try
						{
							boneMap.Add(skinnedMeshRenderer.bones[l].name, boneData3);
						}
						catch
						{
							Debug.LogWarning("Duplicate bone naming in: <" + componentInParent.name + "> <" + skinnedMeshRenderer.bones[l].name + ">Please give bone a unique name");
							boneMap.Add(skinnedMeshRenderer.bones[l].name + num, boneData3);
						}
					}
				}
				Transform[] bones = skinnedMeshRenderer.bones;
				if (skinnedMeshRenderer.rootBone != null)
				{
					Debug.Log(bones.Length);
					for (int m = 0; m < bones.Length; m++)
					{
						Transform transform = bones[m];
						int num2 = -1;
						if (!(transform == null))
						{
							if (boneMap.ContainsKey(transform.name))
							{
								num2 = boneMap[transform.name].index;
							}
							else
							{
								Debug.LogWarning(transform.name + " Is not in BoneMap");
							}
							if (num2 != -1)
							{
								dictionary[m] = num2;
							}
						}
					}
				}
				else
				{
					flag = false;
					int index = boneMap[componentInParent.AttachPoint].index;
					dictionary[0] = index;
					skinnedMeshRenderer.bones = masterBones.ToArray();
					skinnedMeshRenderer.rootBone = rootBone;
				}
				Matrix4x4 localToWorldMatrix = skinnedMeshRenderer.transform.localToWorldMatrix;
				Vector3[] array2 = new Vector3[sharedMesh2.vertexCount];
				Vector3[] array3 = new Vector3[sharedMesh2.vertexCount];
				Vector4[] array4 = new Vector4[sharedMesh2.vertexCount];
				Vector3[] vertices2 = sharedMesh2.vertices;
				Vector3[] normals2 = sharedMesh2.normals;
				Vector4[] tangents2 = sharedMesh2.tangents;
				for (int n = 0; n < sharedMesh2.vertexCount; n++)
				{
					array2[n] = localToWorldMatrix.MultiplyPoint3x4(vertices2[n]);
					array3[n] = localToWorldMatrix.MultiplyVector(normals2[n]).normalized;
					Vector3 normalized = localToWorldMatrix.MultiplyVector(new Vector3(tangents2[n].x, tangents2[n].y, tangents2[n].z)).normalized;
					array4[n] = new Vector4(normalized.x, normalized.y, normalized.z, tangents2[n].w);
				}
				vertices.AddRange(array2);
				normals.AddRange(array3);
				tangents.AddRange(array4);
				if (MergeMaterials)
				{
					Vector2[] uv3 = sharedMesh2.uv;
					Vector2[] array5 = new Vector2[uv3.Length];
					Rect rect = item[componentInParent.name];
					for (int num3 = 0; num3 < uv3.Length; num3++)
					{
						Vector2 vector = uv3[num3];
						array5[num3] = new Vector2(rect.x + vector.x * rect.width, rect.y + vector.y * rect.height);
					}
					uv.AddRange(array5);
				}
				else
				{
					uv.AddRange(sharedMesh2.uv);
					if (sharedMesh2.uv2 != null && sharedMesh2.uv2.Length == sharedMesh2.vertexCount)
					{
						uv2.AddRange(sharedMesh2.uv2);
					}
					else
					{
						Vector2[] collection = new Vector2[sharedMesh2.vertexCount];
						uv2.AddRange(collection);
					}
				}
				Color[] colors2 = sharedMesh2.colors;
				if (colors2 != null && colors2.Length == sharedMesh2.vertexCount)
				{
					colors.AddRange(colors2);
				}
				else
				{
					for (int num4 = 0; num4 < sharedMesh2.vertexCount; num4++)
					{
						colors.Add(Color.white);
					}
				}
				if (flag)
				{
					BoneWeight[] boneWeights2 = sharedMesh2.boneWeights;
					for (int j = 0; j < boneWeights2.Length; j++)
					{
						BoneWeight boneWeight = boneWeights2[j];
						if (!dictionary.ContainsKey(boneWeight.boneIndex0))
						{
							BoneWeight item2 = new BoneWeight
							{
								boneIndex0 = dictionary[boneMap[skinnedMeshRenderer.rootBone.name].index],
								weight0 = 1f
							};
							boneWeights.Add(item2);
							continue;
						}
						BoneWeight item3 = new BoneWeight
						{
							boneIndex0 = dictionary[boneWeight.boneIndex0],
							boneIndex1 = dictionary[boneWeight.boneIndex1],
							boneIndex2 = dictionary[boneWeight.boneIndex2],
							boneIndex3 = dictionary[boneWeight.boneIndex3],
							weight0 = boneWeight.weight0,
							weight1 = boneWeight.weight1,
							weight2 = boneWeight.weight2,
							weight3 = boneWeight.weight3
						};
						boneWeights.Add(item3);
					}
				}
				else
				{
					BoneWeight[] boneWeights2 = new BoneWeight[sharedMesh2.vertexCount];
					foreach (BoneWeight boneWeight2 in boneWeights2)
					{
						BoneWeight item4 = new BoneWeight
						{
							boneIndex0 = dictionary[boneWeight2.boneIndex0],
							weight0 = 1f
						};
						boneWeights.Add(item4);
					}
				}
				if (MergeMaterials)
				{
					for (int num5 = 0; num5 < sharedMesh2.subMeshCount; num5++)
					{
						List<int> list = sharedMesh2.GetTriangles(num5).ToList();
						for (int num6 = 0; num6 < list.Count; num6++)
						{
							list[num6] += vertexOffset;
						}
						if (submeshTriangles.Count == 0)
						{
							submeshTriangles.Add(list);
						}
						else
						{
							submeshTriangles[0].AddRange(list);
						}
					}
				}
				else
				{
					for (int num7 = 0; num7 < sharedMesh2.subMeshCount; num7++)
					{
						List<int> list2 = sharedMesh2.GetTriangles(num7).ToList();
						for (int num8 = 0; num8 < list2.Count; num8++)
						{
							list2[num8] += vertexOffset;
						}
						submeshTriangles.Add(list2);
						materials.Add(skinnedMeshRenderer.sharedMaterials[num7]);
					}
				}
				int blendShapeCount = sharedMesh2.blendShapeCount;
				for (int num9 = 0; num9 < blendShapeCount; num9++)
				{
					string text = sharedMesh2.GetBlendShapeName(num9);
					string[] array6 = text.Split(".");
					if (array6.Length != 0)
					{
						text = text.Replace(array6[0] + ".", "");
					}
					int blendShapeFrameCount = sharedMesh2.GetBlendShapeFrameCount(num9);
					for (int num10 = 0; num10 < blendShapeFrameCount; num10++)
					{
						float blendShapeFrameWeight = sharedMesh2.GetBlendShapeFrameWeight(num9, num10);
						float blendShapeWeight = skinnedMeshRenderer.GetBlendShapeWeight(num9);
						Vector3[] deltaVertices = new Vector3[sharedMesh2.vertexCount];
						Vector3[] deltaNormals = new Vector3[sharedMesh2.vertexCount];
						Vector3[] deltaTangents = new Vector3[sharedMesh2.vertexCount];
						sharedMesh2.GetBlendShapeFrameVertices(num9, num10, deltaVertices, deltaNormals, deltaTangents);
						if (!blendshapeGroups.ContainsKey(text))
						{
							blendshapeGroups[text] = new List<BlendshapeData>();
						}
						blendshapeGroups[text].Add(new BlendshapeData
						{
							name = text,
							weight = blendShapeFrameWeight,
							currentWeight = blendShapeWeight,
							deltaVertices = deltaVertices,
							deltaNormals = deltaNormals,
							deltaTangents = deltaTangents,
							vertexOffset = vertexOffset
						});
					}
				}
				vertexOffset += sharedMesh2.vertexCount;
			}
			foreach (Outfit item7 in outfitsToMerge)
			{
				UnityEngine.Object.DestroyImmediate(item7.gameObject);
			}
			UnityEngine.Object.DestroyImmediate(rig.gameObject);
			for (int num11 = 0; num11 < masterBones.Count; num11++)
			{
				bindposes.Add(masterBones[num11].worldToLocalMatrix * rootBone.localToWorldMatrix);
			}
			Mesh mesh = new Mesh();
			mesh.name = "CombinedSkinnedMesh";
			mesh.SetVertices(vertices);
			mesh.SetNormals(normals);
			mesh.SetTangents(tangents);
			mesh.SetUVs(0, uv);
			mesh.SetUVs(1, uv2);
			mesh.SetColors(colors);
			mesh.boneWeights = boneWeights.ToArray();
			mesh.bindposes = bindposes.ToArray();
			mesh.subMeshCount = submeshTriangles.Count;
			for (int num12 = 0; num12 < submeshTriangles.Count; num12++)
			{
				mesh.SetTriangles(submeshTriangles[num12], num12);
			}
			foreach (KeyValuePair<string, List<BlendshapeData>> item8 in blendshapeGroups)
			{
				string key = item8.Key;
				List<BlendshapeData> value = item8.Value;
				float weight = value[0].weight;
				int vertexCount = mesh.vertexCount;
				Vector3[] array7 = new Vector3[vertexCount];
				Vector3[] array8 = new Vector3[vertexCount];
				Vector3[] array9 = new Vector3[vertexCount];
				foreach (BlendshapeData item9 in value)
				{
					for (int num13 = 0; num13 < item9.deltaVertices.Length; num13++)
					{
						array7[item9.vertexOffset + num13] = item9.deltaVertices[num13];
						array8[item9.vertexOffset + num13] = item9.deltaNormals[num13];
						array9[item9.vertexOffset + num13] = item9.deltaTangents[num13];
					}
				}
				mesh.AddBlendShapeFrame(key, weight, array7, array8, array9);
			}
			SkinnedMeshRenderer skinnedMeshRenderer2 = new GameObject("CombinedSkinnedMesh").AddComponent<SkinnedMeshRenderer>();
			skinnedMeshRenderer2.sharedMesh = mesh;
			skinnedMeshRenderer2.bones = masterBones.ToArray();
			skinnedMeshRenderer2.rootBone = rootBone;
			if ((bool)mergedTexture)
			{
				skinnedMeshRenderer2.material = newMaterial;
			}
			else
			{
				skinnedMeshRenderer2.materials = materials.ToArray();
			}
			foreach (string key2 in blendshapeGroups.Keys)
			{
				BlendshapeData blendshapeData = blendshapeGroups[key2][0];
				int blendShapeIndex = skinnedMeshRenderer2.sharedMesh.GetBlendShapeIndex(blendshapeData.name);
				skinnedMeshRenderer2.SetBlendShapeWeight(blendShapeIndex, blendshapeData.currentWeight);
			}
			skinnedMeshRenderer2.transform.parent = parent;
			Debug.Log("Dynamic skinning merge complete with bone remapping!");
			return parent.gameObject;
		}

		public async Task<(Texture2D texture, Dictionary<string, Texture2D> additionalMaps, Dictionary<string, Rect> rect, Dictionary<string, Texture2D> customMaps)> CreateMergedTextures(List<Outfit> outfits)
		{
			List<Texture2D> diffuseMaps = new List<Texture2D>();
			new List<Texture2D>();
			Dictionary<string, Texture2D[]> additionalMaps = new Dictionary<string, Texture2D[]>();
			Dictionary<string, Texture2D[]> customMaps = new Dictionary<string, Texture2D[]>();
			Material bakeMaterial = new Material(Shader.Find("BoZo/BakeTexture"));
			int index = 0;
			foreach (Outfit outfit in outfits)
			{
				SkinnedMeshRenderer componentInChildren = outfit.GetComponentInChildren<SkinnedMeshRenderer>();
				Renderer renderer = outfit.GetComponentInChildren<Renderer>();
				List<Mesh> list = new List<Mesh>();
				SkinnedMeshRenderer[] skinnedRenderers = outfit.skinnedRenderers;
				foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedRenderers)
				{
					list.Add(skinnedMeshRenderer.sharedMesh);
				}
				if (componentInChildren == null)
				{
					list.Add(outfit.GetComponentInChildren<MeshFilter>(includeInactive: true).sharedMesh);
				}
				Material originalMaterial = renderer.sharedMaterial;
				renderer.sharedMaterial = bakeMaterial;
				if (!outfit.customShader)
				{
					bakeMaterial.mainTexture = originalMaterial.mainTexture;
					bakeMaterial.SetTexture("_DecalMap", originalMaterial.GetTexture("_DecalMap"));
					bakeMaterial.SetFloat("_DecalUVSet", originalMaterial.GetFloat("_DecalUVSet"));
					bakeMaterial.SetFloat("_DecalBlend", originalMaterial.GetFloat("_DecalBlend"));
					bakeMaterial.SetVector("_DecalScale", originalMaterial.GetVector("_DecalScale"));
					bakeMaterial.SetTexture("_PatternMap", originalMaterial.GetTexture("_PatternMap"));
					bakeMaterial.SetFloat("_PatternUVSet", originalMaterial.GetFloat("_PatternUVSet"));
					bakeMaterial.SetFloat("_PatternBlend", originalMaterial.GetFloat("_PatternBlend"));
					bakeMaterial.SetVector("_PatternScale", originalMaterial.GetVector("_PatternScale"));
					for (int j = 0; j < 9; j++)
					{
						bakeMaterial.SetColor("_Color_" + (j + 1), originalMaterial.GetColor("_Color_" + (j + 1)));
						bakeMaterial.SetColor("_Color_" + (j + 1), originalMaterial.GetColor("_Color_" + (j + 1)));
						if (j + 1 <= 3)
						{
							bakeMaterial.SetColor("_DecalColor_" + (j + 1), originalMaterial.GetColor("_DecalColor_" + (j + 1)));
							bakeMaterial.SetColor("_PatternColor_" + (j + 1), originalMaterial.GetColor("_PatternColor_" + (j + 1)));
						}
					}
				}
				else
				{
					diffuseMaps.Add((Texture2D)originalMaterial.mainTexture);
				}
				MergedMaterialData[] array = mergedMaterialDatas;
				foreach (MergedMaterialData mergedMaterialData in array)
				{
					if (!additionalMaps.ContainsKey(mergedMaterialData.toMateiralProperty))
					{
						additionalMaps[mergedMaterialData.toMateiralProperty] = new Texture2D[outfits.Count];
					}
					additionalMaps[mergedMaterialData.toMateiralProperty][index] = (Texture2D)originalMaterial.GetTexture(mergedMaterialData.fromMateiralProperty);
				}
				IOutfitExtension[] componentsInChildren = outfit.GetComponentsInChildren<IOutfitExtension>();
				foreach (IOutfitExtension outfitExtension in componentsInChildren)
				{
					if (outfitExtension.GetValue() is Texture2D && !customMaps.ContainsKey(outfitExtension.GetID()))
					{
						customMaps[outfitExtension.GetID()] = new Texture2D[outfits.Count];
					}
					if (outfitExtension.GetValue() is Texture2D)
					{
						customMaps[outfitExtension.GetID()][index] = (Texture2D)outfitExtension.GetValue();
					}
				}
				diffuseMaps.Add(await BakeTextureAsyncTask(list, bakeMaterial));
				renderer.sharedMaterial = originalMaterial;
				RenderTexture.active = null;
				index++;
			}
			int atlasSize = 2048;
			Texture2D atlas = new Texture2D(atlasSize, atlasSize);
			new Texture2D(atlasSize, atlasSize);
			Dictionary<string, Texture2D> additionalMapsList = new Dictionary<string, Texture2D>();
			Dictionary<string, Texture2D> atlasCustomMapsList = new Dictionary<string, Texture2D>();
			atlas.wrapMode = TextureWrapMode.Repeat;
			Rect[] rects = atlas.PackTextures(diffuseMaps.ToArray(), 0, atlasSize);
			Dictionary<string, Rect> rectMap = new Dictionary<string, Rect>();
			for (int k = 0; k < outfits.Count; k++)
			{
				rectMap.Add(outfits[k].name, rects[k]);
			}
			Color32[] pixels = atlas.GetPixels32();
			atlas.SetPixels32(await DilateTextureAsync(atlas, pixels));
			atlas.Apply();
			int addIndex = 0;
			foreach (KeyValuePair<string, Texture2D[]> item in additionalMaps)
			{
				List<Texture2D> normalMaps = item.Value.ToList();
				Texture2D texture2D = new Texture2D(atlasSize, atlasSize);
				texture2D.wrapMode = TextureWrapMode.Repeat;
				Dictionary<string, Texture2D> dictionary = additionalMapsList;
				string key = item.Key;
				dictionary[key] = await RemapTextureAsync(normalMaps, rects, atlasSize, texture2D, mergedMaterialDatas[addIndex].backgroundColor);
				addIndex++;
			}
			foreach (KeyValuePair<string, Texture2D[]> item2 in customMaps)
			{
				List<Texture2D> list2 = item2.Value.ToList();
				if (list2.Count != 0)
				{
					Texture2D texture2D2 = new Texture2D(atlasSize, atlasSize);
					texture2D2.wrapMode = TextureWrapMode.Repeat;
					Dictionary<string, Texture2D> dictionary = atlasCustomMapsList;
					string key = item2.Key;
					dictionary[key] = await RemapTextureAsync(list2, rects, atlasSize, texture2D2, Color.black);
				}
			}
			return (texture: atlas, additionalMaps: additionalMapsList, rect: rectMap, customMaps: atlasCustomMapsList);
		}

		public async Task<Texture2D> BakeTextureAsyncTask(List<Mesh> mesh, Material bakeMaterial)
		{
			int textureSize = bakeMaterial.mainTexture.width;
			RenderTexture renderTexture = new RenderTexture(textureSize, textureSize, 0, RenderTextureFormat.ARGB32)
			{
				useMipMap = false,
				autoGenerateMips = false
			};
			renderTexture.Create();
			CommandBuffer commandBuffer = new CommandBuffer();
			commandBuffer.SetRenderTarget(renderTexture);
			commandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear);
			foreach (Mesh item in mesh)
			{
				commandBuffer.DrawMesh(item, Matrix4x4.identity, bakeMaterial);
			}
			Graphics.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Release();
			TaskCompletionSource<Texture2D> tcs = new TaskCompletionSource<Texture2D>();
			AsyncGPUReadback.Request(renderTexture, 0, TextureFormat.RGBA32, delegate(AsyncGPUReadbackRequest request)
			{
				if (request.hasError)
				{
					tcs.SetException(new Exception("Async GPU readback failed."));
				}
				else
				{
					NativeArray<Color32> data = request.GetData<Color32>();
					Texture2D texture2D = new Texture2D(textureSize, textureSize, TextureFormat.RGBA32, mipChain: false);
					texture2D.LoadRawTextureData(data);
					texture2D.Apply();
					tcs.SetResult(texture2D);
				}
			});
			return await tcs.Task;
		}

		public async Task<Texture2D> RemapTextureAsync(List<Texture2D> normalMaps, Rect[] rects, int atlasSize, Texture2D atlasNormal, Color fillColor)
		{
			List<Task> list = new List<Task>();
			Color[] array = new Color[atlasSize * atlasSize];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = fillColor;
			}
			atlasNormal.SetPixels(array);
			for (int j = 0; j < normalMaps.Count; j++)
			{
				if (normalMaps[j] == null)
				{
					continue;
				}
				Rect rect = rects[j];
				int num = Mathf.RoundToInt(rect.x * (float)atlasSize);
				int num2 = Mathf.RoundToInt(rect.y * (float)atlasSize);
				int num3 = Mathf.RoundToInt(rect.width * (float)atlasSize);
				int num4 = Mathf.RoundToInt(rect.height * (float)atlasSize);
				Texture2D source = normalMaps[j];
				RenderTexture temporary = RenderTexture.GetTemporary(num3, num4, 0, RenderTextureFormat.ARGB32);
				Graphics.Blit(source, temporary);
				int copyX = num;
				int copyY = num2;
				int copyW = num3;
				int copyH = num4;
				RenderTexture copyRT = temporary;
				TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
				list.Add(tcs.Task);
				AsyncGPUReadback.Request(copyRT, 0, TextureFormat.RGBA32, delegate(AsyncGPUReadbackRequest request)
				{
					if (request.hasError)
					{
						Debug.LogError("Normal map readback failed");
						tcs.SetResult(result: true);
						RenderTexture.ReleaseTemporary(copyRT);
					}
					else
					{
						Color32[] array2 = request.GetData<Color32>().ToArray();
						Color[] array3 = new Color[array2.Length];
						for (int k = 0; k < array2.Length; k++)
						{
							array3[k] = array2[k];
						}
						atlasNormal.SetPixels(copyX, copyY, copyW, copyH, array3);
						RenderTexture.ReleaseTemporary(copyRT);
						tcs.SetResult(result: true);
					}
				});
			}
			await Task.WhenAll(list);
			atlasNormal.Apply();
			return atlasNormal;
		}

		public async Task<Color32[]> DilateTextureAsync(Texture2D tex, Color32[] pixels)
		{
			int iterations = 2;
			int w = tex.width;
			int h = tex.height;
			return await Task.Run(delegate
			{
				Color32[] array = new Color32[pixels.Length];
				Color32[] array2 = new Color32[pixels.Length];
				bool[] array3 = new bool[pixels.Length];
				for (int i = 0; i < pixels.Length; i++)
				{
					array[i] = pixels[i];
					array3[i] = pixels[i].a >= byte.MaxValue;
				}
				for (int j = 0; j < iterations; j++)
				{
					array.CopyTo(array2, 0);
					for (int k = 0; k < h; k++)
					{
						for (int l = 0; l < w; l++)
						{
							int num = k * w + l;
							if (array[num].a < byte.MaxValue)
							{
								for (int m = -1; m <= 1; m++)
								{
									int num4;
									for (int n = -1; n <= 1; n++)
									{
										if (n == 0 && m == 0)
										{
											continue;
										}
										int num2 = l + n;
										int num3 = k + m;
										if (num2 < 0 || num2 >= w || num3 < 0 || num3 >= h)
										{
											continue;
										}
										num4 = num3 * w + num2;
										if (!array3[num4])
										{
											continue;
										}
										goto IL_0102;
									}
									continue;
									IL_0102:
									array2[num] = array[num4];
									break;
								}
							}
						}
					}
					Color32[] array4 = array;
					array = array2;
					array2 = array4;
					for (int num5 = 0; num5 < pixels.Length; num5++)
					{
						if (array[num5].a >= 1)
						{
							array3[num5] = true;
						}
					}
				}
				return array;
			});
		}
	}
}
