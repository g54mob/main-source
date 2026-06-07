using System;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class HUDControlModule : MonoBehaviour, HUDUpdateManager.IUpdateSlave
	{
		public static HUDControlModule Hovered;

		public bool sendUpdatesEveryFrame = true;

		public bool isDraggable;

		private bool wasValueSetThisFrame;

		private float _value;

		public float Value
		{
			get
			{
				return _value;
			}
			protected set
			{
				float value2 = _value;
				_value = value;
				this.ValueChanged?.Invoke(_value);
				if (sendUpdatesEveryFrame)
				{
					wasValueSetThisFrame = true;
					if (value2 == 0f && value != 0f)
					{
						SingletonBehaviour<HUDUpdateManager>.Instance.AddSlave(this);
					}
					else if (value2 != 0f && value == 0f)
					{
						SingletonBehaviour<HUDUpdateManager>.Instance.RemoveSlave(this);
					}
				}
			}
		}

		public event Action<float> ValueChanged;

		protected virtual void Awake()
		{
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<HUDUpdateManager>.Instance.RemoveSlave(this);
			}
		}

		public void DoUpdate()
		{
			if (!wasValueSetThisFrame)
			{
				this.ValueChanged?.Invoke(Value);
			}
			wasValueSetThisFrame = false;
		}

		public virtual void ScrollValue(int notches)
		{
		}

		protected void SetHoverButton(ButtonDV button)
		{
			button.HoverChanged += OnHoverChanged;
		}

		private void OnHoverChanged(IHoverable h)
		{
			if (h.IsHovered)
			{
				Hovered = this;
			}
			else if (this == Hovered)
			{
				Hovered = null;
			}
		}
	}
}
