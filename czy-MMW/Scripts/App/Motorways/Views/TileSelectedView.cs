using Client;
using Easing;
using Factory.Pools;
using UnityEngine;

namespace Motorways.Views
{
	public class TileSelectedView : MonoBehaviour, IView, IReusable
	{
		private enum AnimationState
		{
			None = 0,
			Appearing = 1,
			Disappearing = 2
		}

		private static float Size = 1f;

		private static float TransitionInDuration = 0.4f;

		private static float TransitionOutDuration = 0.2f;

		private TweenFloat _transitionTween = new TweenFloat();

		private AnimationState _animationState;

		public void Reset()
		{
			_animationState = AnimationState.None;
			_transitionTween.Stop();
			base.transform.localPosition = Vector3.zero;
			base.transform.localScale = new Vector3(1f, 1f, 1f);
		}

		public void Appear()
		{
			_animationState = AnimationState.Appearing;
			_transitionTween.Start(0f, Size, TransitionInDuration, Easings.Functions.ElasticEaseOut);
		}

		public void Disappear()
		{
			_animationState = AnimationState.Disappearing;
			_transitionTween.Start(base.transform.localScale.x, 0f, TransitionOutDuration, Easings.Functions.CubicEaseIn);
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_transitionTween.IsActive)
			{
				float num = _transitionTween.Tick(timeInterval.Delta);
				base.transform.localScale = new Vector3(num, num, 1f);
				if (!_transitionTween.IsActive)
				{
					if (_animationState == AnimationState.Appearing)
					{
						_animationState = AnimationState.None;
					}
					else if (_animationState == AnimationState.Disappearing)
					{
						_animationState = AnimationState.None;
						return TickResult.Destroy;
					}
				}
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public static TileSelectedView Create(ViewClient client, TileView owningTile)
		{
			TileSelectedView tileSelectedView = client.Scope.Get<TileSelectedView>();
			tileSelectedView.transform.position = owningTile.transform.position;
			tileSelectedView.transform.localScale = new Vector3(0f, 0f, 1f);
			client.AddView(tileSelectedView);
			return tileSelectedView;
		}
	}
}
