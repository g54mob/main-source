using System;
using System.Collections.Generic;
using System.Linq;
using UniGLTF;
using UnityEngine;

namespace VRM
{
	public static class VRMSpringUtility
	{
		public static void ExportSecondary(Transform root, List<Transform> nodes, Action<glTF_VRM_SecondaryAnimationColliderGroup> addSecondaryColliderGroup, Action<glTF_VRM_SecondaryAnimationGroup> addSecondaryGroup)
		{
			List<VRMSpringBoneColliderGroup> colliders = new List<VRMSpringBoneColliderGroup>();
			foreach (VRMSpringBoneColliderGroup item in from x in root.Traverse()
				select x.GetComponent<VRMSpringBoneColliderGroup>() into x
				where x != null
				select x)
			{
				colliders.Add(item);
				glTF_VRM_SecondaryAnimationColliderGroup glTF_VRM_SecondaryAnimationColliderGroup2 = new glTF_VRM_SecondaryAnimationColliderGroup
				{
					node = nodes.IndexOf(item.transform)
				};
				glTF_VRM_SecondaryAnimationColliderGroup2.colliders = item.Colliders.Select((VRMSpringBoneColliderGroup.SphereCollider x) => new glTF_VRM_SecondaryAnimationCollider
				{
					offset = x.Offset,
					radius = x.Radius
				}).ToList();
				addSecondaryColliderGroup(glTF_VRM_SecondaryAnimationColliderGroup2);
			}
			foreach (VRMSpringBone item2 in from x in root.Traverse().SelectMany((Transform x) => x.GetComponents<VRMSpringBone>())
				where x != null
				select x)
			{
				addSecondaryGroup(new glTF_VRM_SecondaryAnimationGroup
				{
					comment = item2.m_comment,
					center = nodes.IndexOf(item2.m_center),
					dragForce = item2.m_dragForce,
					gravityDir = item2.m_gravityDir,
					gravityPower = item2.m_gravityPower,
					stiffiness = item2.m_stiffnessForce,
					hitRadius = item2.m_hitRadius,
					colliderGroups = (from x in item2.ColliderGroups
						select colliders.IndexOf(x) into x
						where x != -1
						select x).ToArray(),
					bones = item2.RootBones.Select((Transform x) => nodes.IndexOf(x)).ToArray()
				});
			}
		}

		public static void LoadSecondary(Transform root, List<Transform> nodes, glTF_VRM_SecondaryAnimation secondaryAnimation)
		{
			Transform transform = root.Find("secondary");
			if (transform == null)
			{
				transform = new GameObject("secondary").transform;
				transform.SetParent(root, worldPositionStays: false);
			}
			VRMSpringBone[] componentsInChildren = root.GetComponentsInChildren<VRMSpringBone>();
			VRMSpringBoneColliderGroup[] componentsInChildren2 = root.GetComponentsInChildren<VRMSpringBoneColliderGroup>();
			Component[] array = new Component[((componentsInChildren != null) ? componentsInChildren.Length : 0) + ((componentsInChildren2 != null) ? componentsInChildren2.Length : 0)];
			int num = 0;
			if (componentsInChildren != null)
			{
				VRMSpringBone[] array2 = componentsInChildren;
				foreach (VRMSpringBone vRMSpringBone in array2)
				{
					array[num++] = vRMSpringBone;
				}
			}
			if (componentsInChildren2 != null)
			{
				VRMSpringBoneColliderGroup[] array3 = componentsInChildren2;
				foreach (VRMSpringBoneColliderGroup vRMSpringBoneColliderGroup in array3)
				{
					array[num++] = vRMSpringBoneColliderGroup;
				}
			}
			Component[] array4 = array;
			foreach (Component obj in array4)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(obj);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(obj);
				}
			}
			List<VRMSpringBoneColliderGroup> list = new List<VRMSpringBoneColliderGroup>();
			foreach (glTF_VRM_SecondaryAnimationColliderGroup colliderGroup in secondaryAnimation.colliderGroups)
			{
				VRMSpringBoneColliderGroup vRMSpringBoneColliderGroup2 = nodes[colliderGroup.node].gameObject.AddComponent<VRMSpringBoneColliderGroup>();
				vRMSpringBoneColliderGroup2.Colliders = colliderGroup.colliders.Select((glTF_VRM_SecondaryAnimationCollider x) => new VRMSpringBoneColliderGroup.SphereCollider
				{
					Offset = x.offset,
					Radius = x.radius
				}).ToArray();
				list.Add(vRMSpringBoneColliderGroup2);
			}
			if (secondaryAnimation.boneGroups.Count > 0)
			{
				foreach (glTF_VRM_SecondaryAnimationGroup boneGroup in secondaryAnimation.boneGroups)
				{
					VRMSpringBone vRMSpringBone2 = transform.gameObject.AddComponent<VRMSpringBone>();
					if (boneGroup.center != -1)
					{
						vRMSpringBone2.m_center = nodes[boneGroup.center];
					}
					vRMSpringBone2.m_comment = boneGroup.comment;
					vRMSpringBone2.m_dragForce = boneGroup.dragForce;
					vRMSpringBone2.m_gravityDir = boneGroup.gravityDir;
					vRMSpringBone2.m_gravityPower = boneGroup.gravityPower;
					vRMSpringBone2.m_hitRadius = boneGroup.hitRadius;
					vRMSpringBone2.m_stiffnessForce = boneGroup.stiffiness;
					if (boneGroup.colliderGroups != null && boneGroup.colliderGroups.Any())
					{
						vRMSpringBone2.ColliderGroups = new VRMSpringBoneColliderGroup[boneGroup.colliderGroups.Length];
						for (int num2 = 0; num2 < boneGroup.colliderGroups.Length; num2++)
						{
							int index = boneGroup.colliderGroups[num2];
							vRMSpringBone2.ColliderGroups[num2] = list[index];
						}
					}
					List<Transform> list2 = new List<Transform>();
					int[] bones = boneGroup.bones;
					foreach (int index2 in bones)
					{
						list2.Add(nodes[index2]);
					}
					vRMSpringBone2.RootBones = list2;
				}
				return;
			}
			transform.gameObject.AddComponent<VRMSpringBone>();
		}
	}
}
