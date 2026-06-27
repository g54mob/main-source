using EPOOutline;
using UnityEngine;

namespace Restory.Data.Outline
{
	[CreateAssetMenu(fileName = "OutlineSettingsPreset - Preset Name", menuName = "Restory/OutlineSettingsPreset", order = 15)]
	public class OutlineSettingsPreset : ScriptableObject
	{
		[Header("General settings")]
		[SerializeField]
		private ComplexMaskingMode maskingMode;

		[SerializeField]
		private RenderStyle renderStyle = RenderStyle.Single;

		[Header("\"Single\" render style settings")]
		[SerializeField]
		private Outlinable.OutlineProperties commonSettings;

		[Header("\"FrontBack\" render style settings")]
		[SerializeField]
		private Outlinable.OutlineProperties frontSettings;

		[SerializeField]
		private Outlinable.OutlineProperties backSettings;

		public void Apply(Outlinable outlinable)
		{
			outlinable.ComplexMaskingMode = maskingMode;
			outlinable.RenderStyle = renderStyle;
			switch (renderStyle)
			{
			case RenderStyle.Single:
				outlinable.OutlineParameters = commonSettings;
				break;
			case RenderStyle.FrontBack:
				outlinable.FrontParameters = frontSettings;
				outlinable.BackParameters = backSettings;
				break;
			}
		}
	}
}
