using System;
using System.Collections.Generic;
using System.Linq;
using UniHumanoid;
using UnityEngine;

namespace VRM
{
	public static class BoneNormalizer
	{
		private class BlendShapeReport
		{
			private struct BlendShapeStat
			{
				public int Index;

				public string Name;

				public int VertexCount;

				public int NormalCount;

				public int TangentCount;

				public override string ToString()
				{
					return $"[{Index}]{Name}: {VertexCount}, {NormalCount}, {TangentCount}\n";
				}
			}

			private string m_name;

			private int m_count;

			private List<BlendShapeStat> m_stats = new List<BlendShapeStat>();

			public int Count => m_stats.Count;

			public BlendShapeReport(Mesh mesh)
			{
				m_name = mesh.name;
				m_count = mesh.vertexCount;
			}

			public void SetCount(int index, string name, int v, int n, int t)
			{
				m_stats.Add(new BlendShapeStat
				{
					Index = index,
					Name = name,
					VertexCount = v,
					NormalCount = n,
					TangentCount = t
				});
			}

			public override string ToString()
			{
				return string.Format("NormalizeSkinnedMesh: {0}({1}verts)\n{2}", m_name, m_count, string.Join("", m_stats.Select((BlendShapeStat x) => x.ToString()).ToArray()));
			}
		}

		public struct NormalizedResult
		{
			public GameObject Root;

			public Dictionary<Transform, Transform> BoneMap;
		}

		private static void CopyAndBuild(Transform src, Transform dst, Dictionary<Transform, Transform> boneMap)
		{
			boneMap[src] = dst;
			foreach (Transform item in src)
			{
				if (item.gameObject.activeSelf)
				{
					GameObject gameObject = new GameObject(item.name);
					gameObject.transform.SetParent(dst);
					gameObject.transform.position = item.position;
					CopyAndBuild(item, gameObject.transform, boneMap);
				}
			}
		}

		private static IEnumerable<Transform> Traverse(this Transform t)
		{
			yield return t;
			foreach (Transform item in t)
			{
				foreach (Transform item2 in item.Traverse())
				{
					yield return item2;
				}
			}
		}

		private static void EnforceTPose(GameObject go)
		{
			Animator component = go.GetComponent<Animator>();
			if (component == null)
			{
				throw new ArgumentException("Animator with avatar is required");
			}
			Avatar avatar = component.avatar;
			if (avatar == null)
			{
				throw new ArgumentException("avatar is required");
			}
			if (!avatar.isValid)
			{
				throw new ArgumentException("invalid avatar");
			}
			if (!avatar.isHuman)
			{
				throw new ArgumentException("avatar is not human");
			}
			HumanPoseTransfer.SetTPose(avatar, go.transform);
		}

		private static GameObject NormalizeHierarchy(GameObject go, Dictionary<Transform, Transform> boneMap)
		{
			GameObject gameObject = new GameObject(go.name + "(normalized)");
			gameObject.transform.position = go.transform.position;
			CopyAndBuild(go.transform, gameObject.transform, boneMap);
			Animator src = go.GetComponent<Animator>();
			Dictionary<HumanBodyBones, Transform> humanBones = (from HumanBodyBones x in Enum.GetValues(typeof(HumanBodyBones))
				where x != HumanBodyBones.LastBone
				select new
				{
					Key = x,
					Value = src.GetBoneTransform(x)
				} into x
				where x.Value != null
				where boneMap.ContainsKey(x.Value)
				select x).ToDictionary(x => x.Key, x => boneMap[x.Value]);
			Animator animator = gameObject.AddComponent<Animator>();
			VRMHumanoidDescription component = go.GetComponent<VRMHumanoidDescription>();
			AvatarDescription avatarDescription = AvatarDescription.Create();
			if (component != null && component.Description != null)
			{
				avatarDescription.armStretch = component.Description.armStretch;
				avatarDescription.legStretch = component.Description.legStretch;
				avatarDescription.upperArmTwist = component.Description.upperArmTwist;
				avatarDescription.lowerArmTwist = component.Description.lowerArmTwist;
				avatarDescription.upperLegTwist = component.Description.upperLegTwist;
				avatarDescription.lowerLegTwist = component.Description.lowerLegTwist;
				avatarDescription.feetSpacing = component.Description.feetSpacing;
				avatarDescription.hasTranslationDoF = component.Description.hasTranslationDoF;
			}
			avatarDescription.SetHumanBones(humanBones);
			Avatar avatar = avatarDescription.CreateAvatar(gameObject.transform);
			avatar.name = go.name + ".normalized";
			animator.avatar = avatar;
			gameObject.AddComponent<HumanPoseTransfer>().Avatar = avatar;
			return gameObject;
		}

