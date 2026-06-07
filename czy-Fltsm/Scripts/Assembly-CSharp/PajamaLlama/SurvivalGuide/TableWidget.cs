using System;
using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.JSON;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	internal class TableWidget : BaseWidget
	{
		internal class Parameters : BaseParameters
		{
			internal struct Entry
			{
				public string Style;

				public string Text;

				public Sprite Sprite;

				public Color SpriteColor;

				public float Width;

				public Entry(string style, string text, float width)
				{
					Style = style;
					Text = text;
					Sprite = null;
					SpriteColor = Color.white;
					Width = width;
				}

				public Entry(string style, Sprite sprite, Color color, float width)
				{
					Style = style;
					Text = null;
					Sprite = sprite;
					SpriteColor = color;
					Width = width;
				}
			}

			public List<List<Entry>> Table { get; private set; }

			public Parameters(Dictionary<string, object> parameters)
			{
				if (!JSONExtensions.TryReturnParameter<List<object>>(parameters, "columns", out var parameter))
				{
					throw new NotImplementedException("Table Style requires valid columns.");
				}
				Table = new List<List<Entry>>();
				for (int i = 0; i < parameter.Count; i++)
				{
					if (!(parameter[i] is Dictionary<string, object> parameters2))
					{
						throw new NotImplementedException($"Invalid Column parameters defined for Column {i}.");
					}
					List<Entry> list = new List<Entry>();
					if (!JSONExtensions.TryReturnParameter<string>(parameters2, "header", out var parameter2))
					{
						throw new NotImplementedException($"No header term defined for Column {i}.");
					}
					if (!JSONExtensions.TryReturnParameter<string>(parameters2, "header-style", out var parameter3))
					{
						throw new NotImplementedException($"No header style defined for Column {i}.");
					}
					if (!JSONExtensions.TryReturnParameter<long>(parameters2, "width", out var parameter4))
					{
						throw new NotImplementedException($"No header style defined for Column {i}.");
					}
					list.Add(new Entry(parameter3, new LocalizedString(parameter2), parameter4));
					if (JSONExtensions.TryReturnParameter<List<object>>(parameters2, "data", out var parameter5) && JSONExtensions.TryReturnParameter<string>(parameters2, "data-style", out parameter3))
					{
						foreach (string item in parameter5)
						{
							if (item != null)
							{
								list.Add(new Entry(parameter3, new LocalizedString(item), parameter4));
							}
						}
					}
					Table.Add(list);
				}
			}

			public Parameters(List<List<Entry>> table)
			{
				Table = table;
			}
		}

		[SerializeField]
		private Table _table;

		internal override void Initialize(BaseParameters parameters)
		{
			if (parameters is Parameters parameters2)
			{
				UpdateTable(parameters2.Table);
			}
			else
			{
				Debug.LogException(new NotImplementedException());
			}
		}

		internal override BaseParameters CreateParameters(Dictionary<string, object> parameters)
		{
			return new Parameters(parameters);
		}

		private void UpdateTable(List<List<Parameters.Entry>> table)
		{
			if (table.IsNullOrEmpty())
			{
				return;
			}
			List<Table.Row> list = new List<Table.Row>();
			foreach (List<Parameters.Entry> item in table)
			{
				for (int i = 0; i < item.Count; i++)
				{
					Parameters.Entry entry = item[i];
					Table.Row row;
					if (i < list.Count)
					{
						row = list[i];
					}
					else
					{
						row = _table.AddRow();
						list.Add(row);
					}
					if (entry.Sprite != null)
					{
						_table.TryAddEntry(row, entry.Style, entry.Sprite, entry.SpriteColor, entry.Width, out var _);
					}
					else
					{
						_table.TryAddEntry(row, entry.Style, entry.Text, entry.Width, out var _);
					}
				}
			}
		}
	}
}
