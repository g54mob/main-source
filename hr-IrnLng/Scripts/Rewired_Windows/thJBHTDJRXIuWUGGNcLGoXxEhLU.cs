using System;
using System.Globalization;

internal struct thJBHTDJRXIuWUGGNcLGoXxEhLU : IEquatable<thJBHTDJRXIuWUGGNcLGoXxEhLU>
{
	private float SBswsjgiJzfKkjlvrlfAbOoKjDSZ;

	private float HXgwrrxHYJdygeQcUWckMMbsRRnp;

	private float eYDCmYzubYHeGGrjGkDpsBiMQRMI;

	private float mRhCogDoYtixeUERKtPRmKPyKOpB;

	public static readonly thJBHTDJRXIuWUGGNcLGoXxEhLU XyYaPHDqLlsQUwLUOYaXzDXevXl;

	public static readonly thJBHTDJRXIuWUGGNcLGoXxEhLU zsmzMkdCEmYBsYicYunYgCtiuMv;

	public float Left
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

	public float Top
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

	public float Right
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

	public float Bottom
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

	public float X
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

	public float Y
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

	public float Width
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

	public float Height
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

	public ohzRQrGKZflWBjCqYONwTQYejHY Location
	{
		get
		{
			return new ohzRQrGKZflWBjCqYONwTQYejHY(X, Y);
		}
		set
		{
			X = value.aKhnJLPlzQqMJcsXANqZDKcXdkvk;
			Y = value.CfrGUAcJZiBIgrKhIOoWYteVjgS;
		}
	}

	public ohzRQrGKZflWBjCqYONwTQYejHY Center => new ohzRQrGKZflWBjCqYONwTQYejHY(X + Width / 2f, Y + Height / 2f);

	public bool IsEmpty
	{
		get
		{
			if (Width == 0f && Height == 0f && X == 0f)
			{
				return Y == 0f;
			}
			return false;
		}
	}

	public gtvWtiZMRCqkFBbmWIWmYwnkIAiH Size
	{
		get
		{
			return new gtvWtiZMRCqkFBbmWIWmYwnkIAiH(Width, Height);
		}
		set
		{
			Width = value.XVmTnCLlrQbTubpRSjRvTRrxzEWd;
			Height = value.hxcLeAFGkKKZrEJuoceMBiBealeC;
		}
	}

	public ohzRQrGKZflWBjCqYONwTQYejHY TopLeft => new ohzRQrGKZflWBjCqYONwTQYejHY(SBswsjgiJzfKkjlvrlfAbOoKjDSZ, HXgwrrxHYJdygeQcUWckMMbsRRnp);

	public ohzRQrGKZflWBjCqYONwTQYejHY TopRight => new ohzRQrGKZflWBjCqYONwTQYejHY(eYDCmYzubYHeGGrjGkDpsBiMQRMI, HXgwrrxHYJdygeQcUWckMMbsRRnp);

	public ohzRQrGKZflWBjCqYONwTQYejHY BottomLeft => new ohzRQrGKZflWBjCqYONwTQYejHY(SBswsjgiJzfKkjlvrlfAbOoKjDSZ, mRhCogDoYtixeUERKtPRmKPyKOpB);

	public ohzRQrGKZflWBjCqYONwTQYejHY BottomRight => new ohzRQrGKZflWBjCqYONwTQYejHY(eYDCmYzubYHeGGrjGkDpsBiMQRMI, mRhCogDoYtixeUERKtPRmKPyKOpB);

	static thJBHTDJRXIuWUGGNcLGoXxEhLU()
	{
		XyYaPHDqLlsQUwLUOYaXzDXevXl = default(thJBHTDJRXIuWUGGNcLGoXxEhLU);
		zsmzMkdCEmYBsYicYunYgCtiuMv = new thJBHTDJRXIuWUGGNcLGoXxEhLU
		{
			Left = float.NegativeInfinity,
			Top = float.NegativeInfinity,
			Right = float.PositiveInfinity,
			Bottom = float.PositiveInfinity
		};
	}

