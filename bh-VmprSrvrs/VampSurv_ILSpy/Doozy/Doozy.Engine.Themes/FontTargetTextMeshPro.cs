using System;

namespace Doozy.Engine.Themes;

public class FontTargetTextMeshPro : ThemeTarget
{
	public override void UpdateTarget(ThemeData theme)
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
