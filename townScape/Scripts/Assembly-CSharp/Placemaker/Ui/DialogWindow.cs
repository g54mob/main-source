using System;
using TMPro;
using UnityEngine;

namespace Placemaker.Ui
{
	public class DialogWindow : MonoBehaviour, GenericMenuNavigator.INavigableMenu, IComparable<DialogWindow>
	{
		public enum OrderPriority
		{
			Info = 0,
			GameCoreSignOut = 1,
			GameCoreSuspend = 9,
			GameCoreGamepadDisconnected = 10
		}

		private UiMaster master;

		private DialogSystem dialogSystem;

		public UpdateState openState;

		[NonSerialized]
		[HideInInspector]
		private bool hasBeenEnabled;

		[SerializeField]
		private GameObject buttonsGO;

		[SerializeField]
		private TextMeshProUGUI titleText;

		[SerializeField]
		private TextMeshProUGUI descriptionText;

		[SerializeField]
		private TextMeshProUGUI affirmativeButtonText;

		[SerializeField]
		private TextMeshProUGUI negativeButtonText;

		[SerializeField]
		private BaseButton affirmativeButton;

		[SerializeField]
		private BaseButton negativeButton;

		[SerializeField]
		private BaseButton cancelClicker;

		public OrderPriority priority { get; private set; }

		public void Setup(UiMaster master)
		{
		}

		public void Open()
		{
		}

		public void Close(bool openSideMenu)
		{
		}

		UpdateState GenericMenuNavigator.INavigableMenu.GetMainUpdateState()
		{
			return null;
		}

		public void SetDialog(OrderPriority priority, string title = "", string description = "", string affirmativeButtonText = "", string negativeButtonText = "", Action affirmativeCallback = null, Action negativeCallback = null)
		{
		}

		public int CompareTo(DialogWindow other)
		{
			return 0;
		}
	}
}
