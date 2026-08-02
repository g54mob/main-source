using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUIMaterialProvider : GPUIDataProvider<int, Material>
	{
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
			int num = originalMat.GetInstanceID() + ((!string.IsNullOrEmpty(extensionCode)) ? extensionCode.GetHashCode() : 0);
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
					int key = num + string.Concat(keywords).GetHashCode();
					if (TryGetData(key, out var result2))
					{
						if (!(result2 == null) && !(result2.shader == null) && !(result2.shader == GPUIConstants.ShaderUnityInternalError))
						{
							replacementMat = result2;
							return true;
						}
						_dataDict.Remove(key);
					}
					result2 = result.CopyWithShader(result.shader);
					foreach (string keyword in keywords)
					{
						result2.EnableKeyword(keyword);
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
			return false;
		}
	}
}
