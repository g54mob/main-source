using System.Collections.Generic;
using System.Reflection;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class E99_PerformanceAPI : MonoBehaviour
	{
		private const int LOOPS = 20;

		private readonly List<string> mTests;

		private readonly List<string> mTestResults;

		private CurvyInterpolation mInterpolation;

		private CurvyOrientation mOrientation;

		private int mCacheSize;

		private int mControlPointCount;

		private int mTotalSplineLength;

		private bool mUseCache;

		private bool mUseMultiThreads;

		private int mCurrentTest;

		private bool mExecuting;

		private readonly TimeMeasure Timer;

		private MethodInfo mGUIMethod;

		private MethodInfo mRunMethod;

		private bool mInterpolate_UseDistance;

		private int mRefresh_Mode;

		[UsedImplicitly]
		private void Awake()
		{
		}

		[UsedImplicitly]
		private void OnGUI()
		{
		}

		[UsedImplicitly]
		private void GUI_Interpolate()
		{
		}

		[UsedImplicitly]
		private void Test_Interpolate()
		{
		}

		[UsedImplicitly]
		private void GUI_Refresh()
		{
		}

		[UsedImplicitly]
		private void Test_Refresh()
		{
		}

		private CurvySpline getSpline()
		{
			return null;
		}

		private void AddCPs(ref CurvySpline spline, int count, int totalLength)
		{
		}

		private void runTest()
		{
		}
	}
}
