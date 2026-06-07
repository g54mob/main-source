using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class DragVisualizationTool
	{
		public enum DragShadingStyle
		{
			Surfaces = 0,
			PerPart = 1
		}

		private static class ShaderPropertyIds
		{
			public static readonly int DragDirection = Shader.PropertyToID("_DragDirection");

			public static readonly int DragValue = Shader.PropertyToID("_DragValue");

			public static readonly int DragVisualizationThreshold = Shader.PropertyToID("_DragVisualizationThreshold");
		}

		public const bool UseLegacyDragVisualizerForLegacyCraft = false;

		private Designer _designer;

		private Vector3 _dragDirection = Vector3.forward;

		private Dictionary<int, Material> _dragMaterials;

		private bool _enabled;

		private PartDrag.DragDirection? _lastDragUpdateDirection;

		private bool _legacyDragModel;

		private float _maxDragThreshold = 0.5f;

		private Material _partDragLegacyMaterial;

		private Material _partDragMaterial;

		private DragShadingStyle _shadingStyle;

		private bool _updateDrag = true;

		public float DragCount { get; private set; }

		public Vector3 DragDirection
		{
			get
			{
				return _dragDirection;
			}
			set
			{
				if (_dragDirection != value)
				{
					_dragDirection = value;
					UpdateAllMaterials();
					RefreshDragVisualization();
				}
			}
		}

		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				if (_enabled != value)
				{
					_enabled = value;
					if (_enabled)
					{
						Start();
					}
					else
					{
						Stop();
					}
				}
			}
		}

		public bool LegacyDragModel => _legacyDragModel;

		public float MaxDragThreshold
		{
			get
			{
				return _maxDragThreshold;
			}
			set
			{
				if (_maxDragThreshold != value)
				{
					_maxDragThreshold = value;
					UpdateAllMaterials();
				}
			}
		}

		public DragShadingStyle ShadingStyle
		{
			get
			{
				return _shadingStyle;
			}
			set
			{
				if (_shadingStyle != value)
				{
					_shadingStyle = value;
					UpdateAllMaterials();
				}
			}
		}

		public DragVisualizationTool(Designer designer)
		{
			_designer = designer;
			_dragMaterials = new Dictionary<int, Material>();
			_partDragMaterial = Game.Instance.ResourceLoader.LoadMaterial("Designer/Materials/DesignerPartDragVisualization");
			_partDragLegacyMaterial = Game.Instance.ResourceLoader.LoadMaterial("Designer/Materials/DesignerPartDragLegacy");
		}

		public void AircraftStructureChanged()
		{
			_updateDrag = true;
			RefreshDragVisualization();
		}

		public void Start()
		{
			_updateDrag = true;
			RefreshDragVisualization();
		}

		public void Stop()
		{
			foreach (PartData part in _designer.Aircraft.Aircraft.Assembly.Parts)
			{
				part.PartScript.PartMaterialScript.CustomMaterial = null;
			}
			CleanupDragMaterials();
		}

		private void CleanupDragMaterials()
		{
			foreach (Material value in _dragMaterials.Values)
			{
				if (value != null)
				{
					Object.Destroy(value);
				}
			}
			_dragMaterials.Clear();
		}

		private void OnDragModelChanged()
		{
			CleanupDragMaterials();
		}

		private void RefreshDragVisualization()
		{
			AircraftScript aircraft = _designer.Aircraft;
			bool flag = aircraft.Aircraft.AerodynamicsModelType == CraftAerodynamicsModelType.Legacy;
			if (_legacyDragModel != flag)
			{
				_legacyDragModel = flag;
				OnDragModelChanged();
			}
			PartDrag.DragDirection? dragDirection = PartDrag.Vector3ToDragDirection(_dragDirection);
			if (_updateDrag || (_lastDragUpdateDirection.HasValue && _lastDragUpdateDirection.Value != dragDirection))
			{
				_updateDrag = false;
				_lastDragUpdateDirection = dragDirection;
				if (!dragDirection.HasValue)
				{
					if (flag)
					{
						new DragCalculator(aircraft.Parts).CalculateDrag();
					}
					else
					{
						_designer.DesignerScript.DragCalculator.CalculateDragInDesigner(aircraft);
					}
				}
				else if (flag)
				{
					DragCalculator dragCalculator = new DragCalculator(aircraft.Parts);
					DragCount = dragCalculator.CalculateDragCount(dragDirection.Value);
				}
				else
				{
					_designer.DesignerScript.DragCalculator.CalculateDragInDesigner(aircraft, dragDirection.Value, out var dragCount);
					DragCount = dragCount;
				}
			}
			if (flag && false)
			{
				Material material = GetMaterial(0, legacy: true, this);
				material.color = Color.white;
				foreach (PartData part in aircraft.Parts)
				{
					float num = ((!dragDirection.HasValue) ? 0f : part.PartDrag.GetDrag(dragDirection.Value));
					_ = dragDirection.HasValue;
					if (num == 0f)
					{
						part.PartScript.PartMaterialScript.CustomMaterial = material;
						continue;
					}
					int num2 = Mathf.Max(part.PartDrag.DragCalculatorVolume, 4);
					float num3 = num * 50f / (float)num2;
					Color color = new Color(1f, 1f - num3, 1f - num3, 1f);
					Material material2 = GetMaterial(part.Id, legacy: true, this);
					material2.color = color;
					part.PartScript.PartMaterialScript.CustomMaterial = material2;
				}
			}
			else
			{
				Material material3 = GetMaterial(0, legacy: false, this);
				material3.SetFloat(ShaderPropertyIds.DragValue, 0f);
				float num4 = 0f;
				foreach (PartData part2 in aircraft.Parts)
				{
					float num5 = ((!dragDirection.HasValue) ? 0f : part2.PartDrag.GetDrag(dragDirection.Value));
					if (!dragDirection.HasValue)
					{
						float[] drag = part2.PartDrag.GetDrag();
						num5 += ((_dragDirection.z > 0f) ? (drag[0] * _dragDirection.z) : (drag[1] * (0f - _dragDirection.z)));
						num5 += ((_dragDirection.y > 0f) ? (drag[2] * _dragDirection.y) : (drag[3] * (0f - _dragDirection.y)));
						num5 += ((_dragDirection.x > 0f) ? (drag[5] * _dragDirection.x) : (drag[4] * (0f - _dragDirection.x)));
						num4 += num5;
					}
					else
					{
						num4 += num5;
					}
					if (num5 == 0f)
					{
						part2.PartScript.PartMaterialScript.CustomMaterial = material3;
						continue;
					}
					Material material4 = GetMaterial(part2.Id, legacy: false, this);
					material4.SetFloat(ShaderPropertyIds.DragValue, num5);
					part2.PartScript.PartMaterialScript.CustomMaterial = material4;
				}
				if (dragDirection.HasValue && aircraft.Aircraft.AerodynamicsModelType == CraftAerodynamicsModelType.StandardV1)
				{
					num4 = DragCalculatorScript.ApplyCraftLevelDragEffects(aircraft, dragDirection.Value, num4);
				}
				DragCount = num4 / 0.001f;
			}
			_designer.Tools.UpdateToolInformationDisplay();
			static Material GetMaterial(int partId, bool legacy, DragVisualizationTool instance)
			{
				if (!instance._dragMaterials.TryGetValue(partId, out var value))
				{
					value = Object.Instantiate(legacy ? instance._partDragLegacyMaterial : instance._partDragMaterial);
					instance.UpdateMaterial(value);
					instance._dragMaterials.Add(partId, value);
				}
				return value;
			}
		}

		private void UpdateAllMaterials()
		{
			foreach (Material value in _dragMaterials.Values)
			{
				UpdateMaterial(value);
			}
		}

		private void UpdateMaterial(Material mat)
		{
			mat.SetFloat(ShaderPropertyIds.DragVisualizationThreshold, _maxDragThreshold);
			mat.SetVector(ShaderPropertyIds.DragDirection, _dragDirection);
			if (_shadingStyle == DragShadingStyle.PerPart)
			{
				mat.EnableKeyword("_SHADE_PER_PART");
			}
			else
			{
				mat.DisableKeyword("_SHADE_PER_PART");
			}
		}
	}
}
