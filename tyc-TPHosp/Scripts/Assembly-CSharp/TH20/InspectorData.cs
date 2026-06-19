using UnityEngine;

namespace TH20
{
	public abstract class InspectorData : MustCallDestroy
	{
		protected Level Level;

		protected InspectorMenu Owner;

		protected InspectorMenuAssetReference AssetReference;

		protected InspectorData(InspectorMenu owner, Level level, InspectorMenuAssetReference assetReference)
		{
			Owner = owner;
			Level = level;
			AssetReference = assetReference;
		}

		public virtual void Update()
		{
		}

		public abstract string GetHeaderTitle();

		public abstract string GetUserSpecifiedNameEditButtonTooltip();

		public abstract void SetUserSpecifiedName(string userSpecifiedName);

		public abstract string GetUserSpecifiedName();

		public abstract Texture GetHeaderPolaroidTexture();

		public abstract Sprite GetHeaderIcon();

		public abstract bool UsePolaroidBacking();

		public abstract int GetTabCount();

		public abstract int GetDefaultTabIndex();

		public abstract string GetTabText(int tabIndex);

		public abstract bool IsTabEnabled(int tabIndex);

		public abstract void OnTabSelected(int tabIndex);

		public abstract void OnCycleLeftPressed();

		public abstract void OnCycleRightPressed();

		public abstract void OnGoToPressed();

		public abstract GameObject GetBodyPrefab(int tabIndex);

		public abstract int GetFooterButtonCount();

		public abstract Sprite GetFooterButtonImage(int buttonIndex);

		public abstract bool IsFooterButtonVisible(int buttonIndex);

		public abstract bool IsFooterButtonEnabled(int buttonIndex);

		public abstract void OnFooterButtonPressed(int buttonIndex);

		public abstract string GetFooterButtonTooltip(int buttonIndex);

		public abstract string GetFooterButtonNotVisibleTooltip(int buttonIndex);

		public abstract int GetFooterButtonNotificationCount(int buttonIndex);

		public virtual bool UsesSmallFooter()
		{
			return false;
		}

		public virtual string GetFooterButtonText(int buttonIndex)
		{
			return string.Empty;
		}

		public virtual bool UsesSmallFooterExtra()
		{
			return false;
		}

		public virtual int GetSmallFooterExtraButtonCount()
		{
			return 0;
		}

		public virtual bool IsSmallFooterExtraButtonVisible(int buttonIndex)
		{
			return false;
		}

		public virtual bool IsSmallFooterExtraButtonEnabled(int buttonIndex)
		{
			return false;
		}

		public virtual bool OnSmallFooterExtraButtonPressed(int buttonIndex)
		{
			return false;
		}

		public virtual Sprite GetSmallFooterExtraImage(int buttonIndex)
		{
			return null;
		}

		public virtual string GetSmallFooterExtraText(int buttonIndex)
		{
			return string.Empty;
		}

		public virtual string GetSmallFooterExtraTooltip(int buttonIndex)
		{
			return string.Empty;
		}
	}
}
