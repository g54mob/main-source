using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

public class CharacterLightManager : MonoBehaviour
{
	private Light2D characterLight;

	private float mapGlobalLightIntensity;

	public bool FixedIntensity;

	public Light2D CharacterLight => characterLight;

	private void Start()
	{
		Light2D light2D = characterLight;
		if ((object)characterLight == null || ((UnityEngine.Object)light2D).m_CachedPtr == (IntPtr)0)
		{
			Debug.LogError("Character Light not assigned.");
		}
	}

	private void Update()
	{
		if (!FixedIntensity)
		{
			GameManager core = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
			if (mainCharacters._size == 1)
			{
				Light2D light2D = characterLight;
				float intensity = 1f - mapGlobalLightIntensity;
				light2D.m_Intensity = intensity;
			}
			else if (mainCharacters._size > 1)
			{
				Light2D light2D2 = characterLight;
				float num = 1f - mapGlobalLightIntensity;
				float intensity2 = num / (float)mainCharacters._size;
				light2D2.m_Intensity = intensity2;
			}
		}
	}

	public CharacterLightManager()
	{
		//IL_0020: Expected I, but got O
		mapGlobalLightIntensity = 0.333f;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
