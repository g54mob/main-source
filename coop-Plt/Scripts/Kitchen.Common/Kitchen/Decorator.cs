using System.Collections.Generic;
using Kitchen.Layouts;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public abstract class Decorator : IDecorator
	{
		protected LayoutBlueprint Blueprint;

		protected LayoutProfile Profile;

		protected IDecorationConfiguration Configuration;

		protected List<CLayoutAppliancePlacement> Decorations;

		public static Vector3 GetNameplateTile(Vector3 external_front_door)
		{
			return new Vector3((external_front_door.x < 3f) ? (external_front_door.x + 1f) : (external_front_door.x - 1f), 0f, external_front_door.z - 1f);
		}

		public Decorator Setup(LayoutBlueprint blueprint, LayoutProfile profile, IDecorationConfiguration settings, List<CLayoutAppliancePlacement> decorations)
		{
			Blueprint = blueprint;
			Profile = profile;
			Configuration = settings;
			Decorations = decorations;
			return this;
		}

		public abstract bool Decorate(Room room);

		protected void NewPiece(Appliance app, float x, float y, Quaternion rotation)
		{
			if ((bool)app)
			{
				NewPiece(app.ID, x, y, rotation);
			}
		}

		protected void NewPiece(int app, float x, float y, Quaternion rotation)
		{
			if (app != 0)
			{
				Decorations.Add(new CLayoutAppliancePlacement
				{
					Appliance = app,
					Position = new Vector3(x, 0f, y),
					Rotation = rotation
				});
			}
		}

		protected void NewPiece(Appliance app, LayoutPosition pos, Orientation rotation)
		{
			if ((bool)app)
			{
				NewPiece(app.ID, pos.x, pos.y, rotation.ToRotation());
			}
		}

		protected void NewPiece(Appliance app, float x, float y)
		{
			if ((bool)app)
			{
				NewPiece(app.ID, x, y);
			}
		}

		protected void NewPiece(int app, float x, float y)
		{
			if (app != 0)
			{
				NewPiece(app, x, y, Quaternion.identity);
			}
		}
	}
}
