using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UniGLTF;
using UnityEngine;

namespace VRM
{
	internal class MaterialValueBindingMerger
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct DictionaryKeyMaterialValueBindingComparer : IEqualityComparer<MaterialValueBinding>
		{
			public bool Equals(MaterialValueBinding x, MaterialValueBinding y)
			{
				if (x.TargetValue == y.TargetValue && x.BaseValue == y.BaseValue && x.MaterialName == y.MaterialName)
				{
					return x.ValueName == y.ValueName;
				}
				return false;
			}

			public int GetHashCode(MaterialValueBinding obj)
			{
				return obj.GetHashCode();
			}
		}

		private delegate void Setter(float value, bool firstValue);

		private struct MaterialTarget : IEquatable<MaterialTarget>
		{
			public string MaterialName;

			public string ValueName;

			public bool Equals(MaterialTarget other)
			{
				if (MaterialName == other.MaterialName)
				{
					return ValueName == other.ValueName;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is MaterialTarget)
				{
					return Equals((MaterialTarget)obj);
				}
				return false;
			}

			public override int GetHashCode()
			{
				if (MaterialName == null || ValueName == null)
				{
					return 0;
				}
				return MaterialName.GetHashCode() + ValueName.GetHashCode();
			}

			public static MaterialTarget Create(MaterialValueBinding binding)
			{
				return new MaterialTarget
				{
					MaterialName = binding.MaterialName,
					ValueName = binding.ValueName
				};
			}
		}

		private static DictionaryKeyMaterialValueBindingComparer comparer;

		private Dictionary<string, Material> m_materialMap = new Dictionary<string, Material>();

		private Dictionary<MaterialValueBinding, float> m_materialValueMap = new Dictionary<MaterialValueBinding, float>(comparer);

		private Dictionary<MaterialValueBinding, Setter> m_materialSetterMap = new Dictionary<MaterialValueBinding, Setter>(comparer);

		private HashSet<MaterialTarget> m_used = new HashSet<MaterialTarget>();

		public MaterialValueBindingMerger(Dictionary<BlendShapeKey, BlendShapeClip> clipMap, Transform root)
		{
			foreach (Transform item in root.Traverse())
			{
				Renderer component = item.GetComponent<Renderer>();
				if (!(component != null))
				{
					continue;
				}
				foreach (Material item2 in component.sharedMaterials.Where((Material y) => y != null))
				{
					if (!string.IsNullOrEmpty(item2.name) && !m_materialMap.ContainsKey(item2.name))
					{
						m_materialMap.Add(item2.name, item2);
					}
				}
			}
			foreach (KeyValuePair<BlendShapeKey, BlendShapeClip> item3 in clipMap)
			{
				MaterialValueBinding[] materialValues = item3.Value.MaterialValues;
				for (int num = 0; num < materialValues.Length; num++)
				{
					MaterialValueBinding binding = materialValues[num];
					if (m_materialSetterMap.ContainsKey(binding))
					{
						continue;
					}
					if (m_materialMap.TryGetValue(binding.MaterialName, out var target))
					{
						if (binding.ValueName.EndsWith("_ST_S"))
						{
							string valueName = binding.ValueName.Substring(0, binding.ValueName.Length - 2);
							Setter value = delegate(float num2, bool firstValue)
							{
								Vector4 vector = (firstValue ? (binding.BaseValue + (binding.TargetValue - binding.BaseValue) * num2) : (target.GetVector(valueName) + (binding.TargetValue - binding.BaseValue) * num2));
								Vector4 vector2 = target.GetVector(valueName);
								vector2.x = vector.x;
								vector2.z = vector.z;
								target.SetVector(valueName, vector2);
							};
							m_materialSetterMap.Add(binding, value);
						}
						else if (binding.ValueName.EndsWith("_ST_T"))
						{
							string valueName2 = binding.ValueName.Substring(0, binding.ValueName.Length - 2);
							Setter value2 = delegate(float num2, bool firstValue)
							{
								Vector4 vector = (firstValue ? (binding.BaseValue + (binding.TargetValue - binding.BaseValue) * num2) : (target.GetVector(valueName2) + (binding.TargetValue - binding.BaseValue) * num2));
								Vector4 vector2 = target.GetVector(valueName2);
								vector2.y = vector.y;
								vector2.w = vector.w;
								target.SetVector(valueName2, vector2);
							};
							m_materialSetterMap.Add(binding, value2);
						}
						else
						{
							Setter value3 = delegate(float num2, bool firstValue)
							{
								Vector4 vector = (firstValue ? (binding.BaseValue + (binding.TargetValue - binding.BaseValue) * num2) : (target.GetVector(binding.ValueName) + (binding.TargetValue - binding.BaseValue) * num2));
								target.SetColor(binding.ValueName, vector);
							};
							m_materialSetterMap.Add(binding, value3);
						}
					}
					else
					{
						Debug.LogWarningFormat("material: {0} not found", binding.MaterialName);
					}
				}
			}
		}

