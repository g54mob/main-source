using UnityEngine;

public class SoundManager : MonoBehaviour
{
	[Header("References")]
	public static SoundManager instance;

	public AudioSource ambientSource;

	[Header("Sound Effects")]
	public SoundEffect titel_impact;

	public SoundEffect player_walk;

	public SoundEffect player_heart_pounce;

	public SoundEffect player_troll_transformation;

	public SoundEffect duck_walk;

	public SoundEffect duck_honk;

	public SoundEffect duck_idle;

	public SoundEffect duck_flap;

	public SoundEffect overworld_bridge_ambience;

	public SoundEffect overworld_manhole_shake;

	public SoundEffect overworld_manhole_blast;

	public SoundEffect overworld_lilypad;

	public SoundEffect troll_dialog_alert;

	public SoundEffect troll_dialog_voice;

	public SoundEffect troll_dialog_skip;

	public SoundEffect troll_critical_hit;

	public SoundEffect troll_death;

	public SoundEffect transition_fade_out;

	public SoundEffect transition_fade_in;

	public SoundEffect chess_rulebook_slide_in;

	public SoundEffect chess_rulebook_slide_out;

	public SoundEffect chess_rulebook_page_flip;

	public SoundEffect chess_rulebook_link_hover;

	public SoundEffect chess_rulebook_fog_rumble;

	public SoundEffect chess_rulebook_fog_dissipate;

	public SoundEffect chess_accusation_in;

	public SoundEffect chess_accusation_out;

	public SoundEffect chess_accusation_chesspiece;

	public SoundEffect chess_accusation_rulebreak;

	public SoundEffect chess_accusation_confirm;

	public SoundEffect chess_accusation_correct;

	public SoundEffect chess_accusation_false;

	public SoundEffect chess_game_over;

	public SoundEffect chess_piece_grab;

	public SoundEffect chess_piece_drop;

	public SoundEffect chess_piece_capture;

	public SoundEffect chess_piece_castle_merge;

	public SoundEffect chess_piece_castle_scraps;

	public SoundEffect chess_piece_landmine_spawn;

	public SoundEffect chess_piece_landmine_explode;

	public SoundEffect chess_piece_pawn_ascention;

	public SoundEffect chess_piece_queen_worldflip;

	public SoundEffect chess_piece_rook_eat;

	public SoundEffect chess_piece_slip;

	public SoundEffect chess_piece_king_respawn;

	public SoundEffect ascension_rise;

	public SoundEffect ascension_fall;

	public SoundEffect ascension_rumble;

	public SoundEffect ascension_troll_kill;

	public void Awake()
	{
		Object.DontDestroyOnLoad(this);
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public static AudioClip LoadSoundEffect(Transform transform, SoundEffect soundEffect)
	{
		AudioSource audioSource = transform.gameObject.GetComponent<AudioSource>();
		if (audioSource == null)
		{
			audioSource = transform.gameObject.AddComponent<AudioSource>();
		}
		if (soundEffect.doRandomizePitch)
		{
			audioSource.pitch = Random.Range(1f - soundEffect.pitchRange, 1f + soundEffect.pitchRange);
		}
		audioSource.outputAudioMixerGroup = soundEffect.mixerGroup;
		audioSource.volume = soundEffect.volume;
		AudioClip audioClip = soundEffect.audioClips[Random.Range(0, soundEffect.audioClips.Length)];
		if (soundEffect.doLoopClip)
		{
			audioSource.clip = audioClip;
			audioSource.loop = true;
			audioSource.Play();
			return audioClip;
		}
		audioSource.PlayOneShot(audioClip);
		return audioClip;
	}
}
