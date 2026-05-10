using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace HSVPicker
{
	public class ColorPresetList
	{
		public string ListId { get; private set; }

		public List<Color> Colors { get; private set; }

		public event UnityAction<List<Color>> OnColorsUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public ColorPresetList(string listId, List<Color> colors = null)
		{
		}

		public void AddColor(Color color)
		{
		}

		public void UpdateList(IEnumerable<Color> colors)
		{
		}
	}
}
