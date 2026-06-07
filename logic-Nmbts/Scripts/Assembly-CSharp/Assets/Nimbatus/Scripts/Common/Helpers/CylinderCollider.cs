using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	[ExecuteInEditMode]
	public class CylinderCollider : MonoBehaviour
	{
		public float radius = 0.5f;

		public float height = 1f;

		[Range(4f, 64f)]
		public int boxCount = 5;

		[Range(0.1f, 30f)]
		public float widthScale = 1f;

		public bool capTop;

		public bool capBottom;

		[Space]
		public bool alwaysDrawGizmo;

		[Space]
		public bool isTrigger;

		public PhysicMaterial material;

		public Transform colliderParent;

		[Button]
		public void CreateCollider()
		{
			CreateColliders((colliderParent == null) ? base.transform : colliderParent);
		}

		private void Awake()
		{
			CreateColliders((colliderParent == null) ? base.transform : colliderParent);
			base.enabled = false;
		}

		private void Update()
		{
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.grey;
			OnDrawGizmosSelected();
		}

		private void OnDrawGizmosSelected()
		{
			if (!Application.isPlaying && base.enabled)
			{
				float num = CalculateRotationStep();
				float num2 = 0f;
				Vector3 size = CalculateBoxSize();
				for (int i = 0; i < boxCount; i++)
				{
					Matrix4x4 matrix = Gizmos.matrix;
					Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, num2, 0f), Vector3.one);
					Gizmos.matrix = base.transform.localToWorldMatrix * matrix4x;
					Gizmos.DrawWireCube(Vector3.zero, size);
					Gizmos.matrix = matrix;
					num2 += num;
				}
				Vector3 vector = new Vector3(0f, height * 0.5f, 0f);
				if (capBottom)
				{
					Matrix4x4 matrix2 = Gizmos.matrix;
					Matrix4x4 matrix4x2 = Matrix4x4.TRS(vector * -1f, Quaternion.identity, Vector3.one);
					Gizmos.matrix = base.transform.localToWorldMatrix * matrix4x2;
					Gizmos.DrawWireSphere(Vector3.zero, radius);
					Gizmos.matrix = matrix2;
				}
				if (capTop)
				{
					Matrix4x4 matrix3 = Gizmos.matrix;
					Matrix4x4 matrix4x3 = Matrix4x4.TRS(vector, Quaternion.identity, Vector3.one);
					Gizmos.matrix = base.transform.localToWorldMatrix * matrix4x3;
					Gizmos.DrawWireSphere(Vector3.zero, radius);
					Gizmos.matrix = matrix3;
				}
			}
		}

		public void CreateColliders(Transform parent)
		{
			Vector3 size = CalculateBoxSize();
			float num = CalculateRotationStep();
			for (int i = 0; i < boxCount; i++)
			{
				Transform obj = CreateBoxCollider(i, size, num * (float)i).transform;
				obj.SetParent(base.transform, false);
				obj.SetParent(parent, true);
			}
			if (capTop)
			{
				Transform obj2 = CreateCapCollider(true).transform;
				obj2.SetParent(base.transform, false);
				obj2.SetParent(parent, true);
			}
			if (capBottom)
			{
				Transform obj3 = CreateCapCollider(false).transform;
				obj3.SetParent(base.transform, false);
				obj3.SetParent(parent, true);
			}
		}

		private BoxCollider CreateBoxCollider(int index, Vector3 size, float rotationY)
		{
			BoxCollider boxCollider = new GameObject("Cylinder_Box_" + index).AddComponent<BoxCollider>();
			boxCollider.size = size;
			boxCollider.transform.localRotation = Quaternion.Euler(0f, rotationY, 0f);
			boxCollider.isTrigger = isTrigger;
			boxCollider.material = material;
			return boxCollider;
		}

		private SphereCollider CreateCapCollider(bool isTop)
		{
			SphereCollider sphereCollider = new GameObject("Cylinder_Cap_" + (isTop ? "Top" : "Bottom")).AddComponent<SphereCollider>();
			sphereCollider.radius = radius;
			sphereCollider.center = new Vector3(0f, height * (isTop ? 0.5f : (-0.5f)), 0f);
			sphereCollider.isTrigger = isTrigger;
			sphereCollider.material = material;
			return sphereCollider;
		}

		private Vector3 CalculateBoxSize()
		{
			float num = radius * 2f * (float)Math.PI / (float)boxCount;
			return new Vector3(radius / (float)boxCount * 2f * widthScale, height, radius * 2f);
		}

		private float CalculateRotationStep()
		{
			return 360f / (float)boxCount;
		}
	}
}
