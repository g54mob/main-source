using System.Diagnostics;
using UnityEngine;

namespace Animancer
{
	[CreateAssetMenu(menuName = "Animancer/Animancer Transition", order = 410)]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/AnimancerTransitionAsset")]
	public class AnimancerTransitionAsset : AnimancerTransitionAsset<ITransition>
	{
	}
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/AnimancerTransitionAsset_1")]
	public class AnimancerTransitionAsset<TTransition> : AnimancerTransitionAssetBase where TTransition : ITransition
	{
		[SerializeReference]
		private TTransition _Transition;

		public TTransition Transition
		{
			get
			{
				return _Transition;
			}
			set
			{
				_Transition = value;
			}
		}

		public bool HasTransition => _Transition != null;

		public override ITransition GetTransition()
		{
			return _Transition;
		}

		[Conditional("UNITY_ASSERTIONS")]
		private void AssertTransition()
		{
			if (_Transition == null)
			{
				UnityEngine.Debug.LogError("'" + base.name + "' Transition is not assigned. HasTransition can be used to check without triggering this error.", this);
			}
		}
	}
}
