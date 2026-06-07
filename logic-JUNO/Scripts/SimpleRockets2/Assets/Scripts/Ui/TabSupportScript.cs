using System.Collections.Generic;
using System.Linq;
using ModApi.Ui;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public class TabSupportScript : MonoBehaviour
	{
		private DialogScript _dialog;

		public void Initialize(DialogScript dialog)
		{
			_dialog = dialog;
			EventSystem.current.SetSelectedGameObject(null);
		}

		private static int WrapIndex(int index, int max)
		{
			if (index < 0)
			{
				index = max;
			}
			if (index > max)
			{
				index = 0;
			}
			return index;
		}

		private void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog != _dialog)
			{
				return;
			}
			EventSystem current = EventSystem.current;
			if (!UnityEngine.Input.GetKeyDown(KeyCode.Tab))
			{
				return;
			}
			List<GameObject> list = (from x in _dialog.GetComponentsInChildren<Selectable>()
				select x.gameObject).ToList();
			int num = list.IndexOf(current.currentSelectedGameObject);
			num = ((!UnityEngine.Input.GetKey(KeyCode.LeftShift) && !UnityEngine.Input.GetKey(KeyCode.RightShift)) ? (num + 1) : (num - 1));
			num = WrapIndex(num, list.Count - 1);
			if (num >= 0 && num < list.Count)
			{
				GameObject gameObject = list[num];
				if (gameObject != null)
				{
					current.SetSelectedGameObject(gameObject, new BaseEventData(current));
				}
			}
		}
	}
}
