using System;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class ListViewDialogScript : MonoBehaviour, IDialog, IListView
	{
		private bool _closed;

		public bool AllowCameraZoom => false;

		public ListViewScript ListView { get; private set; }

		public bool PreviewEnabled => ListView.DisplayType == ListViewScript.ListViewDisplayType.ObjectPreview;

		public event DialogDelegate Closed;

		public void Close()
		{
			ListView.Close();
		}

		public virtual void Initialize(ListViewModel viewModel, IListViewObjectViewer objectViewer)
		{
			Game.Instance.UserInterface.RegisterDialog(this);
			XmlLayout xmlLayout = base.gameObject.AddComponent<XmlLayout>();
			XmlLayoutController xmlLayoutController = base.gameObject.AddComponent<XmlLayoutController>();
			xmlLayoutController.EventTarget = this;
			Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Menu/ListView", xmlLayout);
			ListView = base.gameObject.AddComponent<ListViewScript>();
			ListView.Initialize(xmlLayout, xmlLayoutController, viewModel, objectViewer, this, viewModel.UseGrid);
			ListView.Closed += OnListViewClosed;
		}

		protected virtual void Start()
		{
		}

		private void OnListViewClosed(object sender, EventArgs e)
		{
			if (ListView != null)
			{
				ListView = null;
				UnityEngine.Object.Destroy(base.gameObject);
				this.Closed?.Invoke(this);
			}
		}
	}
}
