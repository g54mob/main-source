using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class GroupContextMenuItem : ContextMenuItem
	{
		public string LabelKey;

		private IEnumerable<ContextMenuItem> SubItems;

		private Func<IEnumerable<ContextMenuItem>> GetSubItems;

		public GroupContextMenuItem(string labelKey, IEnumerable<ContextMenuItem> subItems)
			: base(null)
		{
		}

		public GroupContextMenuItem(string labelKey, Func<IEnumerable<ContextMenuItem>> getSubItems)
			: base(null)
		{
		}

		public override GameObject CreateGameObject(Transform where)
		{
			return null;
		}
	}
}
