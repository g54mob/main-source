using System;
using System.Collections.Generic;

[Serializable]
public class MstGameActionEntities
{
	public eGameAction id;

	public string name;

	public eGameActionInputType inputType;

	public string actionMap;

	public string action;

	public List<int> bindingIndexes;

	public string actionMap2;

	public string action2;

	public List<int> bindingIndexes2;

	public bool isHidden;

	public bool selectLR;

	public bool selectMoveType;
}
