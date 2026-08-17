using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors.Framework;

public class GlimmerTechniqueCarouselItem : MonoBehaviour
{
	private TextMeshProUGUI m_Text;

	private SpriteRenderer m_Background;

	public float Age;

	public void Activate(string glimmerTechniqueText)
	{
		//IL_003f: Invalid comparison between I and F4
		m_Text.text = glimmerTechniqueText;
		TextMeshProUGUI text = m_Text;
		Age = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v4 (TMPro.TextMeshProUGUI)+15C]");
		bool flag = 0f == 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877DC854h\"");
		if (!flag)
		{
			_ = 1065353216;
			((TMP_Text)text).m_havePropertiesChanged = true;
			text.SetVerticesDirty();
		}
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(m_Background, 0.65f);
	}

	public void Hide()
	{
		TextMeshProUGUI text = m_Text;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rcx_v2 (TMPro.TextMeshProUGUI)+15C]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877DC90Fh\"");
		if (!flag)
		{
			_ = 0;
			((TMP_Text)text).m_havePropertiesChanged = true;
			text.SetVerticesDirty();
		}
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(m_Background, 0f);
		Age = 0f;
	}

	public GlimmerTechniqueCarouselItem()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
