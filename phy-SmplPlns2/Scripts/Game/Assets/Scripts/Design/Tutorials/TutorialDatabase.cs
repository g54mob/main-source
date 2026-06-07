using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Design.Tutorials.Definitions;

namespace Assets.Scripts.Design.Tutorials
{
	public class TutorialDatabase
	{
		public class TutorialInfo
		{
			public Func<TutorialInfo, Tutorial> CreateTutorial { get; set; }

			public string Description { get; internal set; }

			public string Id { get; set; }

			public bool IsDone
			{
				get
				{
					return Game.Instance.Settings.App.SeenNotifications.Contains("Tutorial-" + Id);
				}
				set
				{
					Game.Instance.Settings.App.AddNotification("Tutorial-" + Id);
				}
			}

			public string Name { get; set; }
		}

		public bool AllTutorialsDone => Tutorials.All((TutorialInfo x) => x.IsDone);

		public TutorialInfo FirstTutorial => Tutorials.First();

		public List<TutorialInfo> Tutorials { get; } = new List<TutorialInfo>();

		public TutorialDatabase()
		{
			Tutorials.Add(new TutorialInfo
			{
				Id = "DesignerBasics",
				Name = "Designer Basics",
				Description = "Super quick tutorial that teaches the basics of working in the designer",
				CreateTutorial = (TutorialInfo info) => new DesignerBasicsTutorial(info)
			});
			Tutorials.Add(new TutorialInfo
			{
				Id = "PropPlane",
				Name = "Build Your First Plane",
				Description = "Quick walkthrough on how to build a working prop plane",
				CreateTutorial = (TutorialInfo info) => new PropPlaneTutorial(info)
			});
			Tutorials.Add(new TutorialInfo
			{
				Id = "BasicCar",
				Name = "Build a Simple Car",
				Description = "Quick intro to cars and working with the new powertrain system",
				CreateTutorial = (TutorialInfo info) => new CarTutorial(info)
			});
		}
	}
}
