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
		private OffsetTypePowerEnum offsetProvider;

		[TMPParameterBundleField("uniformity", new string[] { "uni" })]
		[SerializeField]
		private float uniformity;

		[SerializeField]
		[TMPParameterBundleField("ignoreanimatorscaling", new string[] { "ignorescaling", "ignorescl", "ignscl" })]
		private bool ignoreAnimatorScaling;

		[SerializeField]
		[TMPParameterBundleField("zerooffset", new string[] { "zerooff", "zoff", "zoffset", "ignlen" })]
		private bool zeroBasedOffset;

		private OffsetBundleImpl impl;

		public ITMPOffsetProvider Provider => null;

		public float Uniformity => 0f;

		public bool IgnoreAnimatorScaling => false;

		public bool ZeroBasedOffset => false;

		public bool Cache
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private ITMPOffsetProvider provider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void ClearCache()
		{
		}

		public float GetOffset(CharData cData, IAnimatorDataProvider animatorData, ITMPSegmentData segmentData = null)
		{
			return 0f;
		}

		public float GetOffset(CharData cData, IAnimationContext context)
		{
			return 0f;
		}

		private static void Create_Hook(ref SceneOffsetBundle newInstance, SceneOffsetBundle originalInstance, SceneOffsetBundleParameters parameters)
		{
		}

		public static bool ValidateSceneOffsetBundleParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords = null, string prefix = "")
		{
			return false;
		}

		public static SceneOffsetBundleParameters GetSceneOffsetBundleParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords = null, string prefix = "")
		{
			return default(SceneOffsetBundleParameters);
		}

		public static SceneOffsetBundle CreateSceneOffsetBundle(SceneOffsetBundle SceneOffsetBundleInstance, SceneOffsetBundleParameters parameters)
		{
			return null;
		}
	}
}
