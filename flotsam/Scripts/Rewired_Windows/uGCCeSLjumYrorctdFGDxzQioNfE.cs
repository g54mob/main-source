using System;
using System.Runtime.CompilerServices;

internal struct uGCCeSLjumYrorctdFGDxzQioNfE : IEquatable<uGCCeSLjumYrorctdFGDxzQioNfE>
{
	public static readonly uGCCeSLjumYrorctdFGDxzQioNfE AGcWtMBgQWgRKATmRAlbGYyiTgJBA = new uGCCeSLjumYrorctdFGDxzQioNfE(0, 0);

	public static readonly uGCCeSLjumYrorctdFGDxzQioNfE kCjUdOFKPIEAnWfOmymTlwFEwClH = AGcWtMBgQWgRKATmRAlbGYyiTgJBA;

	public int QSuEQaKtwswQVEEXTXTDJCjJaThqA;

	public int heYjgmvxeuxRCxBjgfqecFnnWAfO;

	public uGCCeSLjumYrorctdFGDxzQioNfE(int P_0, int P_1)
	{
		QSuEQaKtwswQVEEXTXTDJCjJaThqA = P_0;
		heYjgmvxeuxRCxBjgfqecFnnWAfO = P_1;
	}

	public bool Equals(uGCCeSLjumYrorctdFGDxzQioNfE other)
	{
		if (other.QSuEQaKtwswQVEEXTXTDJCjJaThqA == QSuEQaKtwswQVEEXTXTDJCjJaThqA)
		{
			return other.heYjgmvxeuxRCxBjgfqecFnnWAfO == heYjgmvxeuxRCxBjgfqecFnnWAfO;
		}
		return false;
	}

	bool IEquatable<uGCCeSLjumYrorctdFGDxzQioNfE>.Equals(uGCCeSLjumYrorctdFGDxzQioNfE other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool mwfdpETtJBJooDoZuCDVKnJyJtYkA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(uGCCeSLjumYrorctdFGDxzQioNfE))
		{
			return false;
		}
		return Equals((uGCCeSLjumYrorctdFGDxzQioNfE)P_0);
	}

	public int YuVIgLdWorjSfkXNCGrcNlmHPooM()
	{
		return (QSuEQaKtwswQVEEXTXTDJCjJaThqA * 397) ^ heYjgmvxeuxRCxBjgfqecFnnWAfO;
	}

	[SpecialName]
	public static bool JUwghcDhDcdGaAGwtcPTrDWQCpqh(uGCCeSLjumYrorctdFGDxzQioNfE P_0, uGCCeSLjumYrorctdFGDxzQioNfE P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool ALHgXdHKJHUrZQtkJDurbgPiaXrWA(uGCCeSLjumYrorctdFGDxzQioNfE P_0, uGCCeSLjumYrorctdFGDxzQioNfE P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string ETAKqOPCenrMhNAWIjMCVLICheEl()
	{
		return $"({QSuEQaKtwswQVEEXTXTDJCjJaThqA},{heYjgmvxeuxRCxBjgfqecFnnWAfO})";
	}
}
