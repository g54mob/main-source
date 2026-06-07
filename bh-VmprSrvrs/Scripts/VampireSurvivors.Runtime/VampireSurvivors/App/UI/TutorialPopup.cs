using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Objects;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors.App.UI
{
	public class TutorialPopup : BasePopup
	{
		public delegate void OnOkButtonClicked();

		[CompilerGenerated]
		private sealed class _003CWaitAndSelect_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TutorialPopup _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitAndSelect_003Ed__15(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private Button _OkButton;

		[SerializeField]
		private RectTransform _Panel;

		[SerializeField]
		private TextMeshProUGUI _TitleText;

		[SerializeField]
		private TextMeshProUGUI _DescriptionText;

		private PlayerOptions _playerOptions;

		private Selectable _previousSelection;

		public event OnOkButtonClicked OKButtonClicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Inject]
		private void Construct(PlayerOptions playerOptions)
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void Initialize(string id, string titleTerm, string descriptionTerm, string buttonTerm)
		{
		}

		public override void Show()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndSelect_003Ed__15))]
		private IEnumerator WaitAndSelect()
		{
			return null;
		}

		public override void Hide()
		{
		}
	}
}
