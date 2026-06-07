using System;
using System.Runtime.InteropServices;

internal struct yIbphFWxKqQKcPXSnKmgMkGDXMz
{
	private IntPtr jSuGGfASRzdxfbHERFDedjWEMMjV;

	private int URGbTyHYwxgSjLQFHjshUIzuJHW;

	private IntPtr wUrFYlhUKTSbKJcmxFIEpasQirkf;

	private IntPtr cSAmbvGqtsPzoWHsdebkjemlbFla;

	private IntPtr DBTaYcTnCBnTznFsKRpRcLWwtcG;

	public IntPtr HWnd
	{
		get
		{
			return jSuGGfASRzdxfbHERFDedjWEMMjV;
		}
		set
		{
			jSuGGfASRzdxfbHERFDedjWEMMjV = value;
		}
	}

	public int Msg
	{
		get
		{
			return URGbTyHYwxgSjLQFHjshUIzuJHW;
		}
		set
		{
			URGbTyHYwxgSjLQFHjshUIzuJHW = value;
		}
	}

	public IntPtr WParam
	{
		get
		{
			return wUrFYlhUKTSbKJcmxFIEpasQirkf;
		}
		set
		{
			wUrFYlhUKTSbKJcmxFIEpasQirkf = value;
		}
	}

	public IntPtr LParam
	{
		get
		{
			return cSAmbvGqtsPzoWHsdebkjemlbFla;
		}
		set
		{
			cSAmbvGqtsPzoWHsdebkjemlbFla = value;
		}
	}

	public IntPtr Result
	{
		get
		{
			return DBTaYcTnCBnTznFsKRpRcLWwtcG;
		}
		set
		{
			DBTaYcTnCBnTznFsKRpRcLWwtcG = value;
		}
	}

	public object bhEUSkGpixHlVJjnzobUxVxGZPR(Type P_0)
	{
		return Marshal.PtrToStructure(cSAmbvGqtsPzoWHsdebkjemlbFla, P_0);
	}

	public static yIbphFWxKqQKcPXSnKmgMkGDXMz XEZZaRuCBatWlcrdVaazQoMlqtI(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3)
	{
		return new yIbphFWxKqQKcPXSnKmgMkGDXMz
		{
			jSuGGfASRzdxfbHERFDedjWEMMjV = P_0,
			URGbTyHYwxgSjLQFHjshUIzuJHW = P_1,
			wUrFYlhUKTSbKJcmxFIEpasQirkf = P_2,
			cSAmbvGqtsPzoWHsdebkjemlbFla = P_3,
			DBTaYcTnCBnTznFsKRpRcLWwtcG = IntPtr.Zero
		};
	}

	public override bool Equals(object o)
	{
		if (!(o is yIbphFWxKqQKcPXSnKmgMkGDXMz yIbphFWxKqQKcPXSnKmgMkGDXMz2))
		{
			return false;
		}
		if (jSuGGfASRzdxfbHERFDedjWEMMjV == yIbphFWxKqQKcPXSnKmgMkGDXMz2.jSuGGfASRzdxfbHERFDedjWEMMjV && URGbTyHYwxgSjLQFHjshUIzuJHW == yIbphFWxKqQKcPXSnKmgMkGDXMz2.URGbTyHYwxgSjLQFHjshUIzuJHW && wUrFYlhUKTSbKJcmxFIEpasQirkf == yIbphFWxKqQKcPXSnKmgMkGDXMz2.wUrFYlhUKTSbKJcmxFIEpasQirkf && cSAmbvGqtsPzoWHsdebkjemlbFla == yIbphFWxKqQKcPXSnKmgMkGDXMz2.cSAmbvGqtsPzoWHsdebkjemlbFla)
		{
			return DBTaYcTnCBnTznFsKRpRcLWwtcG == yIbphFWxKqQKcPXSnKmgMkGDXMz2.DBTaYcTnCBnTznFsKRpRcLWwtcG;
		}
		return false;
	}

	public static bool operator !=(yIbphFWxKqQKcPXSnKmgMkGDXMz a, yIbphFWxKqQKcPXSnKmgMkGDXMz b)
	{
		return !a.Equals(b);
	}

	public static bool operator ==(yIbphFWxKqQKcPXSnKmgMkGDXMz a, yIbphFWxKqQKcPXSnKmgMkGDXMz b)
	{
		return a.Equals(b);
	}

	public override int GetHashCode()
	{
		return ((int)jSuGGfASRzdxfbHERFDedjWEMMjV << 4) | URGbTyHYwxgSjLQFHjshUIzuJHW;
	}

	public override string ToString()
	{
		return string.Empty;
	}
}
