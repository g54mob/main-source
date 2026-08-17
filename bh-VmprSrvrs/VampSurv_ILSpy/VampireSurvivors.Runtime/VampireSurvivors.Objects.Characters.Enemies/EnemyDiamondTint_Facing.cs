using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDiamondTint_Facing : EnemyDiamondTint
{
	private int MaxHits = 4;

	protected override float ItemChance => 0.0615f;

	protected override bool IsImmovable => false;

	protected override bool IsAxe => false;

	protected override bool IsSnake => true;

	protected override bool DoBaseUpdate => true;

	protected override uint[] TintProgression => new uint[3] { 4504575u, 8978431u, 4521915u };

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_009b: Expected O, but got I
		//IL_012b: Expected O, but got I4
		//IL_003e: Expected O, but got I8
		base.InitEnemy(enemyType, asRemote);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		EnemyDiamondTint enemyDiamondTint = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			enemyDiamondTint = (EnemyDiamondTint)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v57 @ rax_v12 (should have been resolved before IL gen)");
		float num = 1f * ((EnemyController)this)._003CSpeed_003Ek__BackingField;
		((EnemyController)this)._003CSpeed_003Ek__BackingField = num;
		uint[] tintProgression = TintProgression;
		uint[] tintProgression2 = TintProgression;
		object obj2 = UnityEngine.Random.RandomRangeInt(0, tintProgression2.Length);
		_saveTint = tintProgression[obj2];
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_EnemyRenderer, tintProgression[obj2]);
	}

	protected override void ChangeFrame()
	{
		//IL_0112: Expected O, but got I4
		//IL_0187: Expected O, but got F4
		//IL_003e: Expected O, but got I4
		//IL_0178: Expected O, but got I4
		float time = default(float);
		if (_hitsTaken < MaxHits)
		{
			SfxType sfx_gotHit = base.Sfx_gotHit;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			float volume_gotHit = base.Volume_gotHit;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_hitsTaken * 100f;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(sfx_gotHit, soundConfig, 100f, 4, time);
			uint[] tintProgression = TintProgression;
			uint[] tintProgression2 = TintProgression;
			object obj = UnityEngine.Random.RandomRangeInt(0, tintProgression2.Length);
			_saveTint = tintProgression[obj];
			SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_EnemyRenderer, tintProgression[obj]);
		}
		else
		{
			SfxType sfx_breaking = base.Sfx_breaking;
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Rate = 1f;
			float volume_breaking = base.Volume_breaking;
			soundConfig2.Volume = (float?)(object)1;
			object obj2 = UnityEngine.Random.value;
			object obj3 = default(object);
			float detune2 = (float)obj3 * -600f;
			soundConfig2.Detune = detune2;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(sfx_breaking, soundConfig2, 100f, 4, time);
			Die();
		}
	}

	public EnemyDiamondTint_Facing()
	{
		base._grav = 0.3125f;
		((EnemyDiamond)this)._002Ector();
	}
}
