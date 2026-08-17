using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_AlucardSpear2_Projectile : TP_AlucardSpear1_Projectile
{
	protected override string FrameName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A41A9]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "TP_VFX_Spear02";
		}
	}

	protected override int AutoFlip => 0;

	protected override Vector2 ImageHalfSize
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
	}

	public TP_AlucardSpear2_Projectile()
	{
		base.horizontalOffset = 0.39999998f;
		List<Projectile> tips = new List<Projectile>();
		base._tips = tips;
		base.offsetPx = 0.3f;
		((Projectile)this)._002Ector();
	}
}
