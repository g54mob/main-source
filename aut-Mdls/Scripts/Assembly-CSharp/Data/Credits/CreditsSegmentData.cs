using System;
using Presentation.UI.Credits;
using UnityEngine;

namespace Data.Credits
{
	[Serializable]
	public struct CreditsSegmentData
	{
		public string TitleLocaKey;

		public Sprite Image;

		public string TextLocaKey;

		public CreditsBaseSegment SegmentPrefab;
	}
}
