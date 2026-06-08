using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	public class ApplianceInfo : Localisation
	{
		public string Name;

		[TextArea]
		public string Description;

		public List<Appliance.Section> Sections;

		public List<string> Tags;

		public void OnEnable()
		{
			if (Sections == null)
			{
				Sections = new List<Appliance.Section>();
			}
			if (Tags == null)
			{
				Tags = new List<string>();
			}
		}

		public override void Export(LocalisationContext context)
		{
			base.SetContext(context);
			context.Add("NAME", Name);
			context.Add("DESCRIPTION", Description);
			for (int i = 0; i < Sections.Count; i++)
			{
				Appliance.Section section = Sections[i];
				context.Add($"SECTION/{i}/TITLE", section.Title);
				context.Add($"SECTION/{i}/DESCRIPTION", section.Description);
				context.Add($"SECTION/{i}/RANGE", section.RangeDescription);
			}
			for (int j = 0; j < Tags.Count; j++)
			{
				string value = Tags[j];
				context.Add($"TAG/{j}", value);
			}
		}

		public override void Import(LocalisationContext context)
		{
			base.SetContext(context);
			Name = context.Get("NAME");
			Description = context.Get("DESCRIPTION");
			int maxSubKeys = context.GetMaxSubKeys("SECTION");
			Sections = new List<Appliance.Section>();
			for (int i = 0; i < maxSubKeys; i++)
			{
				Sections.Add(new Appliance.Section
				{
					Title = context.Get($"SECTION/{i}/TITLE"),
					Description = context.Get($"SECTION/{i}/DESCRIPTION"),
					RangeDescription = context.Get($"SECTION/{i}/RANGE")
				});
			}
			int maxSubKeys2 = context.GetMaxSubKeys("TAG");
			Tags = new List<string>();
			for (int j = 0; j < maxSubKeys2; j++)
			{
				Tags.Add(context.Get($"TAG/{j}"));
			}
		}
	}
}
