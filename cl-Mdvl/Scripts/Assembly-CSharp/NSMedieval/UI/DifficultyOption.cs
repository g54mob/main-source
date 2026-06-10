using System;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	public class DifficultyOption : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private FloatRange valueRange;

		[SerializeField]
		private bool wholeNumbers;

		[SerializeField]
		private UIElementType uiElementType;

		public FloatRange ValueRange => valueRange;

		public bool WholeNumbers => wholeNumbers;

		public UIElementType UIElementType => uiElementType;

		public LocKeys[] LocKeys => locKeys;

		public override string GetID()
		{
			return id;
		}
	}
}
