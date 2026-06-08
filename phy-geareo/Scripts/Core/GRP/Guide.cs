using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class Guide : MonoBehaviour
	{
		public GuideRow rowPrefab;

		public Transform container;

		public float smooth;

		public bool active;

		public Dictionary<string, GuideData> rowsData;

		public Dictionary<string, GuideRow> rows;

		public Dictionary<string, GuideRow> pool;

		private List<string> removeKey;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void Set(string key, GuideData data)
		{
		}

		public void Remove(string key)
		{
		}

		public bool Has(string key)
		{
			return false;
		}
	}
}
