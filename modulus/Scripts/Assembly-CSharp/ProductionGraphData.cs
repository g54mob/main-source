#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor.Resources;
using Data.ProductionHistory;
using UI.Statistics;
using UnityEngine;
using Utils;

public class ProductionGraphData : ILineGraphData
{
	private struct LineInfo
	{
		public List<Vector2> Points;

		public Func<int> SourceList;

		public ProductionGraphLineMetadata Metadata;

		public LineInfo(ProductionGraphLineMetadata metadata)
		{
			Points = new List<Vector2>();
			SourceList = null;
			Metadata = metadata;
		}
	}

	private readonly List<LineInfo> _lines;

	private readonly Vector2 _min;

	private readonly Vector2 _max;

	public Vector2 Min => _min;

	public Vector2 Max => _max;

	IEnumerable<Vector2> ILineGraphData.this[int lineId] => _lines[lineId].Points;

	int ILineGraphData.LinesCount => _lines.Count;

	public ProductionGraphData(IEnumerable<ProductionHistoryNode> nodes, ProductionHistoryPersistentSO persistentSO, ProductionGraphIdLists idLists, ProductionGraphDatabases databases, ProductionGraphColorConfig colorConfig)
	{
		Dictionary<int, LineInfo> dictionary = CreateProducedLineMetadataList(idLists, persistentSO, databases, colorConfig);
		Dictionary<int, LineInfo> dictionary2 = CreateDeliveredLineMetadataList(idLists, persistentSO, databases, colorConfig);
		PopulateLinePoints(nodes, dictionary, dictionary2, out var largestValue, out var timeIndex);
		_lines = new List<LineInfo>();
		_lines.AddRange(dictionary.Values);
		_lines.AddRange(dictionary2.Values);
		_min = Vector2.zero;
		_max = new Vector2(Mathf.Max(0, timeIndex - 1), largestValue);
	}

	public ProductionGraphLineMetadata GetLineMetadata(int lineId)
	{
		if (lineId < 0 || lineId >= _lines.Count)
		{
			this.DevException($"lineId {lineId} is out of bounds. Max is {_lines.Count - 1}", "GetLineMetadata", 59);
			return default(ProductionGraphLineMetadata);
		}
		return _lines[lineId].Metadata;
	}

	private Dictionary<int, LineInfo> CreateProducedLineMetadataList(ProductionGraphIdLists idLists, ProductionHistoryPersistentSO persistentSO, ProductionGraphDatabases databases, ProductionGraphColorConfig colorConfig)
	{
		Dictionary<int, LineInfo> dictionary = new Dictionary<int, LineInfo>(idLists.ProducedResourceIds.Count);
		ResourceDatabaseSO resourceDatabase = databases.ResourceDatabase;
		for (int i = 0; i < idLists.ProducedResourceIds.Count; i++)
		{
			if (persistentSO.ProducedResourceIds.TryGetValue(idLists.ProducedResourceIds[i], out var value))
			{
				NonShapeResourceDataSO obj = (NonShapeResourceDataSO)resourceDatabase.GetResourceDataFromID(idLists.ProducedResourceIds[i]);
				Color color = colorConfig.ProducedColors[i % colorConfig.ProducedColors.Count];
				Sprite sprite = obj.Sprite;
				string localizedText = LocalizationUtility.GetLocalizedText(obj.NameLocaKey);
				dictionary.Add(value: new LineInfo(new ProductionGraphLineMetadata(idLists.ProducedResourceIds[i], ProductionGraphLineType.Produced, localizedText, color, sprite)), key: value);
			}
		}
		return dictionary;
	}

	private Dictionary<int, LineInfo> CreateDeliveredLineMetadataList(ProductionGraphIdLists idLists, ProductionHistoryPersistentSO persistentSO, ProductionGraphDatabases databases, ProductionGraphColorConfig colorConfig)
	{
		Dictionary<int, LineInfo> dictionary = new Dictionary<int, LineInfo>(idLists.DeliveredResourceIds.Count);
		ResourceDatabaseSO resourceDatabase = databases.ResourceDatabase;
		for (int i = 0; i < idLists.DeliveredResourceIds.Count; i++)
		{
			if (persistentSO.ResourceDeliveredIds.TryGetValue(idLists.DeliveredResourceIds[i], out var value))
			{
				NonShapeResourceDataSO obj = (NonShapeResourceDataSO)resourceDatabase.GetResourceDataFromID(idLists.DeliveredResourceIds[i]);
				Color color = colorConfig.DeliveredColors[i % colorConfig.DeliveredColors.Count];
				Sprite sprite = obj.Sprite;
				string localizedText = LocalizationUtility.GetLocalizedText(obj.NameLocaKey);
				dictionary.Add(value: new LineInfo(new ProductionGraphLineMetadata(idLists.DeliveredResourceIds[i], ProductionGraphLineType.Delivered, localizedText, color, sprite)), key: value);
			}
		}
		return dictionary;
	}

	private void PopulateLinePoints(IEnumerable<ProductionHistoryNode> nodes, Dictionary<int, LineInfo> producedLines, Dictionary<int, LineInfo> deliveredLines, out float largestValue, out int timeIndex)
	{
		timeIndex = 0;
		largestValue = 0f;
		if (nodes == null)
		{
			return;
		}
		foreach (ProductionHistoryNode node in nodes)
		{
			int[] array = producedLines.Keys.ToArray();
			foreach (int index in array)
			{
				if (node.ResourceProducedDeltas != null && index < node.ResourceProducedDeltas.Count)
				{
					Vector2 item = new Vector2(timeIndex, node.ResourceProducedDeltas[index]);
					largestValue = Mathf.Max(largestValue, item.y);
					LineInfo value = producedLines[index];
					value.Points.Add(item);
					value.SourceList = () => node.ResourceProducedDeltas[index];
					producedLines[index] = value;
				}
			}
			array = deliveredLines.Keys.ToArray();
			foreach (int index2 in array)
			{
				if (node.ResourceDeliveredDeltas != null && index2 < node.ResourceDeliveredDeltas.Count)
				{
					Vector2 item2 = new Vector2(timeIndex, node.ResourceDeliveredDeltas[index2]);
					largestValue = Mathf.Max(largestValue, item2.y);
					LineInfo value2 = deliveredLines[index2];
					value2.Points.Add(item2);
					value2.SourceList = () => node.ResourceDeliveredDeltas[index2];
					deliveredLines[index2] = value2;
				}
			}
			timeIndex++;
		}
	}

	public IReadOnlyList<Vector2> GetPoints(int lineId)
	{
		return _lines[lineId].Points;
	}

	public int GetLastPointValue(int lineId)
	{
		return _lines[lineId].SourceList();
	}

	(Vector2 min, Vector2 max) ILineGraphData.GetMinMaxValues()
	{
		return (min: _min, max: _max);
	}
}
