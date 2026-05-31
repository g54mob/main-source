using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public enum SoundTypeEnum
	{
		none = 0,
		ui_ability_click = 1,
		ui_ability_hover = 2,
		ui_ba_upgrade_pop = 3,
		ui_button1_click = 4,
		ui_button1_hover = 5,
		ui_button2_click = 6,
		ui_button2_hover = 7,
		ui_checkbox_off = 8,
		ui_checkbox_on = 9,
		ui_gamemenu_off = 10,
		ui_gamemenu_on = 11,
		ui_gamemenu_tab_appear = 12,
		ui_info_click = 13,
		ui_info_hover = 14,
		ui_nodepanel_option_click = 15,
		ui_nodepanel_option_hover = 16,
		ui_node_click_fail = 17,
		ui_node_click_success = 18,
		ui_node_click_success_evil = 19,
		ui_node_hover = 20,
		ui_progressbar_move = 21,
		ui_quest_claim = 22,
		ui_quest_completed = 23,
		ui_title_fill = 24,
		ui_title_fully_fill = 25,
		ui_toast_pop = 26,
		ui_tutorial_pop = 27,
		ui_test = 28,
		ba_build = 29,
		ba_clogged = 30,
		ba_destroy_building_m = 31,
		ba_destroy_building_s = 32,
		ba_garbage_output = 33,
		ba_minigame_click = 34,
		ba_minigame_success = 35,
		ba_upgrade = 36,
		ba_worker_add = 37,
		ba_worker_remove = 38,
		bs_balloon_moving = 39,
		bs_balloon_working = 40,
		bs_balloon_drop = 41,
		bs_cannon = 42,
		bs_catapult = 43,
		bs_compress = 44,
		bs_drone_moving = 45,
		bs_drone_working = 46,
		bs_factory_working = 47,
		bs_fan_on = 48,
		bs_gain_rp = 49,
		bs_helicopter = 50,
		bs_helicopter_drop = 51,
		bs_minigunn = 52,
		bs_portal = 53,
		bs_portal_lazer = 54,
		bs_power_pulse = 55,
		bs_rock_destroy = 56,
		bs_rock_hit = 57,
		bs_temple_praying = 58,
		bs_zap = 59,
		en_lazer_destroy = 60,
		en_lazer_hit = 61,
		en_lazer_prepare = 62,
		en_monster_appear = 63,
		en_peon_happy = 64,
		en_peon_walk = 65,
		en_question_pop = 66,
		en_show_statue = 67,
		ga_airplane = 68,
		ga_book_appear = 69,
		ga_buildingfocus_off = 70,
		ga_buildingfocus_on = 71,
		ga_bulldozer = 72,
		ga_cloud_click = 73,
		ga_cloud_destroy = 74,
		ga_earthquake = 75,
		ga_gain_money = 76,
		ga_garbage_hit = 77,
		ga_garbage_passing = 78,
		ga_grab_peon = 79,
		ga_new_peon = 80,
		ga_peon_getsad = 81,
		ga_shard_appear = 82,
		ga_shard_red_appear = 83,
		ga_throw_garbage = 84,
		ga_throw_peon = 85,
		ga_recall = 86,
		ga_signing = 87,
		ga_minion = 88,
		ga_golem_hit = 89,
		ga_golem_walk = 90,
		mu_beginning = 91,
		mu_earthquake_ready = 92,
		mu_ending = 93,
		mu_en_animation = 94,
		mu_ingame_menu = 95,
		mu_intro = 96,
		mu_v2_ingame1 = 97,
		mu_v2_ingame2 = 98,
		mu_v2_ingame3 = 99,
		mu_v2_ingame4 = 100,
		mu_v2_ingame5 = 101,
		mu_v2_ingame6 = 102,
		mu_v2_ingame7 = 103,
		mu_v2_ingame8 = 104,
		mu_v2_ingame9 = 105,
		mu_looking_at_statue = 106
	}

	private Dictionary<SoundTypeEnum, AudioClip> _allClips = new Dictionary<SoundTypeEnum, AudioClip>();

	private Tween _fading;

	private float _minZoom = 6f;

	private float _maxZoom = 30f;

	private float _maxDistance = 15f;

	private float _minVolume;

	private float _maxVolume = 1f;

	private void Awake()
	{
		_allClips.Add(SoundTypeEnum.ui_ability_click, FindClip("ui_ability_click"));
		_allClips.Add(SoundTypeEnum.ui_ability_hover, FindClip("ui_button2_hover"));
		_allClips.Add(SoundTypeEnum.ui_ba_upgrade_pop, FindClip("ui_ba_upgrade_pop"));
		_allClips.Add(SoundTypeEnum.ui_button1_click, FindClip("ui_button1_click"));
		_allClips.Add(SoundTypeEnum.ui_button1_hover, FindClip("ui_button1_hover"));
		_allClips.Add(SoundTypeEnum.ui_button2_click, FindClip("ui_button2_click"));
		_allClips.Add(SoundTypeEnum.ui_button2_hover, FindClip("ui_button2_hover"));
		_allClips.Add(SoundTypeEnum.ui_checkbox_off, FindClip("ui_checkbox_off"));
		_allClips.Add(SoundTypeEnum.ui_checkbox_on, FindClip("ui_checkbox_on"));
		_allClips.Add(SoundTypeEnum.ui_gamemenu_off, FindClip("ui_gamemenu_off"));
		_allClips.Add(SoundTypeEnum.ui_gamemenu_on, FindClip("ui_gamemenu_on"));
		_allClips.Add(SoundTypeEnum.ui_gamemenu_tab_appear, FindClip("ui_gamemenu_tab_appear"));
		_allClips.Add(SoundTypeEnum.ui_info_click, FindClip("ui_info_click"));
		_allClips.Add(SoundTypeEnum.ui_info_hover, FindClip("ui_info_hover"));
		_allClips.Add(SoundTypeEnum.ui_nodepanel_option_click, FindClip("ui_button1_click"));
		_allClips.Add(SoundTypeEnum.ui_nodepanel_option_hover, FindClip("ui_button2_hover"));
		_allClips.Add(SoundTypeEnum.ui_node_click_fail, FindClip("ui_node_click_fail"));
		_allClips.Add(SoundTypeEnum.ui_node_click_success, FindClip("ui_node_click_success"));
		_allClips.Add(SoundTypeEnum.ui_node_click_success_evil, FindClip("ui_node_click_success_evil"));
		_allClips.Add(SoundTypeEnum.ui_node_hover, FindClip("ui_button2_hover"));
		_allClips.Add(SoundTypeEnum.ui_progressbar_move, FindClip("ui_progressbar_move"));
		_allClips.Add(SoundTypeEnum.ui_quest_claim, FindClip("ui_quest_claim"));
		_allClips.Add(SoundTypeEnum.ui_quest_completed, FindClip("ui_quest_completed"));
		_allClips.Add(SoundTypeEnum.ui_title_fill, FindClip("ui_title_fill"));
		_allClips.Add(SoundTypeEnum.ui_title_fully_fill, FindClip("ui_title_fully_fill"));
		_allClips.Add(SoundTypeEnum.ui_toast_pop, FindClip("ui_toast_pop"));
		_allClips.Add(SoundTypeEnum.ui_tutorial_pop, FindClip("ui_tutorial_pop"));
		_allClips.Add(SoundTypeEnum.ui_test, FindClip("ui_test"));
		_allClips.Add(SoundTypeEnum.ba_build, FindClip("ba_build"));
		_allClips.Add(SoundTypeEnum.ba_clogged, FindClip("ba_clogged"));
		_allClips.Add(SoundTypeEnum.ba_destroy_building_m, FindClip("ba_destroy_building_m"));
		_allClips.Add(SoundTypeEnum.ba_destroy_building_s, FindClip("ba_destroy_building_s"));
		_allClips.Add(SoundTypeEnum.ba_garbage_output, FindClip("ba_garbage_output"));
		_allClips.Add(SoundTypeEnum.ba_minigame_click, FindClip("ba_minigame_click"));
		_allClips.Add(SoundTypeEnum.ba_minigame_success, FindClip("ba_minigame_success"));
		_allClips.Add(SoundTypeEnum.ba_upgrade, FindClip("ba_upgrade"));
		_allClips.Add(SoundTypeEnum.ba_worker_add, FindClip("ui_button1_click"));
		_allClips.Add(SoundTypeEnum.ba_worker_remove, FindClip("ui_button1_click"));
		_allClips.Add(SoundTypeEnum.bs_balloon_moving, FindClip("bs_balloon_moving"));
		_allClips.Add(SoundTypeEnum.bs_balloon_working, FindClip("bs_balloon_working"));
		_allClips.Add(SoundTypeEnum.bs_balloon_drop, FindClip("bs_balloon_drop"));
		_allClips.Add(SoundTypeEnum.bs_cannon, FindClip("bs_cannon"));
		_allClips.Add(SoundTypeEnum.bs_catapult, FindClip("bs_catapult"));
		_allClips.Add(SoundTypeEnum.bs_compress, FindClip("bs_compress"));
		_allClips.Add(SoundTypeEnum.bs_drone_moving, FindClip("bs_drone_moving"));
		_allClips.Add(SoundTypeEnum.bs_drone_working, FindClip("bs_drone_working"));
		_allClips.Add(SoundTypeEnum.bs_factory_working, FindClip("bs_factory_working"));
		_allClips.Add(SoundTypeEnum.bs_fan_on, FindClip("bs_fan_on"));
		_allClips.Add(SoundTypeEnum.bs_gain_rp, FindClip("bs_gain_rp"));
		_allClips.Add(SoundTypeEnum.bs_helicopter, FindClip("bs_helicopter"));
		_allClips.Add(SoundTypeEnum.bs_helicopter_drop, FindClip("bs_helicopter_drop"));
		_allClips.Add(SoundTypeEnum.bs_minigunn, FindClip("bs_minigunn"));
		_allClips.Add(SoundTypeEnum.bs_portal, FindClip("bs_portal"));
		_allClips.Add(SoundTypeEnum.bs_portal_lazer, FindClip("bs_portal_lazer"));
		_allClips.Add(SoundTypeEnum.bs_power_pulse, FindClip("bs_power_pulse"));
		_allClips.Add(SoundTypeEnum.bs_rock_destroy, FindClip("bs_rock_destroy"));
		_allClips.Add(SoundTypeEnum.bs_rock_hit, FindClip("bs_rock_hit"));
		_allClips.Add(SoundTypeEnum.bs_temple_praying, FindClip("bs_temple_praying"));
		_allClips.Add(SoundTypeEnum.bs_zap, FindClip("bs_zap"));
		_allClips.Add(SoundTypeEnum.en_lazer_destroy, FindClip("en_lazer_destroy"));
		_allClips.Add(SoundTypeEnum.en_lazer_hit, FindClip("en_lazer_hit"));
		_allClips.Add(SoundTypeEnum.en_lazer_prepare, FindClip("en_lazer_prepare"));
		_allClips.Add(SoundTypeEnum.en_monster_appear, FindClip("en_monster_appear"));
		_allClips.Add(SoundTypeEnum.en_peon_happy, FindClip("en_peon_happy"));
		_allClips.Add(SoundTypeEnum.en_peon_walk, FindClip("en_peon_walk"));
		_allClips.Add(SoundTypeEnum.en_question_pop, FindClip("en_question_pop"));
		_allClips.Add(SoundTypeEnum.en_show_statue, FindClip("en_show_statue"));
		_allClips.Add(SoundTypeEnum.ga_airplane, FindClip("ga_airplane"));
		_allClips.Add(SoundTypeEnum.ga_book_appear, FindClip("ga_book_appear"));
		_allClips.Add(SoundTypeEnum.ga_buildingfocus_off, FindClip("ga_buildingfocus_off"));
		_allClips.Add(SoundTypeEnum.ga_buildingfocus_on, FindClip("ga_buildingfocus_on"));
		_allClips.Add(SoundTypeEnum.ga_bulldozer, FindClip("ga_bulldozer"));
		_allClips.Add(SoundTypeEnum.ga_cloud_click, FindClip("ga_cloud_click"));
		_allClips.Add(SoundTypeEnum.ga_cloud_destroy, FindClip("ga_cloud_destroy"));
		_allClips.Add(SoundTypeEnum.ga_earthquake, FindClip("ga_earthquake"));
		_allClips.Add(SoundTypeEnum.ga_gain_money, FindClip("ga_gain_money"));
		_allClips.Add(SoundTypeEnum.ga_garbage_hit, FindClip("ga_garbage_hit"));
		_allClips.Add(SoundTypeEnum.ga_garbage_passing, FindClip("ga_garbage_passing"));
		_allClips.Add(SoundTypeEnum.ga_grab_peon, FindClip("ga_grab_peon"));
		_allClips.Add(SoundTypeEnum.ga_new_peon, FindClip("ga_new_peon"));
		_allClips.Add(SoundTypeEnum.ga_peon_getsad, FindClip("ga_peon_getsad"));
		_allClips.Add(SoundTypeEnum.ga_shard_appear, FindClip("ga_shard_appear"));
		_allClips.Add(SoundTypeEnum.ga_shard_red_appear, FindClip("ga_shard_red_appear"));
		_allClips.Add(SoundTypeEnum.ga_throw_garbage, FindClip("ga_throw_garbage"));
		_allClips.Add(SoundTypeEnum.ga_throw_peon, FindClip("ga_throw_peon"));
		_allClips.Add(SoundTypeEnum.ga_recall, FindClip("ga_recall"));
		_allClips.Add(SoundTypeEnum.ga_signing, FindClip("ga_signing"));
		_allClips.Add(SoundTypeEnum.ga_minion, FindClip("ga_minion"));
		_allClips.Add(SoundTypeEnum.ga_golem_hit, FindClip("ga_golem_hit"));
		_allClips.Add(SoundTypeEnum.ga_golem_walk, FindClip("ga_golem_walk"));
		_allClips.Add(SoundTypeEnum.mu_beginning, FindClip("mu_beginning"));
		_allClips.Add(SoundTypeEnum.mu_earthquake_ready, FindClip("mu_earthquake_ready"));
		_allClips.Add(SoundTypeEnum.mu_ending, FindClip("mu_ending"));
		_allClips.Add(SoundTypeEnum.mu_en_animation, FindClip("mu_en_animation"));
		_allClips.Add(SoundTypeEnum.mu_ingame_menu, FindClip("mu_ingame_menu"));
		_allClips.Add(SoundTypeEnum.mu_intro, FindClip("mu_intro"));
		_allClips.Add(SoundTypeEnum.mu_v2_ingame1, FindClip("mu_v2_ingame1"));
		_allClips.Add(SoundTypeEnum.mu_v2_ingame2, FindClip("mu_v2_ingame2"));
		_allClips.Add(SoundTypeEnum.mu_v2_ingame3, FindClip("mu_v2_ingame3"));
		_allClips.Add(SoundTypeEnum.mu_v2_ingame4, FindClip("mu_v2_ingame4"));
		_allClips.Add(SoundTypeEnum.mu_v2_ingame5, FindClip("mu_v2_ingame5"));
		_allClips.Add(SoundTypeEnum.mu_v2_ingame6, FindClip("mu_v2_ingame6"));
		_allClips.Add(SoundTypeEnum.mu_v2_ingame7, FindClip("mu_v2_ingame7"));
		_allClips.Add(SoundTypeEnum.mu_v2_ingame8, FindClip("mu_v2_ingame8"));
		_allClips.Add(SoundTypeEnum.mu_v2_ingame9, FindClip("mu_v2_ingame9"));
		_allClips.Add(SoundTypeEnum.mu_looking_at_statue, FindClip("mu_looking_at_statue"));
	}

	public void PlayClip(AudioSource source, SoundTypeEnum clip, float zoom, float distance)
	{
		if (_allClips[clip] != null)
		{
			SetVolumeByDistance(source, zoom, distance);
			distance = Mathf.Abs(distance);
			if (!(distance > _maxDistance) && !(zoom > _maxZoom))
			{
				source.PlayOneShot(_allClips[clip]);
			}
		}
	}

	public void SetVolumeByDistance(AudioSource source, float zoom, float distance)
	{
		distance = Mathf.Abs(distance);
		if (distance > _maxDistance || zoom > _maxZoom)
		{
			source.volume = 0f;
			return;
		}
		float num = Mathf.InverseLerp(_maxZoom, _minZoom, zoom);
		float num2 = Mathf.Clamp01(1f - distance / _maxDistance);
		float t = num * num2;
		float volume = Mathf.Lerp(_minVolume, _maxVolume, t);
		source.volume = volume;
	}

	public void PlayClip(AudioSource source, SoundTypeEnum clip)
	{
		if (_allClips[clip] != null)
		{
			source.volume = 1f;
			source.pitch = 1f;
			source.PlayOneShot(_allClips[clip]);
		}
	}

	public void PlayClipWithPitch(AudioSource source, SoundTypeEnum clip)
	{
		if (_allClips[clip] != null)
		{
			source.volume = 1f;
			source.pitch = Random.Range(0.9f, 1.1f);
			source.PlayOneShot(_allClips[clip]);
		}
	}

	public void PlayLoopWithFade(AudioSource source, SoundTypeEnum clip)
	{
		if (_allClips[clip] != null)
		{
			if (_fading != null && _fading.active)
			{
				_fading.Kill();
			}
			source.Stop();
			source.clip = _allClips[clip];
			source.volume = 0f;
			source.pitch = 1f;
			source.loop = true;
			source.Play();
			_fading = source.DOFade(1f, 5f);
		}
	}

	public void PlayWithFade(AudioSource source, SoundTypeEnum clip)
	{
		if (_allClips[clip] != null)
		{
			if (_fading != null && _fading.active)
			{
				_fading.Kill();
			}
			source.Stop();
			source.clip = _allClips[clip];
			source.volume = 1f;
			source.pitch = 1f;
			source.loop = false;
			source.Play();
		}
	}

	public void PlayLoop(AudioSource source, SoundTypeEnum clip)
	{
		if (_allClips[clip] != null)
		{
			source.Stop();
			source.clip = _allClips[clip];
			source.volume = 1f;
			source.pitch = 1f;
			source.loop = true;
			source.Play();
		}
	}

	public void PutInBackground(AudioSource source)
	{
		if (_fading != null && _fading.active)
		{
			_fading.Kill();
		}
		source.volume = 0.05f;
	}

	public void PutInForeground(AudioSource source)
	{
		if (_fading != null && _fading.active)
		{
			_fading.Kill();
		}
		source.volume = 1f;
	}

	private AudioClip FindClip(string clipName)
	{
		AudioClip audioClip = null;
		audioClip = Resources.Load<AudioClip>("Audio/" + clipName);
		if (audioClip == null)
		{
			if (clipName.StartsWith("ui_"))
			{
				clipName = clipName.Remove(0, 2);
			}
			if (clipName.StartsWith("ba_"))
			{
				clipName = clipName.Remove(0, 2);
			}
			if (clipName.StartsWith("bs_"))
			{
				clipName = clipName.Remove(0, 2);
			}
			if (clipName.StartsWith("en_"))
			{
				clipName = clipName.Remove(0, 2);
			}
			if (clipName.StartsWith("ga_"))
			{
				clipName = clipName.Remove(0, 2);
			}
			if (clipName.StartsWith("mu_"))
			{
				clipName = clipName.Remove(0, 2);
			}
			audioClip = Resources.Load<AudioClip>("Audio/" + clipName);
		}
		return audioClip;
	}
}
