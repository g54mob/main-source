using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class CollectionTipsListItem : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text titleText;

		[SerializeField]
		private NoticeBadge noticeBadge;

		private eLargeTips largeTipsId;

		private UnityAction<eLargeTips> onClickAction;

		public int enumNumber => 0;

		public void Init(eLargeTips id, UnityAction<eLargeTips> onClickAction)
		{
		}

		public void OnClickButton()
		{
		}

		public void UpdateNoticeBadge(bool unRead)
		{
		}
	}
}
