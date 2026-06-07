using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringSquashAndStretch")]
	public class MMSpringSquashAndStretch : MMSpringFloatComponent<Transform>
	{
		public enum PossibleAxis
		{
			XtoYZ = 0,
			XtoY = 1,
			XtoZ = 2,
			YtoXZ = 3,
			YtoX = 4,
			YtoZ = 5,
			ZtoXZ = 6,
			ZtoX = 7,
			ZtoY = 8
		}

		[MMInspectorGroup("Target", true, 17, false)]
		public PossibleAxis Axis;

		protected Vector3 _newScale;

		protected Vector3 _initialScale;

		protected override void Initialization()
		{
			base.Initialization();
			FloatSpring.ClampSettings.ClampMin = true;
			FloatSpring.ClampSettings.ClampMinValue = 0f;
			FloatSpring.ClampSettings.ClampMinBounce = true;
			_initialScale = Target.localScale;
		}

		protected override void ApplyValue(float newValue)
		{
			float num = 1f / Mathf.Sqrt(newValue);
			switch (Axis)
			{
			case PossibleAxis.XtoYZ:
				_newScale.x = newValue;
				_newScale.y = num;
				_newScale.z = num;
				break;
			case PossibleAxis.XtoY:
				_newScale.x = newValue;
				_newScale.y = num;
				_newScale.z = _initialScale.z;
				break;
			case PossibleAxis.XtoZ:
				_newScale.x = newValue;
				_newScale.y = _initialScale.y;
				_newScale.z = num;
				break;
			case PossibleAxis.YtoXZ:
				_newScale.x = num;
				_newScale.y = newValue;
				_newScale.z = num;
				break;
			case PossibleAxis.YtoX:
				_newScale.x = num;
				_newScale.y = newValue;
				_newScale.z = _initialScale.z;
				break;
			case PossibleAxis.YtoZ:
				_newScale.x = newValue;
				_newScale.y = _initialScale.y;
				_newScale.z = num;
				break;
			case PossibleAxis.ZtoXZ:
				_newScale.x = num;
				_newScale.y = num;
				_newScale.z = newValue;
				break;
			case PossibleAxis.ZtoX:
				_newScale.x = num;
				_newScale.y = _initialScale.y;
				_newScale.z = newValue;
				break;
			case PossibleAxis.ZtoY:
				_newScale.x = _initialScale.x;
				_newScale.y = num;
				_newScale.z = newValue;
				break;
			}
			Target.localScale = _newScale;
		}

		protected override void GrabCurrentValue()
		{
			FloatSpring.CurrentValue = Target.localScale.x;
		}
	}
}
