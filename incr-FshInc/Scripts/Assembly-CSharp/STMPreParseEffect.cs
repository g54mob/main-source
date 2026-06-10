using UnityEngine;

[RequireComponent(typeof(SuperTextMesh))]
public class STMPreParseEffect : MonoBehaviour
{
	public SuperTextMesh superTextMesh;

	public string colorName = "rainbow";

	private void Reset()
	{
		superTextMesh = GetComponent<SuperTextMesh>();
	}

	private void OnEnable()
	{
		superTextMesh.OnPreParse += AddTag;
	}

	private void OnDisable()
	{
		superTextMesh.OnPreParse -= AddTag;
	}

	private void AddTag(STMTextContainer container)
	{
		container.text = "<c=" + colorName + ">" + container.text;
	}
}
