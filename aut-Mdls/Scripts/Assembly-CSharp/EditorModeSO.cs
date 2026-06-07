using Data.FactoryFloor;
using Data.FactoryFloor.GameMode;
using Logic.Factory;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Factory/LevelEditorMode", fileName = "LevelEditorMode", order = 0)]
public class EditorModeSO : GameModeSO
{
	[SerializeField]
	[Required(null)]
	private FactoryLayer _terrainLayer;

	[SerializeField]
	[Required(null)]
	private CurrentFactoryLayer _currentFactoryLayer;

	public override void Init()
	{
		_currentFactoryLayer.SetFactoryLayer(_terrainLayer);
	}
}
