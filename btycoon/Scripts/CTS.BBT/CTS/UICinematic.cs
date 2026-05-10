using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UICinematic : MonoSingleton<UICinematic>
	{
		[SerializeField]
		private CanvasGroupController _upPanel;

		[SerializeField]
		private CanvasGroupController _downPanel;

		public static void Toggle(bool value)
		{
			if (MonoSingleton<UICinematic>.InstanceExists())
			{
				MonoSingleton<UICinematic>.Instance._upPanel.ShowCanvasGroup(value, 0.5f);
				MonoSingleton<UICinematic>.Instance._downPanel.ShowCanvasGroup(value, 0.5f);
			}
		}

		protected override void OnSingletonDestroy()
		{
		}

		protected override void SingletonAwake()
		{
		}
	}
}
