using System;
using System.Collections;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TutorialButtonClickedMessage : MonoBehaviour
	{
		[SerializeField]
		private SharedInstance_TH20TH20_NotificationMessagesDefinition _message;

		private Level _level;

		public static Action<TutorialButtonClickedMessage> OnButtonCreated;

		protected void Awake()
		{
			OnButtonCreated.InvokeSafe(this);
		}

		public void Setup(Level level)
		{
			_level = level;
			Button component = GetComponent<Button>();
			if (component != null)
			{
				component.onClick.AddListener(TryShowMessage);
			}
			DynamicButton component2 = GetComponent<DynamicButton>();
			if (component2 != null)
			{
				component2.onPrimaryDown.AddListener(TryShowMessage);
			}
		}

		private void OnDestroy()
		{
			Button component = GetComponent<Button>();
			if (component != null)
			{
				component.onClick.RemoveListener(TryShowMessage);
			}
			DynamicButton component2 = GetComponent<DynamicButton>();
			if (component2 != null)
			{
				component2.onPrimaryDown.RemoveListener(TryShowMessage);
			}
		}

		public void TryShowMessage()
		{
			string menuName = GameObjectUtils.ObjectFullPath(base.gameObject.transform);
			if (!TutorialUtils.HasMenuBeenSeenBefore(menuName, _level))
			{
				_level.App.StartCoroutine(DelayMessage());
				TutorialUtils.SetMenuHasBeenSeen(menuName, _level);
			}
		}

		private IEnumerator DelayMessage()
		{
			yield return new WaitForSecondsRealtime(0.5f);
			NotificationMessage openMessage = _level.Notifications.OpenMessage;
			if (openMessage == null)
			{
				ShowMessage();
				yield break;
			}
			openMessage.Delegate = (NotificationMessage.ResponseDelegate)Delegate.Combine(openMessage.Delegate, (NotificationMessage.ResponseDelegate)delegate(int response)
			{
				if (response == 0)
				{
					ShowMessage();
				}
			});
		}

		private void ShowMessage()
		{
			_level.Notifications.OpenPopup(new NotificationGenericDecision(_message.Instance, null, _level));
		}
	}
}
