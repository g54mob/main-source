using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public abstract class UMAGeneratorBase : MonoBehaviour
	{
		public enum FitMethod
		{
			DecreaseResolution = 0,
			BestFitSquare = 1
		}

		public class AnimatorState
		{
			public bool wasCopied;

			public bool FreezeTime;

			private bool wasInitialized;

			private int[] stateHashes;

			private float[] stateTimes;

			private AnimatorControllerParameter[] parameters;

			private Dictionary<int, float> layerWeights;

			public void SaveAnimatorState(Animator animator, UMAData umaData)
			{
			}

			public void RestoreAnimatorState(Animator animator, UMAData umaData)
			{
			}
		}

		public bool fitAtlas;

		[HideInInspector]
		public TextureMerge textureMerge;

		[Header("Convert Render Texture should not be used on mobile devices")]
		[Tooltip("Convert this to a normal texture. This should be OFF for mobile devices or devices that have unified memory")]
		public bool convertRenderTexture;

		[Tooltip("Use Async RT conversion to avoid GPU stalls")]
		public bool useAsyncConversion;

		[Tooltip("Regenerate Mipmaps on conversion to avoid copying mips from GPU")]
		public bool asyncMipRegen;

		[Tooltip("Create Mipmaps for the generated texture. Checking this is a good idea.")]
		public bool convertMipMaps;

		[Tooltip("Initial size of the texture atlas (square)")]
		public int atlasResolution;

		[Tooltip("In Editor Initial size of the texture atlas (square)")]
		public int editorAtlasResolution;

		[Tooltip("How the textures are fit in the atlas if they are too large to fit normally")]
		public FitMethod AtlasOverflowFitMethod;

		[Tooltip("The percentage to shrink the textures if using DecreaseResolution fit method")]
		[Range(0.1f, 0.9f)]
		public float FitPercentageDecrease;

		[Tooltip("When true, the rescaled textures will use a higher mipmap when being downsampled. This will result in a more detailed texture.")]
		public bool SharperFitTextures;

		[Tooltip("The default overlay to display if a slot has meshData and no overlays assigned")]
		public OverlayDataAsset defaultOverlayAsset;

		[Tooltip("UMA will ignore items with this tag when rebuilding the skeleton.")]
		public string ignoreTag;

		[Tooltip("UMA will keep items with this tag when rebuilding the skeleton. Any new bone created during the build process will be replaced with the previous copy, keeping components and references intact.")]
		public string keepTag;

		[Tooltip("Default Renderer Asset to use for the generated SkinnedMeshRenderer")]
		public UMARendererAsset defaultRendererAsset;

		public bool MultiThreadTextureConversion;

		public int MaxQueuedConversionsPerFrame;

		[NonSerialized]
		public bool FreezeTime;

		public bool SaveAndRestoreIgnoredItems;

		protected OverlayData _defaultOverlayData;

		public static HashSet<int> CreatedAvatars;

		private static List<SkeletonBone> newBones;

		public OverlayData defaultOverlaydata => null;

		public abstract bool updatePending(UMAData umaToCheck);

		public abstract bool updateProcessing(UMAData umaToCheck);

		public abstract void removeUMA(UMAData umaToRemove);

		public abstract void addDirtyUMA(UMAData umaToAdd);

		public abstract bool IsIdle();

		public abstract int QueueSize();

		public abstract void Work();

		public static UMAGeneratorBase FindInstance()
		{
			return null;
		}

		public virtual void UpdateAvatar(UMAData umaData)
		{
		}

		public static void SetAvatar(UMAData umaData, Animator animator)
		{
		}

		public static void DebugLogHumanAvatar(GameObject root, HumanDescription description)
		{
		}

		public static Avatar CreateAvatar(UMAData umaData, UmaTPose umaTPose)
		{
			return null;
		}

		public static Avatar CreateGenericAvatar(UMAData umaData)
		{
			return null;
		}

		public static HumanDescription CreateHumanDescription(UMAData umaData, UmaTPose umaTPose)
		{
			return default(HumanDescription);
		}

		private void ModifySkeletonBone(ref SkeletonBone bone, Transform trans)
		{
		}

		private static void SkeletonModifier(UMAData umaData, ref SkeletonBone[] bones, HumanBone[] human)
		{
		}
	}
}
