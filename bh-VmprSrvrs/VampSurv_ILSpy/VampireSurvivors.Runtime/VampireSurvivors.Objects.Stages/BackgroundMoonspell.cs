using UnityEngine;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundMoonspell : BackgroundManager
{
	public override void Create()
	{
		base.Create();
		float yMax = default(float);
		bool skipInverseCalculation = default(bool);
		GM.Core.SetHardBoundsMinMax(256f, 256f, 9984f, yMax, skipInverseCalculation);
	}

	public override void Cleanup()
	{
		//IL_0013: Expected O, but got I4
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		GameManager core = GM.Core;
		core._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
	}
}
