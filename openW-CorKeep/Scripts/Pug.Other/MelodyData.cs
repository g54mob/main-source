#define PUG_ACHIEVEMENTS
using Pug.UnityExtensions;
using UnityEngine;

public class MelodyData : MonoBehaviour
{
	public const int MAX_MELODY_NOTES = 16;

	private const int OCTAVE = 12;

	private const int MAX_PITCHES = 36;

	private const float SUCCESS_COOLDOWN = 10f;

	private const float BRIEF_TIME = 0.1f;

	private static float[] pitches = new float[36];

	private static Melody melodyToAutoplay = new Melody();

	public static Melody melodyPlayed = new Melody();

	private static bool justPlayed = false;

	private static Vector3 position;

	private static int keyOffset = 0;

	private static TimerSimple[] noteTimes = new TimerSimple[16];

	private static TimerSimple melodyLingerTime;

	private static bool autoplayMelody = false;

	public static TimerSimple successCooldown = new TimerSimple(10f);

	public static readonly Melody[] melodies = new Melody[28]
	{
		new Melody(MelodyID.Test, new int[3] { 0, 2, 4 }),
		new Melody(MelodyID.Menu, new int[8] { 4, 0, 2, 4, 5, 7, 9, 4 }, new float[8] { 2f, 3f, 1f, 1f, 1f, 2f, 2f, 2f }),
		new Melody(MelodyID.Dirt2, new int[7] { 4, 9, 11, 7, 4, 9, 11 }),
		new Melody(MelodyID.Dirt5, new int[7] { 4, 5, 7, 4, 2, 0, 2 }),
		new Melody(MelodyID.Clay1, new int[5] { 9, 4, 9, 4, 2 }, new float[5] { 2f, 1f, 1f, 4f, 8f }, 0.5f),
		new Melody(MelodyID.Clay3, new int[8] { 9, 4, 5, 0, 9, 4, 5, 0 }),
		new Melody(MelodyID.Stone1, new int[8] { 7, 7, 9, 5, 7, 2, 5, 7 }),
		new Melody(MelodyID.Stone2, new int[8] { 9, 5, 7, 5, 9, 5, 7, 5 }, new float[8] { 2f, 1f, 2f, 3f, 2f, 1f, 2f, 3f }, 0.5f),
		new Melody(MelodyID.Nature1, new int[6] { 9, 7, 5, 2, 0, 4 }, new float[6] { 5f, 1f, 1f, 4f, 3f, 8f }, 0.5f),
		new Melody(MelodyID.Nature2, new int[8] { 7, 9, 4, 4, 7, 9, 4, 4 }, new float[8] { 2f, 1f, 2f, 2f, 2f, 1f, 2f, 2f }, 0.5f),
		new Melody(MelodyID.Sea1, new int[7] { 9, 2, 9, 7, 5, 7, 9 }),
		new Melody(MelodyID.Sea2, new int[6] { 0, 2, 4, 9, 11, 7 }, new float[6] { 1f, 1f, 1f, 1f, 2f, 1f }),
		new Melody(MelodyID.Desert1, new int[7] { 4, 9, 4, 7, 5, 4, 2 }, new float[7] { 2f, 2f, 3f, 1f, 1f, 1f, 6f }),
		new Melody(MelodyID.Desert2, new int[8] { 7, 0, 4, 5, 0, 4, 5, 7 }),
		new Melody(MelodyID.Crystal1, new int[5] { 5, 0, 11, 7, 4 }, new float[5] { 2f, 2f, 3f, 3f, 6f }, 0.5f),
		new Melody(MelodyID.Crystal2, new int[7] { 2, 9, 2, 2, 9, 4, 5 }, new float[7] { 1f, 1f, 4f, 1f, 1f, 2f, 2f }),
		new Melody(MelodyID.Passage1, new int[8] { 4, 9, 5, 4, 4, 9, 5, 7 }, new float[8] { 1f, 2f, 1f, 4f, 1f, 2f, 1f, 4f }, 0.5f),
		new Melody(MelodyID.Excav1, new int[8] { 0, 11, 9, 7, 5, 4, 4, 0 }),
		new Melody(MelodyID.Excav2, new int[8] { 4, 9, 11, 2, 4, 9, 11, 4 }),
		new Melody(MelodyID.Shave, new int[5] { 5, 0, 0, 2, 0 }, new float[5] { 3f, 2f, 1f, 3f, 6f }, 0.5f),
		new Melody(MelodyID.Lick, new int[7] { 2, 4, 5, 7, 4, 0, 2 }, new float[7] { 1f, 1f, 1f, 1f, 2f, 1f, 1f }),
		new Melody(MelodyID.Twinkle, new int[7] { 0, 0, 7, 7, 9, 9, 7 }),
		new Melody(MelodyID.Elise, new int[9] { 7, 6, 7, 6, 7, 2, 5, 3, 0 }),
		new Melody(MelodyID.Storm, new int[6] { 2, 5, 14, 2, 5, 14 }, new float[6] { 1f, 1f, 4f, 1f, 1f, 4f }, 0.5f),
		new Melody(MelodyID.Super, new int[6] { 4, 4, 4, 0, 4, 7 }, new float[6] { 1f, 2f, 2f, 1f, 2f, 4f }),
		new Melody(MelodyID.Roll, new int[7] { 0, 2, 5, 2, 9, 9, 7 }, new float[7] { 1f, 1f, 1f, 1f, 3f, 3f, 4f }),
		new Melody(MelodyID.Megalo, new int[4] { 2, 2, 14, 9 }, new float[4] { 1f, 1f, 2f, 3f }, 0.5f),
		new Melody(MelodyID.Among, new int[7] { 0, 3, 5, 6, 5, 3, 0 })
	};

