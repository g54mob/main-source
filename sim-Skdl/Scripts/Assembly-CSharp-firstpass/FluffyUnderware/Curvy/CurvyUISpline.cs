using UnityEngine;

namespace FluffyUnderware.Curvy
{
	[RequireComponent(typeof(RectTransform))]
	[AddComponentMenu("Curvy/Curvy UI Spline")]
	[HelpURL("https://curvyeditor.com/doclink/curvyuispline")]
	public class CurvyUISpline : CurvySpline
	{
		public static CurvyUISpline CreateUISpline(string gameObjectName = "Curvy UI Spline")
		{
			return null;
		}

		protected override void Reset()
		{
		}

		private void SetupUISpline()
		{
		}
	}
}
