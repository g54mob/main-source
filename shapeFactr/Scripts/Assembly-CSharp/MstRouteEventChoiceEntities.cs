using System;
using System.Collections.Generic;

[Serializable]
public class MstRouteEventChoiceEntities
{
	public eRouteEventChoice id;

	public string choiceTitle;

	public float probability;

	public List<string> cost;

	public int successEvent;

	public bool turnPage;

	public string successDesc;

	public eUpgradeKind successKind1;

	public List<string> successParam1;

	public eUpgradeKind successKind2;

	public List<string> successParam2;

	public eSoundGroupId successAudio;

	public int failureEvent;

	public string failureDesc;

	public eUpgradeKind failureKind1;

	public List<string> failureParam1;

	public eUpgradeKind failureKind2;

	public List<string> failureParam2;

	public eSoundGroupId failureAudio;
}
