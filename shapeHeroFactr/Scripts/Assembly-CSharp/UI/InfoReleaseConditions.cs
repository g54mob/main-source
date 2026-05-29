using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class InfoReleaseConditions : MonoBehaviour
	{
		[SerializeField]
		private CollectionDetailUnit _needUnlockPrefab;

		[SerializeField]
		private RectTransform _needUnlockParent;

		[SerializeField]
		private TMP_Text _cautionText;

		[SerializeField]
		private Color _cautionTextColorOutGame;

		[SerializeField]
		private Color _cautionTextColorInGame;

		private eDialog _parentDialog;

		private UnityAction<int> _buttonAction;

		public void DisplayReleaseConditions(eLuggage luggage, eDialog parentDialog, UnityAction<int> onClickAction)
		{
		}

		private void CreateNeedUnlockIcon(MstLuggageDataEntities luggageData)
		{
		}

		public CollectionDetailUnit CreateDetailUnit(eLuggage luggage)
		{
			return null;
		}
	}
}
