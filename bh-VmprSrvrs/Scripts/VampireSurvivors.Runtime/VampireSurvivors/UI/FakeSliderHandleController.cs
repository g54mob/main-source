using Rewired;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class FakeSliderHandleController : Selectable
	{
		[SerializeField]
		private float _Speed;

		[SerializeField]
		private Slider _Slider;

		[SerializeField]
		public Selectable _OnUp;

		[SerializeField]
		public Selectable _OnDown;

		private Rewired.Player _player;

		protected override void Start()
		{
		}

		private void Update()
		{
		}

		private void DoDown()
		{
		}

		private void DoUp()
		{
		}
	}
}