	public thJBHTDJRXIuWUGGNcLGoXxEhLU(float x, float y, float width, float height)
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

	public void cJyNeilCnUdRmKWIRHhHHebKNpEt(ohzRQrGKZflWBjCqYONwTQYejHY P_0)
	{
		cJyNeilCnUdRmKWIRHhHHebKNpEt(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public void cJyNeilCnUdRmKWIRHhHHebKNpEt(float P_0, float P_1)
	{
		X += P_0;
		Y += P_1;
	}

	public void NlWesEjIehkawokCYEnSdpmuutaB(float P_0, float P_1)
	{
		X -= P_0;
		Y -= P_1;
		Width += P_0 * 2f;
		Height += P_1 * 2f;
	}

	public void TsxbHEcmQPhQPOBcEjqTjgYzUQM(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, out bool P_1)
	{
		P_1 = X <= P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk && P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk < Right && Y <= P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS && P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS < Bottom;
	}

	public bool TsxbHEcmQPhQPOBcEjqTjgYzUQM(gdJIkwdfiiobBLuFbbJTdVYsmbsh P_0)
	{
		if (X <= (float)P_0.X && (float)P_0.Right <= Right && Y <= (float)P_0.Y)
		{
			return (float)P_0.Bottom <= Bottom;
		}
		return false;
	}

	public void TsxbHEcmQPhQPOBcEjqTjgYzUQM(ref thJBHTDJRXIuWUGGNcLGoXxEhLU P_0, out bool P_1)
	{
		P_1 = X <= P_0.X && P_0.Right <= Right && Y <= P_0.Y && P_0.Bottom <= Bottom;
	}

	public bool TsxbHEcmQPhQPOBcEjqTjgYzUQM(float P_0, float P_1)
	{
		if (P_0 >= SBswsjgiJzfKkjlvrlfAbOoKjDSZ && P_0 <= eYDCmYzubYHeGGrjGkDpsBiMQRMI && P_1 >= HXgwrrxHYJdygeQcUWckMMbsRRnp)
		{
			return P_1 <= mRhCogDoYtixeUERKtPRmKPyKOpB;
		}
		return false;
	}

	public bool TsxbHEcmQPhQPOBcEjqTjgYzUQM(ohzRQrGKZflWBjCqYONwTQYejHY P_0)
	{
		return TsxbHEcmQPhQPOBcEjqTjgYzUQM(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public bool TsxbHEcmQPhQPOBcEjqTjgYzUQM(QnXGAFhCHOzZjLcARyFlJmvLkuRD P_0)
	{
		return TsxbHEcmQPhQPOBcEjqTjgYzUQM(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public bool epvkMPDsBmAhEgnsoaQNKOXDHrE(thJBHTDJRXIuWUGGNcLGoXxEhLU P_0)
	{
		epvkMPDsBmAhEgnsoaQNKOXDHrE(ref P_0, out var result);
		return result;
	}

	public void epvkMPDsBmAhEgnsoaQNKOXDHrE(ref thJBHTDJRXIuWUGGNcLGoXxEhLU P_0, out bool P_1)
	{
		P_1 = P_0.X < Right && X < P_0.Right && P_0.Y < Bottom && Y < P_0.Bottom;
	}

	public static thJBHTDJRXIuWUGGNcLGoXxEhLU ILPsvzwCWrAmtzHIgooIywgMlcL(thJBHTDJRXIuWUGGNcLGoXxEhLU P_0, thJBHTDJRXIuWUGGNcLGoXxEhLU P_1)
	{
		ILPsvzwCWrAmtzHIgooIywgMlcL(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void ILPsvzwCWrAmtzHIgooIywgMlcL(ref thJBHTDJRXIuWUGGNcLGoXxEhLU P_0, ref thJBHTDJRXIuWUGGNcLGoXxEhLU P_1, out thJBHTDJRXIuWUGGNcLGoXxEhLU P_2)
	{
		float num = ((P_0.X > P_1.X) ? P_0.X : P_1.X);
		float num2 = ((P_0.Y > P_1.Y) ? P_0.Y : P_1.Y);
		float num3 = ((P_0.Right < P_1.Right) ? P_0.Right : P_1.Right);
		float num4 = ((P_0.Bottom < P_1.Bottom) ? P_0.Bottom : P_1.Bottom);
		if (num3 > num && num4 > num2)
		{
			P_2 = new thJBHTDJRXIuWUGGNcLGoXxEhLU(num, num2, num3 - num, num4 - num2);
		}
		else
		{
			P_2 = XyYaPHDqLlsQUwLUOYaXzDXevXl;
		}
	}

	public static thJBHTDJRXIuWUGGNcLGoXxEhLU LoROzLMQaWXaTNzOhYFChCvWpBw(thJBHTDJRXIuWUGGNcLGoXxEhLU P_0, thJBHTDJRXIuWUGGNcLGoXxEhLU P_1)
	{
		LoROzLMQaWXaTNzOhYFChCvWpBw(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void LoROzLMQaWXaTNzOhYFChCvWpBw(ref thJBHTDJRXIuWUGGNcLGoXxEhLU P_0, ref thJBHTDJRXIuWUGGNcLGoXxEhLU P_1, out thJBHTDJRXIuWUGGNcLGoXxEhLU P_2)
	{
		float num = Math.Min(P_0.Left, P_1.Left);
		float num2 = Math.Max(P_0.Right, P_1.Right);
		float num3 = Math.Min(P_0.Top, P_1.Top);
		float num4 = Math.Max(P_0.Bottom, P_1.Bottom);
		P_2 = new thJBHTDJRXIuWUGGNcLGoXxEhLU(num, num3, num2 - num, num4 - num3);
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if ((object)obj.GetType() != typeof(thJBHTDJRXIuWUGGNcLGoXxEhLU))
		{
			return false;
		}
		return Equals((thJBHTDJRXIuWUGGNcLGoXxEhLU)obj);
	}

	public bool Equals(thJBHTDJRXIuWUGGNcLGoXxEhLU other)
	{
		if (CkEGbSjYizEFwFszszFTBPspHuob.mlfTtstFxHQkEDuBkHVDxIjrIgH(other.Left, Left) && CkEGbSjYizEFwFszszFTBPspHuob.mlfTtstFxHQkEDuBkHVDxIjrIgH(other.Right, Right) && CkEGbSjYizEFwFszszFTBPspHuob.mlfTtstFxHQkEDuBkHVDxIjrIgH(other.Top, Top))
		{
			return CkEGbSjYizEFwFszszFTBPspHuob.mlfTtstFxHQkEDuBkHVDxIjrIgH(other.Bottom, Bottom);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int hashCode = SBswsjgiJzfKkjlvrlfAbOoKjDSZ.GetHashCode();
		hashCode = (hashCode * 397) ^ HXgwrrxHYJdygeQcUWckMMbsRRnp.GetHashCode();
		hashCode = (hashCode * 397) ^ eYDCmYzubYHeGGrjGkDpsBiMQRMI.GetHashCode();
		return (hashCode * 397) ^ mRhCogDoYtixeUERKtPRmKPyKOpB.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "X:{0} Y:{1} Width:{2} Height:{3}", X, Y, Width, Height);
	}

	public static bool operator ==(thJBHTDJRXIuWUGGNcLGoXxEhLU left, thJBHTDJRXIuWUGGNcLGoXxEhLU right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(thJBHTDJRXIuWUGGNcLGoXxEhLU left, thJBHTDJRXIuWUGGNcLGoXxEhLU right)
	{
		return !(left == right);
	}

	public static explicit operator gdJIkwdfiiobBLuFbbJTdVYsmbsh(thJBHTDJRXIuWUGGNcLGoXxEhLU value)
	{
		return new gdJIkwdfiiobBLuFbbJTdVYsmbsh((int)value.X, (int)value.Y, (int)value.Width, (int)value.Height);
	}
}
