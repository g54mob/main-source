using System.Reflection;
using UnityEngine;
using VRTK;

namespace DV.VR
{
	public class VRTK_UIPointerRaycast : VRTK_CustomRaycast
	{
		private VRTK_UIPointer uiPointer;

		private BoxCollider col;

		private FieldInfo field;

		private void Awake()
		{
			uiPointer = GetComponent<VRTK_UIPointer>();
			GameObject gameObject = new GameObject("Dummy collider for pointer");
			gameObject.transform.SetParent(base.transform);
			gameObject.SetActive(value: false);
			col = gameObject.AddComponent<BoxCollider>();
			field = typeof(RaycastHit).GetField("m_Collider", BindingFlags.Instance | BindingFlags.NonPublic);
		}

		public override bool CustomLinecast(Vector3 startPosition, Vector3 endPosition, out RaycastHit hitData)
		{
			Vector3 vector = endPosition - startPosition;
			return CustomRaycast(new Ray(startPosition, vector.normalized), out hitData, vector.magnitude);
		}

		public override bool CustomRaycast(Ray ray, out RaycastHit hitData, float length = float.PositiveInfinity)
		{
			hitData = default(RaycastHit);
			if (!uiPointer.pointerEventData.pointerEnter)
			{
				return false;
			}
			Transform transform = uiPointer.pointerEventData.pointerEnter.transform;
			new Plane(transform.forward, transform.position).Raycast(ray, out var enter);
			object obj = hitData;
			field.SetValue(obj, col.GetInstanceID());
			hitData = (RaycastHit)obj;
			hitData.distance = enter;
			hitData.point = ray.origin + ray.direction.normalized * enter;
			hitData.normal = transform.forward;
			return true;
		}
	}
}
