using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class RepaintOnSaveLoaded : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private SoftReference<IRepaint> _repaintObject;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			GameMode.SceneLoaded += OnLoad;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			GameMode.SceneLoaded -= OnLoad;
		}

		private void OnLoad(MapInfoSO mapInfoSO)
		{
			try
			{
				_repaintObject.Get()?.Repaint();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}
}
