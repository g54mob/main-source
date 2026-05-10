using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class InputFieldCondition : MonoCondition
	{
		private enum EValidState
		{
			InInputField = 0,
			NotInInputField = 1
		}

		[SerializeField]
		private EValidState _trueWhen;

		public override bool IsConditionValid()
		{
			if (_trueWhen == EValidState.NotInInputField)
			{
				return !UIUtility.InInputField();
			}
			return UIUtility.InInputField();
		}
	}
}
