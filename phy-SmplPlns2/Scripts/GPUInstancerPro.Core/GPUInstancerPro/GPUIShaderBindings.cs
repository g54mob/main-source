using System;
using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUIShaderBindings : ScriptableObject
	{
		public static readonly string GPUI_REPLACEMENT_MATERIAL_NAME_SUFFIX = "_GPUIReplacement";

		[SerializeField]
		public List<GPUIShaderInstance> shaderInstances;

		[SerializeField]
		public bool stripObjectMotionVectorVariants;

		[SerializeField]
		public bool stripPerInstanceLightProbeVariants;

		private static GPUIShaderBindings _instance;

		private Shader _errorShader;

		private Material _errorMaterial;

		public static GPUIShaderBindings Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = GetDefaultShaderBindings();
				}
				return _instance;
			}
			set
			{
				_instance = value;
			}
		}

		public Shader ErrorShader
		{
			get
			{
				if (_errorShader == null)
				{
					_errorShader = GPUIUtility.FindShader("Hidden/GPUInstancerPro/InternalErrorShader");
				}
				return _errorShader;
			}
		}

		public Material ErrorMaterial
		{
			get
			{
				if (_errorMaterial == null && ErrorShader != null)
				{
					_errorMaterial = new Material(ErrorShader);
					_errorMaterial.name = "GPUIInternalErrorMaterial";
				}
				return _errorMaterial;
			}
		}

		public static GPUIShaderBindings GetDefaultShaderBindings()
		{
			GPUIShaderBindings gPUIShaderBindings = GPUIUtility.LoadResource<GPUIShaderBindings>("GPUIShaderBindings");
			if (gPUIShaderBindings == null)
			{
				gPUIShaderBindings = ScriptableObject.CreateInstance<GPUIShaderBindings>();
			}
			return gPUIShaderBindings;
		}

		public bool IsShaderSetupForGPUI(Shader shader, string extensionCode)
		{
			if (shader != null)
			{
				return IsShaderSetupForGPUI(shader.name, extensionCode);
			}
			return false;
		}

		public bool IsShaderSetupForGPUI(string shaderName, string extensionCode)
		{
			foreach (GPUIShaderInstance shaderInstance in shaderInstances)
			{
				if ((shaderInstance.shaderName.Equals(shaderName) || shaderInstance.replacementShaderName.Equals(shaderName)) && IsExtensionEqual(shaderInstance, extensionCode))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsShaderSetupForGPUIAnyExtension(string shaderName)
		{
			if (string.IsNullOrEmpty(shaderName))
			{
				return false;
			}
			foreach (GPUIShaderInstance shaderInstance in shaderInstances)
			{
				if (shaderInstance.shaderName.Equals(shaderName) || shaderInstance.replacementShaderName.Equals(shaderName))
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetInstancedShader(Shader shader, string extensionCode, out Shader resultShader)
		{
			resultShader = ErrorShader;
			if (shader != null)
			{
				return GetInstancedShader(shader.name, extensionCode, out resultShader);
			}
			return false;
		}

		public virtual bool GetInstancedShader(string shaderName, string extensionCode, out Shader resultShader)
		{
			ClearEmptyShaderInstances();
			resultShader = ErrorShader;
			if (string.IsNullOrEmpty(shaderName))
			{
				return false;
			}
			if (shaderInstances == null)
			{
				shaderInstances = new List<GPUIShaderInstance>();
			}
			foreach (GPUIShaderInstance shaderInstance in shaderInstances)
			{
				if ((shaderInstance.shaderName.Equals(shaderName) || shaderInstance.replacementShaderName.Equals(shaderName)) && IsExtensionEqual(shaderInstance, extensionCode))
				{
					resultShader = shaderInstance.replacementShader;
					return true;
				}
			}
			if (shaderName.Contains("GPUInstancerPro"))
			{
				shaderName = shaderName.Replace("GPUInstancerPro/", "").Replace("GPUInstancerPro/CrowdAnimations/", "");
				foreach (GPUIShaderInstance shaderInstance2 in shaderInstances)
				{
					if ((shaderInstance2.shaderName.Equals(shaderName) || shaderInstance2.replacementShaderName.Equals(shaderName)) && IsExtensionEqual(shaderInstance2, extensionCode))
					{
						resultShader = shaderInstance2.replacementShader;
						return true;
					}
				}
			}
			Shader shader = Shader.Find(GPUIUtility.ConvertToGPUIShaderName(shaderName, extensionCode));
			if (shader != null)
			{
				AddShaderInstance(shaderName, shader, extensionCode);
				resultShader = shader;
				return true;
			}
			return false;
		}

		public virtual bool GetInstancedMaterial(Material originalMaterial, string extensionCode, out Material replacementMat)
		{
			replacementMat = ErrorMaterial;
			if (originalMaterial == null || originalMaterial.shader == null)
			{
				if (Application.isPlaying)
				{
					Debug.LogWarning(GPUIConstants.LOG_PREFIX + "One of the GPUI Renderers is missing material reference! Check the Material references in MeshRenderer.");
				}
				return false;
			}
			if (GetInstancedShader(originalMaterial.shader, extensionCode, out var resultShader) && resultShader != null)
			{
				if (originalMaterial.shader == resultShader)
				{
					replacementMat = originalMaterial;
				}
				else
				{
					replacementMat = originalMaterial.CopyWithShader(resultShader);
				}
				return true;
			}
			return false;
		}

		public void AddShaderInstance(string shaderName, Shader replacementShader, string extensionCode, bool isUseOriginal = false)
		{
			if (shaderInstances == null)
			{
				shaderInstances = new List<GPUIShaderInstance>();
			}
			if (shaderName == "Hidden/InternalErrorShader")
			{
				return;
			}
			for (int i = 0; i < shaderInstances.Count; i++)
			{
				if (shaderInstances[i].shaderName == shaderName && IsExtensionEqual(shaderInstances[i], extensionCode))
				{
					Debug.LogWarning(GPUIConstants.LOG_PREFIX + "Shader Instance already exists for shader: " + shaderName);
					return;
				}
			}
			shaderInstances.Add(new GPUIShaderInstance
			{
				shaderName = shaderName,
				replacementShaderName = replacementShader.name,
				extensionCode = extensionCode,
				isUseOriginal = isUseOriginal,
				modifiedDate = DateTime.Now.ToDateString()
			});
		}

		public virtual void ClearEmptyShaderInstances()
		{
			if (shaderInstances == null)
			{
				return;
			}
			for (int num = shaderInstances.Count - 1; num >= 0; num--)
			{
				GPUIShaderInstance gPUIShaderInstance = shaderInstances[num];
				if (gPUIShaderInstance != null)
				{
					Shader originalShader = gPUIShaderInstance.originalShader;
					Shader replacementShader = gPUIShaderInstance.replacementShader;
					if (originalShader != null && originalShader.name != "Hidden/InternalErrorShader" && replacementShader != null && replacementShader.name != "Hidden/InternalErrorShader")
					{
						continue;
					}
				}
				shaderInstances.RemoveAt(num);
			}
		}

		public static bool IsExtensionEqual(GPUIShaderInstance shaderInstance, string extensionCode)
		{
			if (!string.IsNullOrEmpty(extensionCode) || !string.IsNullOrEmpty(shaderInstance.extensionCode))
			{
				return extensionCode?.Equals(shaderInstance.extensionCode) ?? false;
			}
			return true;
		}
	}
}
