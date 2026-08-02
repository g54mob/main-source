using System.Collections.Generic;
using UnityEngine;

namespace Themee
{
	public class StyleConfig : MonoBehaviour
	{
		public StyleConfig[] extends;

		private BakedStyle _baked;

		public Dictionary<string, StyleConfig> styles;

		public BakedStyle baked => null;

		public StyleConfig GetStyle(string path)
		{
			return null;
		}

		public void MarkDirty()
		{
		}
	}
}
