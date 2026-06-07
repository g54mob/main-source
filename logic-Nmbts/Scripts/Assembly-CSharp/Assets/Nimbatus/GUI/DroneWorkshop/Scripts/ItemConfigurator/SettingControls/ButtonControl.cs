using System.Collections.Generic;
using System.Reflection;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.SettingControls
{
	public class ButtonControl : MonoBehaviour
	{
		public UILabel Name;

		private MethodInfo _action;

		private UndoManager.EStoreReason _reason;

		private List<DronePart> _parentObjects;

		public void Init(string title, List<DronePart> parentObjects, MethodInfo action, UndoManager.EStoreReason reason)
		{
			Name.text = title;
			_action = action;
			_parentObjects = parentObjects;
			_reason = reason;
		}

		public void OnClick()
		{
			BaseSingleton<UndoManager>.Instance.Store(_reason);
			foreach (DronePart parentObject in _parentObjects)
			{
				_action.Invoke(parentObject, null);
			}
		}

		public void OnTooltip(bool show)
		{
			if (Name.processedText != Name.text)
			{
				NimbatusToolTip.Show(Name.text, show);
			}
		}
	}
}
