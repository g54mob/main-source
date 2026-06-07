using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft;
using ModApi.Craft;
using ModApi.Math;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class CraftDesignsViewModel : ListViewModel
	{
		private class CraftItem
		{
			public string Id { get; set; }

			public long Price { get; set; }
		}

		private string _buttonText;

		private CraftData _craftData;

		private string _craftId;

		private CraftScript _craftScript;

		private CraftDesignsDetails _details;

		private bool _refreshSelectedCraftOnCancel;

		private string _selectedCraftId;

		public Action<string> OnCraftDeleted { get; set; }

		public Action<string, CraftScript> OnCraftSelected { get; set; }

		public Action OnUserCanceled { get; set; }

		public CraftDesignsViewModel(string buttonText = "LOAD", string selectedCraftId = null)
		{
			_buttonText = buttonText;
			_selectedCraftId = selectedCraftId;
		}

		public override IEnumerator LoadItems()
		{
			_details = new CraftDesignsDetails(base.ListView.ListViewDetails);
			List<string> list = (from x in Game.Instance.CraftDesigns.GetCraftDesignIds(excludeReservedIds: true)
				orderby x
				select x).ToList();
			ListViewItemScript selectedItem = null;
			foreach (string item in list)
			{
				try
				{
					long price = CraftData.GetPrice(Game.Instance.CraftDesigns.GetCraftDesign(item));
					CraftItem itemModel = new CraftItem
					{
						Id = item,
						Price = price
					};
					ListViewItemScript listViewItemScript = base.ListView.CreateItem(item, Units.GetPriceString(price), itemModel, null, ListViewScript.SpriteLoadLocation.Resources);
					if (CraftDesigns.IsStock(item))
					{
						listViewItemScript.FilterKeywords.Add("Stock");
					}
					if (item == _selectedCraftId)
					{
						selectedItem = listViewItemScript;
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			base.ListView.SelectedItem = selectedItem;
			yield return new WaitForEndOfFrame();
		}

		public override void OnCanceled()
		{
			OnUserCanceled?.Invoke();
		}

		public override void OnDeleteButtonClicked(ListViewItemScript selectedItem)
		{
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.OkayButtonText = "DELETE";
			CraftItem craftItem = selectedItem.ItemModel as CraftItem;
			messageDialogScript.MessageText = $"Confirm that you want to delete the craft design '{craftItem.Id}'";
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.OkayClicked += OnConfirmDelete;
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			listView.Title = "Load Craft";
			listView.CanDelete = true;
			listView.PrimaryButtonText = _buttonText;
			listView.CreateFilter(false, "Show stock crafts", "Show stock crafts", ListViewFilterType.Exclusive, false, "Stock");
		}

		public override void OnPrimaryButtonClicked(ListViewItemScript selectedItem)
		{
			if (_craftScript != null)
			{
				OnCraftSelected?.Invoke(_craftId, _craftScript);
				base.ListView.Close();
			}
		}

		public override void OnSelectedItemChanging(ListViewItemScript item, Action completeCallback)
		{
			if (item != null)
			{
				CraftItem craftItem = item.ItemModel as CraftItem;
				_craftId = null;
				_craftData = null;
				_craftScript = null;
				Game.Instance.CraftLoader.LoadCraftInteractive(craftItem.Id, delegate(CraftData craftData)
				{
					_craftId = craftItem.Id;
					_craftData = craftData;
					bool flag = true;
					try
					{
						_craftScript = CraftBuilder.CreateCraftScript(_craftData, createBodyScripts: false);
						_craftScript.gameObject.SetActive(value: false);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						flag = false;
					}
					if (flag)
					{
						completeCallback?.Invoke();
					}
					else
					{
						MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog();
						messageDialogScript.MessageText = "An error occurred trying to load craft '" + craftData.Name + "'.";
						messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
						{
							d.Close();
							completeCallback?.Invoke();
						};
					}
				}, completeCallback);
			}
			else
			{
				completeCallback?.Invoke();
			}
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			if (item != null)
			{
				CraftItem craftItem = item.ItemModel as CraftItem;
				_details.UpdateDetails(craftItem.Id, _craftScript);
			}
			completeCallback?.Invoke();
		}

		public override void UpdatePreview(ListViewItemScript item, IListViewObjectViewer objectViewer, Action completeCallback)
		{
			if (_craftScript != null)
			{
				_craftScript.gameObject.SetActive(value: true);
				base.ListView.ListViewDetails.Visible = true;
				objectViewer.PreviewObject(_craftScript.gameObject);
			}
			else
			{
				base.ListView.ListViewDetails.Visible = false;
				objectViewer.PreviewObject(null);
			}
			completeCallback?.Invoke();
		}

		protected override bool MatchesSearchCriteria(ListViewItemScript item, string searchTextLower)
		{
			return ((CraftItem)item.ItemModel).Id.ToLower().Contains(searchTextLower);
		}

		private void OnConfirmDelete(MessageDialogScript messageDialog)
		{
			messageDialog.Close();
			ListViewItemScript selectedItem = base.ListView.SelectedItem;
			CraftItem craftItem = selectedItem.ItemModel as CraftItem;
			Game.Instance.CraftDesigns.DeleteCraftFile(craftItem.Id);
			base.ListView.DeleteItem(selectedItem);
			Items.Remove(selectedItem);
			base.ListView.SelectedItem = null;
			OnCraftDeleted?.Invoke(craftItem.Id);
		}
	}
}
