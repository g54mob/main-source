using System;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Algorithm;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_Familiar_Brownie(ArcanaType type) : CharacterSkillCard_Base(type)
{
	public CharacterType followerType = CharacterType.FS_FOLLOWER_BROWNIE;

	public override void InitialActivate()
	{
		//IL_016c: Expected O, but got I4
		//IL_0192: Expected O, but got I4
		//IL_00d8: Expected I4, but got F4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		base.InitialActivate();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.5f;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
		object obj = UnityEngine.Random.RandomRangeInt(0, 4);
		bool flag = obj == null;
		AIType aiType;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (flag)
			{
				goto IL_0088;
			}
			object obj3 = obj2 - 1;
			aiType = AIType.MirrorInput;
			if (!flag)
			{
				if ((nint)obj3 != 1)
				{
					goto IL_0088;
				}
				aiType = AIType.DelayedPositionCopy;
			}
		}
		else
		{
			aiType = AIType.Aggressive;
		}
		goto IL_00b2;
		IL_0088:
		aiType = AIType.Defensive;
		goto IL_00b2;
		IL_00b2:
		int everyXLevels = default(int);
		bool spawnWithoutAuthority = default(bool);
		CharacterController characterController = GM.Core.AddFollower(followerType, LinkedCharacter, aiType, (byte)(int)num != 0, everyXLevels, spawnWithoutAuthority);
		if ((object)characterController != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			characterController._003CTrackedByCamera_003Ek__BackingField = false;
			characterController.IsFollowerSharingPassives = false;
			characterController.SetPermanentInvulnerability(on: true);
			characterController._003CCountsAsMainCharacterForRevivals_003Ek__BackingField = false;
		}
	}
}
