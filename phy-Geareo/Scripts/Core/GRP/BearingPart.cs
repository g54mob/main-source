using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using Rhizomatic.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GRP
{
	public class BearingPart : Part<BearingPartConfig>, IControllable, IColorable, IPartBound, ICreatedSize, ICreatedInverted
	{
		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<float> top;

		[JsonDataState(null)]
		public State<float> bottom;

		[JsonDataState(null)]
		public State<float> radius;

		[JsonDataState(null)]
		public State<float> shaftRadius;

		[JsonDataState(null)]
		public State<bool> useMotor;

		[JsonDataState(null)]
		public State<int> channel;

		[JsonDataState(null)]
		public State<bool> freeSpin;

		[JsonDataState(null)]
		public State<int> velocity;

		[JsonDataState(null)]
		public State<float> torque;

		[JsonDataState(null)]
		public State<bool> inverted;

		[JsonDataState(null)]
		public State<bool> oneway;

		[JsonDataState(null)]
		public State<int> detent;

		[JsonDataState(null)]
		public State<bool> auto;

		[JsonDataState(null)]
		public State<Key> forwardKey;

		[JsonDataState(null)]
		public State<Key> backwardKey;

		[JsonDataState(null)]
		public State<string> color;

		[JsonDataState(null)]
		public State<string> shaftColor;

		[JsonDataState(null)]
		public State<BodyShapeType> bodyShape;

		[JsonDataState(null)]
		public State<string> material;

		[JsonDataState(null)]
		public State<string> shaftMaterial;

		public StateSelector<Vector3> size;

		public StateSelector<Vector3> shaftSize;

		public StateSelector<Color> colorValue;

		public StateSelector<Color> shaftColorValue;

		public StateSelector<MaterialRowConfig> materialValue;

		public StateSelector<MaterialRowConfig> shaftMaterialValue;

		public StateSelector<float> volume;

		protected override PartViewable DoCreateViewable()
		{
			return null;
		}

		public override void OnContext()
		{
		}

		private float GetVolume()
		{
			return 0f;
		}

		private float GetMaxVolume()
		{
			return 0f;
		}

		private float GetMinVolume()
		{
			return 0f;
		}

		public override void OnExpositorUI(ImUIBuilder ui)
		{
		}

		protected override void Load(JsonData data)
		{
		}

		public void GetKeys(KeyBuilder builder)
		{
		}

		public void GetColors(ColorBuilder builder)
		{
		}

		public Vector3 GetPartSize()
		{
			return default(Vector3);
		}

		public void ClampValues()
		{
		}

		public void CreatedChangeSize(Vector2 change)
		{
		}

		public bool CreatedCanToggleInverted()
		{
			return false;
		}

		public void CreatedToggleInverted()
		{
		}

		public override void BuildExhibit(ExhibitBuilder builder)
		{
		}
	}
}
