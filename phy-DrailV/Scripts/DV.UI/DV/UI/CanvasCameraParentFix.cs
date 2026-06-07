using UnityEngine;

namespace DV.UI
{
	public class CanvasCameraParentFix : MonoBehaviour
	{
		private void Awake()
		{
			base.transform.SetParent(GetComponentInParent<Canvas>().transform.parent);
		}
	}
}
