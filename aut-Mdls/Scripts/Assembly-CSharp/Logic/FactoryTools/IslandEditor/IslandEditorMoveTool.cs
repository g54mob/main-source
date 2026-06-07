using Data.FactoryFloor;
using UnityEngine;

namespace Logic.FactoryTools.IslandEditor
{
	[CreateAssetMenu(menuName = "Factory/Tools/Islands/MoveTool", fileName = "IslandEditorMoveTool", order = 0)]
	public class IslandEditorMoveTool : MoveTool
	{
		protected override bool CanSelectFactoryObject(FactoryObject factoryObject, bool isSingle)
		{
			return true;
		}
	}
}
