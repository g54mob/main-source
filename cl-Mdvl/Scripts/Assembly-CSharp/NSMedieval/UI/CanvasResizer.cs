using System;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Enums;
using NSMedieval.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	[RequireComponent(typeof(CanvasScaler))]
	public class CanvasResizer : MonoBehaviour
	{
		[SerializeField]
		private UISizes[] ignoreSizes;

		private void OnEnable()
		{
			OnUISizeUpdated(MonoSingleton<UIScaleController>.Instance.GetUIScale(MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CurrentUISize));
			MonoSingleton<UIScaleController>.Instance.UpdateUISizeEvent += OnUISizeUpdated;
		}

		private void OnDisable()
		{
			if (MonoSingleton<UIScaleController>.IsInstantiated())
			{
				MonoSingleton<UIScaleController>.Instance.UpdateUISizeEvent -= OnUISizeUpdated;
			}
		}

		private void OnUISizeUpdated(float sizeScale)
		{
			CanvasScaler component = GetComponent<CanvasScaler>();
			if ((object)component != null)
			{
				Vector2 scale = GetScale(sizeScale);
				component.referenceResolution = scale;
			}
		}

		private Vector2 GetScale(float sizeScale)
		{
			Vector2 vector = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.RefResolution;
			if (ignoreSizes.Contains(MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CurrentUISize))
			{
				string[] names = Enum.GetNames(typeof(UISizes));
				for (int num = names.Length - 1; num >= 0; num--)
				{
					Enum.TryParse<UISizes>(names[num], out var result);
					if (!ignoreSizes.Contains(result))
					{
						float uIScale = MonoSingleton<UIScaleController>.Instance.GetUIScale(result);
						return new Vector2(vector.x * uIScale, vector.y * uIScale);
					}
				}
			}
			return new Vector2(vector.x * sizeScale, vector.y * sizeScale);
		}
	}
}
