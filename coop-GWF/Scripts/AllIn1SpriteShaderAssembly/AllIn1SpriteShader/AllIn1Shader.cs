using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

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

		public ShaderTypes currentShaderType = ShaderTypes.Invalid;

		private Material currMaterial;

		private Material prevMaterial;

		private bool destroyed;

		[Range(1f, 20f)]
		public float normalStrength = 5f;

		[Range(0f, 3f)]
		public int normalSmoothing = 1;

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
			SetMaterial(AfterSetAction.Clear, getShaderTypeFromPrefs, shaderName);
		}

		public bool MakeCopy()
		{
			return SetMaterial(AfterSetAction.CopyMaterial, getShaderTypeFromPrefs: false, GetStringFromShaderType());
		}

		private void ResetAllProperties(bool getShaderTypeFromPrefs, string shaderName)
		{
			SetMaterial(AfterSetAction.Reset, getShaderTypeFromPrefs, shaderName);
		}

		private string GetStringFromShaderType()
		{
			currentShaderType = ShaderTypes.Default;
			if (currentShaderType == ShaderTypes.Default)
			{
				return "AllIn1SpriteShader";
			}
			if (currentShaderType == ShaderTypes.ScaledTime)
			{
				return "AllIn1SpriteShaderScaledTime";
			}
			if (currentShaderType == ShaderTypes.MaskedUI)
			{
				return "AllIn1SpriteShaderUiMask";
			}
			if (currentShaderType == ShaderTypes.Urp2dRenderer)
			{
				return "AllIn1Urp2dRenderer";
			}
			if (currentShaderType == ShaderTypes.Lit)
			{
				return "AllIn1SpriteShaderLit";
			}
			if (currentShaderType == ShaderTypes.SRPBatcher)
			{
				return "AllIn1SpriteShaderSRPBatch";
			}
			return "AllIn1SpriteShader";
		}

		private bool SetMaterial(AfterSetAction action, bool getShaderTypeFromPrefs, string shaderName)
		{
			return false;
		}

		private void DoAfterSetAction(AfterSetAction action)
		{
			switch (action)
			{
			case AfterSetAction.Clear:
				ClearAllKeywords();
				break;
			case AfterSetAction.CopyMaterial:
				currMaterial.CopyPropertiesFromMaterial(prevMaterial);
				break;
			}
		}

		public bool TryCreateNew()
		{
			bool flag = false;
			Renderer component = GetComponent<Renderer>();
			if (component != null)
			{
				flag = true;
				if (component != null && component.sharedMaterial != null && component.sharedMaterial.name.Contains("AllIn1"))
				{
					ResetAllProperties(getShaderTypeFromPrefs: false, GetStringFromShaderType());
					ClearAllKeywords();
				}
				else
				{
					CleanMaterial();
					MakeNewMaterial(getShaderTypeFromPrefs: false, GetStringFromShaderType());
				}
			}
			else
			{
				Graphic component2 = GetComponent<Graphic>();
				if (component2 != null)
				{
					flag = true;
					if (component2.material.name.Contains("AllIn1"))
					{
						ResetAllProperties(getShaderTypeFromPrefs: false, GetStringFromShaderType());
						ClearAllKeywords();
					}
					else
					{
						MakeNewMaterial(getShaderTypeFromPrefs: false, GetStringFromShaderType());
					}
				}
			}
			if (!flag)
			{
				MissingRenderer();
			}
			SetSceneDirty();
			return flag;
		}

		public void ClearAllKeywords()
		{
			SetKeyword("RECTSIZE_ON");
			SetKeyword("OFFSETUV_ON");
			SetKeyword("CLIPPING_ON");
			SetKeyword("POLARUV_ON");
			SetKeyword("TWISTUV_ON");
			SetKeyword("ROTATEUV_ON");
			SetKeyword("FISHEYE_ON");
			SetKeyword("PINCH_ON");
			SetKeyword("SHAKEUV_ON");
			SetKeyword("WAVEUV_ON");
			SetKeyword("ROUNDWAVEUV_ON");
			SetKeyword("DOODLE_ON");
			SetKeyword("ZOOMUV_ON");
			SetKeyword("FADE_ON");
			SetKeyword("TEXTURESCROLL_ON");
			SetKeyword("GLOW_ON");
			SetKeyword("OUTBASE_ON");
			SetKeyword("ONLYOUTLINE_ON");
			SetKeyword("OUTTEX_ON");
			SetKeyword("OUTDIST_ON");
			SetKeyword("DISTORT_ON");
			SetKeyword("WIND_ON");
			SetKeyword("GRADIENT_ON");
			SetKeyword("GRADIENT2COL_ON");
			SetKeyword("RADIALGRADIENT_ON");
			SetKeyword("COLORSWAP_ON");
			SetKeyword("HSV_ON");
			SetKeyword("HITEFFECT_ON");
			SetKeyword("PIXELATE_ON");
			SetKeyword("NEGATIVE_ON");
			SetKeyword("GRADIENTCOLORRAMP_ON");
			SetKeyword("COLORRAMP_ON");
			SetKeyword("GREYSCALE_ON");
			SetKeyword("POSTERIZE_ON");
			SetKeyword("BLUR_ON");
			SetKeyword("MOTIONBLUR_ON");
			SetKeyword("GHOST_ON");
			SetKeyword("ALPHAOUTLINE_ON");
			SetKeyword("INNEROUTLINE_ON");
			SetKeyword("ONLYINNEROUTLINE_ON");
			SetKeyword("HOLOGRAM_ON");
			SetKeyword("CHROMABERR_ON");
			SetKeyword("GLITCH_ON");
			SetKeyword("FLICKER_ON");
			SetKeyword("SHADOW_ON");
			SetKeyword("SHINE_ON");
			SetKeyword("CONTRAST_ON");
			SetKeyword("OVERLAY_ON");
			SetKeyword("OVERLAYMULT_ON");
			SetKeyword("ALPHACUTOFF_ON");
			SetKeyword("ALPHAROUND_ON");
			SetKeyword("CHANGECOLOR_ON");
			SetKeyword("CHANGECOLOR2_ON");
			SetKeyword("CHANGECOLOR3_ON");
			SetKeyword("FOG_ON");
			SetSceneDirty();
		}

		private void SetKeyword(string keyword, bool state = false)
		{
			if (destroyed)
			{
				return;
			}
			if (currMaterial == null)
			{
				FindCurrMaterial();
				if (currMaterial == null)
				{
					MissingRenderer();
					return;
				}
			}
			if (!state)
			{
				currMaterial.DisableKeyword(keyword);
			}
			else
			{
				currMaterial.EnableKeyword(keyword);
			}
		}

		private void FindCurrMaterial()
		{
			if (GetComponent<Renderer>() != null)
			{
				currMaterial = GetComponent<Renderer>().sharedMaterial;
				return;
			}
			Graphic component = GetComponent<Graphic>();
			if (component != null)
			{
				currMaterial = component.material;
			}
		}

		public void CleanMaterial()
		{
			Renderer component = GetComponent<Renderer>();
			if (component != null)
			{
				component.sharedMaterial = new Material(Shader.Find("Sprites/Default"));
			}
			else
			{
				Graphic component2 = GetComponent<Graphic>();
				if (component2 != null)
				{
					component2.material = new Material(Shader.Find("Sprites/Default"));
				}
			}
			SetSceneDirty();
		}

		public bool SaveMaterial()
		{
			return false;
		}

		private void SaveMaterialWithOtherName(string path, int i = 1)
		{
			int num = i;
			string fileName = string.Concat(path + "_" + num, ".mat");
			if (File.Exists(fileName))
			{
				num++;
				SaveMaterialWithOtherName(path, num);
			}
			else
			{
				DoSaving(fileName);
			}
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
			bool flag = false;
			SetAtlasUvs setAtlasUvs = GetComponent<SetAtlasUvs>();
			if (activate)
			{
				if (setAtlasUvs == null)
				{
					setAtlasUvs = base.gameObject.AddComponent<SetAtlasUvs>();
				}
				if (setAtlasUvs != null)
				{
					flag = setAtlasUvs.GetAndSetUVs();
				}
				if (flag)
				{
					SetKeyword("ATLAS_ON", state: true);
				}
			}
			else
			{
				if (!(setAtlasUvs != null))
				{
					return false;
				}
				setAtlasUvs.ResetAtlasUvs();
				Object.DestroyImmediate(setAtlasUvs);
				flag = true;
				SetKeyword("ATLAS_ON");
			}
			SetSceneDirty();
			return flag;
		}

		public bool ApplyMaterialToHierarchy()
		{
			Renderer component = GetComponent<Renderer>();
			Graphic component2 = GetComponent<Graphic>();
			Material material = null;
			if (component != null)
			{
				material = component.sharedMaterial;
			}
			else
			{
				if (!(component2 != null))
				{
					MissingRenderer();
					return false;
				}
				material = component2.material;
			}
			List<Transform> transforms = new List<Transform>();
			GetAllChildren(base.transform, ref transforms);
			bool result = false;
			foreach (Transform item in transforms)
			{
				component = item.gameObject.GetComponent<Renderer>();
				if (component != null)
				{
					component.material = material;
				}
				else
				{
					component2 = item.gameObject.GetComponent<Graphic>();
					if (component2 != null)
					{
						component2.material = material;
					}
				}
				result = true;
			}
			return result;
		}

		public void CheckIfValidTarget()
		{
			Renderer component = GetComponent<Renderer>();
			Graphic component2 = GetComponent<Graphic>();
			if (component == null && component2 == null)
			{
				MissingRenderer();
			}
		}

		private void GetAllChildren(Transform parent, ref List<Transform> transforms)
		{
			foreach (Transform item in parent)
			{
				transforms.Add(item);
				GetAllChildren(item, ref transforms);
			}
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
			int num = i;
			string result = string.Concat(path + "_" + num, ".png");
			if (File.Exists(result))
			{
				num++;
				result = GetNewValidPath(path, num);
			}
			return result;
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnEditorUpdate()
		{
			if (!computingNormal)
			{
				return;
			}
			if (needToWait)
			{
				waitingCycles++;
				if (waitingCycles > 5)
				{
					needToWait = false;
					timesWeWaited++;
				}
				return;
			}
			if (timesWeWaited == 1)
			{
				SetNewNormalTexture2();
			}
			if (timesWeWaited == 2)
			{
				SetNewNormalTexture3();
			}
			if (timesWeWaited == 3)
			{
				SetNewNormalTexture4();
			}
			needToWait = true;
		}

		public void CreateAndAssignNormalMap()
		{
		}

		private void SetNewNormalTexture()
		{
			computingNormal = false;
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
