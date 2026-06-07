using Reactivity;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.Quarry.UI
{
	public class DroneTargetController : RComponent
	{
		[Header("References")]
		[SerializeField]
		private RText _maxDepthText;

		[SerializeField]
		private RImage _rockSprite;

		[SerializeField]
		private RImage _caretImage;

		[SerializeField]
		private RComponent _dropdownGO;

		public RBool IsOpen { get; }

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}

		public void ClickedOption(int rockLayerType)
		{
		}

		public void Clicked()
		{
		}

		public void ClickedOutside()
		{
		}
	}
}
