using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rhizomatic.Reactive
{
	public class PrefabContainer : MonoBehaviour
	{
		public bool _fetch;

		public View[] prefabs;

		public PrefabContainer[] containers;

		public Dictionary<Type, View> entries;

		public virtual void LoadEntries()
		{
		}

		public View GetPrefab(IViewable viewable)
		{
			return null;
		}

		private void OnValidate()
		{
		}
	}
}
