using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new ShearAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Shear")]
	public class ShearAnimation : TMPAnimation
	{
		[AutoParametersStorage]
		private class AnimData
		{
			public Wave wave;

			public OffsetBundle offset;
		}

		[Tooltip("The wave that defines the behavior of this animation. No prefix.\nFor more information about it, see the section on Waves in the documentation.")]
		[AutoParameterBundle("")]
		[SerializeField]
		private Wave wave;

		[Tooltip("The timing offsets used by this animation. No prefix.\nFor more information about it, see the section on OffsetProviders in the documentation.")]
		[AutoParameterBundle("")]
		[SerializeField]
		private OffsetBundle offset;

		private void Animate(CharData cData, AnimData data, IAnimationContext context)
		{
			float item = data.wave.Evaluate(context.AnimatorContext.PassedTime, data.offset.GetOffset(cData, context)).Value;
			item -= data.wave.Amplitude / 2f;
			cData.mesh.BL_Position = cData.InitialMesh.BL_Position + Vector3.right * item;
			cData.mesh.BR_Position = cData.InitialMesh.BR_Position + Vector3.right * item;
			cData.mesh.TL_Position = cData.InitialMesh.TL_Position - Vector3.right * item;
			cData.mesh.TR_Position = cData.InitialMesh.TR_Position - Vector3.right * item;
		}

		public override void Animate(CharData cData, IAnimationContext context)
		{
			AnimData data = context.CustomData as AnimData;
			Animate(cData, data, context);
		}

		public override object GetNewCustomData()
		{
			return new AnimData
			{
				wave = wave,
				offset = offset
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				AnimData obj = (AnimData)customData;
				obj.wave = Wave.CreateWave(obj.wave, Wave.GetWaveParameters(parameters, keywordDatabase));
				obj.offset = OffsetBundle.CreateOffsetBundle(obj.offset, OffsetBundle.GetOffsetBundleParameters(parameters, keywordDatabase));
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return true;
			}
			if (!Wave.ValidateWaveParameters(parameters, keywordDatabase))
			{
				return false;
			}
			if (!OffsetBundle.ValidateOffsetBundleParameters(parameters, keywordDatabase))
			{
				return false;
			}
			return true;
		}
	}
}
