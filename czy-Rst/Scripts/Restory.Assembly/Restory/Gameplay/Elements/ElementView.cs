using System.Collections;
using Mandragora.Utils;
using Restory.Data.Elements.Condition;
using Restory.Data.Outline;
using Restory.Gameplay.Common;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class ElementView : MonoBehaviour
	{
		[SerializeField]
		protected ElementBase element;

		[Header("Outline Settings")]
		[SerializeField]
		protected OutlinableAdapter outlineAdapter;

		[SerializeField]
		[Min(0.1f)]
		private float outlineDecayTime = 0.2f;

		[Space]
		[SerializeField]
		[BoolButton(20, 0)]
		protected bool selectableWhenBlocked = true;

		protected ElementOutlineSettings outlineSettings;

		private float hideOutlineTimer;

		private Coroutine hideOutlineCoroutine;

		protected virtual bool IsActivatable => !element.IsBlocked;

		protected bool IsOutlined
		{
			get
			{
				return outlineAdapter.IsActive;
			}
			set
			{
				outlineAdapter.IsActive = value;
			}
		}

		[Inject]
		private void Construct(ElementOutlineSettings outlineSettings)
		{
			this.outlineSettings = outlineSettings;
		}

		protected virtual void OnEnable()
		{
			element.OnSelectionStateChanged.AddListener(ResolveSelectionStateChanged);
			element.OnHighlightedStateChanged.AddListener(ResolveHighlightedStateChanged);
			element.OnOverCompatibleEquipmentStateChanged.AddListener(ResolveOverCompatibleEquipmentStateChanged);
		}

		protected virtual void OnDisable()
		{
			element.OnSelectionStateChanged.RemoveListener(ResolveSelectionStateChanged);
			element.OnHighlightedStateChanged.RemoveListener(ResolveHighlightedStateChanged);
			element.OnOverCompatibleEquipmentStateChanged.RemoveListener(ResolveOverCompatibleEquipmentStateChanged);
		}

		public void HighlightCollision()
		{
			hideOutlineTimer = outlineDecayTime;
			if (hideOutlineCoroutine == null)
			{
				hideOutlineCoroutine = StartCoroutine(HideOutlineAfterTimer());
				outlineAdapter.OverridePreset = outlineSettings.NotActivatableOutline;
				IsOutlined = true;
			}
		}

		protected virtual void ResolveSelectionStateChanged()
		{
			IsOutlined = element.IsSelected && (!element.IsBlocked || selectableWhenBlocked);
			if (IsOutlined)
			{
				if (element.IsInstalling)
				{
					outlineAdapter.OverridePreset = outlineSettings.InstallingOutline;
				}
				else
				{
					OutlineSelectedElement();
				}
			}
		}

		protected void OutlineSelectedElement()
		{
			if (element.IsOnSurface)
			{
				ElementConditionBase condition = element.ConditionHandler.ElementData.Condition;
				if (condition is DirtyElementCondition)
				{
					outlineAdapter.OverridePreset = outlineSettings.DirtyElementOutline;
					return;
				}
				if (condition is DamagedElementCondition)
				{
					outlineAdapter.OverridePreset = outlineSettings.DamagedElementOutline;
					return;
				}
			}
			outlineAdapter.OverridePreset = (IsActivatable ? outlineSettings.ActivatableOutline : outlineSettings.NotActivatableOutline);
		}

		private void ResolveHighlightedStateChanged()
		{
			IsOutlined = element.IsHighlighted;
		}

		private void ResolveOverCompatibleEquipmentStateChanged()
		{
			outlineAdapter.OverridePreset = outlineSettings.ActivatableOutline;
			IsOutlined = element.IsOverCompatibleEquipment;
		}

		private IEnumerator HideOutlineAfterTimer()
		{
			while (hideOutlineTimer > 0f)
			{
				hideOutlineTimer -= Time.deltaTime;
				yield return null;
			}
			IsOutlined = false;
			hideOutlineCoroutine = null;
		}
	}
}