		private static bool CopyOrDropWeight(int[] indexMap, int srcIndex, float weight, Action<int, float> setter)
		{
			if (srcIndex < 0 || srcIndex >= indexMap.Length)
			{
				setter(0, 0f);
				return false;
			}
			int num = indexMap[srcIndex];
			if (num != -1)
			{
				setter(num, weight);
				return true;
			}
			setter(0, 0f);
			return false;
		}

		public static BoneWeight[] MapBoneWeight(BoneWeight[] src, Dictionary<Transform, Transform> boneMap, Transform[] srcBones, Transform[] dstBones)
		{
			int[] array = new int[srcBones.Length];
			for (int i = 0; i < srcBones.Length; i++)
			{
				Transform transform = srcBones[i];
				Transform value;
				if (transform == null)
				{
					array[i] = -1;
					Debug.LogWarningFormat("bones[{0}] is null", i);
				}
				else if (boneMap.TryGetValue(transform, out value))
				{
					int num = dstBones.IndexOf(value);
					if (num == -1)
					{
						throw new Exception();
					}
					array[i] = num;
				}
				else
				{
					array[i] = -1;
					Debug.LogWarningFormat("{0} is removed", transform.name);
				}
			}
			BoneWeight[] newBoneWeights = new BoneWeight[src.Length];
			int i2 = 0;
			while (i2 < src.Length)
			{
				BoneWeight boneWeight = src[i2];
				CopyOrDropWeight(array, boneWeight.boneIndex0, boneWeight.weight0, delegate(int newIndex, float newWeight)
				{
					newBoneWeights[i2].boneIndex0 = newIndex;
					newBoneWeights[i2].weight0 = newWeight;
				});
				CopyOrDropWeight(array, boneWeight.boneIndex1, boneWeight.weight1, delegate(int newIndex, float newWeight)
				{
					newBoneWeights[i2].boneIndex1 = newIndex;
					newBoneWeights[i2].weight1 = newWeight;
				});
				CopyOrDropWeight(array, boneWeight.boneIndex2, boneWeight.weight2, delegate(int newIndex, float newWeight)
				{
					newBoneWeights[i2].boneIndex2 = newIndex;
					newBoneWeights[i2].weight2 = newWeight;
				});
				CopyOrDropWeight(array, boneWeight.boneIndex3, boneWeight.weight3, delegate(int newIndex, float newWeight)
				{
					newBoneWeights[i2].boneIndex3 = newIndex;
					newBoneWeights[i2].weight3 = newWeight;
				});
				int num2 = i2 + 1;
				i2 = num2;
			}
			return newBoneWeights;
		}

