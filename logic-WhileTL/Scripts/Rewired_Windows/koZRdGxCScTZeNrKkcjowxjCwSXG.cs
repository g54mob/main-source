using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class koZRdGxCScTZeNrKkcjowxjCwSXG : OWNGqhbJvUXJOZIyMZKGGdWRctLr<JEUwahUuBCvKlKDLlrHoMVmbuinA, fKIcdIzPeFfRZKWaDHFBArclyibgA>
{
	private static readonly List<DUNlxlqegigEAjzeZiZQcNVskUdf> oErAazYxfcEwcdxeXIXVQMJahHyR;

	[CompilerGenerated]
	private List<DUNlxlqegigEAjzeZiZQcNVskUdf> EqUApgaJqlDRtliqhcQxFaRzYCpf;

	public List<DUNlxlqegigEAjzeZiZQcNVskUdf> cscRnoXhDVwBphxNOemHIGLvjZlt => oErAazYxfcEwcdxeXIXVQMJahHyR;

	public List<DUNlxlqegigEAjzeZiZQcNVskUdf> xKXdiIGVsLdZiBnweASUjzCaHgpJb
	{
		[CompilerGenerated]
		get
		{
			return EqUApgaJqlDRtliqhcQxFaRzYCpf;
		}
		[CompilerGenerated]
		private set
		{
			EqUApgaJqlDRtliqhcQxFaRzYCpf = eqUApgaJqlDRtliqhcQxFaRzYCpf;
		}
	}

	static koZRdGxCScTZeNrKkcjowxjCwSXG()
	{
		oErAazYxfcEwcdxeXIXVQMJahHyR = new List<DUNlxlqegigEAjzeZiZQcNVskUdf>(256);
		foreach (object value in Enum.GetValues(typeof(DUNlxlqegigEAjzeZiZQcNVskUdf)))
		{
			oErAazYxfcEwcdxeXIXVQMJahHyR.Add((DUNlxlqegigEAjzeZiZQcNVskUdf)value);
		}
	}

	public koZRdGxCScTZeNrKkcjowxjCwSXG()
	{
		xKXdiIGVsLdZiBnweASUjzCaHgpJb = new List<DUNlxlqegigEAjzeZiZQcNVskUdf>(16);
	}

	public bool utbOgWbbgCRowvfuqSsMGrbZuXUU(DUNlxlqegigEAjzeZiZQcNVskUdf P_0)
	{
		return xKXdiIGVsLdZiBnweASUjzCaHgpJb.Contains(P_0);
	}

	public void Update(fKIcdIzPeFfRZKWaDHFBArclyibgA P_0)
	{
		if (P_0.ynRdmUszzmOESEZgvCYfuGvyocon != DUNlxlqegigEAjzeZiZQcNVskUdf.Unknown)
		{
			bool flag = utbOgWbbgCRowvfuqSsMGrbZuXUU(P_0.ynRdmUszzmOESEZgvCYfuGvyocon);
			if (P_0.utbOgWbbgCRowvfuqSsMGrbZuXUU && !flag)
			{
				xKXdiIGVsLdZiBnweASUjzCaHgpJb.Add(P_0.ynRdmUszzmOESEZgvCYfuGvyocon);
			}
			else if (P_0.LjdWNjOSpIySzFSgyCYUlLxGYBuh && flag)
			{
				xKXdiIGVsLdZiBnweASUjzCaHgpJb.Remove(P_0.ynRdmUszzmOESEZgvCYfuGvyocon);
			}
		}
	}

	public unsafe void MarshalFrom(IntPtr P_0)
	{
		xKXdiIGVsLdZiBnweASUjzCaHgpJb.Clear();
		JEUwahUuBCvKlKDLlrHoMVmbuinA* ptr = (JEUwahUuBCvKlKDLlrHoMVmbuinA*)(void*)P_0;
		fKIcdIzPeFfRZKWaDHFBArclyibgA fKIcdIzPeFfRZKWaDHFBArclyibgA2 = default(fKIcdIzPeFfRZKWaDHFBArclyibgA);
		byte* ptr2 = &ptr->mpCfWbxTPdzRZLFnoLOKNsmCwLml.wwgeFuhkcTYYFAtZDcYeYnFApsTAb;
		for (int i = 0; i < 256; i++)
		{
			fKIcdIzPeFfRZKWaDHFBArclyibgA2.PVzwQwKKAONBdIXYwmbLllOobamc = i;
			fKIcdIzPeFfRZKWaDHFBArclyibgA2.bHhKLBYReRMVzLmXXVGCAnLNQrgi = ptr2[i];
			if (fKIcdIzPeFfRZKWaDHFBArclyibgA2.utbOgWbbgCRowvfuqSsMGrbZuXUU)
			{
				xKXdiIGVsLdZiBnweASUjzCaHgpJb.Add(fKIcdIzPeFfRZKWaDHFBArclyibgA2.ynRdmUszzmOESEZgvCYfuGvyocon);
			}
		}
	}

	public virtual string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
	{
		return string.Format(CultureInfo.InvariantCulture, "PressedKeys: {0}", new object[1] { qUbotaSLZASADLtRbuWjzvVhFURA.tZoSuFzNBjWbBxKsAtWzHuoGlimg(",", xKXdiIGVsLdZiBnweASUjzCaHgpJb) });
	}
}
