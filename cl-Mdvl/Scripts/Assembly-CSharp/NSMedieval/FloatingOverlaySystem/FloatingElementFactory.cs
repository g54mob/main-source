using FloatingOverlaySystem.Elements;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Utils;
using UnityEngine;

namespace NSMedieval.FloatingOverlaySystem
{
	public static class FloatingElementFactory
	{
		public static TextFloatingElement ProduceTextElement(OverlayTextElementType type, FloatingElementHolderType holderType, Transform followTransform, string initialText = null)
		{
			FloatingElementHolder elementHolder = MonoSingleton<FloatingOverlayManager>.Instance.GetElementHolder(followTransform, holderType);
			if (elementHolder == null)
			{
				Log.Error("This should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\FloatingOverlaySystem\\FloatingElementFactory.cs");
				return null;
			}
			string prefabName = FloatingOverlaySystemConstants.TextElementPrefabs[(int)type];
			TextFloatingElement textFloatingElement = InstantiateOverlayElementPrefab<TextFloatingElement>(elementHolder, prefabName);
			if (!string.IsNullOrEmpty(initialText))
			{
				textFloatingElement.SetText(initialText);
			}
			textFloatingElement.Type = type;
			return textFloatingElement;
		}

		public static T ProduceProgressBarElement<T>(OverlayProgressBarType type, FloatingElementHolderType holderType, Transform followTransform) where T : ProgressBarFloatingElement
		{
			return (T)ProduceProgressBarElement(type, holderType, followTransform);
		}

		public static ProgressBarFloatingElement ProduceProgressBarElement(OverlayProgressBarType type, FloatingElementHolderType holderType, Transform followTransform)
		{
			FloatingElementHolder elementHolder = MonoSingleton<FloatingOverlayManager>.Instance.GetElementHolder(followTransform, holderType);
			if (elementHolder == null)
			{
				Log.Error("This should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\FloatingOverlaySystem\\FloatingElementFactory.cs");
				return null;
			}
			string prefabName = FloatingOverlaySystemConstants.ProgressBarPrefabNames[(int)type];
			return InstantiateOverlayElementPrefab<ProgressBarFloatingElement>(elementHolder, prefabName);
		}

		public static IconCircleFloatingElement ProduceIconCircleElement(OverlayIconCircleType type, FloatingElementHolderType holderType, Transform followTransform)
		{
			FloatingElementHolder elementHolder = MonoSingleton<FloatingOverlayManager>.Instance.GetElementHolder(followTransform, holderType);
			if (elementHolder == null)
			{
				Log.Error("This should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\FloatingOverlaySystem\\FloatingElementFactory.cs");
				return null;
			}
			string prefabName = FloatingOverlaySystemConstants.CircleIconPrefabNames[(int)type];
			return InstantiateOverlayElementPrefab<IconCircleFloatingElement>(elementHolder, prefabName);
		}

		public static DamagePopupFloatingElement ProduceDamagePopupElement(Transform followTransform)
		{
			DamagePopupFloatingElement damagePopupFloatingElement = ProduceDamagePopupElement(FloatingElementHolderType.NoGridHolder, followTransform);
			damagePopupFloatingElement.SetIndex(0);
			return damagePopupFloatingElement;
		}

		public static XpPopupFloatingElement ProduceXpPopupElement(Transform followTransform)
		{
			FloatingElementHolder elementHolder = MonoSingleton<FloatingOverlayManager>.Instance.GetElementHolder(followTransform, FloatingElementHolderType.NoGridHolder);
			if (elementHolder == null)
			{
				Log.Error("This should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\FloatingOverlaySystem\\FloatingElementFactory.cs");
				return null;
			}
			string xpPopupPrefab = FloatingOverlaySystemConstants.XpPopupPrefab;
			return InstantiateOverlayElementPrefab<XpPopupFloatingElement>(elementHolder, xpPopupPrefab);
		}

