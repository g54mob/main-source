using System.Collections.Generic;
using Gh.Tk.UI;
using Gh.Tk.UI.Dialogs;
using Gh.UI;
using UnityEngine;

namespace Gh.Tk
{
	public class UserHandbook3DUIView : ShowHideAnimation3DUIView
	{
		[SerializeField]
		private List<Button3DUIView> _closeButtons;

		[SerializeField]
		private ContentBlockLayout _contentBlockLayout;

		[SerializeField]
		private Container3DUIView _topicButtonContainer;

		[SerializeField]
		private Container3DUIView _contentContainer;

		[SerializeField]
		private ScrollableUIView _scrollableUIView;

		[SerializeField]
		private BoxColliderResizer _topicColliderResizer;

		[SerializeField]
		private DissolveArea3DUIView _dissolveController;

		private Dictionary<string, Button3DUIView> _topicButtons;

		[SerializeField]
		private GameObject _topicButtonPrefab;

		public float maxContentWidth;

		[SerializeField]
		[Header("Handbook Topic Settings")]
		private string[] _handbookDisplayOrder;

		private bool _topicsInitialized;

		private static readonly int _speedHash;

		private bool _gameWasPaused;

		private List<string> _availableTopics;

		private string _currentTopicId;

		protected override void Awake()
		{
		}

		protected override void OnEnable()
		{
		}

		private void OnCurrentProfileChanged(object sender, EventArgs<PlayerProfile> e)
		{
		}

		public void PopulateTopics()
		{
		}

		private void OnHandbookTopicAdded(object sender, EventArgs<string> e)
		{
		}

		private void AddTopicButton(string codexId, bool updateLayout = true)
		{
		}

		private void UpdateTopicButtonLayout()
		{
		}

		private void UpdateSelectedTopicButton()
		{
		}

		public void Open(string codexId, string headerLine = null)
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		public override void Open(ShowHideAnimationSpeed speed)
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void ShowTopic(string codexId, string headerLine = null)
		{
		}

		[ContextMenu("Update Dissolve Materials")]
		private void UpdateDissolveMaterials()
		{
		}

		private void UpdateTextDissolves()
		{
		}

		public void ScrollToHeader(string headerLine)
		{
		}
	}
}
