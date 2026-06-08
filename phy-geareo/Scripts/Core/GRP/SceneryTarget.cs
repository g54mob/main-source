using System.Collections.Generic;
using Rhizomatic.ImUI;
using UnityEngine;

namespace GRP
{
	public class SceneryTarget : MonoBehaviour
	{
		public GameObject[] toggles;

		public string title;

		public string key;

		public ImUIBuilder ui;

		public List<SceneryItem> items;

		private bool started;

		private void Start()
		{
		}

		public void Render()
		{
		}

		public void Tab(ImUIBuilder ui)
		{
		}

		public void _Setup()
		{
		}

		public SceneryData Serialize()
		{
			return null;
		}

		public void Deserialize(SceneryData data)
		{
		}

		protected virtual void Setup()
		{
		}
	}
}
