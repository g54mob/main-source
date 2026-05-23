using NaughtyAttributes;
using UnityEngine;

namespace Presentation.Locators.BaseClasses
{
	public class Assigner : MonoBehaviour
	{
		[ValidateInput("ValueIsOfCorrectType", "Value is not of correct type")]
		[SerializeField]
		private MonoBehaviour _value;

		[SerializeField]
		private BaseLocator _locator;

		private void Awake()
		{
			_locator.Assign(_value);
		}

		private bool ValueIsOfCorrectType(MonoBehaviour value)
		{
			if (value == null || _locator == null)
			{
				return true;
			}
			return _locator.ValueIsOfCorrectType(value);
		}
	}
}
