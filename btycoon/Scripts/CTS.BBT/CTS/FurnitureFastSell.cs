using System;
using CTS.BBT;
using CTS.Core;
using CTS.Emotes;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class FurnitureFastSell : CTSSingleton<FurnitureFastSell>
	{
		[SerializeField]
		private OrderedSelectionMode _selectionMode;

		[SerializeField]
		private InputActionReference _sellInput;

		public bool IsActive { get; private set; }

		public static event Action FastSellActivated;

		protected override void SingletonAwake()
		{
			IsActive = false;
		}

		protected override void OnSingletonDestroy()
		{
		}

		[Button(null, EButtonEnableMode.Always)]
		private void Enable()
		{
			SetActive(value: true);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void Disable()
		{
			SetActive(value: false);
		}

		public void SetActive(bool value)
		{
			if (IsActive != value)
			{
				IsActive = value;
				if (IsActive)
				{
					CTSSingleton<SelectionModeList>.Instance.AddMode(_selectionMode);
				}
				else
				{
					CTSSingleton<SelectionModeList>.Instance.RemoveMode(_selectionMode);
				}
				FurnitureFastSell.FastSellActivated?.Invoke();
			}
		}

		private void Update()
		{
			if (!(CTSSingleton<WorldSelector>.Instance.CurrentSelectionMode != _selectionMode) && _sellInput.action.IsPressed())
			{
				Furniture hovered = WorldSelector.GetHovered<Furniture>();
				if ((object)hovered != null)
				{
					int resellPriceWithSlots = hovered.GetResellPriceWithSlots();
					BoxCollider placementCollider = hovered.Bounds.PlacementCollider;
					EmoteManager.Play<EmoteBBT>(placementCollider.bounds.center, $"${resellPriceWithSlots}").SetRoom(hovered.RoomObject).SetHeight(placementCollider);
					hovered.SellFurniture();
				}
			}
		}
	}
}
