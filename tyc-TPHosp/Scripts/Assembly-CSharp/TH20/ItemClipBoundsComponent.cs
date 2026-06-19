using UnityEngine;

namespace TH20
{
	public class ItemClipBoundsComponent : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _center = new Vector3(0f, 0.5f, 0f);

		[SerializeField]
		private Vector3 _size = new Vector3(1f, 1f, 1f);

		public Vector3 center
		{
			get
			{
				return _center;
			}
			set
			{
				_center = value;
			}
		}

		public Vector3 size
		{
			get
			{
				return _size;
			}
			set
			{
				_size = value;
			}
		}

		private void Reset()
		{
			Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
			if (componentsInChildren.Length != 0)
			{
				Bounds bounds = componentsInChildren[0].bounds;
				for (int i = 1; i < componentsInChildren.Length; i++)
				{
					bounds.Encapsulate(componentsInChildren[i].bounds);
				}
				center = bounds.center;
				size = bounds.size;
			}
		}

		private void DrawGizmo(bool selected)
		{
			Color color = new Color(0f, 0f, 0f);
			color.a = (selected ? 0.3f : 0.1f);
			Gizmos.color = color;
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawCube(_center, _size);
			color.a = (selected ? 0.5f : 0.2f);
			Gizmos.color = color;
			Gizmos.DrawWireCube(_center, _size);
		}

		private void OnDrawGizmos()
		{
			DrawGizmo(selected: false);
		}

		private void OnDrawGizmosSelected()
		{
			DrawGizmo(selected: true);
		}
	}
}
