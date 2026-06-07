using DV.UIFramework;
using DV.Utils;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class LocoHUDControlBase : MonoBehaviour
	{
		public HUDControlModule controlModule;

		public HUDVisualLevelModule visualLevelModule;

		public HUDTextModule textModule;

		public HUDLightIndicatorModule lightIndicatorModule;

		public string VisibleName { get; private set; }

		private void OnValidate()
		{
			if (!controlModule)
			{
				controlModule = GetComponent<HUDControlModule>();
			}
			if (!visualLevelModule)
			{
				visualLevelModule = GetComponent<HUDVisualLevelModule>();
			}
			if (!textModule)
			{
				textModule = GetComponent<HUDTextModule>();
			}
			if (!lightIndicatorModule)
			{
				lightIndicatorModule = GetComponent<HUDLightIndicatorModule>();
			}
		}

		private void Awake()
		{
			IHoverable[] componentsInChildren = GetComponentsInChildren<IHoverable>();
			foreach (IHoverable hoverable in componentsInChildren)
			{
				SingletonBehaviour<HUDHoverManager>.Instance.RegisterHoverable(hoverable, hoverable.GetGameObject().GetComponentInParent<LocoHUDControlBase>());
			}
		}

		private void Start()
		{
			HUDElementNameProviderBase component = GetComponent<HUDElementNameProviderBase>();
			if ((bool)component)
			{
				VisibleName = component.GetName();
			}
		}

		public void ScrollValue(int notches)
		{
			if ((bool)controlModule)
			{
				controlModule.ScrollValue(notches);
			}
		}

		public void SetVisualLevel(float level)
		{
			if ((bool)visualLevelModule)
			{
				visualLevelModule.SetVisualLevel(level);
			}
		}

		public void SetIndicatorColor(Color color)
		{
			if ((bool)lightIndicatorModule)
			{
				lightIndicatorModule.SetIndicatorColor(color);
			}
		}

		public void SetTextValue(string value)
		{
			if ((bool)textModule)
			{
				textModule.SetTextValue(value);
			}
		}

		public void SetTextUnit(string value)
		{
			if ((bool)textModule)
			{
				textModule.SetTextUnit(value);
			}
		}
	}
}
