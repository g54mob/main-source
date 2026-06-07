using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Packages.SocialPlatforms;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Sharing;
using Assets.Scripts.Sharing.Handlers.CelestialDatabase;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Flight.MapView;
using ModApi.Ioc;
using ModApi.Planet;
using TMPro;
using UI.Xml;
using UnityEngine;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class SystemPlanetsFlyoutScript : PlanetStudioFlyoutScript
	{
		public class PlanetElement
		{
			private bool? _isUploaded;

			public bool? IsUploaded
			{
				get
				{
					return _isUploaded;
				}
				set
				{
					if (_isUploaded != value)
					{
						_isUploaded = value;
						if (value == true)
						{
							RowElement.AddClass("uploaded-yes");
						}
						else
						{
							RowElement.AddClass("uploaded-no");
						}
					}
				}
			}

			public TextMeshProUGUI NameText { get; set; }

			public PlanetDataScript Planet { get; }

			public XmlElement RowElement { get; set; }

			public bool Visible
			{
				get
				{
					return RowElement.gameObject.activeSelf;
				}
				set
				{
					RowElement.gameObject.SetActive(value);
				}
			}

			public PlanetElement(PlanetDataScript planet)
			{
				Planet = planet;
			}
		}

		public class ResourceUploadStateCache
		{
			private Dictionary<Guid, bool> _uploaded = new Dictionary<Guid, bool>();

			public bool? IsUploaded(Guid id)
			{
				if (_uploaded.ContainsKey(id))
				{
					return _uploaded[id];
				}
				return null;
			}

			public void SetIsUploaded(Guid id, bool uploaded)
			{
				_uploaded[id] = uploaded;
			}
		}

		private ResourceUploadStateCache _cache = new ResourceUploadStateCache();

		private TMP_InputField _searchInput;

		private PlanetElement _selectedObject;

		public PlanetarySystemDesignerScript Designer => base.PlanetStudioUI.PlanetStudioScript?.PlanetarySystemDesignerScript;

		public List<PlanetElement> Planets { get; private set; } = new List<PlanetElement>();

		public PlanetElement SelectedPlanet
		{
			get
			{
				return _selectedObject;
			}
			private set
			{
				if (_selectedObject != value)
				{
					if (_selectedObject != null)
					{
						_selectedObject.RowElement.RemoveClass("selected");
					}
					_selectedObject = value;
					if (_selectedObject != null)
					{
						_selectedObject.RowElement.AddClass("selected");
					}
				}
			}
		}

		protected override void OnFlyoutClosed()
		{
			base.OnFlyoutClosed();
		}

		protected override void OnInitialized(PlanetStudioUIScript planetStudioUI)
		{
			base.OnInitialized(planetStudioUI);
			_searchInput = base.xmlLayout.GetElementById<TMP_InputField>("search-input");
		}

		protected override void RefreshUI()
		{
			base.RefreshUI();
			SelectedPlanet = null;
			foreach (PlanetElement planet in Planets)
			{
				UnityEngine.Object.Destroy(planet.RowElement.gameObject);
			}
			List<PlanetElement> list = new List<PlanetElement>();
			Planets.Clear();
			List<PlanetDataScript> list2 = new List<PlanetDataScript>();
			CreateListRecursively(null, list2, Designer.CurrentPlanetarySystem.Planets);
			foreach (PlanetDataScript item in list2)
			{
				PlanetElement planetElement = new PlanetElement(item);
				Planets.Add(planetElement);
				planetElement.RowElement = CreateRowElement(planetElement);
				planetElement.IsUploaded = _cache.IsUploaded(item.File.Id);
				if (!planetElement.IsUploaded.HasValue)
				{
					list.Add(planetElement);
				}
			}
			if (list.Count > 0)
			{
				StartCoroutine(QueryUploadStates(list));
			}
			ApplySearchFilter(_searchInput.text);
			if (!Device.IsMobileBuild && !SocialExt.IsSteamDeckOrBigPicture)
			{
				_searchInput.Select();
			}
		}

		private static int CountParentPlanets(PlanetDataScript planet)
		{
			if (planet.Parent == null)
			{
				return 0;
			}
			return CountParentPlanets(planet.Parent) + 1;
		}

		private static void CreateListRecursively(PlanetDataScript parent, List<PlanetDataScript> list, List<PlanetDataScript> sourcePlanets)
		{
			foreach (PlanetDataScript sourcePlanet in sourcePlanets)
			{
				if (sourcePlanet.Parent == parent)
				{
					list.Add(sourcePlanet);
					CreateListRecursively(sourcePlanet, list, sourcePlanets);
				}
			}
		}

		private void ApplySearchFilter(string searchFilter)
		{
			foreach (PlanetElement planet in Planets)
			{
				if (string.IsNullOrEmpty(searchFilter) || planet.NameText.text.IndexOf(searchFilter, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					planet.Visible = true;
				}
				else
				{
					planet.Visible = false;
				}
			}
		}

		private XmlElement CreateRowElement(PlanetElement planetElement)
		{
			XmlElement elementById = base.xmlLayout.GetElementById("row-template");
			XmlElement xmlElement = UiUtilities.CloneTemplate(elementById, elementById.parentElement);
			XmlElement elementByInternalId = xmlElement.GetElementByInternalId("name");
			planetElement.NameText = elementByInternalId.GetComponent<TextMeshProUGUI>();
			planetElement.NameText.text = planetElement.Planet.Name;
			xmlElement.GetElementByInternalId<TextMeshProUGUI>("type").text = $"v{planetElement.Planet.Version}\nby {planetElement.Planet.Author}";
			int num = Mathf.Max(0, CountParentPlanets(planetElement.Planet) - 1);
			if (num > 0)
			{
				elementByInternalId.SetAndApplyAttribute("offsetXY", $"{10 + 10 * num},0");
			}
			return xmlElement;
		}

		private void OnListItemClicked(XmlElement rowElement)
		{
			PlanetElement planetElement = Planets.Where((PlanetElement x) => x.RowElement == rowElement).FirstOrDefault();
			if (SelectedPlanet == planetElement)
			{
				SelectedPlanet = null;
				return;
			}
			SelectedPlanet = planetElement;
			IIocContainer ioc = Designer.MapViewManager.Ioc;
			IMapViewContext context = Designer.MapViewManager.MapView.Context;
			ioc.Resolve<ICurrentCameraTarget>(context);
			MapPlanet mapPlanet = ioc.Resolve<IItemRegistry>(context).Planets.Where((MapPlanet x) => x.ItemName == SelectedPlanet.Planet.Name).FirstOrDefault();
			if (mapPlanet != null)
			{
				ICameraFocusable cameraFocus = mapPlanet;
				Designer.MapViewManager.MapView.SetInspectorFocus(cameraFocus, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
			}
		}

		private IEnumerator QueryUploadStates(List<PlanetElement> resourceToQuery)
		{
			List<Guid> ids = resourceToQuery.Select((PlanetElement x) => x.Planet.File.Id).ToList();
			WebsiteRequest request = CheckResourcesExist.CreateRequest(ids);
			request.SendRequest();
			yield return new WaitUntil(() => request.IsDone);
			if (!request.Success)
			{
				yield break;
			}
			foreach (ResourceInfoResult.ResourceInfo resource in new ResourceInfoResult(request.Response).Resources)
			{
				Guid id = new Guid(resource.Hash);
				resourceToQuery.Where((PlanetElement x) => x.Planet.File.Id == id).First().IsUploaded = resource.Exists;
				_cache.SetIsUploaded(id, resource.Exists);
			}
		}
	}
}
