using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Algorithm;

namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterControllerThemCats : EME_CharacterControllerShowstopper
{
	private int _followers;

	private List<CharacterController> _catFollowers;

	public override bool NeedsCart => false;

	protected override void OnShowStopperStarted()
	{
		//IL_001c: Expected O, but got I4
		//IL_00d3: Expected O, but got I4
		//IL_0164: Expected I4, but got F4
		//IL_011c: Expected O, but got I4
		//IL_013b: Expected F4, but got I4
		if (_followers > 20)
		{
			return;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.5f;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
		if (!_coherenceSync.HasStateAuthority)
		{
			return;
		}
		List<CharacterController> catFollowers = _catFollowers;
		CharacterController followedCharacter;
		float congaYOffset;
		if (catFollowers._size <= 0)
		{
			followedCharacter = this;
			congaYOffset = 0.2f;
		}
		else
		{
			object obj = catFollowers._size - 1;
			if ((nint)obj >= catFollowers._size)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			CharacterController[] items = catFollowers._items;
			object obj2 = catFollowers._size - 1;
			followedCharacter = items[obj2];
			congaYOffset = 0f;
		}
		int everyXLevels = default(int);
		bool spawnWithoutAuthority = default(bool);
		CharacterController characterController = GM.Core.AddFollower(CharacterType.EME_CATS_FOLLOWER, followedCharacter, AIType.Conga, (byte)(int)num != 0, everyXLevels, spawnWithoutAuthority);
		characterController.SetPermanentInvulnerability(on: true);
		CharacterADControl deficiencyControl = characterController._deficiencyControl;
		characterController.IsFollowerSharingPassives = true;
		characterController._003CTrackedByCamera_003Ek__BackingField = false;
		deficiencyControl._congaYOffset = congaYOffset;
		deficiencyControl._currentType = AIType.Conga;
		deficiencyControl._congaMaxDistance = 0.18f;
		deficiencyControl._congaMinDistance = 0.14f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B050");
		int followers = _followers + 1;
		_followers = followers;
	}

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		_followers = 0;
		((CharacterController)this)._spriteTrail.Reset();
		SpriteTrail spriteTrail = ((CharacterController)this)._spriteTrail;
		spriteTrail._MaxHistory = 0;
		spriteTrail.InitialiseGhosts(expandExisting: true);
	}

	public EME_CharacterControllerThemCats()
	{
		List<CharacterController> catFollowers = new List<CharacterController>();
		_catFollowers = catFollowers;
		base._morphDuration = 13000f;
		((CharacterController)this)._002Ector();
	}
}
