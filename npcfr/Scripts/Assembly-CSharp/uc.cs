using System;
using Effectors.ReceiveMethods.Index;
using JetBrains.Annotations;
using Unity.Mathematics;

public interface uc
{
	const float rsx = 100f;

	const float rsy = 0f;

	[CanBeNull]
	Type xfm { get; }

	ue rso { get; }

	Type xfo { get; }

	void gvk(rx a);

	bool gvl(IndexEffectorSignal a, bool b, bool c, out IndexEffectorFeedback d);

	bool gvm(IndexEffectorSignal a, bool b, bool c, out IndexEffectorFeedback d);

	bool gvo(int3 a, bool b, out IndexEffectorSignal c);

	void gvn(int a);
}
