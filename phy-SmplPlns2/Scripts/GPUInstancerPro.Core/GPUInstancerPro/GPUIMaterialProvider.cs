using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUIMaterialProvider : GPUIDataProvider<int, Material>
	{
		private List<Shader> _missingBuildShaders;

		public override void Initialize()
		{
			base.Initialize();
		}

		public override void Dispose()
		{
			if (_dataDict != null)
			{
				foreach (Material value in _dataDict.Values)
				{
					if (value != null && value.name.EndsWith(GPUIShaderBindings.GPUI_REPLACEMENT_MATERIAL_NAME_SUFFIX))
					{
						value.DestroyGeneric();
					}
				}
			}
			base.Dispose();
		}

		public bool TryGetReplacementMaterial(Material originalMat, List<string> keywords, string extensionCode, out Material replacementMat)
		{
			replacementMat = GPUIShaderBindings.Instance.ErrorMaterial;
			if (!base.IsInitialized || originalMat == null || originalMat.shader == null)
			{
				return false;
			}
			int num = originalMat.GetInstanceID();
			if (!string.IsNullOrEmpty(extensionCode))
			{
				num = GPUIUtility.GenerateHash(num, extensionCode.GetHashCode());
			}
			if (TryGetData(num, out var result))
			{
				if (!(result == null) && !(result.shader == null) && !(result.shader == GPUIConstants.ShaderUnityInternalError))
				{
					if (keywords == null || keywords.Count == 0)
					{
						replacementMat = result;
						return true;
					}
					keywords.Sort();
					int key = GPUIUtility.GenerateHash(num, string.Concat(keywords).GetHashCode());
					if (TryGetData(key, out var result2))
					{
						if (!(result2 == null) && !(result2.shader == null) && !(result2.shader == GPUIConstants.ShaderUnityInternalError))
						{
							replacementMat = result2;
							return true;
						}
						_dataDict.Remove(key);
					}
					bool flag = true;
					foreach (string keyword in keywords)
					{
						if (!result.IsKeywordEnabled(keyword))
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						result2 = result;
					}
					else
					{
						result2 = result.CopyWithShader(result.shader);
						foreach (string keyword2 in keywords)
						{
							result2.EnableKeyword(keyword2);
						}
					}
					_dataDict.Add(key, result2);
					replacementMat = result2;
					return true;
				}
				_dataDict.Remove(num);
			}
			if (GPUIShaderBindings.Instance.GetInstancedMaterial(originalMat, extensionCode, out replacementMat))
			{
				_dataDict.Add(num, replacementMat);
				if (keywords != null && keywords.Count > 0)
				{
					return TryGetReplacementMaterial(originalMat, keywords, extensionCode, out replacementMat);
				}
				return true;
			}
			if (_missingBuildShaders == null)
			{
				_missingBuildShaders = new List<Shader>();
			}
			if (!_missingBuildShaders.Contains(originalMat.shader))
			{
				_missingBuildShaders.Add(originalMat.shader);
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find GPU Instancer Pro setup for shader: " + originalMat.shader.name);
			}
			return false;
		}
	}
}
