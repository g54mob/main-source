using Assets.Scripts.Flight.UI.Navball;
using ModApi.Craft;
using ModApi.Craft.Program.Craft;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class NavballWidgetScript : WidgetScript, INavballWidget
	{
		private NavballRendererControllerScript _controller;

		private ICraftScript _craftScript;

		private Color _topColor;

		private Color _bottomColor;

		public Vector3 TopColor
		{
			get
			{
				return new Vector3(_topColor.r, _topColor.g, _topColor.b);
			}
			set
			{
				Color topColor = (_topColor = new Color(value.x, value.y, value.z, 1f));
				_controller.TopColor = topColor;
			}
		}

		public Vector3 BottomColor
		{
			get
			{
				return new Vector3(_bottomColor.r, _bottomColor.g, _bottomColor.b);
			}
			set
			{
				Color bottomColor = (_bottomColor = new Color(value.x, value.y, value.z, 1f));
				_controller.BottomColor = bottomColor;
			}
		}

		protected override Color WidgetColor
		{
			get
			{
				return base.WidgetColor;
			}
			set
			{
				base.WidgetColor = value;
				_controller.MainColor = value;
			}
		}

		public override void Initialize(MfdScript mfdScript, string name, MfdWidgetType widgetType)
		{
			base.transform.localPosition = Vector3.zero;
			_controller = GetComponent<NavballRendererControllerScript>();
			_controller.StencilValue = mfdScript.StencilValue;
			base.Initialize(mfdScript, name, widgetType);
			WidgetColor = UnityEngine.Color.white;
			_topColor = _controller.TopColor;
			_bottomColor = _controller.BottomColor;
			_craftScript = mfdScript.PartScript.CraftScript;
			_craftScript.NavballVectorUpdate += VectorUpdate;
			_craftScript.NavballRotationUpdate += RotationUpdate;
		}

		public void OnDestroy()
		{
			_craftScript.NavballVectorUpdate -= VectorUpdate;
			_craftScript.NavballRotationUpdate -= RotationUpdate;
		}

		private void RotationUpdate(Quaternion rot)
		{
			_controller.NavRotation = rot;
		}

		private void VectorUpdate(int index, Vector3? vector)
		{
			_controller.SetEnabled(index, vector.HasValue);
			if (vector.HasValue)
			{
				_controller.FlightVectors[index] = vector.Value;
			}
		}
	}
}
