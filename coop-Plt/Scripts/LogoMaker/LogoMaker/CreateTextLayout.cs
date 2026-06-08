using System.Collections.Generic;
using LogoMaker.Extensions;
using LogoMaker.Helpers;
using Shapes;
using TMPro;
using UnityEngine;

namespace LogoMaker
{
	public class CreateTextLayout : MonoBehaviour
	{
		public TextMeshPro TextTemplate;

		public Rectangle RectangleBackingTemplate;

		public DynamicFont DynamicFont;

		private HashSet<Object> Objects = new HashSet<Object>();

		public void Test(string text, bool playful)
		{
			Dispose();
			bool flag = Random.value < 0.25f;
			TextLayout textLayout = LayoutCreator.CreateLayout(EnumExtensions.GetRandom<Layout>(), text);
			List<string> list = TextSplit.SplitString(text);
			TextMeshPro textMeshPro = null;
			TMP_FontAsset font = null;
			for (int i = 0; i < textLayout.LayoutAreas.Count; i++)
			{
				if (i == 0 || flag)
				{
					font = (playful ? DynamicFont.Playful : DynamicFont.Serious);
				}
				LayoutArea area = textLayout.LayoutAreas[i];
				string text2 = list[i];
				textMeshPro = FillArea(area, text2, font);
			}
			if ((Object)(object)textMeshPro != null)
			{
				BackingCreator.CreatingBacking(textLayout, delegate
				{
					Rectangle rectangle = Object.Instantiate(RectangleBackingTemplate, base.transform, worldPositionStays: true);
					rectangle.gameObject.SetActive(value: true);
					Objects.Add(rectangle.gameObject);
					return rectangle;
				});
			}
		}

		public void Dispose()
		{
			foreach (Object @object in Objects)
			{
				if (@object != null)
				{
					Object.DestroyImmediate(@object);
				}
			}
			Objects.Clear();
		}

		public TextMeshPro FillArea(LayoutArea area, string text, TMP_FontAsset font)
		{
			TextMeshPro textMeshPro = Object.Instantiate<TextMeshPro>(TextTemplate, base.transform, true);
			textMeshPro.font = font;
			((Component)(object)textMeshPro).gameObject.SetActive(value: true);
			Objects.Add(((Component)(object)textMeshPro).gameObject);
			textMeshPro.text = text;
			area.AddText(textMeshPro);
			return textMeshPro;
		}
	}
}
