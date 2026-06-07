using UnityEngine;
using UnityEngine.UI;

public class TextFitter : MonoBehaviour
{
	private class Info
	{
		public RectTransform rt;

		public string cachedText;

		public float cachedEdge;

		public int defaultFontSize;

		public Info(Text text)
		{
			rt = text.gameObject.transform as RectTransform;
			defaultFontSize = text.fontSize;
		}

		public float GetEdge(RectTransform canvasRt, Vector3[] corners, int cornerIndex)
		{
			rt.GetWorldCorners(corners);
			return canvasRt.worldToLocalMatrix.MultiplyPoint(corners[cornerIndex]).y;
		}
	}

	public Text topText;

	public Text botText;

	public float overlapGrace;

	public int manualWidth;

	public int manualHeight;

	public bool manualFitWidth;

	public bool customWrapping;

	private RectTransform canvasRt;

	private Info topInfo;

	private Info botInfo;

	private TextGenerator utilTextGenerator;

	private Vector3[] corners = new Vector3[4];

	private TextWrapper textWrapper = new TextWrapper();

	private void OnDisable()
	{
		if (topInfo != null)
		{
			topText.fontSize = topInfo.defaultFontSize;
			topInfo.cachedText = string.Empty;
		}
		if (botInfo != null)
		{
			botText.fontSize = botInfo.defaultFontSize;
			botInfo.cachedText = string.Empty;
		}
	}

	public void LateUpdate()
	{
		if (topText != null && botText == null)
		{
			if (utilTextGenerator == null)
			{
				utilTextGenerator = new TextGenerator();
				canvasRt = GetComponentInParent<Canvas>().transform as RectTransform;
				topInfo = new Info(topText);
			}
			if (!(topInfo.cachedText != topText.text))
			{
				return;
			}
			topInfo.cachedText = topText.text;
			string text = topText.text;
			Vector2 size = topInfo.rt.rect.size;
			if (manualWidth > 0)
			{
				size.x = manualWidth;
			}
			if (manualHeight > 0)
			{
				size.y = manualHeight;
			}
			TextGenerationSettings generationSettings = topText.GetGenerationSettings(size);
			int num = ((!manualFitWidth) ? 10 : 20);
			for (int i = 0; i < num; i++)
			{
				generationSettings.fontSize = topInfo.defaultFontSize - i;
				if (manualFitWidth)
				{
					float preferredWidth = utilTextGenerator.GetPreferredWidth(text, generationSettings);
					if (preferredWidth < size.x)
					{
						break;
					}
					continue;
				}
				bool flag = RtlHelper.HasRtl(text);
				if (customWrapping && (Lang.loadedLanguage.isAsian || flag))
				{
					text = textWrapper.Wrap(topText.text, utilTextGenerator, generationSettings, flag);
				}
				float preferredHeight = utilTextGenerator.GetPreferredHeight(text, generationSettings);
				if (preferredHeight < size.y)
				{
					break;
				}
			}
			if (textWrapper != null)
			{
				topText.text = text;
			}
			topText.fontSize = generationSettings.fontSize;
			topInfo.cachedText = topText.text;
		}
		else
		{
			if (!(topText != null) || !(botText != null))
			{
				return;
			}
			if (utilTextGenerator == null)
			{
				utilTextGenerator = new TextGenerator();
				canvasRt = GetComponentInParent<Canvas>().transform as RectTransform;
				topInfo = new Info(topText);
				botInfo = new Info(botText);
			}
			float edge = topInfo.GetEdge(canvasRt, corners, 1);
			float edge2 = botInfo.GetEdge(canvasRt, corners, 0);
			if (!(topInfo.cachedText != topText.text) && !(botInfo.cachedText != botText.text) && !(Mathf.Abs(topInfo.cachedEdge - edge) > 0.01f) && !(Mathf.Abs(botInfo.cachedEdge - edge2) > 0.01f))
			{
				return;
			}
			topInfo.cachedText = topText.text;
			topInfo.cachedEdge = edge;
			botInfo.cachedText = botText.text;
			botInfo.cachedEdge = edge2;
			float num2 = edge - edge2 + overlapGrace;
			TextGenerationSettings generationSettings2 = topText.GetGenerationSettings(topInfo.rt.rect.size);
			TextGenerationSettings generationSettings3 = botText.GetGenerationSettings(botInfo.rt.rect.size);
			for (int j = 0; j < 10; j++)
			{
				generationSettings2.fontSize = topInfo.defaultFontSize - j / 2;
				generationSettings3.fontSize = botInfo.defaultFontSize - (j + 1) / 2;
				float preferredHeight2 = utilTextGenerator.GetPreferredHeight(topText.text, generationSettings2);
				float preferredHeight3 = utilTextGenerator.GetPreferredHeight(botText.text, generationSettings3);
				if (preferredHeight2 + preferredHeight3 < num2)
				{
					break;
				}
			}
			topText.fontSize = generationSettings2.fontSize;
			botText.fontSize = generationSettings3.fontSize;
		}
	}
}
