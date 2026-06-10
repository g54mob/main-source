using System;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class GalleryImageButtonListItem : ListItem
	{
		[SerializeField]
		private Button button;

		private Color _normalColorDefault;

		protected override void Awake()
		{
		}

		public override void Setup(Action clicked)
		{
		}

		public override void Select()
		{
		}

		public override void DeSelect()
		{
		}
	}
}
