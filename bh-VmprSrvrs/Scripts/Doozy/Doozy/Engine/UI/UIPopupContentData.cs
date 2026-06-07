using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.UI
{
	[Serializable]
	public class UIPopupContentData
	{
		public List<UnityAction> ButtonCallbacks;

		public List<string> ButtonLabels;

		public List<string> ButtonNames;

		public List<string> Labels;

		public List<Sprite> Sprites;
	}
}
