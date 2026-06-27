using System;
using System.Collections.Generic;
using DG.Tweening;
using FMODUnity;
using Restory.Audio;
using Restory.Gameplay.Equipment.TableLamps;
using Restory.Utils;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay
{
	public class LightEffectsService : MonoBehaviour, IDisposable
	{
		private LightTimeService lightTimeService;

		private TweenSequencesService tweenSequencesService;

		private IAudioPlayerService audioPlayer;

		private TableLamp tableLamp;

		private Sequence powerSurgeSequence;

		[SerializeField]
		[Min(1f)]
		private int powerSurgeFlickerCount = 5;

		[SerializeField]
		[Min(0f)]
		private float powerSurgeFlickerDuration = 0.15f;

		[SerializeField]
		private EventReference powerSurgeSoundEvent;

		[Inject]
		public void Construct(LightTimeService lightTimeService, TweenSequencesService tweenSequencesService, IAudioPlayerService audioPlayer, TableLamp tableLamp)
		{
			this.lightTimeService = lightTimeService;
			this.tweenSequencesService = tweenSequencesService;
			this.audioPlayer = audioPlayer;
			this.tableLamp = tableLamp;
		}

		public void Dispose()
		{
			if (powerSurgeSequence != null && powerSurgeSequence.IsActive())
			{
				tweenSequencesService.Kill(powerSurgeSequence);
			}
		}

		public void PlayPowerSurgeEffect()
		{
			if (powerSurgeSequence != null && powerSurgeSequence.IsActive())
			{
				tweenSequencesService.Kill(powerSurgeSequence);
			}
			if (!powerSurgeSoundEvent.IsNull)
			{
				audioPlayer.PlaySoundEventOneShot(powerSurgeSoundEvent, base.gameObject);
			}
			List<LightTimeView> allLights = CollectionPool<List<LightTimeView>, LightTimeView>.Get();
			allLights.AddRange(lightTimeService.AmbientLightTimeView);
			allLights.AddRange(lightTimeService.TableLampLightTimeView);
			allLights.Add(lightTimeService.DeviceSpotLightTimeView);
			bool lastIsOn = tableLamp.IsOn;
			float startIntensityModifier = (lastIsOn ? 1f : 0f);
			float endIntensityModifier = (lastIsOn ? 0f : 1f);
			powerSurgeSequence = tweenSequencesService.Create();
			powerSurgeSequence.OnStart(delegate
			{
				tableLamp.IsOn = true;
				foreach (LightTimeView item in allLights)
				{
					item.SetIntensityModifier(startIntensityModifier);
				}
			});
			for (int num = 0; num < powerSurgeFlickerCount; num++)
			{
				bool flag = true;
				foreach (LightTimeView light in allLights)
				{
					Tween t = tweenSequencesService.FloatTo(() => startIntensityModifier, delegate(float modifier)
					{
						light.SetIntensityModifier(modifier);
					}, endIntensityModifier, powerSurgeFlickerDuration * 0.5f);
					if (flag)
					{
						powerSurgeSequence.Append(t);
						flag = false;
					}
					else
					{
						powerSurgeSequence.Join(t);
					}
				}
				flag = true;
				foreach (LightTimeView light2 in allLights)
				{
					Tween t2 = tweenSequencesService.FloatTo(() => endIntensityModifier, delegate(float modifier)
					{
						light2.SetIntensityModifier(modifier);
					}, startIntensityModifier, powerSurgeFlickerDuration * 0.5f);
					if (flag)
					{
						powerSurgeSequence.Append(t2);
						flag = false;
					}
					else
					{
						powerSurgeSequence.Join(t2);
					}
				}
			}
			powerSurgeSequence.OnKill(delegate
			{
				foreach (LightTimeView item2 in allLights)
				{
					item2.SetIntensityModifier(startIntensityModifier);
				}
				tableLamp.IsOn = lastIsOn;
				CollectionPool<List<LightTimeView>, LightTimeView>.Release(allLights);
			});
		}
	}
}
