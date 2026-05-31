using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class RepaintMultipleOnSaveLoaded : CTSBehaviour
	{
		[InjectScope(EGetScope.Children)]
		[Inject(false)]
		private IRepaint[] _repaints;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			SaveManager.OnLoadingFinished += OnLoad;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			SaveManager.OnLoadingFinished -= OnLoad;
		}

		private void OnLoad()
		{
			try
			{
				if (_repaints != null && _repaints.Length != 0)
				{
					IRepaint[] repaints = _repaints;
					for (int i = 0; i < repaints.Length; i++)
					{
						repaints[i].Repaint();
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}
}
