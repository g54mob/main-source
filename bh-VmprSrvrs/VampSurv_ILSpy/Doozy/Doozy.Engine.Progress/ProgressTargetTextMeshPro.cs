using System.Text;

namespace Doozy.Engine.Progress;

public class ProgressTargetTextMeshPro : ProgressTarget
{
	public TargetVariable TargetVariable = TargetVariable.Progress;

	public bool WholeNumbers = true;

	public bool UseMultiplier;

	public float Multiplier = 100f;

	public string Prefix;

	public string Suffix = "%";

	private bool m_initialized;

	private float m_targetValue;

	private StringBuilder m_stringBuilder;

	public override void UpdateTarget(Progressor progressor)
	{
		if (!m_initialized)
		{
			if (m_stringBuilder == null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				m_stringBuilder = stringBuilder;
			}
			m_initialized = true;
		}
	}

	private void Reset()
	{
	}

	private void Init()
	{
		if (m_stringBuilder == null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			m_stringBuilder = stringBuilder;
		}
		m_initialized = true;
	}

	private void UpdateReference()
	{
	}

	public ProgressTargetTextMeshPro()
	{
		StringBuilder stringBuilder = new StringBuilder();
		m_stringBuilder = stringBuilder;
	}
}
