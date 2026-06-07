using System;
using System.Collections.Generic;

namespace PajamaLlama.SurvivalGuide
{
	internal class DrifterDiseasePage : Page
	{
		public Disease Disease { get; private set; }

		private DrifterDiseasePage(Disease disease)
			: base("Disease_" + disease.name, disease.Name, null)
		{
			Disease = disease;
		}

		internal static List<Page> Generate(Disease[] diseases, CategoryPage category)
		{
			List<Page> list = new List<Page>();
			for (int i = 0; i < diseases.Length; i++)
			{
				Page page = new DrifterDiseasePage(diseases[i]);
				list.Add(page);
				category.AddEntry(page);
			}
			return list;
		}

		protected override List<WidgetContainer> GenerateWidgets(SurvivalGuideProperties survivalGuideProperties)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var style))
			{
				throw new NotImplementedException();
			}
			if (!survivalGuideProperties.TryReturnStyle("text-paragraph", out var widget))
			{
				throw new NotImplementedException();
			}
			string text = string.Concat(Disease.Description, "\n\n", Disease.GetEffectDescription());
			return new List<WidgetContainer>
			{
				new WidgetContainer(style, new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
				{
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new TextWidget.Parameters(text))
				})
			};
		}
	}
}
