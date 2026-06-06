using System.Collections;
using UnityEngine;

public class ForestCamp : Camp
{
	protected override IEnumerator Co_StartHarmony()
	{
		yield return base.Co_StartHarmony();
		yield return Co_VoicePlay(_spot_01, _spot_02, _spot_03, _spot_04, _spot_05);
		yield return new WaitForSeconds(0.5f);
		_isHarmonyPlaying = false;
	}
}
