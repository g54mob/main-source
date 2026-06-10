using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NSMedieval
{
	public class TooltipController : MonoSingleton<TooltipController>, IObserver
	{
		[SerializeField]
		private TooltipNew tooltipObject;

		private TooltipViewNew tooltipViewShowing;

		public bool HideTooltips { get; set; }

		private void Start()
		{
			HideTooltips = false;
			MonoSingleton<LoadingController>.Instance.SceneUnloadedEvent += OnSceneUnload;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.SceneUnloadedEvent -= OnSceneUnload;
			}
			base.OnDestroy();
		}

		private void OnSceneUnload(Scene obj)
		{
			if (IsShowing())
			{
				Hide();
			}
		}

		public void Show(List<string> lines, TooltipViewNew source)
		{
			tooltipViewShowing = source;
			tooltipObject.Show(lines, source);
		}

		public void Hide()
		{
			tooltipViewShowing = null;
			tooltipObject.Hide();
		}

		public bool IsShowing()
		{
			return tooltipViewShowing != null;
		}

		public bool IsShowing(TooltipViewNew tooltipViewNew)
		{
			return tooltipViewShowing == tooltipViewNew;
		}

		public void RefreshTooltip(List<string> lines)
		{
			tooltipObject.RefreshTooltip(lines);
		}
	}
}
