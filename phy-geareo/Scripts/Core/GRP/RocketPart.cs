using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using Rhizomatic.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GRP
{
	public class RocketPart : Part<RocketPartConfig>, IColorable, ICreatedSize, IControllable, ICreatedInverted
	{
		[JsonDataState(null)]
		public State<BodyShapeType> bodyShape;

		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<float> radius;

		[JsonDataState(null)]
		public State<string> color;

		[JsonDataState(null)]
		public State<string> material;

		[JsonDataState(null)]
		public State<bool> inverted;

		[JsonDataState(null)]
		public State<float> thrust;

		[JsonDataState(null)]
		public State<int> channel;

		[JsonDataState(null)]
		public State<Key> key;

		public StateSelector<Vector3> size;

		public StateSelector<Color> colorValue;

		public StateSelector<MaterialRowConfig> materialValue;

		public float tailHeight => 0f;

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

		public void GetColors(ColorBuilder builder)
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

		public void GetKeys(KeyBuilder builder)
		{
		}

		protected override void Load(JsonData data)
		{
		}
	}
}
