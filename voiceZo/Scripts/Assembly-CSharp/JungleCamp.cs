using System.Collections;
using UnityEngine;

public class JungleCamp : Camp
{
	protected override IEnumerator Co_StartHarmony()
	{
		yield return base.Co_StartHarmony();
		yield return Co_VoicePlay(_spot_01);
		yield return Co_VoicePlay(_spot_02);
		yield return Co_VoicePlay(_spot_03);
		yield return Co_VoicePlay(_spot_04);
		yield return Co_VoicePlay(_spot_05);
		yield return new WaitForSeconds(0.5f);
		_isHarmonyPlaying = false;
	}
}
