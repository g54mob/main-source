using UnityEngine;

namespace Coffee.UIEffects;

public struct Matrix2x3
{
	public float m00;

	public float m01;

	public float m02;

	public float m10;

	public float m11;

	public float m12;

	public Matrix2x3(Rect rect, float cos, float sin)
	{
		//IL_0013: Expected O, but got F4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0048: Expected O, but got F4
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_00a5: Expected O, but got F4
		object obj = rect.m_XMin ^ -0f;
		object obj2 = obj / rect.m_Width;
		float num = (float)obj2 - 0.5f;
		object obj3 = rect.m_YMin ^ -0f;
		object obj4 = obj3 / rect.m_Height;
		float num2 = (float)obj4 - 0.5f;
		float num3 = cos / rect.m_Width;
		m00 = num3;
		float num4 = num * cos;
		object obj5 = sin ^ -0f;
		float num5 = (float)obj5 / rect.m_Height;
		float num6 = num2 * sin;
		m01 = num5;
		float num7 = num4 - num6;
		float num8 = num7 + 0.5f;
		m02 = num8;
		float num9 = sin / rect.m_Width;
		m10 = num9;
		float num10 = num2 * cos;
		float num11 = cos / rect.m_Height;
		float num12 = num * sin;
		m11 = num11;
		float num13 = num10 + num12;
		float num14 = num13 + 0.5f;
		m12 = num14;
	}

	public static Vector2 operator *(Matrix2x3 m, Vector2 v)
	{
		Vector2 result = default(Vector2);
		return result;
	}
}
