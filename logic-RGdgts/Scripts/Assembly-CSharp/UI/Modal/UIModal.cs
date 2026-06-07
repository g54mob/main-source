using System.Collections.Generic;
using UI.Common;
using UI.Elements;
using UnityEngine;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public abstract class UIModal : MonoBehaviour
	{
		public RectTransform transparentPanel;

		public RectTransform modalArea;

		public UIText title;

		private float width;

		private float height;

		public virtual void Set()
		{
		}

		public virtual void OnOpen()
		{
		}

		public virtual void OnClose()
		{
		}

		public virtual void DisablePanel()
		{
		}

		public virtual void EnablePanel()
		{
		}
	}
	public abstract class UIModal<T> : UIModal
	{
		protected UIModalManager modalManager;

		protected UIButton modalOpenButton;

		protected TableReference messageTypesTableRef;

		protected bool confirm;

		public override void Set()
		{
		}

		public override void OnOpen()
		{
		}

		public override void OnClose()
		{
		}

		public override void DisablePanel()
		{
		}

		public override void EnablePanel()
		{
		}

		public virtual void Init(UIModalManager modalManager, T initParameters, List<UIButton> modalOpenButton = null)
		{
		}

		public UIRenameOutcomes CheckNameErrors(string name, List<string> existingNames, bool sameNameAllowed)
		{
			return default(UIRenameOutcomes);
		}

		public UIRenameOutcomes ReturnNameOutcome(string newName, List<string> names, bool sameNameAllowed)
		{
			return default(UIRenameOutcomes);
		}
	}
}