		public static ThoughtBubbleFloatingElement ProduceThoughtBubbleElement(Transform followTransform, string icon1, string icon2 = null)
		{
			return ProduceThoughtBubbleElement(FloatingElementHolderType.NoGridHolder, followTransform, icon1, icon2);
		}

		private static DamagePopupFloatingElement ProduceDamagePopupElement(FloatingElementHolderType holderType, Transform followTransform)
		{
			FloatingElementHolder elementHolder = MonoSingleton<FloatingOverlayManager>.Instance.GetElementHolder(followTransform, holderType);
			if (elementHolder == null)
			{
				Log.Error("This should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\FloatingOverlaySystem\\FloatingElementFactory.cs");
				return null;
			}
			string damagePopupPrefab = FloatingOverlaySystemConstants.DamagePopupPrefab;
			return InstantiateOverlayElementPrefab<DamagePopupFloatingElement>(elementHolder, damagePopupPrefab);
		}

		private static ThoughtBubbleFloatingElement ProduceThoughtBubbleElement(FloatingElementHolderType holderType, Transform followTransform, string icon1 = null, string icon2 = null)
		{
			FloatingElementHolder elementHolder = MonoSingleton<FloatingOverlayManager>.Instance.GetElementHolder(followTransform, holderType);
			if (elementHolder == null)
			{
				Log.Error("This should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\FloatingOverlaySystem\\FloatingElementFactory.cs");
				return null;
			}
			if (string.IsNullOrEmpty(icon1) && string.IsNullOrEmpty(icon2))
			{
				return null;
			}
			string thoughtBubblePrefab = FloatingOverlaySystemConstants.ThoughtBubblePrefab;
			ThoughtBubbleFloatingElement thoughtBubbleFloatingElement = InstantiateOverlayElementPrefab<ThoughtBubbleFloatingElement>(elementHolder, thoughtBubblePrefab);
			thoughtBubbleFloatingElement.SetupIcons(icon1, icon2);
			return thoughtBubbleFloatingElement;
		}

		public static AdditionalMenuFloatingElement ProduceAdditionalMenuElement(Transform followTransform)
		{
			Vector3 localPosOverride = (MonoSingleton<CameraManager>.Instance.GameplayCamera.WorldToScreenPoint(followTransform.position) - Input.mousePosition) * -1f;
			localPosOverride.z = 0f;
			FloatingElementHolder elementHolder = MonoSingleton<FloatingOverlayManager>.Instance.GetElementHolder(followTransform, FloatingElementHolderType.AdditionalMenu, FloatingElementParentType.Foreground);
			if (elementHolder == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(58, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FloatingOverlaySystem\\FloatingElementFactory.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("FloatingOverlayManager.GetElementHolder returned null for ");
					messageBuilder.AppendFormatted(GameObjectUtils.GetNameWithPath(followTransform));
				}
				Log.Error(messageBuilder);
				return null;
			}
			return InstantiateOverlayElementPrefab<AdditionalMenuFloatingElement>(elementHolder, FloatingOverlaySystemConstants.AdditionalMenuPrefab, localPosOverride);
		}

		private static T InstantiateOverlayElementPrefab<T>(FloatingElementHolder holder, string prefabName, Vector3 localPosOverride = default(Vector3)) where T : FloatingElementBase
		{
			GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(prefabName);
			if (byAddress == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FloatingOverlaySystem\\FloatingElementFactory.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Floating element prefab '");
					messageBuilder.AppendFormatted(prefabName);
					messageBuilder.AppendLiteral("' not found");
				}
				Log.Error(messageBuilder);
				return null;
			}
			GameObject gameObject = Object.Instantiate(byAddress, holder.transform, worldPositionStays: false);
			gameObject.SetActive(value: false);
			T val = gameObject.GetComponent<T>();
			if (val == null)
			{
				val = gameObject.GetComponentInChildren<T>();
			}
			val.LocalPosOverride = localPosOverride;
			holder.AddElement(val);
			return val;
		}
	}
}
