using UnityEngine;

namespace NSMedieval.Construction
{
	public class RoofPreviewView : MonoBehaviour
	{
		[SerializeField]
		private GameObject scalableElement;

		public void Scale(int scaleX)
		{
			if (scaleX < 1)
			{
				scaleX = 1;
			}
			Vector3 localScale = scalableElement.transform.localScale;
			localScale = new Vector3(scaleX, localScale.y, localScale.z);
			scalableElement.transform.localScale = localScale;
		}

		public void ResetScale()
		{
			scalableElement.transform.localScale = Vector3.one;
		}
	}
}
