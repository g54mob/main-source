using Data.FactoryFloor;
using Data.FactoryFloor.GameMode;
using Logic.Factory;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Factory/CampaignMode", fileName = "CampaignMode", order = 0)]
public class CampaignModeSO : GameModeSO
{
	[SerializeField]
	[Required(null)]
	private FactoryLayer _factoryLayer;

	[SerializeField]
	[Required(null)]
	private CurrentFactoryLayer _currentFactoryLayer;

	public override void Init()
	{
		_currentFactoryLayer.SetFactoryLayer(_factoryLayer);
	}
}
