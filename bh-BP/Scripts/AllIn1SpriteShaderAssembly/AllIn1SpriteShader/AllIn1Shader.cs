using System.Collections.Generic;
using UnityEngine;

namespace AllIn1SpriteShader
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[AddComponentMenu("AllIn1SpriteShader/AddAllIn1Shader")]
	public class AllIn1Shader : MonoBehaviour
	{
		public enum ShaderTypes
		{
			Default = 0,
			ScaledTime = 1,
			MaskedUI = 2,
			Urp2dRenderer = 3,
			Invalid = 4
		}

		private enum AfterSetAction
		{
			Clear = 0,
			CopyMaterial = 1,
			Reset = 2
		}

		public ShaderTypes shaderTypes;

		private Material currMaterial;

		private Material prevMaterial;

		private bool matAssigned;

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

		public void MakeCopy()
		{
		}

		private void ResetAllProperties(bool getShaderTypeFromPrefs, string shaderName)
		{
		}

		private string GetStringFromShaderType()
		{
			return null;
		}

		private void SetMaterial(AfterSetAction action, bool getShaderTypeFromPrefs, string shaderName)
		{
		}

		private void DoAfterSetAction(AfterSetAction action)
		{
		}

		public void TryCreateNew()
		{
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

		public void SaveMaterial()
		{
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

		public void ToggleSetAtlasUvs(bool activate)
		{
		}

		public void ApplyMaterialToHierarchy()
		{
		}

		public void CheckIfValidTarget()
		{
		}

		private void GetAllChildren(Transform parent, ref List<Transform> transforms)
		{
		}

		public void RenderToImage()
		{
		}

		public void RenderAndSaveTexture(Material targetMaterial, Texture targetTexture)
		{
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

		private Texture2D CreateNormalMap(Texture2D t, float normalMult = 5f, int normalSmooth = 0)
		{
			return null;
		}
	}
}
