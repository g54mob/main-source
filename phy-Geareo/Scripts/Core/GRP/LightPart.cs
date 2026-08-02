using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GRP
{
	public class LightPart : Part<LightPartConfig>, IControllable, IColorable, ICreatedSize, ICreatedInverted
	{
		[JsonDataState(null)]
		public State<string> color;

		[JsonDataState(null)]
		public State<bool> inverted;

		[JsonDataState(null)]
		public State<int> channel;

		[JsonDataState(null)]
		public State<float> width;

		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<float> depth;

		[JsonDataState(null)]
		public State<Key> key;

		public StateSelector<Vector3> size;

		public StateSelector<Color> colorValue;

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

		public void GetKeys(KeyBuilder builder)
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
	}
}
