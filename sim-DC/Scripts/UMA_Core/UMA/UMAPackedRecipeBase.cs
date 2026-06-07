using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public abstract class UMAPackedRecipeBase : UMARecipeBase
	{
		[Serializable]
		public class packedSlotData
		{
			public string slotID;

			public int overlayScale;

			public int copyOverlayIndex;

			public packedOverlayData[] OverlayDataList;
		}

		[Serializable]
		public class packedOverlayData
		{
			public string overlayID;

			public int[] colorList;

			public int[][] channelMaskList;

			public int[][] channelAdditiveMaskList;

			public int[] rectList;
		}

		[Serializable]
		public class PackedSlotDataV2
		{
			public string id;

			public int scale;

			public int copyIdx;

			public PackedOverlayDataV2[] overlays;
		}

		[Serializable]
		public class PackedOverlayDataV2
		{
			public string id;

			public int colorIdx;

			public int[] rect;
		}

		[Serializable]
		public class PackedOverlayColorDataV2
		{
			public string name;

			public byte[] color;

			public byte[][] masks;

			public byte[][] addMasks;

			public PackedOverlayColorDataV2()
			{
			}

			public PackedOverlayColorDataV2(OverlayColorData colorData)
			{
			}

			public void SetOverlayColorData(OverlayColorData overlayColorData)
			{
			}
		}

		[Serializable]
		public class PackedSlotDataV3
		{
			public string id;

			public int scale;

			public int copyIdx;

			public PackedOverlayDataV3[] overlays;

			public string[] Tags;

			public string[] Races;

			public string blendShapeTarget;

			public float overSmoosh;

			public float smooshDistance;

			public bool smooshInvertX;

			public bool smooshInvertY;

			public bool smooshInvertZ;

			public bool smooshInvertDist;

			public string smooshTargetTag;

			public string smooshableTag;

			public bool isSwapSlot;

			public string swapTag;

			public int uvOverride;

			public bool isDisabled;

			public int expandAlongNormal;
		}

		[Serializable]
		public class PackedOverlayDataV3
		{
			public string id;

			public int colorIdx;

			public float[] rect;

			public bool isTransformed;

			public Vector3 scale;

			public float rotation;

			public int[] blendModes;

			public string[] Tags;

			public bool[] tiling;

			public int uvOverride;

			public Vector2 translate;
		}

		[Serializable]
		public class PackedOverlayColorDataV3
		{
			public string name;

			public short[] colors;

			public string[] ShaderParms;

			public bool alwaysUpdate;

			public bool alwaysUpdateParms;

			public bool isBaseColor;

			public int displayColor;

			public PackedOverlayColorDataV3()
			{
			}

			public PackedOverlayColorDataV3(OverlayColorData colorData)
			{
			}

			public void SetOverlayColorData(OverlayColorData overlayColorData)
			{
			}
		}

		[Serializable]
		public class UMAPackedDna
		{
			public string dnaType;

			public int dnaTypeHash;

			public string packedDna;
		}

		[Serializable]
		public class UMAPackRecipe
		{
			public int version;

			public packedSlotData[] packedSlotDataList;

			public PackedSlotDataV2[] slotsV2;

			public PackedSlotDataV3[] slotsV3;

			public PackedOverlayColorDataV2[] colors;

			public PackedOverlayColorDataV3[] fColors;

			public int sharedColorCount;

			public string race;

			public Dictionary<Type, UMADna> umaDna;

			public List<UMAPackedDna> packedDna;

			public int uvOverride;

			public static bool ArrayHasData(Array array)
			{
				return false;
			}

			public static bool SlotIsValid(SlotData slotData)
			{
				return false;
			}

			public static bool SlotIsValid(packedSlotData packedSlotData)
			{
				return false;
			}

			public static bool SlotIsValid(PackedSlotDataV2 packedSlot)
			{
				return false;
			}

			public static bool SlotIsValid(PackedSlotDataV3 packedSlot)
			{
				return false;
			}

			public static bool MaterialIsValid(UMAMaterial material)
			{
				return false;
			}

			public static bool RaceIsValid(RaceData raceData)
			{
				return false;
			}
		}

		public override void Load(UMAData.UMARecipe umaRecipe, UMAContextBase context, bool loadSlots = true)
		{
		}

		public static UMAData.UMARecipe UnpackRecipe(UMAPackRecipe umaPackRecipe, UMAContextBase context)
		{
			return null;
		}

		public static void UnpackRecipe(UMAData.UMARecipe umaRecipe, UMAPackRecipe umaPackRecipe, UMAContextBase context, bool loadSlots = true)
		{
		}

		public override void Save(UMAData.UMARecipe umaRecipe, UMAContextBase context)
		{
		}

		public abstract UMAPackRecipe PackedLoad(UMAContextBase context);

		public abstract void PackedSave(UMAPackRecipe packedRecipe, UMAContextBase context);

		public static List<UMAPackedDna> GetPackedDNA(UMAData.UMARecipe umaRecipe)
		{
			return null;
		}

		public static UMAPackRecipe PackRecipeV3(UMAData.UMARecipe umaRecipe)
		{
			return null;
		}

		public static bool UnpackRecipeVersion1(UMAData.UMARecipe umaRecipe, UMAPackRecipe umaPackRecipe, UMAContextBase context)
		{
			return false;
		}

		public static List<UMADnaBase> UnPackDNA(List<UMAPackedDna> DNA)
		{
			return null;
		}

		public static UMAData.UMARecipe UnpackRecipeVersion2(UMAPackRecipe umaPackRecipe, UMAContextBase context)
		{
			return null;
		}

		public static void UnpackRecipeVersion2(UMAData.UMARecipe umaRecipe, UMAPackRecipe umaPackRecipe, UMAContextBase context)
		{
		}

		public static UMAData.UMARecipe UnpackRecipeVersion3(UMAPackRecipe umaPackRecipe, UMAContextBase context, bool loadSlots = true)
		{
			return null;
		}

		public static void UnpackRecipeVersion3(UMAData.UMARecipe umaRecipe, UMAPackRecipe umaPackRecipe, UMAContextBase context, bool loadSlots = true)
		{
		}

		public static OverlayColorData[] UnpackColors(UMAPackRecipe umaPackRecipe)
		{
			return null;
		}
	}
}