		public void RestoreMaterialInitialValues(IEnumerable<BlendShapeClip> clips)
		{
			if (m_materialMap == null)
			{
				return;
			}
			foreach (BlendShapeClip clip in clips)
			{
				MaterialValueBinding[] materialValues = clip.MaterialValues;
				for (int i = 0; i < materialValues.Length; i++)
				{
					MaterialValueBinding materialValueBinding = materialValues[i];
					if (m_materialMap.TryGetValue(materialValueBinding.MaterialName, out var _))
					{
						string valueName = materialValueBinding.ValueName;
						if (valueName.EndsWith("_ST_S") || valueName.EndsWith("_ST_T"))
						{
							valueName = valueName.Substring(0, valueName.Length - 2);
						}
					}
					else
					{
						Debug.LogWarningFormat("{0} not found", materialValueBinding.MaterialName);
					}
				}
			}
		}

		public void ImmediatelySetValue(BlendShapeClip clip, float value)
		{
			MaterialValueBinding[] materialValues = clip.MaterialValues;
			foreach (MaterialValueBinding key in materialValues)
			{
				if (m_materialSetterMap.TryGetValue(key, out var value2))
				{
					value2(value, firstValue: true);
				}
			}
		}

		public void AccumulateValue(BlendShapeClip clip, float value)
		{
			MaterialValueBinding[] materialValues = clip.MaterialValues;
			foreach (MaterialValueBinding key in materialValues)
			{
				if (m_materialValueMap.TryGetValue(key, out var value2))
				{
					m_materialValueMap[key] = value2 + value;
				}
				else
				{
					m_materialValueMap[key] = value;
				}
			}
		}

		public void Apply()
		{
			m_used.Clear();
			foreach (KeyValuePair<MaterialValueBinding, float> item2 in m_materialValueMap)
			{
				MaterialTarget item = MaterialTarget.Create(item2.Key);
				if (!m_used.Contains(item))
				{
					if (m_materialMap.TryGetValue(item.MaterialName, out var value))
					{
						Vector4 baseValue = item2.Key.BaseValue;
						string text = item.ValueName;
						if (text.EndsWith("_ST_S"))
						{
							text = text.Substring(0, text.Length - 2);
							Vector4 vector = value.GetVector(text);
							baseValue.y = vector.y;
							baseValue.w = vector.w;
						}
						else if (text.EndsWith("_ST_T"))
						{
							text = text.Substring(0, text.Length - 2);
							Vector4 vector2 = value.GetVector(text);
							baseValue.x = vector2.x;
							baseValue.z = vector2.z;
						}
						value.SetColor(text, baseValue);
					}
					m_used.Add(item);
				}
				if (m_materialSetterMap.TryGetValue(item2.Key, out var value2))
				{
					value2(item2.Value, firstValue: false);
				}
			}
			m_materialValueMap.Clear();
		}
	}
}
