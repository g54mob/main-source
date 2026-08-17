using Cpp2ILInjected;

namespace VampireSurvivors.Framework.Geom;

public class Line : BaseGeom
{
	private float _x1;

	private float _y1;

	private float _x2;

	private float _y2;

	public float Left
	{
		get
		{
			float result = _x1;
			if (_x1 > _x2)
			{
				result = _x2;
			}
			return result;
		}
	}

	public float Right
	{
		get
		{
			float result = _x1;
			if (_x1 < _x2)
			{
				result = _x2;
			}
			return result;
		}
	}

	public float Top
	{
		get
		{
			float result = _y1;
			if (_y1 < _y2)
			{
				result = _y2;
			}
			return result;
		}
	}

	public float Bottom
	{
		get
		{
			float result = _y1;
			if (_y1 > _y2)
			{
				result = _y2;
			}
			return result;
		}
	}

	public float Length
	{
		get
		{
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Expected F4, but got Unknown
			float num = _x1;
			if (_x1 < _x2)
			{
				num = _x2;
			}
			float num2 = _x1;
			if (_x1 > _x2)
			{
				num2 = _x2;
			}
			float num3 = num - num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			return num3 & 0;
		}
	}

	public Line(float x1, float y1, float x2, float y2)
	{
		float y3 = default(float);
		_y2 = y3;
		_x1 = x1;
		_y1 = y1;
		_x2 = x2;
	}
}
