using System;
using UnityEngine;

namespace Deform
{
	[Serializable]
	public class MeshData : IData, IDisposable
	{
		[SerializeField]
		[HideInInspector]
		public Mesh OriginalMesh;

		[NonSerialized]
		public Mesh DynamicMesh;

		public MeshTarget Target;

		public NativeMeshData OriginalNative;

		public NativeMeshData DynamicNative;

		[SerializeField]
		[HideInInspector]
		private bool initialized;

		public int Length { get; private set; }

		public bool Initialize(GameObject targetObject)
		{
			if (Target == null)
			{
				Target = new MeshTarget();
			}
			if (!Target.Initialize(targetObject))
			{
				return false;
			}
			if (!initialized)
			{
				OriginalMesh = Target.GetMesh();
				if (OriginalMesh == null)
				{
					return false;
				}
				if (!OriginalMesh.isReadable)
				{
					Debug.LogError("The mesh '" + OriginalMesh.name + "' must have read/write permissions enabled.", OriginalMesh);
					return false;
				}
				DynamicMesh = UnityEngine.Object.Instantiate(Target.GetMesh());
			}
			else
			{
				if (!(OriginalMesh != null))
				{
					if (DynamicMesh != null)
					{
						Debug.Log("Original mesh is missing. Recreating one from dynamic mesh (\"" + DynamicMesh.name + "\"). This is not ideal, but prevents stuff from breaking when an original mesh is deleted. The best solution is to find and reassign the original mesh.", targetObject);
						OriginalMesh = UnityEngine.Object.Instantiate(DynamicMesh);
						return false;
					}
					return false;
				}
				DynamicMesh = UnityEngine.Object.Instantiate(OriginalMesh);
			}
			Target.SetMesh(DynamicMesh);
			DynamicMesh.MarkDynamic();
			Length = DynamicMesh.vertexCount;
			OriginalNative = new NativeMeshData(DynamicMesh);
			DynamicNative = new NativeMeshData(DynamicMesh);
			initialized = true;
			return true;
		}

		public void ChangeMesh(GameObject targetObject)
		{
			Dispose();
			initialized = false;
			Initialize(targetObject);
		}

		public void ChangeMesh(Mesh mesh)
		{
			Dispose();
			Target.SetMesh(mesh);
			initialized = false;
			Initialize(Target.GetGameObject());
		}

		public void ApplyData(DataFlags dataFlags)
		{
			if (!(DynamicMesh == null))
			{
				DataUtils.CopyNativeDataToMesh(DynamicNative, DynamicMesh, dataFlags);
			}
		}

		public void ApplyOriginalData()
		{
			DataUtils.CopyNativeDataToMesh(OriginalNative, DynamicMesh, DataFlags.All);
		}

		public void ResetData(DataFlags dataFlags)
		{
			DataUtils.CopyNativeDataToNativeData(OriginalNative, DynamicNative, dataFlags);
		}

		public bool EnsureData()
		{
			if (!Target.HasMesh())
			{
				if (OriginalMesh != null)
				{
					Debug.Log("No mesh being rendered. Sending original mesh to target.");
					ChangeMesh(OriginalMesh);
					return true;
				}
				return false;
			}
			if (!TargetUsesDynamicMesh())
			{
				ChangeMesh(Target.GetMesh());
			}
			return true;
		}

		public bool TargetUsesDynamicMesh()
		{
			return Target.GetMesh() == DynamicMesh;
		}

		public void Dispose()
		{
			Dispose(assignOriginalMesh: true);
		}

		public void Dispose(bool assignOriginalMesh)
		{
			if (assignOriginalMesh)
			{
				UnityEngine.Object.DestroyImmediate(DynamicMesh);
				Target.SetMesh(OriginalMesh);
			}
			if (DynamicNative != null)
			{
				DynamicNative.Dispose();
			}
			if (OriginalNative != null)
			{
				OriginalNative.Dispose();
			}
		}
	}
}
