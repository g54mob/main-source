using System;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal sealed class oEKjTOxtumqnvVGrvGQjjCekBlgfb : fuTAbCyJgOZBWWgBXmUSttFWWuoi, IDisposable
{
	private Action lIKxPMkvtlRRoyCnSWrHGPaiJLyM;

	private Id EiFmrskaycOzufcnQDXIVEWmYcMC;

	private bool vrUfzxYqLmnhZEFbQjSsfoGdBxCV;

	public oEKjTOxtumqnvVGrvGQjjCekBlgfb(Action P_0)
	{
		lIKxPMkvtlRRoyCnSWrHGPaiJLyM = P_0;
		EiFmrskaycOzufcnQDXIVEWmYcMC = 0u;
		LocalizationManager.Add(this, ref EiFmrskaycOzufcnQDXIVEWmYcMC);
	}

	void fuTAbCyJgOZBWWgBXmUSttFWWuoi.Localize()
	{
		lIKxPMkvtlRRoyCnSWrHGPaiJLyM();
	}

	private void VdSCIjLsjhvFvOCxZtIqTXRMcMaW(bool P_0)
	{
		if (!vrUfzxYqLmnhZEFbQjSsfoGdBxCV)
		{
			if (P_0)
			{
				LocalizationManager.Remove(ref EiFmrskaycOzufcnQDXIVEWmYcMC);
			}
			vrUfzxYqLmnhZEFbQjSsfoGdBxCV = true;
		}
	}

	public void Dispose()
	{
		VdSCIjLsjhvFvOCxZtIqTXRMcMaW(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