	public static readonly Melody[] melodyContinuations = new Melody[24]
	{
		new Melody(MelodyID.Test, new int[3] { 0, 2, 4 }, null, 1f, autoplay: false),
		new Melody(MelodyID.Menu, new int[7] { 4, 2, 4, 5, 7, 9, 4 }, new float[7] { 3f, 1f, 1f, 1f, 2f, 2f, 1f }),
		new Melody(MelodyID.Dirt2, new int[6] { 11, 4, 9, 11, 7, 6 }, new float[6] { 2f, 1f, 1f, 1f, 1f, 1f }),
		new Melody(MelodyID.Dirt5, new int[8] { 2, 4, 5, 7, 4, 2, 0, -2 }, new float[8] { 2f, 1f, 1f, 1f, 1f, 1f, 1f, 1f }),
		new Melody(MelodyID.Clay1, new int[6] { 2, 4, -1, 4, -1, -3 }, new float[6] { 8f, 2f, 1f, 1f, 4f, 1f }, 0.5f),
		new Melody(MelodyID.Clay3, new int[9] { 0, -2, 4, 5, 12, -2, 4, 5, 12 }, new float[9] { 2f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f }),
		new Melody(MelodyID.Stone1, new int[6] { 7, -5, 7, 9, 5, 7 }),
		new Melody(MelodyID.Stone2, new int[7] { 5, -3, 4, 0, 2, 0, -1 }, new float[7] { 2f, 1f, 2f, 1f, 2f, 2f, 2f }, 0.5f),
		new Melody(MelodyID.Nature1, new int[5] { 4, -5, -3, 0, -3 }, new float[5] { 4f, 2f, 1f, 1f, 1f }, 0.5f),
		new Melody(MelodyID.Nature2, new int[5] { 4, 7, 8, 10, 5 }, new float[5] { 4f, 4f, 3f, 1f, 1f }, 0.5f),
		new Melody(MelodyID.Sea1, new int[8] { 9, 14, 12, 10, 10, 9, 10, 12 }, new float[8] { 3f, 1f, 1f, 1f, 1f, 1f, 1f, 1f }),
		new Melody(MelodyID.Sea2, new int[8] { 7, 2, 4, 6, 7, 9, 6, 4 }, new float[8] { 2f, 1f, 1f, 1f, 1f, 1f, 1f, 1f }),
		new Melody(MelodyID.Desert1, new int[8] { 2, 4, 9, 4, 7, 2, 4, 5 }, new float[8] { 4f, 2f, 2f, 3f, 1f, 1f, 1f, 1f }, 0.5f),
		new Melody(MelodyID.Desert2, new int[9] { 7, 7, 0, 4, 5, 12, 4, 7, 8 }),
		new Melody(MelodyID.Crystal1, new int[7] { 4, 4, 12, 11, 12, 14, 7 }, new float[7] { 3f, 2f, 2f, 3f, 3f, 2f, 2f }, 0.5f),
		new Melody(MelodyID.Crystal2, new int[8] { 5, 2, 9, 2, 2, 5, 4, 0 }, new float[8] { 2f, 1f, 1f, 4f, 1f, 1f, 2f, 2f }),
		new Melody(MelodyID.Passage1, new int[9] { 2, 4, 9, 4, 2, 4, 9, 11, 9 }, new float[9] { 2f, 1f, 2f, 1f, 4f, 1f, 2f, 1f, 4f }, 0.5f),
		new Melody(MelodyID.Excav1, new int[9] { 0, 12, 11, 7, 5, 4, 0, 0, -1 }, new float[9] { 2f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f }),
		new Melody(MelodyID.Excav2, new int[9] { 4, 5, 9, 11, 14, 5, 9, 11, 16 }),
		new Melody(MelodyID.Shave, new int[3] { 0, 4, 5 }, new float[3] { 2f, 1f, 1f }),
		new Melody(MelodyID.Lick, new int[8] { 2, 2, 4, 5, 7, 4, 0, 2 }, new float[8] { 5f, 1f, 1f, 1f, 1f, 2f, 1f, 1f }, 0.5f),
		new Melody(MelodyID.Twinkle, new int[8] { 7, 5, 5, 4, 4, 2, 2, 0 }, new float[8] { 2f, 1f, 1f, 1f, 1f, 1f, 1f, 1f }),
		new Melody(MelodyID.Elise, new int[9] { 0, -9, -5, 0, 2, -5, 3, 2, 0 }, new float[9] { 3f, 1f, 1f, 1f, 3f, 1f, 1f, 1f, 1f }, 0.7f),
		new Melody(MelodyID.Storm, new int[8] { 14, 16, 17, 16, 17, 16, 12, 9 }, new float[8] { 4f, 3f, 1f, 1f, 1f, 1f, 1f, 4f }, 0.5f, autoplay: false)
	};

