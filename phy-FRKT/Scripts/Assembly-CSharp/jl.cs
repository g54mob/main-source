using System;
using Player.Toolbar.ItemHint;

public interface jl
{
	bool xak { get; }

	string xal { get; }

	event Action<string> yef;

	event Action<HintClearReasonType> yeg;
}
