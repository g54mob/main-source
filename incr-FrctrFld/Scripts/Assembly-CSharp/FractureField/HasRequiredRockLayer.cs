using FractureField.Rocks;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField
{
	public class HasRequiredRockLayer : RComponent
	{
		[Header("Variables")]
		[SerializeField]
		private RockLayerType _layerType;

		[SerializeField]
		private RockLayerType _maxLayerType;

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}

		public void SetLayerType(RockLayerType layerType)
		{
		}

		public void SetMaxLayerType(RockLayerType maxLayerType)
		{
		}
	}
}
