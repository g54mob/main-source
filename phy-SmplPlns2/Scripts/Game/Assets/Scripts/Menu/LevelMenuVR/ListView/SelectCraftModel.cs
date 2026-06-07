using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.CraftFiles;
using Assets.Scripts.Net;
using Jundroo.Common.Cache;
using Jundroo.Common.Coroutines;
using UnityEngine;
using Web.Client.Models;
using Web.Client.Models.SimplePlanes;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class SelectCraftModel : ListViewModel
	{
		public class CraftItemModel : ItemModel
		{
			public TrackedCraftList.TrackedCraft Craft { get; set; }

			public CraftItemModel(TrackedCraftList.TrackedCraft craft)
				: base(craft.Title)
			{
				Craft = craft;
				base.ThumbnailLocation = craft.ThumbnailLocation;
				base.ThumbnailPath = craft.ThumbnailPath;
			}
		}

		private const string CuratorQueueAction = "CuratorQueue";

		private const string FavoritesAction = "Favorites";

		private const string JetStreamAction = "JetStream";

		private const string UploadsAction = "Uploads";

		private static string _lastNavLocation;

		private static string _lastTagsSelected;

		private NavigationGroupScript _accountNavGroup;

		private string _autoSelectCraftID;

		private NavigationItemScript _curatedFilter;

		private string _detailsCraftUrlId;

		private NavigationGroupScript _filtersNavGroup;

		private NavigationItemScript _navDownloaded;

		private List<NavigationItemScript> _navigationItems = new List<NavigationItemScript>();

		private NavigationItemScript _navSaved;

		private NavigationItemScript _navStarred;

		private NavigationItemScript _navStock;

		private NavigationGroupScript _onlineNavGroup;

		private WebYieldRequest<string> _requestCurateApprove;

		private WebYieldRequest<string> _requestCurateReject;

		private WebYieldRequest<string> _requestCurateReset;

		private WebYieldRequest<string> _requestFavorite;

		private WebYieldRequest<string> _requestUpvote;

		private int _restorePage;

		private TrackedCraftList.TrackedCraft _selectedCraft;

		private NavigationGroupScript _tagsNavGroup;

		private string _title;

		private TrackedCraftList _trackedCrafts;

		private NavigationItemScript _vrOnly;

		private WebCacheScript _webCache;

		public static int PerformanceCostThresholdHeavy
		{
			get
			{
				_ = Game.Instance.Device.IsAndroidVRBuild;
				return 4000;
			}
		}

		public static int PerformanceCostThresholdModerate
		{
			get
			{
				_ = Game.Instance.Device.IsAndroidVRBuild;
				return 2000;
			}
		}

		public static int PerformanceCostThresholdModerateWithOpponents
		{
			get
			{
				if (Game.Instance.Device.IsAndroidVRBuild)
				{
					return 2500;
				}
				return 5000;
			}
		}

		public event Action<TrackedCraftList.TrackedCraft> OnCraftSelected;

		public SelectCraftModel(TrackedCraftList trackedCrafts, string selectCraftID, string title)
		{
			_title = title;
			_trackedCrafts = trackedCrafts;
			_autoSelectCraftID = selectCraftID;
			_webCache = Game.Instance.WebCache;
		}

		public static string GetVRDeviceTypeName()
		{
			string result = "Computer";
			if (Game.Instance.Device.IsOculusQuestBuild)
			{
				result = ((!Game.Instance.Device.IsOculusQuest1) ? "Quest2" : "Quest1");
			}
			else if (Game.Instance.Device.IsPicoXRBuild)
			{
				result = "PicoXR";
			}
			return result;
		}

		public override IEnumerator LoadItems(List<ItemModel> items)
		{
			List<TrackedCraftList.TrackedCraft> crafts = null;
			if (base.ListView.SelectedNavItem.NavGroup == _onlineNavGroup || base.ListView.SelectedNavItem.NavGroup == _accountNavGroup)
			{
				string sort = base.ListView.SelectedNavItem.UserData as string;
				crafts = new List<TrackedCraftList.TrackedCraft>();
				yield return LoadItemsOnline(sort, crafts);
				base.PagingEnabled = true;
				base.PageNextEnabled = true;
			}
			else
			{
				if (_filtersNavGroup != null)
				{
					_filtersNavGroup.Visible = false;
					_tagsNavGroup.Visible = false;
				}
				if (base.ListView.SelectedNavItem == _navStock)
				{
					crafts = (from x in _trackedCrafts.Crafts
						where x.IsStock
						orderby x.Title
						select x).ToList();
				}
				else if (base.ListView.SelectedNavItem == _navDownloaded)
				{
					crafts = (from x in _trackedCrafts.Crafts
						where !x.IsStock && !x.IsStarred
						orderby x.LastAccess descending
						select x).ToList();
				}
				else if (base.ListView.SelectedNavItem == _navStarred)
				{
					crafts = (from x in _trackedCrafts.Crafts
						where x.IsStarred
						orderby x.StarredDateTime descending
						select x).ToList();
				}
				else if (base.ListView.SelectedNavItem == _navSaved)
				{
					crafts = GetSavedCrafts();
				}
				if (crafts.Count >= 24)
				{
					int num = Math.Max(base.Page - 1, 0);
					crafts = crafts.Skip(num * 24).Take(24).ToList();
					base.PagingEnabled = true;
					base.PageNextEnabled = true;
				}
				else
				{
					base.PagingEnabled = false;
					base.PageNextEnabled = false;
				}
			}
			foreach (TrackedCraftList.TrackedCraft item in crafts)
			{
				items.Add(new CraftItemModel(item));
			}
		}

		public override void OnClosing()
		{
			base.OnClosing();
			_trackedCrafts.Save();
			SaveNavLocation();
			_detailsCraftUrlId = null;
		}

		public override void OnItemsFinishedLoading()
		{
			if (!string.IsNullOrWhiteSpace(_autoSelectCraftID))
			{
				ListViewItemScript listViewItemScript = base.ListView.Items.Where((ListViewItemScript x) => (x.Model as CraftItemModel)?.Craft.UrlId == _autoSelectCraftID).FirstOrDefault();
				if (listViewItemScript != null)
				{
					base.ListView.SelectedItem = listViewItemScript;
				}
				else
				{
					ShowDetailsForCraftWithID(_autoSelectCraftID);
				}
				_autoSelectCraftID = null;
			}
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			listView.SetHeaderText(_title);
			string url = Game.SimplePlanesWebsiteUrl + "/Client/PostNavigation";
			_webCache.GetText(url, 10, delegate(WebYieldRequest<string> request)
			{
				NavigationGroupScript navGroup = listView.CreateNavGroup("CRAFTS");
				_navStock = listView.CreateNavItem(navGroup, "Stock");
				_navDownloaded = listView.CreateNavItem(navGroup, "Recents");
				_navStarred = listView.CreateNavItem(navGroup, "Starred");
				if (!Game.Instance.Device.IsAndroidVRBuild)
				{
					_navSaved = listView.CreateNavItem(navGroup, "Designer");
				}
				string text = null;
				if (request.Success)
				{
					ClientResponse clientResponse = WebUtility.CreateClientResponse(request.Data);
					if (clientResponse.Succeeded)
					{
						PostNavigationModel postNavigationModel = new PostNavigationModel(clientResponse);
						base.ListView.MaxSimultaneousFilters = postNavigationModel.MaxTagsAtOnce;
						if (Game.Instance.Settings.App.IsLoggedIn)
						{
							_accountNavGroup = listView.CreateNavGroup("ACCOUNT");
							listView.CreateNavItem(_accountNavGroup, "Jet Stream", "JetStream");
							listView.CreateNavItem(_accountNavGroup, "Favorites", "Favorites");
							listView.CreateNavItem(_accountNavGroup, "Your Uploads", "Uploads");
							if (Game.Instance.Settings.App.UserIsCurator)
							{
								listView.CreateNavItem(_accountNavGroup, "Curator Queue", "CuratorQueue");
							}
						}
						_onlineNavGroup = listView.CreateNavGroup("ONLINE");
						foreach (PostNavigationModel.NavigationOption link in postNavigationModel.Links)
						{
							listView.CreateNavItem(_onlineNavGroup, link.Name, link.Id);
						}
						_tagsNavGroup = listView.CreateNavGroup("TAGS");
						foreach (PostNavigationModel.NavigationOption tag in postNavigationModel.Tags)
						{
							if (tag.Id != "VR")
							{
								CreateNavFilter(_tagsNavGroup, tag.Name, tag.Id);
							}
						}
						_filtersNavGroup = listView.CreateNavGroup("FILTERS");
						_vrOnly = CreateNavFilter(_filtersNavGroup, "VR Only", "VR", includeInFilterCount: false);
						_vrOnly.IsChecked = true;
						if (Game.Instance.Settings.App.IsLoggedIn)
						{
							_curatedFilter = CreateNavFilter(_filtersNavGroup, "Curated Only", "Curated", includeInFilterCount: false);
						}
						_tagsNavGroup.Visible = false;
					}
					else
					{
						text = clientResponse.Error;
					}
				}
				else
				{
					text = request.ErrorMessage;
				}
				if (text != null)
				{
					_onlineNavGroup = listView.CreateNavGroup("OFFLINE");
				}
				RestoreNavLocation();
			});
		}

		public override void OnSelectButtonClicked(ListViewItemScript selectedItem)
		{
			TrackedCraftList.TrackedCraft selectedCraft = _selectedCraft;
			if (selectedCraft != null)
			{
				_trackedCrafts.AddOrUpdateCraft(selectedCraft);
				this.OnCraftSelected?.Invoke(selectedCraft);
				base.ListView.Close();
			}
			else
			{
				VRDialogScript.CreateDialog(showOkay: true, showCancel: false).MessageText = "Unable to load craft";
			}
		}

		public override void OnSelectedNavItemChanged()
		{
			base.PagingEnabled = false;
			base.PageNextEnabled = false;
			base.Page = _restorePage;
			base.ListView.RefreshItems();
			_restorePage = 1;
		}

		public void ShowDetailsForCraftWithID(string urlID)
		{
			base.ListView.Details.Visible = true;
			base.ListView.StartCoroutine(UpdateDetails(null, urlID));
		}

		public override void UpdateDetailsPanel(ItemModel model, ListViewDetailsScript details)
		{
			TrackedCraftList.TrackedCraft craft = (model as CraftItemModel).Craft;
			base.ListView.StartCoroutine(UpdateDetails(craft, null));
		}

		private static string ConvertHtmlToTextMeshPro(string text)
		{
			if (text == null)
			{
				text = string.Empty;
			}
			return ListViewUtilities.StripHTML(text);
		}

		private static List<TrackedCraftList.TrackedCraft> GetSavedCrafts()
		{
			List<CraftFileInfo> crafts = Game.Instance.CraftDatabase.GetCrafts();
			CraftFileInfo craftFileInfo;
			List<TrackedCraftList.TrackedCraft> list = new List<TrackedCraftList.TrackedCraft>
			{
				new TrackedCraftList.TrackedCraft
				{
					Title = "Designer Craft",
					Author = null,
					ThumbnailPath = null,
					XmlPath = (Game.Instance.CraftDatabase.TryGetCraft("__editor__.xml", out craftFileInfo) ? craftFileInfo.FullFilePath : null),
					XmlLocation = ResourceLocation.File,
					LastUpdated = DateTime.UtcNow
				}
			};
			foreach (CraftFileInfo item in crafts)
			{
				TrackedCraftList.TrackedCraft trackedCraft = new TrackedCraftList.TrackedCraft();
				trackedCraft.Title = item.Name;
				trackedCraft.Author = null;
				trackedCraft.ThumbnailPath = null;
				trackedCraft.XmlPath = item.FullFilePath;
				trackedCraft.XmlLocation = ResourceLocation.File;
				trackedCraft.LastUpdated = DateTime.UtcNow;
				list.Add(trackedCraft);
			}
			return list;
		}

		private static void SetPerformanceCost(ListViewDetailsScript details, DetailsModel detailsModel)
		{
			ListViewDetailsScript.PerformanceLoad load = ListViewDetailsScript.PerformanceLoad.Normal;
			if (detailsModel.PerformanceCost <= 0f)
			{
				load = ListViewDetailsScript.PerformanceLoad.Unknown;
			}
			else if (detailsModel.PerformanceCost > (float)PerformanceCostThresholdHeavy)
			{
				load = ListViewDetailsScript.PerformanceLoad.Heavy;
			}
			else if (detailsModel.PerformanceCost > (float)PerformanceCostThresholdModerate)
			{
				load = ListViewDetailsScript.PerformanceLoad.Moderate;
			}
			details.SetPerformanceInfo(visible: true, detailsModel.PartCount, detailsModel.PerformanceCost, load, detailsModel.DownloadCount, detailsModel.Post.VoteCount);
		}

		private NavigationItemScript CreateNavFilter(NavigationGroupScript navGroup, string name, object userData = null, bool includeInFilterCount = true)
		{
			NavigationItemScript navigationItemScript = base.ListView.CreateNavFilter(navGroup, name, userData, includeInFilterCount);
			_navigationItems.Add(navigationItemScript);
			return navigationItemScript;
		}

		private void HideDetailElements()
		{
			ListViewDetailsScript details = base.ListView.Details;
			details.ShowCurationPanel(show: false);
			details.StarButton.SetButtonStates(visible: false, selected: false);
			details.UpvoteButton.SetButtonStates(visible: false, selected: false);
			details.FavoriteButton.SetButtonStates(visible: false, selected: false);
			details.AuthorUI.Show(show: false);
			details.TagsUI.Clear();
			details.SetSelectButtonText(string.Empty);
			details.SetBodyText(string.Empty);
			details.SetPerformanceInfo(visible: false, 0, 0f, ListViewDetailsScript.PerformanceLoad.Normal, 0, 0);
			details.SetPreviewSprite(null);
		}

		private IEnumerator LoadItemsOnline(string sort, List<TrackedCraftList.TrackedCraft> crafts)
		{
			int expirationInMinutes = 10;
			string text;
			switch (sort)
			{
			case "Favorites":
				expirationInMinutes = -1;
				_tagsNavGroup.Visible = false;
				_filtersNavGroup.Visible = false;
				text = Game.SimplePlanesWebsiteUrl + $"/Client/ListFavorites?page={base.Page}&clientToken={Game.Instance.Settings.App.ClientToken}&deviceId={Game.Instance.Device.DeviceId}";
				break;
			case "Uploads":
				expirationInMinutes = -1;
				_tagsNavGroup.Visible = false;
				_filtersNavGroup.Visible = false;
				text = Game.SimplePlanesWebsiteUrl + $"/Client/ListUploads?page={base.Page}&clientToken={Game.Instance.Settings.App.ClientToken}&deviceId={Game.Instance.Device.DeviceId}";
				break;
			case "JetStream":
				expirationInMinutes = -1;
				_tagsNavGroup.Visible = false;
				_filtersNavGroup.Visible = false;
				text = Game.SimplePlanesWebsiteUrl + $"/Client/ListJetStream?page={base.Page}&clientToken={Game.Instance.Settings.App.ClientToken}&deviceId={Game.Instance.Device.DeviceId}";
				break;
			case "CuratorQueue":
				expirationInMinutes = -1;
				_tagsNavGroup.Visible = false;
				_filtersNavGroup.Visible = false;
				text = Game.SimplePlanesWebsiteUrl + $"/Client/ListCuratorQueue?page={base.Page}";
				break;
			default:
			{
				_tagsNavGroup.Visible = true;
				_filtersNavGroup.Visible = true;
				text = Game.SimplePlanesWebsiteUrl + $"/Client/ListAirplanes?sort={sort}&page={base.Page}&mobile={Game.Instance.Device.IsMobileBuild}";
				string text2 = string.Join(",", from x in _tagsNavGroup.NavigationItems
					where x.IsChecked && x != _curatedFilter
					orderby x.Name
					select x.UserData);
				if (_vrOnly.IsChecked)
				{
					text2 = _vrOnly.UserData.ToString() + (string.IsNullOrWhiteSpace(text2) ? string.Empty : ("," + text2));
				}
				if (!string.IsNullOrEmpty(text2))
				{
					text = text + "&tags=" + text2;
				}
				if (_curatedFilter != null && !_curatedFilter.IsChecked)
				{
					text += "&curated=false";
				}
				break;
			}
			}
			WebYieldRequest<string> request = _webCache.GetText(text, expirationInMinutes);
			while (!request.Done)
			{
				yield return new WaitForEndOfFrame();
			}
			string text3 = null;
			if (request.Success)
			{
				ClientResponse clientResponse = WebUtility.CreateClientResponse(request.Data);
				if (clientResponse.Succeeded)
				{
					PostsModel postsModel = new PostsModel(clientResponse);
					foreach (PostsModel.Post post in postsModel.Posts)
					{
						TrackedCraftList.TrackedCraft item = new TrackedCraftList.TrackedCraft(post, postsModel.GeneratedDateTime);
						crafts.Add(item);
					}
				}
				else
				{
					text3 = clientResponse.Error;
				}
			}
			else
			{
				text3 = request.ErrorMessage;
			}
			if (text3 != null)
			{
				base.ListView.ShowErrorMessage(text3);
			}
		}

		private void RefreshCurationButtons(DetailsModel detailsModel)
		{
			ListViewDetailsScript details = base.ListView.Details;
			details.CurateApproveButton.SetButtonStates(visible: true, detailsModel.CuratedStatus == DetailsModel.CuratedStatusType.Approved);
			details.CurateRejectButton.SetButtonStates(visible: true, detailsModel.CuratedStatus == DetailsModel.CuratedStatusType.Rejected);
			details.CurateResetButton.SetButtonStates(visible: true, detailsModel.CuratedStatus == DetailsModel.CuratedStatusType.None);
		}

		private void RestoreNavLocation()
		{
			try
			{
				if (_lastNavLocation != null)
				{
					if (!string.IsNullOrWhiteSpace(_lastTagsSelected))
					{
						foreach (NavigationItemScript navigationItem in _navigationItems)
						{
							navigationItem.IsChecked = false;
						}
						string[] array = _lastTagsSelected.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
						foreach (string tag in array)
						{
							NavigationItemScript navigationItemScript = _navigationItems.Where((NavigationItemScript x) => x.UserData as string == tag).FirstOrDefault();
							if (navigationItemScript != null)
							{
								base.ListView.SetFilterState(navigationItemScript, enabled: true, notifyModel: false);
							}
						}
					}
					string[] array2 = _lastNavLocation.Split(new char[1] { '/' }, StringSplitOptions.None);
					string navGroupName = array2[0];
					string navItemName = array2[1];
					int result = 0;
					int.TryParse(array2[2], out result);
					NavigationItemScript navigationItemScript2 = base.ListView.NavGroups.Where((NavigationGroupScript x) => x.Name == navGroupName).FirstOrDefault()?.NavigationItems.Where((NavigationItemScript x) => x.Name == navItemName).FirstOrDefault();
					if (navigationItemScript2 != null)
					{
						_restorePage = result;
						base.ListView.SelectedNavItem = navigationItemScript2;
					}
				}
				if (base.ListView.SelectedNavItem == null)
				{
					base.ListView.SelectedNavItem = _navStock;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void SaveNavLocation()
		{
			try
			{
				NavigationItemScript selectedNavItem = base.ListView.SelectedNavItem;
				_lastNavLocation = $"{selectedNavItem.NavGroup.Name}/{selectedNavItem.Name}/{base.Page}";
				_lastTagsSelected = string.Empty;
				foreach (NavigationItemScript navigationItem in _navigationItems)
				{
					if (navigationItem.IsChecked)
					{
						_lastTagsSelected = _lastTagsSelected + navigationItem.UserData?.ToString() + ",";
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private WebYieldRequest<string> SubmitToggleRequest(string url, WebYieldRequest<string> request, object value, string valueUrlParamName = "value")
		{
			if (request != null && !request.Done && !request.Canceled)
			{
				Debug.Log("Canceled request " + url);
				request.Cancel();
				request = null;
			}
			else
			{
				url = url + "?clientToken=" + Game.Instance.Settings.App.ClientToken + "&deviceId=" + Game.Instance.Device.DeviceId + $"&{valueUrlParamName}={value}" + "&deviceType=" + GetVRDeviceTypeName();
				request = _webCache.GetText(url, -1, delegate
				{
				}, 1f);
			}
			return request;
		}

		private void UpdateCraftDetails(string detailsUrl, DetailsModel detailsModel)
		{
			ListViewDetailsScript details = base.ListView.Details;
			TrackedCraftList.TrackedCraft craft = new TrackedCraftList.TrackedCraft(detailsModel.Post, detailsModel.GeneratedDateTime);
			TrackedCraftList.TrackedCraft trackedCraft = _trackedCrafts.Crafts.Where((TrackedCraftList.TrackedCraft x) => x.UrlId == craft.UrlId).FirstOrDefault();
			if (trackedCraft != null && (trackedCraft.IsStock || trackedCraft.LastUpdated >= craft.LastUpdated))
			{
				craft = trackedCraft;
			}
			_selectedCraft = craft;
			if (detailsModel.ImageUrls.Count > 0 || craft.IsStock)
			{
				YieldRequest<Texture2D> imageRequest = new YieldRequest<Texture2D>();
				imageRequest.Callback = delegate
				{
					if (imageRequest.Success && !(_detailsCraftUrlId != craft.UrlId))
					{
						details.SetPreviewSprite(ItemModel.CreateSpriteFromTexture(imageRequest.Data));
					}
				};
				if (craft.IsStock)
				{
					base.ListView.StartCoroutine(ListViewUtilities.LoadTexture(craft.ThumbnailLocation, craft.ThumbnailPath, imageRequest));
				}
				else
				{
					base.ListView.StartCoroutine(ListViewUtilities.LoadTexture(ResourceLocation.Web, detailsModel.ImageUrls[0], imageRequest));
				}
			}
			details.SetHeaderText(craft.Title);
			details.SetSelectButtonText("SELECT CRAFT");
			string text = detailsModel.Description;
			if (detailsModel.DescriptionFormat == FormatType.Html)
			{
				text = ConvertHtmlToTextMeshPro(text);
			}
			details.SetBodyText(text);
			details.AuthorUI.Show(!craft.IsStock);
			details.AuthorUI.SetAuthor(detailsModel.UserPoints, detailsModel.UserName, detailsModel.Post.CreatedDateTime);
			details.TagsUI.Clear();
			if (detailsModel.IsCraft)
			{
				craft.XmlRevision = detailsModel.XmlRevision;
				_trackedCrafts.UpdateCraft(craft);
				details.ShowButtonPanel(show: true);
				if (!craft.IsStock)
				{
					SetPerformanceCost(details, detailsModel);
				}
				else
				{
					details.SetPerformanceInfo(visible: false, 0, 0f, ListViewDetailsScript.PerformanceLoad.Normal, 0, 0);
				}
				foreach (DetailsModel.TagModel tag in detailsModel.Tags)
				{
					details.TagsUI.CreateTag(tag.Name);
				}
				UpdateDetailsButtons(detailsUrl, detailsModel, craft);
				if (craft.IsStarred && !craft.IsStock)
				{
					UpdatePinnedCraftFiles(craft);
				}
			}
			else
			{
				details.ShowButtonPanel(show: false);
				details.SetPerformanceInfo(visible: false, 0, 0f, ListViewDetailsScript.PerformanceLoad.Normal, 0, 0);
			}
		}

		private IEnumerator UpdateDetails(TrackedCraftList.TrackedCraft craft, string urlId)
		{
			_selectedCraft = null;
			ListViewDetailsScript details = base.ListView.Details;
			details.SetBodyText("Loading...");
			details.SetPreviewSprite(null);
			urlId = craft?.UrlId ?? urlId;
			if (!string.IsNullOrWhiteSpace(urlId))
			{
				ResourceLocation location;
				string detailsUrl;
				if (_trackedCrafts.Crafts.Where((TrackedCraftList.TrackedCraft x) => x.UrlId == urlId).FirstOrDefault()?.IsStock ?? false)
				{
					detailsUrl = "Data/StockAircraftDetails/" + urlId;
					location = ResourceLocation.Resource;
				}
				else
				{
					detailsUrl = Game.SimplePlanesWebsiteUrl + "/Client/";
					location = ResourceLocation.Web;
					Game instance = Game.Instance;
					detailsUrl = ((!instance.Settings.App.IsLoggedIn) ? (detailsUrl + "GetPostDetails/" + urlId) : (detailsUrl + "GetPostDetailsAuthenticated/" + urlId + "?deviceId=" + instance.Device.DeviceId + "&clientToken=" + instance.Settings.App.ClientToken));
				}
				_requestCurateApprove = null;
				_requestCurateReject = null;
				_requestCurateReset = null;
				_requestUpvote = null;
				_requestFavorite = null;
				_detailsCraftUrlId = urlId;
				YieldRequest<string> request = new YieldRequest<string>();
				yield return ListViewUtilities.LoadText(location, detailsUrl, request, 60);
				if (!(_detailsCraftUrlId == urlId))
				{
					yield break;
				}
				string text = null;
				if (request.Success)
				{
					ClientResponse clientResponse = WebUtility.CreateClientResponse(request.Data);
					if (clientResponse.Succeeded)
					{
						DetailsModel detailsModel = new DetailsModel(clientResponse);
						UpdateCraftDetails(detailsUrl, detailsModel);
					}
					else
					{
						text = clientResponse.Error;
					}
				}
				else
				{
					Debug.LogError("Request failed for craft details: \n" + request.ErrorMessage);
					TrackedCraftList.TrackedCraft trackedCraft = _trackedCrafts.Crafts.Where((TrackedCraftList.TrackedCraft x) => x.UrlId == urlId).FirstOrDefault();
					if (trackedCraft != null && _webCache.ContainsKey(trackedCraft.XmlUrl))
					{
						_selectedCraft = trackedCraft;
						HideDetailElements();
						details.SetHeaderText(_selectedCraft.Title);
						details.SetBodyText("Unable to download craft details, but the craft design is cached and can be loaded.");
						details.SetSelectButtonText("SELECT CRAFT");
						text = null;
					}
					else
					{
						text = "Request failed. Please, try again later.";
					}
				}
				if (text != null)
				{
					HideDetailElements();
					details.SetHeaderText(string.Empty);
					details.SetBodyText(text);
				}
			}
			else
			{
				HideDetailElements();
				if (craft != null)
				{
					_selectedCraft = craft;
					details.SetBodyText(craft.XmlPath);
					details.SetHeaderText(craft.Title);
				}
			}
		}

		private void UpdateDetailsButtons(string detailsUrl, DetailsModel detailsModel, TrackedCraftList.TrackedCraft craft)
		{
			ListViewDetailsScript details = base.ListView.Details;
			details.StarButton.SetButtonStates(craft.XmlLocation != ResourceLocation.File || craft.IsStarred, craft.IsStarred);
			details.StarButton.Callback = delegate(ToggleButtonScript d)
			{
				craft.SetStarred(!craft.IsStarred);
				_trackedCrafts.AddOrUpdateCraft(craft);
				d.SetButtonStates(visible: true, craft.IsStarred);
				if (craft.IsStarred)
				{
					if (!craft.IsStock)
					{
						UpdatePinnedCraftFiles(craft);
					}
				}
				else
				{
					_webCache.UnpinCacheItems(craft.UrlId);
				}
			};
			if (Game.Instance.Settings.App.IsLoggedIn && !craft.IsStock)
			{
				if (detailsModel.CanUpvote)
				{
					details.UpvoteButton.SetButtonStates(visible: true, detailsModel.Upvoted);
					details.UpvoteButton.Callback = delegate(ToggleButtonScript d)
					{
						detailsModel.Upvoted = !detailsModel.Upvoted;
						string url = Game.SimplePlanesWebsiteUrl + "/Client/SubmitUpvotePost/" + craft.UrlId;
						_requestUpvote = SubmitToggleRequest(url, _requestUpvote, detailsModel.Upvoted);
						_webCache.RemoveCacheItem(detailsUrl);
						d.SetButtonStates(visible: true, detailsModel.Upvoted);
					};
				}
				else
				{
					details.UpvoteButton.SetButtonStates(visible: false, selected: false);
				}
				if (detailsModel.CanFavorite)
				{
					details.FavoriteButton.SetButtonStates(visible: true, detailsModel.Favorite);
					details.FavoriteButton.Callback = delegate(ToggleButtonScript d)
					{
						detailsModel.Favorite = !detailsModel.Favorite;
						string url = Game.SimplePlanesWebsiteUrl + "/Client/SubmitFavoritePost/" + craft.UrlId;
						_requestFavorite = SubmitToggleRequest(url, _requestFavorite, detailsModel.Favorite);
						_webCache.RemoveCacheItem(detailsUrl);
						d.SetButtonStates(visible: true, detailsModel.Favorite);
					};
				}
				else
				{
					details.FavoriteButton.SetButtonStates(visible: false, selected: false);
				}
				if (Game.Instance.Settings.App.UserIsCurator)
				{
					string curateUrl = Game.SimplePlanesWebsiteUrl + "/Client/SubmitCuratePost/" + craft.UrlId;
					Func<WebYieldRequest<string>, DetailsModel.CuratedStatusType, WebYieldRequest<string>> curateFunc = delegate(WebYieldRequest<string> r, DetailsModel.CuratedStatusType s)
					{
						_requestCurateApprove?.Cancel();
						_requestCurateReject?.Cancel();
						_requestCurateReset?.Cancel();
						detailsModel.CuratedStatus = s;
						r = SubmitToggleRequest(curateUrl, _requestCurateApprove, detailsModel.CuratedStatus, "status");
						_webCache.RemoveCacheItem(detailsUrl);
						RefreshCurationButtons(detailsModel);
						return r;
					};
					details.CurateApproveButton.Callback = delegate
					{
						_requestCurateApprove = curateFunc(_requestCurateApprove, DetailsModel.CuratedStatusType.Approved);
					};
					details.CurateRejectButton.Callback = delegate
					{
						_requestCurateReject = curateFunc(_requestCurateReject, DetailsModel.CuratedStatusType.Rejected);
					};
					details.CurateResetButton.Callback = delegate
					{
						_requestCurateReset = curateFunc(_requestCurateReset, DetailsModel.CuratedStatusType.None);
					};
					details.ShowCurationPanel(show: true);
					RefreshCurationButtons(detailsModel);
				}
			}
			else
			{
				details.ShowCurationPanel(show: false);
				details.UpvoteButton.SetButtonStates(visible: false, selected: false);
				details.FavoriteButton.SetButtonStates(visible: false, selected: false);
			}
		}

		private void UpdatePinnedCraftFiles(TrackedCraftList.TrackedCraft craft)
		{
			Action pinCraft = delegate
			{
				_webCache.UnpinCacheItems(craft.UrlId);
				_webCache.PinCacheItem(craft.XmlUrl, craft.UrlId);
				_webCache.PinCacheItem(craft.ThumbnailPath, craft.UrlId);
			};
			if (!_webCache.ContainsKey(craft.XmlUrl))
			{
				Debug.Log("Downloading craft XML so it can be pinned.");
				_webCache.GetBinary(craft.XmlUrl, 0, delegate(WebYieldRequest<byte[]> result)
				{
					if (result.Success)
					{
						pinCraft();
					}
				});
			}
			else
			{
				pinCraft();
			}
		}
	}
}
