using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace AllIn1VfxToolkit
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[AddComponentMenu("AllIn1VfxToolkit/AddAllIn1Vfx")]
	public class AllIn1VfxComponent : MonoBehaviour
	{
		private enum AfterSetAction
		{
			Clear = 0,
			CopyMaterial = 1,
			Reset = 2
		}

		private Material currMaterial;

		private Material prevMaterial;

		private bool matAssigned;

		private bool destroyed;

		private void MakeNewMaterial(string shaderName = "AllIn1Vfx")
		{
			SetMaterial(AfterSetAction.Clear, shaderName);
		}

		public void MakeCopy()
		{
			if (!(currMaterial == null) || !FetchCurrentMaterial())
			{
				string text = currMaterial.shader.name;
				if (text.Contains("AllIn1Vfx/"))
				{
					text = text.Replace("AllIn1Vfx/", "");
				}
				SetMaterial(AfterSetAction.CopyMaterial, text);
			}
		}

		private bool FetchCurrentMaterial()
		{
			bool flag = false;
			Renderer component = GetComponent<Renderer>();
			if (component != null)
			{
				flag = true;
				currMaterial = component.sharedMaterial;
			}
			else
			{
				Graphic component2 = GetComponent<Graphic>();
				if (component2 != null)
				{
					flag = true;
					currMaterial = component2.material;
				}
			}
			if (!flag)
			{
				MissingRenderer();
				return true;
			}
			return false;
		}

		private void ResetAllProperties(string shaderName)
		{
			SetMaterial(AfterSetAction.Reset, shaderName);
		}

		private void SetMaterial(AfterSetAction action, string shaderName)
		{
			Shader shader = Resources.Load(shaderName, typeof(Shader)) as Shader;
			if (!Application.isPlaying && Application.isEditor && shader != null)
			{
				bool flag = false;
				if (GetComponent<Renderer>() != null)
				{
					flag = true;
					prevMaterial = new Material(GetComponent<Renderer>().sharedMaterial);
					currMaterial = new Material(shader);
					GetComponent<Renderer>().sharedMaterial = currMaterial;
					GetComponent<Renderer>().sharedMaterial.hideFlags = HideFlags.None;
					matAssigned = true;
					DoAfterSetAction(action);
				}
				else
				{
					Graphic component = GetComponent<Graphic>();
					if (component != null)
					{
						flag = true;
						prevMaterial = new Material(component.material);
						currMaterial = new Material(shader);
						component.material = currMaterial;
						component.material.hideFlags = HideFlags.None;
						matAssigned = true;
						DoAfterSetAction(action);
					}
				}
				if (!flag)
				{
					MissingRenderer();
				}
				else
				{
					SetSceneDirty();
				}
			}
			else if (shader == null)
			{
				Debug.LogError("Make sure the AllIn1Vfx shader variants are inside the Resource folder!   You looked for " + shaderName);
			}
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

		public void TryCreateNew()
		{
			bool flag = false;
			Renderer component = GetComponent<Renderer>();
			if (component != null)
			{
				flag = true;
				if (component != null && component.sharedMaterial != null && component.sharedMaterial.shader.name.Contains("Vfx"))
				{
					ResetAllProperties("AllIn1Vfx");
					ClearAllKeywords();
				}
				else
				{
					CleanMaterial();
					MakeNewMaterial();
				}
			}
			else
			{
				Graphic component2 = GetComponent<Graphic>();
				if (component2 != null)
				{
					flag = true;
					if (component2.material.shader.name.Contains("Vfx"))
					{
						ResetAllProperties("AllIn1Vfx");
						ClearAllKeywords();
					}
					else
					{
						MakeNewMaterial();
					}
				}
			}
			if (!flag)
			{
				MissingRenderer();
			}
			SetSceneDirty();
		}

		public void ClearAllKeywords()
		{
			SetKeyword("FOG_ON");
			SetKeyword("SCREENDISTORTION_ON");
			SetKeyword("DISTORTUSECOL_ON");
			SetKeyword("DISTORTONLYBACK_ON");
			SetKeyword("SHAPE1SCREENUV_ON");
			SetKeyword("SHAPE2SCREENUV_ON");
			SetKeyword("SHAPE3SCREENUV_ON");
			SetKeyword("SHAPEDEBUG_ON");
			SetKeyword("SHAPE1CONTRAST_ON");
			SetKeyword("SHAPE1DISTORT_ON");
			SetKeyword("SHAPE1ROTATE_ON");
			SetKeyword("SHAPE1SHAPECOLOR_ON");
			SetKeyword("SHAPE2_ON");
			SetKeyword("SHAPE2CONTRAST_ON");
			SetKeyword("SHAPE2DISTORT_ON");
			SetKeyword("SHAPE2ROTATE_ON");
			SetKeyword("SHAPE2SHAPECOLOR_");
			SetKeyword("SHAPE3_ON");
			SetKeyword("SHAPE3CONTRAST_ON");
			SetKeyword("SHAPE3DISTORT_ON");
			SetKeyword("SHAPE3ROTATE_ON");
			SetKeyword("SHAPE3SHAPECOLOR_");
			SetKeyword("GLOW_ON");
			SetKeyword("GLOWTEX_ON");
			SetKeyword("SOFTPART_ON");
			SetKeyword("DEPTHGLOW_ON");
			SetKeyword("MASK_ON");
			SetKeyword("COLORRAMP_ON");
			SetKeyword("COLORRAMPGRAD_ON");
			SetKeyword("COLORGRADING_ON");
			SetKeyword("HSV_ON");
			SetKeyword("BLUR_ON");
			SetKeyword("BLURISHD_ON");
			SetKeyword("POSTERIZE_ON");
			SetKeyword("FADE_ON");
			SetKeyword("FADEBURN_ON");
			SetKeyword("PIXELATE_ON");
			SetKeyword("DISTORT_ON");
			SetKeyword("SHAKEUV_ON");
			SetKeyword("WAVEUV_ON");
			SetKeyword("ROUNDWAVEUV_ON");
			SetKeyword("TWISTUV_ON");
			SetKeyword("DOODLE_ON");
			SetKeyword("OFFSETSTREAM_ON");
			SetKeyword("TEXTURESCROLL_ON");
			SetKeyword("VERTOFFSET_ON");
			SetKeyword("RIM_ON");
			SetKeyword("BACKFACETINT_ON");
			SetKeyword("POLARUV_ON");
			SetKeyword("POLARUVDISTORT_ON");
			SetKeyword("SHAPE1MASK_ON");
			SetKeyword("TRAILWIDTH_ON");
			SetKeyword("LIGHTANDSHADOW_ON");
			SetKeyword("SHAPETEXOFFSET_ON");
			SetKeyword("SHAPEWEIGHTS_ON");
			SetKeyword("ALPHACUTOFF_ON");
			SetKeyword("ALPHASMOOTHSTEP_ON");
			SetKeyword("ALPHAFADE_ON");
			SetKeyword("ALPHAFADEUSESHAPE1_");
			SetKeyword("ALPHAFADEUSEREDCHAN");
			SetKeyword("ALPHAFADETRANSPAREN");
			SetKeyword("ALPHAFADEINPUTSTREA");
			SetKeyword("CAMDISTFADE_ON");
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
				matAssigned = true;
				return;
			}
			Graphic component = GetComponent<Graphic>();
			if (component != null)
			{
				currMaterial = component.material;
				matAssigned = true;
			}
		}

		public void CleanMaterial()
		{
			Renderer component = GetComponent<Renderer>();
			if (component != null)
			{
				component.sharedMaterial = new Material(Shader.Find("Sprites/Default"));
				matAssigned = false;
			}
			else
			{
				Graphic component2 = GetComponent<Graphic>();
				if (component2 != null)
				{
					component2.material = new Material(Shader.Find("Sprites/Default"));
					matAssigned = false;
				}
			}
			SetSceneDirty();
		}

		public void SaveMaterial()
		{
		}

		private void SaveMaterialWithOtherName(string path, int i = 1)
		{
			int num = i;
			string text = string.Concat(path + "_" + num, ".mat");
			if (File.Exists(text))
			{
				num++;
				SaveMaterialWithOtherName(path, num);
			}
			else
			{
				DoSaving(text);
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
	}
}
