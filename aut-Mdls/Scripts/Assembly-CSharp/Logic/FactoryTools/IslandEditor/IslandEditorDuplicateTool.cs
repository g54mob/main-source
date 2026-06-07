using Data.FactoryFloor;
using UnityEngine;

namespace Logic.FactoryTools.IslandEditor
{
	[CreateAssetMenu(menuName = "Factory/Tools/Islands/DuplicateTool", fileName = "IslandEditorDuplicateTool", order = 0)]
	public class IslandEditorDuplicateTool : DuplicateTool
	{
		protected override bool CanSelectFactoryObject(FactoryObject factoryObject, bool isSingle)
		{
			return true;
		}
	}
}
