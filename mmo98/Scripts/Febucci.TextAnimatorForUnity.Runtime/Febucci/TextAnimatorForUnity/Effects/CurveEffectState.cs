using System;
using Febucci.Numbers;
using Febucci.Parsing;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.Text;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	internal struct CurveEffectState : IEffectState, IParameterUpdater
	{
		private bool isRotationEnabled;

		private bool isMovementEnabled;

		private bool isScaleEnabled;

		private bool isColorEnabled;

		private CurveEffectParameters current;

		private readonly CurveEffectParameters defaultData;

		public CurveEffectState(CurveEffectParameters defaultData)
		{
			this.defaultData = defaultData;
			current = defaultData;
			isColorEnabled = defaultData.color != null && defaultData.color.IsValid();
			isMovementEnabled = defaultData.position != null && defaultData.position.IsValid();
			isRotationEnabled = defaultData.rotation != null && defaultData.rotation.IsValid();
			isScaleEnabled = defaultData.scale != null && defaultData.scale.IsValid();
		}

		public void UpdateParameters(RegionParameters parameters)
		{
		}

		public void Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			float pct = (context.isInsideBehavior ? context.progression01 : context.intensity);
			float num = (context.isInsideBehavior ? context.intensity : 1f);
			float num2 = (context.isInsideBehavior ? 1f : context.progressionRange);
			if (isRotationEnabled)
			{
				character.RotateDegrees(current.rotation.Sample(pct).z * num * num2, context.isUpPositive);
			}
			if (isMovementEnabled)
			{
				character.MovePosition(current.position.Sample(pct) * num * num2, context.isUpPositive);
			}
			if (isScaleEnabled)
			{
				character.Scale(current.scale.SampleScale(pct, num) * num2);
			}
			if (!isColorEnabled)
			{
				return;
			}
			switch (current.color.mode)
			{
			case ColorMode.Multiply:
			{
				for (int i = 0; i < 4; i++)
				{
					character.current.colors[i] = Febucci.Numbers.Color32.LerpUnclamped(character.current.colors[i], (UnityEngine.Color32)character.current.colors[i] * current.color.Sample(pct), num);
				}
				break;
			}
			case ColorMode.SetColor:
				character.LerpColor(current.color.Sample(pct), num);
				break;
			}
		}

		void IEffectState.Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			Apply(ref character, in context);
		}
	}
}
