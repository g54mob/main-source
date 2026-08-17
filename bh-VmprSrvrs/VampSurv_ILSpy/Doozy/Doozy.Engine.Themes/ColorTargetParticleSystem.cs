using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Themes;

public class ColorTargetParticleSystem : ThemeTarget
{
	public ParticleSystem ParticleSystem;

	public bool OverrideAlpha;

	public float Alpha;

	private float m_previousAlphaValue = -1f;

	private void Update()
	{
		if (OverrideAlpha)
		{
			bool flag = Alpha == m_previousAlphaValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C0344Ch\"");
			if (!flag)
			{
				SetAlpha(Alpha);
				m_previousAlphaValue = Alpha;
			}
		}
	}

	public unsafe override void UpdateTarget(ThemeData theme)
	{
		//IL_0262: Expected O, but got Ref
		//IL_026f: Expected O, but got Ref
		//IL_0285: Expected O, but got Ref
		ParticleSystem particleSystem = ParticleSystem;
		if ((object)ParticleSystem == null || ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0 || (object)theme == null || ((UnityEngine.Object)theme).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if ((object)ThemeId == (object)Guid.Empty)
		{
			object obj = (object)Guid.Empty >> 32;
			object obj2 = (object)ThemeId >> 32;
			if (obj2 == obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)ThemeId == (object)Guid.Empty)
				{
					object obj3 = (object)Guid.Empty >> 32;
					object obj4 = (object)ThemeId >> 32;
					if (obj4 == obj3)
					{
						return;
					}
				}
			}
		}
		if ((object)PropertyId == (object)Guid.Empty)
		{
			object obj5 = (object)Guid.Empty >> 32;
			object obj6 = (object)PropertyId >> 32;
			if (obj6 == obj5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)PropertyId == (object)Guid.Empty)
				{
					object obj7 = (object)Guid.Empty >> 32;
					object obj8 = (object)PropertyId >> 32;
					if (obj8 == obj7)
					{
						return;
					}
				}
			}
		}
		ThemeVariantData activeVariant = theme.ActiveVariant;
		if (activeVariant != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
			ThemeVariantData activeVariant2 = theme.ActiveVariant;
			Guid guid = default(Guid);
			Color color = activeVariant2.GetColor((Guid)(&guid));
			ParticleSystem.MinMaxGradient minMaxGradient = (Color)(&guid);
			ParticleSystem.MainModule mainModule = default(ParticleSystem.MainModule);
			object obj9 = default(object);
			mainModule.startColor = (ParticleSystem.MinMaxGradient)(&obj9);
			if (OverrideAlpha)
			{
				SetAlpha(Alpha);
			}
		}
	}

	public unsafe void SetAlpha(float value)
	{
		//IL_0096: Expected O, but got Ref
		//IL_00a7: Expected O, but got Ref
		ParticleSystem particleSystem = ParticleSystem;
		if ((object)ParticleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
		{
			Alpha = value;
			ParticleSystem.MainModule mainModule = default(ParticleSystem.MainModule);
			ParticleSystem.MinMaxGradient startColor = mainModule.startColor;
			object obj = default(object);
			ParticleSystem.MinMaxGradient minMaxGradient = (Color)(&obj);
			ParticleSystemGradientMode particleSystemGradientMode = default(ParticleSystemGradientMode);
			mainModule.startColor = (ParticleSystem.MinMaxGradient)(&particleSystemGradientMode);
		}
	}

	private void Reset()
	{
		ThemeId = Guid.Empty;
		VariantId = Guid.Empty;
		PropertyId = Guid.Empty;
		ParticleSystem particleSystem = ParticleSystem;
		if ((object)ParticleSystem == null || ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0)
		{
			ParticleSystem component = GetComponent<ParticleSystem>();
			ParticleSystem = component;
		}
	}

	private void UpdateReference()
	{
		ParticleSystem particleSystem = ParticleSystem;
		if ((object)ParticleSystem == null || ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0)
		{
			ParticleSystem component = GetComponent<ParticleSystem>();
			ParticleSystem = component;
		}
	}
}
