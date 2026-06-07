using UnityEngine;
using UnityEngine.UI;

namespace CurvedUI
{
	public class CUI_GunController : MonoBehaviour
	{
		[SerializeField]
		private CurvedUISettings ControlledCanvas;

		[SerializeField]
		private Transform LaserBeamTransform;

		private void Update()
		{
			Ray ray = new Ray(base.transform.position, base.transform.forward);
			if ((bool)ControlledCanvas)
			{
				CurvedUIInputModule.CustomControllerRay = ray;
			}
			float num = 10000f;
			if (Physics.Raycast(ray, out var hitInfo, num))
			{
				int num2 = 0;
				if (hitInfo.transform.GetComponent<CurvedUIRaycaster>() != null)
				{
					num2 = hitInfo.transform.GetComponent<CurvedUIRaycaster>().GetObjectsUnderPointer().FindAll((GameObject x) => x.GetComponent<Graphic>() != null && x.GetComponent<Graphic>().depth != -1)
						.Count;
				}
				num = ((num2 == 0) ? 10000f : Vector3.Distance(hitInfo.point, base.transform.position));
			}
			LaserBeamTransform.localScale = LaserBeamTransform.localScale.ModifyZ(num);
			if (Input.GetMouseButton(0))
			{
				LaserBeamTransform.localScale = LaserBeamTransform.localScale.ModifyX(0.75f).ModifyY(0.75f);
			}
			else
			{
				LaserBeamTransform.localScale = LaserBeamTransform.localScale.ModifyX(0.2f).ModifyY(0.2f);
			}
		}
	}
}
