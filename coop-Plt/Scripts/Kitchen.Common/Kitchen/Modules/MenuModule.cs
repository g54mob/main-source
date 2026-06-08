using System;
using Controllers;
using UnityEngine;

namespace Kitchen.Modules
{
	public class MenuModule : IModule
	{
		private ModuleSet ModuleSet = new ModuleSet();

		public GameObject Container;

		public virtual bool IsSelectable => true;

		public Vector2 Position
		{
			get
			{
				return ModuleSet.Position;
			}
			set
			{
				ModuleSet.Position = value;
			}
		}

		public Bounds BoundingBox
		{
			get
			{
				Bounds boundingBox = ModuleSet.BoundingBox;
				boundingBox.Expand(0.1f);
				return boundingBox;
			}
		}

		public event Action OnActivated = delegate
		{
		};

		public event Action OnDeactivated = delegate
		{
		};

		public event Action OnClose = delegate
		{
		};

		public MenuModule(GameObject container)
		{
			Container = container;
		}

		public void SetActive(bool active)
		{
			if (active)
			{
				this.OnActivated();
			}
			else
			{
				this.OnDeactivated();
			}
			Container.SetActive(active);
		}

		public ButtonElement AddButton(ButtonElement button, Action on_press)
		{
			button.OnActivate += on_press;
			button.gameObject.SetActive(value: true);
			ModuleSet.AddModule(button, PositionModule(button.transform, button));
			return button;
		}

		public SelectElement AddSelect(SelectElement select, Action<int> on_press, bool require_press = false)
		{
			if (require_press)
			{
				select.OnOptionChosen += on_press;
			}
			else
			{
				select.OnOptionHighlighted += on_press;
			}
			select.gameObject.SetActive(value: true);
			ModuleSet.AddModule(select, PositionModule(select.transform, select));
			return select;
		}

		private Vector2 PositionModule(Transform transform, IModule module)
		{
			transform.parent = Container.transform;
			Vector2 result = new Vector2(0f, BoundingBox.min.y);
			if (ModuleSet.Modules.Count > 0)
			{
				result.y += 0f - module.BoundingBox.extents.y;
			}
			transform.localPosition = new Vector3(0f, result.y, 0f);
			transform.localScale = Vector3.one;
			transform.localRotation = Quaternion.identity;
			return result;
		}

		public bool HandleInteraction(InputState state)
		{
			if (ModuleSet.HandleInteraction(state))
			{
				return true;
			}
			if (state.IsCancellingMenu)
			{
				this.OnClose();
				return true;
			}
			return false;
		}

		public void Clear()
		{
			ModuleSet.Clear();
		}

		public void Destroy()
		{
			ModuleSet.Destroy();
		}

		public void GainFocus()
		{
		}

		public void LoseFocus()
		{
		}
	}
}
