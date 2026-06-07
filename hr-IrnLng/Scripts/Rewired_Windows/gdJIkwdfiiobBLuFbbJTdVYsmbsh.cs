using System;
using System.Globalization;

internal struct gdJIkwdfiiobBLuFbbJTdVYsmbsh : IEquatable<gdJIkwdfiiobBLuFbbJTdVYsmbsh>
{
	private int SBswsjgiJzfKkjlvrlfAbOoKjDSZ;

	private int HXgwrrxHYJdygeQcUWckMMbsRRnp;

	private int eYDCmYzubYHeGGrjGkDpsBiMQRMI;

	private int mRhCogDoYtixeUERKtPRmKPyKOpB;

	public static readonly gdJIkwdfiiobBLuFbbJTdVYsmbsh XyYaPHDqLlsQUwLUOYaXzDXevXl;

	public int Left
	{
		get
		{
			return SBswsjgiJzfKkjlvrlfAbOoKjDSZ;
		}
		set
		{
			SBswsjgiJzfKkjlvrlfAbOoKjDSZ = value;
		}
	}

	public int Top
	{
		get
		{
			return HXgwrrxHYJdygeQcUWckMMbsRRnp;
		}
		set
		{
			HXgwrrxHYJdygeQcUWckMMbsRRnp = value;
		}
	}

	public int Right
	{
		get
		{
			return eYDCmYzubYHeGGrjGkDpsBiMQRMI;
		}
		set
		{
			eYDCmYzubYHeGGrjGkDpsBiMQRMI = value;
		}
	}

	public int Bottom
	{
		get
		{
			return mRhCogDoYtixeUERKtPRmKPyKOpB;
		}
		set
		{
			mRhCogDoYtixeUERKtPRmKPyKOpB = value;
		}
	}

	public int X
	{
		get
		{
			return SBswsjgiJzfKkjlvrlfAbOoKjDSZ;
		}
		set
		{
			eYDCmYzubYHeGGrjGkDpsBiMQRMI = value + Width;
			SBswsjgiJzfKkjlvrlfAbOoKjDSZ = value;
		}
	}

	public int Y
	{
		get
		{
			return HXgwrrxHYJdygeQcUWckMMbsRRnp;
		}
		set
		{
			mRhCogDoYtixeUERKtPRmKPyKOpB = value + Height;
			HXgwrrxHYJdygeQcUWckMMbsRRnp = value;
		}
	}

	public int Width
	{
		get
		{
			return eYDCmYzubYHeGGrjGkDpsBiMQRMI - SBswsjgiJzfKkjlvrlfAbOoKjDSZ;
		}
		set
		{
			eYDCmYzubYHeGGrjGkDpsBiMQRMI = SBswsjgiJzfKkjlvrlfAbOoKjDSZ + value;
		}
	}

	public int Height
	{
		get
		{
			return mRhCogDoYtixeUERKtPRmKPyKOpB - HXgwrrxHYJdygeQcUWckMMbsRRnp;
		}
		set
		{
			mRhCogDoYtixeUERKtPRmKPyKOpB = HXgwrrxHYJdygeQcUWckMMbsRRnp + value;
		}
	}

	public QnXGAFhCHOzZjLcARyFlJmvLkuRD Location
	{
		get
		{
			return new QnXGAFhCHOzZjLcARyFlJmvLkuRD(X, Y);
		}
		set
		{
			X = value.aKhnJLPlzQqMJcsXANqZDKcXdkvk;
			Y = value.CfrGUAcJZiBIgrKhIOoWYteVjgS;
		}
	}

	public QnXGAFhCHOzZjLcARyFlJmvLkuRD Center => new QnXGAFhCHOzZjLcARyFlJmvLkuRD(X + Width / 2, Y + Height / 2);

	public bool IsEmpty
	{
		get
		{
			if (Width == 0 && Height == 0 && X == 0)
			{
				return Y == 0;
			}
			return false;
		}
	}

	public NthYJJdmVgKATgikKXnZnwwRHUk Size
	{
		get
		{
			return new NthYJJdmVgKATgikKXnZnwwRHUk(Width, Height);
		}
		set
		{
			Width = value.XVmTnCLlrQbTubpRSjRvTRrxzEWd;
			Height = value.hxcLeAFGkKKZrEJuoceMBiBealeC;
		}
	}

	public QnXGAFhCHOzZjLcARyFlJmvLkuRD TopLeft => new QnXGAFhCHOzZjLcARyFlJmvLkuRD(SBswsjgiJzfKkjlvrlfAbOoKjDSZ, HXgwrrxHYJdygeQcUWckMMbsRRnp);

	public QnXGAFhCHOzZjLcARyFlJmvLkuRD TopRight => new QnXGAFhCHOzZjLcARyFlJmvLkuRD(eYDCmYzubYHeGGrjGkDpsBiMQRMI, HXgwrrxHYJdygeQcUWckMMbsRRnp);

