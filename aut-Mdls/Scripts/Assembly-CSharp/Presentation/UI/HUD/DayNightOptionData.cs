using System;
using Logic.Lighting;
using UnityEngine;

namespace Presentation.UI.HUD
{
	[Serializable]
	public struct DayNightOptionData
	{
		public string TextKey;

		public Sprite IconSprite;

		public Color IconColor;

		public float Opacity;

		public DayNightCycleManager.CycleState State;
	}
}
