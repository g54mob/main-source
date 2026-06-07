using Reactivity;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField
{
	public class HasRequiredFeature : RComponent
	{
		[Header("Variables")]
		[SerializeField]
		private FeatureType _feature;

		[SerializeField]
		private FeatureType _cannotHaveFeature;

		public CBool ShouldBeActive { get; private set; }

		private bool GetIsFeatureAvailable(FeatureType featureType, bool trueForNone)
		{
			return false;
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Setup()
		{
		}
	}
}
