using System;
using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors
{
	public class WestwoodsWaterHue : MonoBehaviour
	{
		private enum HueChangeState
		{
			Intro = 0,
			Loop = 1
		}

		[Serializable]
		private struct WestwoodsHueChange
		{
			public Gradient HueChangeOverTime;

			[Tooltip("How long does this section of the sequence last for in total before going to the next hue change in the list")]
			public float Duration;

			[Tooltip("How long is a single loop of this colour gradient")]
			public float HueLoopDuration;
		}

		[SerializeField]
		private Gradient _introHueGradient;

		[SerializeField]
		private float _introHueIncrease;

		[SerializeField]
		private float _introDuration;

		[SerializeField]
		private float _introHueChangeDuration;

		[SerializeField]
		private float _hueChangeTransitionTime;

		private TileSprite _waterTileSprite;

		private HueChangeState _currentHueChangeState;

		private float _hueTimer;

		private float _hueChangeTimer;

		private int _currentHueChangeIndex;

		private bool _transitioning;

		private float _transitionTimer;

		private Color _transitionStartColour;

		[Header("Looping colour changes")]
		[SerializeField]
		private WestwoodsHueChange[] _hueChanges;

		public void SetWaterTileSprite(TileSprite waterTileSprite)
		{
		}

		private void Update()
		{
		}
	}
}
