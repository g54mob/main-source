using System;
using Restory.Data.RegularPayments;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.TimeSystems;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.RegularPayments
{
	public class RegularPaymentObject : MonoBehaviour, ITimeChangeReceiver
	{
		[SerializeField]
		private InteractiveObject interactiveObject;

		[SerializeField]
		private GameObject normalView;

		[SerializeField]
		private GameObject unpaidView;

		private RegularPaymentInfo regularPaymentInfo;

		private DateTime dueDateCached = DateTime.MaxValue;

		private GameCalendar gameCalendar;

		public InteractiveObject InteractiveObject => interactiveObject;

		public RegularPaymentInfo RegularPaymentInfo => regularPaymentInfo;

		public event Action<RegularPaymentObject> OnClicked;

		[Inject]
		private void Construct(GameCalendar gameCalendar)
		{
			this.gameCalendar = gameCalendar;
			if (base.isActiveAndEnabled)
			{
				gameCalendar.AddSubscriber(this);
			}
		}

		private void Awake()
		{
			normalView.SetActive(value: true);
			unpaidView.SetActive(value: false);
			interactiveObject.IsActivatable = true;
		}

		private void OnEnable()
		{
			interactiveObject.OnInitialized += ResolveOnInitialized;
			interactiveObject.OnActivated += ResolveOnActivated;
			if (gameCalendar.MonoShellExists())
			{
				gameCalendar.AddSubscriber(this);
			}
		}

		private void OnDisable()
		{
			interactiveObject.OnInitialized -= ResolveOnInitialized;
			interactiveObject.OnActivated -= ResolveOnActivated;
			if (gameCalendar.MonoShellExists())
			{
				gameCalendar.RemoveSubscriber(this);
			}
		}

		void ITimeChangeReceiver.ProcessTimeChanged()
		{
			RefreshView();
		}

		private void RefreshView()
		{
			bool flag = IsOverdue();
			if (normalView.activeSelf == flag)
			{
				normalView.SetActive(!flag);
				unpaidView.SetActive(flag);
			}
		}

		public bool IsOverdue()
		{
			return dueDateCached < gameCalendar.CurrentDateTime;
		}

		public void SetUp(RegularPaymentInfo regularPaymentInfo)
		{
			this.regularPaymentInfo = regularPaymentInfo;
		}

		private void ResolveOnInitialized()
		{
			if (!interactiveObject.AdditionalProperties.TryToGetProperty<RegularPaymentDeliveryDateInteractiveObjectProperty>(out var foundProperty))
			{
				dueDateCached = DateTime.MaxValue;
			}
			else
			{
				dueDateCached = foundProperty.DeliveryTime.AddDays(regularPaymentInfo.DaysForPayment);
			}
		}

		private void ResolveOnActivated()
		{
			this.OnClicked?.Invoke(this);
		}
	}
}
