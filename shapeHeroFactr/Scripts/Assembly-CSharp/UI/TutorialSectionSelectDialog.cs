using System.Collections.Generic;
using InputControl;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class TutorialSectionSelectDialog : BaseDialog
	{
		[Header("ContentsParent")]
		[SerializeField]
		private Transform contentsParent;

		[Header("ItemPrefab")]
		[SerializeField]
		private SectionSelectItem sectionSelectItemPrefab;

		[Header("AnimationObjects")]
		[SerializeField]
		private SkeletonGraphic minion;

		[SerializeField]
		private Image paper;

		[SerializeField]
		private float animationStartPosY;

		[Header("PadSetting")]
		[SerializeField]
		private CursorUIGroup _listItem;

		private bool isInitialized;

		private Dictionary<GameObject, float> recordPositionY;

		private Dictionary<eTutorialSectionId, SectionSelectItem> items;

		private readonly List<CursorUIBase> _createItems;

		public override void Init()
		{
		}

		private void CreateItems()
		{
		}

		private void SetInput()
		{
		}

		public void UpdateItems()
		{
		}

		public override void Open()
		{
		}

		private void OpenInit()
		{
		}

		private void PlayOpenAnimation(float duration)
		{
		}

		private void SetAlpha(Graphic target, float alpha)
		{
		}

		private void SetPosition(RectTransform target, float posY)
		{
		}

		public override void Back()
		{
		}

		public override void SetInFront()
		{
		}
	}
}
