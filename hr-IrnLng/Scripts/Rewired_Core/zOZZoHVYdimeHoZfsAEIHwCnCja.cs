using Rewired.Utils;

internal struct zOZZoHVYdimeHoZfsAEIHwCnCja
{
	public float FzCIvtwBEWqiAMvsUgGqBBCOPJY;

	public float xmFIgjGNxavJrroAlgIEXNVskcM;

	public float oHmQLvKpmAddycxqzPSKoXMbFYY;

	public static zOZZoHVYdimeHoZfsAEIHwCnCja Zero => new zOZZoHVYdimeHoZfsAEIHwCnCja
	{
		FzCIvtwBEWqiAMvsUgGqBBCOPJY = 0f,
		xmFIgjGNxavJrroAlgIEXNVskcM = 0f,
		oHmQLvKpmAddycxqzPSKoXMbFYY = 0f
	};

	public zOZZoHVYdimeHoZfsAEIHwCnCja(float inX, float inY, float inZ)
	{
		FzCIvtwBEWqiAMvsUgGqBBCOPJY = inX;
		xmFIgjGNxavJrroAlgIEXNVskcM = inY;
		oHmQLvKpmAddycxqzPSKoXMbFYY = inZ;
	}

	public void NGXUBbcPdrBYfEJQGstImmQAGjsO(float P_0, float P_1, float P_2)
	{
		FzCIvtwBEWqiAMvsUgGqBBCOPJY = P_0;
		xmFIgjGNxavJrroAlgIEXNVskcM = P_1;
		oHmQLvKpmAddycxqzPSKoXMbFYY = P_2;
	}

	public float oBBQbqRAKFCCwaCJladYTzapClYZ()
	{
		return MathTools.Sqrt(FzCIvtwBEWqiAMvsUgGqBBCOPJY * FzCIvtwBEWqiAMvsUgGqBBCOPJY + xmFIgjGNxavJrroAlgIEXNVskcM * xmFIgjGNxavJrroAlgIEXNVskcM + oHmQLvKpmAddycxqzPSKoXMbFYY * oHmQLvKpmAddycxqzPSKoXMbFYY);
	}

	public void yZKarIdoLjkzTCDqwejwKaYefsiZ()
	{
		float num = oBBQbqRAKFCCwaCJladYTzapClYZ();
		if ((double)num != 0.0)
		{
			float num2 = 1f / num;
			FzCIvtwBEWqiAMvsUgGqBBCOPJY *= num2;
			xmFIgjGNxavJrroAlgIEXNVskcM *= num2;
			oHmQLvKpmAddycxqzPSKoXMbFYY *= num2;
		}
	}

	public zOZZoHVYdimeHoZfsAEIHwCnCja UHmqKyYDUzWUJMXOuGgIyZJKnxz()
	{
		zOZZoHVYdimeHoZfsAEIHwCnCja result = this;
		result.yZKarIdoLjkzTCDqwejwKaYefsiZ();
		return result;
	}

	public static zOZZoHVYdimeHoZfsAEIHwCnCja operator +(zOZZoHVYdimeHoZfsAEIHwCnCja lhs, zOZZoHVYdimeHoZfsAEIHwCnCja rhs)
	{
		zOZZoHVYdimeHoZfsAEIHwCnCja result = default(zOZZoHVYdimeHoZfsAEIHwCnCja);
		result.NGXUBbcPdrBYfEJQGstImmQAGjsO(lhs.FzCIvtwBEWqiAMvsUgGqBBCOPJY + rhs.FzCIvtwBEWqiAMvsUgGqBBCOPJY, lhs.xmFIgjGNxavJrroAlgIEXNVskcM + rhs.xmFIgjGNxavJrroAlgIEXNVskcM, lhs.oHmQLvKpmAddycxqzPSKoXMbFYY + rhs.oHmQLvKpmAddycxqzPSKoXMbFYY);
		return result;
	}

	public static zOZZoHVYdimeHoZfsAEIHwCnCja operator -(zOZZoHVYdimeHoZfsAEIHwCnCja lhs, zOZZoHVYdimeHoZfsAEIHwCnCja rhs)
	{
		zOZZoHVYdimeHoZfsAEIHwCnCja result = default(zOZZoHVYdimeHoZfsAEIHwCnCja);
		result.NGXUBbcPdrBYfEJQGstImmQAGjsO(lhs.FzCIvtwBEWqiAMvsUgGqBBCOPJY - rhs.FzCIvtwBEWqiAMvsUgGqBBCOPJY, lhs.xmFIgjGNxavJrroAlgIEXNVskcM - rhs.xmFIgjGNxavJrroAlgIEXNVskcM, lhs.oHmQLvKpmAddycxqzPSKoXMbFYY - rhs.oHmQLvKpmAddycxqzPSKoXMbFYY);
		return result;
	}

