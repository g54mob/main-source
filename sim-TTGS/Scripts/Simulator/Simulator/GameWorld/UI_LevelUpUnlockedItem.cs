using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class UI_LevelUpUnlockedItem : MonoBehaviour
	{
		[Header("UI Components")]
		[SerializeField]
		protected SimulatorText m_productNameText;

		[SerializeField]
		protected Image m_productImage;

		public virtual void Init(BaseShopBoxData data)
		{
			m_productNameText.SetTerm(data.NameTerm);
			m_productImage.sprite = data.Sprite;
		}
	}
}