	public QnXGAFhCHOzZjLcARyFlJmvLkuRD BottomLeft => new QnXGAFhCHOzZjLcARyFlJmvLkuRD(SBswsjgiJzfKkjlvrlfAbOoKjDSZ, mRhCogDoYtixeUERKtPRmKPyKOpB);

	public QnXGAFhCHOzZjLcARyFlJmvLkuRD BottomRight => new QnXGAFhCHOzZjLcARyFlJmvLkuRD(eYDCmYzubYHeGGrjGkDpsBiMQRMI, mRhCogDoYtixeUERKtPRmKPyKOpB);

	static gdJIkwdfiiobBLuFbbJTdVYsmbsh()
	{
		XyYaPHDqLlsQUwLUOYaXzDXevXl = default(gdJIkwdfiiobBLuFbbJTdVYsmbsh);
	}

	public gdJIkwdfiiobBLuFbbJTdVYsmbsh(int x, int y, int width, int height)
	{
		SBswsjgiJzfKkjlvrlfAbOoKjDSZ = x;
		HXgwrrxHYJdygeQcUWckMMbsRRnp = y;
		eYDCmYzubYHeGGrjGkDpsBiMQRMI = x + width;
		mRhCogDoYtixeUERKtPRmKPyKOpB = y + height;
	}