		private static void NormalizeSkinnedMesh(Transform src, Transform dst, Dictionary<Transform, Transform> boneMap, bool clearBlendShape)
		{
			SkinnedMeshRenderer component = src.GetComponent<SkinnedMeshRenderer>();
			if (component == null || !component.enabled || component.sharedMesh == null || component.sharedMesh.vertexCount == 0)
			{
				return;
			}
			Mesh mesh = component.sharedMesh;
			Mesh sharedMesh = mesh;
			if (clearBlendShape)
			{
				for (int i = 0; i < mesh.blendShapeCount; i++)
				{
					component.SetBlendShapeWeight(i, 0f);
				}
			}
			Transform[] array = (from x in component.bones
				where x != null && boneMap.ContainsKey(x)
				select boneMap[x]).ToArray();
			bool flag = component.bones != null && component.bones.Length != 0;
			if (!flag)
			{
				mesh = mesh.Copy(copyBlendShape: true);
				BoneWeight bw = new BoneWeight
				{
					boneIndex0 = 0,
					boneIndex1 = 0,
					boneIndex2 = 0,
					boneIndex3 = 0,
					weight0 = 1f,
					weight1 = 0f,
					weight2 = 0f,
					weight3 = 0f
				};
				mesh.boneWeights = (from x in Enumerable.Range(0, mesh.vertexCount)
					select bw).ToArray();
				mesh.bindposes = new Matrix4x4[1] { Matrix4x4.identity };
				component.rootBone = component.transform;
				array = new Transform[1] { boneMap[component.transform] };
				component.bones = new Transform[1] { component.transform };
				component.sharedMesh = mesh;
			}
			Mesh mesh2 = mesh.Copy(copyBlendShape: false);
			mesh2.name = mesh.name + ".baked";
			component.BakeMesh(mesh2);
			Dictionary<int, float> dictionary = new Dictionary<int, float>();
			for (int num = 0; num < mesh.blendShapeCount; num++)
			{
				float blendShapeWeight = component.GetBlendShapeWeight(num);
				if (blendShapeWeight > 0f)
				{
					dictionary.Add(num, blendShapeWeight);
				}
			}
			mesh2.boneWeights = MapBoneWeight(mesh.boneWeights, boneMap, component.bones, array);
			mesh2.bindposes = array.Select((Transform x) => x.worldToLocalMatrix * dst.transform.localToWorldMatrix).ToArray();
			Matrix4x4 m = default(Matrix4x4);
			m.SetTRS(Vector3.zero, src.rotation, Vector3.one);
			mesh2.ApplyMatrix(m);
			Vector3[] vertices = mesh2.vertices;
			Vector3[] normals = mesh2.normals;
			Vector3[] array2 = new Vector3[vertices.Length];
			Vector3[] array3 = new Vector3[vertices.Length];
			Vector3[] deltaTangents = new Vector3[vertices.Length];
			BlendShapeReport blendShapeReport = new BlendShapeReport(mesh);
			Mesh mesh3 = new Mesh();
			for (int num2 = 0; num2 < mesh.blendShapeCount; num2++)
			{
				component.sharedMesh.GetBlendShapeFrameVertices(num2, 0, array2, array3, deltaTangents);
				int v = array2.Count((Vector3 x) => x != Vector3.zero);
				int num3 = array3.Count((Vector3 x) => x != Vector3.zero);
				int num4 = 0;
				string text = mesh.GetBlendShapeName(num2);
				if (string.IsNullOrEmpty(text))
				{
					text = $"{num2}";
				}
				blendShapeReport.SetCount(num2, text, v, num3, num4);
				component.SetBlendShapeWeight(num2, 100f);
				component.BakeMesh(mesh3);
				if (mesh3.vertices.Length != mesh2.vertices.Length)
				{
					throw new Exception("different vertex count");
				}
				float value = (dictionary.ContainsKey(num2) ? dictionary[num2] : 0f);
				component.SetBlendShapeWeight(num2, value);
				Vector3[] vertices2 = mesh3.vertices;
				for (int num5 = 0; num5 < vertices2.Length; num5++)
				{
					if (array2[num5] == Vector3.zero)
					{
						vertices2[num5] = Vector3.zero;
					}
					else
					{
						vertices2[num5] = m.MultiplyPoint(vertices2[num5]) - vertices[num5];
					}
				}
				Vector3[] normals2 = mesh3.normals;
				for (int num6 = 0; num6 < normals2.Length; num6++)
				{
					if (array3[num6] == Vector3.zero)
					{
						normals2[num6] = Vector3.zero;
					}
					else
					{
						normals2[num6] = m.MultiplyVector(normals2[num6]) - normals[num6];
					}
				}
				Vector3[] array4 = ((IEnumerable<Vector4>)mesh3.tangents).Select((Func<Vector4, Vector3>)((Vector4 x) => x)).ToArray();
				int blendShapeFrameCount = mesh.GetBlendShapeFrameCount(num2);
				for (int num7 = 0; num7 < blendShapeFrameCount; num7++)
				{
					float blendShapeFrameWeight = mesh.GetBlendShapeFrameWeight(num2, num7);
					try
					{
						mesh2.AddBlendShapeFrame(text, blendShapeFrameWeight, vertices2, (num3 > 0) ? normals2 : null, (num4 > 0) ? array4 : null);
					}
					catch (Exception)
					{
						Debug.LogErrorFormat("fail to mesh.AddBlendShapeFrame {0}.{1}", mesh2.name, mesh.GetBlendShapeName(num2));
						throw;
					}
				}
			}
			if (blendShapeReport.Count > 0)
			{
				Debug.LogFormat("{0}", blendShapeReport.ToString());
			}
			SkinnedMeshRenderer skinnedMeshRenderer = dst.gameObject.AddComponent<SkinnedMeshRenderer>();
			skinnedMeshRenderer.sharedMaterials = component.sharedMaterials;
			if (component.rootBone != null)
			{
				skinnedMeshRenderer.rootBone = boneMap[component.rootBone];
			}
			skinnedMeshRenderer.bones = array;
			skinnedMeshRenderer.sharedMesh = mesh2;
			if (!flag)
			{
				component.bones = new Transform[0];
				component.sharedMesh = sharedMesh;
			}
		}

