using System.Text;
using UnityEngine;

namespace Doozy.Engine.Progress
{
	[AddComponentMenu("Doozy/Progress/Targets/Progress Target TextMeshPro", 13)]
	[DefaultExecutionOrder(-99)]
	public class ProgressTargetTextMeshPro : ProgressTarget
	{
		public TargetVariable TargetVariable;

		public bool WholeNumbers;

		public bool UseMultiplier;

		public float Multiplier;

		public string Prefix;

		public string Suffix;

		private bool m_initialized;

		private float m_targetValue;

		private StringBuilder m_stringBuilder;

		public override void UpdateTarget(Progressor progressor)
		{
		}

		private void Reset()
		{
		}

		private void Init()
		{
		}

		private void UpdateReference()
		{
		}
	}
}
