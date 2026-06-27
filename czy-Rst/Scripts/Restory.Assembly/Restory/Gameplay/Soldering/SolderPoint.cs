using System;
using Restory.Data.SaveLoad.Containers;
using Restory.ObjectPools;
using UnityEngine;

namespace Restory.Gameplay.Soldering
{
	public class SolderPoint : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		private Collider pointCollider;

		[SerializeField]
		private MeshRenderer meshRenderer;

		[Space]
		[Header("Materials")]
		[SerializeField]
		private Material sootyMaterial;

		[SerializeField]
		private Material cleanedMaterial;

		[SerializeField]
		private Material burntMaterial;

		[SerializeField]
		private Material resolderedMaterial;

		private Vector3 contactPosition;

		private Vector3 originalScale;

		private Vector3 deviation;

		private float scaling;

		private bool isPivot;

		public SolderPointData Data => new SolderPointData
		{
			State = State,
			Transform = new SerializableTransform(contactPosition, Quaternion.identity),
			Deviation = deviation,
			Scaling = scaling,
			IsPivot = isPivot
		};

		public bool IsPivot => isPivot;

		public int TraceIndex { get; private set; }

		public float PositionRatioInTrace { get; private set; }

		public SolderPointState State { get; private set; }

		public bool JustTouchedBySolderer { get; set; }

		public void Init(int traceIndex, float pointPositionRatioInTrace, SolderPointData data)
		{
			TraceIndex = traceIndex;
			PositionRatioInTrace = pointPositionRatioInTrace;
			contactPosition = base.transform.localPosition;
			originalScale = base.transform.localScale;
			deviation = data.Deviation;
			scaling = data.Scaling;
			isPivot = data.IsPivot;
			SetState(data.State);
		}

		public void Clean()
		{
			TraceIndex = -1;
			JustTouchedBySolderer = false;
			base.transform.localScale = originalScale;
			deviation = Vector3.zero;
			scaling = 1f;
			SetState(SolderPointState.None);
		}

		public void ApplyCleaningTool()
		{
			if (State == SolderPointState.Sooty)
			{
				pointCollider.enabled = false;
				SetState(SolderPointState.Cleaned);
			}
		}

		public void ApplySolderingTool()
		{
			SolderPointState state = State;
			if (state == SolderPointState.Burnt || state == SolderPointState.Resoldered)
			{
				JustTouchedBySolderer = true;
			}
		}

		public void SetState(SolderPointState state)
		{
			State = state;
			switch (state)
			{
			case SolderPointState.None:
				SetNoneState();
				break;
			case SolderPointState.Sooty:
				SetSootyState();
				break;
			case SolderPointState.Cleaned:
				SetCleanedState();
				break;
			case SolderPointState.Burnt:
				SetBurntState();
				break;
			case SolderPointState.Resoldered:
				SetResolderedState();
				break;
			case SolderPointState.Disappearing:
				SetDisappearingState();
				break;
			default:
				throw new ArgumentOutOfRangeException("state", state, null);
			}
		}

		public void ToggleCollider(bool isEnabled)
		{
			if (isEnabled)
			{
				SolderPointState state = State;
				if (state == SolderPointState.None || state == SolderPointState.Resoldered || state == SolderPointState.Disappearing)
				{
					return;
				}
			}
			pointCollider.enabled = isEnabled;
		}

		public void OverrideMaterial(Material material)
		{
			meshRenderer.material = material;
		}

		private void SetNoneState()
		{
			pointCollider.enabled = false;
			meshRenderer.enabled = false;
		}

		private void SetSootyState()
		{
			base.transform.localPosition = contactPosition + deviation;
			base.transform.localScale = originalScale * scaling;
			meshRenderer.material = sootyMaterial;
			meshRenderer.enabled = true;
		}

		private void SetCleanedState()
		{
			pointCollider.enabled = false;
			base.transform.localPosition = contactPosition + deviation;
			base.transform.localScale = originalScale * scaling;
			meshRenderer.material = cleanedMaterial;
			meshRenderer.enabled = true;
		}

		private void SetBurntState()
		{
			base.transform.localPosition = contactPosition;
			base.transform.localScale = originalScale;
			meshRenderer.material = burntMaterial;
			meshRenderer.enabled = true;
		}

		private void SetResolderedState()
		{
			meshRenderer.enabled = false;
		}

		private void SetDisappearingState()
		{
			pointCollider.enabled = false;
			meshRenderer.enabled = false;
		}
	}
}
