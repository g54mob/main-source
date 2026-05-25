using UnityEngine;

namespace HumanAPI.LightLevel
{
	public class ColorFilter : LightFilter
	{
		public Color color;

		public override int priority
		{
			get
			{
				return 0;
			}
		}

		public override void ApplyFilter(LightHitInfo info)
		{
			Color color = new Color
			{
				r = Mathf.Min(info.source.color.r, this.color.r),
				g = Mathf.Min(info.source.color.g, this.color.g),
				b = Mathf.Min(info.source.color.b, this.color.b)
			};
			if (consume.debugLog)
			{
				Debug.Log("Color");
			}
			foreach (LightBase output in info.outputs)
			{
				output.color = color;
			}
		}
	}
}
