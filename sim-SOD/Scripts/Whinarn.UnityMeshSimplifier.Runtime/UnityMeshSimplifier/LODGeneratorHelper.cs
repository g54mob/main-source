using UnityEngine;

namespace UnityMeshSimplifier
{
	[AddComponentMenu("Rendering/LOD Generator Helper")]
	public sealed class LODGeneratorHelper : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The fade mode used by the created LOD group.")]
		private LODFadeMode fadeMode;

		[Tooltip("If the cross-fading should be animated by time.")]
		[SerializeField]
		private bool animateCrossFading;

		[Tooltip("If the renderers under this game object and any children should be automatically collected.")]
		[SerializeField]
		private bool autoCollectRenderers;

		[Tooltip("The simplification options.")]
		[SerializeField]
		private SimplificationOptions simplificationOptions;

		[Tooltip("The path within the project to save the generated assets. Leave this empty to use the default path.")]
		[SerializeField]
		private string saveAssetsPath;

		[SerializeField]
		[Tooltip("The LOD levels.")]
		private LODLevel[] levels;

		[SerializeField]
		private bool isGenerated;

		public LODFadeMode FadeMode
		{
			get
			{
				return default(LODFadeMode);
			}
			set
			{
			}
		}

		public bool AnimateCrossFading
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AutoCollectRenderers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public SimplificationOptions SimplificationOptions
		{
			get
			{
				return default(SimplificationOptions);
			}
			set
			{
			}
		}

		public string SaveAssetsPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public LODLevel[] Levels
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsGenerated => false;

		private void Reset()
		{
		}
	}
}
