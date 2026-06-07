using UnityEngine;

namespace CurvedUI
{
	public class CUI_OrientOnCurvedSpace : MonoBehaviour
	{
		public CurvedUISettings mySettings;

		private void Awake()
		{
			mySettings = GetComponentInParent<CurvedUISettings>();
		}

		private void Update()
		{
			Vector3 pos = mySettings.transform.worldToLocalMatrix.MultiplyPoint3x4(base.transform.parent.position);
			base.transform.position = mySettings.CanvasToCurvedCanvas(pos);
			base.transform.rotation = Quaternion.LookRotation(mySettings.CanvasToCurvedCanvasNormal(base.transform.parent.localPosition), base.transform.parent.up);
		}
	}
}
