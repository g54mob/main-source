using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniHumanoid
{
	public static class SkeletonMeshUtility
	{
		private class MeshBuilder
		{
			private List<Vector3> m_positions = new List<Vector3>();

			private List<int> m_indices = new List<int>();

			private List<BoneWeight> m_boneWeights = new List<BoneWeight>();

			public void AddBone(Vector3 head, Vector3 tail, int boneIndex, float xWidth, float zWidth)
			{
				Vector3 normalized = (tail - head).normalized;
				Vector3 vector;
				Vector3 vector2;
				if (Vector3.Dot(normalized, Vector3.forward) >= 1f)
				{
					vector = Vector3.right;
					vector2 = Vector3.down;
				}
				else
				{
					vector = Vector3.Cross(normalized, Vector3.forward).normalized;
					vector2 = Vector3.forward;
				}
				AddBox((head + tail) * 0.5f, vector * xWidth, (tail - head) * 0.5f, vector2 * zWidth, boneIndex);
			}

			private void AddBox(Vector3 center, Vector3 xaxis, Vector3 yaxis, Vector3 zaxis, int boneIndex)
			{
				AddQuad(center - yaxis - xaxis - zaxis, center - yaxis + xaxis - zaxis, center - yaxis + xaxis + zaxis, center - yaxis - xaxis + zaxis, boneIndex);
				AddQuad(center + yaxis - xaxis - zaxis, center + yaxis + xaxis - zaxis, center + yaxis + xaxis + zaxis, center + yaxis - xaxis + zaxis, boneIndex, reverse: true);
				AddQuad(center - xaxis - yaxis - zaxis, center - xaxis + yaxis - zaxis, center - xaxis + yaxis + zaxis, center - xaxis - yaxis + zaxis, boneIndex, reverse: true);
				AddQuad(center + xaxis - yaxis - zaxis, center + xaxis + yaxis - zaxis, center + xaxis + yaxis + zaxis, center + xaxis - yaxis + zaxis, boneIndex);
				AddQuad(center - zaxis - xaxis - yaxis, center - zaxis + xaxis - yaxis, center - zaxis + xaxis + yaxis, center - zaxis - xaxis + yaxis, boneIndex, reverse: true);
				AddQuad(center + zaxis - xaxis - yaxis, center + zaxis + xaxis - yaxis, center + zaxis + xaxis + yaxis, center + zaxis - xaxis + yaxis, boneIndex);
			}

			private void AddQuad(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3, int boneIndex, bool reverse = false)
			{
				int count = m_positions.Count;
				m_positions.Add(v0);
				m_positions.Add(v1);
				m_positions.Add(v2);
				m_positions.Add(v3);
				BoneWeight item = new BoneWeight
				{
					boneIndex0 = boneIndex,
					weight0 = 1f
				};
				m_boneWeights.Add(item);
				m_boneWeights.Add(item);
				m_boneWeights.Add(item);
				m_boneWeights.Add(item);
				if (reverse)
				{
					m_indices.Add(count + 3);
					m_indices.Add(count + 2);
					m_indices.Add(count + 1);
					m_indices.Add(count + 1);
					m_indices.Add(count);
					m_indices.Add(count + 3);
				}
				else
				{
					m_indices.Add(count);
					m_indices.Add(count + 1);
					m_indices.Add(count + 2);
					m_indices.Add(count + 2);
					m_indices.Add(count + 3);
					m_indices.Add(count);
				}
			}

			public Mesh CreateMesh()
			{
				Mesh mesh = new Mesh();
				mesh.SetVertices(m_positions);
				mesh.boneWeights = m_boneWeights.ToArray();
				mesh.triangles = m_indices.ToArray();
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				return mesh;
			}
		}

		private struct BoneHeadTail
		{
			public HumanBodyBones Head;

			public HumanBodyBones Tail;

			public Vector3 TailOffset;

			public float XWidth;

			public float ZWidth;

			public BoneHeadTail(HumanBodyBones head, HumanBodyBones tail, float xWidth = 0.05f, float zWidth = 0.05f)
			{
				Head = head;
				Tail = tail;
				TailOffset = Vector3.zero;
				XWidth = xWidth;
				ZWidth = zWidth;
			}

			public BoneHeadTail(HumanBodyBones head, Vector3 tailOffset, float xWidth = 0.05f, float zWidth = 0.05f)
			{
				Head = head;
				Tail = HumanBodyBones.LastBone;
				TailOffset = tailOffset;
				XWidth = xWidth;
				ZWidth = zWidth;
			}
		}

		private static BoneHeadTail[] Bones = new BoneHeadTail[21]
		{
			new BoneHeadTail(HumanBodyBones.Hips, HumanBodyBones.Spine, 0.1f, 0.06f),
			new BoneHeadTail(HumanBodyBones.Spine, HumanBodyBones.Chest),
			new BoneHeadTail(HumanBodyBones.Chest, HumanBodyBones.Neck, 0.1f, 0.06f),
			new BoneHeadTail(HumanBodyBones.Neck, HumanBodyBones.Head, 0.03f, 0.03f),
			new BoneHeadTail(HumanBodyBones.Head, new Vector3(0f, 0.1f, 0f), 0.1f, 0.1f),
			new BoneHeadTail(HumanBodyBones.LeftShoulder, HumanBodyBones.LeftUpperArm),
			new BoneHeadTail(HumanBodyBones.LeftUpperArm, HumanBodyBones.LeftLowerArm),
			new BoneHeadTail(HumanBodyBones.LeftLowerArm, HumanBodyBones.LeftHand),
			new BoneHeadTail(HumanBodyBones.LeftHand, new Vector3(-0.1f, 0f, 0f)),
			new BoneHeadTail(HumanBodyBones.LeftUpperLeg, HumanBodyBones.LeftLowerLeg),
			new BoneHeadTail(HumanBodyBones.LeftLowerLeg, HumanBodyBones.LeftFoot),
			new BoneHeadTail(HumanBodyBones.LeftFoot, HumanBodyBones.LeftToes),
			new BoneHeadTail(HumanBodyBones.LeftToes, new Vector3(0f, 0f, 0.1f)),
			new BoneHeadTail(HumanBodyBones.RightShoulder, HumanBodyBones.RightUpperArm),
			new BoneHeadTail(HumanBodyBones.RightUpperArm, HumanBodyBones.RightLowerArm),
			new BoneHeadTail(HumanBodyBones.RightLowerArm, HumanBodyBones.RightHand),
			new BoneHeadTail(HumanBodyBones.RightHand, new Vector3(0.1f, 0f, 0f)),
			new BoneHeadTail(HumanBodyBones.RightUpperLeg, HumanBodyBones.RightLowerLeg),
			new BoneHeadTail(HumanBodyBones.RightLowerLeg, HumanBodyBones.RightFoot),
			new BoneHeadTail(HumanBodyBones.RightFoot, HumanBodyBones.RightToes),
			new BoneHeadTail(HumanBodyBones.RightToes, new Vector3(0f, 0f, 0.1f))
		};

		public static SkinnedMeshRenderer CreateRenderer(Animator animator)
		{
			List<Transform> list = animator.transform.Traverse().ToList();
			MeshBuilder meshBuilder = new MeshBuilder();
			BoneHeadTail[] bones = Bones;
			for (int i = 0; i < bones.Length; i++)
			{
				BoneHeadTail boneHeadTail = bones[i];
				Transform boneTransform = animator.GetBoneTransform(boneHeadTail.Head);
				if (boneTransform != null)
				{
					Transform transform = null;
					if (boneHeadTail.Tail != HumanBodyBones.LastBone)
					{
						transform = animator.GetBoneTransform(boneHeadTail.Tail);
					}
					if (transform != null)
					{
						meshBuilder.AddBone(boneTransform.position, transform.position, list.IndexOf(boneTransform), boneHeadTail.XWidth, boneHeadTail.ZWidth);
					}
					else
					{
						meshBuilder.AddBone(boneTransform.position, boneTransform.position + boneHeadTail.TailOffset, list.IndexOf(boneTransform), boneHeadTail.XWidth, boneHeadTail.ZWidth);
					}
				}
				else
				{
					Debug.LogWarningFormat("{0} not found", boneHeadTail.Head);
				}
			}
			Mesh mesh = meshBuilder.CreateMesh();
			mesh.name = "box-man";
			mesh.bindposes = list.Select((Transform x) => x.worldToLocalMatrix * animator.transform.localToWorldMatrix).ToArray();
			SkinnedMeshRenderer skinnedMeshRenderer = animator.gameObject.AddComponent<SkinnedMeshRenderer>();
			skinnedMeshRenderer.bones = list.ToArray();
			skinnedMeshRenderer.rootBone = animator.GetBoneTransform(HumanBodyBones.Hips);
			skinnedMeshRenderer.sharedMesh = mesh;
			return skinnedMeshRenderer;
		}
	}
}
