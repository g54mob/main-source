using UnityEngine;

[RequireComponent(typeof(SuperTextMesh))]
public class STMPagination : MonoBehaviour
{
	public SuperTextMesh originalText;

	public SuperTextMesh overflowText;

	public void Awake()
	{
		overflowText.text = "";
	}

	public void OverflowLeftovers()
	{
		overflowText.text = originalText.leftoverText.TrimStart();
	}

	public void OverflowLeftovers(SuperTextMesh stm)
	{
		overflowText.text = stm.leftoverText.TrimStart();
	}

	public void Reset()
	{
		originalText = GetComponent<SuperTextMesh>();
	}

	public void OnEnable()
	{
		originalText.OnCompleteEvent += OverflowLeftovers;
	}

	public void OnDisable()
	{
		originalText.OnCompleteEvent -= OverflowLeftovers;
	}
}
