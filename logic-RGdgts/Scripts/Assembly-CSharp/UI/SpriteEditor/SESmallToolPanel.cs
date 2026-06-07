using System;
using System.Collections.Generic;
using TMPro;
using UI.Common;
using UI.Elements;
using UnityEngine;

namespace UI.SpriteEditor
{
	public abstract class SESmallToolPanel : MonoBehaviour
	{
		protected Action<SEToolType> OnClick;

		protected UIButton currentButtonSelected;

		public TextMeshProUGUI toolName;

		[HideInInspector]
		public SEToolType currentTool;

		public SESelectedArea selectedArea;

		protected List<UIButton> panelButtons;

		public virtual void Init(Action<SEToolType> OnClick, SESelectedArea selectedArea)
		{
		}

		public void SetToolTitle(string title)
		{
		}

		public virtual void ActivatePanel()
		{
		}

		public virtual void DeactivatePanel()
		{
		}

		protected void ChangeTool(UIButton button, SEToolType toolType)
		{
		}
	}
}
