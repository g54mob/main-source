using UnityEngine;
using UnityEngine.Playables;

namespace Animancer
{
	[AddComponentMenu("Animancer/Exposed Property Table")]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/ExposedPropertyTable")]
	[DefaultExecutionOrder(-10000)]
	public class ExposedPropertyTable : MonoBehaviour
	{
		[SerializeField]
		private AnimancerComponent _Animancer;

		[SerializeField]
		private PlayableDirector _Director;

		protected virtual void Reset()
		{
			OnValidate();
			if (_Director == null)
			{
				_Director = base.gameObject.AddComponent<PlayableDirector>();
			}
			_Director.enabled = false;
			_Director.playOnAwake = false;
		}

		protected virtual void OnValidate()
		{
			base.gameObject.GetComponentInParentOrChildren(ref _Animancer);
			base.gameObject.GetComponentInParentOrChildren(ref _Director);
		}

		protected virtual void Awake()
		{
			_Animancer.Playable.Graph.SetResolver(_Director);
		}
	}
}
