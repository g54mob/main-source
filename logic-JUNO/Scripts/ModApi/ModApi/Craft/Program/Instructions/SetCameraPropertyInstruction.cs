using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Craft.Program.Craft;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class SetCameraPropertyInstruction : ProgramInstruction
	{
		private class CameraProperty
		{
			public string DisplayName { get; set; }

			public ListItemInfoType ItemType { get; }

			public Action<ICraftService, ExpressionResult> Setter { get; set; }

			public string Tooltip { get; }

			public string XmlName { get; set; }

			public CameraProperty(string displayName, string xmlName, ListItemInfoType itemType, string tooltip, Action<ICraftService, ExpressionResult> setter)
			{
				DisplayName = displayName;
				XmlName = xmlName;
				ItemType = itemType;
				Tooltip = tooltip;
				Setter = setter;
			}
		}

		private static List<CameraProperty> _properties;

		[ProgramNodeProperty]
		private string _property;

		private CameraProperty _selectedProperty;

		static SetCameraPropertyInstruction()
		{
			_properties = new List<CameraProperty>();
			AddProperty("X Rotation", "rotationX", ListItemInfoType.Number, "Rotates the camera up and down.", delegate(ICraftService c, ExpressionResult x)
			{
				c.SetCameraProperty(ModApi.Craft.Program.Craft.CameraProperty.RotationX, x);
			});
			AddProperty("Y Rotation", "rotationY", ListItemInfoType.Number, "Rotates the camera left and right.", delegate(ICraftService c, ExpressionResult x)
			{
				c.SetCameraProperty(ModApi.Craft.Program.Craft.CameraProperty.RotationY, x);
			});
			AddProperty("Tilt", "tilt", ListItemInfoType.Number, "Rotates the camera around its viewing axis.", delegate(ICraftService c, ExpressionResult x)
			{
				c.SetCameraProperty(ModApi.Craft.Program.Craft.CameraProperty.Tilt, x);
			});
			AddProperty("Zoom", "zoom", ListItemInfoType.Number, "Sets the distance of the camera from the target in meters.", delegate(ICraftService c, ExpressionResult x)
			{
				c.SetCameraProperty(ModApi.Craft.Program.Craft.CameraProperty.Zoom, x);
			});
			AddProperty("Camera Mode", "mode", ListItemInfoType.Text, "Sets the current camera mode by name.", delegate(ICraftService c, ExpressionResult x)
			{
				c.SetCameraProperty(ModApi.Craft.Program.Craft.CameraProperty.CameraMode, x);
			});
			AddProperty("Camera Index", "modeIndex", ListItemInfoType.Number, "Sets the current camera mode by index.", delegate(ICraftService c, ExpressionResult x)
			{
				c.SetCameraProperty(ModApi.Craft.Program.Craft.CameraProperty.CameraModeIndex, x);
			});
			AddProperty("Target Offset", "targetOffset", ListItemInfoType.Vector, "Offsets the position of the camera target in craft space.", delegate(ICraftService c, ExpressionResult x)
			{
				c.CraftScript.CameraTargetOffset = x.VectorValue.ToVector3();
			});
		}

		public SetCameraPropertyInstruction()
		{
			_property = _properties[0].XmlName;
		}

		public override ProgramInstruction Execute(IThreadContext context)
		{
			if (_selectedProperty != null)
			{
				ExpressionResult arg = GetExpression(0).Evaluate(context);
				_selectedProperty.Setter(context.Craft, arg);
			}
			return base.Execute(context);
		}

		public override List<ListItemInfo> GetListItems(string listId)
		{
			List<ListItemInfo> list = new List<ListItemInfo>();
			foreach (CameraProperty property in _properties)
			{
				list.Add(new ListItemInfo(property.XmlName, property.DisplayName, property.Tooltip, property.ItemType));
			}
			return list;
		}

		public override string GetListValue(string listId)
		{
			return _selectedProperty.XmlName;
		}

		public override void OnDeserialized(XElement xml)
		{
			base.OnDeserialized(xml);
			_selectedProperty = _properties.Where((CameraProperty x) => x.XmlName == _property).FirstOrDefault();
		}

		public override void SetListValue(string listId, string value)
		{
			_property = value;
		}

		private static void AddProperty(string displayName, string xmlName, ListItemInfoType itemType, string tooltip, Action<ICraftService, ExpressionResult> setter)
		{
			_properties.Add(new CameraProperty(displayName, xmlName, itemType, tooltip, setter));
		}
	}
}
