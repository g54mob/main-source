using Easing;
using UnityEngine;

namespace Motorways
{
	public class DestinationLevel : MonoBehaviour
	{
		[SerializeField]
		private float _tweenInDuration = 0.45f;

		[SerializeField]
		private float _tweenOutDuration = 0.45f;

		private TweenFloat _transitionTween = new TweenFloat();

		private MeshFilter _meshFilter;

		public bool IsTweening => _transitionTween.IsActive;

		private void Awake()
		{
			_meshFilter = base.gameObject.GetComponent<MeshFilter>();
			base.gameObject.SetActive(value: false);
		}

		public void Tick(float tickTime)
		{
			if (_transitionTween.IsActive)
			{
				float num = _transitionTween.Tick(tickTime);
				base.transform.localScale = new Vector3(num, num, 1f);
				if (num <= 0f && !_transitionTween.IsActive)
				{
					base.gameObject.SetActive(value: false);
				}
			}
		}

		public void Show(TransitionStyle transitionStyle)
		{
			base.gameObject.SetActive(value: true);
			if (transitionStyle == TransitionStyle.Tween)
			{
				base.transform.localScale = new Vector3(0f, 0f, 1f);
				_transitionTween.Start(0f, 1f, _tweenInDuration, Easings.Functions.BackEaseOut);
			}
			else
			{
				base.transform.localScale = new Vector3(1f, 1f, 1f);
				_transitionTween.Stop();
			}
		}

		public void Hide(TransitionStyle transitionStyle)
		{
			if (transitionStyle == TransitionStyle.Tween)
			{
				_transitionTween.Start(base.transform.localScale.x, 0f, _tweenOutDuration, Easings.Functions.BackEaseIn);
				return;
			}
			base.gameObject.SetActive(value: false);
			_transitionTween.Stop();
		}

		public void SetDestinationMesh(Mesh mesh)
		{
			_meshFilter.mesh = mesh;
		}
	}
}
