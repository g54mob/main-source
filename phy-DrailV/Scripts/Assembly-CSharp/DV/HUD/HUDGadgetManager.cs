using System.Collections.Generic;
using DV.Customization;
using DV.Customization.Gadgets;
using DV.UI.LocoHUD;
using DV.Utils;
using UniRx.Toolkit;
using UnityEngine;

namespace DV.HUD
{
	public class HUDGadgetManager : MonoBehaviour
	{
		public class HUDGadgetPool : ObjectPool<GadgetHUDModule>
		{
			public GameObject prefab;

			public Transform disabledRoot;

			protected override GadgetHUDModule CreateInstance()
			{
				GadgetHUDModule component = Object.Instantiate(prefab).GetComponent<GadgetHUDModule>();
				component.originalPrefab = prefab;
				return component;
			}

			protected override void OnBeforeReturn(GadgetHUDModule instance)
			{
				base.OnBeforeReturn(instance);
				instance.transform.SetParent(disabledRoot, worldPositionStays: false);
			}
		}

		[SerializeField]
		private Transform modulesRoot;

		private HUDInterfacer interfacer;

		private Dictionary<GameObject, HUDGadgetPool> pools = new Dictionary<GameObject, HUDGadgetPool>();

		private List<HUDPanel> panelList = new List<HUDPanel>();

		private TrainCarCustomization trainCarCustomization;

		private void Awake()
		{
			interfacer = GetComponent<HUDInterfacer>();
			interfacer.HUDRefreshCallback += OnHUDRefresh;
		}

		private void OnHUDRefresh()
		{
			if (trainCarCustomization != null)
			{
				trainCarCustomization.ModLinked -= ModLinkChanged;
				trainCarCustomization.AfterModUnlinked -= ModLinkChanged;
			}
			if (interfacer.currentCar != null)
			{
				trainCarCustomization = interfacer.currentCar.Customization;
				if (trainCarCustomization != null)
				{
					trainCarCustomization.ModLinked += ModLinkChanged;
					trainCarCustomization.AfterModUnlinked += ModLinkChanged;
				}
			}
			RefreshGadgetsInHUD();
		}

		private void RefreshGadgetsInHUD()
		{
			ReturnToPool();
			TrainCar currentCar = interfacer.currentCar;
			if (!currentCar)
			{
				return;
			}
			panelList.Clear();
			foreach (DV.Customization.Customization.CustomizerBase customizer in currentCar.GetComponent<TrainCarCustomization>().Customizers)
			{
				if (customizer is GadgetBase gadgetBase && (bool)gadgetBase.HUDPrefab)
				{
					GadgetHUDModule gadgetHUDModule = GetPool(gadgetBase.HUDPrefab).Rent();
					panelList.Add(gadgetHUDModule.panel);
					gadgetHUDModule.transform.SetParent(modulesRoot, worldPositionStays: false);
					gadgetHUDModule.SetGadget(gadgetBase);
				}
			}
			SingletonBehaviour<HUDManager>.Instance.SetGadgets(panelList);
			if ((bool)interfacer.currentHud)
			{
				interfacer.currentHud.openGadgetsButton.gameObject.SetActive(panelList.Count != 0);
			}
		}

		private void ModLinkChanged(DV.Customization.Customization.CustomizerBase _)
		{
			RefreshGadgetsInHUD();
		}

		private void ReturnToPool()
		{
			foreach (Transform item in modulesRoot)
			{
				if (item.TryGetComponent<GadgetHUDModule>(out var component))
				{
					pools[component.originalPrefab].Return(component);
				}
			}
		}

		private HUDGadgetPool GetPool(GameObject prefab)
		{
			if (!pools.TryGetValue(prefab, out var value))
			{
				value = new HUDGadgetPool();
				value.prefab = prefab;
				value.disabledRoot = base.transform;
				pools[prefab] = value;
			}
			return value;
		}
	}
}
