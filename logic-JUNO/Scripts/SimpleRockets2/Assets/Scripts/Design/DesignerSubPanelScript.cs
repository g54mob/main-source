using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DesignerSubPanelScript : XmlLayoutController
	{
		private Canvas _canvas;

		public DesignerUiScript DesignerUi { get; private set; }

		public bool IsOpen { get; private set; }

		public virtual void Initialize(DesignerUiScript designerUi)
		{
			DesignerUi = designerUi;
			_canvas = base.transform.parent.GetComponent<Canvas>();
		}

		public virtual void OnClosed()
		{
			IsOpen = false;
		}

		public virtual void OnOpened()
		{
			_canvas.enabled = false;
			_canvas.enabled = true;
			IsOpen = true;
		}
	}
}
