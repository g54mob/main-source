using Data.FactoryFloor;
using UnityEngine;

namespace Logic.FactoryTools.IslandEditor
{
	[CreateAssetMenu(menuName = "Factory/Tools/Islands/DeleteTool", fileName = "IslandEditorDeleteTool", order = 0)]
	public class IslandEditorDeleteTool : DeleteTool
	{
		protected override bool CanSelectFactoryObject(FactoryObject factoryObject, bool isSingle)
		{
			return true;
		}
	}
}
