using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new SketchyAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Sketchy")]
	public class SketchyAnimation : TMPAnimation
	{
		[AutoParametersStorage]
		private class AnimData
		{
			public Dictionary<int, ModData> modDatas = new Dictionary<int, ModData>();

			public Dictionary<int, float> lastUpdate = new Dictionary<int, float>();

			public float delayTime;

			public Vector3 minOffset;

			public Vector3 maxOffset;

			public Vector3 minRotation;

			public Vector3 maxRotation;

			public Vector3 minScale;

			public Vector3 maxScale;

			public Vector3 minColorShift;

			public Vector3 maxColorShift;
		}

		private struct ModData
		{
			public Vector3 rotation;

			public Vector3 scale;

			public Vector3 offset;

			public Vector3 colorshift;
		}

		[AutoParameter("delay", new string[] { "d" })]
		[SerializeField]
		[Tooltip("The delay between each change, in seconds.\nAliases: delay, d")]
		private float delayTime;

		[AutoParameter("minoffset", new string[] { "minoff" })]
		[SerializeField]
		[Tooltip("The min offset from the original position.\nAliases: minoffset, minoff")]
		private Vector3 minOffset;

		[AutoParameter("maxoffset", new string[] { "maxoff" })]
		[SerializeField]
		[Tooltip("The max offset from the original position.\nAliases: maxoffset, maxoff")]
		private Vector3 maxOffset;

		[AutoParameter("minrotation", new string[] { "minrot" })]
		[SerializeField]
		[Tooltip("The min rotation, in euler angles.\nAliases: minrotation, minrot")]
		private Vector3 minRotation;

		[AutoParameter("maxrotation", new string[] { "maxrot" })]
		[SerializeField]
		[Tooltip("The max rotation, in euler angles.\nAliases: maxrotation, maxrot")]
		private Vector3 maxRotation;

		[AutoParameter("minscale", new string[] { "minscl" })]
		[SerializeField]
		[Tooltip("The min scale.\nAliases: minscale, minscl")]
		private Vector3 minScale;

		[AutoParameter("maxscale", new string[] { "maxscl" })]
		[SerializeField]
		[Tooltip("The max scale.\nAliases: maxscale, maxscl")]
		private Vector3 maxScale;

		[AutoParameter("mincolorshift", new string[] { "minclrshift", "minclr" })]
		[SerializeField]
		[Tooltip("The min color shift, RGB.\nAliases: mincolorshift, minclrshift, minclr")]
		private Vector3 minColorShift;

		[AutoParameter("maxcolorshift", new string[] { "maxclrshift", "maxclr" })]
		[SerializeField]
		[Tooltip("The max color shift, RGB.\nAliases: maxcolorshift, maxclrshift, maxclr")]
		private Vector3 maxColorShift;

		private void Animate(CharData cData, AnimData data, IAnimationContext context)
		{
			if (!data.lastUpdate.TryGetValue(cData.info.index, out var value) || context.AnimatorContext.PassedTime - value > data.delayTime || !data.modDatas.TryGetValue(cData.info.index, out var value2))
			{
				value2 = new ModData
				{
					rotation = new Vector3(Random.Range(data.minRotation.x, data.maxRotation.x), Random.Range(data.minRotation.y, data.maxRotation.y), Random.Range(data.minRotation.z, data.maxRotation.z)),
					scale = new Vector3(Random.Range(data.minScale.x, data.maxScale.x), Random.Range(data.minScale.y, data.maxScale.y), Random.Range(data.minScale.z, data.maxScale.z)),
					offset = new Vector3(Random.Range(data.minOffset.x, data.maxOffset.x), Random.Range(data.minOffset.y, data.maxOffset.y), Random.Range(data.minOffset.z, data.maxOffset.z)),
					colorshift = new Vector3(Random.Range(data.minColorShift.x, data.maxColorShift.x), Random.Range(data.minColorShift.y, data.maxColorShift.y), Random.Range(data.minColorShift.z, data.maxColorShift.z))
				};
				data.modDatas[cData.info.index] = value2;
				data.lastUpdate[cData.info.index] = context.AnimatorContext.PassedTime;
			}
			if (value2.offset != Vector3.zero)
			{
				cData.SetPosition(cData.InitialPosition + value2.offset);
			}
			if (value2.scale != Vector3.one)
			{
				cData.SetScale(value2.scale);
			}
			if (value2.rotation != Vector3.zero)
			{
				cData.AddRotation(value2.rotation, cData.InitialPosition);
			}
			if (value2.colorshift != Vector3.zero)
			{
				context.AnimatorContext.Modifiers.CalculateVertexColors(cData, context.AnimatorContext);
				for (int i = 0; i < 4; i++)
				{
					Color color = context.AnimatorContext.Modifiers.VertexColor(i);
					color.r += value2.colorshift.x;
					color.g += value2.colorshift.y;
					color.b += value2.colorshift.z;
					cData.mesh.SetColor(i, color);
				}
			}
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
				delayTime = delayTime,
				minOffset = minOffset,
				maxOffset = maxOffset,
				minRotation = minRotation,
				maxRotation = maxRotation,
				minScale = minScale,
				maxScale = maxScale,
				minColorShift = minColorShift,
				maxColorShift = maxColorShift
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				AnimData animData = (AnimData)customData;
				if (TMPParameterUtility.TryGetFloatParameter(out var value, parameters, keywordDatabase, "delay", "d"))
				{
					animData.delayTime = value;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value2, parameters, keywordDatabase, "minoffset", "minoff"))
				{
					animData.minOffset = value2;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value3, parameters, keywordDatabase, "maxoffset", "maxoff"))
				{
					animData.maxOffset = value3;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value4, parameters, keywordDatabase, "minrotation", "minrot"))
				{
					animData.minRotation = value4;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value5, parameters, keywordDatabase, "maxrotation", "maxrot"))
				{
					animData.maxRotation = value5;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value6, parameters, keywordDatabase, "minscale", "minscl"))
				{
					animData.minScale = value6;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value7, parameters, keywordDatabase, "maxscale", "maxscl"))
				{
					animData.maxScale = value7;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value8, parameters, keywordDatabase, "mincolorshift", "minclrshift", "minclr"))
				{
					animData.minColorShift = value8;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value9, parameters, keywordDatabase, "maxcolorshift", "maxclrshift", "maxclr"))
				{
					animData.maxColorShift = value9;
				}
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return true;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "delay", "d"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "minoffset", "minoff"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "maxoffset", "maxoff"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "minrotation", "minrot"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "maxrotation", "maxrot"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "minscale", "minscl"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "maxscale", "maxscl"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "mincolorshift", "minclrshift", "minclr"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "maxcolorshift", "maxclrshift", "maxclr"))
			{
				return false;
			}
			return true;
		}
	}
}
