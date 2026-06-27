using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.Elements.Condition
{
	public abstract class ElementConditionBase : RestoryEntityInfoBase
	{
		[SerializeField]
		private string nameLocalizationKey;

		public string NameLocalizationKey => nameLocalizationKey;
	}
}
