using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Customization.Paint
{
	public class TrainCarPaint : MonoBehaviour
	{
		[Serializable]
		public class MaterialSet
		{
			[SerializeField]
			private Material originalMaterial;

			public RendererMaterialReplacement[] renderers = Array.Empty<RendererMaterialReplacement>();

			public Material OriginalMaterial => originalMaterial;

			public void ApplyMaterial(Material material)
			{
				RendererMaterialReplacement[] array = renderers;
				foreach (RendererMaterialReplacement rendererMaterialReplacement in array)
				{
					rendererMaterialReplacement.Set(material);
				}
			}
		}

		[Serializable]
		public struct RendererMaterialReplacement
		{
			public Renderer renderer;

			public int materialIndex;

			public RendererMaterialReplacement(Renderer renderer, int materialIndex)
			{
				this.renderer = renderer;
				this.materialIndex = materialIndex;
			}

			public void Set(Material material)
			{
				Material[] sharedMaterials = renderer.sharedMaterials;
				sharedMaterials[materialIndex] = material;
				renderer.sharedMaterials = sharedMaterials;
			}
		}

		public enum Target : byte
		{
			Exterior = 0,
			Interior = 1
		}

		[SerializeField]
		private PaintTheme currentTheme;

		[SerializeField]
		private Target targetArea;

		[SerializeField]
		private MaterialSet[] sets;

		private bool hasChangedWhileDisabled;

		private TrainCar car;

		public Target TargetArea => targetArea;

		public PaintTheme OriginallyAssignedTheme { get; private set; }

		public PaintTheme CurrentTheme
		{
			get
			{
				return currentTheme;
			}
			set
			{
				if (value == null)
				{
					Debug.LogError("[PAINT] Cannot set a null theme!");
				}
				else if (!(currentTheme == value))
				{
					currentTheme = value;
					if (!base.enabled)
					{
						hasChangedWhileDisabled = true;
						return;
					}
					UpdateTheme();
					this.OnThemeChanged?.Invoke(this);
				}
			}
		}

		public event Action<TrainCarPaint> OnThemeChanged;

		public bool IsSupported(PaintTheme theme)
		{
			if (!theme.Allows(car.carLivery))
			{
				return false;
			}
			MaterialSet[] array = sets;
			foreach (MaterialSet materialSet in array)
			{
				if (theme.HasSubstituteFor(materialSet.OriginalMaterial))
				{
					return true;
				}
			}
			return false;
		}

		private void Awake()
		{
			OriginallyAssignedTheme = currentTheme;
			car = GetComponent<TrainCar>();
		}

		private void Start()
		{
			UpdateTheme();
		}

		private void OnEnable()
		{
			if (hasChangedWhileDisabled)
			{
				UpdateTheme();
				this.OnThemeChanged?.Invoke(this);
			}
		}

		private void UpdateTheme()
		{
			hasChangedWhileDisabled = false;
			if (currentTheme == null)
			{
				Debug.LogError("[PAINT] No initial paint theme assigned!");
				return;
			}
			MaterialSet[] array = sets;
			foreach (MaterialSet materialSet in array)
			{
				materialSet.ApplyMaterial((currentTheme.TryGetSubstitute(materialSet.OriginalMaterial, out var substitution) && substitution.substitute != null) ? substitution.substitute : materialSet.OriginalMaterial);
			}
		}

		public void SetupRenderersUsingOriginalMaterials()
		{
			List<RendererMaterialReplacement> list = new List<RendererMaterialReplacement>();
			Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
			MaterialSet[] array = sets;
			foreach (MaterialSet materialSet in array)
			{
				list.Clear();
				Renderer[] array2 = componentsInChildren;
				foreach (Renderer renderer in array2)
				{
					Material[] sharedMaterials = renderer.sharedMaterials;
					for (int k = 0; k < sharedMaterials.Length; k++)
					{
						if (sharedMaterials[k] == materialSet.OriginalMaterial)
						{
							list.Add(new RendererMaterialReplacement(renderer, k));
						}
					}
				}
				materialSet.renderers = list.ToArray();
			}
		}
	}
}
