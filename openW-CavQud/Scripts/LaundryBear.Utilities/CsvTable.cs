using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CsvTable : IEnumerable<CsvTable.Row>, IEnumerable
{
	public struct Row
	{
		private Dictionary<string, string> m_values;

		public string this[string header]
		{
			get
			{
				return m_values[header];
			}
			private set
			{
				m_values[header] = value;
			}
		}

		public Row(string[] headers, string[] elements)
		{
			m_values = new Dictionary<string, string>();
			for (int i = 0; i < headers.Length; i++)
			{
				m_values.Add(headers[i], elements[i]);
			}
		}
	}

	private class CsvEnumerator : IEnumerator<Row>, IEnumerator, IDisposable
	{
		private List<Row> m_rows;

		private int m_currentIndex = -1;

		public Row Current => m_rows[m_currentIndex];

		object IEnumerator.Current => m_rows[m_currentIndex];

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			m_currentIndex++;
			return m_currentIndex < m_rows.Count;
		}

		public void Reset()
		{
			m_currentIndex = -1;
		}

		public CsvEnumerator(List<Row> rows)
		{
			m_rows = rows;
		}
	}

	private List<Row> m_rows;

	public CsvTable(string content, params string[] delimeter)
	{
		m_rows = new List<Row>();
		using StringReader stringReader = new StringReader(content);
		string[] headers = stringReader.ReadLine().Split(delimeter, StringSplitOptions.None);
		for (string text = stringReader.ReadLine(); text != null; text = stringReader.ReadLine())
		{
			string[] elements = text.Split(delimeter, StringSplitOptions.None);
			Row item = new Row(headers, elements);
			m_rows.Add(item);
		}
	}

	public IEnumerator<Row> GetEnumerator()
	{
		return new CsvEnumerator(new List<Row>(m_rows));
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new CsvEnumerator(new List<Row>(m_rows));
	}
}
