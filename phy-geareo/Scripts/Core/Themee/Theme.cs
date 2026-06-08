using System;
using System.Collections.Generic;
using UnityEngine;

namespace Themee
{
	public class Theme : MonoBehaviour
	{
		public bool _dirty;

		public Action onDirty;

		public Dictionary<string, StyleConfig> styles;

		public StyleConfig GetStyle(string path)
		{
			return null;
		}

		private void OnValidate()
		{
		}
	}
}
