using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace VampireSurvivors.UI;

public class FPSText : MonoBehaviour
{
	public TextMeshProUGUI gameFPS;

	private float fpsCounter;

	private float currentFpsTime;

	private float fpsShowPeriod;

	private unsafe void Update()
	{
		//IL_004c: Expected O, but got F4
		//IL_001b: Expected Ref, but got F4
		object obj = Time.deltaTime;
		object obj2 = default(object);
		float num = (float)obj2 + currentFpsTime;
		float num2 = fpsCounter + 1f;
		fpsCounter = num2;
		currentFpsTime = num;
		if (num > fpsShowPeriod)
		{
			float num3 = (float)this + 40f;
			string text = ((float*)num3)->ToString();
			gameFPS.text = text;
			fpsCounter = 0f;
		}
	}

	public FPSText()
	{
		//IL_0020: Expected I, but got O
		fpsShowPeriod = 1f;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
