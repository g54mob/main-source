using System;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

namespace Kitchen.Modules
{
	public class ModuleSet : IModule
	{
		public List<ModuleInstance> Modules;

		private ModuleInstance _Selected;

		public ModuleInstance Selected
		{
			get
			{
				if (Modules.Count == 0)
				{
					return null;
				}
				return _Selected ?? (_Selected = Modules[0]);
			}
			protected set
			{
				_Selected?.Module.LoseFocus();
				_Selected = value;
				_Selected.Module.GainFocus();
				this.OnChangeFocus(_Selected.Module);
			}
		}

		public virtual bool IsSelectable => true;

		public Vector2 Position { get; set; }

		public virtual Bounds BoundingBox
		{
			get
			{
				Bounds result = default(Bounds);
				foreach (ModuleInstance module in Modules)
				{
					result.Encapsulate(module.Module.BoundingBox);
				}
				return result;
			}
		}

		public event Action<IModule> OnChangeFocus = delegate
		{
		};

		public ModuleSet()
		{
			Modules = new List<ModuleInstance>();
		}

		public void RefreshFocus()
		{
			Selected?.Module.GainFocus();
		}

		public void Clear()
		{
			foreach (ModuleInstance module in Modules)
			{
				if (module != null && module.Module != null)
				{
					module.Module?.Destroy();
				}
			}
			Modules = new List<ModuleInstance>();
			_Selected = null;
		}

		public void Destroy()
		{
			foreach (ModuleInstance module in Modules)
			{
				module.Module?.Destroy();
			}
		}

		public void AddModule(IModule module, Vector2 position)
		{
			Modules.Add(new ModuleInstance
			{
				Module = module,
				Position = position
			});
			if ((_Selected == null || !_Selected.Module.IsSelectable) && module.IsSelectable)
			{
				Selected = Modules[Modules.Count - 1];
			}
		}

		public void GainFocus()
		{
		}

		public void LoseFocus()
		{
		}

		public bool HandleInteraction(InputState state)
		{
			ModuleInstance selected = Selected;
			if (selected != null && selected.Module.HandleInteraction(state))
			{
				return true;
			}
			if (state.MenuDown == ButtonState.Pressed)
			{
				MoveDown();
				return true;
			}
			if (state.MenuUp == ButtonState.Pressed)
			{
				MoveUp();
				return true;
			}
			if (state.MenuLeft == ButtonState.Pressed)
			{
				MoveLeft();
				return true;
			}
			if (state.MenuRight == ButtonState.Pressed)
			{
				MoveRight();
				return true;
			}
			return false;
		}

		public void Select(IModule module)
		{
			foreach (ModuleInstance module2 in Modules)
			{
				if (module2.Module == module)
				{
					Selected = module2;
					break;
				}
			}
		}

		public void MoveUp()
		{
			MoveVertical(up: true);
		}

		public void MoveDown()
		{
			MoveVertical(up: false);
		}

		public void MoveLeft()
		{
			MoveHorizontal(right: false);
		}

		public void MoveRight()
		{
			MoveHorizontal(right: true);
		}

		protected virtual void MoveVertical(bool up, bool is_looping = false)
		{
			if (Selected == null)
			{
				return;
			}
			Vector2 position = Selected.Position;
			if (is_looping)
			{
				position += ((!up) ? 1 : (-1)) * new Vector2(0f, 20f);
			}
			ModuleInstance selected = Selected;
			float num = 99f;
			foreach (ModuleInstance module in Modules)
			{
				if (module != Selected && module.Module.IsSelectable)
				{
					Vector2 vector = module.Position - position;
					float num2 = Mathf.Abs(vector.y);
					if (!(num2 < 0.25f) && vector.y > 0f == up && num2 < num)
					{
						num = num2;
						selected = module;
					}
				}
			}
			if (num > 98f && !is_looping)
			{
				MoveVertical(up, is_looping: true);
			}
			else
			{
				Selected = selected;
			}
		}

		protected virtual void MoveHorizontal(bool right)
		{
			if (Selected == null)
			{
				return;
			}
			Vector2 position = Selected.Position;
			ModuleInstance selected = Selected;
			float num = 99f;
			foreach (ModuleInstance module in Modules)
			{
				if (module != Selected && module.Module.IsSelectable)
				{
					Vector2 vector = module.Position - position;
					float num2 = Mathf.Abs(vector.x);
					if (!(Mathf.Abs(vector.y) > 0.25f) && vector.x > 0f == right && num2 < num)
					{
						num = num2;
						selected = module;
					}
				}
			}
			Selected = selected;
		}

		public void Move(Vector2 direction)
		{
			if (Selected == null)
			{
				return;
			}
			Vector2 position = Selected.Position;
			direction = direction.normalized;
			ModuleInstance selected = Selected;
			float num = 99f;
			foreach (ModuleInstance module in Modules)
			{
				if (module == Selected || !module.Module.IsSelectable)
				{
					continue;
				}
				Vector2 vector = module.Position - position;
				float magnitude = vector.magnitude;
				if (!((vector.x * direction.x + vector.y * direction.y) / magnitude < 0.5f))
				{
					float sqrMagnitude = vector.sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						selected = module;
					}
				}
			}
			Selected = selected;
		}
	}
}
