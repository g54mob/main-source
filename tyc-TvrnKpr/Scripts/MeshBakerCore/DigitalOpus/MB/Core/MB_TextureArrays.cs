using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class MB_TextureArrays
	{
		internal class TexturePropertyData
		{
			public bool[] doMips;

			public int[] numMipMaps;

			public TextureFormat[] formats;

			public MB_TextureCompressionQuality[] compressionQualities;

			public Vector2[] sizes;
		}

		[CompilerGenerated]
		private sealed class _003C_CreateAtlasesCoroutineSingleResultMaterial_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MB3_TextureCombiner combiner;

			public int resMatIdx;

			public MB_MultiMaterialTexArray resMatConfig;

			public MB_TextureArrayResultMaterial bakedMatsAndSlicesResMat;

			public ProgressUpdateDelegate progressInfo;

			public List<GameObject> objsToMesh;

			public List<string> texPropNamesToIgnore;

			public MB2_EditorMethodsInterface editorMethods;

			public float maxTimePerFrame;

			public MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult;

			public bool saveAtlasesAsAssets;

			public List<ShaderTextureProperty> customShaderProperties;

			public MB_TextureArrayFormatSet[] textureArrayOutputFormats;

			private MB2_LogLevel _003CLOG_LEVEL_003E5__2;

			private List<MB3_TextureCombiner.TemporaryTexture> _003CgeneratedTemporaryAtlases_003E5__3;

			private List<MB_TexArraySlice> _003CslicesConfig_003E5__4;

			private int _003CsliceIdx_003E5__5;

			private List<MB_TexArraySliceRendererMatPair> _003CsrcMatAndObjPairs_003E5__6;

			private MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult _003CcoroutineResult2_003E5__7;

			private MB_AtlasesAndRects _003CsliceAtlasesAndRectOutput_003E5__8;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003C_CreateAtlasesCoroutineSingleResultMaterial_003Ed__6(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		internal static bool[] DetermineWhichPropertiesHaveTextures(MB_AtlasesAndRects[] resultAtlasesAndRectSlices)
		{
			return null;
		}

		private static bool IsLinearProperty(List<ShaderTextureProperty> shaderPropertyNames, string shaderProperty)
		{
			return false;
		}

		internal static Texture2DArray[] CreateTextureArraysForResultMaterial(TexturePropertyData texPropertyData, List<ShaderTextureProperty> masterListOfTexProperties, MB_AtlasesAndRects[] resultAtlasesAndRectSlices, bool[] hasTexForProperty, MB3_TextureCombiner combiner, MB2_LogLevel LOG_LEVEL)
		{
			return null;
		}

		internal static bool ConvertTexturesToReadableFormat(TexturePropertyData texturePropertyData, MB_AtlasesAndRects[] resultAtlasesAndRectSlices, bool[] hasTexForProperty, List<ShaderTextureProperty> textureShaderProperties, MB3_TextureCombiner combiner, MB2_LogLevel logLevel, List<Texture2D> createdTemporaryTextureAssets, MB2_EditorMethodsInterface textureEditorMethods)
		{
			return false;
		}

		internal static void FindBestSizeAndMipCountAndFormatForTextureArrays(List<ShaderTextureProperty> texPropertyNames, int maxAtlasSize, MB_TextureArrayFormatSet targetFormatSet, MB_AtlasesAndRects[] resultAtlasesAndRectSlices, TexturePropertyData texturePropertyData)
		{
		}

		[IteratorStateMachine(typeof(_003C_CreateAtlasesCoroutineSingleResultMaterial_003Ed__6))]
		public static IEnumerator _CreateAtlasesCoroutineSingleResultMaterial(int resMatIdx, MB_TextureArrayResultMaterial bakedMatsAndSlicesResMat, MB_MultiMaterialTexArray resMatConfig, List<GameObject> objsToMesh, MB3_TextureCombiner combiner, MB_TextureArrayFormatSet[] textureArrayOutputFormats, MB_MultiMaterialTexArray[] resultMaterialsTexArray, List<ShaderTextureProperty> customShaderProperties, List<string> texPropNamesToIgnore, ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult, bool saveAtlasesAsAssets = false, MB2_EditorMethodsInterface editorMethods = null, float maxTimePerFrame = 0.01f)
		{
			return null;
		}
	}
}