	public static void OnMelodyPlayed(MelodyID melodyID, EntityMonoBehaviour entityMono, int scale, bool autoplay)
	{
		int num = (int)(melodyID - 1);
		melodyPlayed = melodies[num];
		melodyLingerTime.Start(0.1f);
		position = entityMono.transform.position;
		keyOffset = scale;
		int num2 = -12;
		for (int i = 0; i < 36; i++)
		{
			pitches[i] = Mathf.Pow(2f, (float)(i + keyOffset + num2 - 12) / 12f);
		}
		if (!successCooldown.isRunning)
		{
			successCooldown.Start();
			float volume = 0.3f;
			SfxID sfxID;
			switch (melodyID)
			{
			case MelodyID.Storm:
				sfxID = SfxID.thunderLightning;
				if (entityMono is PlayerController { isLocal: not false })
				{
					Manager.achievements.TriggerAchievement(AchievementID.StormSong);
				}
				break;
			case MelodyID.Among:
				sfxID = SfxID.daggerImpact2;
				break;
			case MelodyID.Megalo:
			{
				sfxID = SfxID.twinkle;
				PlayerController playerController = (PlayerController)entityMono;
				if (!(playerController == null))
				{
					playerController.flashableEyesComponent.FlashLinearNoCurve(Color.cyan, 0.3f);
				}
				break;
			}
			default:
				sfxID = SfxID.windupMagicGlass;
				volume = 0f;
				break;
			}
			AudioManager.Sfx(sfxID, position, volume);
		}
		if (successCooldown.elapsedTime > successCooldown.lifespan)
		{
			successCooldown.Stop();
		}
		if ((int)melodyID >= melodyContinuations.Length)
		{
			return;
		}
		melodyToAutoplay = melodyContinuations[num];
		if (!(melodyToAutoplay.autoplay && autoplay))
		{
			return;
		}
		if (melodyToAutoplay.Length == 0)
		{
			melodyToAutoplay = melodyContinuations[3];
		}
		autoplayMelody = true;
		for (int j = 0; j < melodyToAutoplay.Length; j++)
		{
			float num3 = 0f;
			for (int k = 0; k < j; k++)
			{
				float num4 = 1f;
				if (melodyToAutoplay.DurationsLength - 1 >= k && melodyToAutoplay.durations.Length != 0)
				{
					num4 = melodyToAutoplay.durations[k];
				}
				float durationMod = melodyToAutoplay.durationMod;
				num3 += 0.3f * num4 * durationMod;
			}
			noteTimes[j].Start(num3);
		}
	}

	public static void Update()
	{
		if (justPlayed)
		{
			justPlayed = false;
			melodyPlayed = new Melody();
		}
		if (!autoplayMelody)
		{
			return;
		}
		for (int i = 0; i < melodyToAutoplay.Length; i++)
		{
			if (noteTimes[i].isRunning && noteTimes[i].isTimerElapsed)
			{
				float volume = 0.4f;
				if (i == 0)
				{
					volume = 0.01f;
				}
				AudioManager.Sfx(SfxID.melody_C6, position, volume, pitches[melodyToAutoplay[i] + 12]);
				noteTimes[i].Stop();
			}
		}
		if (noteTimes[melodyToAutoplay.Length - 1].isTimerElapsed)
		{
			autoplayMelody = false;
		}
		justPlayed = true;
	}
}
