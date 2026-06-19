using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new FunkyAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Funky")]
	public class FunkyAnimation : TMPAnimation
	{
		private class AutoParametersData
		{
			public float speed;

			public float squeezeFactor;

			public float amplitude;
		}

		[SerializeField]
		[AutoParameter("speed", new string[] { "sp", "s" })]
		[Tooltip("The speed at which the animation plays.\nAliases: speed, sp, s")]
		private float speed;

		[SerializeField]
		[AutoParameter("squeezefactor", new string[] { "squeeze", "sqz" })]
		[Tooltip("The percentage of its original size the text is squeezed to.\nAliases: squeezefactor, squeeze, sqz")]
		private float squeezeFactor;

		[SerializeField]
		[AutoParameter("amplitude", new string[] { "amp" })]
		[Tooltip("The amplitude the text pushes to the left / right.\nAliases: amplitude, amp")]
		private float amplitude;

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			float num = Mathf.Sin(context.AnimatorContext.PassedTime * data.speed) / 2f + 0.5f;
			bool num2 = Mathf.Cos(context.AnimatorContext.PassedTime * data.speed) > 0f;
			Vector3 vector = cData.InitialMesh.TL_Position - cData.mesh.initial.BL_Position;
			Vector3 vector2 = cData.InitialMesh.TR_Position - cData.mesh.initial.BR_Position;
			Vector3 position = cData.mesh.initial.GetPosition(0);
			Vector3 position2 = cData.mesh.initial.GetPosition(3);
			position = TMPAnimationUtility.GetRawVertex(1, position + vector * data.squeezeFactor, cData, context);
			position2 = TMPAnimationUtility.GetRawVertex(2, position2 + vector2 * data.squeezeFactor, cData, context);
			Vector3 position3 = cData.mesh.initial.GetPosition(1);
			Vector3 position4 = cData.mesh.initial.GetPosition(2);
			position3 = TMPAnimationUtility.GetRawVertex(1, position3, cData, context) + Vector3.left * data.amplitude;
			position4 = TMPAnimationUtility.GetRawVertex(2, position4, cData, context) + Vector3.left * data.amplitude;
			Vector3 position5 = cData.mesh.initial.GetPosition(1);
			Vector3 position6 = cData.mesh.initial.GetPosition(2);
			position5 = TMPAnimationUtility.GetRawVertex(1, position5, cData, context) + Vector3.right * data.amplitude;
			position6 = TMPAnimationUtility.GetRawVertex(2, position6, cData, context) + Vector3.right * data.amplitude;
			Vector3 position7 = cData.mesh.initial.GetPosition(1);
			Vector3 position8 = cData.mesh.initial.GetPosition(2);
			if (num2)
			{
				if ((double)num <= 0.9)
				{
					position8 = Vector3.Lerp(position4, position2, num / 0.9f);
					position7 = Vector3.Lerp(position3, position, num / 0.9f);
				}
				else
				{
					position7 = Vector3.Lerp(position, position5, (num - 0.9f) / 0.1f);
					position8 = Vector3.Lerp(position2, position6, (num - 0.9f) / 0.1f);
				}
			}
			else if ((double)num >= 0.1)
			{
				position7 = Vector3.Lerp(position, position5, (num - 0.1f) / 0.9f);
				position8 = Vector3.Lerp(position2, position6, (num - 0.1f) / 0.9f);
			}
			else
			{
				position7 = Vector3.Lerp(position3, position, num / 0.1f);
				position8 = Vector3.Lerp(position4, position2, num / 0.1f);
			}
			cData.mesh.SetPosition(1, position7);
			cData.mesh.SetPosition(2, position8);
		}

		public override void Animate(CharData cData, IAnimationContext context)
		{
			AutoParametersData data = context.CustomData as AutoParametersData;
			Animate(cData, data, context);
		}

		public override object GetNewCustomData()
		{
			return new AutoParametersData
			{
				speed = speed,
				squeezeFactor = squeezeFactor,
				amplitude = amplitude
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				AutoParametersData autoParametersData = (AutoParametersData)customData;
				if (TMPParameterUtility.TryGetFloatParameter(out var value, parameters, keywordDatabase, "speed", "sp", "s"))
				{
					autoParametersData.speed = value;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value2, parameters, keywordDatabase, "squeezefactor", "squeeze", "sqz"))
				{
					autoParametersData.squeezeFactor = value2;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value3, parameters, keywordDatabase, "amplitude", "amp"))
				{
					autoParametersData.amplitude = value3;
				}
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return true;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "speed", "sp", "s"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "squeezefactor", "squeeze", "sqz"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "amplitude", "amp"))
			{
				return false;
			}
			return true;
		}
	}
}
