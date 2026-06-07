using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class InfoProduct : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _productCount;

		[SerializeField]
		private TMP_Text _productTime;

		[SerializeField]
		private TMP_Text _expPoint;

		[SerializeField]
		private Image _needMachinePrefab;

		[SerializeField]
		private RectTransform _needMachineContent;

		[SerializeField]
		private TMP_Text _cautionText;

		[SerializeField]
		private Color _cautionTextColorOutGame;

		[SerializeField]
		private Color _cautionTextColorInGame;

		private const int displayMaxSize = 5;

		public void DisplayProduct(eLuggage luggage)
		{
		}

		private void CreateNeedMachineIcon(eLuggage luggage)
		{
		}

		private void CreateNeedMachineIcon(PlayUnlockData targetLuggage)
		{
		}
	}
}