		private static void NormalizeNoneSkinnedMesh(Transform src, Transform dst)
		{
			MeshFilter component = src.GetComponent<MeshFilter>();
			if (!(component == null) && !(component.sharedMesh == null) && component.sharedMesh.vertexCount != 0)
			{
				MeshRenderer component2 = src.GetComponent<MeshRenderer>();
				if (!(component2 == null) && component2.enabled)
				{
					MeshFilter meshFilter = dst.gameObject.AddComponent<MeshFilter>();
					Mesh mesh = component.sharedMesh.Copy(copyBlendShape: false);
					mesh.ApplyRotationAndScale(src.localToWorldMatrix);
					meshFilter.sharedMesh = mesh;
					dst.gameObject.AddComponent<MeshRenderer>().sharedMaterials = component2.sharedMaterials;
				}
			}
		}

		public static GameObject Execute(GameObject go, bool forceTPose, bool clearBlendShapeBeforeNormalize)
		{
			Dictionary<Transform, Transform> dictionary = new Dictionary<Transform, Transform>();
			if (forceTPose)
			{
				Transform boneTransform = go.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips);
				Vector3 position = boneTransform.position;
				Quaternion rotation = boneTransform.rotation;
				try
				{
					EnforceTPose(go);
				}
				finally
				{
					boneTransform.position = position;
					boneTransform.rotation = rotation;
				}
			}
			GameObject gameObject = NormalizeHierarchy(go, dictionary);
			foreach (Transform item in go.transform.Traverse())
			{
				if (dictionary.TryGetValue(item, out var value))
				{
					NormalizeSkinnedMesh(item, value, dictionary, clearBlendShapeBeforeNormalize);
					NormalizeNoneSkinnedMesh(item, value);
				}
			}
			CopyVRMComponents(go, gameObject, dictionary);
			return gameObject;
		}

