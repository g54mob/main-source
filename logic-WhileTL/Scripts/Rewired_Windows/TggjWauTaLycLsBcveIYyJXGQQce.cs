using System;
using System.Runtime.CompilerServices;

internal struct TggjWauTaLycLsBcveIYyJXGQQce : IEquatable<TggjWauTaLycLsBcveIYyJXGQQce>
{
	public static readonly TggjWauTaLycLsBcveIYyJXGQQce DNUQeQhbcXahkIqZaBMMfAOQscLb = new TggjWauTaLycLsBcveIYyJXGQQce(0f, 0f);

	public static readonly TggjWauTaLycLsBcveIYyJXGQQce uMVHqbcnPiGcMKRopEupOZnOYltfA = DNUQeQhbcXahkIqZaBMMfAOQscLb;

	public float sMhjKmedaJXvuWuJjxGXzPNNYASh;

	public float QEnfVkaMwVYHdztLXaIgjMjEhryEA;

	public TggjWauTaLycLsBcveIYyJXGQQce(float P_0, float P_1)
	{
		sMhjKmedaJXvuWuJjxGXzPNNYASh = P_0;
		QEnfVkaMwVYHdztLXaIgjMjEhryEA = P_1;
	}

	public bool Equals(TggjWauTaLycLsBcveIYyJXGQQce other)
	{
		if (other.sMhjKmedaJXvuWuJjxGXzPNNYASh == sMhjKmedaJXvuWuJjxGXzPNNYASh)
		{
			return other.QEnfVkaMwVYHdztLXaIgjMjEhryEA == QEnfVkaMwVYHdztLXaIgjMjEhryEA;
		}
		return false;
	}

	public bool XGTrzxcWbPBiyHnRYfIhrjXAmNvN(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if ((object)P_0.GetType() != typeof(TggjWauTaLycLsBcveIYyJXGQQce))
		{
			return false;
		}
		return Equals((TggjWauTaLycLsBcveIYyJXGQQce)P_0);
	}

	public int bmOcwbrzltTGalVFCIlUiIeugfGh()
	{
		return (sMhjKmedaJXvuWuJjxGXzPNNYASh.GetHashCode() * 397) ^ QEnfVkaMwVYHdztLXaIgjMjEhryEA.GetHashCode();
	}

	[SpecialName]
	public static bool UxzrDeMrBdIYZHmpHMJBdoPkTemL(TggjWauTaLycLsBcveIYyJXGQQce P_0, TggjWauTaLycLsBcveIYyJXGQQce P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool ymVlplVHAhddfhnAkCmAWabpGMPgb(TggjWauTaLycLsBcveIYyJXGQQce P_0, TggjWauTaLycLsBcveIYyJXGQQce P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
	{
		return $"({sMhjKmedaJXvuWuJjxGXzPNNYASh},{QEnfVkaMwVYHdztLXaIgjMjEhryEA})";
	}
}
