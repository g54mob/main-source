using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class RetractableLandingGearScript : LandingGearScript
	{
		private bool _animating;

		private Animation _animation;

		private AnimationState _animationState;

		private bool _down = true;

		private bool _dragReduced;

		private AnimationState _flippedAnimationState;

		private AnimationState _normalAnimationState;

		private AudioSource _retractAudioSource;

		private float _retractAudioVolume;

		private bool _retractionDamaged;

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			base.OnDamageLevelIncreased(level, lastDamage, lastDamagePosition, lastDamageDirection);
			_retractionDamaged = _retractionDamaged || Random.value < 0.2f * (float)level;
		}

		public override void OnMirrored(PartData sourcePart)
		{
			base.OnMirrored(sourcePart);
			if (base.LandingGear.CanFlip)
			{
				base.LandingGear.Flipped = !base.LandingGear.Flipped;
				UpdateFlipConfiguration();
			}
		}

		public void UpdateFlipConfiguration()
		{
			if (!base.LandingGear.CanFlip)
			{
				return;
			}
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("LowerAssembly", base.PartScript.gameObject);
			GameObject editorColliders = Utilities.FindFirstGameObjectMyselfOrChildren("EditorColliders", base.PartScript.gameObject);
			GameObject gameObject2 = Utilities.FindFirstGameObjectMyselfOrChildren("RightPanel", base.PartScript.gameObject);
			GameObject gameObject3 = Utilities.FindFirstGameObjectMyselfOrChildren("LeftPanel", base.PartScript.gameObject);
			if (base.LandingGear.Flipped)
			{
				if (_flippedAnimationState != null)
				{
					_animationState = _flippedAnimationState;
				}
				gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
				gameObject2.SetActive(value: false);
				gameObject3.SetActive(value: true);
				UpdateEditorColliders(editorColliders, mirrored: true);
			}
			else
			{
				if (_normalAnimationState != null)
				{
					_animationState = _normalAnimationState;
				}
				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				gameObject2.SetActive(value: true);
				gameObject3.SetActive(value: false);
				UpdateEditorColliders(editorColliders, mirrored: false);
			}
		}

		protected override void OnStart(in CraftUpdateFrameData frame)
		{
			_animation = base.PartScript.GetComponent<Animation>();
			_flippedAnimationState = null;
			foreach (AnimationState item in _animation)
			{
				if (_normalAnimationState == null)
				{
					_normalAnimationState = item;
				}
				else
				{
					_flippedAnimationState = item;
				}
			}
			_animationState = _normalAnimationState;
			UpdateFlipConfiguration();
			base.OnStart(in frame);
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				_retractAudioSource = base.transform.parent.GetComponentInChildren<AudioSource>();
				_retractAudioVolume = _retractAudioSource.volume;
			}
		}

		protected override void OnUpdate(in CraftUpdateFrameData frame)
		{
			base.OnUpdate(in frame);
			_animationState.speed = (_down ? (-1f) : 1f);
			if (_animating)
			{
				if (!_retractAudioSource.isPlaying)
				{
					_retractAudioSource.Play();
					_retractAudioSource.timeSamples = (int)(Random.value * (float)_retractAudioSource.clip.samples);
				}
				_retractAudioSource.volume = _retractAudioVolume;
				if (!_animation.isPlaying)
				{
					_retractAudioSource.Stop();
					_retractAudioSource.volume = 0f;
					_animating = false;
					if (_down)
					{
						if (_dragReduced)
						{
							_dragReduced = false;
							base.PartScript.Body.DragPhysics.AddDrag(base.PartScript.Part.PartDrag);
						}
						base.WheelCollider.SuspensionEnabled = true;
					}
					else if (!_dragReduced)
					{
						_dragReduced = true;
						base.PartScript.Body.DragPhysics.AddDrag(base.PartScript.Part.PartDrag.Scale(-1f));
					}
				}
			}
			AnimateLandingGear(base.PartScript.Aircraft.Controls.LandingGearDown);
			base.LandingGearEnabled = base.PartScript.Aircraft.Controls.LandingGearDown;
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			base.RegisterUpdateMethods(in registrar);
			registrar.RegisterUpdate(OnUpdatePaused, CraftUpdateFlags.LocalAndRemote | CraftUpdateFlags.FlightScene | CraftUpdateFlags.Paused);
		}

		private void AnimateLandingGear(bool down)
		{
			if (down == _down || _retractionDamaged)
			{
				return;
			}
			base.WheelCollider.SuspensionEnabled = false;
			_animating = true;
			_down = down;
			if (down)
			{
				_animationState.speed = -1f;
				if (!_animation.isPlaying)
				{
					_animation.Play(_animationState.name);
					_animationState.normalizedTime = 1f;
				}
			}
			else
			{
				_animationState.speed = 1f;
				if (!_animation.isPlaying)
				{
					_animation.Play(_animationState.name);
					_animationState.normalizedTime = 0f;
				}
			}
		}

		private void OnUpdatePaused(in CraftUpdateFrameData frame)
		{
			if (_animation.isPlaying)
			{
				_animationState.speed = 0f;
			}
		}

		private void UpdateEditorColliders(GameObject editorColliders, bool mirrored)
		{
			if (!(editorColliders != null))
			{
				return;
			}
			float num = (mirrored ? 1 : (-1));
			foreach (Transform item in editorColliders.transform)
			{
				Vector3 localPosition = item.localPosition;
				localPosition.x = Mathf.Abs(localPosition.x) * num;
				item.localPosition = localPosition;
			}
		}
	}
}