	public static zOZZoHVYdimeHoZfsAEIHwCnCja operator *(zOZZoHVYdimeHoZfsAEIHwCnCja lhs, float rhs)
	{
		zOZZoHVYdimeHoZfsAEIHwCnCja result = default(zOZZoHVYdimeHoZfsAEIHwCnCja);
		result.NGXUBbcPdrBYfEJQGstImmQAGjsO(lhs.FzCIvtwBEWqiAMvsUgGqBBCOPJY * rhs, lhs.xmFIgjGNxavJrroAlgIEXNVskcM * rhs, lhs.oHmQLvKpmAddycxqzPSKoXMbFYY * rhs);
		return result;
	}

	public static zOZZoHVYdimeHoZfsAEIHwCnCja operator /(zOZZoHVYdimeHoZfsAEIHwCnCja lhs, float rhs)
	{
		zOZZoHVYdimeHoZfsAEIHwCnCja result = default(zOZZoHVYdimeHoZfsAEIHwCnCja);
		result.NGXUBbcPdrBYfEJQGstImmQAGjsO(lhs.FzCIvtwBEWqiAMvsUgGqBBCOPJY / rhs, lhs.xmFIgjGNxavJrroAlgIEXNVskcM / rhs, lhs.oHmQLvKpmAddycxqzPSKoXMbFYY / rhs);
		return result;
	}

	public static zOZZoHVYdimeHoZfsAEIHwCnCja operator *(zOZZoHVYdimeHoZfsAEIHwCnCja lhs, SjvCUJbQFvjSikdXJRrKZeKGGxN rhs)
	{
		zOZZoHVYdimeHoZfsAEIHwCnCja result = default(zOZZoHVYdimeHoZfsAEIHwCnCja);
		SjvCUJbQFvjSikdXJRrKZeKGGxN sjvCUJbQFvjSikdXJRrKZeKGGxN = rhs * new SjvCUJbQFvjSikdXJRrKZeKGGxN(0f, lhs.FzCIvtwBEWqiAMvsUgGqBBCOPJY, lhs.xmFIgjGNxavJrroAlgIEXNVskcM, lhs.oHmQLvKpmAddycxqzPSKoXMbFYY) * rhs.bySkeQTBRmAqJXGXnfytcNnYNiO();
		result.NGXUBbcPdrBYfEJQGstImmQAGjsO(sjvCUJbQFvjSikdXJRrKZeKGGxN.FzCIvtwBEWqiAMvsUgGqBBCOPJY, sjvCUJbQFvjSikdXJRrKZeKGGxN.xmFIgjGNxavJrroAlgIEXNVskcM, sjvCUJbQFvjSikdXJRrKZeKGGxN.oHmQLvKpmAddycxqzPSKoXMbFYY);
		return result;
	}

	public static zOZZoHVYdimeHoZfsAEIHwCnCja operator -(zOZZoHVYdimeHoZfsAEIHwCnCja lhs)
	{
		return new zOZZoHVYdimeHoZfsAEIHwCnCja(0f - lhs.FzCIvtwBEWqiAMvsUgGqBBCOPJY, 0f - lhs.xmFIgjGNxavJrroAlgIEXNVskcM, 0f - lhs.oHmQLvKpmAddycxqzPSKoXMbFYY);
	}

	public float kBNWLMEnnkgMqyrjeeJUOjdIdRQ(zOZZoHVYdimeHoZfsAEIHwCnCja P_0)
	{
		return FzCIvtwBEWqiAMvsUgGqBBCOPJY * P_0.FzCIvtwBEWqiAMvsUgGqBBCOPJY + xmFIgjGNxavJrroAlgIEXNVskcM * P_0.xmFIgjGNxavJrroAlgIEXNVskcM + oHmQLvKpmAddycxqzPSKoXMbFYY * P_0.oHmQLvKpmAddycxqzPSKoXMbFYY;
	}

	public zOZZoHVYdimeHoZfsAEIHwCnCja BzPvQUdUAafkeVgSnGvIdpPFJVG(zOZZoHVYdimeHoZfsAEIHwCnCja P_0)
	{
		return new zOZZoHVYdimeHoZfsAEIHwCnCja(xmFIgjGNxavJrroAlgIEXNVskcM * P_0.oHmQLvKpmAddycxqzPSKoXMbFYY - oHmQLvKpmAddycxqzPSKoXMbFYY * P_0.xmFIgjGNxavJrroAlgIEXNVskcM, oHmQLvKpmAddycxqzPSKoXMbFYY * P_0.FzCIvtwBEWqiAMvsUgGqBBCOPJY - FzCIvtwBEWqiAMvsUgGqBBCOPJY * P_0.oHmQLvKpmAddycxqzPSKoXMbFYY, FzCIvtwBEWqiAMvsUgGqBBCOPJY * P_0.xmFIgjGNxavJrroAlgIEXNVskcM - xmFIgjGNxavJrroAlgIEXNVskcM * P_0.FzCIvtwBEWqiAMvsUgGqBBCOPJY);
	}
}
