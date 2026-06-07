using System;
using TMPro;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class BlockingPopup : BasePopup
	{
		[SerializeField]
		private TextMeshProUGUI _Title;

		[SerializeField]
		private TextMeshProUGUI _Description;

		[SerializeField]
		private UISpriteAnimation _AnimLeft;

		[SerializeField]
		private UISpriteAnimation _AnimRight;

		private Action _onClose;

		private DataManager _data;

		private PlayerOptions _playerOptions;

		[Inject]
		private void Construct(DataManager data, PlayerOptions player)
		{
		}

		public virtual void Initialize(string id, string title, string description, Action onClose = null)
		{
		}

		public override void Hide()
		{
		}

		public void UpdateDescriptionText(string newDescription)
		{
		}

		private void OnDestroy()
		{
		}

		private void SetAnimation()
		{
		}
	}
}
