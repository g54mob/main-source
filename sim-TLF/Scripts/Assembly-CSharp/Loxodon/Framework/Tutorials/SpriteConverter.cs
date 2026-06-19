using System;
using System.Collections.Generic;
using Loxodon.Framework.Binding.Converters;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class SpriteConverter : IConverter
	{
		private Dictionary<string, Sprite> sprites;

		public SpriteConverter(Dictionary<string, Sprite> sprites)
		{
			this.sprites = sprites;
		}

		public object Convert(object value)
		{
			Sprite value2 = null;
			if (value != null)
			{
				sprites.TryGetValue((string)value, out value2);
			}
			return value2;
		}

		public object ConvertBack(object value)
		{
			throw new NotImplementedException();
		}
	}
}
