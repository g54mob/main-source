using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class MaterialPropertyTransition : TransitionStateCollection<float>
	{
		[Serializable]
		public class MaterialPropertyTransitionState : TransitionState
		{
			public MaterialPropertyTransitionState(string name, float stateObject)
				: base((string)null, (float)default(_00210))
			{
			}//IL_0010: Expected F4, but got O

		}

		private static Dictionary<MaterialPropertyTransition, Coroutine> activeCoroutines;

		private static List<MaterialPropertyTransition> keysToRemove;

		[SerializeField]
		private BetterImage target;

		[SerializeField]
		private float fadeDuration;

		[SerializeField]
		private List<MaterialPropertyTransitionState> states;

		[SerializeField]
		private int propertyIndex;

		public override UnityEngine.Object Target => null;

		public float FadeDurtaion
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int PropertyIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public MaterialPropertyTransition(params string[] stateNames)
			: base((string[])null)
		{
		}

		protected override void ApplyState(TransitionState state, bool instant)
		{
		}

		internal override void AddStateObject(string stateName)
		{
		}

		protected override IEnumerable<TransitionState> GetTransitionStates()
		{
			return null;
		}

		private void CrossFadeProperty(float startValue, float targetValue, float duration)
		{
		}

		private IEnumerator CoCrossFadeProperty(float startValue, float targetValue, float duration)
		{
			return null;
		}

		internal override void SortStates(string[] sortedOrder)
		{
		}
	}
}
