using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using Rhizomatic.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GRP
{
	public class LinearBearingPart : Part<LinearBearingPartConfig>, IControllable, IColorable, IPartBound, ICreatedSize, ICreatedInverted
	{
		[JsonDataState(null)]
		public State<float> width;

		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<float> length;

		[JsonDataState(null)]
		public State<float> top;

		[JsonDataState(null)]
		public State<float> bottom;

		[JsonDataState(null)]
		public State<float> shaftPosition;

		[JsonDataState(null)]
		public State<bool> useMotor;

		[JsonDataState(null)]
		public State<int> channel;

		[JsonDataState(null)]
		public State<bool> freeMove;

		[JsonDataState(null)]
		public State<float> velocity;

		[JsonDataState(null)]
		public State<float> force;

		[JsonDataState(null)]
		public State<bool> inverted;

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
		public State<string> material;

		[JsonDataState(null)]
		public State<string> shaftMaterial;

		public StateSelector<Vector3> size;

		public StateSelector<Vector3> shaftSize;

		public StateSelector<Color> colorValue;

		public StateSelector<Color> shaftColorValue;

		public StateSelector<MaterialRowConfig> materialValue;

		public StateSelector<MaterialRowConfig> shaftMaterialValue;

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

		public void ClampValues()
		{
		}

		public float GetShaftPosition()
		{
			return 0f;
		}

		public float GetShaftPosition(float pos)
		{
			return 0f;
		}

		public void SetShaftPosition(float pos)
		{
		}

		public float GetMaxShaftPosition()
		{
			return 0f;
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

		protected override void Load(JsonData data)
		{
		}

		public override void BuildExhibit(ExhibitBuilder builder)
		{
		}
	}
}
