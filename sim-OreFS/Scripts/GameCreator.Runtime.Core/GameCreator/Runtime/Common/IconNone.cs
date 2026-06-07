using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public class IconNone : TIcon
	{
		protected override byte[] Bytes => new byte[16384];

		public IconNone(ColorTheme.Type color, IIcon overlay = null)
			: this(ColorTheme.Get(color), overlay)
		{
		}

		public IconNone(Color color, IIcon overlay = null)
			: base(color, overlay)
		{
		}
	}
}
