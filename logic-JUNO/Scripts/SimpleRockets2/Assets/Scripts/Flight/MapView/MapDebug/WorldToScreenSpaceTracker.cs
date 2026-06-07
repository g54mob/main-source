using ModApi;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.MapDebug
{
	internal class WorldToScreenSpaceTracker : MonoBehaviour
	{
		public enum SpaceType
		{
			World = 0,
			Local = 1
		}

		public enum TransType
		{
			ScreenPoint = 0,
			ViewportPoint = 1
		}

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private SpaceType _space;

		[SerializeField]
		private Transform _transToTrack;

		private TransType _type;

		protected virtual void Update()
		{
			Debug.Log("target is " + Utilities.GameWorldToScreenPoint(_camera, _transToTrack.position).x + " pixels from the left");
			if (!(_camera != null) || !(_transToTrack != null))
			{
				return;
			}
			switch (_space)
			{
			case SpaceType.World:
				switch (_type)
				{
				case TransType.ScreenPoint:
					base.transform.position = Utilities.GameWorldToScreenPoint(_camera, _transToTrack.position);
					break;
				case TransType.ViewportPoint:
					base.transform.position = Utilities.GameWorldToScreenPoint(_camera, _transToTrack.position);
					break;
				}
				break;
			case SpaceType.Local:
				switch (_type)
				{
				case TransType.ScreenPoint:
					base.transform.localPosition = Utilities.GameWorldToScreenPoint(_camera, _transToTrack.position);
					break;
				case TransType.ViewportPoint:
					base.transform.localPosition = Utilities.GameWorldToScreenPoint(_camera, _transToTrack.position);
					break;
				}
				break;
			}
			base.transform.localRotation = Quaternion.identity;
		}
	}
}
