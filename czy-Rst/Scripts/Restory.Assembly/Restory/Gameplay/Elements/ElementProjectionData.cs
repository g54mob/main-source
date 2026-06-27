using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class ElementProjectionData
	{
		public Vector3 ElementAttachmentPosition { get; }

		public Vector3 ColliderCenter { get; private set; }

		public Vector3 ColliderSize { get; private set; }

		public Mesh SharedMesh { get; private set; }

		public Vector3 MeshOffset { get; private set; }

		public ElementProjectionData(Transform elementTransform, Vector3 elementAttachmentPosition, BoxCollider collider, MeshFilter meshFilter = null)
		{
			ElementAttachmentPosition = elementAttachmentPosition;
			SetColliderData(collider);
			if ((bool)meshFilter)
			{
				SetMeshData(meshFilter);
			}
			else
			{
				CaptureMeshData(elementTransform);
			}
		}

		private void SetColliderData(BoxCollider collider)
		{
			ColliderCenter = collider.center;
			ColliderSize = collider.size;
		}

		private void SetMeshData(MeshFilter meshFilter)
		{
			SharedMesh = meshFilter.sharedMesh;
			MeshOffset = meshFilter.transform.localPosition;
		}

		private void CaptureMeshData(Transform elementTransform)
		{
			if (elementTransform.TryGetComponent<MeshFilter>(out var component))
			{
				SetMeshData(component);
				return;
			}
			component = elementTransform.GetComponentInChildren<MeshFilter>();
			if ((bool)component)
			{
				SetMeshData(component);
			}
			else
			{
				Debug.LogError($"Failed to find {typeof(MeshFilter)} component in {elementTransform.name} hierarchy.");
			}
		}
	}
}
