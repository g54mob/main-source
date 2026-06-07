using Data.Variables;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Settings/Run in background", fileName = "RunInBackground", order = 0)]
public class RunInBackgroundSO : BoolVariableSO
{
	public override void SetValue(bool value)
	{
		base.SetValue(value);
		Application.runInBackground = value;
	}
}
