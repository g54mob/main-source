using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects
{
	public class TilingBackground : GameMonoBehaviour
	{
		private Stage _stage;

		private Vector2 _initialOffset;

		private float _timeOffset;

		private bool _canScroll;

		private TileSprite _bgtile;

		private Color _dayColor;

		private Color _nightColor;

		private float _yMul;

		private const float DayCycleDuration = 900f;

		public TileSprite bgtile => null;

		public bool RunTimeHue { get; set; }

		public void Init(Stage stage)
		{
		}

		private void LateUpdate()
		{
		}

		public void DayNightHue()
		{
		}

		public void SetBackgroundTilesTint(Color color)
		{
		}

		public void SetVisible(bool visible)
		{
		}

		public void ToggleScrolling(bool value)
		{
		}

		public void ResetAndStopDayNightHue()
		{
		}

		private void ProcessTiling()
		{
		}
	}
}
