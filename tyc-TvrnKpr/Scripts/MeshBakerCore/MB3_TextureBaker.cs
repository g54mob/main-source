using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DigitalOpus.MB.Core;
using UnityEngine;

public class MB3_TextureBaker : MB3_MeshBakerRoot
{
	public delegate void OnCombinedTexturesCoroutineSuccess();

	public delegate void OnCombinedTexturesCoroutineFail();

	[CompilerGenerated]
	private sealed class _003CCreateAtlasesCoroutine_003Ed__108 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MB3_TextureBaker _003C_003E4__this;

		public ProgressUpdateDelegate progressInfo;

		public MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult;

		public bool saveAtlasesAsAssets;

		public MB2_EditorMethodsInterface editorMethods;

		public float maxTimePerFrame;

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
		public _003CCreateAtlasesCoroutine_003Ed__108(int _003C_003E1__state)
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
	private sealed class _003C_CreateAtlasesCoroutine_003Ed__111 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MB3_TextureBaker _003C_003E4__this;

		public float maxTimePerFrame;

		public MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult;

		public bool saveAtlasesAsAssets;

		public ProgressUpdateDelegate progressInfo;

		public MB2_EditorMethodsInterface editorMethods;

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
		public _003C_CreateAtlasesCoroutine_003Ed__111(int _003C_003E1__state)
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
	private sealed class _003C_CreateAtlasesCoroutineAtlases_003Ed__109 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MB3_TextureBaker _003C_003E4__this;

		public MB3_TextureCombiner combiner;

		public ProgressUpdateDelegate progressInfo;

		public MB2_EditorMethodsInterface editorMethods;

		public float maxTimePerFrame;

		public MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult;

		private int _003Ci_003E5__2;

		private MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult _003CcoroutineResult2_003E5__3;

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
		public _003C_CreateAtlasesCoroutineAtlases_003Ed__109(int _003C_003E1__state)
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
	private sealed class _003C_CreateAtlasesCoroutineTextureArray_003Ed__110 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MB3_TextureBaker _003C_003E4__this;

		public MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult;

		public MB2_EditorMethodsInterface editorMethods;

		public MB3_TextureCombiner combiner;

		public ProgressUpdateDelegate progressInfo;

		public bool saveAtlasesAsAssets;

		public float maxTimePerFrame;

		private MB_TextureArrayResultMaterial[] _003CbakedMatsAndSlices_003E5__2;

		private int _003CresMatIdx_003E5__3;

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
		public _003C_CreateAtlasesCoroutineTextureArray_003Ed__110(int _003C_003E1__state)
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

	public MB2_LogLevel LOG_LEVEL;

	[SerializeField]
	protected MB2_TextureBakeResults _textureBakeResults;

	[SerializeField]
	protected int _atlasPadding;

	[SerializeField]
	protected int _maxAtlasSize;

	[SerializeField]
	protected bool _useMaxAtlasWidthOverride;

	[SerializeField]
	protected int _maxAtlasWidthOverride;

	[SerializeField]
	protected bool _useMaxAtlasHeightOverride;

	[SerializeField]
	protected int _maxAtlasHeightOverride;

	[SerializeField]
	protected bool _resizePowerOfTwoTextures;

	[SerializeField]
	protected bool _fixOutOfBoundsUVs;

	[SerializeField]
	protected int _maxTilingBakeSize;

	[SerializeField]
	protected MB2_PackingAlgorithmEnum _packingAlgorithm;

	[SerializeField]
	protected int _layerTexturePackerFastMesh;

	[SerializeField]
	protected bool _meshBakerTexturePackerForcePowerOfTwo;

	[SerializeField]
	[NonReorderable]
	protected List<ShaderTextureProperty> _customShaderProperties;

	[SerializeField]
	[NonReorderable]
	protected List<string> _texturePropNamesToIgnore;

	[SerializeField]
	protected List<string> _customShaderPropNames_Depricated;

	[SerializeField]
	protected MB2_TextureBakeResults.ResultType _resultType;

	[SerializeField]
	protected bool _doMultiMaterial;

	[SerializeField]
	protected bool _doMultiMaterialSplitAtlasesIfTooBig;

	[SerializeField]
	protected bool _doMultiMaterialSplitAtlasesIfOBUVs;

	[SerializeField]
	protected Material _resultMaterial;

	[SerializeField]
	protected bool _considerNonTextureProperties;

