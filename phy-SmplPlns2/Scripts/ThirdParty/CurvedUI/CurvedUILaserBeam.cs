using UnityEngine;
using UnityEngine.UI;

namespace CurvedUI
{
	public class CurvedUILaserBeam : MonoBehaviour
	{
		[SerializeField]
		private Transform LaserBeamTransform;

		[SerializeField]
		private Transform LaserBeamDot;

		[SerializeField]
		private bool hideWhenNotAimingAtCanvas;

		protected void Update()
		{
			Ray ray = new Ray(base.transform.position, base.transform.forward);
			if (!LaserBeamTransform || !LaserBeamDot)
			{
				return;
			}
			float num = 10000f;
			if (Physics.Raycast(ray, out var hitInfo, num, CurvedUIInputModule.Instance.RaycastLayerMask))
			{
				num = Vector3.Distance(hitInfo.point, base.transform.position);
				CurvedUISettings componentInParent = hitInfo.collider.GetComponentInParent<CurvedUISettings>();
				if (componentInParent != null)
				{
					num = ((componentInParent.GetObjectsUnderPointer().FindAll((GameObject x) => x != null && x.GetComponent<Graphic>() != null && x.GetComponent<Graphic>().depth != -1).Count == 0) ? 10000f : Vector3.Distance(hitInfo.point, base.transform.position));
				}
				else if (hideWhenNotAimingAtCanvas)
				{
					num = 0f;
				}
			}
			else if (hideWhenNotAimingAtCanvas)
			{
				num = 0f;
			}
			LaserBeamTransform.localScale = LaserBeamTransform.localScale.ModifyZ(num);
		}
	}
}
