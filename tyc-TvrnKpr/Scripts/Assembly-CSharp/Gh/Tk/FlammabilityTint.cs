using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class FlammabilityTint : Tint
	{
		public static Color DefaultTintColor;

		public static Color NotFlammableColor;

		public static Color LowFlammabilityColor;

		public static Color MediumFlammabilityColor;

		public static Color HighFlammabilityColor;

		private Flammability? _currentTintLevel;

		private void Update()
		{
		}

		protected override void UpdateTint()
		{
		}

		protected override Color GetColor()
		{
			return default(Color);
		}

		protected override IEnumerable<Renderer> GetTintableRenderers()
		{
			return null;
		}
	}
}
