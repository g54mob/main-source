using System;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Settings;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore
{
	internal sealed class DirectEffectPlayer : IEffectPlayer, ITagProvider, IDisposable, IParameterUpdater
	{
		private readonly IEffectStateSync state;

		private readonly StateCategory category;

		private float duration;

		private bool isUpPositive;

		private GlobalSettingsBase globalSettings;

		public string TagID { get; private set; }

		public DirectEffectPlayer(string tagID, IEffectStateSync state, StateCategory category)
		{
			TagID = tagID;
			this.state = state;
			this.category = category;
			duration = state?.GetDefaultDuration() ?? ((category == StateCategory.Behavior) ? float.PositiveInfinity : 1f);
		}

		public void InitializeOnce(bool isUpPositive, GlobalSettingsBase globalSettings)
		{
			this.isUpPositive = isUpPositive;
			this.globalSettings = globalSettings;
		}

		public float GetTotalDuration()
		{
			return duration;
		}

		public void Animate(ref CharacterData characterData, in AnimationContext animationContext)
		{
			if (!(characterData.visibleTime <= 0f))
			{
				DirectEffectContext context = new DirectEffectContext(1f, animationContext.deltaTime, animationContext.timeSinceStart, isUpPositive);
				state.Apply(ref characterData, in context);
			}
		}

		public void UpdateParameters(RegionParameters parameters)
		{
			state.UpdateParameters(parameters);
		}

		public void Refresh()
		{
			InitializeOnce(isUpPositive, globalSettings);
		}

		public void Dispose()
		{
		}

		void IEffectPlayer.Animate(ref CharacterData characterData, in AnimationContext animationContext)
		{
			Animate(ref characterData, in animationContext);
		}
	}
}
