using System;
using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.CharacterModelSystem;
using Timberborn.Common;

namespace Timberborn.Wandering
{
	internal class VariedIdleAnimation : BaseComponent, IAwakableComponent
	{
		private readonly IRandomNumberGenerator _randomNumberGenerator;

		private VariedIdleAnimationSpec _variedIdleAnimationSpec;

		private CharacterAnimator _characterAnimator;

		public VariedIdleAnimation(IRandomNumberGenerator randomNumberGenerator)
		{
			_randomNumberGenerator = randomNumberGenerator;
		}

		public void Awake()
		{
			_variedIdleAnimationSpec = GetComponent<VariedIdleAnimationSpec>();
			_characterAnimator = GetComponent<CharacterAnimator>();
			GetComponent<WanderRootBehavior>().IdleStarted += OnIdleStarted;
		}

		private void OnIdleStarted(object sender, EventArgs e)
		{
			ImmutableArray<string> variants = _variedIdleAnimationSpec.Variants;
			ImmutableArray<string>.Enumerator enumerator = variants.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				_characterAnimator.SetBool(current, value: false);
			}
			int num = _randomNumberGenerator.Range(0, variants.Length + 1);
			if (num < variants.Length)
			{
				_characterAnimator.SetBool(variants[num], value: true);
			}
		}
	}
}
