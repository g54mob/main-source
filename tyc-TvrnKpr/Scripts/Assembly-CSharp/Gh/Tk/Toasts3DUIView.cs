using System;
using System.Collections.Generic;
using DG.Tweening;
using Gh.Tk.UI;
using UnityEngine;

namespace Gh.Tk
{
	[PersistenceOptIn]
	[PersistenceIgnoreParent]
	public class Toasts3DUIView : MonoBehaviour, IPersistable, ILevelStaticObject, ICustomSaveState
	{
		public class ToastUIData : IPersistable
		{
			[PersistenceObjectReference]
			public List<TavernLog.TavernEventLogEntry> Entries;

			public float currentToastTime;
		}

		[SerializeField]
		private Toast3DUIView _toastPrefab;

		[PersistenceOptIn]
		private ToastUIData[] _activeToastData;

		private Toast3DUIView[] _activeToastViews;

		private static PrefabObjectPool _toastObjectPool;

		[SerializeField]
		private Container3DUIView _toastContainer;

		[SerializeField]
		private Transform _exitTransform;

		private int _toastMaxVisible;

		private int _previousActiveToastCount;

		[SerializeField]
		private Ease _tweenEase;

		[SerializeField]
		private float _tweenDuration;

		[PersistenceOptIn]
		public string Id
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public void ResetState()
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnToastCleared(object sender, EventArgs e)
		{
		}

		private void OnTavernLogEventLogged(object sender, EventArgs<TavernLog.TavernEventLogEntry> e)
		{
		}

		private void OnResetUI(object sender, EventArgs e)
		{
		}

		private void Clear()
		{
		}

		private Toast3DUIView CreateToast(ToastUIData toastData)
		{
			return null;
		}

		public void QueueToast(TavernLog.TavernEventLogEntry entry)
		{
		}

		private void SetInFreeSlot(TavernLog.TavernEventLogEntry entry)
		{
		}

		private void LateUpdate()
		{
		}

		private void RemoveExpiredToasts()
		{
		}

		private bool IsToastPinned(ToastUIData toastData)
		{
			return false;
		}

		private bool IsToastHovered(ToastUIData toastUIData)
		{
			return false;
		}

		private void SortToastOrder()
		{
		}

		private void UpdateToastVisuals()
		{
		}

		public void SaveState(IDataStore data)
		{
		}

		public void RestoreState(IDataStore data)
		{
		}
	}
}
