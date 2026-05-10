using FluffyUnderware.Curvy.Controllers;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyUnderware.Curvy.Examples
{
	public class E04_PaintSpline : MonoBehaviour
	{
		public float StepDistance;

		public SplineController Controller;

		public Text InfoText;

		private CurvySpline mSpline;

		private Vector2 mLastControlPointPos;

		private bool mResetSpline;

		[UsedImplicitly]
		private void Awake()
		{
		}

		[UsedImplicitly]
		private void OnGUI()
		{
		}

		private CurvySplineSegment addCP(Vector3 mousePos)
		{
			return null;
		}
	}
}
