using System;
using System.Collections.Generic;
using ModApi;
using ModApi.Planet;
using ModApi.Planet.Modifiers;
using ModApi.Planet.Modifiers.Profiling;
using ModApi.Planet.Modifiers.VertexData;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts.Noise
{
	public class NoiseElement : TreeNode<NoiseElement>
	{
		private class PerformanceData
		{
			public double AverageExecutionTimeNanoSeconds { get; set; }

			public double ExecutionCountPercentage { get; set; }

			public double ExecutionTimePercentage { get; set; }

			public double TotalExecutionTimeNanoSeconds { get; set; }

			public void Add(PerformanceData data)
			{
				AverageExecutionTimeNanoSeconds += data.AverageExecutionTimeNanoSeconds;
				ExecutionCountPercentage += data.ExecutionCountPercentage;
				ExecutionTimePercentage += data.ExecutionTimePercentage;
				TotalExecutionTimeNanoSeconds += data.TotalExecutionTimeNanoSeconds;
			}
		}

		private string _containerName = string.Empty;

		private PerformanceData _performanceData;

		public bool CanModify { get; set; } = true;

		public bool ContributesToContainerPath { get; set; }

		public DataFlowVisualization DataFlowVisualization { get; private set; }

		public List<DataSlotField> DataSlots { get; private set; }

		public Transform DataTransform { get; }

		public XmlElement GridElement => base.RowElement.GetElementByInternalId("grid");

		public IInspectorPanel InspectorPanel { get; set; }

		public bool IsActive
		{
			get
			{
				if (IsContainer)
				{
					foreach (TreeNode<NoiseElement> child in base.Children)
					{
						if (!child.Item.IsActive)
						{
							return false;
						}
					}
					return true;
				}
				return DataTransform.gameObject.activeSelf;
			}
			set
			{
				if (IsContainer)
				{
					foreach (TreeNode<NoiseElement> child in base.Children)
					{
						child.Item.IsActive = value;
					}
					return;
				}
				if (IsActive != value)
				{
					DataTransform.gameObject.SetActive(value);
					if (!value)
					{
						base.RowElement.AddClass("disabled");
					}
					else
					{
						base.RowElement.RemoveClass("disabled");
					}
				}
			}
		}

		public bool IsContainer => Modifier == null;

		public bool IsPass { get; private set; }

		public VertexDataPlanetModifier Modifier { get; }

		public string Name
		{
			get
			{
				if (IsContainer)
				{
					return _containerName;
				}
				return Modifier.Name;
			}
			set
			{
				if (IsContainer)
				{
					_containerName = value;
				}
				else
				{
					Modifier.Name = value;
				}
				if (NameText != null)
				{
					NameText.text = value;
				}
			}
		}

		public TextMeshProUGUI NameText { get; set; }

		public NoiseFlyoutScript NoiseFlyout { get; }

		public VertexDataPlanetModifierPassType Pass { get; private set; }

		public PlanetBiome PassBiome { get; private set; }

		public NoiseElement PassContainer
		{
			get
			{
				if (PassTransform != null)
				{
					return this;
				}
				return base.Parent?.Item.PassContainer;
			}
		}

		public Transform PassTransform { get; set; }

		public int TotalModifierCount
		{
			get
			{
				int num = 0;
				foreach (TreeNode<NoiseElement> child in base.Children)
				{
					num += child.Item.TotalModifierCount;
				}
				if (Modifier != null)
				{
					num++;
				}
				return num;
			}
		}

		public VertexDataType VertexDataType { get; }

		public NoiseElement(NoiseFlyoutScript noiseFlyout, Transform dataTransform, VertexDataPlanetModifier modifier)
		{
			base.Item = this;
			NoiseFlyout = noiseFlyout;
			DataTransform = dataTransform;
			Modifier = modifier;
			Pass = modifier.Pass;
			VertexDataType = modifier.VertexDataType;
			DataSlots = new List<DataSlotField>();
		}

		public NoiseElement(NoiseFlyoutScript noiseFlyout, string name, VertexDataPlanetModifierPassType pass, VertexDataType vertexDataType)
		{
			base.Item = this;
			NoiseFlyout = noiseFlyout;
			Name = name;
			Pass = pass;
			ContributesToContainerPath = true;
			VertexDataType = vertexDataType;
		}

		public override void Delete()
		{
			base.Delete();
			InspectorPanel?.Close();
			if (DataTransform != null)
			{
				Modifier.Biome?.Modifiers.Remove(Modifier);
				UnityEngine.Object.DestroyImmediate(DataTransform.gameObject);
			}
		}

		public void InitializePassContainer(Transform passTransform, PlanetBiome biome)
		{
			PassTransform = passTransform;
			PassBiome = biome;
			CanModify = false;
			ContributesToContainerPath = false;
			IsPass = true;
			if (biome != null)
			{
				GridElement.AddClass("biome-pass");
			}
			else
			{
				GridElement.AddClass("hidden");
			}
			if (passTransform != null)
			{
				DataFlowVisualization = new DataFlowVisualization(this);
			}
		}

		public override bool MoveToContainer(TreeNode<NoiseElement> container, TreeNode<NoiseElement> insertBefore)
		{
			base.MoveToContainer(container, insertBefore);
			UpdatePassModifierTransformOrdering();
			return true;
		}

		public void UpdatePassModifierTransformOrdering()
		{
			NoiseElement passContainer = PassContainer;
			passContainer.UpdateModifierTransformOrdering(0, passContainer, string.Empty);
		}

		public void UpdateProfilerColumns()
		{
			_performanceData = new PerformanceData();
			if (Modifier?.ProfilerResults != null)
			{
				ModifierPerformanceData modifierPerformanceData = Modifier?.ProfilerResults;
				_performanceData.AverageExecutionTimeNanoSeconds = modifierPerformanceData.AverageExecutionTimeNanoSeconds;
				_performanceData.ExecutionCountPercentage = modifierPerformanceData.ExecutionCountPercentage;
				_performanceData.ExecutionTimePercentage = modifierPerformanceData.ExecutionTimePercentage;
				_performanceData.TotalExecutionTimeNanoSeconds = modifierPerformanceData.TotalExecutionTimeNanoSeconds;
			}
			if (base.Children != null)
			{
				foreach (TreeNode<NoiseElement> child in base.Children)
				{
					child.Item.UpdateProfilerColumns();
					_performanceData.Add(child.Item._performanceData);
				}
			}
			base.RowElement.GetElementByInternalId<TextMeshProUGUI>("perf-1").text = $"{_performanceData.ExecutionTimePercentage:n2}%";
			base.RowElement.GetElementByInternalId<TextMeshProUGUI>("perf-2").text = $"{_performanceData.AverageExecutionTimeNanoSeconds:n1}ns";
			base.RowElement.GetElementByInternalId<TextMeshProUGUI>("perf-3").text = $"{_performanceData.ExecutionCountPercentage:n2}%";
			base.RowElement.GetElementByInternalId<TextMeshProUGUI>("perf-4").text = $"{_performanceData.TotalExecutionTimeNanoSeconds / 1000.0:n1}μs";
		}

		public void UpdateVisualization()
		{
			DataFlowVisualization?.UpdateVisualization(!Collapsed && NoiseFlyout.ShowDataVisualization);
		}

		protected override int UpdateRowElements(int index, int indent, bool collapsedSubTree)
		{
			if (IsPass && TotalModifierCount == 0 && NoiseFlyout.HideEmptyPasses)
			{
				collapsedSubTree = true;
			}
			return base.UpdateRowElements(index, indent, collapsedSubTree);
		}

		private void UpdateContainerPath()
		{
			if (Modifier == null)
			{
				throw new InvalidOperationException("Attempting to update container path for a noise element that does not have a planet modifier.");
			}
			TreeNode<NoiseElement> parent = base.Parent;
			string text = string.Empty;
			while (!parent.Item.IsPass)
			{
				text = parent.Item.Name + "/" + text;
				parent = parent.Parent;
			}
			Modifier.Container = text.TrimEnd(new char[1] { '/' });
		}

		private int UpdateModifierTransformOrdering(int siblingIndex, NoiseElement passContainer, string containerPath)
		{
			if (ContributesToContainerPath)
			{
				containerPath = Utilities.CombinePaths(containerPath, Name);
			}
			Pass = passContainer.Pass;
			if (IsContainer)
			{
				foreach (TreeNode<NoiseElement> child in base.Children)
				{
					siblingIndex = child.Item.UpdateModifierTransformOrdering(siblingIndex, passContainer, containerPath);
				}
			}
			else
			{
				if (DataTransform.parent != passContainer.PassTransform)
				{
					DataTransform.SetParent(passContainer.PassTransform, worldPositionStays: false);
				}
				DataTransform.SetSiblingIndex(siblingIndex++);
				Modifier.Container = containerPath;
				Modifier.SetPass(passContainer.Pass, passContainer.PassBiome);
			}
			return siblingIndex;
		}
	}
}
