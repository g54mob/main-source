using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Icicle2_LaunchProjectile : Projectile
{
	private const float Radius = 16f;

	private PhaserSprite _icicleSprite;

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A161B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite icicleSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Ice21");
		_icicleSprite = icicleSprite;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0067: Expected O, but got I4
		//IL_00f1: Expected O, but got F4
		//IL_011c: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_speed = 3f;
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		float num = _weapon.PArea();
		object obj = default(object);
		float num2 = (float)obj * 0.3f;
		float num3 = num2 + 1f;
		ArcadeSprite arcadeSprite = setScale(num3, (float?)(object)0);
		PhaserSprite phaserSprite = _icicleSprite.setVisible(visible: false);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj2 = Random.value;
		float detune = num3 * 200f;
		soundConfig.Detune = detune;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_ShieldDark1, soundConfig, 200f, 1, time);
	}

	public void SetSprite(Sprite sprite)
	{
		PhaserSprite icicleSprite = _icicleSprite;
		icicleSprite._spriteRenderer.sprite = sprite;
		PhaserSprite phaserSprite = _icicleSprite.setVisible(visible: true);
	}

	private void PlaySfx()
	{
		//IL_004b: Expected O, but got F4
		//IL_0076: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = Random.value;
		object obj2 = default(object);
		float detune = (float)obj2 * 200f;
		soundConfig.Detune = detune;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_ShieldDark1, soundConfig, 200f, 1, time);
	}
}
