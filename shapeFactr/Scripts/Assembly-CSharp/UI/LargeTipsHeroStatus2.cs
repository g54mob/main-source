using UnityEngine;

namespace UI
{
	public class LargeTipsHeroStatus2 : MonoBehaviour
	{
		public CollectionActionTypeItem actionTypeItemPrefab;

		public RectTransform actionTypeArea;

		public RectTransform spellTypeArea;

		public RectTransform attackTypeArea;

		public RectTransform attackTypeArea2;

		public RectTransform contentsArea;

		public RectTransform contentsArea2;

		[SerializeField]
		private eUnitAttackType[] ignoreAttackType;

		private void Start()
		{
		}
	}
}
