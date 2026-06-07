using Rewired;
using Rewired.Interfaces;
using Rewired.Platforms.Custom;
using UnityEngine;

internal class hxycXAiSqHTUgzqdFOdDFlhyefffA : tPGRFTYXuGFqwLQBERoDOsedxtCo, IUnifiedMouseSource
{
	Vector2 IUnifiedMouseSource.mousePosition => ((CustomPlatformUnifiedMouseSource)akMLpjOlowLRkzJlEVxjILjMsNqM).mousePosition;

	public hxycXAiSqHTUgzqdFOdDFlhyefffA(CustomPlatformUnifiedMouseSource P_0)
		: base(P_0, UnityUnifiedMouseSource.CreateHardwareMap())
	{
	}
}
