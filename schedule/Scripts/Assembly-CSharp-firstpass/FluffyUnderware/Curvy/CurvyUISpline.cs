using UnityEngine;

namespace FluffyUnderware.Curvy
{
	[AddComponentMenu("Curvy/Curvy UI Spline")]
	[RequireComponent(typeof(RectTransform))]
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
