using TMPro;

namespace Dorfromantik.UI
{
	public class UiScalingAffectedTextMeshInfo
	{
		internal float defaultTextSizeMax;

		internal float defaultTextSizeMin;

		internal float defaultTextSize;

		public UiScalingAffectedTextMeshInfo(TextMeshProUGUI textMesh)
		{
			if (textMesh.enableAutoSizing)
			{
				defaultTextSizeMin = textMesh.fontSizeMin;
				defaultTextSizeMax = textMesh.fontSizeMax;
			}
			else
			{
				defaultTextSize = textMesh.fontSize;
			}
		}
	}
}
