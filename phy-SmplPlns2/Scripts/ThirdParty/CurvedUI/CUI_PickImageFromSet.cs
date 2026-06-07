using UnityEngine;
using UnityEngine.UI;

namespace CurvedUI
{
	public class CUI_PickImageFromSet : MonoBehaviour
	{
		private static CUI_PickImageFromSet picked;

		public void PickThis()
		{
			if (picked != null)
			{
				picked.GetComponent<Button>().targetGraphic.color = Color.white;
			}
			Debug.Log("Clicked this!", base.gameObject);
			picked = this;
			picked.GetComponent<Button>().targetGraphic.color = Color.red;
		}
	}
}
