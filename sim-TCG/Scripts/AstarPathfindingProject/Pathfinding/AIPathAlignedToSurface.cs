using System.Collections.Generic;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pathfinding
{
	[HelpURL("https://arongranberg.com/astar/documentation/stable/aipathalignedtosurface.html")]
	public class AIPathAlignedToSurface : AIPath
	{
		private static readonly Dictionary<Mesh, int> scratchDictionary = new Dictionary<Mesh, int>();

		protected override void OnEnable()
		{
			base.OnEnable();
			movementPlane = new SimpleMovementPlane(rotation);
		}

		protected override void ApplyGravity(float deltaTime)
		{
			if (base.usingGravity)
			{
				verticalVelocity += deltaTime * (float.IsNaN(gravity.x) ? Physics.gravity.y : gravity.y);
			}
			else
			{
				verticalVelocity = 0f;
			}
		}

		public unsafe static void UpdateMovementPlanes(AIPathAlignedToSurface[] components, int count)
		{
			List<Mesh> list = ListPool<Mesh>.Claim();
			List<List<AIPathAlignedToSurface>> list2 = new List<List<AIPathAlignedToSurface>>();
			Dictionary<Mesh, int> dictionary = scratchDictionary;
			for (int i = 0; i < count; i++)
			{
				if (components[i].lastRaycastHit.collider is MeshCollider meshCollider && components[i].lastRaycastHit.triangleIndex != -1)
				{
					Mesh sharedMesh = meshCollider.sharedMesh;
					if (dictionary.TryGetValue(sharedMesh, out var value))
					{
						list2[value].Add(components[i]);
					}
					else if (sharedMesh != null && sharedMesh.isReadable)
					{
						dictionary[sharedMesh] = list.Count;
						list.Add(sharedMesh);
						list2.Add(ListPool<AIPathAlignedToSurface>.Claim());
						list2[list.Count - 1].Add(components[i]);
					}
					else
					{
						components[i].SetInterpolatedNormal(components[i].lastRaycastHit.normal);
					}
				}
				else
				{
					components[i].SetInterpolatedNormal(components[i].lastRaycastHit.normal);
				}
			}
			Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(list);
			for (int j = 0; j < list.Count; j++)
			{
				Mesh key = list[j];
				int index = dictionary[key];
				Mesh.MeshData meshData = meshDataArray[index];
				List<AIPathAlignedToSurface> list3 = list2[index];
				int vertexAttributeStream = meshData.GetVertexAttributeStream(VertexAttribute.Normal);
				if (vertexAttributeStream == -1)
				{
					for (int k = 0; k < list3.Count; k++)
					{
						list3[k].SetInterpolatedNormal(list3[k].lastRaycastHit.normal);
					}
					continue;
				}
				NativeArray<byte> vertexData = meshData.GetVertexData<byte>(vertexAttributeStream);
				int vertexBufferStride = meshData.GetVertexBufferStride(vertexAttributeStream);
				int vertexAttributeOffset = meshData.GetVertexAttributeOffset(VertexAttribute.Normal);
				byte* ptr = (byte*)vertexData.GetUnsafeReadOnlyPtr() + vertexAttributeOffset;
				for (int l = 0; l < list3.Count; l++)
				{
					AIPathAlignedToSurface aIPathAlignedToSurface = list3[l];
					RaycastHit raycastHit = aIPathAlignedToSurface.lastRaycastHit;
					int num;
					int num2;
					int num3;
					if (meshData.indexFormat == IndexFormat.UInt16)
					{
						NativeArray<ushort> indexData = meshData.GetIndexData<ushort>();
						num = indexData[raycastHit.triangleIndex * 3];
						num2 = indexData[raycastHit.triangleIndex * 3 + 1];
						num3 = indexData[raycastHit.triangleIndex * 3 + 2];
					}
					else
					{
						NativeArray<int> indexData2 = meshData.GetIndexData<int>();
						num = indexData2[raycastHit.triangleIndex * 3];
						num2 = indexData2[raycastHit.triangleIndex * 3 + 1];
						num3 = indexData2[raycastHit.triangleIndex * 3 + 2];
					}
					Vector3 vector = *(Vector3*)(ptr + num * vertexBufferStride);
					Vector3 vector2 = *(Vector3*)(ptr + num2 * vertexBufferStride);
					Vector3 vector3 = *(Vector3*)(ptr + num3 * vertexBufferStride);
					Vector3 barycentricCoordinate = raycastHit.barycentricCoordinate;
					Vector3 normalized = (vector * barycentricCoordinate.x + vector2 * barycentricCoordinate.y + vector3 * barycentricCoordinate.z).normalized;
					normalized = raycastHit.collider.transform.TransformDirection(normalized);
					aIPathAlignedToSurface.SetInterpolatedNormal(normalized);
				}
			}
			meshDataArray.Dispose();
			for (int m = 0; m < list2.Count; m++)
			{
				ListPool<AIPathAlignedToSurface>.Release(list2[m]);
			}
			ListPool<Mesh>.Release(ref list);
			scratchDictionary.Clear();
		}

		private void SetInterpolatedNormal(Vector3 normal)
		{
			if (normal != Vector3.zero)
			{
				Vector3 forward = Vector3.Cross(movementPlane.rotation * Vector3.right, normal);
				movementPlane = new SimpleMovementPlane(Quaternion.LookRotation(forward, normal));
			}
			if (rvoController != null)
			{
				rvoController.movementPlane = movementPlane;
			}
		}

		protected override void UpdateMovementPlane()
		{
		}
	}
}
