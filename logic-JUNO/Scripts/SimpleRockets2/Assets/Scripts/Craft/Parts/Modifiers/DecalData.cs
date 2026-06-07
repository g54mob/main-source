using System;
using System.Collections.Generic;
using System.Linq;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Craft.Parts.Decals;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Decal")]
	[PartModifierTypeId("Decal")]
	public class DecalData : PartModifierData<DecalScript>
	{
		[SerializeField]
		[DesignerPropertySpinner(Label = "Material 3", Order = 90, Tooltip = "The third part material trim level assigned to the texture. This is assigned to the blue channel of the decal texture.")]
		private PartMeshMaterialLevel _materialB = PartMeshMaterialLevel.Trim3;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Material 2", Order = 80, Tooltip = "The second part material trim level assigned to the texture. This is assigned to the green channel of the decal texture.")]
		private PartMeshMaterialLevel _materialG = PartMeshMaterialLevel.Trim2;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Material 1", Order = 70, Tooltip = "The first part material trim level assigned to the texture. This is assigned to the red channel of the decal texture.")]
		private PartMeshMaterialLevel _materialR = PartMeshMaterialLevel.Trim1;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Material", Order = 70, Tooltip = "The part material trim level used to paint the part when the source color option is enabled. Painting the part won't affect the color, but it does apply the other material settings.")]
		private PartMeshMaterialLevel _materialSourceColor = PartMeshMaterialLevel.Trim1;

		[SerializeField]
		[DesignerPropertySpinner(-1f, 1f, 0.05f, Label = "Offset X", AllowManualInput = true, ValidateManualInput = false, Order = 20, Tooltip = "The offset of the decal texture on the x-axis.")]
		private float _offsetX;

		[SerializeField]
		[DesignerPropertySpinner(-1f, 1f, 0.05f, Label = "Offset Y", AllowManualInput = true, ValidateManualInput = false, Order = 30, Tooltip = "The offset of the decal texture on the y-axis.")]
		private float _offsetY;

		[SerializeField]
		[DesignerPropertySpinner(new string[] { "None" }, Label = "Decal", Order = 10, Tooltip = "The decal texture to use.")]
		private string _path = "None";

		[SerializeField]
		[DesignerPropertySpinner(0f, 5f, 0.05f, Label = "Tiling X", AllowManualInput = true, ValidateManualInput = false, Order = 40, Tooltip = "The tiling of the decal texture on the x-axis.")]
		private float _tilingX = 1f;

		[SerializeField]
		[DesignerPropertySpinner(0f, 5f, 0.05f, Label = "Tiling Y", AllowManualInput = true, ValidateManualInput = false, Order = 50, Tooltip = "The tiling of the decal texture on the y-axis.")]
		private float _tilingY = 1f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Use Source Color", Order = 60, Tooltip = "If enabled, the source color of the texture will be used as is rather than as a part material mask.")]
		private bool _useSourceColor;

		public PartMeshMaterialLevel MaterialB
		{
			get
			{
				return _materialB;
			}
			set
			{
				_materialB = value;
			}
		}

		public PartMeshMaterialLevel MaterialG
		{
			get
			{
				return _materialG;
			}
			set
			{
				_materialG = value;
			}
		}

		public PartMeshMaterialLevel MaterialR
		{
			get
			{
				return _materialR;
			}
			set
			{
				_materialR = value;
			}
		}

		public PartMeshMaterialLevel MaterialSourceColor
		{
			get
			{
				return _materialSourceColor;
			}
			set
			{
				_materialSourceColor = value;
			}
		}

		public float OffsetX
		{
			get
			{
				return _offsetX;
			}
			set
			{
				_offsetX = value;
			}
		}

		public float OffsetY
		{
			get
			{
				return _offsetY;
			}
			set
			{
				_offsetY = value;
			}
		}

		public string Path
		{
			get
			{
				return _path;
			}
			set
			{
				_path = value;
			}
		}

		public float TilingX
		{
			get
			{
				return _tilingX;
			}
			set
			{
				_tilingX = value;
			}
		}

		public float TilingY
		{
			get
			{
				return _tilingY;
			}
			set
			{
				_tilingY = value;
			}
		}

		public bool UseSourceColor
		{
			get
			{
				return _useSourceColor;
			}
			set
			{
				_useSourceColor = value;
			}
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.OnDesignerInitialization(d);
			d.OnSpinnerValuesRequested(() => _path, GetPaths);
			d.OnValueLabelRequested(() => _path, GetDisplayName);
			d.OnPropertyChanged(() => _path, delegate
			{
				OnDecalChanged();
			});
			d.OnPropertyChanged(() => _offsetX, delegate
			{
				OnDecalChanged();
			});
			d.OnPropertyChanged(() => _offsetY, delegate
			{
				OnDecalChanged();
			});
			d.OnPropertyChanged(() => _tilingX, delegate
			{
				OnDecalChanged();
			});
			d.OnPropertyChanged(() => _tilingY, delegate
			{
				OnDecalChanged();
			});
			d.OnPropertyChanged(() => _useSourceColor, delegate
			{
				OnDecalChanged();
			});
			d.OnPropertyChanged(() => _materialSourceColor, delegate
			{
				OnDecalChanged();
			});
			d.OnPropertyChanged(() => _materialR, delegate
			{
				OnDecalChanged();
			});
			d.OnPropertyChanged(() => _materialG, delegate
			{
				OnDecalChanged();
			});
			d.OnPropertyChanged(() => _materialB, delegate
			{
				OnDecalChanged();
			});
			d.OnVisibilityRequested(() => _materialR, (bool showHidden) => !_useSourceColor);
			d.OnVisibilityRequested(() => _materialG, (bool showHidden) => !_useSourceColor);
			d.OnVisibilityRequested(() => _materialB, (bool showHidden) => !_useSourceColor);
			d.OnVisibilityRequested(() => _materialSourceColor, (bool showHidden) => _useSourceColor);
		}

		private string GetDisplayName(string path)
		{
			if (string.IsNullOrWhiteSpace(path) || path == "None")
			{
				return "None";
			}
			return Game.Instance.PartDecalManager.GetDecal(path, logError: true)?.DisplayName ?? "Unknown";
		}

		private void GetPaths(List<string> decalPaths)
		{
			decalPaths.AddRange(from x in Game.Instance.PartDecalManager.Decals
				where !x.IsHidden
				select x.Path);
		}

		private void OnDecalChanged()
		{
			base.Script.ApplyDecalTexture();
		}
	}
}
