using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Progress
{
	[AddComponentMenu("Doozy/Progress/Targets/Progress Target Text", 13)]
	[DefaultExecutionOrder(-99)]
	public class ProgressTargetText : ProgressTarget
	{
		public Text Text;

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
