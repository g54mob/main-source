using System;

internal abstract class upvGVYkuyycfihDbJJnflTMruYm
{
	public abstract IntPtr GetIntPtr();

	public abstract bool Init();

	public abstract bool Shutdown();

	public abstract void RunFrame();

	public abstract int GetConnectedControllers(ulong[] P_0);

	public abstract int GetConnectedControllers(IntPtr P_0);

	public abstract bool ShowBindingPanel(ulong P_0);

	public abstract ulong GetActionSetHandle(string P_0);

	public abstract void ActivateActionSet(ulong P_0, ulong P_1);

	public abstract ulong GetCurrentActionSet(ulong P_0);

	public abstract ulong GetDigitalActionHandle(string P_0);

	public abstract OBfMVxddjuYzEvCThHAmoKGjAhu GetDigitalActionData(ulong P_0, ulong P_1);

	public abstract int GetDigitalActionOrigins(ulong P_0, ulong P_1, ulong P_2, ref uint P_3);

	public abstract int GetDigitalActionOrigins(ulong P_0, ulong P_1, ulong P_2, qnWQnCnVygzqNYsMYlQfTwIvNew[] P_3);

	public abstract ulong GetAnalogActionHandle(string P_0);

	public abstract rcKBMqpHhHnQuCIOFQemglsFLir GetAnalogActionData(ulong P_0, ulong P_1);

	public abstract int GetAnalogActionOrigins(ulong P_0, ulong P_1, ulong P_2, ref uint P_3);

	public abstract int GetAnalogActionOrigins(ulong P_0, ulong P_1, ulong P_2, qnWQnCnVygzqNYsMYlQfTwIvNew[] P_3);

	public abstract void StopAnalogActionMomentum(ulong P_0, ulong P_1);

	public abstract void TriggerHapticPulse(ulong P_0, uint P_1, ushort P_2);
}
