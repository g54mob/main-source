using Assets.Scripts.UI;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class ResizeOnLocalization : MonoBehaviour
{
	public Transform rebuildTransform;

	public LocalizeStringEvent localizeStringEvent;

	public TextSizer textSizer;

	public ButtonTextWrapper buttonTextWrapper;

	private bool expectingRebuild;

	private bool expectingRefresh;

	private void Start()
	{
		if (this.localizeStringEvent != null)
		{
			LocalizeStringEvent localizeStringEvent = this.localizeStringEvent;
			LocalizedString.ChangeHandler value = OnLocalizedStringChanged;
			localizeStringEvent.m_StringReference.StringChanged += value;
		}
	}

	private void OnDestroy()
	{
		if (this.localizeStringEvent != null)
		{
			LocalizeStringEvent localizeStringEvent = this.localizeStringEvent;
			LocalizedString.ChangeHandler value = OnLocalizedStringChanged;
			localizeStringEvent.m_StringReference.StringChanged -= value;
		}
	}

	private void OnEnable()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317303B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (expectingRebuild)
		{
			Invoke("Rebuild", 0f);
		}
		if (expectingRefresh)
		{
			Invoke("DelayedRefresh", 0f);
		}
	}

	private void OnLocalizedStringChanged(string updatedString)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317303C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Invoke("DelayedRefresh", 0f);
		GameObject gameObject = base.gameObject;
		if (!gameObject.activeInHierarchy)
		{
			expectingRefresh = true;
		}
	}

	private void DelayedRefresh()
	{
		if (textSizer != null)
		{
			textSizer.Refresh();
			textSizer.Recalculate();
		}
		if (buttonTextWrapper != null)
		{
			buttonTextWrapper.Refresh();
		}
		if (rebuildTransform != null)
		{
			GameObject gameObject = base.gameObject;
			if (gameObject.activeInHierarchy)
			{
				Invoke("Rebuild", 0f);
			}
			else
			{
				expectingRebuild = true;
			}
		}
	}

	private void Rebuild()
	{
		expectingRebuild = false;
		UiUtility.RebuildUi(rebuildTransform);
	}

	private void OnValidate()
	{
		if (localizeStringEvent == null)
		{
			LocalizeStringEvent componentInChildren = GetComponentInChildren<LocalizeStringEvent>();
			localizeStringEvent = componentInChildren;
		}
		if (textSizer == null)
		{
			TextSizer componentInChildren2 = GetComponentInChildren<TextSizer>();
			textSizer = componentInChildren2;
		}
		if (buttonTextWrapper == null)
		{
			ButtonTextWrapper componentInChildren3 = GetComponentInChildren<ButtonTextWrapper>();
			buttonTextWrapper = componentInChildren3;
		}
	}
}
