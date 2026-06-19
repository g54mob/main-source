using Rewired.Utils;

internal struct PsdmHjepOdXNZbCTdoUZJOpNYzW
{
	public float fmiyCZXvdFCBWTjMPhSrLknizZk;

	public float JSffCNviejhMhwjEgVmNZseKfks;

	public float AuICePbhJNkEiFnOAaSLeapjTMJk;

	public static PsdmHjepOdXNZbCTdoUZJOpNYzW Zero => new PsdmHjepOdXNZbCTdoUZJOpNYzW
	{
		fmiyCZXvdFCBWTjMPhSrLknizZk = 0f,
		JSffCNviejhMhwjEgVmNZseKfks = 0f,
		AuICePbhJNkEiFnOAaSLeapjTMJk = 0f
	};

	public PsdmHjepOdXNZbCTdoUZJOpNYzW(float inX, float inY, float inZ)
	{
		fmiyCZXvdFCBWTjMPhSrLknizZk = inX;
		JSffCNviejhMhwjEgVmNZseKfks = inY;
		AuICePbhJNkEiFnOAaSLeapjTMJk = inZ;
	}

	public void vJjhoRLlAcrjzWycVrrFomtsobA(float P_0, float P_1, float P_2)
	{
		fmiyCZXvdFCBWTjMPhSrLknizZk = P_0;
		JSffCNviejhMhwjEgVmNZseKfks = P_1;
		AuICePbhJNkEiFnOAaSLeapjTMJk = P_2;
	}

	public float OYfCSKIazGcjmLHlcKfNxXTVfdcI()
	{
		return MathTools.Sqrt(fmiyCZXvdFCBWTjMPhSrLknizZk * fmiyCZXvdFCBWTjMPhSrLknizZk + JSffCNviejhMhwjEgVmNZseKfks * JSffCNviejhMhwjEgVmNZseKfks + AuICePbhJNkEiFnOAaSLeapjTMJk * AuICePbhJNkEiFnOAaSLeapjTMJk);
	}

	public void OnooYsDbgoAIBOKWtRbpoefGAgMi()
	{
		float num = OYfCSKIazGcjmLHlcKfNxXTVfdcI();
		if ((double)num != 0.0)
		{
			float num2 = 1f / num;
			fmiyCZXvdFCBWTjMPhSrLknizZk *= num2;
			JSffCNviejhMhwjEgVmNZseKfks *= num2;
			AuICePbhJNkEiFnOAaSLeapjTMJk *= num2;
		}
	}

	public PsdmHjepOdXNZbCTdoUZJOpNYzW kvOCjSjdpqIzNpLuboaTXiugojPG()
	{
		PsdmHjepOdXNZbCTdoUZJOpNYzW result = this;
		result.OnooYsDbgoAIBOKWtRbpoefGAgMi();
		return result;
	}

	public static PsdmHjepOdXNZbCTdoUZJOpNYzW operator +(PsdmHjepOdXNZbCTdoUZJOpNYzW lhs, PsdmHjepOdXNZbCTdoUZJOpNYzW rhs)
	{
		PsdmHjepOdXNZbCTdoUZJOpNYzW result = default(PsdmHjepOdXNZbCTdoUZJOpNYzW);
		result.vJjhoRLlAcrjzWycVrrFomtsobA(lhs.fmiyCZXvdFCBWTjMPhSrLknizZk + rhs.fmiyCZXvdFCBWTjMPhSrLknizZk, lhs.JSffCNviejhMhwjEgVmNZseKfks + rhs.JSffCNviejhMhwjEgVmNZseKfks, lhs.AuICePbhJNkEiFnOAaSLeapjTMJk + rhs.AuICePbhJNkEiFnOAaSLeapjTMJk);
		return result;
	}

	public static PsdmHjepOdXNZbCTdoUZJOpNYzW operator -(PsdmHjepOdXNZbCTdoUZJOpNYzW lhs, PsdmHjepOdXNZbCTdoUZJOpNYzW rhs)
	{
		PsdmHjepOdXNZbCTdoUZJOpNYzW result = default(PsdmHjepOdXNZbCTdoUZJOpNYzW);
		result.vJjhoRLlAcrjzWycVrrFomtsobA(lhs.fmiyCZXvdFCBWTjMPhSrLknizZk - rhs.fmiyCZXvdFCBWTjMPhSrLknizZk, lhs.JSffCNviejhMhwjEgVmNZseKfks - rhs.JSffCNviejhMhwjEgVmNZseKfks, lhs.AuICePbhJNkEiFnOAaSLeapjTMJk - rhs.AuICePbhJNkEiFnOAaSLeapjTMJk);
		return result;
	}

