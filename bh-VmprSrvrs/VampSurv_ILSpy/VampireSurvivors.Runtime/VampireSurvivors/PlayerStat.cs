using System;
using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;

namespace VampireSurvivors;

[Serializable]
public class PlayerStat
{
	public PowerUpType _Type;

	public int _Level;

	public List<PowerUpData> _Data;

	private double _value;

	public const float BASE_MARKUP = 0.1f;
}
