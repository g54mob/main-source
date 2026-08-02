using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ultimate Radial Menu Style", menuName = "Tank and Healer Studio/Ultimate Radial Menu Style", order = 1)]
public class UltimateRadialMenuStyle : ScriptableObject
{
	[Serializable]
	public class RadialMenuStyle
	{
		public int buttonCount;

		public Sprite normalSprite;

		public Sprite highlightedSprite;

		public Sprite pressedSprite;

		public Sprite selectedSprite;

		public Sprite disabledSprite;
	}

	public int minButtonCount = 3;

	public int maxButtonCount = 12;

	public List<RadialMenuStyle> RadialMenuStyles = new List<RadialMenuStyle>();
}
