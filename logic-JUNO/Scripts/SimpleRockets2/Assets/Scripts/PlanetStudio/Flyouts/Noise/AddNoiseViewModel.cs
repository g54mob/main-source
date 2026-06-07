using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Menu.ListView;
using ModApi;
using ModApi.Planet;
using ModApi.Planet.Modifiers;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Planet.Modifiers.VertexData;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts.Noise
{
	public class AddNoiseViewModel : ListViewModel
	{
		public class PlanetModifierElement
		{
			public string Description { get; set; }

			public Type ModifierType { get; set; }

			public string Name { get; set; }

			public VertexDataPlanetModifierPassType[] SupportedPasses { get; set; }

			public VertexDataType VertexDataType { get; set; }
		}

		private static List<PlanetModifierElement> _elementsCache = null;

		private static List<string> _recentlyUsed = new List<string>();

		private AddNoiseDetails _details;

		public Action<VertexDataPlanetModifier> OnComplete { get; set; }

		public VertexDataPlanetModifierPassType Pass { get; }

		public VertexDataType VertexDataType { get; }

		public AddNoiseViewModel(VertexDataPlanetModifierPassType pass, VertexDataType vertexDataType)
		{
			Pass = pass;
			VertexDataType = vertexDataType;
		}

		public override IEnumerator LoadItems()
		{
			_details = new AddNoiseDetails(base.ListView.ListViewDetails);
			yield return new WaitForEndOfFrame();
			ListViewItemScript selectedItem = null;
			if (_elementsCache == null)
			{
				CachePlanetModifierElements();
			}
			foreach (string recent in _recentlyUsed)
			{
				PlanetModifierElement planetModifierElement = _elementsCache.Where((PlanetModifierElement x) => x.Name == recent).FirstOrDefault();
				if (planetModifierElement != null && planetModifierElement.SupportedPasses.Contains(Pass) && (planetModifierElement.VertexDataType & VertexDataType) != 0)
				{
					base.ListView.CreateItem(planetModifierElement.Name, "Recently used", planetModifierElement, null, ListViewScript.SpriteLoadLocation.Resources).FilterKeywords.Add("Recent");
				}
			}
			foreach (PlanetModifierElement item in _elementsCache)
			{
				if (item.SupportedPasses.Contains(Pass) && (item.VertexDataType & VertexDataType) != 0)
				{
					base.ListView.CreateItem(item.Name, string.Empty, item, null, ListViewScript.SpriteLoadLocation.Resources);
				}
			}
			yield return new WaitForEndOfFrame();
			base.ListView.SelectedItem = selectedItem;
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			listView.Title = "Add Noise Modifier";
			listView.CanDelete = false;
			listView.PrimaryButtonText = "Add";
			listView.DisplayType = ListViewScript.ListViewDisplayType.LargeDialog;
			listView.CreateFilter(true, "Recently Used", "Show recently used at the top of the list.", ListViewFilterType.Include, false, "Recent");
		}

		public override void OnPrimaryButtonClicked(ListViewItemScript selectedItem)
		{
			if (selectedItem != null)
			{
				PlanetModifierElement planetModifierElement = selectedItem.ItemModel as PlanetModifierElement;
				VertexDataPlanetModifier vertexDataPlanetModifier = new GameObject(planetModifierElement.ModifierType.Name).AddComponent(planetModifierElement.ModifierType) as VertexDataPlanetModifier;
				vertexDataPlanetModifier.Name = planetModifierElement.Name;
				VertexDataCommonPassPlanetModifier vertexDataCommonPassPlanetModifier = vertexDataPlanetModifier as VertexDataCommonPassPlanetModifier;
				if (vertexDataCommonPassPlanetModifier != null)
				{
					vertexDataCommonPassPlanetModifier.SetPass(Pass, null);
				}
				if (vertexDataPlanetModifier.Pass != Pass)
				{
					Debug.LogErrorFormat("Modifier pass {0} does not match expected pass {1}", vertexDataPlanetModifier.Pass, Pass);
				}
				_recentlyUsed.Remove(vertexDataPlanetModifier.Name);
				_recentlyUsed.Insert(0, vertexDataPlanetModifier.Name);
				if (_recentlyUsed.Count > 7)
				{
					_recentlyUsed.RemoveRange(7, _recentlyUsed.Count - 7);
				}
				OnComplete?.Invoke(vertexDataPlanetModifier);
				base.ListView.Close();
			}
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			if (item != null)
			{
				PlanetModifierElement itemModel = item.ItemModel as PlanetModifierElement;
				_details.UpdateDetails(itemModel);
			}
			completeCallback?.Invoke();
		}

		private static void CheckModifierVertexTypeSupport(VertexDataPlanetModifier vertexDataScript)
		{
			PlanetVertexDataInput input = new PlanetVertexDataInput();
			PlanetVertexData data = new PlanetVertexData(new TerrainGeneratorCacheData(1, 1));
			PlanetBiomeVertexData data2 = new PlanetBiomeVertexData();
			try
			{
				vertexDataScript.GetVertexData(input, data);
			}
			catch (NotSupportedException)
			{
				if (vertexDataScript.SupportsVertexDataType(VertexDataType.Common))
				{
					Debug.LogFormat("{0} does not support Common Pass", vertexDataScript?.Name);
				}
			}
			try
			{
				vertexDataScript.GetVertexData(input, data2);
			}
			catch (NotSupportedException)
			{
				if (vertexDataScript.SupportsVertexDataType(VertexDataType.Biome))
				{
					Debug.LogFormat("{0} does not support Biome Pass", vertexDataScript?.Name);
				}
			}
		}

		private void CachePlanetModifierElements()
		{
			List<PlanetModifierElement> list = new List<PlanetModifierElement>();
			GameObject gameObject = new GameObject("AddNoiseViewModel-ModifierCache");
			foreach (Type planetModifierType in PlanetModifier.GetPlanetModifierTypes())
			{
				PlanetModifierElement planetModifierElement = new PlanetModifierElement();
				planetModifierElement.Name = Utilities.FormatCodeToDisplayName(planetModifierType.Name);
				planetModifierElement.ModifierType = planetModifierType;
				if (!planetModifierType.IsSubclassOf(typeof(VertexDataPlanetModifier)))
				{
					continue;
				}
				PlanetModifierInfoAttribute planetModifierInfoAttribute = planetModifierType.GetCustomAttributes(typeof(PlanetModifierInfoAttribute), inherit: false).Cast<PlanetModifierInfoAttribute>().FirstOrDefault();
				if (planetModifierInfoAttribute != null)
				{
					if (planetModifierInfoAttribute.IsHidden)
					{
						continue;
					}
					if (!string.IsNullOrWhiteSpace(planetModifierInfoAttribute.DisplayName))
					{
						planetModifierElement.Name = planetModifierInfoAttribute.DisplayName;
					}
					planetModifierElement.Description = planetModifierInfoAttribute.Description;
				}
				else
				{
					planetModifierElement.Description = "No description has been provided.";
				}
				VertexDataPlanetModifier vertexDataPlanetModifier = gameObject.AddComponent(planetModifierType) as VertexDataPlanetModifier;
				planetModifierElement.SupportedPasses = vertexDataPlanetModifier.SupportedPassTypes;
				planetModifierElement.VertexDataType = vertexDataPlanetModifier.VertexDataType;
				list.Add(planetModifierElement);
			}
			_elementsCache = list.OrderBy((PlanetModifierElement x) => x.Name).ToList();
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
