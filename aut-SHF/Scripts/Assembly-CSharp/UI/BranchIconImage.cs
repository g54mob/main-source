using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class BranchIconImage : ChoiceMenuButtonBase
	{
		[Serializable]
		private struct IconPosition
		{
			[Label("通常位置")]
			public List<Vector2> normalPos;

			[Label("アニメーション位置")]
			public List<Vector2> animationPos;
		}

		public List<Image> icons;

		public Image checkImage;

		public Material desableEventMaterial;

		[SerializeField]
		private List<IconPosition> iconPosition;

		[SerializeField]
		private Material material;

		[SerializeField]
		private Image ordealSpecificImage;

		public float defaultOutlineSpread;

		private static readonly int OutLineSpread;

		private static readonly int OutLineColor;

		private int iconNum;

		private bool _isReached;

		private List<eRouteEvent> _eventType;

		private int? _ordealNum;

		private void Awake()
		{
		}

		public void AttachIcon(Sprite sprite, bool isOrdeal = false)
		{
		}

		private void SortOrgin()
		{
		}

		public void ChangeIcon(Sprite sprite, int index)
		{
		}

		private void UpdateIconLayout()
		{
		}

		public void ActiveCheckMark()
		{
		}

		public void SwitchIconOutline(bool on)
		{
		}

		public void SetDesabledMaterial()
		{
		}
	}
}