	public static PsdmHjepOdXNZbCTdoUZJOpNYzW operator *(PsdmHjepOdXNZbCTdoUZJOpNYzW lhs, float rhs)
	{
		PsdmHjepOdXNZbCTdoUZJOpNYzW result = default(PsdmHjepOdXNZbCTdoUZJOpNYzW);
		result.vJjhoRLlAcrjzWycVrrFomtsobA(lhs.fmiyCZXvdFCBWTjMPhSrLknizZk * rhs, lhs.JSffCNviejhMhwjEgVmNZseKfks * rhs, lhs.AuICePbhJNkEiFnOAaSLeapjTMJk * rhs);
		return result;
	}

	public static PsdmHjepOdXNZbCTdoUZJOpNYzW operator /(PsdmHjepOdXNZbCTdoUZJOpNYzW lhs, float rhs)
	{
		PsdmHjepOdXNZbCTdoUZJOpNYzW result = default(PsdmHjepOdXNZbCTdoUZJOpNYzW);
		result.vJjhoRLlAcrjzWycVrrFomtsobA(lhs.fmiyCZXvdFCBWTjMPhSrLknizZk / rhs, lhs.JSffCNviejhMhwjEgVmNZseKfks / rhs, lhs.AuICePbhJNkEiFnOAaSLeapjTMJk / rhs);
		return result;
	}

	public static PsdmHjepOdXNZbCTdoUZJOpNYzW operator *(PsdmHjepOdXNZbCTdoUZJOpNYzW lhs, aSVlFbMceavOajezIgjVPDdyujh rhs)
	{
		PsdmHjepOdXNZbCTdoUZJOpNYzW result = default(PsdmHjepOdXNZbCTdoUZJOpNYzW);
		aSVlFbMceavOajezIgjVPDdyujh aSVlFbMceavOajezIgjVPDdyujh2 = rhs * new aSVlFbMceavOajezIgjVPDdyujh(0f, lhs.fmiyCZXvdFCBWTjMPhSrLknizZk, lhs.JSffCNviejhMhwjEgVmNZseKfks, lhs.AuICePbhJNkEiFnOAaSLeapjTMJk) * rhs.JvyAPawugxljFIXjiutaucWaaTgK();
		result.vJjhoRLlAcrjzWycVrrFomtsobA(aSVlFbMceavOajezIgjVPDdyujh2.fmiyCZXvdFCBWTjMPhSrLknizZk, aSVlFbMceavOajezIgjVPDdyujh2.JSffCNviejhMhwjEgVmNZseKfks, aSVlFbMceavOajezIgjVPDdyujh2.AuICePbhJNkEiFnOAaSLeapjTMJk);
		return result;
	}

	public static PsdmHjepOdXNZbCTdoUZJOpNYzW operator -(PsdmHjepOdXNZbCTdoUZJOpNYzW lhs)
	{
		return new PsdmHjepOdXNZbCTdoUZJOpNYzW(0f - lhs.fmiyCZXvdFCBWTjMPhSrLknizZk, 0f - lhs.JSffCNviejhMhwjEgVmNZseKfks, 0f - lhs.AuICePbhJNkEiFnOAaSLeapjTMJk);
	}

	public float SOfHgotfGfRfsnJPvJFLQDOyzFa(PsdmHjepOdXNZbCTdoUZJOpNYzW P_0)
	{
		return fmiyCZXvdFCBWTjMPhSrLknizZk * P_0.fmiyCZXvdFCBWTjMPhSrLknizZk + JSffCNviejhMhwjEgVmNZseKfks * P_0.JSffCNviejhMhwjEgVmNZseKfks + AuICePbhJNkEiFnOAaSLeapjTMJk * P_0.AuICePbhJNkEiFnOAaSLeapjTMJk;
	}

	public PsdmHjepOdXNZbCTdoUZJOpNYzW hSpKoCAxBrIjsKeCcjwPzsUfNcc(PsdmHjepOdXNZbCTdoUZJOpNYzW P_0)
	{
		return new PsdmHjepOdXNZbCTdoUZJOpNYzW(JSffCNviejhMhwjEgVmNZseKfks * P_0.AuICePbhJNkEiFnOAaSLeapjTMJk - AuICePbhJNkEiFnOAaSLeapjTMJk * P_0.JSffCNviejhMhwjEgVmNZseKfks, AuICePbhJNkEiFnOAaSLeapjTMJk * P_0.fmiyCZXvdFCBWTjMPhSrLknizZk - fmiyCZXvdFCBWTjMPhSrLknizZk * P_0.AuICePbhJNkEiFnOAaSLeapjTMJk, fmiyCZXvdFCBWTjMPhSrLknizZk * P_0.JSffCNviejhMhwjEgVmNZseKfks - JSffCNviejhMhwjEgVmNZseKfks * P_0.fmiyCZXvdFCBWTjMPhSrLknizZk);
	}
}
