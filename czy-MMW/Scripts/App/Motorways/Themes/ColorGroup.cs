using NaughtyAttributes;
using UnityEngine;

namespace Motorways.Themes
{
	[CreateAssetMenu(menuName = "Motorways/Theme/Color Group")]
	public class ColorGroup : ScriptableObject
	{
		[SerializeField]
		[EnumTypedArray(typeof(ThemeComponentGroupTarget))]
		private Color[] targets = new Color[10];

		public Color GetColor(ThemeComponentGroupTarget groupTarget)
		{
			if (Diagnostics.Verify((int)groupTarget < targets.Length, this, "Unable to find matching color for index: {0} - targets.Length: {1} ", (int)groupTarget, targets.Length))
			{
				return targets[(int)groupTarget];
			}
			return Color.magenta;
		}

		[Button(null)]
		public void UpdateTheme()
		{
		}
	}
}
