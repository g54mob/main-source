using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Statistics
{
	public class LineGraphTest : MonoBehaviour
	{
		private interface IColorPick
		{
			Color Color { get; }
		}

		private enum Type
		{
			Mock = 0,
			Function = 1,
			Error = 2
		}

		[Serializable]
		private class MockLine : IList<Vector2>, ICollection<Vector2>, IEnumerable<Vector2>, IEnumerable, IColorPick
		{
			[FormerlySerializedAs("Data")]
			[SerializeField]
			private List<Vector2> data;

			[FormerlySerializedAs("Color")]
			[SerializeField]
			private Color color;

			public int Count => data.Count;

			public bool IsReadOnly => ((ICollection<Vector2>)data).IsReadOnly;

			public Vector2 this[int index]
			{
				get
				{
					return data[index];
				}
				set
				{
					data[index] = value;
				}
			}

			public Color Color => color;

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public IEnumerator<Vector2> GetEnumerator()
			{
				return data.GetEnumerator();
			}

			public void Add(Vector2 item)
			{
				data.Add(item);
			}

			public void Clear()
			{
				data.Clear();
			}

			public bool Contains(Vector2 item)
			{
				return data.Contains(item);
			}

			public void CopyTo(Vector2[] array, int arrayIndex)
			{
				data.CopyTo(array, arrayIndex);
			}

			public bool Remove(Vector2 item)
			{
				return data.Remove(item);
			}

			public int IndexOf(Vector2 item)
			{
				return data.IndexOf(item);
			}

			public void Insert(int index, Vector2 item)
			{
				data.Insert(index, item);
			}

			public void RemoveAt(int index)
			{
				data.RemoveAt(index);
			}
		}

		[Serializable]
		private class FunctionLine : IColorPick
		{
			public List<float> xValues;

			[SerializeField]
			private Color color;

			public Color Color => color;
		}

		private class ColorPick : IColorPick
		{
			public Color Color { get; }

			public ColorPick(Color color)
			{
				Color = color;
			}
		}

		[SerializeField]
		private LineGraph lineGraph;

		[SerializeField]
		private MockLine[] data;

		[SerializeField]
		private FunctionLine[] funcData;

		[SerializeField]
		private Type type;

		[SerializeField]
		private TMP_Dropdown dropdown;

		[SerializeField]
		private Image lineHighlightPrefab;

		[SerializeField]
		private bool changeDiscritization;

		private IList<IColorPick> _colorPick;

		private void Start()
		{
			dropdown.ClearOptions();
			List<string> options = Enum.GetNames(typeof(Type)).ToList();
			dropdown.AddOptions(options);
			dropdown.value = (int)type;
			dropdown.RefreshShownValue();
			dropdown.onValueChanged.AddListener(SetType);
			Plot();
		}

		private void SetType(int arg0)
		{
			type = (Type)arg0;
			lineGraph.Clear();
			Plot();
		}

		public void Plot()
		{
			ILineGraphData lineGraphData = null;
			switch (type)
			{
			case Type.Mock:
			{
				IList<Vector2>[] rawData = data;
				lineGraphData = new SimpleLineGraphData(rawData);
				break;
			}
			case Type.Function:
				lineGraphData = new FunctionLineGraphData(funcData.Select(delegate(FunctionLine functionLine, int i)
				{
					Func<float, float> func = null;
					return new FunctionLineGraphData.Function((i % 3) switch
					{
						0 => (float x) => 100f + 2f * x, 
						1 => (float x) => 150f - 1.5f * x, 
						2 => (float x) => 0.05f * x * x + 100f, 
						_ => throw new NotImplementedException("Function is not created"), 
					}, functionLine.xValues);
				}).ToArray());
				break;
			case Type.Error:
				lineGraphData = new SimpleLineGraphData(new Vector2[1] { Vector2.one * 0.5f }, new List<Vector2>(), new Vector2[4]
				{
					Vector2.zero,
					Vector2.up,
					Vector2.one,
					Vector2.right
				});
				break;
			default:
				throw new ArgumentException("Undefined Type");
			}
			switch (type)
			{
			case Type.Mock:
				_colorPick = data;
				break;
			case Type.Function:
				_colorPick = funcData;
				break;
			case Type.Error:
				_colorPick = new List<IColorPick>
				{
					new ColorPick(Color.blue),
					new ColorPick(Color.black),
					new ColorPick(Color.red)
				};
				break;
			default:
				throw new ArgumentException("Undefined Type");
			}
			lineGraph.PlotGraph(lineGraphData, DotCreated, LineCreated, CriticalValuesFound, NormalizedLineDotsCalculated);
		}

		private void NormalizedLineDotsCalculated(int lineId, List<Vector2> positions)
		{
			if (lineHighlightPrefab != null)
			{
				lineGraph.DrawHighlight(positions, _colorPick[lineId].Color, lineHighlightPrefab);
			}
		}

		private void CriticalValuesFound(Vector2 min, Vector2 max)
		{
			if (type == Type.Error)
			{
				lineGraph.SetMinMaxOnGraph(Vector2.zero, Vector2.one * 3f);
				lineGraph.Discretization = Vector2.one;
			}
			else if (changeDiscritization)
			{
				lineGraph.Discretization = new Vector2(10f, 50f);
			}
		}

		private void LineCreated(int lineId, Image line)
		{
			line.color = _colorPick[lineId].Color;
		}

		private void DotCreated(int lineId, Image dot)
		{
			dot.transform.GetChild(0).GetComponent<Image>().color = _colorPick[lineId].Color;
		}
	}
}
