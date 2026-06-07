using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ModelShark
{
	public class Tooltip
	{
		public RectTransform RectTransform { get; set; }

		public TooltipStyle TooltipStyle { get; set; }

		public GameObject GameObject { get; set; }

		public List<TextField> TextFields { get; set; }

		public List<ImageField> ImageFields { get; set; }

		public List<SectionField> SectionFields { get; set; }

		public Image BackgroundImage { get; set; }

		public CanvasRenderer[] CanvasRenderers { get; set; }

		public Graphic[] Graphics { get; set; }

		public bool StaysOpen { get; set; }

		public bool NeverRotate { get; set; }

		public bool IsBlocking { get; set; }

		public static string Delimiter { get; set; }

		public TooltipTrigger TooltipTrigger { get; set; }

		public void Initialize()
		{
		}

		public void WarmUp()
		{
		}

		public void Deactivate()
		{
		}

		public void ResetParameterizedFields()
		{
		}

		public void Display(float fadeDuration)
		{
		}
	}
}
