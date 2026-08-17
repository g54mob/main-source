using System;

namespace VampireSurvivors.Framework.PhaserTweens;

public class CachedCustomField
{
	public Func<object, object> getter;

	public Action<object, object> setter;

	public Type type;
}
