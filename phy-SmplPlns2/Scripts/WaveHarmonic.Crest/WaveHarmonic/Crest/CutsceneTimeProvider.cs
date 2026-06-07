using System;
using UnityEngine;
using UnityEngine.Playables;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Time/Crest Cutscene Time Provider")]
	public sealed class CutsceneTimeProvider : TimeProvider
	{
		[Tooltip("Playable Director to take time from.")]
		[SerializeField]
		internal PlayableDirector _PlayableDirector;

		[Tooltip("Time offset which will be added to the Timeline time.")]
		[SerializeField]
		private float _TimeOffset;

		[Tooltip("Assign this time provider to the water system when this component becomes active.")]
		[SerializeField]
		private bool _AssignToWaterComponentOnEnable = true;

		[Tooltip("Restore the time provider that was previously assigned to water system when this component disables.")]
		[SerializeField]
		private bool _RestorePreviousTimeProviderOnDisable = true;

		private readonly DefaultTimeProvider _FallbackTimeProvider = new DefaultTimeProvider();

		private bool _Attached;

		public bool AssignToWaterComponentOnEnable
		{
			get
			{
				return _AssignToWaterComponentOnEnable;
			}
			set
			{
				_AssignToWaterComponentOnEnable = value;
			}
		}

		public PlayableDirector PlayableDirector
		{
			get
			{
				return _PlayableDirector;
			}
			set
			{
				_PlayableDirector = value;
			}
		}

		public bool RestorePreviousTimeProviderOnDisable
		{
			get
			{
				return _RestorePreviousTimeProviderOnDisable;
			}
			set
			{
				_RestorePreviousTimeProviderOnDisable = value;
			}
		}

		public float TimeOffset
		{
			get
			{
				return _TimeOffset;
			}
			set
			{
				_TimeOffset = value;
			}
		}

		private protected override Action<WaterRenderer> OnEnableMethod => Attach;

		public override float Time
		{
			get
			{
				if (_PlayableDirector != null && _PlayableDirector.isActiveAndEnabled && (!Application.isPlaying || _PlayableDirector.state == PlayState.Playing))
				{
					return (float)_PlayableDirector.time + _TimeOffset;
				}
				return _FallbackTimeProvider.Time;
			}
		}

		public override float Delta => UnityEngine.Time.deltaTime;

		private protected override void OnDisable()
		{
			base.OnDisable();
			WaterRenderer instance = ManagerBehaviour<WaterRenderer>.Instance;
			if (_RestorePreviousTimeProviderOnDisable && _Attached && instance != null)
			{
				instance.TimeProviders.Pop(this);
			}
			_Attached = false;
		}

		private void Attach(WaterRenderer water)
		{
			if (!_Attached && !(_PlayableDirector == null))
			{
				if (_AssignToWaterComponentOnEnable && (bool)water)
				{
					water.TimeProviders.Push(this);
				}
				_Attached = true;
			}
		}
	}
}
