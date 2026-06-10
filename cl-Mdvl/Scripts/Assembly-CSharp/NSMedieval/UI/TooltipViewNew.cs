using System;
using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NSMedieval.UI
{
	public class TooltipViewNew : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		protected List<string> lines;

		[SerializeField]
		private AnchoringPosition anchoringPosition;

		[SerializeField]
		private float maxWidth = 450f;

		private bool isEnabled = true;

		private Action executeOnShow;

		private RectTransform rectTransformCache;

		public float MaxWidth => maxWidth;

		public AnchoringPosition AnchoringPosition => anchoringPosition;

		public Action ExecuteOnShow
		{
			set
			{
				executeOnShow = value;
			}
		}

		public List<GameObject> Prefabs { get; } = new List<GameObject>();

		public virtual bool ShowPrefabsFirst => false;

		public RectTransform RectTransform
		{
			get
			{
				if (rectTransformCache == null)
				{
					rectTransformCache = GetComponent<RectTransform>();
				}
				return rectTransformCache;
			}
		}

		protected List<string> Lines => lines ?? (lines = new List<string>());

		public void SetEnabled(bool isEnabled)
		{
			if (this.isEnabled && !isEnabled && MonoSingleton<TooltipController>.Instance.IsShowing(this))
			{
				MonoSingleton<TooltipController>.Instance.Hide();
			}
			this.isEnabled = isEnabled;
		}

		public void ClearLines()
		{
			Lines.Clear();
		}

		public void AppendLine(string line, string lineStyle)
		{
			if (!string.IsNullOrEmpty(line))
			{
				if (string.IsNullOrEmpty(lineStyle))
				{
					lines.Add(line);
				}
				else
				{
					lines.Add(TooltipStyles.ApplyStyle(line, lineStyle));
				}
			}
		}

		public void ShowFreshLine(string line)
		{
			if (!string.IsNullOrEmpty(line))
			{
				Hide();
				ClearLines();
				Lines.Add(line);
				Show();
			}
		}

		public void AppendLine(string line)
		{
			if (!string.IsNullOrEmpty(line))
			{
				Lines.Add(line);
			}
		}

		public void AppendLines(IEnumerable<string> lines)
		{
			if (lines != null)
			{
				Lines.AddRange(lines);
			}
		}

		public void SetLines(IEnumerable<string> lines)
		{
			ClearLines();
			if (lines != null)
			{
				this.lines.AddRange(lines);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (isEnabled)
			{
				Show();
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (isEnabled)
			{
				Hide();
			}
		}

		protected virtual List<string> GetLinesToShow()
		{
			executeOnShow?.Invoke();
			return lines;
		}

		protected void SetTooltipPrefab(GameObject tooltipPrefab)
		{
			Prefabs.Clear();
			Prefabs.Add(tooltipPrefab);
		}

		private void Show()
		{
			if (MonoSingleton<TooltipController>.IsInstantiated() && !MonoSingleton<TooltipController>.Instance.HideTooltips)
			{
				MonoSingleton<TooltipController>.Instance.Show(GetLinesToShow(), this);
			}
		}

		public void RefreshTooltip()
		{
			if (MonoSingleton<TooltipController>.IsInstantiated() && MonoSingleton<TooltipController>.Instance.IsShowing(this))
			{
				MonoSingleton<TooltipController>.Instance.RefreshTooltip(GetLinesToShow());
			}
		}

		private void Hide()
		{
			if (MonoSingleton<TooltipController>.IsInstantiated())
			{
				MonoSingleton<TooltipController>.Instance.Hide();
			}
		}

		private void OnDisable()
		{
			if (isEnabled && MonoSingleton<TooltipController>.IsInstantiated() && MonoSingleton<TooltipController>.Instance.IsShowing(this))
			{
				Hide();
			}
		}

		protected virtual void OnDestroy()
		{
			if (isEnabled && MonoSingleton<TooltipController>.IsInstantiated() && MonoSingleton<TooltipController>.Instance.IsShowing(this))
			{
				Hide();
				executeOnShow = null;
			}
		}

		public void SetSingleLineTooltip(string line)
		{
			lines.Clear();
			lines.Add(line);
		}

		public void SetSingleLineTooltip(string line, string style)
		{
			lines.Clear();
			if (string.IsNullOrEmpty(style))
			{
				lines.Add(line);
			}
			else
			{
				lines.Add(TooltipStyles.ApplyStyle(line, style));
			}
		}
	}
}
