using System;
using System.Collections.Generic;
using NSEipix.Base;

namespace NSMedieval.DevConsole
{
	public class DeveloperToolsCategories : Singleton<DeveloperToolsCategories>
	{
		public List<DeveloperToolsCategory> Categories { get; } = new List<DeveloperToolsCategory>();

		public DeveloperToolsCategories()
		{
			foreach (DeveloperPanelCategory value in Enum.GetValues(typeof(DeveloperPanelCategory)))
			{
				Categories.Add(new DeveloperToolsCategory
				{
					Name = value.ToString(),
					Category = value
				});
			}
		}
	}
}
