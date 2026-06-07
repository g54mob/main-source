#define ENABLE_DEBUG_LOGS
using UnityEngine;
using Utils;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/Settings/Resolution", fileName = "Resolution", order = 0)]
	public class ResolutionSO : VariableSO<Vector2Int>
	{
		public override void SetValue(Vector2Int value)
		{
			Screen.SetResolution(value.x, value.y, Screen.fullScreenMode);
			base.SetValue(value);
			this.Log($"Set to {value}", "SetValue", 14);
		}

		public void SetValue(int width, int height)
		{
			SetValue(new Vector2Int(width, height));
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		public override void ResetToDefault()
		{
			SetValue(Display.main.systemWidth, Display.main.systemHeight);
		}
	}
}
