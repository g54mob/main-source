using System;
using System.Collections;
using Assets.Scripts.Career.Exploration;
using Assets.Scripts.Career.Milestones;
using ModApi;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.ListView.Career
{
	public class ExplorationViewModel : CareerViewModelBase
	{
		private ExplorationDetails _details;

		public override IEnumerator LoadItems()
		{
			_details = new ExplorationDetails(base.ListView.ListViewDetails);
			foreach (ExplorationNode node in Game.Instance.GameState.Career.Exploration.Nodes)
			{
				AddExplorationNode(node);
			}
			yield return new WaitForEndOfFrame();
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			listView.Title = "EXPLORATION";
			listView.CanDelete = false;
			listView.PrimaryButtonText = string.Empty;
			listView.DisplayType = ListViewScript.ListViewDisplayType.SmallDialog;
			listView.FooterEnabled = false;
			listView.XmlLayout.GetElementById("exploration-stars-header").Show();
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			if (item != null)
			{
				ExplorationNode explorationNode = item.ItemModel as ExplorationNode;
				base.ListView.DetailsTitleText = explorationNode.Name;
				_details.UpdateDetails(explorationNode, Game.Instance.GameState.Career.Milestones);
			}
			completeCallback?.Invoke();
		}

		private void AddExplorationNode(ExplorationNode node)
		{
			ListViewItemScript listViewItemScript = base.ListView.CreateItem(node.Name, string.Empty, node, null, null, "list-item-exploration");
			if (node.Indent > 0)
			{
				listViewItemScript.XmlElement.AddClass($"indent-{node.Indent}");
			}
			Image elementByInternalId = listViewItemScript.XmlElement.GetElementByInternalId<Image>("planet-icon");
			Sprite sprite = ("Ui/Sprites/Career/Planets/" + node.PlanetIconName).ToSprite(reportError: false);
			Texture2D texture2D = Utilities.LoadTextureFromFile(Utilities.CombinePaths(Game.Instance.GameState.Career.ResourcesAbsolutePath, "Images/", "PlanetIcons", node.PlanetIconName + ".png"));
			if (texture2D != null)
			{
				Debug.Log("found it for " + node.PlanetIconName);
				texture2D.wrapMode = TextureWrapMode.Clamp;
				sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0f, 0f), 100f, 0u, SpriteMeshType.FullRect);
			}
			else
			{
				Debug.Log(Utilities.CombinePaths(Game.Instance.GameState.Career.ResourcesAbsolutePath, "Images/", "PlanetIcons", node.PlanetIconName));
			}
			if (sprite != null)
			{
				elementByInternalId.sprite = sprite;
			}
			if (node.IsFlyByComplete)
			{
				listViewItemScript.XmlElement.GetElementByInternalId("fly-by").AddClass("star-complete");
			}
			if (node.IsOrbitComplete)
			{
				listViewItemScript.XmlElement.GetElementByInternalId("orbit").AddClass("star-complete");
			}
			if (node.IsContactComplete)
			{
				listViewItemScript.XmlElement.GetElementByInternalId("contact").AddClass("star-complete");
			}
			XmlElement elementByInternalId2 = listViewItemScript.XmlElement.GetElementByInternalId("landmarks");
			if (node.Landmarks.Count > 0)
			{
				if (node.IsLandmarksComplete)
				{
					elementByInternalId2.AddClass("star-complete");
				}
			}
			else
			{
				elementByInternalId2.SetActive(active: false);
			}
			XmlElement elementByInternalId3 = listViewItemScript.XmlElement.GetElementByInternalId("milestones");
			MilestoneContext milestones = Game.Instance.GameState.Career.Milestones;
			if (node.HasMilestones(milestones))
			{
				if (node.IsMilestonesComplete(milestones))
				{
					elementByInternalId3.AddClass("star-complete");
				}
			}
			else
			{
				elementByInternalId3.SetActive(active: false);
			}
		}
	}
}
