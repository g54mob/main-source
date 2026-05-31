using UnityEngine;

public class GarbageInfo
{
	public enum GarbageTypeEnum
	{
		GarbageS = 0,
		GarbageM = 1,
		GarbageL = 2,
		GarbageXL = 3,
		ShardBlue = 4,
		ShardRed = 5,
		ShardYellow = 6,
		Book = 7,
		Golem = 8
	}

	public enum CameFromEnum
	{
		None = 0,
		Catapult = 1,
		Compressor = 2,
		Drone = 3,
		Helicopter = 4,
		Balloon = 5,
		House = 6,
		Industry = 7,
		Power = 8,
		Research = 9,
		Store = 10,
		Temple = 11,
		Training = 12,
		Cloud = 13,
		Rock = 14,
		Compressed = 15
	}

	public const int GARBAGE_S_FILL = 1;

	public const int GARBAGE_M_FILL = 5;

	public const int GARBAGE_L_FILL = 25;

	public const int GARBAGE_XL_FILL = 125;

	public static Color CATAPULT_COLOR = new Color(0.41796875f, 19f / 128f, 1f / 64f);

	public static Color COMPRESSOR_COLOR = new Color(0.99609375f, 0.64453125f, 0f);

	public static Color DRONE_COLOR = new Color(0.99609375f, 0.87109375f, 0f);

	public static Color HELICOPTER_COLOR = new Color(17f / 128f, 0.54296875f, 17f / 128f);

	public static Color BALLOON_COLOR = new Color(0f, 0f, 0.99609375f);

	public static Color HOUSE_COLOR = new Color(0.5f, 0f, 0.5f);

	public static Color INDUSTRY_COLOR = new Color(25f / 128f, 0.80078125f, 25f / 128f);

	public static Color POWER_COLOR = new Color(0f, 0.99609375f, 0.99609375f);

	public static Color RESEARCH_COLOR = new Color(0.99609375f, 0.41015625f, 45f / 64f);

	public static Color STORE_COLOR = new Color(0f, 0.5f, 0.5f);

	public static Color TEMPLE_COLOR = new Color(0.99609375f, 0f, 0.99609375f);

	public static Color TRAINING_COLOR = new Color(0f, 0f, 0.5f);

	public static Color CLOUD_COLOR = Color.magenta;

	public static Color ROCK_COLOR = Color.cyan;

	public static Color ZAP_COLOR = Color.gray;

	private GarbageTypeEnum _garbageType;

	private CameFromEnum _cameFrom;

	private int _weight = 1;

	private bool _isEvil;

	private bool _isZap;

	private Color _color;

	public GarbageTypeEnum GarbageType => _garbageType;

	public CameFromEnum CameFrom => _cameFrom;

	public int Weight => _weight;

	public bool IsEvil => _isEvil;

	public Color CurColor => _color;

	public bool IsGarbage
	{
		get
		{
			if (GarbageType == GarbageTypeEnum.GarbageS || GarbageType == GarbageTypeEnum.GarbageM || GarbageType == GarbageTypeEnum.GarbageL || GarbageType == GarbageTypeEnum.GarbageXL)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsShard
	{
		get
		{
			if (GarbageType == GarbageTypeEnum.ShardBlue || GarbageType == GarbageTypeEnum.ShardRed || GarbageType == GarbageTypeEnum.ShardYellow)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsBook
	{
		get
		{
			if (GarbageType == GarbageTypeEnum.Book)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsZap => _isZap;

	public GarbageInfo()
	{
	}

	public GarbageInfo(int weight, GarbageTypeEnum type, CameFromEnum cameFrom, bool isEvil)
	{
		_weight = weight;
		_garbageType = type;
		_cameFrom = cameFrom;
		_isEvil = isEvil;
		_isZap = false;
		CalculateColor();
	}

	public GarbageInfo(GarbageInfo info)
	{
		_weight = info.Weight;
		_garbageType = info.GarbageType;
		_cameFrom = info.CameFrom;
		_isEvil = info.IsEvil;
		_isZap = info.IsZap;
		CalculateColor();
	}

	public void SetAsZap()
	{
		if (!_isZap)
		{
			_weight *= 2;
			_isZap = true;
			CalculateColor();
		}
	}

	public void ForceDoubleValue()
	{
		_weight *= 2;
		CalculateColor();
	}

	public void ForceZap()
	{
		if (!_isZap)
		{
			_isZap = true;
			CalculateColor();
		}
	}

	public int GetSize()
	{
		if (GarbageType == GarbageTypeEnum.GarbageS)
		{
			return 1;
		}
		if (GarbageType == GarbageTypeEnum.GarbageM)
		{
			return 5;
		}
		if (GarbageType == GarbageTypeEnum.GarbageL)
		{
			return 25;
		}
		if (GarbageType == GarbageTypeEnum.GarbageXL)
		{
			return 125;
		}
		return 0;
	}

	private Color GetMainColor()
	{
		if (IsZap)
		{
			return ZAP_COLOR;
		}
		return CameFrom switch
		{
			CameFromEnum.Catapult => CATAPULT_COLOR, 
			CameFromEnum.Compressor => COMPRESSOR_COLOR, 
			CameFromEnum.Compressed => COMPRESSOR_COLOR, 
			CameFromEnum.Drone => DRONE_COLOR, 
			CameFromEnum.Helicopter => HELICOPTER_COLOR, 
			CameFromEnum.Balloon => BALLOON_COLOR, 
			CameFromEnum.House => HOUSE_COLOR, 
			CameFromEnum.Industry => INDUSTRY_COLOR, 
			CameFromEnum.Power => POWER_COLOR, 
			CameFromEnum.Research => RESEARCH_COLOR, 
			CameFromEnum.Store => STORE_COLOR, 
			CameFromEnum.Temple => TEMPLE_COLOR, 
			CameFromEnum.Training => TRAINING_COLOR, 
			CameFromEnum.Cloud => CLOUD_COLOR, 
			CameFromEnum.Rock => ROCK_COLOR, 
			_ => Color.white, 
		};
	}

	private void CalculateColor()
	{
		Color white = Color.white;
		Color mainColor = GetMainColor();
		if (!IsGarbage)
		{
			_color = Color.white;
			return;
		}
		if (IsZap)
		{
			_color = mainColor;
			return;
		}
		float num = 10f;
		if (GarbageType == GarbageTypeEnum.GarbageM)
		{
			num = 50f;
		}
		else if (GarbageType == GarbageTypeEnum.GarbageL)
		{
			num = 250f;
		}
		else if (GarbageType == GarbageTypeEnum.GarbageXL)
		{
			num = 1250f;
		}
		if ((float)Weight >= num + 1f)
		{
			_color = mainColor;
			return;
		}
		if (Weight <= 1)
		{
			_color = white;
			return;
		}
		float num2 = (float)(Weight - 1) / num;
		if (num2 > 1f)
		{
			num2 = 1f;
		}
		_color = new Color(white.r + (mainColor.r - white.r) * num2, white.g + (mainColor.g - white.g) * num2, white.b + (mainColor.b - white.b) * num2);
	}
}
