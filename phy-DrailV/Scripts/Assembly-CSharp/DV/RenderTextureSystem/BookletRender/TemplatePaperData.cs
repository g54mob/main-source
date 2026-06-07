using System.Collections.Generic;
using DV.ThingTypes;
using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public abstract class TemplatePaperData
	{
		public static readonly Color NOT_USED_COLOR = Color.white;

		public const string NOT_USED_FLAG_STR = "";

		public const List<CargoType> NO_CARGO_IN_CARS = null;

		public abstract TemplatePaperType GetTemplatePaperType();
	}
}
