using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.ScriptableObjectScripts.Settings
{
	public class InGameScaleSetting : ScriptableObject
	{
		[Serializable]
		public struct TutorialTarget
		{
			public eTutorialId targetId;

			public double targetTime;
		}

		[Header("時間・報酬スケール")]
		[Range(0f, 5f)]
		public float pcScale;

		[Range(0f, 5f)]
		public float switchScale;

		[Range(0f, 5f)]
		public float psScale;

		[Range(0f, 5f)]
		public float xboxScale;

		[Header("チュートリアル目標時間")]
		public List<TutorialTarget> pcTutorialTarget;

		public List<TutorialTarget> consoleTutorialTarget;

		public float GetPlatformScale()
		{
			return 0f;
		}

		public List<TutorialTarget> GetPlatformTutorialTarget()
		{
			return null;
		}

		public double GetPlatformTutorialTargetTime(int index)
		{
			return 0.0;
		}
	}
}
