using Loxodon.Framework.Contexts;
using Player.Animations;
using Player.Arms;
using UnityEngine;
using Zenject;

namespace Player
{
	public class PlayerToolView : MonoBehaviour, IPlayerToolView
	{
		[SerializeField]
		private Transform _toolHolder;

		[Inject]
		private IPlayerEquipService _playerEquipToolService;

		private PlayerArmsViewModel _playerArmsViewModel;

		private ArmsAnimator _armsAnimator;

		private void Start()
		{
			_playerArmsViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<PlayerArmsViewModel>();
			_armsAnimator = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<ArmsAnimator>();
		}

		void IPlayerToolView.SetToolObject(ToolObject tool)
		{
			_armsAnimator.StartDrinkingAnimation();
			switch (tool.HandedView)
			{
			case HandedViewObject.RedDrill:
				_playerArmsViewModel.DrillEnabled = true;
				break;
			case HandedViewObject.MetalSpanner:
				_playerArmsViewModel.SpannerEnabled = true;
				break;
			case HandedViewObject.YellowScrew:
				_playerArmsViewModel.ScrewEnabled = true;
				break;
			case HandedViewObject.MetalRatchet:
				_playerArmsViewModel.RatchetEnabled = true;
				break;
			case HandedViewObject.GasCan:
				_playerArmsViewModel.CanisterEnabled = true;
				break;
			case HandedViewObject.FlareGun:
				_playerArmsViewModel.FlareGunEnabled = true;
				break;
			}
		}

		void IPlayerToolView.ClearToolObject()
		{
			_armsAnimator.StopDrinkingAnimation();
			_playerArmsViewModel.SpannerEnabled = false;
			_playerArmsViewModel.DrillEnabled = false;
			_playerArmsViewModel.ScrewEnabled = false;
			_playerArmsViewModel.RatchetEnabled = false;
			_playerArmsViewModel.CanisterEnabled = false;
			_playerArmsViewModel.FlareGunEnabled = false;
		}
	}
}
