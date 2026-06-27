using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Restory.AssetManagement;
using Restory.Data.Base;
using Restory.Data.Email;
using Restory.Data.NPCs;
using Restory.Gameplay.EmailSystems;
using Restory.Gameplay.WorkshopRatings;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class WorkshopRatingsCheats : SRDebugCheatBase, INotifyPropertyChanged
	{
		private readonly WorkshopRatingsService workshopRatingsService;

		private readonly ReviewForOrderService reviewForOrderService;

		private readonly EmailNamesService emailNamesService;

		private readonly List<StoryNpcInfo> storyNpcs = new List<StoryNpcInfo>();

		private const string COMMON_CATEGORY = "Workshop Ratings Cheats";

		private int selectedEmailContactIndex = -1;

		private int selectedStoryNpcIndex = -1;

		private int rating = 5;

		private string reviewComment = "Test Comment";

		private ReviewForOrderService.ComfortLevel comfortLevel = ReviewForOrderService.ComfortLevel.Comfortable;

		private bool isOverdueOrder;

		[Category("Workshop Ratings Cheats")]
		[DisplayName("Email Contact")]
		[SROptions.Sort(1)]
		public string EmailContact
		{
			get
			{
				if (selectedEmailContactIndex >= 0 && selectedEmailContactIndex < emailNamesService.EmailContacts.Count)
				{
					return emailNamesService.EmailContacts[selectedEmailContactIndex].EmailAddress;
				}
				return "None";
			}
		}

		[Category("Workshop Ratings Cheats")]
		[DisplayName("Story Npc")]
		[SROptions.Sort(4)]
		public string StoryNpc
		{
			get
			{
				if (selectedStoryNpcIndex >= 0 && selectedStoryNpcIndex < storyNpcs.Count)
				{
					return storyNpcs[selectedStoryNpcIndex].ID;
				}
				return "None";
			}
		}

		[Category("Workshop Ratings Cheats")]
		[DisplayName("Rating")]
		[SROptions.Sort(6)]
		[SROptions.NumberRange(1.0, 5.0)]
		public int Rating
		{
			get
			{
				return rating;
			}
			set
			{
				rating = Mathf.Clamp(value, 1, 5);
			}
		}

		[Category("Workshop Ratings Cheats")]
		[DisplayName("Comment")]
		[SROptions.Sort(7)]
		public string ReviewComment
		{
			get
			{
				return reviewComment;
			}
			set
			{
				reviewComment = value;
			}
		}

		[Category("Workshop Ratings Cheats")]
		[DisplayName("Comfort Level")]
		[SROptions.Sort(10)]
		public ReviewForOrderService.ComfortLevel ComfortLevel
		{
			get
			{
				return comfortLevel;
			}
			set
			{
				comfortLevel = value;
			}
		}

		[Category("Workshop Ratings Cheats")]
		[DisplayName("Overdue Order")]
		[SROptions.Sort(11)]
		public bool IsOverdueOrder
		{
			get
			{
				return isOverdueOrder;
			}
			set
			{
				isOverdueOrder = value;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[Category("Workshop Ratings Cheats")]
		[DisplayName("<")]
		[SROptions.Sort(0)]
		public void CycleSelectedEmailContactLeft()
		{
			if (emailNamesService.EmailContacts != null)
			{
				SwitchSelectedIndex(-1, ref selectedEmailContactIndex, emailNamesService.EmailContacts.Count);
				OnPropertyChanged("EmailContact");
			}
		}

		[Category("Workshop Ratings Cheats")]
		[DisplayName(">")]
		[SROptions.Sort(2)]
		public void CycleSelectedEmailContactRight()
		{
			if (emailNamesService.EmailContacts != null)
			{
				SwitchSelectedIndex(1, ref selectedEmailContactIndex, emailNamesService.EmailContacts.Count);
				OnPropertyChanged("EmailContact");
			}
		}

		[Category("Workshop Ratings Cheats")]
		[DisplayName("<")]
		[SROptions.Sort(3)]
		public void CycleSelectedStoryNpcInfoLeft()
		{
			SwitchSelectedIndex(-1, ref selectedStoryNpcIndex, storyNpcs.Count);
			OnPropertyChanged("StoryNpc");
		}

		[Category("Workshop Ratings Cheats")]
		[DisplayName(">")]
		[SROptions.Sort(5)]
		public void CycleSelectedStoryNpcInfoRight()
		{
			SwitchSelectedIndex(1, ref selectedStoryNpcIndex, storyNpcs.Count);
			OnPropertyChanged("StoryNpc");
		}

		[Category("Workshop Ratings Cheats")]
		[DisplayName("Add Email Review")]
		[SROptions.Sort(8)]
		public void AddEmailContactReview()
		{
			if (selectedEmailContactIndex >= 0 && selectedEmailContactIndex < emailNamesService.EmailContacts.Count)
			{
				EmailContact emailContact = emailNamesService.EmailContacts[selectedEmailContactIndex];
				workshopRatingsService.AddReview(emailContact, new ReviewComment(reviewComment), rating);
				Debug.Log("Cheat command: AddEmailContactReview success");
			}
		}

		[Category("Workshop Ratings Cheats")]
		[DisplayName("Add Npc Review")]
		[SROptions.Sort(9)]
		public void AddStoryNpcReview()
		{
			if (selectedStoryNpcIndex >= 0 && selectedStoryNpcIndex < storyNpcs.Count)
			{
				StoryNpcInfo npcInfo = storyNpcs[selectedStoryNpcIndex];
				workshopRatingsService.AddReview(npcInfo, new ReviewComment(reviewComment), rating);
				Debug.Log("Cheat command: AddStoryNpcReview success");
			}
		}

		[Category("Workshop Ratings Cheats")]
		[DisplayName("Add Generated Email Review")]
		[SROptions.Sort(12)]
		public void AddEmailContactGeneratedReview()
		{
			if (selectedEmailContactIndex >= 0 && selectedEmailContactIndex < emailNamesService.EmailContacts.Count)
			{
				EmailContact emailContact = emailNamesService.EmailContacts[selectedEmailContactIndex];
				reviewForOrderService.AddGeneratedReview(emailContact, comfortLevel, isOverdueOrder);
				Debug.Log("Cheat command: AddEmailContactGeneratedReview success");
			}
		}

		[Category("Workshop Ratings Cheats")]
		[DisplayName("Clear Reviews")]
		[SROptions.Sort(13)]
		public void ClearReviews()
		{
			workshopRatingsService.ClearReviews();
			Debug.Log("Cheat command: ClearReviews success");
		}

		[Inject]
		public WorkshopRatingsCheats(WorkshopRatingsService workshopRatingsService, ReviewForOrderService reviewForOrderService, EmailNamesService emailNamesService, GameEntityDataBaseProvider gameEntityDataBaseProvider)
		{
			this.workshopRatingsService = workshopRatingsService;
			this.reviewForOrderService = reviewForOrderService;
			this.emailNamesService = emailNamesService;
			storyNpcs = gameEntityDataBaseProvider.Asset.All.Where((RestoryEntityInfoBase entity) => entity is StoryNpcInfo).Cast<StoryNpcInfo>().ToList();
		}

		private static void SwitchSelectedIndex(int increment, ref int selectedIndex, int count)
		{
			if (count != 0)
			{
				if (selectedIndex < 0 || selectedIndex >= count)
				{
					selectedIndex = 0;
				}
				int num = (selectedIndex + increment + count) % count;
				selectedIndex = num;
			}
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
