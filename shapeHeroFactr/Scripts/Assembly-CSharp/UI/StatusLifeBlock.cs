using UnityEngine;

namespace UI
{
	public class StatusLifeBlock : MonoBehaviour
	{
		[SerializeField]
		private GameObject _validImage;

		[SerializeField]
		private GameObject _invalidImage;

		[SerializeField]
		private GameObject _lifePointImage;

		public void UpdateLifeUI(bool valid, bool enablePoint = false)
		{
		}
	}
}
