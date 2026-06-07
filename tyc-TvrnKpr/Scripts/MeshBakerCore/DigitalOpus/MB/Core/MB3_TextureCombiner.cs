using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	[Serializable]
	public class MB3_TextureCombiner
	{
		public class CreateAtlasesCoroutineResult
		{
			public bool success;

			public bool isFinished;
		}

		internal class TemporaryTexture
		{
			internal string property;

			internal Texture2D texture;

			public TemporaryTexture(string prop, Texture2D tex)
			{
			}
		}

		public class CombineTexturesIntoAtlasesCoroutineResult
		{
			public bool success;

			public bool isFinished;
		}

		[CompilerGenerated]
		private sealed class _003CCombineTexturesIntoAtlasesCoroutine_003Ed__84 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CombineTexturesIntoAtlasesCoroutineResult coroutineResult;

			public float maxTimePerFrame;

			public MB3_TextureCombiner _003C_003E4__this;

			public ProgressUpdateDelegate progressInfo;

			public MB_AtlasesAndRects resultAtlasesAndRects;

			public Material resultMaterial;

			public List<GameObject> objsToMesh;

			public List<Material> allowedMaterialsFilter;

			public List<string> texPropsToIgnore;

			public MB2_EditorMethodsInterface textureEditorMethods;

			public List<AtlasPackingResult> packingResults;

			public bool onlyPackRects;

			public bool splitAtlasWhenPackingIfTooBig;

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
			public _003CCombineTexturesIntoAtlasesCoroutine_003Ed__84(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003C_CombineTexturesIntoAtlases_003Ed__85 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MB3_TextureCombiner _003C_003E4__this;

			public MB2_EditorMethodsInterface textureEditorMethods;

			public bool splitAtlasWhenPackingIfTooBig;

			public bool onlyPackRects;

			public CombineTexturesIntoAtlasesCoroutineResult result;

			public List<GameObject> objsToMesh;

			public ProgressUpdateDelegate progressInfo;

			public Material resultMaterial;

			public List<Material> allowedMaterialsFilter;

			public List<string> texPropsToIgnore;

			public MB_AtlasesAndRects resultAtlasesAndRects;

			public List<AtlasPackingResult> atlasPackingResult;

			private Stopwatch _003Csw_003E5__2;

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
			public _003C_CombineTexturesIntoAtlases_003Ed__85(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C__CombineTexturesIntoAtlases_003Ed__87 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MB3_TextureCombiner _003C_003E4__this;

			public MB3_TextureCombinerPipeline.TexturePipelineData data;

			public ProgressUpdateDelegate progressInfo;

			public CombineTexturesIntoAtlasesCoroutineResult result;

			public MB2_EditorMethodsInterface textureEditorMethods;

			public MB_AtlasesAndRects resultAtlasesAndRects;

			private MB3_TextureCombinerPipeline _003Cpipeline_003E5__2;

			private StringBuilder _003Creport_003E5__3;

			private MB_ITextureCombinerPacker _003CtexturePaker_003E5__4;

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
			public _003C__CombineTexturesIntoAtlases_003Ed__87(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003C__RunTexturePackerOnly_003Ed__88 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MB3_TextureCombiner _003C_003E4__this;

			public MB3_TextureCombinerPipeline.TexturePipelineData data;

			public CombineTexturesIntoAtlasesCoroutineResult result;

			public MB2_EditorMethodsInterface textureEditorMethods;

			public bool splitAtlasWhenPackingIfTooBig;

			public MB_AtlasesAndRects resultAtlasesAndRects;

			public List<AtlasPackingResult> packingResult;

			private MB3_TextureCombinerPipeline _003Cpipeline_003E5__2;

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
			public _003C__RunTexturePackerOnly_003Ed__88(int _003C_003E1__state)
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

		public const int TEMP_SOLID_COLOR_TEXTURE_SIZE = 16;

		public static Color NEUTRAL_NORMAL_MAP_COLOR_SWIZZLED;

		public static Color NEUTRAL_NORMAL_MAP_COLOR_NON_SWIZZLED;

		public MB2_LogLevel LOG_LEVEL;

		[SerializeField]
		protected MB2_TextureBakeResults _textureBakeResults;

		[SerializeField]
		protected int _atlasPadding;

		[SerializeField]
		protected int _maxAtlasSize;

		[SerializeField]
		protected int _maxAtlasWidthOverride;

		[SerializeField]
		protected int _maxAtlasHeightOverride;

		[SerializeField]
		protected bool _useMaxAtlasWidthOverride;

		[SerializeField]
		protected bool _useMaxAtlasHeightOverride;

		[SerializeField]
		protected bool _resizePowerOfTwoTextures;

		[SerializeField]
		protected bool _fixOutOfBoundsUVs;

		[SerializeField]
		protected int _layerTexturePackerFastMesh;

		[SerializeField]
		protected int _maxTilingBakeSize;

		[SerializeField]
		protected bool _saveAtlasesAsAssets;

		[SerializeField]
		protected MB2_TextureBakeResults.ResultType _resultType;

		[SerializeField]
		protected MB2_PackingAlgorithmEnum _packingAlgorithm;

		[SerializeField]
		protected bool _meshBakerTexturePackerForcePowerOfTwo;

		[SerializeField]
		protected List<ShaderTextureProperty> _customShaderPropNames;

		[SerializeField]
		protected bool _normalizeTexelDensity;

		[SerializeField]
		protected bool _considerNonTextureProperties;

		protected bool _doMergeDistinctMaterialTexturesThatWouldExceedAtlasSize;

		private List<TemporaryTexture> _temporaryTextures;

		public static bool _RunCorutineWithoutPauseIsRunning;

		public MB2_TextureBakeResults textureBakeResults
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int atlasPadding
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int maxAtlasSize
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public virtual int maxAtlasWidthOverride
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public virtual int maxAtlasHeightOverride
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public virtual bool useMaxAtlasWidthOverride
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool useMaxAtlasHeightOverride
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool resizePowerOfTwoTextures
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool fixOutOfBoundsUVs
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int layerTexturePackerFastMesh
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int maxTilingBakeSize
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool saveAtlasesAsAssets
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public MB2_TextureBakeResults.ResultType resultType
		{
			get
			{
				return default(MB2_TextureBakeResults.ResultType);
			}
			set
			{
			}
		}

		public MB2_PackingAlgorithmEnum packingAlgorithm
		{
			get
			{
				return default(MB2_PackingAlgorithmEnum);
			}
			set
			{
			}
		}

		public bool meshBakerTexturePackerForcePowerOfTwo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public List<ShaderTextureProperty> customShaderPropNames
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool considerNonTextureProperties
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool doMergeDistinctMaterialTexturesThatWouldExceedAtlasSize
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static void RunCorutineWithoutPause(IEnumerator cor, int recursionDepth)
		{
		}

		public bool CombineTexturesIntoAtlases(ProgressUpdateDelegate progressInfo, MB_AtlasesAndRects resultAtlasesAndRects, Material resultMaterial, List<GameObject> objsToMesh, List<Material> allowedMaterialsFilter, List<string> texPropsToIgnore, MB2_EditorMethodsInterface textureEditorMethods = null, List<AtlasPackingResult> packingResults = null, bool onlyPackRects = false, bool splitAtlasWhenPackingIfTooBig = false)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CCombineTexturesIntoAtlasesCoroutine_003Ed__84))]
		public IEnumerator CombineTexturesIntoAtlasesCoroutine(ProgressUpdateDelegate progressInfo, MB_AtlasesAndRects resultAtlasesAndRects, Material resultMaterial, List<GameObject> objsToMesh, List<Material> allowedMaterialsFilter, List<string> texPropsToIgnore, MB2_EditorMethodsInterface textureEditorMethods = null, CombineTexturesIntoAtlasesCoroutineResult coroutineResult = null, float maxTimePerFrame = 0.01f, List<AtlasPackingResult> packingResults = null, bool onlyPackRects = false, bool splitAtlasWhenPackingIfTooBig = false)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003C_CombineTexturesIntoAtlases_003Ed__85))]
		private IEnumerator _CombineTexturesIntoAtlases(ProgressUpdateDelegate progressInfo, CombineTexturesIntoAtlasesCoroutineResult result, MB_AtlasesAndRects resultAtlasesAndRects, Material resultMaterial, List<GameObject> objsToMesh, List<Material> allowedMaterialsFilter, List<string> texPropsToIgnore, MB2_EditorMethodsInterface textureEditorMethods, List<AtlasPackingResult> atlasPackingResult, bool onlyPackRects, bool splitAtlasWhenPackingIfTooBig)
		{
			return null;
		}

		private MB3_TextureCombinerPipeline.TexturePipelineData LoadPipelineData(Material resultMaterial, List<ShaderTextureProperty> texPropertyNames, List<GameObject> objsToMesh, List<Material> allowedMaterialsFilter, List<string> texPropsToIgnore, List<MB_TexSet> distinctMaterialTextures)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003C__CombineTexturesIntoAtlases_003Ed__87))]
		private IEnumerator __CombineTexturesIntoAtlases(ProgressUpdateDelegate progressInfo, CombineTexturesIntoAtlasesCoroutineResult result, MB_AtlasesAndRects resultAtlasesAndRects, MB3_TextureCombinerPipeline.TexturePipelineData data, MB2_EditorMethodsInterface textureEditorMethods)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003C__RunTexturePackerOnly_003Ed__88))]
		private IEnumerator __RunTexturePackerOnly(CombineTexturesIntoAtlasesCoroutineResult result, MB_AtlasesAndRects resultAtlasesAndRects, MB3_TextureCombinerPipeline.TexturePipelineData data, bool splitAtlasWhenPackingIfTooBig, MB2_EditorMethodsInterface textureEditorMethods, List<AtlasPackingResult> packingResult)
		{
			return null;
		}

		internal int _getNumTemporaryTextures()
		{
			return 0;
		}

		public Texture2D _createTemporaryTexture(string propertyName, int w, int h, TextureFormat texFormat, bool mipMaps, bool linear)
		{
			return null;
		}

		internal void AddTemporaryTexture(TemporaryTexture tt)
		{
		}

		internal Texture2D _createTextureCopy(ShaderTextureProperty propertyName, Texture2D t)
		{
			return null;
		}

		internal Texture2D _resizeTexture(ShaderTextureProperty propertyName, Texture2D t, int w, int h)
		{
			return null;
		}

		internal void _destroyAllTemporaryTextures()
		{
		}

		internal void _destroyTemporaryTextures(string propertyName)
		{
		}

		public void _restoreProceduralMaterials()
		{
		}

		public void SuggestTreatment(List<GameObject> objsToMesh, Material[] resultMaterials, List<ShaderTextureProperty> _customShaderPropNames, List<string> texPropsToIgnore)
		{
		}

		public static bool ShouldTextureBeLinear(ShaderTextureProperty shaderTextureProperty)
		{
			return false;
		}

		private string PrintList(List<GameObject> gos)
		{
			return null;
		}
	}
}
