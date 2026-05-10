using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyUnderware.Curvy.Examples
{
	[ExecuteAlways]
	public class E05_MoveToNearestPoint : MonoBehaviour
	{
		public Transform Lookup;

		public CurvySpline Spline;

		public Text StatisticsText;

		public Slider Density;

		private readonly TimeMeasure Timer;

		[UsedImplicitly]
		private void Update()
		{
		}

		public void OnSliderChange()
		{
		}
	}
}
