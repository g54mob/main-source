using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.BuiltIn;
using Febucci.TextAnimatorCore.Settings;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore
{
	public abstract class ManagedEffectPlayerBase : IEffectPlayer, ITagProvider, IDisposable
	{
		private bool hasBeenInitialized;

		private static readonly IEffectPlayback FallbackPlayback = default(SimplePlayback);

		private static readonly IEffectPhase FallbackPhase = default(DefaultPhase);

		protected readonly IEffectManaged preset;

		protected readonly IEffectContent content;

		protected bool isValidEffect;

		protected bool isUpPositive;

		protected EffectPresetSettings effectSettings;

		protected IEffectPlayback playback;

		protected IEffectPhase phase;

		protected IEffectCurve stateCurve;

		protected IEffectState transformState;

		private GlobalSettingsBase globalSettings;

		private readonly RegionParameters parameters;

		protected float duration;

		private Dictionary<IEffectCurve, BakedCurve> bakedCurves;

		public string TagID { get; private set; }

		protected ManagedEffectPlayerBase(string tagId, IEffectManaged preset, IEffectContent content, RegionParameters parameters)
		{
			TagID = tagId;
			this.preset = preset;
			this.content = content;
			hasBeenInitialized = false;
			this.parameters = parameters;
			preset.OnValueChanged += Refresh;
		}

		public void Refresh()
		{
			isValidEffect = false;
			hasBeenInitialized = false;
			InitializeOnce(isUpPositive, globalSettings);
		}

		private BakedCurve? GetOrCreateBakedCurve(IEffectCurve original)
		{
			if (original == null)
			{
				return null;
			}
			if (bakedCurves == null)
			{
				bakedCurves = new Dictionary<IEffectCurve, BakedCurve>();
			}
			if (bakedCurves.TryGetValue(original, out var value))
			{
				value.Bake();
				return value;
			}
			BakedCurve value2 = new BakedCurve(original);
			value2.Bake();
			bakedCurves.Add(original, value2);
			return value2;
		}

		public void InitializeOnce(bool isUpPositive, GlobalSettingsBase globalSettings)
		{
			isValidEffect = false;
			if (hasBeenInitialized && this.globalSettings == globalSettings)
			{
				return;
			}
			hasBeenInitialized = true;
			this.globalSettings = globalSettings;
			effectSettings = preset.Settings;
			playback = content.Playback;
			stateCurve = content.StateCurve;
			if (globalSettings != null)
			{
				if (parameters.keywordsCount > 0)
				{
					Dictionary<string, IEffectPlayback> dictionary = globalSettings.GlobalPlaybacksDatabase?.Database;
					if (dictionary != null)
					{
						foreach (string keyword in parameters.keywords)
						{
							if (dictionary.TryGetValue(keyword, out playback))
							{
								break;
							}
						}
					}
				}
				if (playback == null)
				{
					playback = globalSettings.FallbackPlayback;
				}
				if (stateCurve == null)
				{
					stateCurve = globalSettings.FallbackStateCurve;
				}
			}
			if (playback == null || stateCurve == null || preset == null)
			{
				return;
			}
			if (effectSettings.bakeCurves && stateCurve.BakeResolution > 0)
			{
				stateCurve = GetOrCreateBakedCurve(stateCurve);
			}
			try
			{
				preset.Initialize();
				playback.Initialize();
				stateCurve?.Initialize();
				phase = content.CreatePhase();
				phase.UpdateParameters(parameters);
				transformState = content.CreateState();
				transformState.UpdateParameters(parameters);
				float maxSpeed = phase.MaxSpeed;
				duration = playback.GetTotalDuration();
				if (maxSpeed < 1f)
				{
					duration *= 1f / maxSpeed;
				}
			}
			catch (Exception arg)
			{
				Logger.LogWarning($"Unable to initialize preset: {GetType()}. Skipping. Reason: {arg}");
				return;
			}
			this.isUpPositive = isUpPositive;
			isValidEffect = true;
		}

		public float GetTotalDuration()
		{
			if (!isValidEffect)
			{
				return 0f;
			}
			return duration;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected static float NormalizeTimeForCurve(float time)
		{
			return time - MathF.Floor(time);
		}

		public abstract void Animate(ref CharacterData characterData, in AnimationContext animationContext);

		public void Dispose()
		{
			if (preset != null)
			{
				preset.OnValueChanged -= Refresh;
			}
		}
	}
}
