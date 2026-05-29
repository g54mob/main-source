using FluffyUnderware.Curvy.Generator;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class E99_PerformanceDynamicSpline : MonoBehaviour
	{
		private CurvySpline mSpline;

		public CurvyGenerator Generator;

		[Positive]
		public int UpdateInterval;

		[RangeEx(2f, 2000f, null, null)]
		public int CPCount;

		[Positive]
		public float Radius;

		public bool AlwaysClear;

		public bool UpdateCG;

		private float mAngleStep;

		private float mCurrentAngle;

		private float mLastUpdateTime;

		private readonly TimeMeasure ExecTimes;

		[UsedImplicitly]
		private void Awake()
		{
		}

		[UsedImplicitly]
		private void Start()
		{
		}

		[UsedImplicitly]
		private void Update()
		{
		}

		private void addCP()
		{
		}

		[UsedImplicitly]
		private void OnGUI()
		{
		}
	}
}
