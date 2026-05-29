using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	[ExecuteAlways]
	public class E12_TrainManager : MonoBehaviour
	{
		public CurvySpline Spline;

		public float Speed;

		public float Position;

		public float CarSize;

		public float AxisDistance;

		public float CarGap;

		public float Limit;

		private bool isSetup;

		private E12_TrainCarManager[] Cars;

		[UsedImplicitly]
		private void Start()
		{
		}

		[UsedImplicitly]
		private void OnDisable()
		{
		}

		[UsedImplicitly]
		private void LateUpdate()
		{
		}

		private void setup()
		{
		}
	}
}
