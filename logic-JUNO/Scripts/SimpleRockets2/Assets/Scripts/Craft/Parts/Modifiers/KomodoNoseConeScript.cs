using System;
using ModApi;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class KomodoNoseConeScript : PartModifierScript<KomodoNoseConeData>, IConnectedAttachPointChangedHandler
	{
		private Transform _hingeExtension;

		private SubPartRotatorScript _rotatorScript;

		private Transform _scalar;

		void IConnectedAttachPointChangedHandler.OnAttachPointRadiusChanged(AttachPoint connectionAttachPoint, AttachPoint otherAttachPoint)
		{
			UpdateRadius(otherAttachPoint.Radius);
		}

		public override void OnConnectedToPart(PartConnectedEventData e)
		{
			base.OnConnectedToPart(e);
			UpdateRadius(e.TargetAttachPoint.Radius);
		}

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
			_rotatorScript = base.PartScript.GetModifier<SubPartRotatorScript>();
			OnRotated(_rotatorScript.Data.CurrentEnabledPercent);
			SubPartRotatorScript rotatorScript = _rotatorScript;
			rotatorScript.OnEnabledPercentChanged = (Action<float>)Delegate.Combine(rotatorScript.OnEnabledPercentChanged, new Action<float>(OnRotated));
		}

		public override void OnPartDestroyed()
		{
			base.OnPartDestroyed();
			if (_rotatorScript?.OnEnabledPercentChanged != null)
			{
				SubPartRotatorScript rotatorScript = _rotatorScript;
				rotatorScript.OnEnabledPercentChanged = (Action<float>)Delegate.Remove(rotatorScript.OnEnabledPercentChanged, new Action<float>(OnRotated));
			}
		}

		public void UpdateScale(float newScale)
		{
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 1f * newScale;
			}
			_scalar.localScale = new Vector3(newScale, newScale, newScale);
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_scalar = Utilities.FindFirstGameObjectMyselfOrChildren("Parent", base.PartScript.GameObject).transform;
			_hingeExtension = Utilities.FindFirstGameObjectMyselfOrChildren("HingeExtension", _scalar.gameObject).transform;
			UpdateScale(base.Data.Scale);
		}

		private void OnRotated(float openPercent)
		{
			_hingeExtension.localRotation = Quaternion.Euler(new Vector3(Mathf.Lerp(0f, -41f, (openPercent - 0.785f) * 4.652f), 0f, 0f));
		}

		private void UpdateRadius(float radius)
		{
			float num = radius / base.Data.DefaultRadius;
			if (num >= 0.5f)
			{
				UpdateScale(num);
				base.Data.Scale = num;
			}
		}
	}
}
