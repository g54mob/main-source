using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniGLTF
{
	public static class NodeImporter
	{
		public class TransformWithSkin
		{
			public Transform Transform;

			public int? SkinIndex;

			public GameObject GameObject => Transform.gameObject;
		}

		public static GameObject ImportNode(glTFNode node, int nodeIndex)
		{
			string text = node.name;
			if (!string.IsNullOrEmpty(text) && text.Contains("/"))
			{
				Debug.LogWarningFormat("node {0} contains /. replace _", node.name);
				text = text.Replace("/", "_");
			}
			if (string.IsNullOrEmpty(text))
			{
				text = $"nodeIndex_{nodeIndex}";
			}
			GameObject gameObject = new GameObject(text);
			if (node.translation != null && node.translation.Length != 0)
			{
				gameObject.transform.localPosition = new Vector3(node.translation[0], node.translation[1], node.translation[2]);
			}
			if (node.rotation != null && node.rotation.Length != 0)
			{
				gameObject.transform.localRotation = new Quaternion(node.rotation[0], node.rotation[1], node.rotation[2], node.rotation[3]);
			}
			if (node.scale != null && node.scale.Length != 0)
			{
				gameObject.transform.localScale = new Vector3(node.scale[0], node.scale[1], node.scale[2]);
			}
			if (node.matrix != null && node.matrix.Length != 0)
			{
				Matrix4x4 matrix = UnityExtensions.MatrixFromArray(node.matrix);
				gameObject.transform.localRotation = matrix.ExtractRotation();
				gameObject.transform.localPosition = matrix.ExtractPosition();
				gameObject.transform.localScale = matrix.ExtractScale();
			}
			return gameObject;
		}

		public static TransformWithSkin BuildHierarchy(ImporterContext context, int i)
		{
			GameObject gameObject = context.Nodes[i].gameObject;
			if (string.IsNullOrEmpty(gameObject.name))
			{
				gameObject.name = $"node{i:000}";
			}
			TransformWithSkin transformWithSkin = new TransformWithSkin
			{
				Transform = gameObject.transform
			};
			glTFNode glTFNode2 = context.GLTF.nodes[i];
			if (glTFNode2.children != null)
			{
				int[] children = glTFNode2.children;
				foreach (int index in children)
				{
					context.Nodes[index].transform.SetParent(context.Nodes[i].transform, worldPositionStays: false);
				}
			}
			if (glTFNode2.mesh != -1)
			{
				MeshWithMaterials meshWithMaterials = context.Meshes[glTFNode2.mesh];
				if (meshWithMaterials.Mesh.blendShapeCount == 0 && glTFNode2.skin == -1)
				{
					gameObject.AddComponent<MeshFilter>().sharedMesh = meshWithMaterials.Mesh;
					MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
					meshRenderer.sharedMaterials = meshWithMaterials.Materials;
					meshRenderer.enabled = false;
					meshWithMaterials.Renderers.Add(meshRenderer);
				}
				else
				{
					SkinnedMeshRenderer skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();
					if (glTFNode2.skin != -1)
					{
						transformWithSkin.SkinIndex = glTFNode2.skin;
					}
					skinnedMeshRenderer.sharedMesh = meshWithMaterials.Mesh;
					skinnedMeshRenderer.sharedMaterials = meshWithMaterials.Materials;
					skinnedMeshRenderer.enabled = false;
					meshWithMaterials.Renderers.Add(skinnedMeshRenderer);
				}
			}
			return transformWithSkin;
		}

		public static void FixCoordinate(ImporterContext context, List<TransformWithSkin> nodes)
		{
			Dictionary<Transform, PosRot> dictionary = nodes.ToDictionary((TransformWithSkin x) => x.Transform, (TransformWithSkin x) => new PosRot
			{
				Position = x.Transform.position,
				Rotation = x.Transform.rotation
			});
			int[] rootnodes = context.GLTF.rootnodes;
			foreach (int index in rootnodes)
			{
				foreach (Transform item in nodes[index].Transform.Traverse())
				{
					PosRot posRot = dictionary[item];
					item.position = posRot.Position.ReverseZ();
					item.rotation = posRot.Rotation.ReverseZ();
				}
			}
		}

		public static void SetupSkinning(ImporterContext context, List<TransformWithSkin> nodes, int i)
		{
			TransformWithSkin transformWithSkin = nodes[i];
			SkinnedMeshRenderer component = transformWithSkin.Transform.GetComponent<SkinnedMeshRenderer>();
			if (!(component != null))
			{
				return;
			}
			Mesh sharedMesh = component.sharedMesh;
			if (!transformWithSkin.SkinIndex.HasValue)
			{
				return;
			}
			if (sharedMesh == null)
			{
				throw new Exception();
			}
			if (component == null)
			{
				throw new Exception();
			}
			if (transformWithSkin.SkinIndex.Value >= context.GLTF.skins.Count)
			{
				return;
			}
			component.sharedMesh = null;
			glTFSkin glTFSkin2 = context.GLTF.skins[transformWithSkin.SkinIndex.Value];
			Transform[] array = glTFSkin2.joints.Select((int y) => nodes[y].Transform).ToArray();
			if (array.Any())
			{
				component.bones = array;
				if (glTFSkin2.inverseBindMatrices != -1)
				{
					Matrix4x4[] bindposes = (from y in context.GLTF.GetArrayFromAccessor<Matrix4x4>(glTFSkin2.inverseBindMatrices)
						select y.ReverseZ()).ToArray();
					sharedMesh.bindposes = bindposes;
				}
				else
				{
					Transform meshCoords = component.transform;
					Matrix4x4[] bindposes2 = array.Select((Transform y) => y.worldToLocalMatrix * meshCoords.localToWorldMatrix).ToArray();
					sharedMesh.bindposes = bindposes2;
				}
			}
			component.sharedMesh = sharedMesh;
			if (glTFSkin2.skeleton >= 0 && glTFSkin2.skeleton < nodes.Count)
			{
				component.rootBone = nodes[glTFSkin2.skeleton].Transform;
			}
		}
	}
}
