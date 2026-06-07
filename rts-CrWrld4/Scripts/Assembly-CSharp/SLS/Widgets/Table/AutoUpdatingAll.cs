using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLS.Widgets.Table
{
	public class AutoUpdatingAll : MonoBehaviour
	{
		public Table table;

		public Sprite sprite1;

		public Sprite sprite2;

		public Sprite sprite3;

		public Sprite sprite4;

		public Sprite sprite5;

		private Dictionary<string, Sprite> spriteDict;

		private List<string> spriteNames;

		private void Start()
		{
		}

		private Datum MakeDatum(string pfx)
		{
			return null;
		}

		private string RandomSprite()
		{
			return null;
		}

		private IEnumerator DoRandomData()
		{
			return null;
		}

		private void OnRowSelected(Datum datum)
		{
		}

		private void OnHeaderSelected(Column column)
		{
		}

		public void PushRowTop()
		{
		}

		public void PushRowRandom()
		{
		}

		public void PushRowBottom()
		{
		}

		public void DeleteRow()
		{
		}

		public void UpdateRow()
		{
		}
	}
}
