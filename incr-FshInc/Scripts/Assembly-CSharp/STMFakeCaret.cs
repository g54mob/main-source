using UnityEngine;

public class STMFakeCaret : MonoBehaviour
{
	public SuperTextMesh stm;

	public Vector3 offset;

	private void OnEnable()
	{
		stm.OnPrintEvent += MoveCaret;
	}

	private void OnDisable()
	{
		stm.OnPrintEvent -= MoveCaret;
	}

	private void MoveCaret()
	{
		if (stm != null && stm.info.Count > 0 && stm.latestNumber > -1 && stm.hyphenedText[stm.latestNumber] != '\n')
		{
			STMTextInfo sTMTextInfo = stm.info[stm.latestNumber];
			base.transform.localPosition = sTMTextInfo.pos + sTMTextInfo.Advance(stm.characterSpacing, stm.quality) + offset;
		}
	}
}
