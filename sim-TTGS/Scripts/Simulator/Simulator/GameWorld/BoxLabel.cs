using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class BoxLabel : MonoBehaviour
	{
		[SerializeField]
		private Image m_image;

		[SerializeField]
		private SimulatorText m_text;

		public void SetContent(BaseShopBoxData boxData)
		{
			m_image.sprite = boxData.Sprite;
			m_text.SetTerm(boxData.NameTerm);
			base.transform.localEulerAngles += new Vector3(0f, 0f, Random.Range(-10f, 10f));
		}
	}
}
