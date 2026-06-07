using System;
using System.Collections.Generic;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class OnlineFeaturesDecisionWindow3DUIView : SimpleDecisionWindow3DUIView
	{
		[SerializeField]
		private BaseInteractable3DUIView _playOnlineButton;

		[SerializeField]
		private BaseInteractable3DUIView _playOfflineButton;

		[SerializeField]
		private TextMeshProUGUII18n _onlineFeaturesText;

		[SerializeField]
		private List<Animator> _featureAnimators;

		protected override void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Closed()
		{
		}

		private void OnButtonHoverChanged(object sender, EventArgs<bool> e)
		{
		}

		protected override void OnDecisionInvoked(Action action)
		{
		}
	}
}
