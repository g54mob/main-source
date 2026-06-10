using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace NSMedieval.UI
{
	public abstract class UIView : NSEipix.Base.View
	{
		private Action<Vector3, bool> cameraCenterAction;

		private Action<Transform> cameraFollowAction;

		private LocalizationController localize;

		private SceneUIManager sceneUIManager;

		[NonSerialized]
		private List<AssetReference> assetReferences = new List<AssetReference>();

		public bool IsVisible => base.gameObject.activeInHierarchy;

		protected virtual bool AddToClosables => true;

		public SceneUIManager SceneUIManager
		{
			get
			{
				if (sceneUIManager == null)
				{
					sceneUIManager = GetComponentInParent<SceneUIManager>();
				}
				return sceneUIManager;
			}
		}

		protected Action<Vector3, bool> CameraCenterAction
		{
			get
			{
				Action<Vector3, bool> obj = cameraCenterAction ?? new Action<Vector3, bool>(MonoSingleton<RtsCamera>.Instance.JumpTo);
				Action<Vector3, bool> result = obj;
				cameraCenterAction = obj;
				return result;
			}
		}

		protected Action<Transform> CameraFollowAction
		{
			get
			{
				Action<Transform> obj = cameraFollowAction ?? new Action<Transform>(MonoSingleton<RtsCamera>.Instance.JumpToAndFollow);
				Action<Transform> result = obj;
				cameraFollowAction = obj;
				return result;
			}
		}

		protected LocalizationController Localize
		{
			get
			{
				if (localize == null)
				{
					localize = MonoSingleton<LocalizationController>.Instance;
				}
				return localize;
			}
		}

		protected virtual void OnDestroy()
		{
			if (AddToClosables && MonoSingleton<UIClosableController>.IsInstantiated())
			{
				MonoSingleton<UIClosableController>.Instance.RemoveFromClosables(this);
			}
			foreach (AssetReference assetReference in assetReferences)
			{
				if (assetReference != null && assetReference.IsValid())
				{
					assetReference.ReleaseAsset();
				}
			}
			assetReferences.Clear();
			cameraCenterAction = null;
			cameraFollowAction = null;
			localize = null;
			sceneUIManager = null;
		}

		protected void AddReferenceCallback(AssetReference newReference)
		{
			assetReferences.Add(newReference);
		}

		public virtual void Show()
		{
			base.gameObject.SetActive(value: true);
			if (AddToClosables && MonoSingleton<UIClosableController>.IsInstantiated())
			{
				MonoSingleton<UIClosableController>.Instance.AddToClosables(this);
			}
			if (MonoSingleton<AnalyticsManager>.IsInstantiated() && !string.IsNullOrEmpty(base.name))
			{
				MonoSingleton<AnalyticsManager>.Instance.OnScreenVisit(base.name);
			}
		}

		protected virtual Task LoadAssets()
		{
			return Task.CompletedTask;
		}

		public virtual void Hide()
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(11, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\UIView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Hide: body=");
				messageBuilder.AppendFormatted(GetType().Name);
			}
			Log.Debug(messageBuilder);
			if (MonoSingleton<UIClosableController>.IsInstantiated() && !(this == null) && !(base.gameObject == null))
			{
				if (AddToClosables)
				{
					MonoSingleton<UIClosableController>.Instance.RemoveFromClosables(this);
				}
				base.gameObject.SetActive(value: false);
			}
		}

		protected static void SetText(TMP_Text textFiled, string textKey, string text)
		{
			textFiled.SetText(text);
		}

		protected static void SetText(TMP_Text textFiled, string textKey, string text, HumanoidInstance humanoid)
		{
			textFiled.SetText(text);
			CreatureBaseTooltipView component = textFiled.gameObject.GetComponent<CreatureBaseTooltipView>();
			if (!(component == null))
			{
				component.SetTooltipData(textKey, humanoid);
			}
		}
	}
}