	[SerializeField]
	protected bool _doSuggestTreatment;

	private MB3_TextureCombiner.CreateAtlasesCoroutineResult _coroutineResult;

	[NonReorderable]
	public MB_MultiMaterial[] resultMaterials;

	[NonReorderable]
	public MB_MultiMaterialTexArray[] resultMaterialsTexArray;

	[NonReorderable]
	public MB_TextureArrayFormatSet[] textureArrayOutputFormats;

	[NonReorderable]
	public List<GameObject> objsToMesh;

	public OnCombinedTexturesCoroutineSuccess onBuiltAtlasesSuccess;

	public OnCombinedTexturesCoroutineFail onBuiltAtlasesFail;

	public MB_AtlasesAndRects[] OnCombinedTexturesCoroutineAtlasesAndRects;

	public override MB2_TextureBakeResults textureBakeResults
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual int atlasPadding
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public virtual int maxAtlasSize
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

	public virtual bool resizePowerOfTwoTextures
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual bool fixOutOfBoundsUVs
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual int maxTilingBakeSize
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public virtual MB2_PackingAlgorithmEnum packingAlgorithm
	{
		get
		{
			return default(MB2_PackingAlgorithmEnum);
		}
		set
		{
		}
	}

	public virtual int layerForTexturePackerFastMesh
	{
		get
		{
			return 0;
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

	public virtual List<ShaderTextureProperty> customShaderProperties
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual List<string> texturePropNamesToIgnore
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual List<string> customShaderPropNames
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual MB2_TextureBakeResults.ResultType resultType
	{
		get
		{
			return default(MB2_TextureBakeResults.ResultType);
		}
		set
		{
		}
	}

	public virtual bool doMultiMaterial
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual bool doMultiMaterialSplitAtlasesIfTooBig
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual bool doMultiMaterialSplitAtlasesIfOBUVs
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual Material resultMaterial
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

	public bool doSuggestTreatment
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public MB3_TextureCombiner.CreateAtlasesCoroutineResult CoroutineResult => null;

	public override List<GameObject> GetObjectsToCombine()
	{
		return null;
	}

	[ContextMenu("Purge Objects to Combine of null references")]
	public override void PurgeNullsFromObjectsToCombine()
	{
	}

	public MB_AtlasesAndRects[] CreateAtlases()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCreateAtlasesCoroutine_003Ed__108))]
	public IEnumerator CreateAtlasesCoroutine(ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult, bool saveAtlasesAsAssets = false, MB2_EditorMethodsInterface editorMethods = null, float maxTimePerFrame = 0.01f)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_CreateAtlasesCoroutineAtlases_003Ed__109))]
	private IEnumerator _CreateAtlasesCoroutineAtlases(MB3_TextureCombiner combiner, ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult, bool saveAtlasesAsAssets = false, MB2_EditorMethodsInterface editorMethods = null, float maxTimePerFrame = 0.01f)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_CreateAtlasesCoroutineTextureArray_003Ed__110))]
	internal IEnumerator _CreateAtlasesCoroutineTextureArray(MB3_TextureCombiner combiner, ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult, bool saveAtlasesAsAssets = false, MB2_EditorMethodsInterface editorMethods = null, float maxTimePerFrame = 0.01f)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_CreateAtlasesCoroutine_003Ed__111))]
	private IEnumerator _CreateAtlasesCoroutine(ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult, bool saveAtlasesAsAssets = false, MB2_EditorMethodsInterface editorMethods = null, float maxTimePerFrame = 0.01f)
	{
		return null;
	}

	public MB_AtlasesAndRects[] CreateAtlases(ProgressUpdateDelegate progressInfo, bool saveAtlasesAsAssets = false, MB2_EditorMethodsInterface editorMethods = null)
	{
		return null;
	}

	private void unpackMat2RectMap(MB_AtlasesAndRects[] rawResults)
	{
	}

	internal void unpackMat2RectMap(MB_TextureArrayResultMaterial[] rawResults)
	{
	}

	public MB3_TextureCombiner CreateAndConfigureTextureCombiner()
	{
		return null;
	}

	public static void ConfigureNewMaterialToMatchOld(Material newMat, Material original)
	{
	}

	private string PrintSet(HashSet<Material> s)
	{
		return null;
	}

	private bool _ValidateResultMaterials()
	{
		return false;
	}
}
