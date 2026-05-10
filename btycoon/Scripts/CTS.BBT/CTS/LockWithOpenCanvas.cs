using CTS.Core;
using CTS.UI;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class LockWithOpenCanvas : CTSBehaviour
	{
		[SerializeField]
		private SoftReference<ILockable> _lockable;

		[SerializeField]
		private StringKey _canvas;

		[SerializeField]
		private CanvasIsOpenCondition.EValid _lockCondition;

		private readonly LockToggle _lock = new LockToggle();

		private CanvasGroupController _canvasCache;

		private void Start()
		{
			_lock.Add(_lockable.Value);
			CanvasGroupController.SlidingPanel += OnAnyPanelSliding;
			CanvasGroupController.PanelSlided += OnAnyPanelSlided;
		}

		private void OnDestroy()
		{
			_lock.Unlock();
			SetCanvasCache(null);
			CanvasGroupController.SlidingPanel -= OnAnyPanelSliding;
			CanvasGroupController.PanelSlided -= OnAnyPanelSlided;
		}

		private void SetCanvasCache(CanvasGroupController canvasGroupController)
		{
			if (!(canvasGroupController == _canvasCache))
			{
				if ((bool)_canvasCache)
				{
					_canvasCache.CanvasShowned -= OnPanelOpened;
					_canvasCache.CanvasShowning -= OnPanelOpening;
					_canvasCache.gameObject.UnregisterToDestroy(OnCacheCanvasDestroyed);
					_canvasCache = null;
				}
				if (canvasGroupController == null)
				{
					CanvasGroupController.SlidingPanel += OnAnyPanelSliding;
					CanvasGroupController.PanelSlided += OnAnyPanelSlided;
					return;
				}
				CanvasGroupController.SlidingPanel -= OnAnyPanelSliding;
				CanvasGroupController.PanelSlided -= OnAnyPanelSlided;
				_canvasCache = canvasGroupController;
				_canvasCache.CanvasShowned += OnPanelOpened;
				_canvasCache.CanvasShowning += OnPanelOpening;
				_canvasCache.gameObject.RegisterToDestroy(OnCacheCanvasDestroyed);
			}
		}

		private void OnAnyPanelSliding(CanvasGroupController panel, bool isOpening)
		{
			if (!(panel.IdKey != _canvas))
			{
				SetCanvasCache(panel);
				OnPanelOpening(isOpening);
			}
		}

		private void OnAnyPanelSlided(CanvasGroupController panel, bool isOpened)
		{
			if (!(panel.IdKey != _canvas))
			{
				SetCanvasCache(panel);
				OnPanelOpened(isOpened);
			}
		}

		private void OnPanelOpening(bool isOpening)
		{
			if (isOpening)
			{
				if (_lockCondition == CanvasIsOpenCondition.EValid.Close)
				{
					_lock.Unlock();
				}
				else
				{
					_lock.Lock();
				}
			}
		}

		private void OnPanelOpened(bool isOpened)
		{
			if (!isOpened)
			{
				if (_lockCondition == CanvasIsOpenCondition.EValid.Close)
				{
					_lock.Lock();
				}
				else
				{
					_lock.Unlock();
				}
			}
		}

		private void OnCacheCanvasDestroyed()
		{
			SetCanvasCache(null);
		}
	}
}
