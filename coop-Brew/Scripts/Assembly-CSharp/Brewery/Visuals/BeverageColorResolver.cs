using Brewery.Core;
using UnityEngine;

namespace Brewery.Visuals
{
	public static class BeverageColorResolver
	{
		private static readonly Color BeerBase;

		private static readonly Color WineBase;

		private static readonly Color SpiritsBase;

		public static (Color, Color) Resolve(BaseType baseType, BrewTag tags, bool isLegendary)
		{
			return default((Color, Color));
		}
	}
}
