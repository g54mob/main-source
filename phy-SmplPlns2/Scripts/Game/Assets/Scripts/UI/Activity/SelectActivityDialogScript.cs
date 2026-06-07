using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.UI.Panels;
using Assets.Scripts.Multiplayer.ActivityFramework;
using Assets.Scripts.Settings;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Activity
{
	public class SelectActivityDialogScript : PanelDialogScript
	{
		public class ActivityInfo
		{
			public NetworkedActivityData Activity { get; set; }

			public float? BestScore { get; set; }

			public string CategoryId { get; set; }

			public string Description { get; set; }

			public string DisplayName { get; set; }

			public string Icon { get; set; }

			public bool ShowTiers { get; set; }

			public int UnlockedScoreTier { get; set; }

			public ActivityInfo(NetworkedActivityData activity)
			{
				Activity = activity;
				DisplayName = activity.DisplayName;
				CategoryId = activity.Category;
				Icon = "Sprites/Activity/" + activity.Icon;
				Description = activity.Description;
				BestScore = Game.Instance.Settings.Cloud.Activities.GetActivityScore(activity.Id);
				if (activity.ScoreTiers.Tiers.Count == 3)
				{
					ShowTiers = true;
					if (BestScore.HasValue)
					{
						UnlockedScoreTier = activity.ScoreTiers.GetScoreTier(BestScore.Value);
					}
				}
			}
		}

		public class Category
		{
			public List<ActivityInfo> Activities { get; private set; }

			public string Icon { get; set; }

			public string Name { get; set; }

			public Category(string name, string icon)
			{
				Name = name;
				Icon = icon;
				Activities = new List<ActivityInfo>();
			}
		}

		private List<ActivityWidgetScript> _activities = new List<ActivityWidgetScript>();

		private Widget _activityDetails;

		private List<Category> _categories;

		private List<CategoryButtonScript> _categoryButtons = new List<CategoryButtonScript>();

		private Widget _itemsParent;

		private ActivityWidgetScript _selectedActivity;

		private CategoryButtonScript _selectedCategory;

		public ActivityWidgetScript SelectedActivity
		{
			get
			{
				return _selectedActivity;
			}
			set
			{
				if (_selectedActivity != value)
				{
					_selectedActivity?.SetSelected(selected: false);
					_selectedActivity = value;
					_selectedActivity?.SetSelected(selected: true);
					UpdateActivityDetails(_selectedActivity);
				}
			}
		}

		private CategoryButtonScript SelectedCategory
		{
			get
			{
				return _selectedCategory;
			}
			set
			{
				if (_selectedCategory != value)
				{
					_selectedCategory?.SetSelected(selected: false);
					_selectedCategory = value;
					_selectedCategory?.SetSelected(selected: true);
					RefreshActivityList(_selectedCategory);
				}
			}
		}

		public event EventHandler<ActivitySelectedEventArgs> ActivitySelected;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_itemsParent = base.Widget.FindWidget("list-item-parent");
		}

		protected override void Start()
		{
			base.Start();
			List<ActivityInfo> list = new List<ActivityInfo>();
			LocationSettings locations = Game.Instance.Settings.Cloud.Locations;
			string mapId = Game.Instance.CurrentMap.MapId;
			foreach (NetworkedActivityData registeredActivity in Game.Instance.NetworkedActivityManager.RegisteredActivities)
			{
				if (registeredActivity.RequiredLocation == null || locations.HasDiscoveredLocation(mapId, registeredActivity.RequiredLocation))
				{
					list.Add(new ActivityInfo(registeredActivity));
				}
			}
			_categories = new List<Category>();
			_categories.Add(new Category("Air Races", "Sprites/Activity/IconRaceAir"));
			_categories.Add(new Category("Car Races", "Sprites/Activity/IconRaceCar"));
			_categories.Add(new Category("Combat", "Sprites/Activity/IconCombat"));
			_categories.Add(new Category("Challenges", "Sprites/Activity/IconChallenge"));
			Widget parent = base.Widget.FindWidget("categories");
			base.Widget.Context.CreateWidgetFromTemplate("category-spacer", parent);
			foreach (Category category in _categories)
			{
				category.Activities.AddRange(list.Where((ActivityInfo x) => x.CategoryId == category.Name));
				CategoryButtonScript component = base.Widget.Context.CreateWidgetFromTemplate("category", parent).GetComponent<CategoryButtonScript>();
				component.Initialize(category);
				component.Widget.EventHandler = this;
				_categoryButtons.Add(component);
			}
			base.Widget.Context.CreateWidgetFromTemplate("category-spacer", parent);
			SelectedCategory = _categoryButtons.FirstOrDefault();
		}

		private void OnActivityClicked(Widget widget)
		{
			ActivityWidgetScript component = widget.GetComponent<ActivityWidgetScript>();
			SelectedActivity = component;
		}

		private void OnCancelClicked(Widget widget)
		{
			Close();
		}

		private void OnCategoryClicked(Widget widget)
		{
			SelectedCategory = widget.GetComponentInParent<CategoryButtonScript>();
		}

		private void OnOkayClicked(Widget widget)
		{
			if (SelectedActivity != null)
			{
				if (SelectedActivity.IsLocked)
				{
					Game.Instance.UserInterface.CreateMessageDialog("This activity is not available in the demo.", "Not Available");
					return;
				}
				if (!FlightSceneScript.Instance.FlightSceneNetwork.IsServerStarted && FlightSceneScript.IsPeacefulMode && !SelectedActivity.Activity.Activity.AllowPeacefulMode)
				{
					Game.Instance.UserInterface.CreateMessageDialog("This activity cannot be started while Peaceful Mode is enabled by the server host.");
					return;
				}
				this.ActivitySelected?.Invoke(this, new ActivitySelectedEventArgs(SelectedActivity.Activity.Activity.Id));
				Close();
			}
		}

		private void RefreshActivityList(CategoryButtonScript category)
		{
			SelectedActivity = null;
			foreach (ActivityWidgetScript activity in _activities)
			{
				activity.Widget.Destroy();
			}
			_activities.Clear();
			Widget parent = base.Widget.FindWidget("activities");
			foreach (ActivityInfo activity2 in category.Category.Activities)
			{
				ActivityWidgetScript component = base.Widget.Context.CreateWidgetFromTemplate("activity", parent).GetComponent<ActivityWidgetScript>();
				component.Initialize(activity2);
				component.Widget.EventHandler = this;
				_activities.Add(component);
			}
		}

		private void SetupScoreTier(NetworkedActivityScoreTiers scoreTiers, Widget activityDetails, int tier, bool unlocked)
		{
			Widget widget = activityDetails.FindWidget($"tier-{tier}");
			widget.EnableClass("unlocked", unlocked);
			widget.FindWidget<TextWidget>("score-tier-text").Text = scoreTiers.FormatScore(scoreTiers.Tiers[tier - 1].Score);
		}

		private void SetupScoreTiers(ActivityInfo activityInfo, Widget activityDetails)
		{
			if (activityInfo.ShowTiers)
			{
				NetworkedActivityData activity = activityInfo.Activity;
				if (_selectedActivity.Activity.BestScore.HasValue)
				{
					activityDetails.FindWidget<TextWidget>("best-score-text").Text = "Your Best Score: " + activity.ScoreTiers.FormatScore(_selectedActivity.Activity.BestScore.Value);
				}
				else
				{
					activityDetails.FindWidget("best-score").SetStyle("visible", "false");
				}
				for (int i = 0; i < 3; i++)
				{
					SetupScoreTier(activity.ScoreTiers, activityDetails, i + 1, _selectedActivity.Activity.UnlockedScoreTier > i);
				}
			}
			else
			{
				_activityDetails.AddClass("no-score-tiers");
			}
		}

		private void UpdateActivityDetails(ActivityWidgetScript activity)
		{
			_activityDetails?.Destroy();
			_activityDetails = null;
			if (activity != null)
			{
				Widget parent = base.Widget.FindWidget("activity-details-parent");
				_activityDetails = base.Widget.Context.CreateWidgetFromTemplate("activity-details", parent);
				_activityDetails.FindWidget<TextWidget>("description").Text = activity.Activity.Description;
				_activityDetails.Show();
				SetupScoreTiers(_selectedActivity.Activity, _activityDetails);
				_activityDetails.FindWidget("settings-header").Visible = activity.Activity.Activity.Settings.AllSettings.Count > 0;
				_activityDetails.GetComponent<ActivitySettingsScript>().SetActivitySettings(activity.Activity.Activity.Settings, ActivitySettingsScript.ActivitySettingsVisibility.HostMenu);
			}
		}
	}
}
