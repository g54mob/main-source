using System;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class SubPartRotatorScript : PartModifierScript<SubPartRotatorData>, IFlightStart, IGameLoopItem, IFlightUpdate
	{
		private Transform _offset;

		private Vector3 _offsetPositionInverse;

		private AudioSource _sound;

		private Transform _subPart;

		private bool _updateCraftWhenDoneAnimating;

		public float AngleMultiplier { get; set; } = 1f;

		public Action<float> OnEnabledPercentChanged { get; set; }

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			if (base.Data.SelfGoverned && base.Data.StartEnabled)
			{
				base.Data.Part.Activated = true;
				base.Data.StartEnabled = false;
			}
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (base.Data.SelfGoverned)
			{
				float num = (base.Data.Part.Activated ? 1 : 0);
				if (base.Data.CurrentEnabledPercent != num)
				{
					base.Data.CurrentEnabledPercent = Mathf.MoveTowards(base.Data.CurrentEnabledPercent, num, frame.DeltaTime * base.Data.RotationRate);
					SetEnabledPercent(base.Data.CurrentEnabledPercent);
					_updateCraftWhenDoneAnimating = true;
				}
				else if (_updateCraftWhenDoneAnimating)
				{
					_updateCraftWhenDoneAnimating = false;
					base.PartScript.BodyScript.OnPartMassChanged();
					base.PartScript.CraftScript.InitiateDragRecalculation();
				}
			}
		}

		public override void OnActivated()
		{
			base.OnActivated();
			if (base.Data.SelfGoverned)
			{
				if (_sound != null)
				{
					_sound.Play();
				}
				if (base.Data.SyncActivationGroup && base.Data.Part.ActivationGroup >= 1 && base.Data.Part.Activated != base.PartScript.CommandPod.GetActivationGroupState(base.Data.Part.ActivationGroup))
				{
					base.PartScript.CommandPod.SetActivationGroupState(base.PartScript.Data.ActivationGroup, base.Data.Part.Activated);
				}
			}
		}

		public override void OnDeactivated()
		{
			base.OnDeactivated();
			if (base.Data.SelfGoverned)
			{
				if (_sound != null)
				{
					_sound.Play();
				}
				if (base.Data.SyncActivationGroup && base.Data.Part.ActivationGroup >= 1 && base.Data.Part.Activated != base.PartScript.CommandPod.GetActivationGroupState(base.Data.Part.ActivationGroup))
				{
					base.PartScript.CommandPod.SetActivationGroupState(base.PartScript.Data.ActivationGroup, base.Data.Part.Activated);
				}
			}
		}

		public override void PrepareForPartIcon()
		{
			base.PrepareForPartIcon();
			if (base.Data.SelfGoverned)
			{
				SetEnabledPercent(base.Data.DesignerIconEnabledPercent);
			}
		}

		public void SetEnabledPercent(float percent)
		{
			if (_subPart == null)
			{
				Debug.LogWarning("SubPartRotator has no defined sub part.", this);
				return;
			}
			if (base.Data.AngleLerp == SubPartRotatorData.AngleLerpType.Quaternion)
			{
				_subPart.localRotation = Quaternion.Lerp(Quaternion.Euler(base.Data.DisabledRotation * AngleMultiplier), Quaternion.Euler(base.Data.EnabledRotation * AngleMultiplier), percent);
			}
			else
			{
				_subPart.localRotation = Quaternion.Euler(Vector3.Lerp(base.Data.DisabledRotation * AngleMultiplier, base.Data.EnabledRotation * AngleMultiplier, percent));
			}
			if (_offset != null)
			{
				_offset.localRotation = _subPart.localRotation;
				_subPart.position = _offset.TransformPoint(_offsetPositionInverse);
			}
			base.Data.CurrentEnabledPercent = percent;
			OnEnabledPercentChanged?.Invoke(percent);
		}

		public void SetSubPart(Transform subPart)
		{
			if (_offset != null)
			{
				UnityEngine.Object.Destroy(_offset.gameObject);
				_offset = null;
			}
			_subPart = subPart;
			if (_subPart != null && base.Data.PositionOffset.magnitude > 0f)
			{
				GameObject gameObject = new GameObject("SubPartRotatorOffset");
				_offset = gameObject.transform;
				_offset.SetParent(_subPart.parent, worldPositionStays: false);
				_offset.position = _subPart.TransformPoint(base.Data.PositionOffset);
				_offsetPositionInverse = _offset.InverseTransformPoint(_subPart.position);
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			if (base.Data.SelfGoverned)
			{
				string[] array = base.Data.SubPartPath.Split('/');
				Transform transform = base.transform;
				string[] array2 = array;
				foreach (string n in array2)
				{
					transform = transform.Find(n) ?? transform;
				}
				if (transform.name == array[^1])
				{
					SetSubPart(transform);
				}
				else
				{
					SetSubPart(Utilities.FindFirstGameObjectMyselfOrChildren(base.Data.SubPartPath, base.gameObject)?.transform);
				}
				_sound = base.gameObject.GetComponentInChildren<AudioSource>();
				if (_subPart != null)
				{
					SetEnabledPercent(base.Data.CurrentEnabledPercent);
				}
			}
		}
	}
}
