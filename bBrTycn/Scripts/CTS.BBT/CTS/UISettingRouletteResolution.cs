using UnityEngine;

namespace CTS
{
	public class UISettingRouletteResolution : UISettingRoulette<Vector2Int>
	{
		protected override void OnAwake()
		{
			base.OnAwake();
			Resolution[] resolutions = Screen.resolutions;
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution resolution = resolutions[i];
				AddValue(new Vector2Int(resolution.width, resolution.height));
			}
		}

		protected override string ToString(Vector2Int obj)
		{
			return $"{obj.x}x{obj.y}";
		}

		protected override int IndexOf(Vector2Int obj)
		{
			return _values.IndexOf(obj);
		}
	}
}
