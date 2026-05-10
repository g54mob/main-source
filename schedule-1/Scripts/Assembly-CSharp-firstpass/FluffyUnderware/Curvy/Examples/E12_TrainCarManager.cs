using FluffyUnderware.Curvy.Controllers;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	[ExecuteAlways]
	public class E12_TrainCarManager : MonoBehaviour
	{
		public SplineController Waggon;

		public SplineController FrontAxis;

		public SplineController BackAxis;

		private E12_TrainManager mTrain;

		public float Position
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[UsedImplicitly]
		private void LateUpdate()
		{
		}

		public void setup()
		{
		}

		private void setController(SplineController c, CurvySpline spline, float speed)
		{
		}

		public void OnCPReached(CurvySplineMoveEventArgs e)
		{
		}
	}
}
