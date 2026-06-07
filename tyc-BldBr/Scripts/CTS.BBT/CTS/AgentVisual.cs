using System.Collections.Generic;
using CTS.Core.Pooling;
using UnityEngine;
using UnityEngine.Rendering;

namespace CTS
{
	public class AgentVisual : MonoBehaviour, IPoolCallbackReceiver
	{
		private HashSet<Renderer> _renderers = new HashSet<Renderer>();

		private readonly Dictionary<Renderer, Material[]> _originalMaterials = new Dictionary<Renderer, Material[]>();

		public static Shader ToonShader;

		public bool IsMaterialOverriden { get; private set; }

		public Material EyesMaterial { get; set; }

		public static LocalKeyword Keyword(string name)
		{
			return new LocalKeyword(ToonShader, name);
		}

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
			ToonShader = Shader.Find("CTS/Toon Lit");
		}

		public void ClearRenderers()
		{
			SetOverrideMaterial(null);
			_renderers.Clear();
			_originalMaterials.Clear();
			EyesMaterial = null;
		}

		public void AddRenderers(Renderer[] renderers)
		{
			foreach (Renderer renderer in renderers)
			{
				AddRenderer(renderer);
			}
		}

		public void AddRenderer(Renderer renderer)
		{
			if (_renderers.Add(renderer))
			{
				Material[] value = (renderer.materials = renderer.materials);
				_originalMaterials[renderer] = value;
			}
		}

		public void SetOverrideMaterial(Material material)
		{
			if (material == null)
			{
				if (!IsMaterialOverriden)
				{
					return;
				}
				IsMaterialOverriden = false;
				{
					foreach (Renderer renderer in _renderers)
					{
						if (_originalMaterials.TryGetValue(renderer, out var value))
						{
							renderer.materials = value;
						}
					}
					return;
				}
			}
			IsMaterialOverriden = true;
			foreach (Renderer renderer2 in _renderers)
			{
				Material[] materials = renderer2.materials;
				for (int i = 0; i < materials.Length; i++)
				{
					materials[i] = material;
				}
				renderer2.materials = materials;
			}
		}

		public void SetKeyword(in LocalKeyword keyword, bool value)
		{
			foreach (Material[] value2 in _originalMaterials.Values)
			{
				foreach (Material material in value2)
				{
					if (!(material.shader != ToonShader))
					{
						material.SetKeyword(in keyword, value);
					}
				}
			}
		}

		public void SetFloat(int nameId, float value)
		{
			foreach (Material[] value2 in _originalMaterials.Values)
			{
				for (int i = 0; i < value2.Length; i++)
				{
					value2[i].SetFloat(nameId, value);
				}
			}
		}

		public void SetVector(int nameId, Vector4 value)
		{
			foreach (Material[] value2 in _originalMaterials.Values)
			{
				for (int i = 0; i < value2.Length; i++)
				{
					value2[i].SetVector(nameId, value);
				}
			}
		}

		public void SetColor(int var, Color color)
		{
			foreach (Material[] value in _originalMaterials.Values)
			{
				for (int i = 0; i < value.Length; i++)
				{
					value[i].SetColor(var, color);
				}
			}
		}

		void IPoolCallbackReceiver.OnPulled()
		{
		}

		void IPoolCallbackReceiver.OnPushed()
		{
			ClearRenderers();
		}
	}
}
