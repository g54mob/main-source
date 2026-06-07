using System;
using UI.Elements;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SESmallPanel : MonoBehaviour
	{
		public SEPenPanel penPanel;

		public SEFillPanel fillPanel;

		public SEPickPanel pickPanel;

		public SEShapePanel shapePanel;

		public SESelectionPanel selectPanel;

		public GameObject persistentToolsPanel;

		public UIButton deleteInAreaButton;

		public UIButton backInHistoryButton;

		public UIButton pasteButton;

		public UIButton copyButton;

		public UIButton cutButton;

		public void Init(Action deleteInArea, Action backInHistory, Action paste, Action copy, Action cut)
		{
		}

		public void EnableButtons(bool enablePaste, bool selectionActive, bool selectionToolActive)
		{
		}

		public void EnableCopyCut(bool enable)
		{
		}

		public void EnableBackHistory(bool enable)
		{
		}
	}
}
