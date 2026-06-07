using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Stages
{
	[Serializable]
	public class DirecterManager
	{
		private Background6 _background6;

		private Stage _stage;

		private int _currentPhase;

		private float _combatTimer;

		private List<Tween> _bgmTimers;

		private Tween _timer0;

		private bool _quickDebug;

		private bool _startedPhase2;

		private bool _startedPhase4;

		private bool _startedPhase3;

		private bool _startedPhase5;

		private AudioSource _currentBgm;

		private float _volume;

		private DirecterAudioManager _directerAudioManager;

		private List<List<float>> _delays;

		private List<BgmType> _soundKeys;

		private const float ThresholdPhase1 = 30.000002f;

		private const float ThresholdPhase2 = 60.000004f;

		private const float ThresholdPhase3 = 60.000004f;

		private const float ThresholdPhase4 = 45.000004f;

		private const float _soundTweenDuration = 0.85f;

		public DirecterManager(Background6 background6)
		{
		}

		public void Update(float deltaTime)
		{
		}

		private static void ResetPlayersGrowth()
		{
		}

		private void ResetMasks()
		{
		}

		public void Cleanup()
		{
		}

		public void StartPhase0()
		{
		}

		private void OnOnlineStageSwitch(OnlineSignals.OnDirecterStageSwitch newPhase)
		{
		}

		private Tween SetTimeout(float delay, TweenCallback callback)
		{
			return null;
		}

		private void CheckTime1(int soundPhase, int phaseSwitch, bool fadeIn = true)
		{
		}

		private static void DestroySound(AudioSource sound1)
		{
		}

		private void PerformChangePhase(int soundPhase, int phaseSwitch)
		{
		}

		private void RemoveTimers()
		{
		}

		private void ChangePhase()
		{
		}

		private void StartPhase1()
		{
		}

		private void StartPhase2()
		{
		}

		private void SetParticlesVelocity(ParticleSystem ps, float yVel)
		{
		}

		private void StartPhase3()
		{
		}

		private void StartPhase4()
		{
		}

		private void StartPhase5()
		{
		}
	}
}
