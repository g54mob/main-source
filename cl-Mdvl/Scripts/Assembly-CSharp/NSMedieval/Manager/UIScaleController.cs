using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Enums;

namespace NSMedieval.Manager
{
	public class UIScaleController : MonoSingleton<UIScaleController>
	{
		public delegate void UpdateUISize(float sizeScale);

		private readonly Dictionary<UISizes, float> scaleDictionary = new Dictionary<UISizes, float>
		{
			{
				UISizes.Smallest,
				1.3f
			},
			{
				UISizes.Small,
				1.2f
			},
			{
				UISizes.Normal,
				1f
			},
			{
				UISizes.Large,
				0.9f
			},
			{
				UISizes.Largest,
				0.8f
			}
		};

		public event UpdateUISize UpdateUISizeEvent;

		private void Start()
		{
			this.UpdateUISizeEvent?.Invoke(GetUIScale(MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CurrentUISize));
		}

		public UISizes GetUISizeName(int value)
		{
			UISizes uISizes = (UISizes)Enum.Parse(typeof(UISizes), Enum.GetName(typeof(UISizes), value) ?? string.Empty);
			this.UpdateUISizeEvent?.Invoke(GetUIScale(uISizes));
			return uISizes;
		}

		public float GetUIScale(UISizes sizeName)
		{
			return scaleDictionary[sizeName];
		}

		protected override void OnDestroy()
		{
			this.UpdateUISizeEvent = null;
			base.OnDestroy();
		}
	}
}
