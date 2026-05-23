using System;
using System.Collections.Generic;

[Serializable]
public class MstRouteEventDataEntities
{
	public int id;

	public eRouteEvent routeEvent;

	public string name;

	public string desc;

	public List<eStageDivision> division;

	public List<eRouteEventChoice> choices;

	public bool isHidden;

	public bool isSub;

	public string eventImagePath;
}
