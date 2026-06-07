using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class AdventureCompletedPopup : BasePopup
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndShow_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AdventureCompletedPopup _003C_003E4__this;

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
			public _003CWaitAndShow_003Ed__38(int _003C_003E1__state)
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
		private CanvasGroup _BackgroundFader;

		[SerializeField]
		private GameObject _Ray;

		[SerializeField]
		private RectTransform _RayContainer;

		[SerializeField]
		private RectTransform _IconContainer;

		[SerializeField]
		private List<ParticleSystem> _particles;

		[SerializeField]
		private RectTransform _TitleGroup;

		[SerializeField]
		private TextMeshProUGUI _MainTitle;

		[SerializeField]
		private TextMeshProUGUI _TitleFade1;

		[SerializeField]
		private TextMeshProUGUI _TitleFade2;

		[SerializeField]
		private CanvasGroup _IconCG;

		[SerializeField]
		private Image _DarkOverlay;

		[SerializeField]
		private CanvasGroup _Panel;

		[SerializeField]
		private TextMeshProUGUI _AdventureNameText;

		[SerializeField]
		private TextMeshProUGUI _RewardsText;

		[SerializeField]
		private RectTransform _RewardsPanel;

		[SerializeField]
		private CanvasGroup _RewardContent;

		[SerializeField]
		private CanvasGroup _CoinRewardGroup;

		[SerializeField]
		private CanvasGroup _StarRewardGroup;

		[SerializeField]
		private CanvasGroup _SkinRewardGroup;

		[SerializeField]
		private TextMeshProUGUI _CoinRewardText;

		[SerializeField]
		private TextMeshProUGUI _StarRewardText;

		[SerializeField]
		private Button _DoneButton;

		[SerializeField]
		private ParticleEmitterManager _ParticleEmitter;

		[SerializeField]
		private Image _SubtitleImage;

		[SerializeField]
		private RectTransform _SkinCarousel;

		private MainMenuBackgroundFactory _mainMenuFactory;

		private AdventureManager _adventureManager;

		private ParticleSystem _colorParticles;

		private List<GameObject> _rays;

		private List<Tween> _tweens;

		private GameObject _spawnedBackground;

		private AdventureType _currentAdventure;

		private DataManager _dataManager;

		private PlayerOptions _playerOptions;

		private List<SkinToUnlock> _skinsToUnlock;

		[Inject]
		private void Construct(MainMenuBackgroundFactory menu, AdventureManager adventure, DataManager dataManager, PlayerOptions playerOptions)
		{
		}

		private void DoShow()
		{
		}

		private void MakeColorParticles()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndShow_003Ed__38))]
		private IEnumerator WaitAndShow()
		{
			return null;
		}

		public override void Show()
		{
		}

		private void Reset()
		{
		}

		public override void Hide()
		{
		}

		public void Initialize(string id)
		{
		}

		private void SetAdventureBackground()
		{
		}

		private void PlayParticles(bool b)
		{
		}

		private void AddRays()
		{
		}

		private void ClearRays()
		{
		}

		private GameObject CreateRay(string color)
		{
			return null;
		}

		public static string colorToHex(Color32 color)
		{
			return null;
		}

		private static Color hexToColor(string hex)
		{
			return default(Color);
		}

		private Texture2D DuplicateTexture(Texture2D source)
		{
			return null;
		}

		public void SetSkins()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