	public void cJyNeilCnUdRmKWIRHhHHebKNpEt(QnXGAFhCHOzZjLcARyFlJmvLkuRD P_0)
	{
		cJyNeilCnUdRmKWIRHhHHebKNpEt(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public void cJyNeilCnUdRmKWIRHhHHebKNpEt(int P_0, int P_1)
	{
		X += P_0;
		Y += P_1;
	}

	public void NlWesEjIehkawokCYEnSdpmuutaB(int P_0, int P_1)
	{
		X -= P_0;
		Y -= P_1;
		Width += P_0 * 2;
		Height += P_1 * 2;
	}

	public bool TsxbHEcmQPhQPOBcEjqTjgYzUQM(int P_0, int P_1)
	{
		if (X <= P_0 && P_0 < Right && Y <= P_1)
		{
			return P_1 < Bottom;
		}
		return false;
	}

	public bool TsxbHEcmQPhQPOBcEjqTjgYzUQM(QnXGAFhCHOzZjLcARyFlJmvLkuRD P_0)
	{
		TsxbHEcmQPhQPOBcEjqTjgYzUQM(ref P_0, out var result);
		return result;
	}

	public void TsxbHEcmQPhQPOBcEjqTjgYzUQM(ref QnXGAFhCHOzZjLcARyFlJmvLkuRD P_0, out bool P_1)
	{
		P_1 = X <= P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk && P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk < Right && Y <= P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS && P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS < Bottom;
	}

	public bool TsxbHEcmQPhQPOBcEjqTjgYzUQM(gdJIkwdfiiobBLuFbbJTdVYsmbsh P_0)
	{
		TsxbHEcmQPhQPOBcEjqTjgYzUQM(ref P_0, out var result);
		return result;
	}

	public void TsxbHEcmQPhQPOBcEjqTjgYzUQM(ref gdJIkwdfiiobBLuFbbJTdVYsmbsh P_0, out bool P_1)
	{
		P_1 = X <= P_0.X && P_0.Right <= Right && Y <= P_0.Y && P_0.Bottom <= Bottom;
	}

	public bool TsxbHEcmQPhQPOBcEjqTjgYzUQM(float P_0, float P_1)
	{
		if (P_0 >= (float)SBswsjgiJzfKkjlvrlfAbOoKjDSZ && P_0 <= (float)eYDCmYzubYHeGGrjGkDpsBiMQRMI && P_1 >= (float)HXgwrrxHYJdygeQcUWckMMbsRRnp)
		{
			return P_1 <= (float)mRhCogDoYtixeUERKtPRmKPyKOpB;
		}
		return false;
	}

	public bool TsxbHEcmQPhQPOBcEjqTjgYzUQM(ohzRQrGKZflWBjCqYONwTQYejHY P_0)
	{
		return TsxbHEcmQPhQPOBcEjqTjgYzUQM(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public bool epvkMPDsBmAhEgnsoaQNKOXDHrE(gdJIkwdfiiobBLuFbbJTdVYsmbsh P_0)
	{
		epvkMPDsBmAhEgnsoaQNKOXDHrE(ref P_0, out var result);
		return result;
	}

	public void epvkMPDsBmAhEgnsoaQNKOXDHrE(ref gdJIkwdfiiobBLuFbbJTdVYsmbsh P_0, out bool P_1)
	{
		P_1 = P_0.X < Right && X < P_0.Right && P_0.Y < Bottom && Y < P_0.Bottom;
	}

	public static gdJIkwdfiiobBLuFbbJTdVYsmbsh ILPsvzwCWrAmtzHIgooIywgMlcL(gdJIkwdfiiobBLuFbbJTdVYsmbsh P_0, gdJIkwdfiiobBLuFbbJTdVYsmbsh P_1)
	{
		ILPsvzwCWrAmtzHIgooIywgMlcL(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void ILPsvzwCWrAmtzHIgooIywgMlcL(ref gdJIkwdfiiobBLuFbbJTdVYsmbsh P_0, ref gdJIkwdfiiobBLuFbbJTdVYsmbsh P_1, out gdJIkwdfiiobBLuFbbJTdVYsmbsh P_2)
	{
		int num = ((P_0.X > P_1.X) ? P_0.X : P_1.X);
		int num2 = ((P_0.Y > P_1.Y) ? P_0.Y : P_1.Y);
		int num3 = ((P_0.Right < P_1.Right) ? P_0.Right : P_1.Right);
		int num4 = ((P_0.Bottom < P_1.Bottom) ? P_0.Bottom : P_1.Bottom);
		if (num3 > num && num4 > num2)
		{
			P_2 = new gdJIkwdfiiobBLuFbbJTdVYsmbsh(num, num2, num3 - num, num4 - num2);
		}
		else
		{
			P_2 = XyYaPHDqLlsQUwLUOYaXzDXevXl;
		}
	}

	public static gdJIkwdfiiobBLuFbbJTdVYsmbsh LoROzLMQaWXaTNzOhYFChCvWpBw(gdJIkwdfiiobBLuFbbJTdVYsmbsh P_0, gdJIkwdfiiobBLuFbbJTdVYsmbsh P_1)
	{
		LoROzLMQaWXaTNzOhYFChCvWpBw(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void LoROzLMQaWXaTNzOhYFChCvWpBw(ref gdJIkwdfiiobBLuFbbJTdVYsmbsh P_0, ref gdJIkwdfiiobBLuFbbJTdVYsmbsh P_1, out gdJIkwdfiiobBLuFbbJTdVYsmbsh P_2)
	{
		int num = Math.Min(P_0.Left, P_1.Left);
		int num2 = Math.Max(P_0.Right, P_1.Right);
		int num3 = Math.Min(P_0.Top, P_1.Top);
		int num4 = Math.Max(P_0.Bottom, P_1.Bottom);
		P_2 = new gdJIkwdfiiobBLuFbbJTdVYsmbsh(num, num3, num2 - num, num4 - num3);
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if ((object)obj.GetType() != typeof(gdJIkwdfiiobBLuFbbJTdVYsmbsh))
		{
			return false;
		}
		return Equals((gdJIkwdfiiobBLuFbbJTdVYsmbsh)obj);
	}

	public bool Equals(gdJIkwdfiiobBLuFbbJTdVYsmbsh other)
	{
		if (other.SBswsjgiJzfKkjlvrlfAbOoKjDSZ == SBswsjgiJzfKkjlvrlfAbOoKjDSZ && other.HXgwrrxHYJdygeQcUWckMMbsRRnp == HXgwrrxHYJdygeQcUWckMMbsRRnp && other.eYDCmYzubYHeGGrjGkDpsBiMQRMI == eYDCmYzubYHeGGrjGkDpsBiMQRMI)
		{
			return other.mRhCogDoYtixeUERKtPRmKPyKOpB == mRhCogDoYtixeUERKtPRmKPyKOpB;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int sBswsjgiJzfKkjlvrlfAbOoKjDSZ = SBswsjgiJzfKkjlvrlfAbOoKjDSZ;
		sBswsjgiJzfKkjlvrlfAbOoKjDSZ = (sBswsjgiJzfKkjlvrlfAbOoKjDSZ * 397) ^ HXgwrrxHYJdygeQcUWckMMbsRRnp;
		sBswsjgiJzfKkjlvrlfAbOoKjDSZ = (sBswsjgiJzfKkjlvrlfAbOoKjDSZ * 397) ^ eYDCmYzubYHeGGrjGkDpsBiMQRMI;
		return (sBswsjgiJzfKkjlvrlfAbOoKjDSZ * 397) ^ mRhCogDoYtixeUERKtPRmKPyKOpB;
	}

	public static bool operator ==(gdJIkwdfiiobBLuFbbJTdVYsmbsh left, gdJIkwdfiiobBLuFbbJTdVYsmbsh right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(gdJIkwdfiiobBLuFbbJTdVYsmbsh left, gdJIkwdfiiobBLuFbbJTdVYsmbsh right)
	{
		return !(left == right);
	}

	public static implicit operator thJBHTDJRXIuWUGGNcLGoXxEhLU(gdJIkwdfiiobBLuFbbJTdVYsmbsh value)
	{
		return new thJBHTDJRXIuWUGGNcLGoXxEhLU(value.X, value.Y, value.Width, value.Height);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "X:{0} Y:{1} Width:{2} Height:{3}", X, Y, Width, Height);
	}

	internal void LHqqoNQXwnFbnefcbMeKacvhLxS()
	{
		eYDCmYzubYHeGGrjGkDpsBiMQRMI -= SBswsjgiJzfKkjlvrlfAbOoKjDSZ;
		mRhCogDoYtixeUERKtPRmKPyKOpB -= HXgwrrxHYJdygeQcUWckMMbsRRnp;
	}
}
