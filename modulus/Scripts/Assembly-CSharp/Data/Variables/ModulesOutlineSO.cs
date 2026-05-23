using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/Settings/ModulesOutline", fileName = "ModulesOutlineSO", order = 0)]
	public class ModulesOutlineSO : BoolVariableSO
	{
		private static readonly int ShowModulesOutline = Shader.PropertyToID("_ShowModulesOutline");

		public override void SetValue(bool value)
		{
			base.SetValue(value);
			Shader.SetGlobalFloat(ShowModulesOutline, value ? 1f : 0f);
		}
	}
}
