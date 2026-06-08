using System;
using System.Collections.Generic;
using Rhizomatic.ImUI;

namespace GRP
{
	public class PaletteViewer : IExpositorUI
	{
		public Project project;

		public List<string> colors;

		public ColorBuilder builder;

		private Action updateItems;

		private Action updateItem;

		private List<string> availableColors;

		public PaletteViewer(Project project)
		{
		}

		public void OnExpositorUI(ImUIBuilder ui)
		{
		}

		public void UpdateItems(string previousColor, string newColor)
		{
		}

		public void UpdateItem(ColorField field, string newColor)
		{
		}

		public void CheckColorablePart(Part part)
		{
		}
	}
}
