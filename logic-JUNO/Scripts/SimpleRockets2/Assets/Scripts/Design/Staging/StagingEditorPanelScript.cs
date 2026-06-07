using UI.Xml;

namespace Assets.Scripts.Design.Staging
{
	public class StagingEditorPanelScript : DesignerSubPanelScript
	{
		private bool _removeEmptyStages;

		private bool _refreshStaging;

		private StagingEditorScript _stagingEditor;

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			designerUi.Designer.CraftStructureChanged += OnCraftStructureChanged;
			designerUi.Designer.CraftLoaded += OnCraftLoaded;
			_stagingEditor.ResetStagingButtonEnabled = true;
			_stagingEditor.UserInterface = Game.Instance.UserInterface;
			_stagingEditor.ShowMessage = delegate(string s)
			{
				base.DesignerUi.ShowMessage(s);
			};
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_stagingEditor = base.gameObject.AddComponent<StagingEditorScript>();
			_stagingEditor.OnLayoutRebuilt(this);
			base.EventTarget = _stagingEditor;
		}

		public void OnCraftLoaded()
		{
			_removeEmptyStages = true;
			_refreshStaging = true;
		}

		public void OnCraftStructureChanged()
		{
			_refreshStaging = true;
		}

		public override void OnClosed()
		{
			_stagingEditor.OnClose();
			base.OnClosed();
		}

		public override void OnOpened()
		{
			base.OnOpened();
			_refreshStaging = true;
		}

		protected virtual void Update()
		{
			if (_refreshStaging)
			{
				_refreshStaging = false;
				_stagingEditor.UpdateStaging(base.DesignerUi.Designer.CraftScript, _removeEmptyStages);
				_removeEmptyStages = false;
			}
		}
	}
}
