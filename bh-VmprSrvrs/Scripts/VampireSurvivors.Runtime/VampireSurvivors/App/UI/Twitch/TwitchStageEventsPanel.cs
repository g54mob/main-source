using TMPro;
using UnityEngine;
using VampireSurvivors.App.Scripts.Objects.VFX;

namespace VampireSurvivors.App.UI.Twitch
{
	public class TwitchStageEventsPanel : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup _CanvasGroup;

		[SerializeField]
		private CanvasGroup _UsernamesCanvasGroup;

		[SerializeField]
		private TextMeshProUGUI _Text1;

		[SerializeField]
		private TextMeshProUGUI _Text2;

		[SerializeField]
		private TextMeshProUGUI _Text3;

		[SerializeField]
		private TextMeshProUGUI _Option1;

		[SerializeField]
		private TextMeshProUGUI _Option2;

		[SerializeField]
		private TextMeshProUGUI _Option3;

		[SerializeField]
		private TwitchUsername _TwitchUsernamePrefab;

		[SerializeField]
		private Transform _TwitchUsernamesRoot;

		private RectTransform _rectTransform;

		private Vector2? _defaultAnchoredPos;

		private Vector2? _hideAnchorPos;

		public TextMeshProUGUI Text1 => null;

		public TextMeshProUGUI Text2 => null;

		public TextMeshProUGUI Text3 => null;

		public TextMeshProUGUI Option1 => null;

		public TextMeshProUGUI Option2 => null;

		public TextMeshProUGUI Option3 => null;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		public void AnimatePanelIn()
		{
		}

		public void AnimatePanelOut()
		{
		}

		public void QuickShow()
		{
		}

		public void QuickHide()
		{
		}

		public void ShowUsernameAt(Vector3 usernameGizmoPos, string username)
		{
		}

		private void CacheDefaultPosition()
		{
		}

		private void EditorShowRandomUsername(int num)
		{
		}
	}
}
