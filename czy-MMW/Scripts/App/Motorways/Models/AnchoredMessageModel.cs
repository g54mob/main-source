using Factory;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class AnchoredMessageModel : Model<EmptyModelFrame, AnchoredMessageModel.IObserver>
	{
		public interface IObserver
		{
			void OnAnimationRelease();
		}

		public StringId Message { get; private set; }

		public AnchoredMessageAnchorType AnchorType { get; private set; }

		public Vector2 Offset { get; private set; }

		public Vector3 WorldAnchor { get; private set; }

		public TileDirection Direction { get; private set; }

		public UIMessageAnchor UIAnchor { get; private set; }

		public Vector2 UIAnchorPivot { get; private set; }

		public CameraLayer CameraLayer { get; private set; }

		public bool ShowDismissArrow { get; set; }

		public int? IntParameter { get; set; }

		public void InitializeWithScreenAnchor(StringId message, Vector2 screenOffset, CameraLayer cameraLayer = CameraLayer.Default, int? intParameter = null)
		{
			Message = message;
			AnchorType = AnchoredMessageAnchorType.Screen;
			Offset = screenOffset;
			CameraLayer = cameraLayer;
			IntParameter = intParameter;
		}

		public void InitializeWithWorldAnchor(StringId message, Vector3 worldAnchor, TileDirection direction)
		{
			Message = message;
			AnchorType = AnchoredMessageAnchorType.World;
			WorldAnchor = worldAnchor;
			Direction = direction;
			UIAnchor = UIMessageAnchor.None;
		}

		public void InitializeWithUIAnchor(StringId message, UIMessageAnchor uiAnchor, Vector2 uiAnchorPivot)
		{
			Message = message;
			AnchorType = AnchoredMessageAnchorType.UI;
			UIAnchor = uiAnchor;
			UIAnchorPivot = uiAnchorPivot;
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnAnimationRelease();
			}
			base.OnReleasedFromScope(scope);
		}

		public override void Reset()
		{
			base.Reset();
			Message = StringId.None;
			AnchorType = AnchoredMessageAnchorType.Screen;
			Offset = default(Vector2);
			WorldAnchor = default(Vector3);
			Direction = TileDirection.North;
			UIAnchor = UIMessageAnchor.None;
			UIAnchorPivot = default(Vector2);
			CameraLayer = CameraLayer.Default;
			ShowDismissArrow = false;
			IntParameter = null;
		}

		public AnchoredMessageModel()
			: base(1)
		{
		}
	}
}
