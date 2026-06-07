using System;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[Serializable]
	public struct ModelDialogPageContent
	{
		[LocaKey]
		public string TitleKey;

		[LocaKey]
		public string TextKey;

		public string ExtraTextKey;

		public Sprite Sprite;

		public string VideoName;
	}
}
