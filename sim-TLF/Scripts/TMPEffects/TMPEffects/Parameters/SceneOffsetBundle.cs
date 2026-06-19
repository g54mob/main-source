using System;
using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Databases;
using TMPEffects.Parameters.Attributes;
using TMPEffects.TMPAnimations;
using UnityEngine;

namespace TMPEffects.Parameters
{
	[Serializable]
	[TMPParameterBundle("SceneOffsetBundle")]
	public class SceneOffsetBundle
	{
		public struct SceneOffsetBundleParameters
		{
			public ITMPOffsetProvider _provider;

			public float? uniformity;

			public bool? ignoreAnimatorScaling;

			public bool? zeroBasedOffset;
		}

		[TMPParameterBundleField("offset", new string[] { "off" })]
		private ITMPOffsetProvider _provider;

		[SerializeField]
		[HideInInspector]
		private OffsetTypePowerEnum offsetProvider = new OffsetTypePowerEnum();

		[TMPParameterBundleField("uniformity", new string[] { "uni" })]
		[SerializeField]
		private float uniformity = 1f;

		[SerializeField]
		[TMPParameterBundleField("ignoreanimatorscaling", new string[] { "ignorescaling", "ignorescl", "ignscl" })]
		private bool ignoreAnimatorScaling;

		[SerializeField]
		[TMPParameterBundleField("zerooffset", new string[] { "zerooff", "zoff", "zoffset", "ignlen" })]
		private bool zeroBasedOffset;

		private OffsetBundleImpl impl;

		public ITMPOffsetProvider Provider => provider;

		public float Uniformity => uniformity;

		public bool IgnoreAnimatorScaling => ignoreAnimatorScaling;

		public bool ZeroBasedOffset => zeroBasedOffset;

		public bool Cache
		{
			get
			{
				return impl.Cache;
			}
			set
			{
				impl.Cache = value;
			}
		}

		private ITMPOffsetProvider provider
		{
			get
			{
				return _provider ?? offsetProvider;
			}
			set
			{
				_provider = value;
			}
		}

		public void ClearCache()
		{
			impl.ClearCache();
		}

		public float GetOffset(CharData cData, IAnimatorDataProvider animatorData, ITMPSegmentData segmentData = null)
		{
			return impl.GetOffset(cData, animatorData, segmentData);
		}

		public float GetOffset(CharData cData, IAnimationContext context)
		{
			return impl.GetOffset(cData, context);
		}

		private static void Create_Hook(ref SceneOffsetBundle newInstance, SceneOffsetBundle originalInstance, SceneOffsetBundleParameters parameters)
		{
			newInstance.impl = new OffsetBundleImpl();
			newInstance.impl.IgnoreAnimatorScaling = newInstance.ignoreAnimatorScaling;
			newInstance.impl.Provider = newInstance.provider;
			newInstance.impl.ZeroBasedOffset = newInstance.zeroBasedOffset;
			newInstance.impl.Uniformity = newInstance.uniformity;
			newInstance.impl.Cache = true;
		}

		public static bool ValidateSceneOffsetBundleParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords = null, string prefix = "")
		{
			if (parameters == null)
			{
				return true;
			}
			if (ITMPOffsetProvider.HasNonOffsetProviderParameter(parameters, keywords, prefix + "offset", prefix + "off"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywords, prefix + "uniformity", prefix + "uni"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonBoolParameter(parameters, keywords, prefix + "ignoreanimatorscaling", prefix + "ignorescaling", prefix + "ignorescl", prefix + "ignscl"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonBoolParameter(parameters, keywords, prefix + "zerooffset", prefix + "zerooff", prefix + "zoff", prefix + "zoffset", prefix + "ignlen"))
			{
				return false;
			}
			return true;
		}

		public static SceneOffsetBundleParameters GetSceneOffsetBundleParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords = null, string prefix = "")
		{
			SceneOffsetBundleParameters result = default(SceneOffsetBundleParameters);
			if (parameters == null)
			{
				return result;
			}
			if (ITMPOffsetProvider.TryGetOffsetProviderParameter(out var value, parameters, keywords, prefix + "offset", prefix + "off"))
			{
				result._provider = value;
			}
			if (TMPParameterUtility.TryGetFloatParameter(out var value2, parameters, keywords, prefix + "uniformity", prefix + "uni"))
			{
				result.uniformity = value2;
			}
			if (TMPParameterUtility.TryGetBoolParameter(out var value3, parameters, keywords, prefix + "ignoreanimatorscaling", prefix + "ignorescaling", prefix + "ignorescl", prefix + "ignscl"))
			{
				result.ignoreAnimatorScaling = value3;
			}
			if (TMPParameterUtility.TryGetBoolParameter(out var value4, parameters, keywords, prefix + "zerooffset", prefix + "zerooff", prefix + "zoff", prefix + "zoffset", prefix + "ignlen"))
			{
				result.zeroBasedOffset = value4;
			}
			return result;
		}

		public static SceneOffsetBundle CreateSceneOffsetBundle(SceneOffsetBundle SceneOffsetBundleInstance, SceneOffsetBundleParameters parameters)
		{
			SceneOffsetBundle newInstance = new SceneOffsetBundle();
			newInstance._provider = parameters._provider ?? SceneOffsetBundleInstance._provider;
			newInstance.uniformity = parameters.uniformity ?? SceneOffsetBundleInstance.uniformity;
			newInstance.ignoreAnimatorScaling = parameters.ignoreAnimatorScaling ?? SceneOffsetBundleInstance.ignoreAnimatorScaling;
			newInstance.zeroBasedOffset = parameters.zeroBasedOffset ?? SceneOffsetBundleInstance.zeroBasedOffset;
			Create_Hook(ref newInstance, SceneOffsetBundleInstance, parameters);
			return newInstance;
		}
	}
}
