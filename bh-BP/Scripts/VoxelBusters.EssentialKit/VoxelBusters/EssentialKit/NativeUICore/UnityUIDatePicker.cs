using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit.NativeUICore
{
	public abstract class UnityUIDatePicker : MonoBehaviour, IUnityUIDatePicker
	{
		private EventCallback<DateTime?> m_callback;

		public bool IsShowing { get; private set; }

		public DatePickerMode Mode { get; set; }

		public DateTime? MinDate { get; set; }

		public DateTime? MaxDate { get; set; }

		public DateTime? InitialDate { get; set; }

		public DateTimeKind Kind { get; set; }

		public DateTime SelectedDate { get; set; }

		protected DateTime GetCurrentDateTime(DateTimeKind kind)
		{
			return default(DateTime);
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		public virtual void Show()
		{
		}

		public virtual void Dismiss()
		{
		}

		public void SetCompletionCallback(EventCallback<DateTime?> callback)
		{
		}

		protected void DismissInternal()
		{
		}

		protected void SendCompletionResult(DateTime? result, Error error)
		{
		}
	}
}
