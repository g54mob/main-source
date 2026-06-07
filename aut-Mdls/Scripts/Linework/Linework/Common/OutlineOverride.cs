using System.Collections.Generic;
using UnityEngine;

namespace Linework.Common
{
	[RequireComponent(typeof(Renderer))]
	public class OutlineOverride : MonoBehaviour
	{
		public List<ShaderPropertyOverride> overrides = new List<ShaderPropertyOverride>();

		private MaterialPropertyBlock propertyBlock;

		public void AddFloatOverride(string propertyName, float value)
		{
			overrides.Add(new ShaderPropertyOverride
			{
				type = ShaderPropertyType.Float,
				propertyName = propertyName,
				floatValue = value
			});
		}

		public void AddIntOverride(string propertyName, int value)
		{
			overrides.Add(new ShaderPropertyOverride
			{
				type = ShaderPropertyType.Int,
				propertyName = propertyName,
				intValue = value
			});
		}

		public void AddColorOverride(string propertyName, Color color)
		{
			overrides.Add(new ShaderPropertyOverride
			{
				type = ShaderPropertyType.Color,
				propertyName = propertyName,
				colorValue = color
			});
		}

		public void AddVectorOverride(string propertyName, Vector4 value)
		{
			overrides.Add(new ShaderPropertyOverride
			{
				type = ShaderPropertyType.Vector,
				propertyName = propertyName,
				vectorValue = value
			});
		}

		private void Start()
		{
			SetOverrides();
		}

		private void OnValidate()
		{
			SetOverrides();
		}

		private void SetOverrides()
		{
			Renderer component = GetComponent<Renderer>();
			if (!base.enabled)
			{
				component.SetPropertyBlock(null);
				return;
			}
			if (propertyBlock == null)
			{
				propertyBlock = new MaterialPropertyBlock();
			}
			propertyBlock.Clear();
			foreach (ShaderPropertyOverride @override in overrides)
			{
				@override.CachePropertyID();
				switch (@override.type)
				{
				case ShaderPropertyType.Float:
					propertyBlock.SetFloat(@override.propertyId, @override.floatValue);
					break;
				case ShaderPropertyType.Int:
					propertyBlock.SetInt(@override.propertyId, @override.intValue);
					break;
				case ShaderPropertyType.Vector:
					propertyBlock.SetVector(@override.propertyId, @override.vectorValue);
					break;
				case ShaderPropertyType.Color:
					propertyBlock.SetColor(@override.propertyId, @override.colorValue);
					break;
				default:
					Debug.LogWarning($"Unsupported shader property type: {@override.type}");
					break;
				}
			}
			component.SetPropertyBlock(propertyBlock);
		}
	}
}
