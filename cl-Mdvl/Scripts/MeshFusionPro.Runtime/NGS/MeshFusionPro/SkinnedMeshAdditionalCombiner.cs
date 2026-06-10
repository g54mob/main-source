using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace NGS.MeshFusionPro
{
	public class SkinnedMeshAdditionalCombiner
	{
		private struct BoneInfo
		{
			public Transform bone;

			public Matrix4x4 bindpose;

			public BoneInfo(Transform bone, Matrix4x4 bindpose)
			{
				this.bone = bone;
				this.bindpose = bindpose;
			}
		}

		private List<Transform> _bones;

		private List<Matrix4x4> _bindposes;

		private List<BoneWeight> _boneWeights;

		private Dictionary<BoneInfo, int> _boneToIndex;

		private Dictionary<int, int> _tempBonesMap;

		private List<BoneWeight> _tempBoneWeights;

		private List<Matrix4x4> _tempBindposes;

		public List<Transform> Bones => _bones;

		public SkinnedMeshAdditionalCombiner()
		{
			_bones = new List<Transform>();
			_bindposes = new List<Matrix4x4>();
			_boneWeights = new List<BoneWeight>();
			_boneToIndex = new Dictionary<BoneInfo, int>();
			_tempBonesMap = new Dictionary<int, int>();
			_tempBindposes = new List<Matrix4x4>();
			_tempBoneWeights = new List<BoneWeight>();
		}

		public void Combine(IList<SkinnedMeshCombineInfo> combineInfos)
		{
			for (int i = 0; i < combineInfos.Count; i++)
			{
				_tempBonesMap.Clear();
				_tempBindposes.Clear();
				_tempBoneWeights.Clear();
				SkinnedMeshCombineInfo skinnedMeshCombineInfo = combineInfos[i];
				Mesh mesh = skinnedMeshCombineInfo.MeshCombineInfo.mesh;
				Transform[] bones = skinnedMeshCombineInfo.Bones;
				SubMeshDescriptor subMesh = mesh.GetSubMesh(skinnedMeshCombineInfo.MeshCombineInfo.submeshIndex);
				mesh.GetBindposes(_tempBindposes);
				mesh.GetBoneWeights(_tempBoneWeights);
				for (int j = 0; j < bones.Length; j++)
				{
					BoneInfo key = new BoneInfo(bones[j], _tempBindposes[j]);
					int value = -1;
					if (!_boneToIndex.TryGetValue(key, out value))
					{
						value = _bones.Count;
						_bones.Add(key.bone);
						_bindposes.Add(key.bindpose);
						_boneToIndex.Add(key, value);
					}
					_tempBonesMap.Add(j, value);
				}
				int firstVertex = subMesh.firstVertex;
				int num = firstVertex + subMesh.vertexCount;
				for (int k = firstVertex; k < num; k++)
				{
					BoneWeight item = _tempBoneWeights[k];
					item.boneIndex0 = _tempBonesMap[item.boneIndex0];
					item.boneIndex1 = _tempBonesMap[item.boneIndex1];
					item.boneIndex2 = _tempBonesMap[item.boneIndex2];
					item.boneIndex3 = _tempBonesMap[item.boneIndex3];
					_boneWeights.Add(item);
				}
			}
		}

		public void Cut(IList<CombinedMeshPart> parts)
		{
			foreach (CombinedMeshPart item in parts.OrderByDescending((CombinedMeshPart p) => p.VertexStart))
			{
				_boneWeights.RemoveRange(item.VertexStart, item.VertexCount);
			}
		}

		public void Apply(Mesh mesh)
		{
			mesh.boneWeights = _boneWeights.ToArray();
			mesh.bindposes = _bindposes.ToArray();
		}
	}
}
