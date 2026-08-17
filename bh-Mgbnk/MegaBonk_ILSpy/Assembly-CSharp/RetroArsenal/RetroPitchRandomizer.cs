using Cpp2ILInjected;
using UnityEngine;

namespace RetroArsenal;

public class RetroPitchRandomizer : MonoBehaviour
{
	public float randomPercent = 10f;

	private void Start()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		Transform transform = base.transform;
		AudioSource component = transform.GetComponent<AudioSource>();
		float pitch = component.pitch;
		float num = randomPercent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
		object obj = num ^ 0;
		float minInclusive = (float)obj / 100f;
		float maxInclusive = randomPercent / 100f;
		float num2 = Random.Range(minInclusive, maxInclusive);
		float num3 = num2 + 1f;
		float pitch2 = num3 * pitch;
		component.pitch = pitch2;
	}
}
