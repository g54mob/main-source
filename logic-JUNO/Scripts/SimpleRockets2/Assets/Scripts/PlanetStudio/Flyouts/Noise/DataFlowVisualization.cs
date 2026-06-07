using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Ui;
using ModApi.Common.Events;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Planet.Modifiers.VertexData;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts.Noise
{
	public class DataFlowVisualization
	{
		public class DataMarker
		{
			public bool Bypass { get; set; }

			public int Count { get; set; }

			public int DataIndex { get; private set; }

			public DataSlotField DataSlotField { get; set; }

			public NoiseElement End { get; set; }

			public XmlElement MarkerElement { get; set; }

			public NoiseElement NoiseElement { get; }

			public bool Output { get; set; }

			public NoiseElement Start { get; set; }

			public bool UserEditable { get; set; }

			public DataMarker(NoiseElement start, int dataIndex)
			{
				NoiseElement = start;
				DataIndex = dataIndex;
			}
		}

		public const int DataSlotSeparation = 21;

		private NoiseElement _passContainer;

		public List<DataMarker> DataMarkers { get; private set; } = new List<DataMarker>();

		public DataFlowVisualization(NoiseElement passContainer)
		{
			_passContainer = passContainer;
		}

		public static Vector3 CalculatePosition(NoiseElement noiseElement, int dataIndex, bool bypass = false)
		{
			return noiseElement.GridElement.rectTransform.TransformPoint(dataIndex * 21, bypass ? (-8) : 16, 0f);
		}

		public void ClearMarkers()
		{
			if (DataMarkers.Count <= 0)
			{
				return;
			}
			foreach (DataMarker dataMarker in DataMarkers)
			{
				if (dataMarker.MarkerElement != null)
				{
					Object.Destroy(dataMarker.MarkerElement.gameObject);
				}
			}
			DataMarkers.Clear();
		}

		public void UpdateVisualization(bool enabled)
		{
			ClearMarkers();
			if (enabled)
			{
				Generate();
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					CreateDisplayMarkers();
				});
			}
		}

		private static NoiseElement GetElementOrClosestContainer(TreeNode<NoiseElement> node)
		{
			if (node == null || node.Item.IsPass)
			{
				return null;
			}
			if (node.Item.IsVisible)
			{
				return node.Item;
			}
			return GetElementOrClosestContainer(node.Parent);
		}

		private static void GetFlatModifierList(TreeNode<NoiseElement> root, List<NoiseElement> list)
		{
			foreach (TreeNode<NoiseElement> child in root.Children)
			{
				if ((bool)child.Item.Modifier)
				{
					list.Add(child.Item);
				}
				else
				{
					GetFlatModifierList(child.Item, list);
				}
			}
		}

		private DataMarker CreateDataInput(DataSlotField dataSlotField, NoiseElement noiseElement, int dataIndex, int count, bool userEditable)
		{
			DataMarker dataMarker = new DataMarker(noiseElement, dataIndex);
			dataMarker.Start = GetElementOrClosestContainer(noiseElement);
			dataMarker.DataSlotField = dataSlotField;
			dataMarker.Output = false;
			dataMarker.Count = count;
			dataMarker.UserEditable = userEditable;
			DataMarkers.Add(dataMarker);
			return dataMarker;
		}

		private DataMarker CreateDataOutput(DataSlotField dataSlotField, NoiseElement noiseElement, int dataIndex, bool bypass, int count, bool userEditable)
		{
			DataMarker dataMarker = new DataMarker(noiseElement, dataIndex);
			dataMarker.Start = GetElementOrClosestContainer(noiseElement);
			dataMarker.DataSlotField = dataSlotField;
			dataMarker.Output = true;
			dataMarker.Bypass = bypass;
			dataMarker.Count = count;
			dataMarker.UserEditable = userEditable;
			DataMarkers.Add(dataMarker);
			return dataMarker;
		}

		private void CreateDisplayMarkers()
		{
			foreach (DataMarker dataMarker in DataMarkers)
			{
				XmlElement xmlElement = null;
				if (dataMarker.DataIndex < 0)
				{
					continue;
				}
				if (dataMarker.Output)
				{
					if (dataMarker.Start?.RowElement != null && dataMarker.Start != dataMarker.End)
					{
						XmlElement elementById = _passContainer.NoiseFlyout.xmlLayout.GetElementById("template-data-output");
						xmlElement = UiUtilities.CloneTemplate(elementById, elementById.parentElement);
						Vector3 position = CalculatePosition(dataMarker.Start, dataMarker.DataIndex);
						xmlElement.rectTransform.position = position;
						float size = 20f;
						if (dataMarker.End != null)
						{
							Vector3 position2 = CalculatePosition(dataMarker.End, dataMarker.DataIndex, dataMarker.Bypass);
							size = Mathf.Abs(xmlElement.rectTransform.InverseTransformPoint(position2).y);
						}
						xmlElement.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
					}
				}
				else if (dataMarker.Start?.RowElement != null)
				{
					XmlElement elementById2 = _passContainer.NoiseFlyout.xmlLayout.GetElementById("template-data-input");
					xmlElement = UiUtilities.CloneTemplate(elementById2, elementById2.parentElement);
					xmlElement.rectTransform.position = CalculatePosition(dataMarker.Start, dataMarker.DataIndex);
					xmlElement.AddClass($"input-color-{dataMarker.Count}");
				}
				if (xmlElement != null)
				{
					xmlElement.gameObject.AddComponent<DataMarkerScript>().DataMarker = dataMarker;
					xmlElement.SetAndApplyAttribute("tooltip", dataMarker.NoiseElement.Name + "." + dataMarker.DataSlotField.Attribute.Name);
				}
				dataMarker.MarkerElement = xmlElement;
			}
		}

		private void Generate()
		{
			List<NoiseElement> list = new List<NoiseElement>();
			GetFlatModifierList(_passContainer, list);
			DataMarker[] array = new DataMarker[10];
			foreach (NoiseElement item in list)
			{
				if (!item.IsActive)
				{
					continue;
				}
				List<DataSlotField> list2 = item.DataSlots.Where((DataSlotField x) => x.Attribute.DataSlotType == DataSlotType.Output).ToList();
				int num = 0;
				foreach (DataSlotField item2 in list2)
				{
					int dataIndex = item2.DataIndex;
					DataMarker dataMarker = CreateDataOutput(item2, item, dataIndex, bypass: false, num++, item2.Attribute.UserEditable);
					if (dataIndex >= 0 && dataIndex < array.Length)
					{
						if (array[dataIndex] != null)
						{
							array[dataIndex].End = GetElementOrClosestContainer(item);
						}
						array[dataIndex] = dataMarker;
					}
				}
				List<DataSlotField> list3 = item.DataSlots.Where((DataSlotField x) => x.Attribute.DataSlotType == DataSlotType.Input).ToList();
				num = 0;
				foreach (DataSlotField item3 in list3)
				{
					int dataIndex2 = item3.DataIndex;
					CreateDataInput(item3, item, dataIndex2, num++, item3.Attribute.UserEditable);
				}
			}
			NoiseElement elementOrClosestContainer = GetElementOrClosestContainer(list.LastOrDefault());
			for (int num2 = 0; num2 < array.Length; num2++)
			{
				if (array[num2] != null)
				{
					array[num2].End = elementOrClosestContainer;
					array[num2].Bypass = true;
					array[num2] = null;
				}
			}
		}
	}
}
