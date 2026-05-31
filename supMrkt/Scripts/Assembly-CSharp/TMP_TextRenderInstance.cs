using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TMP_TextRenderInstance : LODInstance
{
	private TMP_Text m_Text;

	private Renderer m_Renderer;

	private void Awake()
	{
	}

	public override void SetAvailability(bool b)
	{
	}
}
