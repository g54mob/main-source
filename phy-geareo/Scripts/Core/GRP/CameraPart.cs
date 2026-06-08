using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GRP
{
	public class CameraPart : Part<CameraPartConfig>, IControllable
	{
		[JsonDataState(null)]
		public State<bool> lockZ;

		[JsonDataState(null)]
		public State<int> fov;

		[JsonDataState(null)]
		public State<float> distance;

		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<float> around;

		[JsonDataState(null)]
		public State<float> tilt;

		[JsonDataState(null)]
		public State<float> roll;

		[JsonDataState(null)]
		public State<float> yaw;

		[JsonDataState(null)]
		public State<float> smooth;

		[JsonDataState(null)]
		public State<Key> key;

		[JsonDataState(null)]
		public State<int> channel;

		public RenderTexture texture;

		protected override PartViewable DoCreateViewable()
		{
			return null;
		}

		public override void OnContext()
		{
		}

		public override void OnExpositorUI(ImUIBuilder ui)
		{
		}

		private float Snap(float value, float step)
		{
			return 0f;
		}

		public void GetKeys(KeyBuilder builder)
		{
		}

		public void MoveCamera(Transform anchor, Transform camTransform, float smooth)
		{
		}

		public override void BuildExhibit(ExhibitBuilder builder)
		{
		}
	}
}
