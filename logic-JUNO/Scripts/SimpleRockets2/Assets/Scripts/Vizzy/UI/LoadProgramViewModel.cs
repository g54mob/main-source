using System;
using System.Collections;
using System.IO;
using System.Xml.Linq;
using Assets.Scripts.Menu.ListView;
using ModApi;
using ModApi.Math;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Vizzy.UI
{
	public class LoadProgramViewModel : ListViewModel
	{
		private LoadProgramDetails _details;

		private bool _import;

		private VizzyUIScript _vizzyUI;

		public LoadProgramViewModel(VizzyUIScript vizzyUI, bool import)
		{
			_import = import;
			_vizzyUI = vizzyUI;
		}

		public static string GetProgramName(FileInfo file)
		{
			return Utilities.RemoveFileExtension(file.Name);
		}

		public override IEnumerator LoadItems()
		{
			_details = new LoadProgramDetails(base.ListView.ListViewDetails);
			FileInfo[] files = new DirectoryInfo(VizzyUIScript.FlightProgramsFolderPath).GetFiles("*.xml");
			foreach (FileInfo fileInfo in files)
			{
				if (!fileInfo.Name.StartsWith("__"))
				{
					string memoryString = Units.GetMemoryString(fileInfo.Length);
					base.ListView.CreateItem(GetProgramName(fileInfo), memoryString, fileInfo, null, ListViewScript.SpriteLoadLocation.Resources);
				}
			}
			yield return new WaitForEndOfFrame();
		}

		public override void OnDeleteButtonClicked(ListViewItemScript selectedItem)
		{
			FileInfo file = selectedItem.ItemModel as FileInfo;
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.OkayButtonText = "DELETE";
			messageDialogScript.MessageText = $"Confirm that you want to delete the program '{GetProgramName(file)}'";
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.OkayClicked += OnConfirmDelete;
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			if (_import)
			{
				listView.Title = "Import Program";
				listView.PrimaryButtonText = "IMPORT";
			}
			else
			{
				listView.Title = "Load Program";
				listView.PrimaryButtonText = "LOAD";
			}
			listView.CanDelete = true;
			listView.DisplayType = ListViewScript.ListViewDisplayType.SmallDialog;
			listView.TranslucentBackground = false;
		}

		public override void OnPrimaryButtonClicked(ListViewItemScript selectedItem)
		{
			string programName = GetProgramName(selectedItem.ItemModel as FileInfo);
			XElement programXml = VizzyUIScript.LoadXml(programName);
			if (_import)
			{
				_vizzyUI.ImportFlightProgram(programXml);
				_vizzyUI.ShowMessage($"Imported program '{programName}'");
			}
			else
			{
				_vizzyUI.LoadFlightProgram(programXml);
				_vizzyUI.ShowMessage($"Loaded program '{programName}'");
			}
			base.ListView.Close();
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			if (item != null)
			{
				FileInfo file = item.ItemModel as FileInfo;
				_details.UpdateDetails(file);
			}
			completeCallback?.Invoke();
		}

		private void OnConfirmDelete(MessageDialogScript messageDialog)
		{
			messageDialog.Close();
			ListViewItemScript selectedItem = base.ListView.SelectedItem;
			Utilities.Delete((selectedItem.ItemModel as FileInfo).FullName);
			Items.Remove(selectedItem);
			selectedItem.gameObject.SetActive(value: false);
			UnityEngine.Object.Destroy(selectedItem.gameObject);
			base.ListView.SelectedItem = null;
		}
	}
}
