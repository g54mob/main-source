using System;
using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/BoolVariableRef", fileName = "BoolVariableRef", order = 0)]
	public class BoolVariableRefSO : BoolVariableSO
	{
		public event Action<bool, BoolVariableRefSO> ValueChangedWithRef = delegate
		{
		};

		public override void SetValue(bool value)
		{
			base.SetValue(value);
			this.ValueChangedWithRef?.Invoke(value, this);
		}
	}
}
