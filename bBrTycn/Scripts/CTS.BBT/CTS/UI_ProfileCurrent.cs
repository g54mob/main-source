using UnityEngine;

namespace CTS
{
	public class UI_ProfileCurrent : UI_ProfileFeature
	{
		[SerializeField]
		private CanvasGroup _canvasGroup;

		public override void Repaint()
		{
			if (_careerMetaData.IsCurrentProfile())
			{
				_canvasGroup.alpha = 1f;
			}
			else
			{
				_canvasGroup.alpha = 0f;
			}
		}
	}
}
