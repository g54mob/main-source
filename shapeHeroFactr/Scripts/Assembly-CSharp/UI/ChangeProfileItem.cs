using SaveData;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class ChangeProfileItem : MonoBehaviour
	{
		[SerializeField]
		private GameObject bgObj;

		[SerializeField]
		private TMP_Text newGameText;

		[SerializeField]
		private GameObject contentsObj;

		[SerializeField]
		private GameObject playIconObj;

		[SerializeField]
		private TMP_Text profileNameText;

		[SerializeField]
		private TMP_Text lastUpdateText;

		[SerializeField]
		private GameObject writer1Obj;

		[SerializeField]
		private TMP_Text writer1AscensionText;

		[SerializeField]
		private GameObject writer2Obj;

		[SerializeField]
		private TMP_Text writer2AscensionText;

		[SerializeField]
		private TMP_Text outgameShopProgressText;

		[SerializeField]
		private GameObject cursorObj;

		private int _index;

		private UnityAction<int> onClickAction;

		public bool isNewGame => false;

		public void Init(int index, UnityAction<int> onClickAction)
		{
		}

		public void SetSummary(ProfileSummaryData summary, int selectedProfineNumber, int outgameShopCountMax)
		{
		}

		private void SetWriterAscension(ProfileSummaryData summary, eWriterId writerId, GameObject obj, TMP_Text text)
		{
		}

		private void SetOutgameShopCount(ProfileSummaryData summary, int outgameShopCountMax)
		{
		}

		public void OnClickButton()
		{
		}

		public void DisableCursor()
		{
		}
	}
}
