using LeTai.Asset.TranslucentImage;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.XmlLayoutExtensions
{
	public class TranslucencyAttribute : CustomXmlAttribute
	{
		public override string DefaultValue => "0";

		public override bool UsesApplyMethod => true;

		public override string ValueDataType => "xmlLayout:float";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			if (!Application.isPlaying)
			{
				return;
			}
			float num = value?.ToFloat() ?? 0f;
			float spriteBlending = 1f - num;
			TranslucentImage translucentImage = xmlElement.GetComponent<TranslucentImage>();
			if (num > 0f)
			{
				if (translucentImage == null)
				{
					Image component = xmlElement.GetComponent<Image>();
					if (component != null)
					{
						Object.DestroyImmediate(component);
						translucentImage = xmlElement.gameObject.AddComponent<TranslucentImage>();
						translucentImage.sprite = component.sprite;
						translucentImage.overrideSprite = component.overrideSprite;
						translucentImage.color = component.color;
						translucentImage.raycastTarget = component.raycastTarget;
						translucentImage.type = component.type;
						translucentImage.preserveAspect = component.preserveAspect;
						translucentImage.fillCenter = component.fillCenter;
						translucentImage.fillMethod = component.fillMethod;
						translucentImage.fillAmount = component.fillAmount;
						translucentImage.fillClockwise = component.fillClockwise;
						translucentImage.fillOrigin = component.fillOrigin;
						translucentImage.alphaHitTestMinimumThreshold = component.alphaHitTestMinimumThreshold;
						translucentImage.useSpriteMesh = component.useSpriteMesh;
						translucentImage.pixelsPerUnitMultiplier = component.pixelsPerUnitMultiplier;
						TranslucentImageHelperScript.SetupTranslucentImage(translucentImage);
						Button component2 = xmlElement.GetComponent<Button>();
						if (component2 != null)
						{
							component2.targetGraphic = translucentImage;
						}
					}
				}
				translucentImage.spriteBlending = spriteBlending;
			}
			else if (translucentImage != null)
			{
				translucentImage.spriteBlending = spriteBlending;
			}
		}
	}
}
