using UnityEngine;

namespace TH20
{
	public class ItemBuildBoundsComponent : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _center = new Vector3(0f, 0.5f, 0f);

		[SerializeField]
		private Vector3 _size = new Vector3(1f, 1f, 1f);

		[Tooltip("Solid things can't overlap with anything. Non-solid things can overlap with other non-solid things. Use non-solid for e.g. the area in front of a bench to keep clear.")]
		[SerializeField]
		private bool _solid = true;

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

		public bool Solid
		{
			get
			{
				return _solid;
			}
			set
			{
				_solid = value;
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
			Color color = (_solid ? new Color(0.11f, 0.51f, 1f) : new Color(0.11f, 1f, 0.4f));
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