		private static void CopyVRMComponents(GameObject go, GameObject root, Dictionary<Transform, Transform> map)
		{
			VRMBlendShapeProxy component = go.GetComponent<VRMBlendShapeProxy>();
			if (component != null)
			{
				root.AddComponent<VRMBlendShapeProxy>().BlendShapeAvatar = component.BlendShapeAvatar;
			}
			if (go.transform.Find("secondary") == null)
			{
				_ = go.transform;
			}
			Transform transform = root.transform.Find("secondary");
			if (transform == null)
			{
				transform = new GameObject("secondary").transform;
				transform.SetParent(root.transform, worldPositionStays: false);
			}
			VRMSpringBoneColliderGroup[] componentsInChildren = go.transform.GetComponentsInChildren<VRMSpringBoneColliderGroup>();
			foreach (VRMSpringBoneColliderGroup src in componentsInChildren)
			{
				Transform dst = map[src.transform];
				dst.gameObject.AddComponent<VRMSpringBoneColliderGroup>().Colliders = src.Colliders.Select(delegate(VRMSpringBoneColliderGroup.SphereCollider y)
				{
					Vector3 offset = dst.worldToLocalMatrix.MultiplyPoint(src.transform.localToWorldMatrix.MultiplyPoint(y.Offset));
					return new VRMSpringBoneColliderGroup.SphereCollider
					{
						Offset = offset,
						Radius = y.Radius
					};
				}).ToArray();
			}
			VRMSpringBone[] componentsInChildren2 = go.transform.GetComponentsInChildren<VRMSpringBone>();
			foreach (VRMSpringBone vRMSpringBone in componentsInChildren2)
			{
				VRMSpringBone vRMSpringBone2 = transform.gameObject.AddComponent<VRMSpringBone>();
				vRMSpringBone2.m_comment = vRMSpringBone.m_comment;
				vRMSpringBone2.m_stiffnessForce = vRMSpringBone.m_stiffnessForce;
				vRMSpringBone2.m_gravityPower = vRMSpringBone.m_gravityPower;
				vRMSpringBone2.m_gravityDir = vRMSpringBone.m_gravityDir;
				vRMSpringBone2.m_dragForce = vRMSpringBone.m_dragForce;
				if (vRMSpringBone.m_center != null)
				{
					vRMSpringBone2.m_center = map[vRMSpringBone.m_center];
				}
				vRMSpringBone2.RootBones = vRMSpringBone.RootBones.Select((Transform x) => map[x]).ToList();
				vRMSpringBone2.m_hitRadius = vRMSpringBone.m_hitRadius;
				if (vRMSpringBone.ColliderGroups != null)
				{
					vRMSpringBone2.ColliderGroups = vRMSpringBone.ColliderGroups.Select((VRMSpringBoneColliderGroup x) => map[x.transform].GetComponent<VRMSpringBoneColliderGroup>()).ToArray();
				}
			}
			VRMMetaInformation component2 = go.GetComponent<VRMMetaInformation>();
			if (component2 != null)
			{
				component2.CopyTo(root);
			}
			VRMMeta component3 = go.GetComponent<VRMMeta>();
			if (component3 != null)
			{
				root.AddComponent<VRMMeta>().Meta = component3.Meta;
			}
			VRMFirstPerson component4 = go.GetComponent<VRMFirstPerson>();
			if (component4 != null)
			{
				component4.CopyTo(root, map);
			}
			VRMHumanoidDescription vRMHumanoidDescription = root.AddComponent<VRMHumanoidDescription>();
			VRMHumanoidDescription component5 = go.GetComponent<VRMHumanoidDescription>();
			if (component5 != null)
			{
				vRMHumanoidDescription.Avatar = component5.Avatar;
				vRMHumanoidDescription.Description = component5.Description;
				return;
			}
			Animator component6 = go.GetComponent<Animator>();
			if (component6 != null)
			{
				vRMHumanoidDescription.Avatar = component6.avatar;
			}
		}
	}
}
