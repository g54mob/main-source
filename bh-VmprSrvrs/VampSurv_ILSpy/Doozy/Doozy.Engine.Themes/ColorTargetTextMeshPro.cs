using System;
using Cpp2ILInjected;

namespace Doozy.Engine.Themes;

public class ColorTargetTextMeshPro : ThemeTarget
{
	public bool OverrideAlpha;

	public float Alpha;

	private float m_previousAlphaValue = -1f;

	private void Update()
	{
		if (OverrideAlpha)
		{
			bool flag = Alpha == m_previousAlphaValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C06A33h\"");
			if (!flag)
			{
				m_previousAlphaValue = Alpha;
			}
		}
	}

	public override void UpdateTarget(ThemeData theme)
	{
	}

	public void SetAlpha(float value)
	{
	}

	private void Reset()
	{
		ThemeId = Guid.Empty;
		VariantId = Guid.Empty;
		PropertyId = Guid.Empty;
	}

	private void UpdateReference()
	{
	}
}
