using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class WingLandingGearScript : LandingGearScript
	{
		private bool _animating;

		private float _animationTime;

		private bool _down = true;

		private bool _dragReduced;

		private Transform _gearAssembly;

		private AudioSource _retractAudioSource;

		private float _retractAudioVolume;

		private float _startRotation;

		private float _targetRotation;

		private float _time;

		private float _wingAngle;

		protected override void OnStart(in CraftUpdateFrameData frame)
		{
			base.OnStart(in frame);
			if (frame.CraftLoadContext != CraftLoadContext.Flight)
			{
				return;
			}
			PartData part = base.PartScript.Part;
			if (part.PartConnections.Count == 1)
			{
				WingScript modifier = part.PartConnections[0].GetOtherPart(part).PartScript.GetModifier<WingScript>();
				if (modifier != null)
				{
					_wingAngle = modifier.DihedralAngle;
					Vector3 vector = modifier.transform.up;
					Vector3 vector2 = modifier.transform.right;
					if (modifier.Wing.Inverted)
					{
						vector = -vector;
						vector2 = -vector2;
					}
					float num = Vector3.Dot(base.transform.right, vector) * Vector3.Dot(base.transform.up, vector2);
					_wingAngle *= num;
				}
			}
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				_retractAudioSource = base.transform.parent.GetComponentInChildren<AudioSource>();
				_retractAudioVolume = _retractAudioSource.volume;
			}
			_gearAssembly = Utilities.FindFirstGameObjectMyselfOrChildren("GearAssembly", base.PartScript.gameObject).transform;
		}

		protected override void OnUpdate(in CraftUpdateFrameData frame)
		{
			base.OnUpdate(in frame);
			if (_animating)
			{
				if (!_retractAudioSource.isPlaying)
				{
					_retractAudioSource.Play();
					_retractAudioSource.timeSamples = (int)(Random.value * (float)_retractAudioSource.clip.samples);
				}
				_retractAudioSource.volume = _retractAudioVolume;
				bool flag = false;
				_time += Time.deltaTime;
				float t = Mathf.Clamp01(_time / _animationTime);
				Vector3 localEulerAngles = _gearAssembly.localEulerAngles;
				localEulerAngles.z = Mathf.Lerp(_startRotation, _targetRotation, t);
				_gearAssembly.localEulerAngles = localEulerAngles;
				if (Utilities.CompareFloats(localEulerAngles.z, _targetRotation, 0.01f))
				{
					flag = true;
				}
				if (flag)
				{
					_animating = false;
					if (_retractAudioSource != null)
					{
						_retractAudioSource.Stop();
						_retractAudioSource.volume = 0f;
					}
					if (_down)
					{
						if (_dragReduced)
						{
							_dragReduced = false;
							base.PartScript.Body.DragPhysics.AddDrag(base.PartScript.Part.PartDrag);
						}
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

		private void AnimateLandingGear(bool down)
		{
			if (down != _down)
			{
				_animating = true;
				_down = down;
				_time = 0f;
				_animationTime = 2f;
				_startRotation = _gearAssembly.localEulerAngles.z;
				if (_startRotation > 350f)
				{
					_startRotation = 0f;
				}
				if (down)
				{
					_targetRotation = 0f;
				}
				else
				{
					_targetRotation = 90f + _wingAngle;
				}
			}
		}
	}
}
