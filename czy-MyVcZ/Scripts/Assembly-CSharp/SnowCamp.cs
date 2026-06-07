using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCamp : Camp
{
	protected override IEnumerator Co_StartHarmony()
	{
		yield return base.Co_StartHarmony();
		List<Spot> list = new List<Spot> { _spot_01, _spot_02, _spot_03, _spot_04, _spot_05 };
		Shuffle(list);
		foreach (Spot item in list)
		{
			yield return Co_VoicePlay(item);
		}
		yield return new WaitForSeconds(0.5f);
		_isHarmonyPlaying = false;
	}

	private void Shuffle<T>(List<T> list)
	{
		for (int num = list.Count - 1; num > 0; num--)
		{
			int num2 = Random.Range(0, num + 1);
			int index = num;
			int index2 = num2;
			T val = list[num2];
			T val2 = list[num];
			T val3 = (list[index] = val);
			val3 = (list[index2] = val2);
		}
	}
}
