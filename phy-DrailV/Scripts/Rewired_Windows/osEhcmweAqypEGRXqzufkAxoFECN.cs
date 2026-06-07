using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal class osEhcmweAqypEGRXqzufkAxoFECN
{
	public IntPtr eRuooOpUXUMNyxAVfhJQXVsDGDql;

	public osEhcmweAqypEGRXqzufkAxoFECN(IntPtr P_0)
	{
		eRuooOpUXUMNyxAVfhJQXVsDGDql = P_0;
	}

	public unsafe osEhcmweAqypEGRXqzufkAxoFECN(void* P_0)
	{
		eRuooOpUXUMNyxAVfhJQXVsDGDql = new IntPtr(P_0);
	}

	[SpecialName]
	public static IntPtr IBFxjPKSVGakniVxxRyuoOQSHIuC(osEhcmweAqypEGRXqzufkAxoFECN P_0)
	{
		return P_0.eRuooOpUXUMNyxAVfhJQXVsDGDql;
	}

	[SpecialName]
	public static osEhcmweAqypEGRXqzufkAxoFECN bPhBTDiXwPSGeHgqUdzKHurTqKRxA(IntPtr P_0)
	{
		return new osEhcmweAqypEGRXqzufkAxoFECN(P_0);
	}

	[SpecialName]
	public unsafe static void* bPhBTDiXwPSGeHgqUdzKHurTqKRxA(osEhcmweAqypEGRXqzufkAxoFECN P_0)
	{
		return (void*)P_0.eRuooOpUXUMNyxAVfhJQXVsDGDql;
	}

	[SpecialName]
	public unsafe static osEhcmweAqypEGRXqzufkAxoFECN IBFxjPKSVGakniVxxRyuoOQSHIuC(void* P_0)
	{
		return new osEhcmweAqypEGRXqzufkAxoFECN(P_0);
	}

	public virtual string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { eRuooOpUXUMNyxAVfhJQXVsDGDql });
	}

	public string GvNCmPFePpgwRPnXVCmFehxNQKcDb(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { eRuooOpUXUMNyxAVfhJQXVsDGDql.ToString(P_0) });
	}

	public virtual int fEwcDhFDzGumYFCZRxsMimpbheAt()
	{
		return eRuooOpUXUMNyxAVfhJQXVsDGDql.ToInt32();
	}

	public bool JRxBWnhQlwwPGktFTDexAbegXFrzB(osEhcmweAqypEGRXqzufkAxoFECN P_0)
	{
		return eRuooOpUXUMNyxAVfhJQXVsDGDql == P_0.eRuooOpUXUMNyxAVfhJQXVsDGDql;
	}

	public virtual bool JRxBWnhQlwwPGktFTDexAbegXFrzB(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if ((object)P_0.GetType() != typeof(osEhcmweAqypEGRXqzufkAxoFECN))
		{
			return false;
		}
		return JRxBWnhQlwwPGktFTDexAbegXFrzB((osEhcmweAqypEGRXqzufkAxoFECN)P_0);
	}
}
