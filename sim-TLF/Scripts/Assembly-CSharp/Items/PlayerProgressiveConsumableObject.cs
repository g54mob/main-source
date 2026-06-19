using System.Collections.Generic;
using JSAM;
using Loxodon.Framework.Contexts;
using Player;
using Player.Arms;
using Player.FSM;
using UnityEngine;
using Zenject;

namespace Items
{
	[CreateAssetMenu(menuName = "Player Usable Object/Consumable/Progressive Consumable", fileName = "New Progressive Consumable")]
	public class PlayerProgressiveConsumableObject : PlayerConsumableObject
	{
		[SerializeField]
		private HandedViewObject _handedType;

		public List<SoundFileObject> EquipSounds;

		public List<SoundFileObject> UseSounds;

		public EquipSide SideConsuming;

		[Inject]
		private IPlayerConsumeService _playerConsumeService;

		private PlayerArmsViewModel _playerArmsViewModel;

		public void Resolve()
		{
			_playerArmsViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<PlayerArmsViewModel>();
		}

		public void Progress()
		{
			Debug.Log("CONSUMING " + base.name);
			_playerStatsService.AddModToAlcohol(AlcoholStatChanger);
			_playerStatsService.AddModToNicotine(NicotineStatChanger);
		}

		public override void Consume(UsableConsumableItem consumableItem)
		{
			_playerConsumeService.SetConsumingObject(SideConsuming, this);
			switch (_handedType)
			{
			case HandedViewObject.MetalCan:
				_playerArmsViewModel.MetalCanEnabled = true;
				break;
			case HandedViewObject.GlassBottle:
				_playerArmsViewModel.GlassBottleEnabled = true;
				break;
			}
			Debug.Log(_playerArmsViewModel.GlassBottleEnabled);
		}

		public override void TryUnuse()
		{
			_playerConsumeService.ClearObject(SideConsuming);
			switch (_handedType)
			{
			case HandedViewObject.MetalCan:
				_playerArmsViewModel.MetalCanEnabled = false;
				break;
			case HandedViewObject.GlassBottle:
				_playerArmsViewModel.GlassBottleEnabled = false;
				break;
			}
		}
	}
}
