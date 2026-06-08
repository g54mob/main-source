using UnityEngine;

namespace Kitchen.Modules
{
	public class ModuleGrid : ModuleSet
	{
		public float Padding = 0.1f;

		public int RowLength = 5;

		public int ColumnLength = 5;

		public float XSpacing = 0.5f;

		public float YSpacing = 0.5f;

		public override Bounds BoundingBox
		{
			get
			{
				Bounds boundingBox = base.BoundingBox;
				boundingBox.Expand(new Vector3(Padding, Padding));
				return boundingBox;
			}
		}

		public void AddModule(IModule module)
		{
			int num = Modules.Count % RowLength;
			int num2 = (Modules.Count - num) / RowLength;
			module.Position = new Vector2(XSpacing * (float)num, (0f - YSpacing) * (float)num2);
			AddModule(module, module.Position);
		}

		protected override void MoveVertical(bool up, bool is_looping = false)
		{
			Move(up ? Orientation.Up : Orientation.Down);
		}

		protected override void MoveHorizontal(bool right)
		{
			Move(right ? Orientation.Right : Orientation.Left);
		}

		private void Move(Orientation dir)
		{
			if (base.Selected == null)
			{
				return;
			}
			int num = Modules.IndexOf(base.Selected);
			if (num < 0)
			{
				base.Selected = Modules[0];
				return;
			}
			int num2 = num;
			num = num2 + dir switch
			{
				Orientation.Right => 1, 
				Orientation.Down => RowLength, 
				Orientation.Left => -1, 
				Orientation.Up => -RowLength, 
				_ => 0, 
			};
			if (num >= 0 && num < ColumnLength * RowLength && Modules[num].Module.IsSelectable)
			{
				base.Selected = Modules[num];
			}
		}
	}
}
