using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.State;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Planet;
using ModApi.Scripts.State;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class ActiveCraftsViewModel : ListViewModel
	{
		private CraftData _craftData;

		private CraftScript _craftScript;

		private List<CrewMember> _crewMembers = new List<CrewMember>();

		private ActiveCraftsDetails _details;

		private FlightStateData _flightStateData;

		private List<PlanetNode> _planetNodes;

		private SolarSystemDataScript _solarSystemData;

		public ActiveCraftsViewModel(FlightStateData flightStateData, SolarSystemDataScript solarSystemData, List<PlanetNode> planetNodes)
		{
			_flightStateData = flightStateData;
			_solarSystemData = solarSystemData;
			_planetNodes = planetNodes;
		}

		public override IEnumerator LoadItems()
		{
			_details = new ActiveCraftsDetails(base.ListView.ListViewDetails);
			List<ICraftNodeData> list = new List<ICraftNodeData>();
			foreach (ICraftNodeData craftNode in _flightStateData.CraftNodes)
			{
				list.Add(craftNode);
			}
			foreach (ICraftNodeData item in list.OrderBy((ICraftNodeData x) => x.Name).ToList())
			{
				base.ListView.CreateItem(item.Name, item.ParentName, item, null, ListViewScript.SpriteLoadLocation.Resources);
			}
			yield return new WaitForEndOfFrame();
		}

		public override void OnDeleteButtonClicked(ListViewItemScript selectedItem)
		{
			if (_craftScript == null)
			{
				DeleteNodeItem(selectedItem, saveGameState: true);
				return;
			}
			ICraftNodeData craftNodeData = selectedItem.ItemModel as ICraftNodeData;
			PlanetNode planet = _planetNodes.Where((PlanetNode x) => x.Name == craftNodeData.ParentName).First();
			RecoverCraftDialogScript recoverCraftDialogScript = RecoverCraftDialogScript.Create(new CraftRecovery(Game.Instance.GameState, _craftScript.Data, _craftScript.Mass, craftNodeData, planet));
			recoverCraftDialogScript.CraftDestroyed = delegate
			{
				DeleteNodeItem(selectedItem, saveGameState: true);
			};
			recoverCraftDialogScript.CraftRecovered = delegate
			{
				DeleteNodeItem(selectedItem, saveGameState: true);
			};
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			listView.Title = "Resume Flight";
			listView.CanDelete = true;
			listView.PrimaryButtonText = "RESUME";
			listView.CreateContextMenuItem("Remove All Debris", OnRemoveAllDebris, string.Empty);
		}

		public override void OnPrimaryButtonClicked(ListViewItemScript selectedItem)
		{
			if (_craftScript == null)
			{
				Game.Instance.UserInterface.CreateMessageDialog("Unable to resume the craft because it cannot be loaded.");
			}
			else if (_details.IsResumable)
			{
				ICraftNodeData craftNodeData = selectedItem.ItemModel as ICraftNodeData;
				Game.Instance.ResumeFlight(craftNodeData.NodeId, craftNodeData.ParentName);
			}
			else if (!_details.IsPlayerAllowed)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog();
				messageDialogScript.OkayButtonText = "OK";
				ICraftNodeData craftNodeData2 = selectedItem.ItemModel as ICraftNodeData;
				messageDialogScript.MessageText = "You are not allowed to take control of " + craftNodeData2.Name + " from this menu.";
				messageDialogScript.UseDangerButtonStyle = false;
			}
			else
			{
				MessageDialogScript messageDialogScript2 = Game.Instance.UserInterface.CreateMessageDialog();
				messageDialogScript2.OkayButtonText = "OK";
				ICraftNodeData craftNodeData3 = selectedItem.ItemModel as ICraftNodeData;
				messageDialogScript2.MessageText = craftNodeData3.Name + " is not resumable because it does not have a control unit.";
				messageDialogScript2.UseDangerButtonStyle = false;
			}
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			if (item != null)
			{
				ICraftNodeData craftNodeData = item.ItemModel as ICraftNodeData;
				_details.UpdateDetails(craftNodeData, _solarSystemData);
				if (_details.IsResumable)
				{
					base.ListView.PrimaryButtonText = "RESUME";
				}
				else
				{
					base.ListView.PrimaryButtonText = "NOT RESUMABLE";
				}
			}
			completeCallback?.Invoke();
		}

		public override void UpdatePreview(ListViewItemScript item, IListViewObjectViewer objectViewer, Action completeCallback)
		{
			_craftData = null;
			_crewMembers.Clear();
			if (!(item != null))
			{
				return;
			}
			ICraftNodeData itemModel = item.ItemModel as ICraftNodeData;
			XElement xElement = null;
			try
			{
				xElement = _flightStateData.LoadCraftXml(itemModel.NodeId);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				xElement = null;
			}
			if (xElement == null)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog();
				messageDialogScript.MessageText = "An error occurred trying to load craft '" + itemModel.Name + "'.";
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					completeCallback?.Invoke();
				};
				return;
			}
			Game.Instance.CraftLoader.LoadCraftInteractive(xElement, delegate(CraftData craftData)
			{
				_craftData = craftData;
				try
				{
					_craftScript = CraftBuilder.CreateCraftScript(craftData, createBodyScripts: false);
					_crewMembers = GetCrewMembers(craftData);
					_details.UpdateCrew(_crewMembers);
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
					_craftScript = null;
				}
				if (_craftScript == null)
				{
					objectViewer.PreviewObject(null);
					MessageDialogScript messageDialogScript2 = Game.Instance.UserInterface.CreateMessageDialog();
					messageDialogScript2.MessageText = "An error occurred trying to load craft '" + (string.IsNullOrWhiteSpace(craftData.Name) ? itemModel.Name : craftData.Name) + "'.";
					messageDialogScript2.OkayClicked += delegate(MessageDialogScript d)
					{
						d.Close();
						completeCallback?.Invoke();
					};
				}
				else
				{
					objectViewer.PreviewObject(_craftScript.gameObject);
					completeCallback?.Invoke();
				}
			}, delegate
			{
				objectViewer.PreviewObject(null);
				completeCallback?.Invoke();
			});
		}

		protected override bool MatchesSearchCriteria(ListViewItemScript item, string searchTextLower)
		{
			ICraftNodeData craftNodeData = (ICraftNodeData)item.ItemModel;
			if (!craftNodeData.Name.ToLower().Contains(searchTextLower))
			{
				return craftNodeData.ParentName.ToLower().Contains(searchTextLower);
			}
			return true;
		}

		private static void DeleteCraftNode(FlightStateData flightStateData, ICraftNodeData craftNodeData)
		{
			try
			{
				XElement craftXml = flightStateData.LoadCraftXml(craftNodeData.NodeId);
				List<CrewMember> crewMembers = GetCrewMembers(Game.Instance.CraftLoader.LoadCraftImmediate(craftXml));
				if (crewMembers.Count > 0)
				{
					foreach (CrewMember item in crewMembers)
					{
						if (item.State == CrewMemberState.InFlight)
						{
							item.State = CrewMemberState.Deceased;
						}
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			flightStateData.RemoveCraftNode(craftNodeData);
			flightStateData.Save();
		}

		private static List<CrewMember> GetCrewMembers(CraftData craftData)
		{
			List<CrewMember> list = new List<CrewMember>();
			foreach (PartData part in craftData.Assembly.Parts)
			{
				EvaData modifier = part.GetModifier<EvaData>();
				if (modifier?.CrewMember != null)
				{
					list.Add(modifier.CrewMember);
				}
			}
			return list;
		}

		private void DeleteNodeItem(ListViewItemScript item, bool saveGameState)
		{
			DeleteCraftNode(_flightStateData, item.ItemModel as ICraftNodeData);
			_crewMembers.Clear();
			_craftData = null;
			_craftScript = null;
			base.ListView.DeleteItem(item);
			Items.Remove(item);
			base.ListView.SelectedItem = null;
			if (saveGameState)
			{
				Game.Instance.GameState.Save();
			}
		}

		private void OnRemoveAllDebris(ContextMenuItemScript contextMenuItem)
		{
			List<ListViewItemScript> debris = new List<ListViewItemScript>();
			foreach (ListViewItemScript item in Items)
			{
				ICraftNodeData craftNodeData = item.ItemModel as ICraftNodeData;
				if ((!craftNodeData.HasCommandPod && craftNodeData.ContractTrackingId == null) || craftNodeData.CraftPartCount == 0)
				{
					debris.Add(item);
				}
			}
			if (debris.Count > 0)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = $"There are {debris.Count} non-resumable craft(s). Confirm that you wish to remove them.";
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					foreach (ListViewItemScript item2 in debris)
					{
						DeleteNodeItem(item2, saveGameState: false);
					}
					Game.Instance.GameState.Save();
				};
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "There is no more debris to remove.";
			}
		}
	}
}
