using UnityEngine;

namespace Gh.Tk
{
	public class GameSpeedButton3DUIView : Button3DUIView
	{
		[Range(0f, 3f)]
		public int timeSelection;

		private static Color _defaultColor;

		private static Color _defaultEmission;

		private static Color _hoverEmission;

		private static Color _disabledColor;

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected override void OnClickedInternal()
		{
		}
	}
}
