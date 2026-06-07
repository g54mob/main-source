using System;
using System.Collections.Generic;
using System.Linq;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class HUDHoverManager : SingletonBehaviour<HUDHoverManager>
	{
		public LocoHUDControlBase CurrentHovered;

		private HashSet<LocoHUDControlBase> hoveredList = new HashSet<LocoHUDControlBase>();

		private Dictionary<IHoverable, LocoHUDControlBase> hoverables = new Dictionary<IHoverable, LocoHUDControlBase>();

		public event Action<LocoHUDControlBase> HoveredChangedAll;

		public new static string AllowAutoCreate()
		{
			return "[HUDHoverManager]";
		}

		public void RegisterHoverable(IHoverable hoverable, LocoHUDControlBase controlBase)
		{
			hoverable.HoverChanged += OnHoverChanged;
			hoverables[hoverable] = controlBase;
		}

		public void UnregisterHoverable(IHoverable hoverable)
		{
			hoverable.HoverChanged -= OnHoverChanged;
			hoverables.Remove(hoverable);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (UnloadWatcher.isQuitting)
			{
				return;
			}
			foreach (IHoverable item in hoverables.Keys.ToList())
			{
				UnregisterHoverable(item);
			}
		}

		private void OnHoverChanged(IHoverable hoverable)
		{
			LocoHUDControlBase item = hoverables[hoverable];
			if (hoverable.IsHovered)
			{
				hoveredList.Add(item);
			}
			else
			{
				hoveredList.Remove(item);
			}
			RefreshHovered();
		}

		private void RefreshHovered()
		{
			LocoHUDControlBase locoHUDControlBase = null;
			if (hoveredList.Count != 0)
			{
				int num = -1;
				LocoHUDControlBase locoHUDControlBase2 = null;
				foreach (LocoHUDControlBase hovered in hoveredList)
				{
					int depth = GetDepth(hovered.transform);
					if (depth > num)
					{
						num = depth;
						locoHUDControlBase2 = hovered;
					}
				}
				locoHUDControlBase = locoHUDControlBase2;
			}
			if (CurrentHovered != locoHUDControlBase)
			{
				CurrentHovered = locoHUDControlBase;
				this.HoveredChangedAll?.Invoke(CurrentHovered);
			}
		}

		private int GetDepth(Transform transform)
		{
			int num = 0;
			Transform parent = transform.parent;
			while (parent != null)
			{
				num++;
				parent = parent.parent;
			}
			return num;
		}
	}
}
