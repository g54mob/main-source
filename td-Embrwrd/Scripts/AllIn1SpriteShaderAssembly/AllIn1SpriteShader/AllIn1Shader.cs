using System.Collections.Generic;
using UnityEngine;

namespace AllIn1SpriteShader
{
	[AddComponentMenu("AllIn1SpriteShader/AddAllIn1Shader")]
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class AllIn1Shader : MonoBehaviour
	{
		public enum ShaderTypes
		{
			Default = 0,
			ScaledTime = 1,
			MaskedUI = 2,
			Urp2dRenderer = 3,
			Lit = 5,
			SRPBatcher = 6,
			Invalid = 4
		}

		private enum AfterSetAction
		{
			Clear = 0,
			CopyMaterial = 1,
			Reset = 2
		}

		public ShaderTypes currentShaderType;

		private Material currMaterial;

		private Material prevMaterial;

		private bool destroyed;

		[Range(1f, 20f)]
		public float normalStrength;

		[Range(0f, 3f)]
		public int normalSmoothing;

		[HideInInspector]
		public bool computingNormal;

		private bool needToWait;

		private int waitingCycles;

		private int timesWeWaited;

		private SpriteRenderer normalMapSr;

		private Renderer normalMapRenderer;

		private bool isSpriteRenderer;

		private string path;

		private string subPath;

		private void MakeNewMaterial(bool getShaderTypeFromPrefs, string shaderName = "AllIn1SpriteShader")
		{
		}

		public bool MakeCopy()
		{
			return false;
		}

		private void ResetAllProperties(bool getShaderTypeFromPrefs, string shaderName)
		{
		}

		private string GetStringFromShaderType()
		{
			return null;
		}

		private bool SetMaterial(AfterSetAction action, bool getShaderTypeFromPrefs, string shaderName)
		{
			return false;
		}

		private void DoAfterSetAction(AfterSetAction action)
		{
		}

		public bool TryCreateNew()
		{
			return false;
		}

		public void ClearAllKeywords()
		{
		}

		private void SetKeyword(string keyword, bool state = false)
		{
		}

		private void FindCurrMaterial()
		{
		}

		public void CleanMaterial()
		{
		}

		public bool SaveMaterial()
		{
			return false;
		}

		private void SaveMaterialWithOtherName(string path, int i = 1)
		{
		}

		private void DoSaving(string fileName)
		{
		}

		public void SetSceneDirty()
		{
		}

		private void MissingRenderer()
		{
		}

		public bool ToggleSetAtlasUvs(bool activate)
		{
			return false;
		}

		public bool ApplyMaterialToHierarchy()
		{
			return false;
		}

		public void CheckIfValidTarget()
		{
		}

		private void GetAllChildren(Transform parent, ref List<Transform> transforms)
		{
		}

		public bool RenderToImage()
		{
			return false;
		}

		private bool RenderAndSaveTexture(Material targetMaterial, Texture targetTexture)
		{
			return false;
		}

		private string GetNewValidPath(string path, int i = 1)
		{
			return null;
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnEditorUpdate()
		{
		}

		public void CreateAndAssignNormalMap()
		{
		}

		private void SetNewNormalTexture()
		{
		}

		private void SetNewNormalTexture2()
		{
		}

		private void SetNewNormalTexture3()
		{
		}

		private void SetNewNormalTexture4()
		{
		}
	}
}
