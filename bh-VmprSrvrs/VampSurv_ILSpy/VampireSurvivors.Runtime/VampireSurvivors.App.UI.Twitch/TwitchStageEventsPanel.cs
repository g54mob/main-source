using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Scripts.Objects.VFX;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;

namespace VampireSurvivors.App.UI.Twitch;

public class TwitchStageEventsPanel : MonoBehaviour
{
	private CanvasGroup _CanvasGroup;

	private CanvasGroup _UsernamesCanvasGroup;

	private TextMeshProUGUI _Text1;

	private TextMeshProUGUI _Text2;

	private TextMeshProUGUI _Text3;

	private TextMeshProUGUI _Option1;

	private TextMeshProUGUI _Option2;

	private TextMeshProUGUI _Option3;

	private TwitchUsername _TwitchUsernamePrefab;

	private Transform _TwitchUsernamesRoot;

	private RectTransform _rectTransform;

	private Vector2? _defaultAnchoredPos;

	private Vector2? _hideAnchorPos;

	public TextMeshProUGUI Text1 => _Text1;

	public TextMeshProUGUI Text2 => _Text2;

	public TextMeshProUGUI Text3 => _Text3;

	public TextMeshProUGUI Option1 => _Option1;

	public TextMeshProUGUI Option2 => _Option2;

	public TextMeshProUGUI Option3 => _Option3;

	private void Awake()
	{
		RectTransform component = GetComponent<RectTransform>();
		_rectTransform = component;
		Vector2 anchoredPosition = _rectTransform.anchoredPosition;
		Vector2? defaultAnchoredPos = default(Vector2?);
		_defaultAnchoredPos = defaultAnchoredPos;
		_CanvasGroup.alpha = 0f;
	}

	private void Start()
	{
		GameManager core = GM.Core;
		RectTransform component = core._003CMainUI_003Ek__BackingField.GetComponent<RectTransform>();
		Vector3[] fourCornersArray = new Vector3[4];
		component.GetWorldCorners(fourCornersArray);
		Vector2 sizeDelta = _rectTransform.sizeDelta;
		Vector2 anchoredPosition = _rectTransform.anchoredPosition;
		Vector2 vector = default(Vector2);
		_hideAnchorPos = vector;
		if ((object)_hideAnchorPos != null)
		{
			_rectTransform.anchoredPosition = vector;
		}
	}

	private void OnEnable()
	{
		if ((object)_hideAnchorPos != null)
		{
			Vector2 anchoredPosition = default(Vector2);
			_rectTransform.anchoredPosition = anchoredPosition;
		}
	}

	public void AnimatePanelIn()
	{
		if ((object)_defaultAnchoredPos == null)
		{
			return;
		}
		Vector2 endValue = default(Vector2);
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(_rectTransform, endValue, 0.15f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_CanvasGroup, 0.65f, 0.15f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
	}

	public void AnimatePanelOut()
	{
		if ((object)_hideAnchorPos == null)
		{
			return;
		}
		Vector2 endValue = default(Vector2);
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(_rectTransform, endValue, 0.15f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_CanvasGroup, 0f, 0.15f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
	}

	public void QuickShow()
	{
		_CanvasGroup.alpha = 0.65f;
		_UsernamesCanvasGroup.alpha = 1f;
	}

	public void QuickHide()
	{
		_CanvasGroup.alpha = 0f;
		_UsernamesCanvasGroup.alpha = 0f;
	}

	public void ShowUsernameAt(Vector3 usernameGizmoPos, string username)
	{
		TwitchUsername twitchUsername = Object.Instantiate(_TwitchUsernamePrefab, _TwitchUsernamesRoot);
		Vector2 spawnPos = default(Vector2);
		twitchUsername.Init(username, spawnPos);
	}

	private void CacheDefaultPosition()
	{
		GameManager core = GM.Core;
		RectTransform component = core._003CMainUI_003Ek__BackingField.GetComponent<RectTransform>();
		Vector3[] fourCornersArray = new Vector3[4];
		component.GetWorldCorners(fourCornersArray);
		Vector2 sizeDelta = _rectTransform.sizeDelta;
		Vector2 anchoredPosition = _rectTransform.anchoredPosition;
		Vector2? hideAnchorPos = default(Vector2?);
		_hideAnchorPos = hideAnchorPos;
	}

	private unsafe void EditorShowRandomUsername(int num)
	{
		//IL_0013: Expected O, but got I4
		//IL_009c: Expected O, but got Ref
		bool flag = num == 0;
		Component component;
		if (!flag)
		{
			object obj = num - 1;
			if (!flag)
			{
				if ((nint)obj != 1)
				{
					return;
				}
				component = _Option3;
			}
			else
			{
				component = _Option2;
			}
		}
		else
		{
			component = _Option1;
		}
		RectTransform component2 = component.GetComponent<RectTransform>();
		Rect worldRect = VampireSurvivors.App.Tools.Extensions.GetWorldRect(component2);
		object obj2 = default(object);
		ShowUsernameAt((Vector3)(&obj2), "Adam");
	}

	public TwitchStageEventsPanel()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
