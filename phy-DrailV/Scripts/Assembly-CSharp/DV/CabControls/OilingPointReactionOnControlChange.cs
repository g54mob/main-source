using UnityEngine;

namespace DV.CabControls
{
	public class OilingPointReactionOnControlChange : AReactionOnControlChange
	{
		public GameObject capToRotate;

		public Vector3 localRotationOpened;

		public Vector3 localRotationClosed;

		public bool OilingPointOpened { get; private set; }

		protected override void OnValueChanged(ValueChangedEventArgs valueChangedEventArgs)
		{
			OilingPointOpened = valueChangedEventArgs.newValue > 0.5f;
			capToRotate.transform.localRotation = (OilingPointOpened ? Quaternion.Euler(localRotationOpened) : Quaternion.Euler(localRotationClosed));
		}
	}
}
