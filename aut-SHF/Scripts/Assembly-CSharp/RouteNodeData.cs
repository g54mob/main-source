using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

[Serializable]
public class RouteNodeData
{
	public eRouteEvent nodeType;

	[Label("優先順位")]
	[Tooltip("現在は優先度が重みになっている。(大きいほどでやすい)")]
	public int priority;

	[Label("除外wave数")]
	[Tooltip("入力した値のwave終了後の報酬で出現しないようになる。例えば1wave終了報酬にショップが出てきてもなにもできないなどの防止")]
	public List<int> ignoreWave;
}
