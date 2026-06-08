using System.Collections.Generic;
using System.Text;
using KitchenData;
using Shapes;
using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class DecorationValueElement : Element
	{
		[ColorUsage(true, true)]
		public Color ActiveColour;

		[ColorUsage(true, true)]
		public Color InactiveColour;

		public float ActiveHeight;

		public float InactiveHeight;

		public Bounds Bounds;

		public TextMeshPro Icon;

		public TextMeshPro Description;

		public List<Rectangle> Pips;

		public TextMeshPro Number;

		public DecorationLocalisation Localisation;

		public bool DrawMultipleIcons;

		public override Bounds BoundingBox
		{
			get
			{
				Bounds.center = base.transform.localPosition;
				return Bounds;
			}
		}

		public void Set(DecorationType type, int level, int partial, bool draw_sign = false)
		{
			if (Localisation.Icons.TryGetValue(type, out var value))
			{
				if (DrawMultipleIcons)
				{
					int num = level * 3 + partial;
					StringBuilder stringBuilder = new StringBuilder(num);
					for (int i = 0; i < num; i++)
					{
						stringBuilder.Append(value);
					}
					Icon.text = stringBuilder.ToString();
				}
				else
				{
					Icon.text = value;
				}
				if (Description != null)
				{
					Description.text = Localisation[DecorationValues.Bonus(type, level)];
				}
			}
			else
			{
				value = "";
			}
			if (Pips != null)
			{
				for (int j = 0; j < Pips.Count; j++)
				{
					Pips[j].Color = ((j < level) ? ActiveColour : InactiveColour);
					Pips[j].Height = ((j < level) ? ActiveHeight : InactiveHeight);
					if (j == level && partial > 0)
					{
						Pips[j].Color = Color.Lerp(InactiveColour, ActiveColour, 0.5f * (float)partial / 3f);
						Pips[j].Height = Mathf.Lerp(InactiveHeight, ActiveHeight, 0.5f * (float)partial / 3f);
					}
				}
			}
			if (Number != null)
			{
				int num2 = level * 3 + partial;
				string arg = "";
				if (draw_sign && num2 > 0)
				{
					arg = "+";
				}
				Number.text = $"{arg}{num2}";
			}
		}
	}
}
