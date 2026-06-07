using System;
using UnityEngine;

namespace Motorways.Views
{
	[Serializable]
	public class UpgradeButtonHolder
	{
		public RectTransform _anchor;

		public RectTransform _visualElementIcon;

		public RectTransform _visualElementCounter;

		public UpgradeButtonCount _count;
	}
}
