using System;
using System.Collections.Generic;

[Serializable]
public class MstLuggageDataEntities : ICommonEntiies
{
	public eLuggage id;

	public int sortNum;

	public string name;

	public eLuggageKind kind;

	public List<eLuggageTag> luggageTag;

	public eResearchPointKind getReserchPointKind;

	public int getReserchPoint;

	public int exp;

	public List<eLuggage> unlockIds;

	public List<int> unlockNums;

	public List<eResearchTreeId> unlockResearchs;

	public bool isHidden;

	public bool isTrial;

	public bool isEarly;

	public bool isShop;

	public string addressablePath;

	public string statueAddressablePath;

	public string Name => null;

	public string Desc => null;

	public string IconPath => null;

	public string GifPath => null;

	public override string ToString()
	{
		return null;
	}
}
